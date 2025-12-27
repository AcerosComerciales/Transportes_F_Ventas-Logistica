Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETRAN_Ranflas

#Region " Campos "
	
	Private m_ranfl_id As Long
	Private m_tipos_codmarca As String
	Private m_ranfl_codigo As String
	Private m_ranfl_modelo As String
	Private m_ranfl_placa As String
	Private m_ranfl_certificado As String
	Private m_ranfl_fecadquisicion As Date
	Private m_ranfl_estado As String
	Private m_ranfl_usrcrea As String
	Private m_ranfl_feccrea As Date
	Private m_ranfl_usrmod As String
	Private m_ranfl_fecmod As Date
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACETransporte.My.Resources.xmlTRAN_Ranflas
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
	
	Public Property RANFL_Id() As Long
		Get
			return m_ranfl_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_ranfl_id) Then
				If Not m_ranfl_id.Equals(value) Then
					m_ranfl_id = value
					OnRANFL_IdChanged(m_ranfl_id, EventArgs.Empty)
				End If
			Else
				m_ranfl_id = value
				OnRANFL_IdChanged(m_ranfl_id, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property TIPOS_CodMarca() As String
		Get
			return m_tipos_codmarca
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codmarca) Then
				If Not m_tipos_codmarca.Equals(value) Then
					m_tipos_codmarca = value
					OnTIPOS_CodMarcaChanged(m_tipos_codmarca, EventArgs.Empty)
				End If
			Else
				m_tipos_codmarca = value
				OnTIPOS_CodMarcaChanged(m_tipos_codmarca, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property RANFL_Codigo() As String
		Get
			return m_ranfl_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_ranfl_codigo) Then
				If Not m_ranfl_codigo.Equals(value) Then
					m_ranfl_codigo = value
					OnRANFL_CodigoChanged(m_ranfl_codigo, EventArgs.Empty)
				End If
			Else
				m_ranfl_codigo = value
				OnRANFL_CodigoChanged(m_ranfl_codigo, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property RANFL_Modelo() As String
		Get
			return m_ranfl_modelo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_ranfl_modelo) Then
				If Not m_ranfl_modelo.Equals(value) Then
					m_ranfl_modelo = value
					OnRANFL_ModeloChanged(m_ranfl_modelo, EventArgs.Empty)
				End If
			Else
				m_ranfl_modelo = value
				OnRANFL_ModeloChanged(m_ranfl_modelo, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property RANFL_Placa() As String
		Get
			return m_ranfl_placa
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_ranfl_placa) Then
				If Not m_ranfl_placa.Equals(value) Then
					m_ranfl_placa = value
					OnRANFL_PlacaChanged(m_ranfl_placa, EventArgs.Empty)
				End If
			Else
				m_ranfl_placa = value
				OnRANFL_PlacaChanged(m_ranfl_placa, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property RANFL_Certificado() As String
		Get
			return m_ranfl_certificado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_ranfl_certificado) Then
				If Not m_ranfl_certificado.Equals(value) Then
					m_ranfl_certificado = value
					OnRANFL_CertificadoChanged(m_ranfl_certificado, EventArgs.Empty)
				End If
			Else
				m_ranfl_certificado = value
				OnRANFL_CertificadoChanged(m_ranfl_certificado, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property RANFL_FecAdquisicion() As Date
		Get
			return m_ranfl_fecadquisicion
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_ranfl_fecadquisicion) Then
				If Not m_ranfl_fecadquisicion.Equals(value) Then
					m_ranfl_fecadquisicion = value
					OnRANFL_FecAdquisicionChanged(m_ranfl_fecadquisicion, EventArgs.Empty)
				End If
			Else
				m_ranfl_fecadquisicion = value
				OnRANFL_FecAdquisicionChanged(m_ranfl_fecadquisicion, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property RANFL_Estado() As String
		Get
			return m_ranfl_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_ranfl_estado) Then
				If Not m_ranfl_estado.Equals(value) Then
					m_ranfl_estado = value
					OnRANFL_EstadoChanged(m_ranfl_estado, EventArgs.Empty)
				End If
			Else
				m_ranfl_estado = value
				OnRANFL_EstadoChanged(m_ranfl_estado, EventArgs.Empty)
			End If
		End Set
	End Property
	Public Property RANFL_UsrCrea() As String
		Get
			return m_ranfl_usrcrea
		End Get
		Set(ByVal value As String)
			m_ranfl_usrcrea = value
		End Set
	End Property
	Public Property RANFL_FecCrea() As Date
		Get
			return m_ranfl_feccrea
		End Get
		Set(ByVal value As Date)
			m_ranfl_feccrea = value
		End Set
	End Property
	Public Property RANFL_UsrMod() As String
		Get
			return m_ranfl_usrmod
		End Get
		Set(ByVal value As String)
			m_ranfl_usrmod = value
		End Set
	End Property
	Public Property RANFL_FecMod() As Date
		Get
			return m_ranfl_fecmod
		End Get
		Set(ByVal value As Date)
			m_ranfl_fecmod = value
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
			Return "TRAN_Ranflas"
		End Get
	End Property
	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "Transportes"
		End Get
	End Property


#End Region

#Region " Eventos "
	
	Public Event RANFL_IdChanged As EventHandler
	Public Event TIPOS_CodMarcaChanged As EventHandler
	Public Event RANFL_CodigoChanged As EventHandler
	Public Event RANFL_ModeloChanged As EventHandler
	Public Event RANFL_PlacaChanged As EventHandler
	Public Event RANFL_CertificadoChanged As EventHandler
	Public Event RANFL_FecAdquisicionChanged As EventHandler
	Public Event RANFL_EstadoChanged As EventHandler
	Public Sub OnRANFL_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent RANFL_IdChanged(sender, e)
	End Sub
	Public Sub OnTIPOS_CodMarcaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodMarcaChanged(sender, e)
	End Sub
	Public Sub OnRANFL_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent RANFL_CodigoChanged(sender, e)
	End Sub
	Public Sub OnRANFL_ModeloChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent RANFL_ModeloChanged(sender, e)
	End Sub
	Public Sub OnRANFL_PlacaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent RANFL_PlacaChanged(sender, e)
	End Sub
	Public Sub OnRANFL_CertificadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent RANFL_CertificadoChanged(sender, e)
	End Sub
	Public Sub OnRANFL_FecAdquisicionChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent RANFL_FecAdquisicionChanged(sender, e)
	End Sub
	Public Sub OnRANFL_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent RANFL_EstadoChanged(sender, e)
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

