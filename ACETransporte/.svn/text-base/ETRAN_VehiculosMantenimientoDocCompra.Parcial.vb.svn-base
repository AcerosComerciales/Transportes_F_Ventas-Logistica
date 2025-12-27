Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETRAN_VehiculosMantenimientoDocCompra

#Region " Campos "
	
	Private m_docus_codigo As String
	Private m_entid_codigo As String
	Private m_vehic_id As Long
	Private m_vman_item As Long
	Private m_vmdco_numero As Short
	Private m_vmdco_usrcrea As String
	Private m_vmdco_feccrea As Date
	Private m_vmdco_usrmod As String
	Private m_vmdco_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACETransporte.My.Resources.xmlTRAN_VehiculosMantenimientoDocCompra
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

	Public Property VEHIC_Id() As Long
		Get
			return m_vehic_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_vehic_id) Then
				If Not m_vehic_id.Equals(value) Then
					m_vehic_id = value
					OnVEHIC_IdChanged(m_vehic_id, EventArgs.Empty)
				End If
			Else
				m_vehic_id = value
				OnVEHIC_IdChanged(m_vehic_id, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VMAN_Item() As Long
		Get
			return m_vman_item
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_vman_item) Then
				If Not m_vman_item.Equals(value) Then
					m_vman_item = value
					OnVMAN_ItemChanged(m_vman_item, EventArgs.Empty)
				End If
			Else
				m_vman_item = value
				OnVMAN_ItemChanged(m_vman_item, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VMDCO_Numero() As Short
		Get
			return m_vmdco_numero
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_vmdco_numero) Then
				If Not m_vmdco_numero.Equals(value) Then
					m_vmdco_numero = value
					OnVMDCO_NumeroChanged(m_vmdco_numero, EventArgs.Empty)
				End If
			Else
				m_vmdco_numero = value
				OnVMDCO_NumeroChanged(m_vmdco_numero, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VMDCO_UsrCrea() As String
		Get
			return m_vmdco_usrcrea
		End Get
		Set(ByVal value As String)
			m_vmdco_usrcrea = value
		End Set
	End Property

	Public Property VMDCO_FecCrea() As Date
		Get
			return m_vmdco_feccrea
		End Get
		Set(ByVal value As Date)
			m_vmdco_feccrea = value
		End Set
	End Property

	Public Property VMDCO_UsrMod() As String
		Get
			return m_vmdco_usrmod
		End Get
		Set(ByVal value As String)
			m_vmdco_usrmod = value
		End Set
	End Property

	Public Property VMDCO_FecMod() As Date
		Get
			return m_vmdco_fecmod
		End Get
		Set(ByVal value As Date)
			m_vmdco_fecmod = value
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
			Return "TRAN_VehiculosMantenimientoDocCompra"
		End Get
	End Property

	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "Transportes"
		End Get
	End Property

	#End Region

#End Region

#Region " Eventos "
	
	Public Event DOCUS_CodigoChanged As EventHandler
	Public Event ENTID_CodigoChanged As EventHandler
	Public Event VEHIC_IdChanged As EventHandler
	Public Event VMAN_ItemChanged As EventHandler
	Public Event VMDCO_NumeroChanged As EventHandler

	Public Sub OnDOCUS_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCUS_CodigoChanged(sender, e)
	End Sub

	Public Sub OnENTID_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoChanged(sender, e)
	End Sub

	Public Sub OnVEHIC_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VEHIC_IdChanged(sender, e)
	End Sub

	Public Sub OnVMAN_ItemChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VMAN_ItemChanged(sender, e)
	End Sub

	Public Sub OnVMDCO_NumeroChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VMDCO_NumeroChanged(sender, e)
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

