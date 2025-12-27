Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACEVentas
Imports ACDVentas
Imports System.Configuration
Imports ACEVentas.EUtilitarios
Imports DAConexion
Imports ACFramework

Public Class BEntidades

#Region " Variables "
   Private m_ListEliDirecciones As List(Of EDirecciones)
   Private m_ListEliTelefonos As List(Of ETelefonos)
   Private m_inicio As EEntidades.TipoInicializacion

   Private m_ecliente As EClientes
   Private m_eproveedor As EProveedores
   Private m_econductor As EConductores
    Private m_vendedores As List(Of EEntidades)
    Private m_cotizadores As List(Of EEntidades)
   Private m_proveedores As List(Of EEntidades)

#End Region

#Region " Constructores "

#End Region

#Region " Propiedades "

   Public Property Cliente() As EClientes
      Get
         Return m_ecliente
      End Get
      Set(ByVal value As EClientes)
         m_ecliente = value
      End Set
   End Property

   Public Property Vendedores() As List(Of EEntidades)
      Get
         Return m_vendedores
      End Get
      Set(ByVal value As List(Of EEntidades))
         m_vendedores = value
      End Set
    End Property
    Public Property Cotizadores() As List(Of EEntidades)
        Get
            Return m_cotizadores
        End Get
        Set(ByVal value As List(Of EEntidades))
            m_cotizadores = value
        End Set
    End Property


   Public Property Proveedor() As EProveedores
      Get
         Return m_eproveedor
      End Get
      Set(ByVal value As EProveedores)
         m_eproveedor = value
      End Set
   End Property


#End Region

#Region " Funciones para obtencion de datos "
   Public Sub setListEliDirecciones(ByVal _listEliDirecciones As List(Of EDirecciones))
      m_ListEliDirecciones = _listEliDirecciones
   End Sub

   Public Sub setListEliTelefonos(ByVal _listEliTelefonos As List(Of ETelefonos))
      m_ListEliTelefonos = _listEliTelefonos
   End Sub
#End Region

