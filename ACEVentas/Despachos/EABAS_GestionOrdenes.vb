Imports System
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Public Class EABAS_GestionOrdenes


#Region " Campos "
   Private m_listdist_gestionordenesdetalle As List(Of EABAS_GestionOrdenesDetalle)

    Private m_seleccion As Boolean
    Private m_almac_origen As String
    Private m_entid_direccion As String
    Private m_codigo As String
    Private m_usuario As String
    Private m_usu_Modificador As String
    Private m_CANTIDAD As Decimal
    Private m_saldo As Decimal
    Private m_tipodoc as String
    Private m_peso As Decimal
    Private m_cliente As String
    Private m_nuevo As Boolean
    Private m_documento as String
    Private m_encargado As String
    Private m_artic_descripcion As String
    Private m_modificado as Boolean
    Private m_eliminado As Boolean
    Enum Estado
      Ingresado
      Anulado
      Eliminado
      Confirmado
   End Enum

   Public Property ListDIST_GestionOrdenesDetalle() As List(Of EABAS_GestionOrdenesDetalle)
      Get
         Return m_listdist_gestionordenesdetalle
      End Get
      Set(ByVal value As List(Of EABAS_GestionOrdenesDetalle))
         m_listdist_gestionordenesdetalle = value
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


   Public Property ALMAC_Origen() As String
      Get
         Return m_almac_origen
      End Get
      Set(ByVal value As String)
         m_almac_origen = value
      End Set
   End Property
   
    Public Property  Documento() as string
    Get
            return m_documento
    End Get
    Set(ByVal value As String)
            m_documento=value
    End Set
    end Property


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
    
    Public Property CANTIDAD() As decimal   
      Get
         Return m_CANTIDAD
      End Get
      Set(ByVal value As Decimal)
         m_CANTIDAD = value
      End Set
   End Property
    Public Property Saldo() As decimal   
      Get
         Return m_saldo
      End Get
      Set(ByVal value As Decimal)
         m_saldo = value
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

    Public Property ARTIC_Descripcion() As String
      Get
         Return m_artic_descripcion
      End Get
      Set(ByVal value As String)
         m_artic_descripcion = value
      End Set
   End Property

    Public Property ENTID_DescripcionEncargado() As String
      Get
         Return m_encargado
      End Get
      Set(ByVal value As String)
         m_encargado = value
      End Set
   End Property
  
    

   Public ReadOnly Property GESTOR_Estado_Text() As String
      Get
         Select Case m_gestor_estado
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
Partial Public Class EABAS_GestionOrdenes

