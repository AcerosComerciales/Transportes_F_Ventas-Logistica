Imports ACETransporte
Imports ACBTransporte

Imports ACSeguridad
Imports ACBVentas
Imports ACEVentas

'Imports NSSeguridad

Public Class GApp
   Private Shared m_mutex As New System.Threading.Mutex
   Private Shared m_instance As GApp = Nothing

   Private Shared m_coperativo As String
   Private Shared m_CodUsuario As String
   Private Shared m_sucursal As Int64 = 1
   Private Shared m_NomUsuario As String = "DEFAULT"
   Private Shared m_FechaProceso As Date = Date.Now
   Private Shared m_FechaServidor As Date
   Private Shared m_FechaVenta As Date
   Private Shared m_DireSucursal As String

   Private Shared m_ezona As EZonas
   Private Shared m_esucursal As ESucursales
   Private Shared m_epuntoventa As EPuntoVenta

   Private Shared m_aplicacion As String
   Private Shared m_empresa As String
   Private Shared m_periodo As String

   Private Shared m_servidor As String
   Private Shared m_basedatos As String
   Private Shared m_basedatos_admin As String
   Private Shared m_user_sql As String
   Private Shared m_pass_sql As String

   Private Shared managerBEntidades As BEntidades
   Private Shared m_eusuario As EEntidades
   Private Shared m_dataconexion As ACDataConexion
   Private Shared m_datausuario As ACDataUsuario
   Private Shared m_adminusuario As EUsuarios

   Private Shared m_log_existe As Boolean

   Private Shared m_ealmacen As EAlmacenes

   Private Shared m_eempresa As EEmpresas

#Region " Constructor Privado "
   Private Sub New()

   End Sub
#End Region

#Region " Constructor Singleton "
   Public Shared Function Inicializar(ByVal x_codusuario As String, Optional ByVal Forzar As Boolean = False) As GApp
      m_mutex.WaitOne()
      Try
         If m_instance Is Nothing Or Forzar Then
            m_instance = New GApp()
         End If
         m_CodUsuario = x_codusuario
      Catch ex As Exception
         Return Nothing
      Finally
         m_mutex.ReleaseMutex()
      End Try
      Return m_instance
   End Function

   Public Shared Function Inicializar(ByVal x_empresa As String, ByVal x_aplicacion As String _
                                    , ByVal x_codusuario As String, ByVal x_servidor As String _
                                    , ByVal x_basedatos As String, ByVal x_basedatos_admin As String _
                                    , ByVal x_usersql As String, ByVal x_passsql As String _
                                    , Optional ByVal Forzar As Boolean = False) As GApp
      m_mutex.WaitOne()
      Try
         If m_instance Is Nothing Or Forzar Then
            m_instance = New GApp()
         End If
         m_empresa = x_empresa
         m_aplicacion = x_aplicacion
         m_CodUsuario = x_codusuario
         m_servidor = x_servidor
         m_basedatos = x_basedatos
         m_basedatos_admin = x_basedatos_admin
         m_user_sql = x_usersql
         m_pass_sql = x_passsql

         m_log_existe = cargarUsuario(m_CodUsuario)

         ' Inicializar datos para la validacion de contraseña
         m_dataconexion = New ACDataConexion()
         m_dataconexion.BaseDatos = x_basedatos_admin
         m_dataconexion.Servidor = x_servidor
         m_dataconexion.UsuarioBD = x_usersql
         m_dataconexion.PasswordBD = x_passsql
         m_dataconexion.Algoritmo = ACTypeAlgorithm.csAlgorithmPassMd5New
         '' Cargar Usuario de la base de Administracion
         Dim x_usuario As New ACLoadUsers(m_dataconexion)
         x_usuario.Cargar(GApp.Usuario)
         m_adminusuario = x_usuario.Usuario
         '' Inicializar datos del usuario que se esta conectando
         m_datausuario = New ACDataUsuario()
         m_datausuario.APLI_Codigo = x_aplicacion
         m_datausuario.EMPR_Codigo = x_empresa
         m_datausuario.USER_IdUser = m_adminusuario.USER_IdUser
         m_datausuario.USER_CodUsr = m_adminusuario.USER_CodUsr
         m_datausuario.USER_DNI = m_adminusuario.USER_DNI
         '' Cargar el periodo
         cargarPeriodo()
      Catch ex As Exception
         Return Nothing
      Finally
         m_mutex.ReleaseMutex()
      End Try
      Return m_instance
   End Function

   Private Shared Sub cargarPeriodo()
      Try
         Dim managerPeriodos As New BPeriodos
         Dim _where As New Hashtable()
         _where.Add("PERIO_StockActivo", New ACFramework.ACWhere(True))
         If managerPeriodos.Cargar(_where) Then
            m_periodo = managerPeriodos.Periodos.PERIO_Codigo
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Shared Function cargarUsuario(ByVal x_usuario As String) As Boolean
      Try
         managerBEntidades = New BEntidades
         Dim _where As New Hashtable() : _where.Add("USUAR_Codigo", New ACFramework.ACWhere(x_usuario))
         Dim _existe As Boolean = managerBEntidades.Cargar(_where)
         EUsuarioEntidad = managerBEntidades.Entidades
         Return _existe
      Catch ex As Exception
         Throw ex
      End Try
   End Function


   Public Shared Function Inicializar(ByVal x_sucr_codigo As String, ByVal x_fechaProceso As Date, ByVal x_sucursal As ESucursales) As GApp
      m_mutex.WaitOne()
      Try
         If Not IsNothing(m_instance) Then
            m_sucursal = x_sucr_codigo
            m_FechaProceso = x_fechaProceso
            m_esucursal = x_sucursal
         End If
      Catch ex As Exception
         Return Nothing
      Finally
         m_mutex.ReleaseMutex()
      End Try
      Return m_instance
   End Function

   Public Shared Sub SetValoresEntorno()
      Try

      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Public Shared Sub SetSucursal(ByVal _sucursal As ESucursales, ByVal x_fecha As DateTime)
      m_esucursal = _sucursal
      m_FechaProceso = x_fecha
   End Sub

   Public Shared Sub SetBase(ByVal _zona As EZonas, ByVal _sucursal As ESucursales, ByVal x_fecha As DateTime)
      m_esucursal = _sucursal
      m_FechaProceso = x_fecha
      m_ezona = _zona
   End Sub

   Public Shared Sub SetBase(ByVal _zona As EZonas, ByVal _sucursal As ESucursales, ByVal _puntoventa As EPuntoVenta, ByVal x_fecha As DateTime)
      m_esucursal = _sucursal
      m_FechaProceso = x_fecha
      m_ezona = _zona
      m_epuntoventa = _puntoventa
   End Sub

   Public Shared Sub SetBase(ByVal _zona As EZonas, ByVal _sucursal As ESucursales, ByVal _almacen As EAlmacenes, ByVal x_fecha As DateTime)
      m_esucursal = _sucursal
      m_FechaProceso = x_fecha
      m_ezona = _zona
      m_ealmacen = _almacen
   End Sub

   Public Shared Sub SetEmpresa(ByVal _empresa As EEmpresas)
      m_eempresa = _empresa
   End Sub
