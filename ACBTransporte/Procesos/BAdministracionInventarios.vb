Imports ACDTransporte
Imports ACETransporte
Imports DAConexion

Public Class BAdministracionInventarios
#Region " Variables "
   Private m_listtran_vehiculosinventariodetalle As List(Of ETRAN_VehiculosInventarioDetalle)
   Private m_tran_vehiculosinventario As ETRAN_VehiculosInventario
   Private m_listetran_vehiculosinventario As List(Of ETRAN_VehiculosInventario)

   Private d_administracioninventarios As DAdministracionInventarios
   Private dt_datos As DataTable
#End Region

#Region " Propiedades "

   Public Property ListETRAN_VehiculosInventarioDetalle() As List(Of ETRAN_VehiculosInventarioDetalle)
      Get
         Return m_listtran_vehiculosinventariodetalle
      End Get
      Set(ByVal value As List(Of ETRAN_VehiculosInventarioDetalle))
         m_listtran_vehiculosinventariodetalle = value
      End Set
   End Property


   Public Property TRAN_VehiculosInventario() As ETRAN_VehiculosInventario
      Get
         Return m_tran_vehiculosinventario
      End Get
      Set(ByVal value As ETRAN_VehiculosInventario)
         m_tran_vehiculosinventario = value
      End Set
   End Property

   Public Property ListTRAN_VehiculosInventario() As List(Of ETRAN_VehiculosInventario)
      Get
         Return m_listetran_vehiculosinventario
      End Get
      Set(ByVal value As List(Of ETRAN_VehiculosInventario))
         m_listetran_vehiculosinventario = value
      End Set
   End Property

#End Region

#Region " Constructores "
   Public Sub New()
      d_administracioninventarios = New DAdministracionInventarios
   End Sub
#End Region

