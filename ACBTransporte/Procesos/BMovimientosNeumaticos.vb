Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACETransporte
Imports ACDTransporte

Imports System.Configuration
Imports DAConexion
Imports ACFramework
Imports ACBVentas

Public Class BMovimientosNeumaticos


#Region " Variables "
   Private m_documentos As EDocumentos
   Private m_listTRAN_Neumaticos As List(Of ETRAN_Neumaticos)
   Private m_listNoAsignadosTRAN_Neumaticos As List(Of ETRAN_Neumaticos)
   Private m_listMovimientosNeumaticos As List(Of ETRAN_MovimientosNeumaticos)
#End Region

#Region " Constructores "

#End Region

#Region " Propiedades "

   Public Property Documentos() As EDocumentos
      Get
         Return m_documentos
      End Get
      Set(ByVal value As EDocumentos)
         m_documentos = value
      End Set
   End Property

   Public Property ListTRAN_Neumaticos() As List(Of ETRAN_Neumaticos)
      Get
         Return m_listTRAN_Neumaticos
      End Get
      Set(ByVal value As List(Of ETRAN_Neumaticos))
         m_listTRAN_Neumaticos = value
      End Set
   End Property

   Public Property NoAsignadosTRAN_Neumaticos() As List(Of ETRAN_Neumaticos)
      Get
         Return m_listNoAsignadosTRAN_Neumaticos
      End Get
      Set(ByVal value As List(Of ETRAN_Neumaticos))
         m_listNoAsignadosTRAN_Neumaticos = value
      End Set
   End Property

   Public Property ListMovimientosNeumaticos() As List(Of ETRAN_MovimientosNeumaticos)
      Get
         Return m_listMovimientosNeumaticos
      End Get
      Set(ByVal value As List(Of ETRAN_MovimientosNeumaticos))
         m_listMovimientosNeumaticos = value
      End Set
   End Property

#End Region

#Region " Funciones para obtencion de datos "

#End Region

