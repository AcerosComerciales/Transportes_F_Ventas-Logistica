Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Xml
Imports ACFramework


Public Class EABAS_PedidoTransformacion
    
    #Region " Campos "
   Private m_listdist_pedidTransdetalle As List(Of EABAS_PedidoTransformacionDetalle)

   Private m_seleccion As Boolean
   Private m_documento As String
   Private m_codigo As String
   Private m_usuario As String
   Private m_usu_Modificador As String
   Private m_tipodoc as String
   Private m_almac As String
   Private m_pvent As String
   Private m_peso As Decimal
   Private m_cliente As String
   Private m_cantidad As Decimal
    Private m_articdescripcion As String
    Private m_articCodigo As String
    Private m_pedidcantidad As Decimal
    Private tipo as String
   
#End Region

#Region" Constructores "
	
#End Region

#Region " Propiedades "

   Public Property ListABAS_PedidoTransDetalle() As List(Of EABAS_PedidoTransformacionDetalle)
      Get
         Return m_listdist_pedidTransdetalle
      End Get
      Set(ByVal value As List(Of EABAS_PedidoTransformacionDetalle))
         m_listdist_pedidTransdetalle = value
      End Set
   End Property

   Public Property TIPOS_TipoDocumento() As String
     Get
         Return m_tipodoc
      End Get
      Set(ByVal value As String)
         m_tipodoc = value
      End Set
   End Property
    Public Property TIPOS_TipoDocCorta() As String
     Get
         Return tipo
      End Get
      Set(ByVal value As String)
         tipo = value
      End Set
   End Property
    

     Public Property PVENT_Origen() As String
      Get
         Return m_pvent
      End Get
      Set(ByVal value As String)
         m_pvent = value
      End Set
   End Property
     Public Property ARTIC_Descripcion() As String
      Get
         Return m_articdescripcion
      End Get
      Set(ByVal value As String)
         m_articdescripcion = value
      End Set
   End Property
     Public Property ARTIC_Codigo() As String
      Get
         Return m_articCodigo
      End Get
      Set(ByVal value As String)
         m_articCodigo = value
      End Set
   End Property
    
     Public Property PEDID_Cantidad() As decimal
      Get
         Return m_pedidcantidad
      End Get
      Set(ByVal value As Decimal)
         m_pedidcantidad = value
      End Set
   End Property

   Public Property ALMAC_Origen() As String
      Get
         Return m_almac
      End Get
      Set(ByVal value As String)
         m_almac = value
      End Set
   End Property

   Public Property Seleccion() As Boolean
      Get
         Return m_seleccion
      End Get
      Set(ByVal value As Boolean)
         m_seleccion = value
      End Set
   End Property
  
   Public Property Documento() As String
      Get
			return m_documento
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_documento) Then
				If Not m_documento.Equals(value) Then
					m_documento = value
					OnDocumentoChanged(m_documento, EventArgs.Empty)
				End If
			Else
				m_documento = value
				OnDocumentoChanged(m_documento, EventArgs.Empty)
			End If
		End Set
   End Property
    
    Public Property Usuario_Modificador() As String
        Get
            Return m_usu_Modificador
        End Get
        Set(ByVal value As String)
            m_usu_Modificador = value
        End Set
    End Property
    
   Public Property Usuario() As String
      Get
         Return m_usuario
      End Get
      Set(ByVal value As String)
         m_usuario = value
      End Set
   End Property

   Public Property Codigo() As String
      Get
         Return m_codigo
      End Get
      Set(ByVal value As String)
         m_codigo = value
      End Set
   End Property
    
    Public Property CANTIDAD() As String
      Get
         Return m_cantidad
      End Get
      Set(ByVal value As String)
         m_cantidad = value
      End Set
   End Property


   Public ReadOnly Property PEDID_Estado_Text() As String
      Get
         Select Case m_pedid_estado
            Case Constantes.getEstado(Constantes.Estado.Ingresado)
               Return Constantes.Estado.Ingresado.ToString()
            Case Constantes.getEstado(Constantes.Estado.Anulado)
               Return Constantes.Estado.Anulado.ToString()
            Case Constantes.getEstado(Constantes.Estado.Confirmado)
               Return Constantes.Estado.Confirmado.ToString()
            Case Constantes.getEstado(Constantes.Estado.Eliminado)
               Return Constantes.Estado.Eliminado.ToString()
            Case Constantes.getEstado(Constantes.Estado.Terminado)
                Return Constantes.Estado.Terminado.ToString()
            Case Else
               Return Constantes.Estado.Ingresado.ToString()
         End Select
      End Get
   End Property

   Public Property Peso() As Decimal
      Get
         Return m_peso
      End Get
      Set(ByVal value As Decimal)
         m_peso = value
      End Set
   End Property

   Public Property Cliente() As String
      Get
         Return m_cliente
      End Get
      Set(ByVal value As String)
         m_cliente = value
      End Set
   End Property


