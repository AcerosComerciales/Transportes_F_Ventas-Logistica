Imports System
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Public Class EABAS_GestionOrdenesDetalle


#Region " Campos "
  
    Private m_seleccion As Boolean
    Private m_almac_origen As String
    Private m_entid_direccion As String
    Private m_codigo As String
    Private m_usuario As String
    Private m_usu_Modificador As String
    Private m_tipodoc as String
    Private m_documento As String
    Private m_peso As Decimal
    Private m_stock As Decimal
    Private m_cliente As String
    Private m_nuevo As Boolean
    Private m_modificado as Boolean
    Private m_eliminado As Boolean
    Private m_docrelacionado as String
    
    
    Public Property Documento_Rel() As String
     Get
         Return m_docrelacionado
      End Get
      Set(ByVal value As String)
         m_docrelacionado = value
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

   Public Property Seleccion() As Boolean
      Get
         Return m_seleccion
      End Get
      Set(ByVal value As Boolean)
         m_seleccion = value
      End Set
   End Property

    Public Property DocumentoOC() As String
        Get
         Return m_documento
      End Get
      Set(ByVal value As String)
         m_documento = value
      End Set
    End Property
    Public Property GESTOD_CantRestante() As Decimal
        Get
         Return m_stock
      End Get
      Set(ByVal value As Decimal)
         m_stock = value
      End Set
    End Property


   Public Property ALMAC_Origen() As String
      Get
         Return m_almac_origen
      End Get
      Set(ByVal value As String)
         m_almac_origen = value
      End Set
   End Property
   



   Public Property ENTID_Direccion() As String
      Get
         Return m_entid_direccion
      End Get
      Set(ByVal value As String)
         m_entid_direccion = value
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

   Public ReadOnly Property GESTOR_EstadoOC_Text() As String
      Get
         Select Case m_gestod_estadoOC
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

Partial Public Class EABAS_GestionOrdenesDetalle

