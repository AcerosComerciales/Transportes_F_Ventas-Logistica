Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Public Class EABAS_PedidoTransformacionDetalle
   #Region " Campos "
   Private m_artic_descripcion As String
   Private m_tipos_unidadmedida As String
   Private m_codigo As String
   Private m_titulo As String
   Private m_pesounitario As Decimal
   Private m_entregado As Decimal
   Private m_diferencia As Decimal
   Private m_docvd_cantidad As Decimal
   Private m_tipos_codunidadmedida As String
   Private m_stockdestino As Decimal
   Private m_faltante As Decimal
   Private m_almacen As String
   Private m_peso as Decimal
   Private m_desencargado As String
   Private m_observacion As string
   Private m_estado As string
   Private m_estadotext As string
#End Region

#Region" Constructores "
	
#End Region

#Region" Propiedades "

   Public Property ARTIC_Descripcion() As String
      Get
         Return m_artic_descripcion
      End Get
      Set(ByVal value As String)
         m_artic_descripcion = value
      End Set
   End Property
    Public Property PEDID_Observaciones() As String
      Get
         Return m_observacion
      End Get
      Set(ByVal value As String)
         m_observacion = value
      End Set
   End Property
     Public Property ALMAC_Descripcion() As String
      Get
         Return m_almacen
      End Get
      Set(ByVal value As String)
         m_almacen = value
      End Set
   End Property
     Public Property PEDID_PesoTotal() As Decimal
      Get
         Return m_peso
      End Get
      Set(ByVal value As Decimal)
         m_peso = value
      End Set
   End Property

    Public Property PEDID_DescripcionEncargado() As String
      Get
         Return m_desencargado
      End Get
      Set(ByVal value As String)
         m_desencargado = value
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
      Public Property Titulo() As String
      Get
         Return m_titulo
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_titulo) Then
            If Not m_titulo.Equals(value) Then
               m_titulo = value
            End If
         Else
            m_titulo = value
         End If
      End Set
   End Property
  
   Public Property TIPOS_UnidadMedida() As String
      Get
         Return m_tipos_unidadmedida
      End Get
      Set(ByVal value As String)
         m_tipos_unidadmedida = value
      End Set
   End Property

   Public Property PesoUnitario() As Decimal
      Get
         Return m_pesounitario
      End Get
      Set(ByVal value As Decimal)
         m_pesounitario = value
      End Set
   End Property

   Public Property Diferencia() As Decimal
      Get
         Return m_diferencia
      End Get
      Set(ByVal value As Decimal)
         m_diferencia = value
      End Set
   End Property

    Public Property faltante() As Decimal
      Get
         Return m_faltante
      End Get
      Set(ByVal value As Decimal)
         m_faltante = value
      End Set
   End Property

   Public Property Entregado() As Decimal
      Get
         Return m_entregado
      End Get
      Set(ByVal value As Decimal)
         m_entregado = value
      End Set
   End Property

   Public Property DOCVD_Cantidad() As Decimal
      Get
         Return m_docvd_cantidad
      End Get
      Set(ByVal value As Decimal)
         m_docvd_cantidad = value
      End Set
   End Property

   Public Property TIPOS_CodUnidadMedida() As String
      Get
         Return m_tipos_codunidadmedida
      End Get
      Set(ByVal value As String)
         m_tipos_codunidadmedida = value
      End Set
   End Property

   Public Property StockDestino() As Decimal
      Get
         Return m_stockdestino
      End Get
      Set(ByVal value As Decimal)
         m_stockdestino = value
      End Set
   End Property


    Public Property PEDID_Estado() As String
     Get
         Return m_estado
      End Get
      Set(ByVal value As String)
         m_estado = value
      End Set
    End Property

    Public Property CANTIDAD() As Decimal
     Get
         Return m_pedid_faltante
      End Get
      Set(ByVal value As Decimal)
         m_pedid_faltante = value
      End Set
    End Property

    Public Property Saldo() As Decimal
     Get
         Return m_saldo
      End Get
      Set(ByVal value As Decimal)
         m_saldo = value
      End Set
    End Property

    


     Public ReadOnly Property PEDID_Estado_Text() As String
     Get
        Select Case m_estado
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


