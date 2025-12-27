Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class EDIST_GuiasRemisionDetalle

#Region " Campos "
	
	Private m_guiar_codigo As String
	Private m_guird_item As Short
	Private m_artic_codigo As String
	Private m_guird_itemdocumento As Short
	Private m_guird_pesounitario As Decimal
	Private m_guird_cantidad As Decimal
	Private m_guird_usrcrea As String
	Private m_guird_feccrea As Date
	Private m_guird_usrmod As String
	Private m_guird_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
    Private m_eliminado As Boolean
    Private m_artic_descripcion As String
    Private m_tipos_unidadmedida As String
    Private m_tipos_unidadmedidacorta As String



	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACELogistica.My.Resources.xmlDIST_GuiasRemisionDetalle
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

    Public Property ARTIC_Descripcion() As String
        Get
            Return m_artic_descripcion
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_artic_descripcion) Then
                If Not m_artic_descripcion.Equals(value) Then
                    m_artic_descripcion = value
                End If
            Else
                m_artic_descripcion = value
            End If
        End Set
    End Property
    Public Property TIPOS_UnidadMedida() As String
        Get
            Return m_tipos_unidadmedida
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_tipos_unidadmedida) Then
                If Not m_tipos_unidadmedida.Equals(value) Then
                    m_tipos_unidadmedida = value
                End If
            Else
                m_tipos_unidadmedida = value
            End If
        End Set
    End Property
    Public Property TIPOS_UnidadMedidaCorta() As String
        Get
            Return m_tipos_unidadmedidacorta
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_tipos_unidadmedidacorta) Then
                If Not m_tipos_unidadmedidacorta.Equals(value) Then
                    m_tipos_unidadmedidacorta = value
                End If
            Else
                m_tipos_unidadmedidacorta = value
            End If
        End Set
    End Property
	Public Property GUIAR_Codigo() As String
		Get
			return m_guiar_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_guiar_codigo) Then
				If Not m_guiar_codigo.Equals(value) Then
					m_guiar_codigo = value
					OnGUIAR_CodigoChanged(m_guiar_codigo, EventArgs.Empty)
				End If
			Else
				m_guiar_codigo = value
				OnGUIAR_CodigoChanged(m_guiar_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property GUIRD_Item() As Short
		Get
			return m_guird_item
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_guird_item) Then
				If Not m_guird_item.Equals(value) Then
					m_guird_item = value
					OnGUIRD_ItemChanged(m_guird_item, EventArgs.Empty)
				End If
			Else
				m_guird_item = value
				OnGUIRD_ItemChanged(m_guird_item, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ARTIC_Codigo() As String
		Get
			return m_artic_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_artic_codigo) Then
				If Not m_artic_codigo.Equals(value) Then
					m_artic_codigo = value
					OnARTIC_CodigoChanged(m_artic_codigo, EventArgs.Empty)
				End If
			Else
				m_artic_codigo = value
				OnARTIC_CodigoChanged(m_artic_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property GUIRD_ItemDocumento() As Short
		Get
			return m_guird_itemdocumento
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_guird_itemdocumento) Then
				If Not m_guird_itemdocumento.Equals(value) Then
					m_guird_itemdocumento = value
					OnGUIRD_ItemDocumentoChanged(m_guird_itemdocumento, EventArgs.Empty)
				End If
			Else
				m_guird_itemdocumento = value
				OnGUIRD_ItemDocumentoChanged(m_guird_itemdocumento, EventArgs.Empty)
			End If
		End Set
    End Property

    Public ReadOnly Property SubPeso() As Decimal
        Get
            Return m_guird_cantidad * m_guird_pesounitario
        End Get
    End Property

	Public Property GUIRD_PesoUnitario() As Decimal
		Get
			return m_guird_pesounitario
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_guird_pesounitario) Then
				If Not m_guird_pesounitario.Equals(value) Then
					m_guird_pesounitario = value
					OnGUIRD_PesoUnitarioChanged(m_guird_pesounitario, EventArgs.Empty)
				End If
			Else
				m_guird_pesounitario = value
				OnGUIRD_PesoUnitarioChanged(m_guird_pesounitario, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property GUIRD_Cantidad() As Decimal
		Get
			return m_guird_cantidad
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_guird_cantidad) Then
				If Not m_guird_cantidad.Equals(value) Then
					m_guird_cantidad = value
					OnGUIRD_CantidadChanged(m_guird_cantidad, EventArgs.Empty)
				End If
			Else
				m_guird_cantidad = value
				OnGUIRD_CantidadChanged(m_guird_cantidad, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property GUIRD_UsrCrea() As String
		Get
			return m_guird_usrcrea
		End Get
		Set(ByVal value As String)
			m_guird_usrcrea = value
		End Set
	End Property

	Public Property GUIRD_FecCrea() As Date
		Get
			return m_guird_feccrea
		End Get
		Set(ByVal value As Date)
			m_guird_feccrea = value
		End Set
	End Property

	Public Property GUIRD_UsrMod() As String
		Get
			return m_guird_usrmod
		End Get
		Set(ByVal value As String)
			m_guird_usrmod = value
		End Set
	End Property

	Public Property GUIRD_FecMod() As Date
		Get
			return m_guird_fecmod
		End Get
		Set(ByVal value As Date)
			m_guird_fecmod = value
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
			Return "DIST_GuiasRemisionDetalle"
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
	
	Public Event GUIAR_CodigoChanged As EventHandler
	Public Event GUIRD_ItemChanged As EventHandler
	Public Event ARTIC_CodigoChanged As EventHandler
	Public Event GUIRD_ItemDocumentoChanged As EventHandler
	Public Event GUIRD_PesoUnitarioChanged As EventHandler
	Public Event GUIRD_CantidadChanged As EventHandler

	Public Sub OnGUIAR_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GUIAR_CodigoChanged(sender, e)
	End Sub

	Public Sub OnGUIRD_ItemChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GUIRD_ItemChanged(sender, e)
	End Sub

	Public Sub OnARTIC_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARTIC_CodigoChanged(sender, e)
	End Sub

	Public Sub OnGUIRD_ItemDocumentoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GUIRD_ItemDocumentoChanged(sender, e)
	End Sub

	Public Sub OnGUIRD_PesoUnitarioChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GUIRD_PesoUnitarioChanged(sender, e)
	End Sub

	Public Sub OnGUIRD_CantidadChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GUIRD_CantidadChanged(sender, e)
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