#Region " Metodos "
   Public Function Guardar(ByVal x_usuario As String, ByVal x_ano As String, ByVal x_detalle As Boolean _
                           , ByRef msg As String) As Boolean
      Try
         DAEnterprise.BeginTransaction()
         '' Grabar la cabecera del documentos
         Dim b_documentos As New BDocumentos()
         b_documentos.setDocumentos(m_documentos)
         b_documentos.Guardar(x_usuario, x_ano, True, False)
         '' Grabar la detalle del documentos
         If x_detalle Then
            Dim _listNeuma As New List(Of ETRAN_Neumaticos)
            For Each Item As ETRAN_Neumaticos In m_listTRAN_Neumaticos
               '' Grabar el Movimiento hacia el destino elegido
               Item.TRAN_MovimientosNeumaticos.Instanciar(ACEInstancia.Nuevo)
               Item.TRAN_MovimientosNeumaticos.NEUMA_Id = Item.NEUMA_Id
               Item.TRAN_MovimientosNeumaticos.DOCMT_IdOrden = m_documentos.DOCMT_Id
               Dim b_bmovimientos As New BTRAN_MovimientosNeumaticos()
               b_bmovimientos.setTRAN_MovimientosNeumaticos(Item.TRAN_MovimientosNeumaticos)
               b_bmovimientos.TRAN_MovimientosNeumaticos.DOCMT_IdOrden = m_documentos.DOCMT_Id
               b_bmovimientos.TRAN_MovimientosNeumaticos.MOVNM_Estado = BConstantes.getEstado(BConstantes.EstadoMovimientos.Activo)
               b_bmovimientos.TRAN_MovimientosNeumaticos.MOVNM_Id = b_bmovimientos.getCorrelativo()
               b_bmovimientos.GuardarMovimiento(x_usuario)
               '' Grabar en movimiento en el vehiculo
               Select Case Item.TRAN_MovimientosNeumaticos.TDestino
                  Case ETRAN_MovimientosNeumaticos.TipoDestino.Almacen, BConstantes.TipoDestino.Proveedor
                     Dim b_bvneumaticos As New BTRAN_VehiculosNeumaticos()
                     Item.TRAN_VehiculosNeumaticos.Instanciar(ACEInstancia.Nuevo)
                     'b_bvneumaticos.setTRAN_VehiculosNeumaticos(Item.TRAN_VehiculosNeumaticos)
                     b_bvneumaticos.TRAN_VehiculosNeumaticos = New ETRAN_VehiculosNeumaticos()
                     Dim _where As New Hashtable()
                     _where.Add("MOVNM_Id", New ACWhere(Item.TRAN_MovNeumaAnterior.MOVNM_Id, ACWhere.TipoWhere.Igual))
                     _where.Add("NEUMA_Id", New ACWhere(Item.NEUMA_Id, ACWhere.TipoWhere.Igual))
                     _where.Add("VNEUM_Estado", New ACWhere(BConstantes.getEstado(BConstantes.Estados.Activo), ACWhere.TipoWhere.Igual))
                     b_bvneumaticos.Cargar(New List(Of ACJoin), _where)
                     Dim _movid As Long = b_bvneumaticos.TRAN_VehiculosNeumaticos.VNEUM_Id
                     b_bvneumaticos.TRAN_VehiculosNeumaticos = New ETRAN_VehiculosNeumaticos()
                     b_bvneumaticos.TRAN_VehiculosNeumaticos.VNEUM_Id = _movid
                     b_bvneumaticos.TRAN_VehiculosNeumaticos.VNEUM_Estado = BConstantes.getEstado(BConstantes.EstadoMovimientos.Inactivo)
                     b_bvneumaticos.TRAN_VehiculosNeumaticos.Instanciar(ACEInstancia.Modificado)
                     b_bvneumaticos.Guardar(x_usuario)

                     '' Cambiar  de estado al movimiento anterior
                     Dim _neumatico As New ETRAN_Neumaticos()
                     _neumatico = b_bvneumaticos.GuardarEstado(x_usuario)
                  Case ETRAN_MovimientosNeumaticos.TipoDestino.Vehiculo
                     Dim b_bvneumaticos As New BTRAN_VehiculosNeumaticos()
                     Item.TRAN_VehiculosNeumaticos.Instanciar(ACEInstancia.Nuevo)
                     b_bvneumaticos.setTRAN_VehiculosNeumaticos(Item.TRAN_VehiculosNeumaticos)
                     b_bvneumaticos.TRAN_VehiculosNeumaticos.VEHIC_Id = Item.TRAN_MovimientosNeumaticos.MOVNM_IdDestino
                     b_bvneumaticos.TRAN_VehiculosNeumaticos.NEUMA_Id = Item.NEUMA_Id
                     b_bvneumaticos.TRAN_VehiculosNeumaticos.MOVNM_Id = b_bmovimientos.TRAN_MovimientosNeumaticos.MOVNM_Id
                     b_bvneumaticos.TRAN_VehiculosNeumaticos.VNEUM_Estado = BConstantes.getEstado(BConstantes.EstadoMovimientos.Activo)
                     '' Cambiar  de estado al movimiento anterior
                     Dim _neumatico As New ETRAN_Neumaticos()
                     _neumatico = b_bvneumaticos.GuardarEstado(x_usuario)
                     If Not IsNothing(_neumatico) Then
                        _neumatico.TRAN_MovimientosNeumaticos = New ETRAN_MovimientosNeumaticos()
                        _neumatico.TRAN_MovimientosNeumaticos.TDestino = Item.TRAN_MovimientosNeumaticos.TDestino
                        _listNeuma.Add(_neumatico)
                     End If
                     b_bvneumaticos.TRAN_VehiculosNeumaticos.VNEUM_Estado = BConstantes.getEstado(BConstantes.EstadoMovimientos.Activo)
                     '' Guarda el nuevo movimiento del neumatico
                     b_bvneumaticos.Guardar(x_usuario)
                  Case ETRAN_MovimientosNeumaticos.TipoDestino.Ranfla
                     Dim b_bvneumaticos As New BTRAN_VehiculosNeumaticos()
                     Item.TRAN_VehiculosNeumaticos.Instanciar(ACEInstancia.Nuevo)
                     b_bvneumaticos.setTRAN_VehiculosNeumaticos(Item.TRAN_VehiculosNeumaticos)
                     b_bvneumaticos.TRAN_VehiculosNeumaticos.RANFL_Id = Item.TRAN_MovimientosNeumaticos.MOVNM_IdDestino
                     b_bvneumaticos.TRAN_VehiculosNeumaticos.NEUMA_Id = Item.NEUMA_Id
                     b_bvneumaticos.TRAN_VehiculosNeumaticos.MOVNM_Id = b_bmovimientos.TRAN_MovimientosNeumaticos.MOVNM_Id
                     b_bvneumaticos.TRAN_VehiculosNeumaticos.VNEUM_Estado = BConstantes.getEstado(BConstantes.EstadoMovimientos.Activo)
                     '' Cambiar  de estado al movimiento anterior
                     _listNeuma.Add(b_bvneumaticos.GuardarEstado(x_usuario))
                     b_bvneumaticos.TRAN_VehiculosNeumaticos.VNEUM_Estado = BConstantes.getEstado(BConstantes.EstadoMovimientos.Activo)
                     '' Guarda el nuevo movimiento del neumatico
                     b_bvneumaticos.Guardar(x_usuario)
               End Select
            Next
            '' Verifica que los neumaticos que estan siendo movidos tengan un destino apropiado 
            Dim _vehicNeumas As New BTRAN_VehiculosNeumaticos()
            Dim _MovimNeumas As New BTRAN_MovimientosNeumaticos()
            Dim _msg As String = ""
            m_listNoAsignadosTRAN_Neumaticos = New List(Of ETRAN_Neumaticos)()
            For Each Item As ETRAN_Neumaticos In _listNeuma
               If Not IsNothing(Item) Then
                  '' Verifica que el neumatico movido tenga posicion
                  If _vehicNeumas.CargarXneumatico(Item.NEUMA_Id) Then
                     '' Si el netumatico no tiene posición  se verifica que se le este asignando una ubicacio
                     Dim _fil As New ACFiltrador(Of ETRAN_Neumaticos)
                     _fil.ACFiltro = "NEUMA_Id=" & Item.NEUMA_Id.ToString()
                     _fil.ACFiltrar(m_listTRAN_Neumaticos)
                     If Not _fil.ACListaFiltrada.Count > 0 Then
                        Item.NEUMA_Estado = "U"
                        _msg &= String.Format("- Neumatico, Codigo: {0}, no tiene asignación", Item.NEUMA_Codigo) & vbNewLine
                     End If
                  End If
               End If
            Next

            If _msg.Length > 0 Then
               DAEnterprise.RollBackTransaction()
               For Each Item As ETRAN_Neumaticos In _listNeuma
                  If Not IsNothing(Item) Then
                     If Item.NEUMA_Estado = "U" Then
                        Dim _bNeumaticos As New BTRAN_Neumaticos()
                        _bNeumaticos.Cargar(Item.NEUMA_Id, True)
                        m_listNoAsignadosTRAN_Neumaticos.Add(_bNeumaticos.TRAN_Neumaticos)
                        '_msg &= String.Format("- Neumatico, Codigo: {0}, no tiene asignación", Item.NEUMA_Codigo) & vbNewLine
                     End If
                  End If
               Next
               msg &= "Los Neumaticos siguientes presentar errores:" & vbNewLine & _msg
               Return False
            Else
               DAEnterprise.CommitTransaction()
               Return True
            End If
         Else
            DAEnterprise.CommitTransaction()
         End If
         Return True
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

   Public Function cargarMovimientos(ByVal x_neuma_id As Long) As Boolean
      Try
         Dim b_tranmovimientosneumaticos As New BTRAN_MovimientosNeumaticos()
         Dim _join As New List(Of ACJoin)()
         _join.Add(New ACJoin("Transportes", "TRAN_VehiculosNeumaticos", ACJoin.TipoJoin.Left _
                              , New ACCampos() {New ACCampos("MOVNM_Id", "MOVNM_Id")} _
                              , New ACCampos() {}))
         _join.Add(New ACJoin("dbo", "Tipos", "TUbi", ACJoin.TipoJoin.Left _
                              , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodDestino")} _
                              , New ACCampos() {New ACCampos("TIPOS_Descripcion", "Destino")}))
         Dim _where As New Hashtable()
         _where.Add("NEUMA_Id", New ACWhere(x_neuma_id.ToString(), ACWhere.TipoWhere.Igual))
         _where.Add("OrderBy", New ACWhere(New ACOrderBy() {New ACOrderBy("MOVNM_Id", ACOrderBy.Ordenamiento.Descendente)}))
         b_tranmovimientosneumaticos.CargarTodos(_join, _where)
         m_listMovimientosNeumaticos = New List(Of ETRAN_MovimientosNeumaticos)(b_tranmovimientosneumaticos.ListTRAN_MovimientosNeumaticos)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function cargarMovDocumento(ByVal x_docmt_id As Long) As Boolean
      Try
         '' Cargar los documentos
         Dim m_bdocumentos As New BDocumentos()
         m_bdocumentos.Cargar(x_docmt_id)
         m_documentos = m_bdocumentos.Documentos
         '' Cargar los Movimiento
         Dim m_dmovimientosneumaticos As New DMovimientosNeumaticos()
         m_listTRAN_Neumaticos = New List(Of ETRAN_Neumaticos)
         Return m_dmovimientosneumaticos.cargarMovimientos(x_docmt_id, m_listTRAN_Neumaticos)
         '' Cargar los Neumaticos 
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

End Class

