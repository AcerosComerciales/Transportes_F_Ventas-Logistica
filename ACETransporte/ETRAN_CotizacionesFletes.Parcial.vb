Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETRAN_CotizacionesFletes
   Implements ICloneable
#Region " Campos "
	
	Private m_cotiz_codigo As String
	Private m_flete_id As Long
	Private m_cofle_usrcrea As String
	Private m_cofle_feccrea As Date
	Private m_cofle_usrmod As String
	Private m_cofle_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACETransporte.My.Resources.xmlTRAN_CotizacionesFletes
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
	
	Public Property COTIZ_Codigo() As String
		Get
			return m_cotiz_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_cotiz_codigo) Then
				If Not m_cotiz_codigo.Equals(value) Then
					m_cotiz_codigo = value
					OnCOTIZ_CodigoChanged(m_cotiz_codigo, EventArgs.Empty)
				End If
			Else
				m_cotiz_codigo = value
				OnCOTIZ_CodigoChanged(m_cotiz_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property FLETE_Id() As Long
		Get
			return m_flete_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_flete_id) Then
				If Not m_flete_id.Equals(value) Then
					m_flete_id = value
					OnFLETE_IdChanged(m_flete_id, EventArgs.Empty)
				End If
			Else
				m_flete_id = value
				OnFLETE_IdChanged(m_flete_id, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property COFLE_UsrCrea() As String
		Get
			return m_cofle_usrcrea
		End Get
		Set(ByVal value As String)
			m_cofle_usrcrea = value
		End Set
	End Property

	Public Property COFLE_FecCrea() As Date
		Get
			return m_cofle_feccrea
		End Get
		Set(ByVal value As Date)
			m_cofle_feccrea = value
		End Set
	End Property

	Public Property COFLE_UsrMod() As String
		Get
			return m_cofle_usrmod
		End Get
		Set(ByVal value As String)
			m_cofle_usrmod = value
		End Set
	End Property

	Public Property COFLE_FecMod() As Date
		Get
			return m_cofle_fecmod
		End Get
		Set(ByVal value As Date)
			m_cofle_fecmod = value
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
			Return "TRAN_CotizacionesFletes"
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
	
	Public Event COTIZ_CodigoChanged As EventHandler
	Public Event FLETE_IdChanged As EventHandler

	Public Sub OnCOTIZ_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent COTIZ_CodigoChanged(sender, e)
	End Sub

	Public Sub OnFLETE_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent FLETE_IdChanged(sender, e)
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

   Public Function Clone() As Object Implements System.ICloneable.Clone
      Try
         Dim cloneInstance As New ETRAN_CotizacionesFletes()
         cloneInstance = CType(Me, ETRAN_CotizacionesFletes)
         Return cloneInstance.MemberwiseClone
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#End Region

End Class

