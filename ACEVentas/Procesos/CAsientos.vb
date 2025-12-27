Public Class CAsientos

#Region " Variables "
   Private m_cuenta As String
   Private m_descripcion As String
   Private m_glosa As String
   Private m_cargo As Decimal
   Private m_abono As Decimal
   Private m_documento As String
   Private m_registro As Integer
#End Region

#Region " Propiedades "

   Public Property Cuenta() As String
      Get
         Return m_cuenta
      End Get
      Set(ByVal value As String)
         m_cuenta = value
      End Set
   End Property

   Public Property Descripcion() As String
      Get
         Return m_descripcion
      End Get
      Set(ByVal value As String)
         m_descripcion = value
      End Set
   End Property

   Public Property Glosa() As String
      Get
         Return m_glosa
      End Get
      Set(ByVal value As String)
         m_glosa = value
      End Set
   End Property

   Public Property Cargo() As Decimal
      Get
         Return m_cargo
      End Get
      Set(ByVal value As Decimal)
         m_cargo = value
      End Set
   End Property

   Public Property Abono() As Decimal
      Get
         Return m_abono
      End Get
      Set(ByVal value As Decimal)
         m_abono = value
      End Set
   End Property

   Public Property Documento() As String
      Get
         Return m_documento
      End Get
      Set(ByVal value As String)
         m_documento = value
      End Set
   End Property

   Public Property Registro() As Integer
      Get
         Return m_registro
      End Get
      Set(ByVal value As Integer)
         m_registro = value
      End Set
   End Property

#End Region

#Region " Constructores "
   Public Sub New()

   End Sub

   Public Sub New(ByVal x_cuenta As String, ByVal x_descripcion As String, ByVal x_glosa As String, ByVal x_cargo As Decimal, ByVal x_abono As Decimal, ByVal x_documento As String, ByVal x_registro As Integer)
      m_cuenta = x_cuenta
      m_descripcion = x_descripcion
      m_glosa = x_glosa
      m_cargo = x_cargo
      m_abono = x_abono
      m_documento = x_documento
      m_registro = x_registro
   End Sub
#End Region

#Region " Metodos "

#End Region

#Region " Metodos de Controles"

#End Region

End Class