#Region " Campos "
	
	Private m_gestor_codigo As String
    Private m_almac_id As Short
	Private m_entid_codigoencargado As String
    Private m_gestor_serie As String
	Private m_gestor_numero As Integer
    Private m_gestor_fechaingreso As Date
    Private m_gestor_fechatransformacion As Date
    Private m_gestor_lote as Long
    Private m_artic_codigo as String
    Private m_gestor_pesobruto as Decimal
    Private m_gestor_pesoneto as Decimal
    Private m_gestor_calcmetros as Decimal
    Private m_gestor_observaciones As String
    Private m_gestor_estado As String
	Private m_gestor_estadocorte As String
    Private m_gestor_usrcrea As String
	Private m_gestor_feccrea As Date
	Private m_gestor_usrmod As String
	Private m_gestor_fecmod As Date
    '''''Calibres
    Private m_gestor_calibre1 as decimal
    Private m_gestor_pm1 as decimal
    Private m_gestor_aprox1 as decimal
    Private m_gestor_calibre2 as decimal
    Private m_gestor_pm2 as decimal
    Private m_gestor_aprox2 as decimal
    Private m_gestor_calibre3 as decimal
    Private m_gestor_pm3 as decimal
    Private m_gestor_aprox3 as decimal



	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlABAS_GestionOrdenes
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

    Public Property ALMAC_Id() As Short
		Get
			return m_almac_id
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_almac_id) Then
				If Not m_almac_id.Equals(value) Then
					m_almac_id = value
					OnALMAC_IdChanged(m_almac_id, EventArgs.Empty)
				End If
			Else
				m_almac_id = value
				OnALMAC_IdChanged(m_almac_id, EventArgs.Empty)
			End If
		End Set
	End Property

     Public Property ENTID_CodigoEncargado() As String
		Get
			return m_entid_codigoencargado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_entid_codigoencargado) Then
				If Not m_entid_codigoencargado.Equals(value) Then
					m_entid_codigoencargado = value
					OnENTID_CodigoEncargadoChanged(m_entid_codigoencargado, EventArgs.Empty)
				End If
			Else
				m_entid_codigoencargado = value
				OnENTID_CodigoEncargadoChanged(m_entid_codigoencargado, EventArgs.Empty)
			End If
		End Set
	End Property
    

    	Public Property GESTOR_Serie() As String
		Get
			return m_gestor_serie
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_gestor_serie) Then
				If Not m_gestor_serie.Equals(value) Then
					m_gestor_serie = value
					OnGESTOR_SerieChanged(m_gestor_serie, EventArgs.Empty)
				End If
			Else
				m_gestor_serie = value
				OnGESTOR_SerieChanged(m_gestor_serie, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property GESTOR_Numero() As Integer
		Get
			return m_gestor_numero
		End Get
		Set(ByVal value As Integer)
			If Not IsNothing(m_gestor_numero) Then
				If Not m_gestor_numero.Equals(value) Then
					m_gestor_numero = value
					OnGESTOR_NumeroChanged(m_gestor_numero, EventArgs.Empty)
				End If
			Else
				m_gestor_numero = value
				OnGESTOR_NumeroChanged(m_gestor_numero, EventArgs.Empty)
			End If
		End Set
	End Property
    
    Public Property GESTOR_FechaIngreso() As Date
		Get
			return m_gestor_fechaingreso
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_gestor_fechaingreso) Then
				If Not m_gestor_fechaingreso.Equals(value) Then
					m_gestor_fechaingreso = value
					OnGESTOR_FechaIngresoChanged(m_gestor_fechaingreso, EventArgs.Empty)
				End If
			Else
				m_gestor_fechaingreso = value
				OnGESTOR_FechaIngresoChanged(m_gestor_fechaingreso, EventArgs.Empty)
			End If
		End Set
	End Property

    Public Property GESTOR_FecTrans() As Date
		Get
			return m_gestor_fechatransformacion
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_gestor_fechatransformacion) Then
				If Not m_gestor_fechatransformacion.Equals(value) Then
					m_gestor_fechatransformacion = value
					OnGESTOR_FecTransChanged(m_gestor_fechatransformacion, EventArgs.Empty)
				End If
			Else
				m_gestor_fechatransformacion = value
				OnGESTOR_FecTransChanged(m_gestor_fechatransformacion, EventArgs.Empty)
			End If
		End Set
	End Property

    Public Property GESTOR_Lote() As Long
		Get
			return m_gestor_lote
		End Get
		Set(ByVal value As long)
			If Not IsNothing(m_gestor_lote) Then
				If Not m_gestor_lote.Equals(value) Then
					m_gestor_lote = value
					OnGESTOR_LoteChanged(m_gestor_lote, EventArgs.Empty)
				End If
			Else
				m_gestor_lote = value
				OnGESTOR_LoteChanged(m_gestor_lote, EventArgs.Empty)
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
    
    Public Property GESTOR_PesoBruto() As Decimal
		Get
			return m_gestor_pesobruto
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_gestor_pesobruto) Then
				If Not m_gestor_pesobruto.Equals(value) Then
					m_gestor_pesobruto = value
					OnGESTOR_PesoBrutoChanged(m_gestor_pesobruto, EventArgs.Empty)
				End If
			Else
				m_gestor_pesobruto = value
				OnGESTOR_PesoBrutoChanged(m_gestor_pesobruto, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property GESTOR_PesoNeto() As Decimal
		Get
			return m_gestor_pesoneto
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_gestor_pesoneto) Then
				If Not m_gestor_pesoneto.Equals(value) Then
					m_gestor_pesoneto = value
					OnGESTOR_PesoNestoChanged(m_gestor_pesoneto, EventArgs.Empty)
				End If
			Else
				m_gestor_pesoneto = value
				OnGESTOR_PesoNestoChanged(m_gestor_pesoneto, EventArgs.Empty)
			End If
		End Set
	End Property

    Public Property GESTOR_CalcMetros() As Decimal
		Get
			return m_gestor_calcmetros
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_gestor_calcmetros) Then
				If Not m_gestor_calcmetros.Equals(value) Then
					m_gestor_calcmetros = value
					OnGESTOR_CalcMetrosChanged(m_gestor_calcmetros, EventArgs.Empty)
				End If
			Else
				m_gestor_calcmetros = value
				OnGESTOR_CalcMetrosChanged(m_gestor_calcmetros, EventArgs.Empty)
			End If
		End Set
	End Property

    Public Property GESTOR_Observaciones() As String
		Get
			return m_gestor_observaciones
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_gestor_observaciones) Then
				If Not m_gestor_observaciones.Equals(value) Then
					m_gestor_observaciones = value
					OnGESTOR_ObservacionesChanged(m_gestor_observaciones, EventArgs.Empty)
				End If
			Else
				m_gestor_observaciones = value
				OnGESTOR_ObservacionesChanged(m_gestor_observaciones, EventArgs.Empty)
			End If
		End Set
	End Property

     Public Property GESTOR_Estado() As String
		Get
			return m_gestor_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_gestor_estado) Then
				If Not m_gestor_estado.Equals(value) Then
					m_gestor_estado = value
					OnGESTOR_EstadoChanged(m_gestor_estado, EventArgs.Empty)
				End If
			Else
				m_gestor_estado = value
				OnGESTOR_EstadoChanged(m_gestor_estado, EventArgs.Empty)
			End If
		End Set
	End Property

    Public Property GESTOR_EstadoCorte() As String
		Get
			return m_gestor_estadocorte
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_gestor_estadocorte) Then
				If Not m_gestor_estadocorte.Equals(value) Then
					m_gestor_estadocorte = value
					OnGESTOR_EstadoCorteChanged(m_gestor_estadocorte, EventArgs.Empty)
				End If
			Else
				m_gestor_estadocorte = value
				OnGESTOR_EstadoCorteChanged(m_gestor_estadocorte, EventArgs.Empty)
			End If
		End Set
	End Property
      Public Property GESTOR_Calibre1() As Decimal
		Get
			return m_gestor_calibre1
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_gestor_calibre1) Then
				If Not m_gestor_calibre1.Equals(value) Then
					m_gestor_calibre1 = value
					OnGESTOR_Calibre1Changed(m_gestor_calibre1, EventArgs.Empty)
				End If
			Else
				m_gestor_calibre1 = value
				OnGESTOR_Calibre1Changed(m_gestor_calibre1, EventArgs.Empty)
			End If
		End Set
	End Property
      Public Property GESTOR_Calibre2() As Decimal
		Get
			return m_gestor_calibre2
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_gestor_calibre2) Then
				If Not m_gestor_calibre2.Equals(value) Then
					m_gestor_calibre2 = value
					OnGESTOR_Calibre2Changed(m_gestor_calibre2, EventArgs.Empty)
				End If
			Else
				m_gestor_calibre2 = value
				OnGESTOR_Calibre2Changed(m_gestor_calibre2, EventArgs.Empty)
			End If
		End Set
	End Property
    Public Property GESTOR_Calibre3() As Decimal
		Get
			return m_gestor_calibre3
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_gestor_calibre3) Then
				If Not m_gestor_calibre3.Equals(value) Then
					m_gestor_calibre3 = value
					OnGESTOR_Calibre3Changed(m_gestor_calibre3, EventArgs.Empty)
				End If
			Else
				m_gestor_calibre3 = value
				OnGESTOR_Calibre3Changed(m_gestor_calibre3, EventArgs.Empty)
			End If
		End Set
	End Property
     Public Property GESTOR_Pm1() As Decimal
		Get
			return m_gestor_pm1
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_gestor_pm1) Then
				If Not m_gestor_pm1.Equals(value) Then
					m_gestor_pm1 = value
					OnGESTOR_Pm1Changed(m_gestor_pm1, EventArgs.Empty)
				End If
			Else
				m_gestor_pm1 = value
				OnGESTOR_Pm1Changed(m_gestor_pm1, EventArgs.Empty)
			End If
		End Set
	End Property
    Public Property GESTOR_Pm2() As Decimal
		Get
			return m_gestor_pm2
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_gestor_pm2) Then
				If Not m_gestor_pm2.Equals(value) Then
					m_gestor_pm2 = value
					OnGESTOR_Pm2Changed(m_gestor_pm2, EventArgs.Empty)
				End If
			Else
				m_gestor_pm2 = value
				OnGESTOR_Pm2Changed(m_gestor_pm2, EventArgs.Empty)
			End If
		End Set
	End Property
    Public Property GESTOR_Pm3() As Decimal
		Get
			return m_gestor_pm3
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_gestor_pm3) Then
				If Not m_gestor_pm3.Equals(value) Then
					m_gestor_pm3 = value
					OnGESTOR_Pm3Changed(m_gestor_pm3, EventArgs.Empty)
				End If
			Else
				m_gestor_pm3 = value
				OnGESTOR_Pm3Changed(m_gestor_pm3, EventArgs.Empty)
			End If
		End Set
	End Property
     Public Property GESTOR_Aprox1() As Decimal
		Get
			return m_gestor_aprox1
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_gestor_aprox1) Then
				If Not m_gestor_aprox1.Equals(value) Then
					m_gestor_aprox1 = value
					OnGESTOR_Aprox1Changed(m_gestor_aprox1, EventArgs.Empty)
				End If
			Else
				m_gestor_aprox1 = value
				OnGESTOR_Aprox1Changed(m_gestor_aprox1, EventArgs.Empty)
			End If
		End Set
	End Property
       Public Property GESTOR_Aprox2() As Decimal
		Get
			return m_gestor_aprox2
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_gestor_aprox2) Then
				If Not m_gestor_aprox2.Equals(value) Then
					m_gestor_aprox2 = value
					OnGESTOR_Aprox2Changed(m_gestor_aprox2, EventArgs.Empty)
				End If
			Else
				m_gestor_aprox2 = value
				OnGESTOR_Aprox2Changed(m_gestor_aprox2, EventArgs.Empty)
			End If
		End Set
	End Property
      Public Property GESTOR_Aprox3() As Decimal
		Get
			return m_gestor_aprox3
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_gestor_aprox3) Then
				If Not m_gestor_aprox3.Equals(value) Then
					m_gestor_aprox3 = value
					OnGESTOR_Aprox3Changed(m_gestor_aprox3, EventArgs.Empty)
				End If
			Else
				m_gestor_aprox3 = value
				OnGESTOR_Aprox3Changed(m_gestor_aprox3, EventArgs.Empty)
			End If
		End Set
	End Property


	Public Property GESTOR_UsrCrea() As String
		Get
			return m_gestor_usrcrea
		End Get
		Set(ByVal value As String)
			m_gestor_usrcrea = value
		End Set
	End Property

	Public Property GESTOR_FecCrea() As Date
		Get
			return m_gestor_feccrea
		End Get
		Set(ByVal value As Date)
			m_gestor_feccrea = value
		End Set
	End Property

	Public Property GESTOR_UsrMod() As String
		Get
			return m_gestor_usrmod
		End Get
		Set(ByVal value As String)
			m_gestor_usrmod = value
		End Set
	End Property

	Public Property GESTOR_FecMod() As Date
		Get
			return m_gestor_fecmod
		End Get
		Set(ByVal value As Date)
			m_gestor_fecmod = value
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
    Public Event ALMAC_IdChanged as EventHandler
    Public Event GESTOR_SerieChanged as EventHandler
    Public Event ENTID_CodigoEncargadoChanged As EventHandler
	Public Event GESTOR_NumeroChanged As EventHandler
	Public Event GESTOR_FechaIngresoChanged As EventHandler
    Public Event GESTOR_FecTransChanged as EventHandler
    Public Event GESTOR_LoteChanged As EventHandler
    Public Event ARTIC_CodigoChanged As EventHandler
	Public Event GESTOR_PesoBrutoChanged As EventHandler
    Public Event GESTOR_PesoNestoChanged As EventHandler
	Public Event GESTOR_CalcMetrosChanged As EventHandler
	Public Event GESTOR_ObservacionesChanged As EventHandler
	Public Event GESTOR_EstadoChanged As EventHandler
	Public Event GESTOR_EstadoCorteChanged As EventHandler
    Public Event GESTOR_Calibre1Changed as EventHandler
    Public Event GESTOR_Calibre2Changed as EventHandler
    Public Event GESTOR_Calibre3Changed as EventHandler
    Public Event GESTOR_Pm1Changed as EventHandler
    Public Event GESTOR_Pm2Changed as EventHandler
    Public Event GESTOR_Pm3Changed as EventHandler
    Public Event GESTOR_Aprox1Changed as EventHandler
    Public Event GESTOR_Aprox2Changed as EventHandler
    Public Event GESTOR_Aprox3Changed as EventHandler
    

	Public Sub OnGESTOR_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GESTOR_CodigoChanged(sender, e)
	End Sub
    
    Public Sub OnGESTOR_SerieChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GESTOR_SerieChanged(sender, e)
	End Sub
   
    Public Sub OnENTID_CodigoEncargadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoEncargadoChanged(sender, e)
	End Sub
	Public Sub OnGESTOR_NumeroChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GESTOR_NumeroChanged(sender, e)
	End Sub

	Public Sub OnGESTOR_FechaIngresoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GESTOR_FechaIngresoChanged(sender, e)
	End Sub
    
    Public Sub OnGESTOR_FecTransChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GESTOR_FecTransChanged(sender, e)
	End Sub

    Public Sub OnGESTOR_LoteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GESTOR_LoteChanged(sender, e)
	End Sub
    
	Public Sub OnARTIC_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARTIC_CodigoChanged(sender, e)
	End Sub

	Public Sub OnGESTOR_PesoBrutoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GESTOR_PesoBrutoChanged(sender, e)
	End Sub
    
    Public Sub OnGESTOR_PesoNestoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GESTOR_PesoNestoChanged(sender, e)
	End Sub
	Public Sub OnALMAC_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ALMAC_IdChanged(sender, e)
	End Sub
    
	Public Sub OnGESTOR_CalcMetrosChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GESTOR_CalcMetrosChanged(sender, e)
	End Sub

	Public Sub OnGESTOR_ObservacionesChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GESTOR_ObservacionesChanged(sender, e)
	End Sub

	Public Sub OnGESTOR_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GESTOR_EstadoChanged(sender, e)
	End Sub

	Public Sub OnGESTOR_EstadoCorteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GESTOR_EstadoCorteChanged(sender, e)
	End Sub

    Public Sub OnGESTOR_Calibre1Changed(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GESTOR_Calibre1Changed(sender, e)
	End Sub
    Public Sub OnGESTOR_Calibre2Changed(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GESTOR_Calibre2Changed(sender, e)
	End Sub
    Public Sub OnGESTOR_Calibre3Changed(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GESTOR_Calibre3Changed(sender, e)
	End Sub
    Public Sub OnGESTOR_Pm1Changed(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GESTOR_Pm1Changed(sender, e)
	End Sub
    Public Sub OnGESTOR_Pm2Changed(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GESTOR_Pm2Changed(sender, e)
	End Sub
    Public Sub OnGESTOR_Pm3Changed(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GESTOR_Pm3Changed(sender, e)
	End Sub
     Public Sub OnGESTOR_Aprox1Changed(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GESTOR_Aprox1Changed(sender, e)
	End Sub
     Public Sub OnGESTOR_Aprox2Changed(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GESTOR_Aprox2Changed(sender, e)
	End Sub
    Public Sub OnGESTOR_Aprox3Changed(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent GESTOR_Aprox3Changed(sender, e)
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
    Public Shared Function getEstado(ByVal x_opcion As Estado)

      Select Case x_opcion
         Case Estado.Anulado
            Return "X"
         Case Estado.Confirmado
            Return "C"
         Case Estado.Eliminado
            Return "E"
         Case Estado.Ingresado
            Return "I"
         Case Else
            Return "I"
      End Select

   End Function
	Public Sub ActualizarInstancia()
		If Not Nuevo Then
			If Not Eliminado Then
				Instanciar(ACEInstancia.Modificado)
			End If
		End If
	End Sub

#End Region


End Class
