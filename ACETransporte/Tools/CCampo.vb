Public Class CCampo
#Region " Variables "
   Private m_identity As Boolean
   Private m_foreignkey As Boolean
   Private m_primarykey As Boolean
   Private m_nombre As String
#End Region

#Region " Propiedades "

   Public Property Identity() As Boolean
      Get
         Return m_identity
      End Get
      Set(ByVal value As Boolean)
         m_identity = value
      End Set
   End Property

   Public Property ForeignKey() As Boolean
      Get
         Return m_foreignkey
      End Get
      Set(ByVal value As Boolean)
         m_foreignkey = value
      End Set
   End Property

   Public Property PrimaryKey() As Boolean
      Get
         Return m_primarykey
      End Get
      Set(ByVal value As Boolean)
         m_primarykey = value
      End Set
   End Property

   Public Property Nombre() As String
      Get
         Return m_nombre
      End Get
      Set(ByVal value As String)
         m_nombre = value
      End Set
   End Property

#End Region

#Region " Constructores "
   Public Sub New()

   End Sub

   Public Sub New(ByVal x_nombre As String)
      Me.m_foreignkey = False
      Me.m_identity = False
      Me.m_primarykey = False
      Me.Nombre = x_nombre
   End Sub

   Public Sub New(ByVal x_nombre As String, ByVal x_identity As Boolean, ByVal x_foreignkey As Boolean _
                  , ByVal x_primarykey As Boolean)
      Me.m_foreignkey = x_foreignkey
      Me.m_identity = x_identity
      Me.m_primarykey = x_primarykey
      Me.Nombre = x_nombre
   End Sub
#End Region

#Region " Metodos "

#End Region

#Region " Metodos de Controles"

#End Region
End Class
