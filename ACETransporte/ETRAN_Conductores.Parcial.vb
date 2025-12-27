Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETRAN_Conductores

#Region " Campos "
	
	Private m_condu_id As Long
	Private m_zonas_codigo As String
	Private m_sucur_id As Short
	Private m_entid_codigo As String
	Private m_condu_nroviaje As Short
	Private m_condu_licencia As String
	Private m_condu_estado As String
	Private m_condu_usrcrea As String
	Private m_condu_feccrea As Date
	Private m_condu_usrmod As String
	Private m_condu_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACETransporte.My.Resources.xmlTRAN_Conductores
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
	
	Public Property CONDU_Id() As Long
		Get
			return m_condu_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_condu_id) Then
				If Not m_condu_id.Equals(value) Then
					m_condu_id = value
					OnCONDU_IdChanged(m_condu_id, EventArgs.Empty)
				End If
			Else
				m_condu_id = value
				OnCONDU_IdChanged(m_condu_id, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property ZONAS_Codigo() As String
		Get
			return m_zonas_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_zonas_codigo) Then
				If Not m_zonas_codigo.Equals(value) Then
					m_zonas_codigo = value
					OnZONAS_CodigoChanged(m_zonas_codigo, EventArgs.Empty)
				End If
			Else
				m_zonas_codigo = value
				OnZONAS_CodigoChanged(m_zonas_codigo, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property SUCUR_Id() As Short
		Get
			return m_sucur_id
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_sucur_id) Then
				If Not m_sucur_id.Equals(value) Then
					m_sucur_id = value
					OnSUCUR_IdChanged(m_sucur_id, EventArgs.Empty)
				End If
			Else
				m_sucur_id = value
				OnSUCUR_IdChanged(m_sucur_id, EventArgs.Empty)
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
	Public Property CONDU_NroViaje() As Short
		Get
			return m_condu_nroviaje
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_condu_nroviaje) Then
				If Not m_condu_nroviaje.Equals(value) Then
					m_condu_nroviaje = value
					OnCONDU_NroViajeChanged(m_condu_nroviaje, EventArgs.Empty)
				End If
			Else
				m_condu_nroviaje = value
				OnCONDU_NroViajeChanged(m_condu_nroviaje, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property CONDU_Licencia() As String
		Get
			return m_condu_licencia
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_condu_licencia) Then
				If Not m_condu_licencia.Equals(value) Then
					m_condu_licencia = value
					OnCONDU_LicenciaChanged(m_condu_licencia, EventArgs.Empty)
				End If
			Else
				m_condu_licencia = value
				OnCONDU_LicenciaChanged(m_condu_licencia, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property CONDU_Estado() As String
		Get
			return m_condu_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_condu_estado) Then
				If Not m_condu_estado.Equals(value) Then
					m_condu_estado = value
					OnCONDU_EstadoChanged(m_condu_estado, EventArgs.Empty)
				End If
			Else
				m_condu_estado = value
				OnCONDU_EstadoChanged(m_condu_estado, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property CONDU_UsrCrea() As String
		Get
			return m_condu_usrcrea
		End Get
		Set(ByVal value As String)
			m_condu_usrcrea = value
		End Set
	End Property
	Public Property CONDU_FecCrea() As Date
		Get
			return m_condu_feccrea
		End Get
		Set(ByVal value As Date)
			m_condu_feccrea = value
		End Set
	End Property
	Public Property CONDU_UsrMod() As String
		Get
			return m_condu_usrmod
		End Get
		Set(ByVal value As String)
			m_condu_usrmod = value
		End Set
	End Property
	Public Property CONDU_FecMod() As Date
		Get
			return m_condu_fecmod
		End Get
		Set(ByVal value As Date)
			m_condu_fecmod = value
		End Set
	End Property
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
			Return "TRAN_Conductores"
		End Get
	End Property
	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "Transportes"
		End Get
	End Property


#End Region

#Region " Eventos "
	
	Public Event CONDU_IdChanged As EventHandler
	Public Event ZONAS_CodigoChanged As EventHandler
	Public Event SUCUR_IdChanged As EventHandler
	Public Event ENTID_CodigoChanged As EventHandler
	Public Event CONDU_NroViajeChanged As EventHandler
	Public Event CONDU_LicenciaChanged As EventHandler
	Public Event CONDU_EstadoChanged As EventHandler
	Public Sub OnCONDU_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CONDU_IdChanged(sender, e)
	End Sub
	Public Sub OnZONAS_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ZONAS_CodigoChanged(sender, e)
	End Sub
	Public Sub OnSUCUR_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent SUCUR_IdChanged(sender, e)
	End Sub
	Public Sub OnENTID_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoChanged(sender, e)
	End Sub
	Public Sub OnCONDU_NroViajeChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CONDU_NroViajeChanged(sender, e)
	End Sub
	Public Sub OnCONDU_LicenciaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CONDU_LicenciaChanged(sender, e)
	End Sub
	Public Sub OnCONDU_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent CONDU_EstadoChanged(sender, e)
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

