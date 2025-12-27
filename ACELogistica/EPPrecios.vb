Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports ACFramework

Public Class EPPrecios
    #Region " Campos "
   Private m_lprec_id As Int64
   Private m_lprec_descripcion As String
   Private m_alpre_porcentaventa As Double
   Private m_artic_precioventa As Double
   Private m_preciocalculado As Double
   Private m_nuevo As Boolean
   Private m_modificado As Boolean
   Private m_eliminado As Boolean

    Private m_preciooriginal As Double
    Private m_preciologistica As Double
   Private m_tipos_codtipomoneda As String
   Private m_tipos_tipomoneda As String
   Private m_tipos_tipomonedacorta As String

   Private m_artic_codigo As String

   Private m_orden As Integer

    Private m_preciocalculadosoles As Decimal
   Private m_preciocalculadodolares As String
#End Region

   Public Sub New()
      Try

      Catch ex As Exception
         Throw ex
      End Try
   End Sub

#Region " Propiedades "

   Public Property PrecioCalculadoSoles() As Decimal
      Get
         Return m_preciocalculadosoles
      End Get
      Set(ByVal value As Decimal)
         m_preciocalculadosoles = value
      End Set
    End Property

   Public Property PrecioCalculadoDolares() As Decimal
      Get
         Return m_preciocalculadodolares
      End Get
      Set(ByVal value As Decimal)
         m_preciocalculadodolares = value
      End Set
   End Property

   Public Property LPREC_Id() As Int64
      Get
         Return m_lprec_id
      End Get
      Set(ByVal value As Int64)
         If Not IsNothing(m_lprec_id) Then
            If Not m_lprec_id.Equals(value) Then
               m_lprec_id = value
               OnLPREC_IdChanged(m_lprec_id, EventArgs.Empty)
            End If
         Else
            m_lprec_id = value
            OnLPREC_IdChanged(m_lprec_id, EventArgs.Empty)
         End If
      End Set
   End Property
   Public Property LPREC_Descripcion() As String
      Get
         Return m_lprec_descripcion
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_lprec_descripcion) Then
            If Not m_lprec_descripcion.Equals(value) Then
               m_lprec_descripcion = value
               OnLPREC_DescripcionChanged(m_lprec_descripcion, EventArgs.Empty)
            End If
         Else
            m_lprec_descripcion = value
            OnLPREC_DescripcionChanged(m_lprec_descripcion, EventArgs.Empty)
         End If
      End Set
   End Property
   Public Property ALPRE_PorcentaVenta() As Double
      Get
         Return m_alpre_porcentaventa
      End Get
      Set(ByVal value As Double)
         If Not IsNothing(m_alpre_porcentaventa) Then
            If Not m_alpre_porcentaventa.Equals(value) Then
               m_alpre_porcentaventa = value
               OnALPRE_PorcentaVentaChanged(m_alpre_porcentaventa, EventArgs.Empty)
            End If
         Else
            m_alpre_porcentaventa = value
            OnALPRE_PorcentaVentaChanged(m_alpre_porcentaventa, EventArgs.Empty)
         End If
      End Set
   End Property
   Public Property ARTIC_PrecioVenta() As Double
      Get
         Return m_artic_precioventa
      End Get
      Set(ByVal value As Double)
         If Not IsNothing(m_artic_precioventa) Then
            If Not m_artic_precioventa.Equals(value) Then
               m_artic_precioventa = value
               OnARTIC_PrecioVentaChanged(m_artic_precioventa, EventArgs.Empty)
            End If
         Else
            m_artic_precioventa = value
            OnARTIC_PrecioVentaChanged(m_artic_precioventa, EventArgs.Empty)
         End If
      End Set
   End Property
   Public Property PrecioCalculado() As Double
      Get
         Return m_preciocalculado
      End Get
      Set(ByVal value As Double)
         If Not IsNothing(m_preciocalculado) Then
            If Not m_preciocalculado.Equals(value) Then
               m_preciocalculado = value
               OnPrecioCalculadoChanged(m_preciocalculado, EventArgs.Empty)
            End If
         Else
            m_preciocalculado = value
            OnPrecioCalculadoChanged(m_preciocalculado, EventArgs.Empty)
         End If
      End Set
    End Property
    Public Property PrecioLogistica() As Double
        Get
            Return m_preciologistica
        End Get
        Set(ByVal value As Double)
            If Not IsNothing(m_preciologistica) Then
                If Not m_preciologistica.Equals(value) Then
                    m_preciologistica = value
                    OnPrecioLogisticaChanged(m_preciologistica, EventArgs.Empty)
                End If
            Else
                m_preciologistica = value
                OnPrecioLogisticaChanged(m_preciologistica, EventArgs.Empty)
            End If
        End Set
    End Property
   Public Property PrecioOriginal() As Double
      Get
         Return m_preciooriginal
      End Get
      Set(ByVal value As Double)
         m_preciooriginal = value
      End Set
   End Property
   Public Property TIPOS_CodTipoMoneda() As String
      Get
         Return m_tipos_codtipomoneda
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_codtipomoneda) Then
            If Not m_tipos_codtipomoneda.Equals(value) Then
               m_tipos_codtipomoneda = value
            End If
         Else
            m_tipos_codtipomoneda = value
         End If
      End Set
   End Property
   Public Property TIPOS_TipoMoneda() As String
      Get
         Return m_tipos_tipomoneda
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_tipomoneda) Then
            If Not m_tipos_tipomoneda.Equals(value) Then
               m_tipos_tipomoneda = value
            End If
         Else
            m_tipos_tipomoneda = value
         End If
      End Set
   End Property
   Public Property TIPOS_TipoMonedaCorta() As String
      Get
         Return m_tipos_tipomonedacorta
      End Get
      Set(ByVal value As String)
         If Not IsNothing(m_tipos_tipomonedacorta) Then
            If Not m_tipos_tipomonedacorta.Equals(value) Then
               m_tipos_tipomonedacorta = value
            End If
         Else
            m_tipos_tipomonedacorta = value
         End If
      End Set
   End Property
   Public Property Orden() As Integer
      Get
         Return m_orden
      End Get
      Set(ByVal value As Integer)
         m_orden = value
      End Set
   End Property

   Public Property ARTIC_Codigo() As String
      Get
         Return m_artic_codigo
      End Get
      Set(ByVal value As String)
         m_artic_codigo = value
      End Set
   End Property


   Public ReadOnly Property Nuevo() As Boolean
      Get
         Return m_nuevo
      End Get
   End Property
   Public ReadOnly Property Modificado() As Boolean
      Get
         Return m_modificado
      End Get
   End Property
   Public ReadOnly Property Eliminado() As Boolean
      Get
         Return m_eliminado
      End Get
   End Property

#End Region

   Public Event LPREC_IdChanged As EventHandler
   Public Event LPREC_DescripcionChanged As EventHandler
   Public Event ALPRE_PorcentaVentaChanged As EventHandler
   Public Event ARTIC_PrecioVentaChanged As EventHandler
    Public Event PrecioCalculadoChanged As EventHandler
    Public Event PrecioLogisticaChanged As EventHandler
   Public Sub OnLPREC_IdChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent LPREC_IdChanged(sender, e)
   End Sub
   Public Sub OnLPREC_DescripcionChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent LPREC_DescripcionChanged(sender, e)
   End Sub
   Public Sub OnALPRE_PorcentaVentaChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent ALPRE_PorcentaVentaChanged(sender, e)
   End Sub
   Public Sub OnARTIC_PrecioVentaChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent ARTIC_PrecioVentaChanged(sender, e)
   End Sub
   Public Sub OnPrecioCalculadoChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent PrecioCalculadoChanged(sender, e)
    End Sub
    Public Sub OnPrecioLogisticaChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent PrecioLogisticaChanged(sender, e)
    End Sub

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
End Class
