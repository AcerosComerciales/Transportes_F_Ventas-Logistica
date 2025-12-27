Imports ACETransporte
Imports ACFramework

Imports DAConexion
Imports System
Imports System.Data.Common

Partial Public Class DTRAN_Neumaticos

#Region " Constructores "

#End Region

#Region " Procedimientos Almacenados "
    Public Function NEUMSS_Todos(ByRef listETRAN_Neumaticos As List(Of ETRAN_Neumaticos), ByVal x_cadena As String) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(x_cadena), CommandType.Text)
            Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
                If reader.HasRows Then
                    Dim _utilitarios As New ACEsquemas(New ETRAN_Neumaticos())
                    While reader.Read()
                        Dim e_tran_neumaticos As New ETRAN_Neumaticos()
                        _utilitarios.ACCargarEsquemas(reader, e_tran_neumaticos)
                        e_tran_neumaticos.Instanciar(ACEInstancia.Consulta)
                        listETRAN_Neumaticos.Add(e_tran_neumaticos)
                    End While
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function NEUMSS_TodosAyuda(ByRef dtETRAN_Neumaticos As DataTable, ByVal x_where As Hashtable) As Boolean
        Try
            DAEnterprise.AsignarProcedure(getSelectAyuda(x_where), CommandType.Text)
            dtETRAN_Neumaticos = DAEnterprise.ExecuteDataSet().Tables(0)
            Return dtETRAN_Neumaticos.Rows.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function getCorrelativo() As Integer
        Try
            DAEnterprise.AsignarProcedure(getSelectId(), CommandType.Text)
            Dim m_data As DataSet = DAEnterprise.ExecuteDataSet()
            Return CType(m_data.Tables(0).Rows(0)("NEUMA_Id"), Integer)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


#Region "Procedimientos Adicionales "
    Public Function getSelectAll(ByVal x_cadena As String) As String
        Dim sql As String
        Try
            sql = " SELECT "
            sql &= " Neu.*"
            sql &= ",TIPOS_CodMoneda"
            sql &= ",Suc.SUCUR_Nombre"
            sql &= ",TMarca.TIPOS_Descripcion TIPO_Marca"
            sql &= " FROM Transportes.TRAN_Neumaticos As Neu "
            sql &= " Inner Join Sucursales As Suc On Suc.SUCUR_Id = Neu.SUCUR_Id "
            sql &= " Inner Join Tipos As TMarca On TMarca.TIPOS_Codigo = Neu.TIPOS_CodMarca "
            sql &= " WHERE "
            sql &= "NEUMA_Codigo Like '%" + x_cadena & "%'"
            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function getSelectAyuda(ByVal x_where As Hashtable) As String
        Dim sql As String = String.Empty
        Try
            '   sql = "  Select Neu.NEUMA_Id As Interno, Neu.NEUMA_Codigo AS Codigo, Neu.NEUMA_Modelo As Modelo,Neu.NEUMA_NroPosicion as [Posicion],Neu.Neuma_Precio as Precio,Neu.NEUMA_KmVidaUtil as KMUtil ,Neu.NEUMA_Tamano,Neu.NEUMA_Parches as Parches ,  TNeu.TIPOs_DESCRIPCION As [Tipo Llanta], TMarca.TIPOs_DESCRIPCION  As [Marca], Convert(date, Neu.NEUMA_FecCompra) As [Fec. Compra], NEUMA_KmVidaUtil As Kilometraje ,Neu.NEUMA_Estado as ESTADO From Transportes.TRAN_Neumaticos As Neu Inner Join Tipos As TNeu On TNeu.TIPOS_Codigo = Neu.TIPOS_CodTipoLlanta Inner Join Tipos As TMarca On TMarca.TIPOS_Codigo = Neu.TIPOS_CodMarca "
            sql = "SELECT 
    Neu.NEUMA_Id AS Interno,
    CASE 
        WHEN VehNeuma.VEHIC_Id  IS not  NULL THEN 'Placa/Vehiculo : ' + Vehiculo.VEHIC_PLACA
		when VehNeuma.RANFL_Id IS NOT NULL  THEN  'Placa/Ranfla : ' + Ranfla.RANFL_Placa
        ELSE 'SIn Vehiculo Asignado' 
    END AS Asignaciones,
    Neu.NEUMA_Codigo AS Codigo,
    Neu.NEUMA_Modelo AS Modelo,
    Neu.NEUMA_NroPosicion AS [Posicion],
    CASE 
        WHEN Neu.NEUMA_Estado = 'A' THEN 'Activo'
        ELSE 'Inactivo'
    END AS Estado
	,Entid.ENTID_Nombres as CreadoPor,
    Neu.Neuma_Precio AS Precio,
    Neu.NEUMA_KmVidaUtil AS KMUtil,
    Neu.NEUMA_Tamano,
    Neu.NEUMA_Parches AS Parches,
    TNeu.TIPOs_DESCRIPCION AS [Tipo Llanta],
    TMarca.TIPOs_DESCRIPCION AS [Marca],
    CONVERT(date, Neu.NEUMA_FecCompra) AS [Fec. Compra],
    NEUMA_KmVidaUtil AS Kilometraje,
	  ISNULL(VehNeuma.VEHIC_Id, 0) AS VEHIC_Id,
    ISNULL(VehNeuma.RANFL_Id, 0) AS RANFL_Id
FROM 
    Transportes.TRAN_Neumaticos AS Neu     
LEFT JOIN 
    Transportes.TRAN_VehiculosNeumaticos AS VehNeuma ON VehNeuma.NEUMA_Id = Neu.NEUMA_Id
LEFT JOIN 
    Transportes.TRAN_Vehiculos AS Vehiculo ON Vehiculo.VEHIC_Id = VehNeuma.VEHIC_Id
	left JOIN Transportes.TRAN_Ranflas as Ranfla on VehNeuma.RANFL_Id  = Ranfla.RANFL_Id
INNER JOIN 
    Tipos AS TNeu ON TNeu.TIPOS_Codigo = Neu.TIPOS_CodTipoLlanta
INNER JOIN 
    Tipos AS TMarca ON TMarca.TIPOS_Codigo = Neu.TIPOS_CodMarca
	iNNER JOIN 
	Entidades  as Entid on Neu.NEUMA_UsrCrea  = Entid.ENTID_Codigo"
            If Not IsNothing(x_where) Then
                sql &= " WHERE   Neu.NEUMA_Estado =  'A'  "
                '   Dim _where As New ACGenerador(Of ETRAN_Neumaticos)(m_formatofecha)
                '  sql &= _where.getWhere(x_where, True)
                'sql &= "and VehNeuma.VEHIC_Id is null AND  VehNeuma.RANFL_Id  is null "
                sql &= "order by Neu.NEUMA_FecCompra DESC"
            End If
            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function getSelectID() As String
        Dim sql As String = String.Empty
        Try
            sql &= String.Format("SELECT isnull(max(TN.NEUMA_Id),0) as NEUMA_Id  from Transportes.TRAN_Neumaticos TN {0}", vbNewLine)
            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region
#End Region

End Class

