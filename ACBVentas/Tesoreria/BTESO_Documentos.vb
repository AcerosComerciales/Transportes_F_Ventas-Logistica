Imports System
Imports System.Data
Imports System.Collections.Generic
Imports DAConexion
Imports ACEVentas
Imports ACDVentas

Partial Public Class BTESO_Documentos

#Region " Variables "
	
#End Region

#Region " Constructores "
	
#End Region

#Region " Propiedades "
	
#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "

   ''' <summary>
   ''' Generar documento de compra
   ''' </summary>
   ''' <param name="x_descripcion"></param>
   ''' <param name="x_usuario"></param>
   ''' <param name="x_tran"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GenerarDocumento(ByVal x_descripcion As String, ByVal x_usuario As String, Optional ByVal x_tran As Boolean = True) As Boolean
      Try
         If x_tran Then DAEnterprise.BeginTransaction()
         If Guardar(x_usuario) Then
            Dim _teso_documentosdetalle As New BTESO_DocumentosDetalle
            _teso_documentosdetalle.TESO_DocumentosDetalle = New ETESO_DocumentosDetalle
            _teso_documentosdetalle.TESO_DocumentosDetalle.Instanciar(ACFramework.ACEInstancia.Nuevo)

            _teso_documentosdetalle.TESO_DocumentosDetalle.DOCUS_Codigo = m_eteso_documentos.DOCUS_Codigo
            _teso_documentosdetalle.TESO_DocumentosDetalle.ENTID_Codigo = m_eteso_documentos.ENTID_Codigo
            _teso_documentosdetalle.TESO_DocumentosDetalle.DCDET_Item = 1
            _teso_documentosdetalle.TESO_DocumentosDetalle.DCDET_Cantidad = 1
            _teso_documentosdetalle.TESO_DocumentosDetalle.DCDET_Descripcion = x_descripcion
            _teso_documentosdetalle.TESO_DocumentosDetalle.DCDET_Importe = m_eteso_documentos.DOCUS_Importe
            _teso_documentosdetalle.TESO_DocumentosDetalle.DCDET_SubImporte = m_eteso_documentos.DOCUS_Importe
            _teso_documentosdetalle.TESO_DocumentosDetalle.DCDET_Estado = Constantes.getEstado(Constantes.Estado.Ingresado)
            If _teso_documentosdetalle.Guardar(x_usuario) Then
               If x_tran Then DAEnterprise.CommitTransaction()
               Return True
            Else
               Throw New Exception("No se puede grabar el registro del detalle del documento")
            End If
         End If
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function
#End Region

End Class

