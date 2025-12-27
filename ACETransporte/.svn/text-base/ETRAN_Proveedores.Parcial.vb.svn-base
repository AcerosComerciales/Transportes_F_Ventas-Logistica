Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETRAN_Proveedores

#Region " Campos "
	
	Private m_prove_id As Long
	Private m_prove_nombre As String
	Private m_prove_direccion As String
	Private m_prove_ruc As String
	Private m_prove_sucursal As String
	Private m_sucur_id As Short
	Private m_entid_id As Long
	Private m_prove_estado As String
	Private m_prove_usrcrea As String
	Private m_prove_feccrea As Date
	Private m_prove_usrmod As String
	Private m_prove_fecmod As String
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACETransporte.My.Resources.xmlTRAN_Proveedores
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
	
	Public Property PROVE_Id() As Long
		Get
			return m_prove_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_prove_id) Then
				If Not m_prove_id.Equals(value) Then
					m_prove_id = value
					OnPROVE_IdChanged(m_prove_id, EventArgs.Empty)
				End If
			Else
				m_prove_id = value
				OnPROVE_IdChanged(m_prove_id, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property PROVE_Nombre() As String
		Get
			return m_prove_nombre
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_prove_nombre) Then
				If Not m_prove_nombre.Equals(value) Then
					m_prove_nombre = value
					OnPROVE_NombreChanged(m_prove_nombre, EventArgs.Empty)
				End If
			Else
				m_prove_nombre = value
				OnPROVE_NombreChanged(m_prove_nombre, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property PROVE_Direccion() As String
		Get
			return m_prove_direccion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_prove_direccion) Then
				If Not m_prove_direccion.Equals(value) Then
					m_prove_direccion = value
					OnPROVE_DireccionChanged(m_prove_direccion, EventArgs.Empty)
				End If
			Else
				m_prove_direccion = value
				OnPROVE_DireccionChanged(m_prove_direccion, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property PROVE_RUC() As String
		Get
			return m_prove_ruc
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_prove_ruc) Then
				If Not m_prove_ruc.Equals(value) Then
					m_prove_ruc = value
					OnPROVE_RUCChanged(m_prove_ruc, EventArgs.Empty)
				End If
			Else
				m_prove_ruc = value
				OnPROVE_RUCChanged(m_prove_ruc, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property PROVE_Sucursal() As String
		Get
			return m_prove_sucursal
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_prove_sucursal) Then
				If Not m_prove_sucursal.Equals(value) Then
					m_prove_sucursal = value
					OnPROVE_SucursalChanged(m_prove_sucursal, EventArgs.Empty)
				End If
			Else
				m_prove_sucursal = value
				OnPROVE_SucursalChanged(m_prove_sucursal, EventArgs.Empty)
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
	Public Property ENTID_Id() As Long
		Get
			return m_entid_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_entid_id) Then
				If Not m_entid_id.Equals(value) Then
					m_entid_id = value
					OnENTID_IdChanged(m_entid_id, EventArgs.Empty)
				End If
			Else
				m_entid_id = value
				OnENTID_IdChanged(m_entid_id, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property PROVE_Estado() As String
		Get
			return m_prove_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_prove_estado) Then
				If Not m_prove_estado.Equals(value) Then
					m_prove_estado = value
					OnPROVE_EstadoChanged(m_prove_estado, EventArgs.Empty)
				End If
			Else
				m_prove_estado = value
				OnPROVE_EstadoChanged(m_prove_estado, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property PROVE_UsrCrea() As String
		Get
			return m_prove_usrcrea
		End Get
		Set(ByVal value As String)
			m_prove_usrcrea = value
		End Set
	End Property
	Public Property PROVE_FecCrea() As Date
		Get
			return m_prove_feccrea
		End Get
		Set(ByVal value As Date)
			m_prove_feccrea = value
		End Set
	End Property
	Public Property PROVE_UsrMod() As String
		Get
			return m_prove_usrmod
		End Get
		Set(ByVal value As String)
			m_prove_usrmod = value
		End Set
	End Property
	Public Property PROVE_FecMod() As String
		Get
			return m_prove_fecmod
		End Get
		Set(ByVal value As String)
			m_prove_fecmod = value
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
			Return "TRAN_Proveedores"
		End Get
	End Property
	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "Transportes"
		End Get
	End Property


#End Region

#Region " Eventos "
	
	Public Event PROVE_IdChanged As EventHandler
	Public Event PROVE_NombreChanged As EventHandler
	Public Event PROVE_DireccionChanged As EventHandler
	Public Event PROVE_RUCChanged As EventHandler
	Public Event PROVE_SucursalChanged As EventHandler
	Public Event SUCUR_IdChanged As EventHandler
	Public Event ENTID_IdChanged As EventHandler
	Public Event PROVE_EstadoChanged As EventHandler
	Public Sub OnPROVE_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PROVE_IdChanged(sender, e)
	End Sub
	Public Sub OnPROVE_NombreChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PROVE_NombreChanged(sender, e)
	End Sub
	Public Sub OnPROVE_DireccionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PROVE_DireccionChanged(sender, e)
	End Sub
	Public Sub OnPROVE_RUCChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PROVE_RUCChanged(sender, e)
	End Sub
	Public Sub OnPROVE_SucursalChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PROVE_SucursalChanged(sender, e)
	End Sub
	Public Sub OnSUCUR_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent SUCUR_IdChanged(sender, e)
	End Sub
	Public Sub OnENTID_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_IdChanged(sender, e)
	End Sub
	Public Sub OnPROVE_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PROVE_EstadoChanged(sender, e)
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