#Region " Campos "
	
	Private m_gestor_codigo As String
    Private m_gestod_item As Short
	Private m_gestod_CodigoOC As String
    Private m_gestod_DescripcionClienteOC As String
	Private m_gestod_CantidadXmetrosOC As decimal
    Private m_gestod_Cantidadusada As decimal
    Private m_gestod_FecCreaOC As Date
    Private m_gestod_EstadoOC as String
    Private m_gestod_feccrea as date
    Private m_gestod_usrcrea as String
    Private m_gestod_fecmod as date
    Private m_gestod_usrmod as String
    Private m_gestod_saldo as decimal
    
	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlABAS_GestionOrdenesDetalle
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
	
	Public Property GESTOR_Codigo() As String
		Get
			return m_gestor_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_gestor_codigo) Then
				If Not m_gestor_codigo.Equals(value) Then
					m_gestor_codigo = value
					OnGESTOR_CodigoChanged(m_gestor_codigo, EventArgs.Empty)
				End If
			Else
				m_gestor_codigo = value
				OnGESTOR_CodigoChanged(m_gestor_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

    Public Property GESTOD_Item() As Short
		Get
			return m_gestod_item
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_gestod_item) Then
				If Not m_gestod_item.Equals(value) Then
					m_gestod_item = value
					OnGESTOD_ItemChanged(m_gestod_item, EventArgs.Empty)
				End If
			Else
				m_gestod_item = value
				OnGESTOD_ItemChanged(m_gestod_item, EventArgs.Empty)
			End If
		End Set
	End Property

     Public Property GESTOD_CodigoOC() As String
		Get
			return m_gestod_CodigoOC
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_gestod_CodigoOC) Then
				If Not m_gestod_CodigoOC.Equals(value) Then
					m_gestod_CodigoOC = value
					OnGESTOD_CodigoOCChanged(m_gestod_CodigoOC, EventArgs.Empty)
				End If
			Else
				m_gestod_CodigoOC = value
				OnGESTOD_CodigoOCChanged(m_gestod_CodigoOC, EventArgs.Empty)
			End If
		End Set
	End Property
    

    	Public Property GESTOD_DescripcionClienteOC() As String
		Get
			return m_gestod_DescripcionClienteOC
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_gestod_DescripcionClienteOC) Then
				If Not m_gestod_DescripcionClienteOC.Equals(value) Then
					m_gestod_DescripcionClienteOC = value
					OnGESTOD_DescripcionClienteOCChanged(m_gestod_DescripcionClienteOC, EventArgs.Empty)
				End If
			Else
				m_gestod_DescripcionClienteOC = value
				OnGESTOD_DescripcionClienteOCChanged(m_gestod_DescripcionClienteOC, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property GESTOD_CantidadXmetrosOC() As Decimal
		Get
			return m_gestod_CantidadXmetrosOC
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_gestod_CantidadXmetrosOC) Then
				If Not m_gestod_CantidadXmetrosOC.Equals(value) Then
					m_gestod_CantidadXmetrosOC = value
					OnGESTOD_CantidadXmetrosOCChanged(m_gestod_CantidadXmetrosOC, EventArgs.Empty)
				End If
			Else
				m_gestod_CantidadXmetrosOC = value
				OnGESTOD_CantidadXmetrosOCChanged(m_gestod_CantidadXmetrosOC, EventArgs.Empty)
			End If
		End Set
	End Property
    
    Public Property GESTOD_FecCreaOC() As Date
		Get
			return m_gestod_FecCreaOC
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_gestod_FecCreaOC) Then
				If Not m_gestod_FecCreaOC.Equals(value) Then
					m_gestod_FecCreaOC = value
					OnGESTOD_FecCreaOCChanged(m_gestod_FecCreaOC, EventArgs.Empty)
				End If
			Else
				m_gestod_FecCreaOC = value
				OnGESTOD_FecCreaOCChanged(m_gestod_FecCreaOC, EventArgs.Empty)
			End If
		End Set
	End Property

    Public Property GESTOD_EstadoOC() As String
		Get
			return m_gestod_EstadoOC
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_gestod_EstadoOC) Then
				If Not m_gestod_EstadoOC.Equals(value) Then
					m_gestod_EstadoOC = value
					OnGESTOD_EstadoOCChanged(m_gestod_EstadoOC, EventArgs.Empty)
				End If
			Else
				m_gestod_EstadoOC = value
				OnGESTOD_EstadoOCChanged(m_gestod_EstadoOC, EventArgs.Empty)
			End If
		End Set
	End Property  
    
	Public Property GESTOD_UsrCrea() As String
		Get
			return m_gestod_usrcrea
		End Get
		Set(ByVal value As String)
			m_gestod_usrcrea = value
		End Set
	End Property
    
    Public Property CANTIDAD() As Decimal
		Get
			return m_gestod_Cantidadusada
		End Get
		Set(ByVal value As Decimal)
			m_gestod_Cantidadusada = value
		End Set
	End Property

    Public Property GESTOD_Saldo() As Decimal
		Get
			return m_gestod_saldo
		End Get
		Set(ByVal value As Decimal)
			m_gestod_saldo = value
		End Set
	End Property
    

	Public Property GESTOD_FecCrea() As Date
		Get
			return m_gestod_feccrea
		End Get
		Set(ByVal value As Date)
			m_gestod_feccrea = value
		End Set
	End Property

    Public Property GESTOD_UsrMod() As String
		Get
			return m_gestod_usrmod
		End Get
		Set(ByVal value As String)
			m_gestod_usrmod = value
		End Set
	End Property

	Public Property GESTOD_FecMod() As Date
		Get
			return m_gestod_fecmod
		End Get
		Set(ByVal value As Date)
			m_gestod_fecmod = value
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
			Return "ABAS_GestionOrdenes"
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
	
	Public Event GESTOR_CodigoChanged As EventHandler
    Public Event GESTOD_ItemChanged as EventHandler
    Public Event GESTOD_CodigoOCChanged as EventHandler
    Public Event GESTOD_DescripcionClienteOCChanged As EventHandler
	Public Event GESTOD_CantidadXmetrosOCChanged As EventHandler
	Public Event GESTOD_FecCreaOCChanged As EventHandler
    Public Event GESTOD_EstadoOCChanged As EventHandler
    Public Event GESTOD_FecCreaChanged As EventHandler
	Public Event GESTOD_UsrCreaChanged As EventHandler
    Public Event GESTOD_FecModChanged As EventHandler
	Public Event GESTOD_UsrModChanged As EventHandler
  
	

	Public Sub OnGESTOR_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GESTOR_CodigoChanged(sender, e)
	End Sub
    
    Public Sub OnGESTOD_ItemChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GESTOD_ItemChanged(sender, e)
	End Sub
   
    Public Sub OnGESTOD_CodigoOCChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GESTOD_CodigoOCChanged(sender, e)
	End Sub
	Public Sub OnGESTOD_DescripcionClienteOCChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GESTOD_DescripcionClienteOCChanged(sender, e)
	End Sub

	Public Sub OnGESTOD_CantidadXmetrosOCChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GESTOD_CantidadXmetrosOCChanged(sender, e)
	End Sub

    Public Sub OnGESTOD_FecCreaOCChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GESTOD_FecCreaOCChanged(sender, e)
	End Sub
    
	Public Sub OnGESTOD_EstadoOCChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GESTOD_EstadoOCChanged(sender, e)
	End Sub

	Public Sub OnGESTOD_FecCreaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GESTOD_FecCreaChanged(sender, e)
	End Sub
    
    Public Sub OnGESTOD_UsrCreaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GESTOD_UsrCreaChanged(sender, e)
	End Sub

	Public Sub OnGESTOD_FecModChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GESTOD_FecModChanged(sender, e)
	End Sub
    
    Public Sub OnGESTOD_UsrModChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GESTOD_UsrModChanged(sender, e)
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
