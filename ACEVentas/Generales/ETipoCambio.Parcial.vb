Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETipoCambio

#Region " Campos "
	
	Private m_tipoc_fecha As String
	Private m_tipoc_fechac As Date
	Private m_tipoc_compraoficina As Decimal
	Private m_tipoc_ventaoficina As Decimal
	Private m_tipoc_comprarenta As Decimal
	Private m_tipoc_ventarenta As Decimal
	Private m_tipoc_comprasunat As Decimal
	Private m_tipoc_ventasunat As Decimal
	Private m_tipoc_usrcrea As String
	Private m_tipoc_feccrea As Date
	Private m_tipoc_fecmod As Date
	Private m_tipoc_usrmod As String
	Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlTipoCambio
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
	
	Public Property TIPOC_Fecha() As String
		Get
			return m_tipoc_fecha
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipoc_fecha) Then
				If Not m_tipoc_fecha.Equals(value) Then
					m_tipoc_fecha = value
					OnTIPOC_FechaChanged(m_tipoc_fecha, EventArgs.Empty)
				End If
			Else
				m_tipoc_fecha = value
				OnTIPOC_FechaChanged(m_tipoc_fecha, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOC_FechaC() As Date
		Get
			return m_tipoc_fechac
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_tipoc_fechac) Then
				If Not m_tipoc_fechac.Equals(value) Then
					m_tipoc_fechac = value
					OnTIPOC_FechaCChanged(m_tipoc_fechac, EventArgs.Empty)
				End If
			Else
				m_tipoc_fechac = value
				OnTIPOC_FechaCChanged(m_tipoc_fechac, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOC_CompraOficina() As Decimal
		Get
			return m_tipoc_compraoficina
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_tipoc_compraoficina) Then
				If Not m_tipoc_compraoficina.Equals(value) Then
					m_tipoc_compraoficina = value
					OnTIPOC_CompraOficinaChanged(m_tipoc_compraoficina, EventArgs.Empty)
				End If
			Else
				m_tipoc_compraoficina = value
				OnTIPOC_CompraOficinaChanged(m_tipoc_compraoficina, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOC_VentaOficina() As Decimal
		Get
			return m_tipoc_ventaoficina
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_tipoc_ventaoficina) Then
				If Not m_tipoc_ventaoficina.Equals(value) Then
					m_tipoc_ventaoficina = value
					OnTIPOC_VentaOficinaChanged(m_tipoc_ventaoficina, EventArgs.Empty)
				End If
			Else
				m_tipoc_ventaoficina = value
				OnTIPOC_VentaOficinaChanged(m_tipoc_ventaoficina, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOC_CompraRenta() As Decimal
		Get
			return m_tipoc_comprarenta
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_tipoc_comprarenta) Then
				If Not m_tipoc_comprarenta.Equals(value) Then
					m_tipoc_comprarenta = value
					OnTIPOC_CompraRentaChanged(m_tipoc_comprarenta, EventArgs.Empty)
				End If
			Else
				m_tipoc_comprarenta = value
				OnTIPOC_CompraRentaChanged(m_tipoc_comprarenta, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOC_VentaRenta() As Decimal
		Get
			return m_tipoc_ventarenta
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_tipoc_ventarenta) Then
				If Not m_tipoc_ventarenta.Equals(value) Then
					m_tipoc_ventarenta = value
					OnTIPOC_VentaRentaChanged(m_tipoc_ventarenta, EventArgs.Empty)
				End If
			Else
				m_tipoc_ventarenta = value
				OnTIPOC_VentaRentaChanged(m_tipoc_ventarenta, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOC_CompraSunat() As Decimal
		Get
			return m_tipoc_comprasunat
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_tipoc_comprasunat) Then
				If Not m_tipoc_comprasunat.Equals(value) Then
					m_tipoc_comprasunat = value
					OnTIPOC_CompraSunatChanged(m_tipoc_comprasunat, EventArgs.Empty)
				End If
			Else
				m_tipoc_comprasunat = value
				OnTIPOC_CompraSunatChanged(m_tipoc_comprasunat, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOC_VentaSunat() As Decimal
		Get
			return m_tipoc_ventasunat
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_tipoc_ventasunat) Then
				If Not m_tipoc_ventasunat.Equals(value) Then
					m_tipoc_ventasunat = value
					OnTIPOC_VentaSunatChanged(m_tipoc_ventasunat, EventArgs.Empty)
				End If
			Else
				m_tipoc_ventasunat = value
				OnTIPOC_VentaSunatChanged(m_tipoc_ventasunat, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOC_UsrCrea() As String
		Get
			return m_tipoc_usrcrea
		End Get
		Set(ByVal value As String)
			m_tipoc_usrcrea = value
		End Set
	End Property

	Public Property TIPOC_FecCrea() As Date
		Get
			return m_tipoc_feccrea
		End Get
		Set(ByVal value As Date)
			m_tipoc_feccrea = value
		End Set
	End Property

	Public Property TIPOC_FecMod() As Date
		Get
			return m_tipoc_fecmod
		End Get
		Set(ByVal value As Date)
			m_tipoc_fecmod = value
		End Set
	End Property

	Public Property TIPOC_UsrMod() As String
		Get
			return m_tipoc_usrmod
		End Get
		Set(ByVal value As String)
			m_tipoc_usrmod = value
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
			Return "TipoCambio"
		End Get
	End Property

	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "dbo"
		End Get
	End Property

	#End Region

#End Region

#Region " Eventos "
	
	Public Event TIPOC_FechaChanged As EventHandler
	Public Event TIPOC_FechaCChanged As EventHandler
	Public Event TIPOC_CompraOficinaChanged As EventHandler
	Public Event TIPOC_VentaOficinaChanged As EventHandler
	Public Event TIPOC_CompraRentaChanged As EventHandler
	Public Event TIPOC_VentaRentaChanged As EventHandler
	Public Event TIPOC_CompraSunatChanged As EventHandler
	Public Event TIPOC_VentaSunatChanged As EventHandler

	Public Sub OnTIPOC_FechaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOC_FechaChanged(sender, e)
	End Sub

	Public Sub OnTIPOC_FechaCChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOC_FechaCChanged(sender, e)
	End Sub

	Public Sub OnTIPOC_CompraOficinaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOC_CompraOficinaChanged(sender, e)
	End Sub

	Public Sub OnTIPOC_VentaOficinaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOC_VentaOficinaChanged(sender, e)
	End Sub

	Public Sub OnTIPOC_CompraRentaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOC_CompraRentaChanged(sender, e)
	End Sub

	Public Sub OnTIPOC_VentaRentaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOC_VentaRentaChanged(sender, e)
	End Sub

	Public Sub OnTIPOC_CompraSunatChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOC_CompraSunatChanged(sender, e)
	End Sub

	Public Sub OnTIPOC_VentaSunatChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOC_VentaSunatChanged(sender, e)
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