#End Region
#Region " Eventos "
	
#End Region
#Region " Metodos "

#End Region


End Class

Partial Public Class EABAS_PedidoTransformacion

#Region " Campos "
	
	Private m_pedid_codigotrans As String
    Private m_entid_codigoencargado As String
    Private m_entid_descripcionencargado As String
	Private m_tipos_codtipopedido As String
	Private m_docve_codigo As String
	Private m_pvent_id As Long
	Private m_almac_id As Short
	Private m_pedid_fechaingreso As Date
	Private m_pedid_fechadocumento As Date
	Private m_pedid_observaciones As String
	Private m_pedid_atendido As Boolean
	Private m_pedid_impresa As Boolean
	Private m_pedid_impresiones As Short
	Private m_pedid_estado As String
	Private m_pedid_usrcrea As String
	Private m_pedid_feccrea As Date
    Private m_pedid_motivoanulacion as String
	Private m_pedid_usrmod As String
	Private m_pedid_fecmod As Date
    Private m_pedid_serie As String
	Private m_pedid_numero As Integer
    Private m_pesoTotal as Decimal
    Private m_pedid_cod_referencia as String
    Private m_tipos_codtransformacion as String
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean
   
	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlABAS_PedidoTransformacion
			Dim _xml As New XmlDocument
			_xml.LoadXml(_obj)
			If IsNothing(m_hash) Then
				m_hash = New Hashtable()
				Dim cPlantilla As XmlNodeList = _xml.GetElementsByTagName("Tabla")
				Dim cCampos As XmlNodeList = CType(cPlantilla(0), XmlElement).GetElementsByTagName("Campos")
				Dim Campo As XmlNodeList = CType(cCampos(0), XmlElement).GetElementsByTagName("CCampo")
				For Each Item As XmlElement In Campo
					m_hash.Add(Item.InnerText.ToString(), New CCampo(Item.GetAttribute("xmlns"), IIf(Item.GetAttribute("Identity") = "1", True, False), IIf(Item.GetAttribute("ForeignKey") = "1", True, False), IIf(Item.GetAttribute("PrimaryKey") = "1", True, False)))
				Next
			End If
		Catch ex As Exception
			Throw ex
		End Try
	End Sub

#End Region

