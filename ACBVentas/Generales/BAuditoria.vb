Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas
Imports System.Configuration

Imports ACFramework

Public Class BAuditoria


#Region " Variables "
   Private m_autorizacion As Boolean
#End Region

#Region " Constructores "
	
#End Region

#Region " Propiedades "
   Public Property Autorizacion() As Boolean
      Get
         Return m_autorizacion
      End Get
      Set(ByVal value As Boolean)
         m_autorizacion = value
      End Set
   End Property

#End Region

#Region " Funciones para obtencion de datos "
	
#End Region

#Region " Metodos "

   ''' <summary>
   ''' Agregar autorizacion para una accion definida
   ''' </summary>
   ''' <param name="x_aplic_codigo">codigo de aplicacion</param>
   ''' <param name="x_zonas_codigo">codig de la zona</param>
   ''' <param name="x_sucur_id">codigo de la sucursal</param>
   ''' <param name="x_documento">documento al que se le aplica la autorizacion</param>
   ''' <param name="x_codigo">codigo de referencia para la autorizacion</param>
   ''' <param name="x_entid_codigo">codigo del la entidad que asigna la autorizacion</param>
   ''' <param name="x_tipos_codproceso">codigo del proceso que se esta autorizando</param>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function AgregarAutorizacion(ByVal x_aplic_codigo As String, ByVal x_zonas_codigo As String, ByVal x_sucur_id As Short _
                                       , ByVal x_documento As String, ByVal x_codigo As String, ByVal x_entid_codigo As String _
                                       , ByVal x_tipos_codproceso As String, ByVal x_usuario As String) As Boolean
      Try
         m_auditoria = New EAuditoria()
         m_auditoria.APLIC_Codigo = x_aplic_codigo
         m_auditoria.ZONAS_Codigo = x_zonas_codigo
         m_auditoria.SUCUR_Id = x_sucur_id
         m_auditoria.TIPOS_CodTipoDocumento = x_documento
         m_auditoria.AUDIT_Estado = EAuditoria.getEstado(EAuditoria.Estado.Ingresado)
         m_auditoria.ENTID_CodigoOtorgado = x_entid_codigo
         m_auditoria.TIPOS_CodTipoProceso = x_tipos_codproceso
         m_auditoria.Instanciar(ACFramework.ACEInstancia.Nuevo)
         If m_auditoria.Nuevo Then m_auditoria.AUDIT_Id = getCorrelativo()

         m_auditoria.AUDIT_CodigoReferencia = x_codigo
         Return Guardar(x_usuario)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Quitar la autorizacion asignada a un documento
   ''' </summary>
   ''' <param name="x_audit_id">codigo de auditoria</param>
   ''' <param name="x_aplicacion">codigo de aplicacion</param>
   ''' <param name="x_sucursal">codigo de la sucursal</param>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function QuitarAutorizacion(ByVal x_audit_id As Integer, ByVal x_aplicacion As String, ByVal x_sucursal As Integer, ByVal x_usuario As String) As Boolean
      Try
         m_auditoria = New EAuditoria()
         m_auditoria.AUDIT_Id = x_audit_id
         m_auditoria.APLIC_Codigo = x_aplicacion
         m_auditoria.SUCUR_Id = x_sucursal
         m_auditoria.AUDIT_Estado = EAuditoria.getEstado(EAuditoria.Estado.Anulado)
         m_auditoria.Instanciar(ACFramework.ACEInstancia.Modificado)
         Return Guardar(x_usuario)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Confirmar autorizacion, es decir se ejecuta el proceso y se graba quien uso el permiso
   ''' </summary>
   ''' <param name="x_audit_id">codigo de auditoria</param>
   ''' <param name="x_entid_codigo">codigo de entidad que usa la autorizacion</param>
   ''' <param name="x_docautorizado">codigo del documento autorizado</param>
   ''' <param name="x_tipos_codproceso">tipo de proceso que se autorizo</param>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function ConfirmarAutorizacion(ByVal x_audit_id As Integer, ByVal x_entid_codigo As String, ByVal x_docautorizado As String, ByVal x_tipos_codproceso As String _
                                       , ByVal x_usuario As String) As Boolean
      Try
         m_auditoria = New EAuditoria()
         m_auditoria.AUDIT_Id = x_audit_id
         m_auditoria.APLIC_Codigo = BConstantes.APLIC_Codigo
         m_auditoria.SUCUR_Id = BConstantes.SUCUR_Id
         m_auditoria.ENTID_CodigoConfirmado = x_entid_codigo
         m_auditoria.AUDIT_DocAutorizado = x_docautorizado
         m_auditoria.AUDIT_Estado = EAuditoria.getEstado(EAuditoria.Estado.Confirmado)
         m_auditoria.Instanciar(ACFramework.ACEInstancia.Modificado)
         Return Guardar(x_usuario)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Verificar si el documento tiene autorizacion
   ''' </summary>
   ''' <param name="x_aplic_codigo">codigo de aplicacion</param>
   ''' <param name="x_zonas_codigo">codigo de la zona</param>
   ''' <param name="x_sucur_id">codigo de la sucursal</param>
   ''' <param name="x_documento">codigo del tipo de documento que se consulta</param>
   ''' <param name="x_codigo">codigo del documento de referencia</param>
   ''' <param name="x_tipos_proceso">codigo del tipo de proceso que se verifica la autorizacion</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function VerificarAutorizacion(ByVal x_aplic_codigo As String, ByVal x_zonas_codigo As String, ByVal x_sucur_id As Short, ByVal x_documento As String _
                                       , ByVal x_codigo As String, ByVal x_tipos_proceso As String) As Boolean
      Try
         Dim _where As New Hashtable()
         _where.Add("APLIC_Codigo", New ACWhere(x_aplic_codigo))
         _where.Add("ZONAS_Codigo", New ACWhere(x_zonas_codigo))
         _where.Add("SUCUR_Id", New ACWhere(x_sucur_id))
         _where.Add("AUDIT_CodigoReferencia", New ACWhere(x_codigo))
         _where.Add("TIPOS_CodTipoProceso", New ACWhere(x_tipos_proceso))
         _where.Add("TIPOS_CodTipoDocumento", New ACWhere(x_documento))
         _where.Add("AUDIT_Estado", New ACWhere(EAuditoria.getEstado(EAuditoria.Estado.Ingresado)))
         m_autorizacion = Cargar(_where)
         Return m_autorizacion
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Negocio: VENT_AUDISS_Autorizaciones
   ''' </summary>
   ''' <param name="x_audit_codigoreferencia">Parametro 1: Codigo de referencia</param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function VENT_AUDISS_Autorizaciones(ByVal x_audit_codigoreferencia As String) As Boolean
      m_listAuditoria = New List(Of EAuditoria)
      Try
         Return d_auditoria.VENT_AUDISS_Autorizaciones(m_listAuditoria, x_audit_codigoreferencia)
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class

