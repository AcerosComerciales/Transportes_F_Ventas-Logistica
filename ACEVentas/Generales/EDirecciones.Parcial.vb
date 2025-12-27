Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class EDirecciones

#Region " Campos "
	
	Private m_direc_id As Short
	Private m_entid_codigo As String
    Private m_ubigo_codigo As String
    Private m_entid_codigo_ent As String
    Private m_direc_direccion As String
	Private m_direc_observacion As String
	Private m_direc_estado As String
	Private m_direc_usrcrea As String
	Private m_direc_feccrea As Date
	Private m_direc_usrmod As String
	Private m_direc_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean
    Private m_tipo_direccion As String

    Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlDirecciones
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
	
	Public Property DIREC_Id() As Short
		Get
			return m_direc_id
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_direc_id) Then
				If Not m_direc_id.Equals(value) Then
					m_direc_id = value
					OnDIREC_IdChanged(m_direc_id, EventArgs.Empty)
				End If
			Else
				m_direc_id = value
				OnDIREC_IdChanged(m_direc_id, EventArgs.Empty)
			End If
		End Set
	End Property
    Public Property ENTID_Codigo() As String
        Get
            Return m_entid_codigo
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
    'Variable ENTID_Direccion Creador para Mostrar Direccion desde Entidades 

    Public Property ENTID_Direccion() As String
        Get
            Return m_entid_codigo_ent
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_entid_codigo_ent) Then
                If Not m_entid_codigo_ent.Equals(value) Then
                    m_entid_codigo_ent = value
                    OnUBIGO_CodigoChanged(m_entid_codigo_ent, EventArgs.Empty)
                End If
            Else
                m_entid_codigo_ent = value
                OnUBIGO_CodigoChanged(m_entid_codigo_ent, EventArgs.Empty)
            End If
        End Set
    End Property


    Public Property UBIGO_Codigo() As String
		Get
			return m_ubigo_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_ubigo_codigo) Then
				If Not m_ubigo_codigo.Equals(value) Then
					m_ubigo_codigo = value
					OnUBIGO_CodigoChanged(m_ubigo_codigo, EventArgs.Empty)
				End If
			Else
				m_ubigo_codigo = value
				OnUBIGO_CodigoChanged(m_ubigo_codigo, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property DIREC_Direccion() As String
		Get
			return m_direc_direccion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_direc_direccion) Then
				If Not m_direc_direccion.Equals(value) Then
					m_direc_direccion = value
					OnDIREC_DireccionChanged(m_direc_direccion, EventArgs.Empty)
				End If
			Else
				m_direc_direccion = value
				OnDIREC_DireccionChanged(m_direc_direccion, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property DIREC_Observacion() As String
		Get
			return m_direc_observacion
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_direc_observacion) Then
				If Not m_direc_observacion.Equals(value) Then
					m_direc_observacion = value
					OnDIREC_ObservacionChanged(m_direc_observacion, EventArgs.Empty)
				End If
			Else
				m_direc_observacion = value
				OnDIREC_ObservacionChanged(m_direc_observacion, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property DIREC_Estado() As String
		Get
			return m_direc_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_direc_estado) Then
				If Not m_direc_estado.Equals(value) Then
					m_direc_estado = value
					OnDIREC_EstadoChanged(m_direc_estado, EventArgs.Empty)
				End If
			Else
				m_direc_estado = value
				OnDIREC_EstadoChanged(m_direc_estado, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property DIREC_UsrCrea() As String
		Get
			return m_direc_usrcrea
		End Get
		Set(ByVal value As String)
			m_direc_usrcrea = value
		End Set
	End Property
	Public Property DIREC_FecCrea() As Date
		Get
			return m_direc_feccrea
		End Get
		Set(ByVal value As Date)
			m_direc_feccrea = value
		End Set
	End Property
	Public Property DIREC_UsrMod() As String
		Get
			return m_direc_usrmod
		End Get
		Set(ByVal value As String)
			m_direc_usrmod = value
		End Set
	End Property
    Public Property DIREC_FecMod() As Date
        Get
            Return m_direc_fecmod
        End Get
        Set(ByVal value As Date)
            m_direc_fecmod = value
        End Set
    End Property
    Public Property TIPO_Direccion() As String
        Get
            Return m_tipo_direccion
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_tipo_direccion) Then
                If Not m_tipo_direccion.Equals(value) Then
                    m_tipo_direccion = value
                    OnTIPO_DireccionChanged(m_tipo_direccion, EventArgs.Empty)
                End If
            Else
                m_tipo_direccion = value
                OnTIPO_DireccionChanged(m_tipo_direccion, EventArgs.Empty)
            End If
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
			Return "Direcciones"
		End Get
	End Property
	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "dbo"
		End Get
	End Property


#End Region

#Region " Eventos "
	
	Public Event DIREC_IdChanged As EventHandler
	Public Event ENTID_CodigoChanged As EventHandler
    Public Event UBIGO_CodigoChanged As EventHandler '
    Public Event ENTID_DireccionChanged As EventHandler '
    Public Event DIREC_DireccionChanged As EventHandler
	Public Event DIREC_ObservacionChanged As EventHandler
    Public Event DIREC_EstadoChanged As EventHandler
    Public Event TIPO_DireccionChanged As EventHandler
    Public Sub OnDIREC_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DIREC_IdChanged(sender, e)
	End Sub
	Public Sub OnENTID_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoChanged(sender, e)
	End Sub
    Public Sub OnUBIGO_CodigoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent UBIGO_CodigoChanged(sender, e)
    End Sub
    'ENTID_Direccion
    Public Sub OnENTID_DireccionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent ENTID_DireccionChanged(sender, e)
    End Sub
    Public Sub OnDIREC_DireccionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DIREC_DireccionChanged(sender, e)
	End Sub
	Public Sub OnDIREC_ObservacionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DIREC_ObservacionChanged(sender, e)
	End Sub
    Public Sub OnDIREC_EstadoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DIREC_EstadoChanged(sender, e)
    End Sub
    Public Sub OnTIPO_DireccionChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent TIPO_DireccionChanged(sender, e)
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

