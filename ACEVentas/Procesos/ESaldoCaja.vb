Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Public Class ESaldoCaja

#Region " Campos "

   Private m_saldo As Decimal
   Private m_saldoinicial As Decimal
   Private m_ingreso As Decimal
   Private m_egreso As Decimal
   Private m_nuevo As Boolean
   Private m_modificado As Boolean
   Private m_eliminado As Boolean

   Private m_hash As Hashtable

   Private m_saldoinicialdol As Decimal
   Private m_saldodol As Decimal
   Private m_m_ingresodol As Decimal
   Private m_egresodol As Decimal
#End Region

#Region " Constructores "

   Public Sub New()

      Try

      Catch ex As Exception
         Throw ex
      End Try
   End Sub

#End Region

#Region " Propiedades "


   Public Property Saldo() As Decimal
      Get
         Return m_saldo
      End Get
      Set(ByVal value As Decimal)
         m_saldo = value
      End Set
   End Property

   Public Property SaldoInicial() As Decimal
      Get
         Return m_saldoinicial
      End Get
      Set(ByVal value As Decimal)
         If Not IsNothing(m_saldoinicial) Then
            If Not m_saldoinicial.Equals(value) Then
               m_saldoinicial = value
               OnFLETE_TotIngresoChanged(m_saldoinicial, EventArgs.Empty)
            End If
         Else
            m_saldoinicial = value
            OnFLETE_TotIngresoChanged(m_saldoinicial, EventArgs.Empty)
         End If
      End Set
   End Property
   Public Property Ingreso() As Decimal
      Get
         Return m_ingreso
      End Get
      Set(ByVal value As Decimal)
         If Not IsNothing(m_ingreso) Then
            If Not m_ingreso.Equals(value) Then
               m_ingreso = value
               OnIngresoChanged(m_ingreso, EventArgs.Empty)
            End If
         Else
            m_ingreso = value
            OnIngresoChanged(m_ingreso, EventArgs.Empty)
         End If
      End Set
   End Property
   Public Property Egreso() As Decimal
      Get
         Return m_egreso
      End Get
      Set(ByVal value As Decimal)
         If Not IsNothing(m_egreso) Then
            If Not m_egreso.Equals(value) Then
               m_egreso = value
               OnEgresoChanged(m_egreso, EventArgs.Empty)
            End If
         Else
            m_egreso = value
            OnEgresoChanged(m_egreso, EventArgs.Empty)
         End If
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
   Public ReadOnly Property Hash() As Hashtable
      Get
         Return m_hash
      End Get
   End Property
   Public Shared ReadOnly Property Tabla() As String
      Get
         Return "SaldoCaja"
      End Get
   End Property
   Public Shared ReadOnly Property Esquema() As String
      Get
         Return ""
      End Get
   End Property

   Public Property SaldoInicialDol() As Decimal
      Get
         Return m_saldoinicialdol
      End Get
      Set(ByVal value As Decimal)
         m_saldoinicialdol = value
      End Set
   End Property

   Public Property SaldoDol() As Decimal
      Get
         Return m_saldodol
      End Get
      Set(ByVal value As Decimal)
         m_saldodol = value
      End Set
   End Property

   Public Property IngresoDol() As Decimal
      Get
         Return m_m_ingresodol
      End Get
      Set(ByVal value As Decimal)
         m_m_ingresodol = value
      End Set
   End Property

   Public Property EgresoDol() As Decimal
      Get
         Return m_egresodol
      End Get
      Set(ByVal value As Decimal)
         m_egresodol = value
      End Set
   End Property

#End Region

#Region " Eventos "

   Public Event FLETE_TotIngresoChanged As EventHandler
   Public Event IngresoChanged As EventHandler
   Public Event EgresoChanged As EventHandler
   Public Sub OnFLETE_TotIngresoChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent FLETE_TotIngresoChanged(sender, e)
   End Sub
   Public Sub OnIngresoChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent IngresoChanged(sender, e)
   End Sub
   Public Sub OnEgresoChanged(ByVal sender As Object, ByVal e As EventArgs)
      ActualizarInstancia()
      RaiseEvent EgresoChanged(sender, e)
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
