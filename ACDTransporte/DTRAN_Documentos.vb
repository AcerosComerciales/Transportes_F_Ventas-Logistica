Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACETransporte

Partial Public Class DTRAN_Documentos

#Region " Variables "

#End Region

#Region " Constructores "

#End Region

#Region " Procedimientos Almacenados "

    ' <summary> 
    ' Capa de Datos: TRAN_ObtenerDocumentosCompra
    ' </summary>
    ' <param name="x_fecini">Parametro 1: </param> 
    ' <param name="x_fecfin">Parametro 2: </param> 
    ' <param name="x_pvent_id">Parametro 3: </param> 
    ' <param name="x_opcion">Parametro 4: </param> 
    ' <param name="x_cadena">Parametro 5: </param> 
    ' <param name="x_todos">Parametro 6: </param> 
    ' <returns></returns> 
    ' <remarks></remarks> 
    Public Function TRAN_ObtenerDocumentosCompra(ByVal m_listtran_documentos As List(Of ETRAN_Documentos), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_opcion As Short, ByVal x_cadena As String, ByVal x_todos As Boolean) As Boolean
        Try
            DAEnterprise.AsignarProcedure("TRAN_ObtenerDocumentosCompra")
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
            DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
            DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _tran_documentos As New ETRAN_Documentos()
                        ACEsquemas.ACCargarEsquema(reader, _tran_documentos)
                        _tran_documentos.Instanciar(ACEInstancia.Consulta)
                        m_listtran_documentos.Add(_tran_documentos)
                    End While
                    Return True
                Else
                    Return False
                End If
            End Using
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TRAN_ObtenerDocumentosCompraNow(ByVal m_listtran_documentos As List(Of ETRAN_Documentos), ByVal x_fecini As Date, ByVal x_fecfin As Date, ByVal x_pvent_id As Long, ByVal x_cadena As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure("TRAN_ObtenerDocumentosCompra_all")
            DAEnterprise.AgregarParametro("@FecIni", x_fecini, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@FecFin", x_fecfin, DbType.DateTime, 8)
            DAEnterprise.AgregarParametro("@PVENT_Id", x_pvent_id, DbType.Int64, 8)
            '  DAEnterprise.AgregarParametro("@Opcion", x_opcion, DbType.Int16, 2)
            DAEnterprise.AgregarParametro("@Cadena", x_cadena, DbType.String, 50)
            '   DAEnterprise.AgregarParametro("@Todos", x_todos, DbType.Boolean, 1)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _tran_documentos As New ETRAN_Documentos()
                        ACEsquemas.ACCargarEsquema(reader, _tran_documentos)
                        _tran_documentos.Instanciar(ACEInstancia.Consulta)
                        m_listtran_documentos.Add(_tran_documentos)
                    End While
                    Return True
                Else
                    Return False
                End If
            End Using
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#Region "Procedimientos Adicionales "

#End Region
#End Region

#Region " Metodos "
    Public Function CargarDetalle(ByVal x_tran_documentos As ETRAN_Documentos, ByVal x_condicion As String) As Boolean
        Dim _sql As String = ""
        Try
            x_tran_documentos.ListETRAN_DocumentosDetalle = New List(Of ETRAN_DocumentosDetalle)

            _sql &= String.Format("Select Ent.ENTID_RazonSocial, Det.*{0}", vbNewLine)
            _sql &= String.Format(",TDoc.TIPOS_DescCorta + ' ' + RIGHT(Doc.DOCUS_Serie, 3) + '-' + Right(Doc.DOCUS_Codigo, 7) As Codigo{0}", vbNewLine)
            _sql &= String.Format("From Transportes.TRAN_Documentos As Doc{0}", vbNewLine)
            _sql &= String.Format("Inner Join Entidades As Ent On Ent.ENTID_Codigo = Doc.ENTID_Codigo{0}", vbNewLine)
            _sql &= String.Format("Inner Join Transportes.TRAN_DocumentosDetalle As Det On Det.DOCUS_Codigo = Doc.DOCUS_Codigo And Det.ENTID_Codigo = Doc.ENTID_Codigo{0}", vbNewLine)
            _sql &= String.Format("Inner Join Tipos As TDoc On TDoc.TIPOS_Codigo = Doc.TIPOS_CodTipoDocumento{0}", vbNewLine)
            _sql &= String.Format("Where Doc.DOCUS_Codigo + Doc.ENTID_Codigo In ({1}){0}", vbNewLine, x_condicion)
            _sql &= String.Format("{0}", vbNewLine)

            DAEnterprise.AsignarProcedure(_sql, CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _tran_documentos As New ETRAN_DocumentosDetalle()
                        ACEsquemas.ACCargarEsquema(reader, _tran_documentos)
                        _tran_documentos.Instanciar(ACEInstancia.Consulta)
                        x_tran_documentos.ListETRAN_DocumentosDetalle.Add(_tran_documentos)
                    End While
                    Return True
                Else
                    Return False
                End If
            End Using
            Return True


        Catch ex As Exception
            Throw ex
        End Try
    End Function


    ' CargarDetalleMantenimiento
    Public Function CargarDetalleMantenimiento(ByVal x_tran_documentos As ETRAN_Documentos, ByVal x_condicion As String) As Boolean
        Dim _sql As String = ""
        Try
            x_tran_documentos.ListETRAN_DocumentosDetalle = New List(Of ETRAN_DocumentosDetalle)

            _sql &= String.Format("Select Ent.ENTID_RazonSocial, Det.*{0}", vbNewLine)
            _sql &= String.Format(",TDoc.TIPOS_DescCorta + ' ' + RIGHT(Doc.DOCUS_Serie, 3) + '-' + Right(Doc.DOCUS_Codigo, 7) As Codigo{0}", vbNewLine)
            _sql &= String.Format("From Transportes.TRAN_Documentos As Doc{0}", vbNewLine)
            _sql &= String.Format("Inner Join Entidades As Ent On Ent.ENTID_Codigo = Doc.ENTID_Codigo{0}", vbNewLine)
            _sql &= String.Format("Inner Join Transportes.TRAN_DocumentosDetalle As Det On Det.DOCUS_Codigo = Doc.DOCUS_Codigo And Det.ENTID_Codigo = Doc.ENTID_Codigo{0}", vbNewLine)
            _sql &= String.Format("Inner Join Tipos As TDoc On TDoc.TIPOS_Codigo = Doc.TIPOS_CodTipoDocumento{0}", vbNewLine)
            _sql &= String.Format("Where Doc.DOCUS_Codigo + Doc.ENTID_Codigo In ({1}){0}", vbNewLine, x_condicion)
            _sql &= String.Format("{0}", vbNewLine)

            DAEnterprise.AsignarProcedure(_sql, CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    While reader.Read()
                        Dim _tran_documentos As New ETRAN_DocumentosDetalle()
                        ACEsquemas.ACCargarEsquema(reader, _tran_documentos)
                        _tran_documentos.Instanciar(ACEInstancia.Consulta)
                        x_tran_documentos.ListETRAN_DocumentosDetalle.Add(_tran_documentos)
                    End While
                    Return True
                Else
                    Return False
                End If
            End Using
            Return True


        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region


End Class