#Region" Propiedades "
	
	Public Property PEDID_CodigoTrans() As String
		Get
			return m_pedid_codigotrans
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pedid_codigotrans) Then
				If Not m_pedid_codigotrans.Equals(value) Then
					m_pedid_codigotrans = value
					OnPEDID_CodigoTransChanged(m_pedid_codigotrans, EventArgs.Empty)
				End If
			Else
				m_pedid_codigotrans = value
				OnPEDID_CodigoTransChanged(m_pedid_codigotrans, EventArgs.Empty)
			End If
		End Set
	End Property
 
    Public Property ENTID_CodigoEncargado() As String
		Get
			return m_entid_codigoencargado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_entid_codigoencargado) Then
				If Not m_entid_codigoencargado.Equals(value) Then
					m_entid_codigoencargado = value
					OnENTID_CodigoEncargadoChanged(m_entid_codigoencargado, EventArgs.Empty)
				End If
			Else
				m_entid_codigoencargado = value
				OnENTID_CodigoEncargadoChanged(m_entid_codigoencargado, EventArgs.Empty)
			End If
		End Set
	End Property

     Public Property PEDID_DescripcionEncargado() As String
		Get
			return m_entid_descripcionencargado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_entid_descripcionencargado) Then
				If Not m_entid_descripcionencargado.Equals(value) Then
					m_entid_descripcionencargado = value
					OnPEDID_DescripcionEncargadoChanged(m_entid_descripcionencargado, EventArgs.Empty)
				End If
			Else
				m_entid_descripcionencargado = value
				OnPEDID_DescripcionEncargadoChanged(m_entid_descripcionencargado, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property TIPOS_CodTipoPedido() As String
		Get
			return m_tipos_codtipopedido
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codtipopedido) Then
				If Not m_tipos_codtipopedido.Equals(value) Then
					m_tipos_codtipopedido = value
					OnTIPOS_CodTipoPedidoChanged(m_tipos_codtipopedido, EventArgs.Empty)
				End If
			Else
				m_tipos_codtipopedido = value
				OnTIPOS_CodTipoPedidoChanged(m_tipos_codtipopedido, EventArgs.Empty)
			End If
		End Set
	End Property
    
    Public Property TIPOS_CodTransformacion() As String
		Get
			return m_tipos_codtransformacion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codtransformacion) Then
				If Not m_tipos_codtransformacion.Equals(value) Then
					m_tipos_codtransformacion = value
					OnTIPOS_CodTransformacionChanged(m_tipos_codtransformacion, EventArgs.Empty)
				End If
			Else
				m_tipos_codtransformacion = value
				OnTIPOS_CodTransformacionChanged(m_tipos_codtransformacion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCVE_Codigo() As String
		Get
			return m_docve_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docve_codigo) Then
				If Not m_docve_codigo.Equals(value) Then
					m_docve_codigo = value
					OnDOCVE_CodigoChanged(m_docve_codigo, EventArgs.Empty)
				End If
			Else
				m_docve_codigo = value
				OnDOCVE_CodigoChanged(m_docve_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PVENT_Id() As Short
		Get
			return m_pvent_id
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_pvent_id) Then
				If Not m_pvent_id.Equals(value) Then
					m_pvent_id = value
					OnPVENT_IdChanged(m_pvent_id, EventArgs.Empty)
				End If
			Else
				m_pvent_id = value
				OnPVENT_IdChanged(m_pvent_id, EventArgs.Empty)
			End If
		End Set
	End Property

    
	Public Property ALMAC_Id() As Short
		Get
			return m_almac_id
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_almac_id) Then
				If Not m_almac_id.Equals(value) Then
					m_almac_id = value
					OnALMAC_IdChanged(m_almac_id, EventArgs.Empty)
				End If
			Else
				m_almac_id = value
				OnALMAC_IdChanged(m_almac_id, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_FechaIngreso() As date
		Get
			return m_pedid_fechaingreso
		End Get
		Set(ByVal value As date)
			If Not IsNothing(m_pedid_fechaingreso) Then
				If Not m_pedid_fechaingreso.Equals(value) Then
					m_pedid_fechaingreso = value
					OnPEDID_FechaIngresoChanged(m_pedid_fechaingreso, EventArgs.Empty)
				End If
			Else
				m_pedid_fechaingreso = value
				OnPEDID_FechaIngresoChanged(m_pedid_fechaingreso, EventArgs.Empty)
			End If
		End Set
	End Property

    Public Property PEDID_FechaDocumento() As date
		Get
			return m_pedid_fechadocumento
		End Get
		Set(ByVal value As date)
			If Not IsNothing(m_pedid_fechadocumento) Then
				If Not m_pedid_fechadocumento.Equals(value) Then
					m_pedid_fechadocumento = value
					OnPEDID_FechaDocumentoChanged(m_pedid_fechadocumento, EventArgs.Empty)
				End If
			Else
				m_pedid_fechadocumento = value
				OnPEDID_FechaDocumentoChanged(m_pedid_fechadocumento, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_Observaciones() As String
		Get
			return m_pedid_observaciones
		End Get
		Set(ByVal value As string)
			If Not IsNothing(m_pedid_observaciones) Then
				If Not m_pedid_observaciones.Equals(value) Then
					m_pedid_observaciones = value
					OnPEDID_ObservacionesChanged(m_pedid_observaciones, EventArgs.Empty)
				End If
			Else
				m_pedid_observaciones = value
				OnPEDID_ObservacionesChanged(m_pedid_observaciones, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_Atendido() As Boolean
		Get
			return m_pedid_atendido
		End Get
		Set(ByVal value As Boolean)
			If Not IsNothing(m_pedid_atendido) Then
				If Not m_pedid_atendido.Equals(value) Then
					m_pedid_atendido = value
					OnPEDID_AtendidoChanged(m_pedid_atendido, EventArgs.Empty)
				End If
			Else
				m_pedid_atendido = value
				OnPEDID_AtendidoChanged(m_pedid_atendido, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_Impresa() As Boolean
		Get
			return m_pedid_impresa
		End Get
		Set(ByVal value As Boolean)
			If Not IsNothing(m_pedid_impresa) Then
				If Not m_pedid_impresa.Equals(value) Then
					m_pedid_impresa = value
					OnPEDID_ImpresaChanged(m_pedid_impresa, EventArgs.Empty)
				End If
			Else
				m_pedid_impresa = value
				OnPEDID_ImpresaChanged(m_pedid_impresa, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_Impresiones() As Short
		Get
			return m_pedid_impresiones
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_pedid_impresiones) Then
				If Not m_pedid_impresiones.Equals(value) Then
					m_pedid_impresiones = value
					OnPEDID_ImpresionesChanged(m_pedid_impresiones, EventArgs.Empty)
				End If
			Else
				m_pedid_impresiones = value
				OnPEDID_ImpresionesChanged(m_pedid_impresiones, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_Estado() As String
		Get
			return m_pedid_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pedid_estado) then
				If Not m_pedid_estado.Equals(value) Then
					m_pedid_estado = value
					OnPEDID_EstadoChanged(m_pedid_estado, EventArgs.Empty)
				End If
			Else
				m_pedid_estado = value
				OnPEDID_EstadoChanged(m_pedid_estado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_UsrCrea() As String
		Get
			return m_pedid_usrcrea
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pedid_usrcrea) Then
				If Not m_pedid_usrcrea.Equals(value) Then
					m_pedid_usrcrea = value
					OnPEDID_UsrCreaChanged(m_pedid_usrcrea, EventArgs.Empty)
				End If
			Else
				m_pedid_usrcrea = value
				OnPEDID_UsrCreaChanged(m_pedid_usrcrea, EventArgs.Empty)
			End If
		End Set
	End Property
    
    	Public Property PEDID_UsrMod() As String
		Get
			return m_pedid_usrmod
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pedid_usrmod) Then
				If Not m_pedid_usrmod.Equals(value) Then
					m_pedid_usrmod = value
					OnPEDID_UsrModChanged(m_pedid_usrmod, EventArgs.Empty)
				End If
			Else
				m_pedid_usrmod = value
				OnPEDID_UsrModChanged(m_pedid_usrmod, EventArgs.Empty)
			End If
		End Set
	End Property
   

	Public Property PEDID_FecCrea() As date
		Get
			return m_pedid_feccrea
		End Get
		Set(ByVal value As date)
			If Not IsNothing(m_pedid_feccrea) Then
				If Not m_pedid_feccrea.Equals(value) Then
					m_pedid_feccrea = value
					OnPEDID_FecCreaChanged(m_pedid_feccrea, EventArgs.Empty)
				End If
			Else
				m_pedid_feccrea = value
				OnPEDID_FecCreaChanged(m_pedid_feccrea, EventArgs.Empty)
			End If
		End Set
	End Property


	Public Property PEDID_MotivoAnulacion() As String
		Get
			return m_pedid_motivoanulacion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pedid_motivoanulacion) Then
				If Not m_pedid_motivoanulacion.Equals(value) Then
					m_pedid_motivoanulacion = value
					OnPEDID_MotivoAnulacionChanged(m_pedid_motivoanulacion, EventArgs.Empty)
				End If
			Else
				m_pedid_motivoanulacion = value
				OnPEDID_MotivoAnulacionChanged(m_pedid_motivoanulacion, EventArgs.Empty)
			End If
		End Set
	End Property



	Public Property PEDID_FecMod() As date
		Get
			return m_pedid_fecmod
		End Get
		Set(ByVal value As Date)
			If Not m_pedid_fecmod.Equals(value) Then
				m_pedid_fecmod = value
				OnPEDID_FecModChanged(m_pedid_fecmod, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_Serie() As String
		Get
			return m_pedid_serie
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pedid_serie) Then
				If Not m_pedid_serie.Equals(value) Then
					m_pedid_serie = value
					OnPEDID_SerieChanged(m_pedid_serie, EventArgs.Empty)
				End If
			Else
				m_pedid_serie = value
				OnPEDID_SerieChanged(m_pedid_serie, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_Numero() As Integer
		Get
			return m_pedid_numero
		End Get
		Set(ByVal value As Integer)
			If Not IsNothing(m_pedid_numero) Then
				If Not m_pedid_numero.Equals(value) Then
					m_pedid_numero = value
					OnPEDID_NumeroChanged(m_pedid_numero, EventArgs.Empty)
				End If
			Else
				m_pedid_numero = value
				OnPEDID_NumeroChanged(m_pedid_numero, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_PesoTotal() As Decimal
		Get
			return m_pesoTotal
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_pesoTotal) Then
				If Not m_pesoTotal.Equals(value) Then
					m_pesoTotal = value
					OnPEDID_PesoTotalChanged(m_pesoTotal, EventArgs.Empty)
				End If
			Else
				m_pesoTotal = value
				OnPEDID_PesoTotalChanged(m_pesoTotal, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_CodReferencia() As String
		Get
			return m_pedid_cod_referencia
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pedid_cod_referencia) Then
				If Not m_pedid_cod_referencia.Equals(value) Then
					m_pedid_cod_referencia = value
					OnPEDID_CodReferenciaChanged(m_pedid_cod_referencia, EventArgs.Empty)
				End If
			Else
				m_pedid_cod_referencia = value
				OnPEDID_CodReferenciaChanged(m_pedid_cod_referencia, EventArgs.Empty)
			End If
		End Set
	End Property


	#Region " Propiedades de Solo Lectura "

	Public ReadOnly Property Nuevo() As Boolean
		Get
			return m_nuevo
		End Get
	End Property

	Public ReadOnly Property Modificado() As Boolean
		Get
			return m_modificado
		End Get
	End Property

	Public ReadOnly Property Eliminado() As Boolean
		Get
			return m_eliminado
		End Get
	End Property

	Public ReadOnly Property Hash() As Hashtable
		Get
			return m_hash
		End Get
	End Property

	Public Shared ReadOnly Property Tabla() As String
		Get
			Return "DIST_Ordenes"
		End Get
	End Property

	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "Logistica"
		End Get
	End Property

	#End Region

#End Region

#Region " Eventos "
	
	Public Event PEDID_CodigoTransChanged As EventHandler
    Public Event ENTID_CodigoEncargadoChanged as EventHandler
    Public Event PEDID_DescripcionEncargadoChanged as EventHandler
    Public Event TIPOS_CodTipoPedidoChanged AS EventHandler
	Public Event DOCVE_CodigoChanged As EventHandler
    Public Event PVENT_IdChanged As EventHandler
	Public Event ALMAC_IdChanged As EventHandler
	Public Event PEDID_FechaIngresoChanged As EventHandler
    Public Event PEDID_FechaDocumentoChanged As EventHandler
    Public Event PEDID_ObservacionesChanged As EventHandler
	Public Event PEDID_AtendidoChanged As EventHandler
    Public Event PEDID_ImpresaChanged As EventHandler
	Public Event PEDID_ImpresionesChanged As EventHandler
	Public Event PEDID_EstadoChanged As EventHandler
	Public Event PEDID_UsrCreaChanged As EventHandler
	Public Event PEDID_FecCreaChanged As EventHandler
	Public Event PEDID_MotivoAnulacionChanged As EventHandler
	Public Event PEDID_UsrModChanged As EventHandler
	Public Event PEDID_FecModChanged As EventHandler
	Public Event PEDID_SerieChanged As EventHandler
	Public Event PEDID_NumeroChanged As EventHandler
	Public Event PEDID_PesoTotalChanged As EventHandler
	Public Event PEDID_CodReferenciaChanged As EventHandler
    Public Event DocumentoChanged as EventHandler
    Public Event TIPOS_CodTransformacionChanged As EventHandler

    
	Public Sub OnPEDID_CodigoTransChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_CodigoTransChanged(sender, e)
	End Sub
    
    Public Sub OnENTID_CodigoEncargadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoEncargadoChanged(sender, e)
	End Sub
    Public Sub OnPEDID_DescripcionEncargadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_DescripcionEncargadoChanged(sender, e)
	End Sub
      Public Sub OnTIPOS_CodTipoPedidoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoPedidoChanged(sender, e)
	End Sub

     Public Sub OnTIPOS_CodTransformacionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTransformacionChanged(sender, e)
	End Sub
    
	Public Sub OnDOCVE_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCVE_CodigoChanged(sender, e)
	End Sub
    
    Public Sub OnPVENT_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PVENT_IdChanged(sender, e)
	End Sub
	Public Sub OnALMAC_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ALMAC_IdChanged(sender, e)
	End Sub

	Public Sub OnPEDID_FechaIngresoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_FechaIngresoChanged(sender, e)
	End Sub

    Public Sub OnPEDID_FechaDocumentoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_FechaDocumentoChanged(sender, e)
	End Sub
    

	Public Sub OnPEDID_ObservacionesChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_ObservacionesChanged(sender, e)
	End Sub

	Public Sub OnPEDID_AtendidoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_AtendidoChanged(sender, e)
	End Sub
    
    Public Sub OnPEDID_ImpresaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_ImpresaChanged(sender, e)
	End Sub
	Public Sub OnPEDID_ImpresionesChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_ImpresionesChanged(sender, e)
	End Sub

	Public Sub OnPEDID_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_EstadoChanged(sender, e)
	End Sub
    
    Public Sub OnDocumentoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DocumentoChanged(sender, e)
	End Sub


	Public Sub OnPEDID_UsrCreaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_UsrCreaChanged(sender, e)
	End Sub

	Public Sub OnPEDID_FecCreaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_FecCreaChanged(sender, e)
	End Sub

	Public Sub OnPEDID_MotivoAnulacionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_MotivoAnulacionChanged(sender, e)
	End Sub

	Public Sub OnPEDID_UsrModChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_UsrModChanged(sender, e)
	End Sub

	Public Sub OnPEDID_FecModChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_FecModChanged(sender, e)
	End Sub

	Public Sub OnPEDID_SerieChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_SerieChanged(sender, e)
	End Sub

	Public Sub OnPEDID_NumeroChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_NumeroChanged(sender, e)
	End Sub

	Public Sub OnPEDID_PesoTotalChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_PesoTotalChanged(sender, e)
	End Sub

	Public Sub OnPEDID_CodReferenciaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_CodReferenciaChanged(sender, e)
	End Sub
 
    


#End Region

#Region " Metodos "
	
	Public Sub Instanciar(ByVal x_instancia As ACEInstancia)
		Select Case x_instancia
			Case ACEInstancia.Consulta
				m_nuevo = False
				m_modificado = False
				m_eliminado = False
			Case ACEInstancia.Nuevo
				m_nuevo = True
				m_modificado = False
				m_eliminado = False
			Case ACEInstancia.Modificado
				m_nuevo = False
				m_modificado = True
				m_eliminado = False
			Case ACEInstancia.Eliminado
				m_nuevo = False
				m_modificado = False
				m_eliminado = True
		End Select
	End Sub

	Public Sub ActualizarInstancia()
		If Not Nuevo Then
			If Not Eliminado Then
				Instanciar(ACEInstancia.Modificado)
			End If
		End If
	End Sub

#End Region



End Class
