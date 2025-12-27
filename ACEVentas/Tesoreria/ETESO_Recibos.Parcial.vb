Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETESO_Recibos

#Region " Campos "
	
	Private m_recib_codigo As String
	Private m_entid_codigo As String
	Private m_tipos_codtipomoneda As String
	Private m_tipos_codtiporecibo As String
	Private m_tipos_codtransaccion As String
	Private m_pvent_id As Long
	Private m_entid_codigoproveedor As String
	Private m_docus_codigo As String
	Private m_recib_serie As String
	Private m_recib_numero As Integer
	Private m_recib_fecha As Date
	Private m_recib_recibide As String
	Private m_recib_importe As Decimal
	Private m_recib_concepto As String
	Private m_recib_nrodocumento As String
	Private m_recib_efectivo As Boolean
	Private m_recib_estado As String
    Private m_caja_codigo As String
    Private m_caja_codigo1 As String '_M
	Private m_caja_ordendocumento As Short
	Private m_dpago_id As Long
	Private m_recib_anuladocaja As Boolean
	Private m_recib_fechaanulacion As Date
	Private m_recib_motivoanulacion As String
	Private m_recib_usrcrea As String
	Private m_recib_feccrea As Date
	Private m_recib_usrmod As String
	Private m_recib_fecmod As Date
    Private m_recib_trans as Boolean
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean
    'R 30-11-2017-sisAdmin
    Private m_docve_codRelacion As String

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlTESO_Recibos
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

	Public Property RECIB_Codigo() As String
		Get
			return m_recib_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_recib_codigo) Then
				If Not m_recib_codigo.Equals(value) Then
					m_recib_codigo = value
					OnRECIB_CodigoChanged(m_recib_codigo, EventArgs.Empty)
				End If
			Else
				m_recib_codigo = value
				OnRECIB_CodigoChanged(m_recib_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ENTID_Codigo() As String
		Get
			return m_entid_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_entid_codigo) Then
				If Not m_entid_codigo.Equals(value) Then
					m_entid_codigo = value
					OnENTID_CodigoChanged(m_entid_codigo, EventArgs.Empty)
				End If
			Else
				m_entid_codigo = value
				OnENTID_CodigoChanged(m_entid_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_CodTipoMoneda() As String
		Get
			return m_tipos_codtipomoneda
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codtipomoneda) Then
				If Not m_tipos_codtipomoneda.Equals(value) Then
					m_tipos_codtipomoneda = value
					OnTIPOS_CodTipoMonedaChanged(m_tipos_codtipomoneda, EventArgs.Empty)
				End If
			Else
				m_tipos_codtipomoneda = value
				OnTIPOS_CodTipoMonedaChanged(m_tipos_codtipomoneda, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_CodTipoRecibo() As String
		Get
			return m_tipos_codtiporecibo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codtiporecibo) Then
				If Not m_tipos_codtiporecibo.Equals(value) Then
					m_tipos_codtiporecibo = value
					OnTIPOS_CodTipoReciboChanged(m_tipos_codtiporecibo, EventArgs.Empty)
				End If
			Else
				m_tipos_codtiporecibo = value
				OnTIPOS_CodTipoReciboChanged(m_tipos_codtiporecibo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_CodTransaccion() As String
		Get
			return m_tipos_codtransaccion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codtransaccion) Then
				If Not m_tipos_codtransaccion.Equals(value) Then
					m_tipos_codtransaccion = value
					OnTIPOS_CodTransaccionChanged(m_tipos_codtransaccion, EventArgs.Empty)
				End If
			Else
				m_tipos_codtransaccion = value
				OnTIPOS_CodTransaccionChanged(m_tipos_codtransaccion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PVENT_Id() As Long
		Get
			return m_pvent_id
		End Get
		Set(ByVal value As Long)
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

	Public Property ENTID_CodigoProveedor() As String
		Get
			return m_entid_codigoproveedor
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_entid_codigoproveedor) Then
				If Not m_entid_codigoproveedor.Equals(value) Then
					m_entid_codigoproveedor = value
					OnENTID_CodigoProveedorChanged(m_entid_codigoproveedor, EventArgs.Empty)
				End If
			Else
				m_entid_codigoproveedor = value
				OnENTID_CodigoProveedorChanged(m_entid_codigoproveedor, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCUS_Codigo() As String
		Get
			return m_docus_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docus_codigo) Then
				If Not m_docus_codigo.Equals(value) Then
					m_docus_codigo = value
					OnDOCUS_CodigoChanged(m_docus_codigo, EventArgs.Empty)
				End If
			Else
				m_docus_codigo = value
				OnDOCUS_CodigoChanged(m_docus_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property RECIB_Serie() As String
		Get
			return m_recib_serie
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_recib_serie) Then
				If Not m_recib_serie.Equals(value) Then
					m_recib_serie = value
					OnRECIB_SerieChanged(m_recib_serie, EventArgs.Empty)
				End If
			Else
				m_recib_serie = value
				OnRECIB_SerieChanged(m_recib_serie, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property RECIB_Numero() As Integer
		Get
			return m_recib_numero
		End Get
		Set(ByVal value As Integer)
			If Not IsNothing(m_recib_numero) Then
				If Not m_recib_numero.Equals(value) Then
					m_recib_numero = value
					OnRECIB_NumeroChanged(m_recib_numero, EventArgs.Empty)
				End If
			Else
				m_recib_numero = value
				OnRECIB_NumeroChanged(m_recib_numero, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property RECIB_Fecha() As Date
		Get
			return m_recib_fecha
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_recib_fecha) Then
				If Not m_recib_fecha.Equals(value) Then
					m_recib_fecha = value
					OnRECIB_FechaChanged(m_recib_fecha, EventArgs.Empty)
				End If
			Else
				m_recib_fecha = value
				OnRECIB_FechaChanged(m_recib_fecha, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property RECIB_RecibiDe() As String
		Get
			return m_recib_recibide
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_recib_recibide) Then
				If Not m_recib_recibide.Equals(value) Then
					m_recib_recibide = value
					OnRECIB_RecibiDeChanged(m_recib_recibide, EventArgs.Empty)
				End If
			Else
				m_recib_recibide = value
				OnRECIB_RecibiDeChanged(m_recib_recibide, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property RECIB_Importe() As Decimal
		Get
			return m_recib_importe
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_recib_importe) Then
				If Not m_recib_importe.Equals(value) Then
					m_recib_importe = value
					OnRECIB_ImporteChanged(m_recib_importe, EventArgs.Empty)
				End If
			Else
				m_recib_importe = value
				OnRECIB_ImporteChanged(m_recib_importe, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property RECIB_Concepto() As String
		Get
			return m_recib_concepto
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_recib_concepto) Then
				If Not m_recib_concepto.Equals(value) Then
					m_recib_concepto = value
					OnRECIB_ConceptoChanged(m_recib_concepto, EventArgs.Empty)
				End If
			Else
				m_recib_concepto = value
				OnRECIB_ConceptoChanged(m_recib_concepto, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property RECIB_NroDocumento() As String
		Get
			return m_recib_nrodocumento
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_recib_nrodocumento) Then
				If Not m_recib_nrodocumento.Equals(value) Then
					m_recib_nrodocumento = value
					OnRECIB_NroDocumentoChanged(m_recib_nrodocumento, EventArgs.Empty)
				End If
			Else
				m_recib_nrodocumento = value
				OnRECIB_NroDocumentoChanged(m_recib_nrodocumento, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property RECIB_Efectivo() As Boolean
		Get
			return m_recib_efectivo
		End Get
		Set(ByVal value As Boolean)
			If Not m_recib_efectivo.Equals(value) Then
				m_recib_efectivo = value
				OnRECIB_EfectivoChanged(m_recib_efectivo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property RECIB_Estado() As String
		Get
			return m_recib_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_recib_estado) Then
				If Not m_recib_estado.Equals(value) Then
					m_recib_estado = value
					OnRECIB_EstadoChanged(m_recib_estado, EventArgs.Empty)
				End If
			Else
				m_recib_estado = value
				OnRECIB_EstadoChanged(m_recib_estado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property CAJA_Codigo() As String
		Get
			return m_caja_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_caja_codigo) Then
				If Not m_caja_codigo.Equals(value) Then
					m_caja_codigo = value
					OnCAJA_CodigoChanged(m_caja_codigo, EventArgs.Empty)
				End If
			Else
				m_caja_codigo = value
				OnCAJA_CodigoChanged(m_caja_codigo, EventArgs.Empty)
			End If
		End Set
    End Property
    '_M
    Public Property CAJA_Codigo1() As String
        Get
            Return m_caja_codigo1
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_caja_codigo1) Then
                If Not m_caja_codigo1.Equals(value) Then
                    m_caja_codigo1 = value
                    OnCAJA_CodigoChanged(m_caja_codigo1, EventArgs.Empty)
                End If
            Else
                m_caja_codigo1 = value
                OnCAJA_CodigoChanged(m_caja_codigo1, EventArgs.Empty)
            End If
        End Set
    End Property

	Public Property CAJA_OrdenDocumento() As Short
		Get
			return m_caja_ordendocumento
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_caja_ordendocumento) Then
				If Not m_caja_ordendocumento.Equals(value) Then
					m_caja_ordendocumento = value
					OnCAJA_OrdenDocumentoChanged(m_caja_ordendocumento, EventArgs.Empty)
				End If
			Else
				m_caja_ordendocumento = value
				OnCAJA_OrdenDocumentoChanged(m_caja_ordendocumento, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DPAGO_Id() As Long
		Get
			return m_dpago_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_dpago_id) Then
				If Not m_dpago_id.Equals(value) Then
					m_dpago_id = value
					OnDPAGO_IdChanged(m_dpago_id, EventArgs.Empty)
				End If
			Else
				m_dpago_id = value
				OnDPAGO_IdChanged(m_dpago_id, EventArgs.Empty)
			End If
		End Set
	End Property
    'R 30-11-2017-sisAdmin
    Public Property DOCVE_CodRelacion() As String
        Get
            Return m_docve_codRelacion
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_docve_codRelacion) Then
                If Not m_docve_codRelacion.Equals(value) Then
                    m_docve_codRelacion = value
                    OnDOCVE_CodRelacionChanged(m_docve_codRelacion, EventArgs.Empty)
                End If
            Else
                m_docve_codRelacion = value
                OnDOCVE_CodRelacionChanged(m_docve_codRelacion, EventArgs.Empty)
            End If
        End Set
    End Property

	Public Property RECIB_AnuladoCaja() As Boolean
		Get
			return m_recib_anuladocaja
		End Get
		Set(ByVal value As Boolean)
			If Not m_recib_anuladocaja.Equals(value) Then
				m_recib_anuladocaja = value
				OnRECIB_AnuladoCajaChanged(m_recib_anuladocaja, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property RECIB_FechaAnulacion() As Date
		Get
			return m_recib_fechaanulacion
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_recib_fechaanulacion) Then
				If Not m_recib_fechaanulacion.Equals(value) Then
					m_recib_fechaanulacion = value
					OnRECIB_FechaAnulacionChanged(m_recib_fechaanulacion, EventArgs.Empty)
				End If
			Else
				m_recib_fechaanulacion = value
				OnRECIB_FechaAnulacionChanged(m_recib_fechaanulacion, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property RECIB_MotivoAnulacion() As String
		Get
			return m_recib_motivoanulacion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_recib_motivoanulacion) Then
				If Not m_recib_motivoanulacion.Equals(value) Then
					m_recib_motivoanulacion = value
					OnRECIB_MotivoAnulacionChanged(m_recib_motivoanulacion, EventArgs.Empty)
				End If
			Else
				m_recib_motivoanulacion = value
				OnRECIB_MotivoAnulacionChanged(m_recib_motivoanulacion, EventArgs.Empty)
			End If
		End Set
	End Property
    Public Property RECIB_Trans() As Boolean
		Get
			return m_recib_trans
		End Get
		Set(ByVal value As Boolean)
			If Not IsNothing(m_recib_trans) Then
				If Not m_recib_trans.Equals(value) Then
					m_recib_trans = value
					OnRECIB_TransChanged(m_recib_trans, EventArgs.Empty)
				End If
			Else
				m_recib_motivoanulacion = value
				OnRECIB_TransChanged(m_recib_trans, EventArgs.Empty)
			End If
		End Set
	End Property
    
	Public Property RECIB_UsrCrea() As String
		Get
			return m_recib_usrcrea
		End Get
		Set(ByVal value As String)
			m_recib_usrcrea = value
		End Set
	End Property

	Public Property RECIB_FecCrea() As Date
		Get
			return m_recib_feccrea
		End Get
		Set(ByVal value As Date)
			m_recib_feccrea = value
		End Set
	End Property

	Public Property RECIB_UsrMod() As String
		Get
			return m_recib_usrmod
		End Get
		Set(ByVal value As String)
			m_recib_usrmod = value
		End Set
	End Property

	Public Property RECIB_FecMod() As Date
		Get
			return m_recib_fecmod
		End Get
		Set(ByVal value As Date)
			m_recib_fecmod = value
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
			Return "TESO_Recibos"
		End Get
	End Property

	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "Tesoreria"
		End Get
	End Property

	#End Region