#Region " Metodos "

   ''' <summary>
   ''' carhar la entidad, segun el tipo de inicializacion
   ''' </summary>
   ''' <param name="x_entid_codigo">codigo de la entidad</param>
   ''' <param name="x_inicio">tipo de inicializacion</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
    Public Function Cargar(ByVal x_entid_codigo As String, ByVal x_inicio As EEntidades.TipoInicializacion) As Boolean
        m_inicio = x_inicio
        Try
            m_entidades = New EEntidades()
            Dim _join As New List(Of ACJoin)
            _join.Add(New ACJoin(EUbigeos.Esquema, EUbigeos.Tabla, ACJoin.TipoJoin.Left _
                                 , New ACCampos() {New ACCampos("UBIGO_Codigo", "UBIGO_Codigo")} _
                                 , New ACCampos() {New ACCampos("UBIGO_Descripcion", "UBIGO_Descripcion")}))
            Dim _where As New Hashtable()
            _where.Add("ENTID_Codigo", New ACWhere(x_entid_codigo))
            If Cargar(_join, _where) Then
                setAdicionales(m_entidades.ENTID_Codigo)
                If x_inicio = EEntidades.TipoInicializacion.Direcciones Then
                    m_entidades.ENTID_Direccion = ENTISS_ObtenerDireccion(x_entid_codigo)
                    End If
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
   

   ''' <summary>
   ''' cargar la entidad por el numero de documento
   ''' </summary>
   ''' <param name="x_entid_nrodocumento">numero del documento de identidad</param>
   ''' <param name="x_inicio">tipo de inicio para la carga de informacion de la entidad</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
    Public Function CargarDocIden(ByVal x_entid_nrodocumento As String, ByVal x_inicio As EEntidades.TipoInicializacion) As Boolean 'x_entid_nrodocumento
        m_inicio = x_inicio
        Try
            m_entidades = New EEntidades()
            If d_entidades.ENTISS_CargarDocIden(m_entidades, x_entid_nrodocumento) Then
                setAdicionales(m_entidades.ENTID_Codigo)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

   ''' <summary>
   ''' Cargar Valores adicionales de la entidad
   ''' </summary>
   ''' <param name="x_entid_codigo">Codigo de la Entidad</param>
   ''' <remarks></remarks>
   Private Sub setAdicionales(ByVal x_entid_codigo As String)
      Select Case m_inicio
         Case EEntidades.TipoInicializacion.EntTipos_Dir_Tel
            '' Cargar EntidadesRoles
            Dim x_enttipos As New BEntidadesRoles
            x_enttipos.CargarTodos(x_entid_codigo)
            m_entidades.ListEntidadesTipos = New List(Of EEntidadesRoles)(x_enttipos.ListEntidadesRoles)
            '' Cargar Direcciones
            Dim x_direcciones As New BDirecciones()
            x_direcciones.CargarTodos(x_entid_codigo)
            m_entidades.ListDirecciones = New List(Of EDirecciones)(x_direcciones.ListDirecciones)
            '' Cargar Telefonos  
            Dim x_telefonos As New BTelefonos
            x_telefonos.CargarTodos(x_entid_codigo)
            m_entidades.ListTelefonos = New List(Of ETelefonos)(x_telefonos.ListTelefonos)
         Case EEntidades.TipoInicializacion.Cliente
            '' Cargar EntidadesRoles
            Dim x_enttipos As New BEntidadesRoles
            x_enttipos.CargarTodos(x_entid_codigo)
            m_entidades.ListEntidadesTipos = New List(Of EEntidadesRoles)(x_enttipos.ListEntidadesRoles)
            '' Cargar Cliente
            Dim b_cliente As New BClientes
            If b_cliente.Cargar(x_entid_codigo) Then
               m_ecliente = b_cliente.Clientes
            Else
               m_ecliente = New EClientes
               m_ecliente.Instanciar(ACEInstancia.Nuevo)
            End If
         Case EEntidades.TipoInicializacion.Proveedor
            '' Cargar EntidadesRoles
            Dim x_enttipos As New BEntidadesRoles
            x_enttipos.CargarTodos(x_entid_codigo)
            m_entidades.ListEntidadesTipos = New List(Of EEntidadesRoles)(x_enttipos.ListEntidadesRoles)
            '' Cargar Proveedor
            Dim b_proveedor As New BProveedores
            If b_proveedor.Cargar(x_entid_codigo) Then
               m_eproveedor = b_proveedor.Proveedores
            Else
               m_eproveedor = New EProveedores
               m_eproveedor.Instanciar(ACEInstancia.Nuevo)
            End If
         Case EEntidades.TipoInicializacion.Direcciones
            '' Cargar Direcciones
            m_entidades.ListDirecciones = New List(Of EDirecciones)
            d_entidades.ENTISS_CargarDirecciones(m_entidades.ListDirecciones, x_entid_codigo)
         Case Else

      End Select

      Select Case m_inicio
         Case EEntidades.TipoInicializacion.Cliente
            m_entidades.Cliente = m_ecliente
         Case EEntidades.TipoInicializacion.Proveedor
            m_entidades.Proveedor = m_eproveedor
      End Select
   End Sub

   ''' <summary>
   ''' Cargar la entidad por numero de documento de entidad
   ''' </summary>
   ''' <param name="x_entid_nrodocumento">numero de documento de entidad</param>
   ''' <param name="x_inicio">tipo de inicializacion para la carga de informacion de la entidad</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function CargarDoc(ByVal x_entid_nrodocumento As String, ByVal x_inicio As EEntidades.TipoInicializacion) As Boolean
      m_inicio = x_inicio
      Try
         Dim _where As New Hashtable()
         _where.Add("ENTID_NroDocumento", New ACWhere(x_entid_nrodocumento))

         'Dim d_entidades As New DEntidades()
         m_entidades = New EEntidades()

         If d_entidades.ENTIDSS_UnReg(m_entidades, _where) Then
            Dim x_codigo As Long = m_entidades.ENTID_Id
            Select Case m_inicio
               Case EEntidades.TipoInicializacion.EntTipos_Dir_Tel
                  '' Cargar EntidadesRoles
                  Dim x_enttipos As New BEntidadesRoles
                  x_enttipos.CargarTodos(x_codigo)
                  m_entidades.ListEntidadesTipos = New List(Of EEntidadesRoles)(x_enttipos.ListEntidadesRoles)
                  '' Cargar Direcciones
                  Dim x_direcciones As New BDirecciones()
                  x_direcciones.CargarTodos(x_codigo)
                  m_entidades.ListDirecciones = New List(Of EDirecciones)(x_direcciones.ListDirecciones)
                  '' Cargar Telefonos  
                  Dim x_telefonos As New BTelefonos
                  x_telefonos.CargarTodos(x_codigo)
                  m_entidades.ListTelefonos = New List(Of ETelefonos)(x_telefonos.ListTelefonos)
               Case EEntidades.TipoInicializacion.Cliente
                  Dim b_cliente As New BClientes
                  If b_cliente.Cargar(x_codigo) Then
                     m_ecliente = b_cliente.Clientes
                     m_ecliente = b_cliente.Clientes
                     Return True
                  Else
                     Return False
                  End If

               Case Else

            End Select
            Return True
         Else
            Return False
         End If

      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' cargar la entidad por numero de documento de la entidad
   ''' </summary>
   ''' <param name="x_entid_dni">numero del documento</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function CargarDNI(ByVal x_entid_dni As String) As Boolean
      Try
         m_entidades = New EEntidades()
         Return d_entidades.ENTISS_UnReg(m_entidades, x_entid_dni)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' busqueda de entidades
   ''' </summary>
   ''' <param name="x_cadena"></param>
   ''' <param name="x_campo"></param>
   ''' <param name="x_perfil"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function Busqueda(ByVal x_cadena As String, ByVal x_campo As String, ByVal x_perfil As EEntidades.TipoEntidad) As Boolean
      'Dim d_entidades As New DEntidades()
      Try
         Dim _join As New List(Of ACJoin)
         _join.Add(New ACJoin("dbo", "Tipos", "TDoc", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoDocumento")} _
                            , New ACCampos() {New ACCampos("TIPOS_DescCorta", "TIPOS_Documento")}))
         _join.Add(New ACJoin("dbo", "EntidadesRoles", "Rol", ACJoin.TipoJoin.Inner _
                   , New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_Codigo")} _
                   , New ACCampos() {}))
         _join.Add(New ACJoin(EProveedores.Esquema, EProveedores.Tabla, "Prov", ACJoin.TipoJoin.Left _
                   , New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_Codigo")} _
                   , New ACCampos() {New ACCampos("PROVE_Contacto", "PROVE_Contacto")}))
         Dim _where As New Hashtable()
         _where.Add(x_campo, New ACWhere(x_cadena, ACWhere.TipoWhere._Like))
         _where.Add("ENTID_Estado", New ACWhere(BConstantes.getEstado(BConstantes.Estados.Anulado), ACWhere.TipoWhere.Diferente))
         If Not x_perfil = EEntidades.TipoEntidad.Todos Then
            Dim iMax As Integer
            iMax = x_perfil
            _where.Add("ROLES_Id", New ACWhere(iMax, "Rol", "System.Long", ACWhere.TipoWhere.Igual))
         End If
         m_listEntidades = New List(Of EEntidades)()
         If CargarTodos(_join, _where, True) Then
            Dim _order As New ACOrdenador(Of EEntidades)
            _order.ACOrdenamiento = "ENTID_Nombres ASC"
            m_listEntidades.Sort(AddressOf _order.ACCompare)
            Return True
         Else
            Return False
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' ayuda de las entidades
   ''' </summary>
   ''' <param name="x_cadena">cadena de busqueda</param>
   ''' <param name="x_tipoentidad">tipo de entidad</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function Ayuda(ByVal x_cadena As Hashtable, ByVal x_tipoentidad As EEntidades.TipoEntidad) As Boolean
      Try
         m_dtEntidades = New DataTable()
         Return d_entidades.ENTISS_TodosAyuda(m_dtEntidades, x_cadena, x_tipoentidad)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' ayuda de entidades conductores
   ''' </summary>
   ''' <param name="x_entid_codigo">codigo de entidad</param>
   ''' <param name="x_cadena">cadena de busqueda</param>
   ''' <param name="x_campo">campo de busqueda</param>
   ''' <param name="x_tipoentidad">tipo de entidad</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function AyudaConductores(ByVal x_entid_codigo As String, ByVal x_cadena As String, ByVal x_campo As String, ByVal x_tipoentidad As EEntidades.TipoEntidad) As Boolean
      Try
         m_dtEntidades = New DataTable()
         Return d_entidades.ENTISS_TodosAyudaConductor(m_dtEntidades, x_entid_codigo, x_cadena, x_campo, x_tipoentidad)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' ayuda de entidades conductores
   ''' </summary>
   ''' <param name="x_cadena">cadena de busqueda</param>
   ''' <param name="x_tipoentidad">tipo de entidad</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function AyudaConductores(ByVal x_cadena As String, ByVal x_opcion As Short, ByVal x_tipoentidad As EEntidades.TipoEntidad) As Boolean
      Try
         m_dtEntidades = New DataTable()
         Return d_entidades.ENTISS_TodosAyudaConductor(m_dtEntidades, x_cadena, x_opcion, x_tipoentidad)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Guaradar la entidad, con todos sus datos adicionales
   ''' </summary>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <param name="x_inicio">tipo de inicializacion o datos que trae la entida para se grabados</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function Guardar(ByVal x_usuario As String, ByVal x_inicio As EEntidades.TipoInicializacion) As Boolean
      Try
         DAEnterprise.BeginTransaction()
         'Dim d_entidades As New DEntidades()
         If m_entidades.Nuevo Then
            m_entidades.ENTID_Estado = BConstantes.getEstado(BConstantes.Estados.Activo)
            m_entidades.ENTID_Id = getCorrelativo("ENTID_Id")

            For Each Item As EEntidadesRoles In m_entidades.ListEntidadesTipos
               If Item.ROLES_Id = CType(EEntidades.TipoEntidad.Usuarios, Integer) Then
                  Dim ptrM As Integer = m_entidades.ENTID_PtrApeMaterno
                  Dim ptrN1 As Integer = m_entidades.ENTID_PtrNombre1
                  Dim _long As Integer = m_entidades.ENTID_Nombres.Length
                  Dim _usuario As String = ""
                  If ptrM + ptrN1 > 0 Then
                     Dim txtNombres As String = m_entidades.ENTID_Nombres.Substring(ptrN1, _long - ptrN1)
                     Dim txtApePaterno As String = m_entidades.ENTID_Nombres.Substring(0, ptrM - 1)
                     Dim txtApeMaterno As String = m_entidades.ENTID_Nombres.Substring(ptrM, _long - (_long - ptrN1) - ptrM - 1)
                     _usuario = String.Format("{0}{1}{2}", txtNombres.Substring(0, 1), txtApePaterno.Trim(), txtApeMaterno.Substring(0, 1))
                  End If
                  m_entidades.ENTID_CodUsuario = _usuario
               End If
            Next

            d_entidades.ENTIDSI_UnReg(m_entidades, x_usuario)
         ElseIf m_entidades.Modificado Then
            d_entidades.ENTIDSU_UnReg(m_entidades, x_usuario)
         ElseIf m_entidades.Eliminado Then
            Dim _entidad As New EEntidades() With {.ENTID_Id = m_entidades.ENTID_Id, .ENTID_Estado = BConstantes.getEstado(BConstantes.Estados.Anulado)}
            d_entidades.ENTIDSU_UnReg(_entidad, x_usuario)
            DAEnterprise.CommitTransaction()
            Return True
         End If
         '' Guardar el detalle
         Select Case x_inicio
            Case EEntidades.TipoInicializacion.EntTipos_Dir_Tel
               '' Direcciones
               '' Guardar
               For Each Item As EDirecciones In m_entidades.ListDirecciones
                  Item.ENTID_Codigo = m_entidades.ENTID_Codigo
                  If Item.Nuevo Then
                     Dim _direcciones As New BDirecciones()
                     Item.DIREC_Id = _direcciones.getIdDireccion(Item.ENTID_Codigo)
                  End If
                  Dim _bdirecciones As New BDirecciones() With {.Direcciones = Item}
                  _bdirecciones.Guardar(x_usuario)
               Next
               '' Eliminar
               If Not IsNothing(m_ListEliDirecciones) Then
                  For Each Item As EDirecciones In m_ListEliDirecciones
                     Item.ENTID_Codigo = m_entidades.ENTID_Codigo
                     Dim _bdirecciones As New BDirecciones() With {.Direcciones = Item}
                     _bdirecciones.Guardar(x_usuario)
                  Next
               End If
               '' Telefonos
               '' Guardar
               For Each Item As ETelefonos In m_entidades.ListTelefonos
                  Item.ENTID_Codigo = m_entidades.ENTID_Codigo

                  Dim _btelefonos As New BTelefonos() With {.Telefonos = Item}
                  If Item.Nuevo Then _btelefonos.Telefonos.TELEF_ID = _btelefonos.getCorrelativo("TELEF_ID")
                  _btelefonos.Guardar(x_usuario)
               Next
               '' Eliminar
               If Not IsNothing(m_ListEliTelefonos) Then
                  For Each Item As ETelefonos In m_ListEliTelefonos
                     Item.ENTID_Codigo = m_entidades.ENTID_Codigo
                     Dim _btelefonos As New BTelefonos() With {.Telefonos = Item}
                     _btelefonos.Guardar(x_usuario)
                  Next
               End If
               '' Entidades Tipos
               For Each Item As EEntidadesRoles In m_entidades.ListEntidadesTipos
                  Item.ENTID_Codigo = m_entidades.ENTID_Codigo
                  Dim _benti As New BEntidadesRoles() With {.EntidadesRoles = Item}
                  _benti.Guardar(x_usuario)
               Next
            Case 2

            Case Else

         End Select
         '' Guardar Tablas adicionales a la entidad
         '' Guardar Cliente
         If Not IsNothing(m_entidades.Cliente) Then
            Dim m_cliente As New BClientes
            If m_cliente.Cargar(m_entidades.ENTID_Codigo) Then
               m_entidades.Cliente.Instanciar(ACEInstancia.Modificado)
            Else
               m_entidades.Cliente.Instanciar(ACEInstancia.Nuevo)
            End If
            m_entidades.Cliente.ENTID_Codigo = m_entidades.ENTID_Codigo
            m_cliente.setClientes(m_entidades.Cliente)
            If Not m_cliente.Guardar(x_usuario) Then
               DAEnterprise.RollBackTransaction()
               Return False
            End If
         End If
         '' Guardar Proveedor
         If Not IsNothing(m_entidades.Proveedor) Then
            Dim m_proveedor As New BProveedores
            m_entidades.Proveedor.ENTID_Codigo = m_entidades.ENTID_Codigo
            m_proveedor.setProveedores(m_entidades.Proveedor)
            If Not m_proveedor.Guardar(x_usuario) Then
               DAEnterprise.RollBackTransaction()
               Return False
            End If
         End If
         '' Guardar Conductor
         If Not IsNothing(m_entidades.Conductor) Then
            Dim m_conductor As New BConductores
            If m_conductor.Cargar(m_entidades.ENTID_Codigo) Then
               m_entidades.Conductor.Instanciar(ACEInstancia.Modificado)
            Else
               m_entidades.Conductor.Instanciar(ACEInstancia.Nuevo)
            End If
            m_entidades.Conductor.ENTID_Codigo = m_entidades.ENTID_Codigo
            m_conductor.Conductores = m_entidades.Conductor
            If Not m_conductor.Guardar(x_usuario) Then
               DAEnterprise.RollBackTransaction()
               Return False
            End If
                'If Not IsNothing(m_entidades.Conductor.Transportista) Then
                '   Dim _relac As New BEntidadRelacion
                '   Dim _where As New Hashtable
                '   _where.Add("ENTID_Codigo", New ACWhere(m_entidades.Conductor.Transportista.ENTID_Codigo))
                '   _where.Add("ENTID_CodRelacion", New ACWhere(m_entidades.Conductor.ENTID_Codigo))
                '   _where.Add("TIPOS_CodTipoRelacion", New ACWhere(ETipos.getTipo(ETipos.TipoEntidadRelacion.Conductor)))
                '   If Not _relac.Cargar(_where) Then
                '      _relac.EntidadRelacion = New EEntidadRelacion
                '      _relac.EntidadRelacion.Instanciar(ACEInstancia.Nuevo)
                '      _relac.EntidadRelacion.ENTID_Codigo = m_entidades.Conductor.Transportista.ENTID_Codigo
                '      _relac.EntidadRelacion.ENTID_CodRelacion = m_entidades.Conductor.ENTID_Codigo
                '      _relac.EntidadRelacion.TIPOS_CodTipoRelacion = ETipos.getTipo(ETipos.TipoEntidadRelacion.Conductor)
                '      Dim _wherecor As New Hashtable
                '      _wherecor.Add("ENTID_Codigo", New ACWhere(_relac.EntidadRelacion.ENTID_Codigo))
                '      _relac.EntidadRelacion.ENTRE_Numero = _relac.getCorrelativo("ENTRE_Numero", _wherecor)
                '      If _relac.EntidadRelacion.ENTID_Codigo.Length >= 8 Then
                '         _relac.Guardar(x_usuario)
                '      End If
                '   End If
                'End If

            End If
         '' Completar la operacion cerrando la transacción
         DAEnterprise.CommitTransaction()
         Return True
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' verificar campo de nro de documento, si existe cargara la entidad a la que le pertenece
   ''' </summary>
   ''' <param name="x_campo">campo de busqueda</param>
   ''' <param name="x_ruc">numero a buscar</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function verificarCampo(ByVal x_campo As String, ByVal x_ruc As String) As Boolean
      m_listEntidades = New List(Of EEntidades)()
      Try
         Dim x_where As New Hashtable()
         x_where.Add(x_campo, New ACWhere(x_ruc, ACWhere.TipoWhere.Igual))
         If CargarTodos(x_where) Then
            m_entidades = m_listEntidades(0)
            Return True
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Obtener los usuarios
   ''' </summary>
   ''' <param name="x_baseadmin">base de datos de administracion</param>
   ''' <param name="x_datos">clase donde se almacenara la informacion cargada</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getUsuarios(ByVal x_baseadmin As String, ByRef x_datos As DataTable) As Boolean
      'Dim d_entidades As New DEntidades()
      Try
         Dim _datos As New DataSet
         Dim _where As New Hashtable()
         _where.Add("USUAR_Codigo", New ACWhere(String.Format("Select USER_DNI From {0}.{1}.Usuarios Where USER_Activo = 1", x_baseadmin, "dbo"), ACWhere.TipoWhere._In))
         If d_entidades.ENTISS_TodosAyudaUsuario(_datos, _where) Then
            x_datos = _datos.Tables(0)
            Return x_datos.Rows.Count > 0
         Else
            Return False
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Obtener el listado de usuarios por punto de venta
   ''' </summary>
   ''' <param name="x_pvent_id">codigo de punto de venta</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getListUsuariosXPuntoVenta(ByVal x_pvent_id As Long) As Boolean
      'Dim d_entidades As New DEntidades()
      Try
         Dim _join As New List(Of ACJoin)
         _join.Add(New ACJoin(EUsuariosPorPuntoVenta.Esquema, EUsuariosPorPuntoVenta.Tabla, "UVta", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_Codigo")} _
                              , New ACCampos() {New ACCampos("ENTID_Codigo", "Interno")}))
         Dim _where As New Hashtable()
         _where.Add("PVENT_Id", New ACWhere(x_pvent_id, "UVta", "System.Int32", ACWhere.TipoWhere.Igual))
         m_listEntidades = New List(Of EEntidades)
         Return d_entidades.ENTIDSS_Todos(m_listEntidades, _join, _where, True)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' obtener el listado de usuario por almacen
   ''' </summary>
   ''' <param name="x_almac_id">codigo del almacen</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getListUsuariosXAlmacen(ByVal x_almac_id As Short) As Boolean
      'Dim d_entidades As New DEntidades()
      Try
         Dim _join As New List(Of ACJoin)
         _join.Add(New ACJoin(EUsuariosPorAlmacen.Esquema, EUsuariosPorAlmacen.Tabla, "UAlm", ACJoin.TipoJoin.Inner _
                              , New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_Codigo")} _
                              , New ACCampos() {New ACCampos("ENTID_Codigo", "Interno")}))
         Dim _where As New Hashtable()
         _where.Add("ALMAC_Id", New ACWhere(x_almac_id, "UAlm", "System.Int32", ACWhere.TipoWhere.Igual))
         m_listEntidades = New List(Of EEntidades)
         Return d_entidades.ENTIDSS_Todos(m_listEntidades, _join, _where, True)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Cargar vendedores
   ''' </summary>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function cargarVendedores() As Boolean
      Try
         Dim _join As New List(Of ACJoin)
         _join.Add(New ACJoin(EEntidadesRoles.Esquema, EEntidadesRoles.Tabla, "Rol", ACJoin.TipoJoin.Inner _
                                           , New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_Codigo")} _
                                           , New ACCampos() {}))

         Dim _where As New Hashtable
         _where.Add("ROLES_Id", New ACWhere(CType(EEntidades.TipoEntidad.Vendedores, Integer), "Rol", "System.Int32", ACWhere.TipoWhere.Igual))

         If CargarTodos(_join, _where) Then
            m_vendedores = New List(Of EEntidades)(m_listEntidades)
         End If

      Catch ex As Exception
         Throw ex
      End Try
    End Function



   ''' <summary> 
   ''' Capa de Negocio: ENTISS_ObtenerDireccion
   ''' </summary>
   ''' <param name="x_entid_codigo">Parametro 1: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function ENTISS_ObtenerDireccion(ByVal x_entid_codigo As String) As String
      Dim _entidades As New EEntidades
      Try
         If d_entidades.ENTISS_ObtenerDireccion(_entidades, x_entid_codigo) Then
            Return _entidades.ENTID_Direccion
         Else
            Return ""
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Negocio: ENTISS_BuscarClientes
   ''' </summary>
   ''' <param name="x_cadena">Parametro 1: </param> 
   ''' <param name="x_opcion">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function ENTISS_BuscarClientes(ByVal x_cadena As String, ByVal x_opcion As Short) As Boolean
      m_listEntidades = New List(Of EEntidades)
      Try
         Return d_entidades.ENTISS_BuscarClientes(m_listEntidades, x_cadena, x_opcion)
      Catch ex As Exception
         Throw ex
      End Try
    End Function
    ''' <summary> 
    ''' Capa de Negocio: ENTISS_BuscarClientes
    ''' </summary>
    ''' <param name="x_cadena">Parametro 1: </param> 
    ''' <param name="x_opcion">Parametro 2: </param> 
    ''' <returns></returns> 
    ''' <remarks></remarks> 
    Public Function ENTISS_CargarCotizadores(ByVal x_periodo As String) As Boolean ', ByRef x_datos As DataTable
        'm_listEntidades = New List(Of EEntidades)
        Try
            m_dtEntidades = New DataTable()
            Return d_entidades.ENTISS_CargarCotizadores(m_dtEntidades, x_periodo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#Region " Cargar Roles "

   ''' <summary>
   ''' Cargar clientes
   ''' </summary>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function CargarCliente() As Boolean
      Try
         '' Cargar Cliente
         Dim b_cliente As New BClientes
         If b_cliente.Cargar(m_entidades.ENTID_Codigo) Then
            m_ecliente = b_cliente.Clientes
            m_entidades.Cliente = m_ecliente
            Return True
         Else
            m_ecliente = New EClientes
            m_ecliente.Instanciar(ACEInstancia.Nuevo)
            m_entidades.Cliente = m_ecliente
            Return False
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' cargar tabla de cleinte
   ''' </summary>
   ''' <param name="x_entid_codigo">codigo de entidad</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function CargarCliente(ByVal x_entid_codigo As String) As Boolean
      Try
         '' Cargar Cliente
         Dim b_cliente As New BClientes
         If b_cliente.Cargar(x_entid_codigo) Then
            m_ecliente = b_cliente.Clientes
            m_entidades.Cliente = m_ecliente
            Return True
         Else
            m_ecliente = New EClientes
            m_ecliente.Instanciar(ACEInstancia.Nuevo)
            m_entidades.Cliente = m_ecliente
            Return False
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' cargar tabla proveedor
   ''' </summary>
   ''' <param name="x_entid_codigo"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function CargarProveedor(ByVal x_entid_codigo As String) As Boolean
      Try
         '' Cargar Proveedor
         Dim b_proveedor As New BProveedores
         If b_proveedor.Cargar(x_entid_codigo) Then
            m_eproveedor = b_proveedor.Proveedores
            m_entidades.Proveedor = m_eproveedor
            Return True
         Else
            m_eproveedor = New EProveedores
            m_eproveedor.Instanciar(ACEInstancia.Nuevo)
            m_entidades.Proveedor = m_eproveedor
            Return False
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' cargar tabla de conductor
   ''' </summary>
   ''' <param name="x_entid_codigo">codigo de entidad</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function CargarConductor(ByVal x_entid_codigo As String) As Boolean
      Try
         '' Cargar Proveedor
         Dim b_conductor As New BConductores
         If b_conductor.Cargar(x_entid_codigo) Then
            m_econductor = b_conductor.Conductores
            m_entidades.Conductor = m_econductor
            '' Cargar Conductor de la tabla relacionados de entidad
            Dim _relac As New BEntidadRelacion
            Dim _join As New List(Of ACJoin)
            _join.Add(New ACJoin(EEntidades.Esquema, EEntidades.Tabla, "Ent", ACJoin.TipoJoin.Inner _
                                         , New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_Codigo")} _
                                         , New ACCampos() {New ACCampos("ENTID_RazonSocial", "ENTID_RazonSocial")}))
            Dim _where As New Hashtable
            _where.Add("ENTID_CodRelacion", New ACWhere(x_entid_codigo, ACWhere.TipoWhere.Igual))
            If _relac.Cargar(_join, _where) Then
               m_econductor.Transportista = _relac.EntidadRelacion
            Else
               m_econductor.Transportista = New EEntidadRelacion
            End If
            Return True
         Else
            m_econductor = New EConductores
            m_econductor.Instanciar(ACEInstancia.Nuevo)
            m_entidades.Conductor = m_econductor
            Return False
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region
#End Region

End Class