#Region " Metodos "
   Public Function GetInventarios(ByVal x_codigos As String) As Boolean
      dt_datos = New DataTable
      Try
         Return d_administracioninventarios.GetInventarios(dt_datos, x_codigos)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function GetObjetosInventario(ByVal x_vehic_id As Long) As Boolean
      Try
         Dim _invdet As New BTRAN_VehiculosInventarioDetalle
         If _invdet.TodosObjetosInventario(x_vehic_id) Then
            m_listtran_vehiculosinventariodetalle = _invdet.ListTRAN_VehiculosInventarioDetalle
            Return True
         Else
            m_listtran_vehiculosinventariodetalle = New List(Of ETRAN_VehiculosInventarioDetalle)
            Return False
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function GrabarInventario(ByVal x_usuario As String) As Boolean
      Try
         Dim _invetario As New BTRAN_VehiculosInventario
         _invetario.TRAN_VehiculosInventario = m_tran_vehiculosinventario
         _invetario.TRAN_VehiculosInventario.Instanciar(ACFramework.ACEInstancia.Nuevo)
         Dim _where As New Hashtable
         _where.Add("VEHIC_Id", New ACFramework.ACWhere(m_tran_vehiculosinventario.VEHIC_Id))
         _invetario.TRAN_VehiculosInventario.VEHIN_Id = _invetario.getCorrelativo("VEHIN_Id", _where)

         DAEnterprise.BeginTransaction()
         If _invetario.Guardar(x_usuario) Then
            Dim _i As Integer = 1
            For Each item As ETRAN_VehiculosInventarioDetalle In m_listtran_vehiculosinventariodetalle
               Dim _invdetalle As New BTRAN_VehiculosInventarioDetalle
               _invdetalle.TRAN_VehiculosInventarioDetalle = item
               _invdetalle.TRAN_VehiculosInventarioDetalle.VEHIN_Id = _invetario.TRAN_VehiculosInventario.VEHIN_Id
               _invdetalle.TRAN_VehiculosInventarioDetalle.VEHID_Id = _i
               If item.Existe = item.VEHID_Existe Then
                  'If item.VEHID_Existe Then
                  _invdetalle.TRAN_VehiculosInventarioDetalle.VEHID_Observacion = String.Format("{0}", item.VEHID_Observacion)

                  'End If
               Else
                  If item.VEHID_Existe Then
                     _invdetalle.TRAN_VehiculosInventarioDetalle.VEHID_Observacion = String.Format("Se cambio su estado de existencia a [Si existe]{0}{1}", vbNewLine, item.VEHID_Observacion)
                  Else
                     _invdetalle.TRAN_VehiculosInventarioDetalle.VEHID_Observacion = String.Format("Se cambio su estado de existencia a [No existe]{0}{1}", vbNewLine, item.VEHID_Observacion)
                  End If
               End If

         _invdetalle.TRAN_VehiculosInventarioDetalle.VEHID_Estado = Constantes.getEstado(Constantes.EstadoDocVta.Ingresado)
         _invdetalle.TRAN_VehiculosInventarioDetalle.Instanciar(ACFramework.ACEInstancia.Nuevo)
         _invdetalle.Guardar(x_usuario)
         _i += 1
            Next
            DAEnterprise.CommitTransaction()
            Return True
         End If
         Return False
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

   Public Function GetInventarios() As String
      Dim _cadenas As String = ""
      Try
         Dim _where As New Hashtable
         _where.Add("VEHIC_Id", New ACFramework.ACWhere(m_tran_vehiculosinventario.VEHIC_Id))
         Dim _inventarios As New BTRAN_VehiculosInventario
         If _inventarios.CargarTodos(_where) Then
            Dim _order As New ACFramework.ACOrdenador(Of ETRAN_VehiculosInventario)("VEHIN_Id DESC")
            _inventarios.ListTRAN_VehiculosInventario.Sort(_order)
            For Each item As ETRAN_VehiculosInventario In _inventarios.ListTRAN_VehiculosInventario
               _cadenas &= String.Format("{0}=====Actualización {2}: {1:dd/MM/yyyy HH:mm:ss}=====", vbNewLine, item.VEHIN_Fecha, item.VEHIN_Id)
               _cadenas &= String.Format("{0}Detalle : {1}", vbNewLine, item.VEHIN_Observacion)
            Next
         End If
         Return _cadenas
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function GetInventariosDetalle(ByVal x_tipos_codobjeto As String) As String
      Dim _cadenas As String = ""
      Try
         Dim _where As New Hashtable
         _where.Add("VEHIC_Id", New ACFramework.ACWhere(m_tran_vehiculosinventario.VEHIC_Id))
         _where.Add("TIPOS_CodObjeto", New ACFramework.ACWhere(x_tipos_codobjeto))
         Dim _inventarios As New BTRAN_VehiculosInventarioDetalle
         If _inventarios.CargarTodos(_where) Then
            Dim _order As New ACFramework.ACOrdenador(Of ETRAN_VehiculosInventarioDetalle)("VEHIN_Id DESC")
            _inventarios.ListTRAN_VehiculosInventarioDetalle.Sort(_order)

            For Each item As ETRAN_VehiculosInventarioDetalle In _inventarios.ListTRAN_VehiculosInventarioDetalle
               If Not IsNothing(item.VEHID_Observacion) Then
                  _cadenas &= String.Format("{0}=====Actualización {2}: {1:dd/MM/yyyy HH:mm:ss}=====", vbNewLine, item.VEHID_FecCrea, item.VEHIN_Id)
                  _cadenas &= String.Format("{0}Detalle : {1}", vbNewLine, item.VEHID_Observacion)
               Else
                  _cadenas &= String.Format("{0}=====Actualización {2}: {1:dd/MM/yyyy HH:mm:ss}=====", vbNewLine, item.VEHID_FecCrea, item.VEHIN_Id)
               End If
            Next
         Else
            Return ""
         End If
         Return _cadenas
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region

#Region " Metodos de Controles"

#End Region
End Class