#End Region

#Region " Eventos "
	
	Public Event RECIB_CodigoChanged As EventHandler
	Public Event ENTID_CodigoChanged As EventHandler
	Public Event TIPOS_CodTipoMonedaChanged As EventHandler
	Public Event TIPOS_CodTipoReciboChanged As EventHandler
	Public Event TIPOS_CodTransaccionChanged As EventHandler
	Public Event PVENT_IdChanged As EventHandler
	Public Event ENTID_CodigoProveedorChanged As EventHandler
	Public Event DOCUS_CodigoChanged As EventHandler
	Public Event RECIB_SerieChanged As EventHandler
	Public Event RECIB_NumeroChanged As EventHandler
	Public Event RECIB_FechaChanged As EventHandler
	Public Event RECIB_RecibiDeChanged As EventHandler
	Public Event RECIB_ImporteChanged As EventHandler
	Public Event RECIB_ConceptoChanged As EventHandler
	Public Event RECIB_NroDocumentoChanged As EventHandler
	Public Event RECIB_EfectivoChanged As EventHandler
	Public Event RECIB_EstadoChanged As EventHandler
	Public Event CAJA_CodigoChanged As EventHandler
	Public Event CAJA_OrdenDocumentoChanged As EventHandler
	Public Event DPAGO_IdChanged As EventHandler
    'R 30-11-2017-sisAdmin
    Public Event DOCVE_CodRelacionChanged As EventHandler

	Public Event RECIB_AnuladoCajaChanged As EventHandler
	Public Event RECIB_FechaAnulacionChanged As EventHandler
	Public Event RECIB_MotivoAnulacionChanged As EventHandler
    Public Event RECIB_TransChanged As EventHandler

	Public Sub OnRECIB_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent RECIB_CodigoChanged(sender, e)
	End Sub

	Public Sub OnENTID_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoMonedaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoMonedaChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTipoReciboChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoReciboChanged(sender, e)
	End Sub

	Public Sub OnTIPOS_CodTransaccionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTransaccionChanged(sender, e)
	End Sub

	Public Sub OnPVENT_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PVENT_IdChanged(sender, e)
	End Sub

	Public Sub OnENTID_CodigoProveedorChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoProveedorChanged(sender, e)
	End Sub

	Public Sub OnDOCUS_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCUS_CodigoChanged(sender, e)
	End Sub

	Public Sub OnRECIB_SerieChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent RECIB_SerieChanged(sender, e)
	End Sub

	Public Sub OnRECIB_NumeroChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent RECIB_NumeroChanged(sender, e)
	End Sub

	Public Sub OnRECIB_FechaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent RECIB_FechaChanged(sender, e)
	End Sub

	Public Sub OnRECIB_RecibiDeChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent RECIB_RecibiDeChanged(sender, e)
	End Sub

	Public Sub OnRECIB_ImporteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent RECIB_ImporteChanged(sender, e)
	End Sub

	Public Sub OnRECIB_ConceptoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent RECIB_ConceptoChanged(sender, e)
	End Sub

	Public Sub OnRECIB_NroDocumentoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent RECIB_NroDocumentoChanged(sender, e)
	End Sub

	Public Sub OnRECIB_EfectivoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent RECIB_EfectivoChanged(sender, e)
	End Sub

	Public Sub OnRECIB_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent RECIB_EstadoChanged(sender, e)
	End Sub

	Public Sub OnCAJA_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJA_CodigoChanged(sender, e)
	End Sub

	Public Sub OnCAJA_OrdenDocumentoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CAJA_OrdenDocumentoChanged(sender, e)
	End Sub

	Public Sub OnDPAGO_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DPAGO_IdChanged(sender, e)
	End Sub
    'R 30-11-2017-sisAdmin
    Public Sub OnDOCVE_CodRelacionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DOCVE_CodRelacionChanged(sender, e)
    End Sub

	Public Sub OnRECIB_AnuladoCajaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent RECIB_AnuladoCajaChanged(sender, e)
	End Sub

	Public Sub OnRECIB_FechaAnulacionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent RECIB_FechaAnulacionChanged(sender, e)
	End Sub

	Public Sub OnRECIB_MotivoAnulacionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent RECIB_MotivoAnulacionChanged(sender, e)
	End Sub
    Public Sub OnRECIB_TransChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent RECIB_TransChanged(sender, e)
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