#End Region

#Region " Path Generales "

   Public Shared ReadOnly Property Path_Plantillas() As String
      Get
         Return System.IO.Path.Combine(Application.StartupPath, "Plantillas")
      End Get
   End Property

#End Region

#Region " Propiedades Generales "

   Public Shared Property EUsuarioEntidad() As EEntidades
      Get
         Return m_eusuario
      End Get
      Set(ByVal value As EEntidades)
         m_eusuario = value
      End Set
   End Property

   Public Shared ReadOnly Property DataConexion() As ACDataConexion
      Get
         Return m_dataconexion
      End Get
   End Property

   Public Shared ReadOnly Property DataUsuario() As ACDataUsuario
      Get
         Return m_datausuario
      End Get
   End Property

   Public Shared Property LogExiste() As Boolean
      Get
         Return m_log_existe
      End Get
      Set(ByVal value As Boolean)
         m_log_existe = value
      End Set
   End Property

   Public Shared ReadOnly Property Sucursal() As Short
      Get
         Return m_esucursal.SUCUR_Id
      End Get
   End Property

   Public Shared ReadOnly Property ESucursal() As ESucursales
      Get
         Return m_esucursal
      End Get
   End Property

   Public Shared ReadOnly Property EZona() As EZonas
      Get
         Return m_ezona
      End Get
   End Property

   Public Shared ReadOnly Property Zona() As String
      Get
         Return m_ezona.ZONAS_Codigo
      End Get
   End Property

   Public Shared ReadOnly Property DirecSucursal() As String
      Get
         Return m_DireSucursal
      End Get
   End Property

   Public Shared ReadOnly Property Usuario() As String
      Get
         Return m_CodUsuario
      End Get
   End Property

   Public Shared ReadOnly Property EUsuario() As EUsuarios
      Get
         Return m_adminusuario
      End Get
   End Property


   Public Shared ReadOnly Property UsuarioNombre() As String
      Get
         Return m_NomUsuario
      End Get
   End Property

   Public Shared ReadOnly Property FechaProceso() As Date
      Get
         Return m_FechaProceso.Date
      End Get
    End Property

    Public Shared ReadOnly Property Almacen() As Short
        Get
            Return m_ealmacen.ALMAC_Id
        End Get
    End Property

    Public Shared ReadOnly Property PuntoVenta() As Long
        Get
            Return m_epuntoventa.PVENT_Id
        End Get
   End Property

   Public Shared ReadOnly Property EPuntoVenta() As EPuntoVenta
      Get
         Return m_epuntoventa
      End Get
   End Property

   Public Shared ReadOnly Property EmpresaRUC() As String
      Get
         Return m_eempresa.EMPR_RUC
      End Get
   End Property

   Public Shared ReadOnly Property EmpresaCodigo() As String
      Get
         Return m_eempresa.EMPR_Codigo
      End Get
   End Property

   Public Shared ReadOnly Property Periodo() As String
      Get
         Return m_periodo
      End Get
   End Property

#End Region

#Region " Propiedades Aplicacion - Empresa "
   Public Shared ReadOnly Property Aplicacion() As String
      Get
         Return m_aplicacion
      End Get
   End Property
   Public Shared ReadOnly Property Empresa() As String
      Get
         Return m_empresa
      End Get
   End Property

   Public Shared ReadOnly Property EEmpresa() As EEmpresas
      Get
         Return m_eempresa
      End Get
   End Property

#End Region

#Region " Propiedades Coneccion "
   Public Shared ReadOnly Property Servidor() As String
      Get
         Return m_servidor
      End Get
   End Property
   Public Shared ReadOnly Property BaseDatos() As String
      Get
         Return m_basedatos
      End Get
   End Property
   Public Shared ReadOnly Property BaseDatosAdmin() As String
      Get
         Return m_basedatos_admin
      End Get
   End Property
   Public Shared ReadOnly Property UserSql() As String
      Get
         Return m_user_sql
      End Get
   End Property
   Public Shared ReadOnly Property PasswordSql() As String
      Get
         Return m_pass_sql
      End Get
   End Property
#End Region

End Class