#End Region

#Region " Eventos "
	
#End Region

#Region " Metodos "
	
#End Region
End Class


Partial Public Class EABAS_PedidoTransformacionDetalle
 
#Region " Campos "
	
	Private m_pedid_codigoTrans As String
	Private m_pedid_item As Short
    Private m_artic_codigo As String
	Private m_pedid_cantidad As Decimal
    Private m_pedid_pesounitario As Decimal
	Private m_pedid_lote As short
	Private m_pedid_usrcrea As String
	Private m_pedid_feccrea As Date
	Private m_pedid_usrmod As String
	Private m_pedid_fecmod As Date
	Private m_pedid_faltante As Decimal
    Private m_saldo As Decimal
	Private m_pedid_loteGeneral As short
	Private m_pedid_referencia As string
    Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACEVentas.My.Resources.xmlABAS_PedidoTransformacionDetalle
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
	
	Public Property PEDID_CodigoTrans() As String
		Get
			return m_pedid_codigoTrans
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pedid_codigoTrans) Then
				If Not m_pedid_codigoTrans.Equals(value) Then
					m_pedid_codigoTrans = value
					OnPEDID_CodigoTransChanged(m_pedid_codigoTrans, EventArgs.Empty)
				End If
			Else
				m_pedid_codigoTrans = value
				OnPEDID_CodigoTransChanged(m_pedid_codigoTrans, EventArgs.Empty)
			End If
		End Set
	End Property
       Public ReadOnly Property SubPeso() As Decimal
      Get
         Return Math.Round(m_pedid_cantidad * m_pedid_pesounitario,0)
      End Get
   End Property

	Public Property PEDID_Item() As Short
		Get
			return m_pedid_item
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_pedid_item) Then
				If Not m_pedid_item.Equals(value) Then
					m_pedid_item = value
					OnPEDID_ItemChanged(m_pedid_item, EventArgs.Empty)
				End If
			Else
				m_pedid_item = value
				OnPEDID_ItemChanged(m_pedid_item, EventArgs.Empty)
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

	Public Property PEDID_Cantidad() As Decimal
		Get
			return m_pedid_cantidad
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_pedid_cantidad) Then
				If Not m_pedid_cantidad.Equals(value) Then
					m_pedid_cantidad = value
					OnPEDID_CantidadChanged(m_pedid_cantidad, EventArgs.Empty)
				End If
			Else
				m_pedid_cantidad = value
				OnPEDID_CantidadChanged(m_pedid_cantidad, EventArgs.Empty)
			End If
		End Set
	End Property
    
    Public Property PEDID_PesoUnitario() As Decimal
		Get
			return m_pedid_pesounitario
		End Get
		Set(ByVal value As Decimal)
			If Not IsNothing(m_pedid_pesounitario) Then
				If Not m_pedid_pesounitario.Equals(value) Then
					m_pedid_pesounitario = value
					OnPEDID_PesoUnitarioChanged(m_pedid_pesounitario, EventArgs.Empty)
				End If
			Else
				m_pedid_pesounitario = value
				OnPEDID_PesoUnitarioChanged(m_pedid_pesounitario, EventArgs.Empty)
			End If
		End Set
	End Property
    Public Property PEDID_Lote() As Short
		Get
			return m_pedid_lote
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_pedid_lote) Then
				If Not m_pedid_lote.Equals(value) Then
					m_pedid_lote = value
					OnPEDID_LoteChanged(m_pedid_lote, EventArgs.Empty)
				End If
			Else
				m_pedid_lote = value
				OnPEDID_LoteChanged(m_pedid_lote, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_UsrCrea() As String
		Get
			return m_pedid_usrcrea
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pedid_usrcrea) Then
				If Not m_pedid_usrcrea.Equals(value) Then
					m_pedid_usrcrea = value
					OnPEDID_UsrCreaChanged(m_pedid_usrcrea, EventArgs.Empty)
				End If
			Else
				m_pedid_usrcrea = value
				OnPEDID_UsrCreaChanged(m_pedid_usrcrea, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PEDID_FecCrea() As Date
		Get
			return m_pedid_feccrea
		End Get
		Set(ByVal value As Date)
			If Not IsNothing(m_pedid_feccrea) Then
				If Not m_pedid_feccrea.Equals(value) Then
					m_pedid_feccrea = value
					OnPEDID_FecCreaChanged(m_pedid_feccrea, EventArgs.Empty)
				End If
			Else
				m_pedid_feccrea = value
				OnPEDID_FecCreaChanged(m_pedid_feccrea, EventArgs.Empty)
			End If
		End Set
	End Property
      Public Property PEDID_LoteGeneral() As short
		Get
			return m_pedid_loteGeneral
		End Get
		Set(ByVal value As short)
			If Not IsNothing(m_pedid_loteGeneral) Then
				If Not m_pedid_loteGeneral.Equals(value) Then
					m_pedid_loteGeneral = value
					OnPEDID_LoteGeneralChanged(m_pedid_loteGeneral, EventArgs.Empty)
				End If
			Else
				m_pedid_loteGeneral = value
				OnPEDID_LoteGeneralChanged(m_pedid_loteGeneral, EventArgs.Empty)
			End If
		End Set
	End Property

    Public Property PEDID_Referencia() As String
		Get
			return m_pedid_referencia
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_pedid_referencia) Then
				If Not m_pedid_referencia.Equals(value) Then
					m_pedid_referencia = value
					OnPEDID_ReferenciaChanged(m_pedid_referencia, EventArgs.Empty)
				End If
			Else
				m_pedid_referencia = value
				OnPEDID_ReferenciaChanged(m_pedid_referencia, EventArgs.Empty)
			End If
		End Set
	End Property


	Public Property PEDID_UsrMod() As String
		Get
			return m_pedid_usrmod
		End Get
		Set(ByVal value As String)
			m_pedid_usrmod = value
		End Set
	End Property

	Public Property PEDID_FecMod() As Date
		Get
			return m_pedid_fecmod
		End Get
		Set(ByVal value As Date)
			m_pedid_fecmod = value
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
			Return "DIST_OrdenesDetalle"
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
	
	Public Event PEDID_CodigoTransChanged As EventHandler
	Public Event PEDID_ItemChanged As EventHandler
    Public Event ORDET_ItemDocumentoChanged As EventHandler
	Public Event ARTIC_CodigoChanged As EventHandler
	Public Event PEDID_CantidadChanged As EventHandler
    Public Event PEDID_PesoUnitarioChanged As EventHandler
    Public Event PEDID_LoteChanged As EventHandler
	Public Event PEDID_UsrCreaChanged As EventHandler
	Public Event PEDID_FecCreaChanged As EventHandler
    Public Event PEDID_LoteGeneralChanged As EventHandler
    Public Event PEDID_ReferenciaChanged As EventHandler

	Public Sub OnPEDID_CodigoTransChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_CodigoTransChanged(sender, e)
	End Sub

	Public Sub OnPEDID_ItemChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_ItemChanged(sender, e)
	End Sub
   
	Public Sub OnARTIC_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ARTIC_CodigoChanged(sender, e)
	End Sub

	Public Sub OnPEDID_CantidadChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_CantidadChanged(sender, e)
	End Sub
    Public Sub OnPEDID_PesoUnitarioChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_PesoUnitarioChanged(sender, e)
	End Sub
    
    Public Sub OnPEDID_LoteGeneralChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_LoteGeneralChanged(sender, e)
	End Sub
    Public Sub OnPEDID_LoteChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_LoteChanged(sender, e)
	End Sub
    
    Public Sub OnPEDID_UsrCreaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_UsrCreaChanged(sender, e)
	End Sub

	Public Sub OnPEDID_FecCreaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_FecCreaChanged(sender, e)
	End Sub
    
    Public Sub OnPEDID_ReferenciaChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent PEDID_ReferenciaChanged(sender, e)
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
