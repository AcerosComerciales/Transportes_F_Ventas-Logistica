Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACELogistica
Imports ACDLogistica
Imports ACEVentas
Imports Microsoft.Practices.Unity
Imports Microsoft.Practices.Unity.Configuration
Imports System.Configuration

Imports ACFramework
Imports DAConexion
Imports System.Reflection


Public Class BGenerarCosteo

#Region " Variables "

   Private m_dtGenerarCosteo As DataTable

   Private ds_generarcosteo As DataSet
   Private d_generarcosteo As DGenerarCosteo

   Private m_flete As EABAS_Costeos
   Private m_gasto As EABAS_Costeos
   Private m_servicios As EABAS_Costeos
   Private m_eabas_docscompra As EABAS_DocsCompra

   Private m_listABAS_DocsCompraDetalle As List(Of EABAS_DocsCompraDetalle)
#End Region

#Region " Constructores "

   Public Sub New()
      d_generarcosteo = New DGenerarCosteo
   End Sub

#End Region

#Region " Propiedades "

   Public Property Flete() As EABAS_Costeos
      Get
         Return m_flete
      End Get
      Set(ByVal value As EABAS_Costeos)
         m_flete = value
      End Set
   End Property

   Public Property Gasto() As EABAS_Costeos
      Get
         Return m_gasto
      End Get
      Set(ByVal value As EABAS_Costeos)
         m_gasto = value
      End Set
   End Property

   Public Property Servicios() As EABAS_Costeos
      Get
         Return m_servicios
      End Get
      Set(ByVal value As EABAS_Costeos)
         m_servicios = value
      End Set
   End Property

   Public Property ABAS_DocsCompra() As EABAS_DocsCompra
      Get
         Return m_eabas_docscompra
      End Get
      Set(ByVal value As EABAS_DocsCompra)
         m_eabas_docscompra = value
      End Set
   End Property

   Public Property ListABAS_DocsCompraDetalle() As List(Of EABAS_DocsCompraDetalle)
      Get
         Return m_listABAS_DocsCompraDetalle
      End Get
      Set(ByVal value As List(Of EABAS_DocsCompraDetalle))
         m_listABAS_DocsCompraDetalle = value
      End Set
   End Property

#End Region

#Region " Funciones para obtencion de datos "

#End Region

#Region " Metodos "

   ''' <summary>
   ''' Grabar los registros necesarios para registrar el costeo de los items de un documento de venta
   ''' </summary>
   ''' <param name="x_eabas_docscompra">Clase Docmento de Venta que contiene los datos necesarios para
   ''' grabar el costeo respectivo por cada detalle</param>
   ''' <param name="x_usuario">Usuario que realiza la operación</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GrabarCosteo(ByVal x_eabas_docscompra As EABAS_DocsCompra, ByVal x_usuario As String) As Boolean
      Try
         m_eabas_docscompra = x_eabas_docscompra
         '' Iniciar la transaccion del proceso
         DAEnterprise.BeginTransaction()
         '' Eliminar todos los registros para nuevos
         Dim _eliminar As New BABAS_Costeos()
         _eliminar.ABAS_Costeos = New EABAS_Costeos()
         _eliminar.ABAS_Costeos.Instanciar(ACEInstancia.Eliminado)
         Dim _where As New Hashtable
         _where.Add("DOCCO_Codigo", New ACWhere(m_eabas_docscompra.DOCCO_Codigo))
         _where.Add("ENTID_CodigoProveedor", New ACWhere(m_eabas_docscompra.ENTID_CodigoProveedor))
         _eliminar.Guardar(_where, x_usuario)

         Dim _babas_costeos As New BABAS_Costeos() With {.ABAS_Costeos = m_flete}
         '' Grabar la cabecera del flete
         If m_flete.COSTE_Importe > 0 Then
            _babas_costeos.ABAS_Costeos.TIPOS_CodTipoCosteo = ACEVentas.ETipos.getTipo(ACEVentas.ETipos.TipoCosteo.Fletes)
            _babas_costeos.ABAS_Costeos.DOCCO_Codigo = m_eabas_docscompra.DOCCO_Codigo
            _babas_costeos.ABAS_Costeos.DOCCD_Item = 1
            _babas_costeos.ABAS_Costeos.COSTE_Item = -1
            _babas_costeos.ABAS_Costeos.ENTID_CodigoProveedor = m_eabas_docscompra.ENTID_CodigoProveedor
            _babas_costeos.ABAS_Costeos.Instanciar(ACFramework.ACEInstancia.Nuevo)
            _babas_costeos.Guardar(x_usuario)
         End If
         '' Grabar la cabecera del Gasto
         If m_gasto.COSTE_Importe > 0 Then
            _babas_costeos = New BABAS_Costeos()
            _babas_costeos.ABAS_Costeos = m_gasto
            _babas_costeos.ABAS_Costeos.TIPOS_CodTipoCosteo = ACEVentas.ETipos.getTipo(ACEVentas.ETipos.TipoCosteo.Gastos)
            _babas_costeos.ABAS_Costeos.DOCCO_Codigo = m_eabas_docscompra.DOCCO_Codigo
            _babas_costeos.ABAS_Costeos.DOCCD_Item = 1
            _babas_costeos.ABAS_Costeos.COSTE_Item = -2
            _babas_costeos.ABAS_Costeos.ENTID_CodigoProveedor = m_eabas_docscompra.ENTID_CodigoProveedor
            _babas_costeos.ABAS_Costeos.Instanciar(ACFramework.ACEInstancia.Nuevo)
            _babas_costeos.Guardar(x_usuario)
         End If
         '' Grabar Importe total del servicio
         If m_servicios.COSTE_Importe > 0 Then
            _babas_costeos = New BABAS_Costeos()
            _babas_costeos.ABAS_Costeos = m_servicios
            _babas_costeos.ABAS_Costeos.TIPOS_CodTipoCosteo = ACEVentas.ETipos.getTipo(ACEVentas.ETipos.TipoCosteo.Servicio)
            _babas_costeos.ABAS_Costeos.DOCCO_Codigo = m_eabas_docscompra.DOCCO_Codigo
            _babas_costeos.ABAS_Costeos.DOCCD_Item = 1
            _babas_costeos.ABAS_Costeos.COSTE_Item = -3
            _babas_costeos.ABAS_Costeos.ENTID_CodigoProveedor = m_eabas_docscompra.ENTID_CodigoProveedor
            _babas_costeos.ABAS_Costeos.Instanciar(ACFramework.ACEInstancia.Nuevo)
            _babas_costeos.Guardar(x_usuario)
         End If
         '' Recorrer todos los item para grabar los servicios
         For Each Item As EABAS_DocsCompraDetalle In m_eabas_docscompra.ListEABAS_DocsCompraDetalle
            Dim i As Integer = 1
            '' Grabar el detalle disgregado del costeo
            For Each Costeo As EABAS_Costeos In Item.CCosteos
               Dim m_babas_costeos As New BABAS_Costeos()
               m_babas_costeos.ABAS_Costeos = Costeo
               m_babas_costeos.ABAS_Costeos.DOCCO_Codigo = Item.DOCCO_Codigo
               m_babas_costeos.ABAS_Costeos.DOCCD_Item = Item.DOCCD_Item
               m_babas_costeos.ABAS_Costeos.COSTE_Item = i
               If m_babas_costeos.ABAS_Costeos.TIPOS_CodTipoCosteo = ACEVentas.ETipos.getTipo(ACEVentas.ETipos.TipoCosteo.Servicio) Then m_babas_costeos.ABAS_Costeos.COSTE_Cantidad = Item.COSTE_Cantidad
               m_babas_costeos.ABAS_Costeos.ENTID_CodigoProveedor = Item.ENTID_CodigoProveedor
               m_babas_costeos.ABAS_Costeos.Instanciar(ACFramework.ACEInstancia.Nuevo)
               m_babas_costeos.Guardar(x_usuario)
               i += 1
            Next
            '' Actualizar el precio Costeado
            Dim m_babas_docscompradetalle As New BABAS_DocsCompraDetalle
            m_babas_docscompradetalle.ABAS_DocsCompraDetalle = New EABAS_DocsCompraDetalle
            'm_babas_docscompradetalle()
            m_babas_docscompradetalle.ABAS_DocsCompraDetalle.DOCCD_Costo = Item.Costo
            m_babas_docscompradetalle.ABAS_DocsCompraDetalle.DOCCD_CostoIGV = Item.CostoIGV
            m_babas_docscompradetalle.ABAS_DocsCompraDetalle.DOCCO_Codigo = m_eabas_docscompra.DOCCO_Codigo
            m_babas_docscompradetalle.ABAS_DocsCompraDetalle.ENTID_CodigoProveedor = m_eabas_docscompra.ENTID_CodigoProveedor
            m_babas_docscompradetalle.ABAS_DocsCompraDetalle.DOCCD_Item = Item.DOCCD_Item
            m_babas_docscompradetalle.ABAS_DocsCompraDetalle.Instanciar(ACEInstancia.Modificado)
            m_babas_docscompradetalle.Guardar(x_usuario)
         Next
         'DAEnterprise.RollBackTransaction()
         '' Cambiar el estado del documento de compra
         Dim _babas_docscompras As New BABAS_DocsCompra
         _babas_docscompras.ABAS_DocsCompra = New EABAS_DocsCompra
         '_babas_docscompras.ABAS_DocsCompra.DOCCO_Estado = EABAS_DocsCompra.getEstado(EABAS_DocsCompra.Estado.Confirmado)
         _babas_docscompras.ABAS_DocsCompra.DOCCO_Costeado = True
         _babas_docscompras.ABAS_DocsCompra.DOCCO_Codigo = m_eabas_docscompra.DOCCO_Codigo
         _babas_docscompras.ABAS_DocsCompra.ENTID_CodigoProveedor = m_eabas_docscompra.ENTID_CodigoProveedor
         _babas_docscompras.ABAS_DocsCompra.Instanciar(ACFramework.ACEInstancia.Modificado)
         _babas_docscompras.Guardar(x_usuario)

         '' Confirmar la transaccion y terminar el proceso
         DAEnterprise.CommitTransaction()
         Return True
      Catch ex As Exception
         '' Rehacer la transaccion en caso de que surja algun error
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Negocio: COSTESS_ObtenerDocCosteadosDetalle
   ''' </summary>
   ''' <param name="x_entid_codigoproveedor">Parametro 1: </param> 
   ''' <param name="x_docco_codigo">Parametro 2: </param> 
   ''' <param name="x_artic_codigo">Parametro 3: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function ObtenerDocCosteadosDetalle(ByVal x_entid_codigoproveedor As String, ByVal x_docco_codigo As String, ByVal x_artic_codigo As String) As Boolean
      m_listABAS_DocsCompraDetalle = New List(Of EABAS_DocsCompraDetalle)
      Try
         
         Return False
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Proceso para recupera el costeo grabado, en las clases respectivas para su edición tanto
   ''' de cambio como de corrección
   ''' </summary>
   ''' <param name="x_docco_codigo">Nro documento de compra</param>
   ''' <param name="x_entid_codigo">Codigo de entidad de proveedor</param>
   ''' <param name="x_max">Objeto para recuperar el numero de descuentos que se realizaron</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function CargarCosteo(ByVal x_docco_codigo As String, ByVal x_entid_codigo As String, ByRef x_max As Integer) As Boolean
      Try
         Dim m_babas_docscompra As New BABAS_DocsCompra
         '' Carga documento de compra
         'If m_babas_docscompra.Cargar(x_docco_codigo, x_entid_codigo, True) Then
         If m_babas_docscompra.ObtenerDocCosteados(x_entid_codigo, x_docco_codigo, True) Then
            m_eabas_docscompra = m_babas_docscompra.ABAS_DocsCompra
            '' Cargar Costeos
            Dim x_join As New List(Of ACJoin)
            x_join.Add(New ACJoin(EEntidades.Esquema, EEntidades.Tabla, ACJoin.TipoJoin.Inner _
                                 , New ACCampos() {New ACCampos("ENTID_Codigo", "COSTE_CodigoProveedor")} _
                                 , New ACCampos() {New ACCampos("ENTID_RazonSocial", "ENTID_RazonSocial")}))

            Dim _join As New List(Of ACJoin)
            _join.Add(New ACJoin(EEntidades.Esquema, EEntidades.Tabla, ACJoin.TipoJoin.Inner _
                                 , New ACCampos() {New ACCampos("ENTID_Codigo", "COSTE_CodigoProveedor")} _
                                 , New ACCampos() {New ACCampos("ENTID_RazonSocial", "ENTID_RazonSocial")}))
            _join.Add(New ACJoin(ACEVentas.EArticulos.Esquema, ACEVentas.EArticulos.Tabla, ACJoin.TipoJoin.Inner _
                                 , New ACCampos() {New ACCampos("ARTIC_Codigo", "ARTIC_Codigo")} _
                                 , New ACCampos() {New ACCampos("ARTIC_Descripcion", "ARTIC_Descripcion")}))

            Dim m_babas_costeos As New BABAS_Costeos
            Dim x_where As New Hashtable
            x_where.Add("DOCCO_Codigo", New ACWhere(x_docco_codigo))
            x_where.Add("ENTID_CodigoProveedor", New ACWhere(x_entid_codigo))
            x_where.Add("COSTE_Item", New ACWhere(0, ACWhere.TipoWhere.Menor))
            '' Cargar Fletes
            x_where.Add("TIPOS_CodTipoCosteo", New ACWhere(ACEVentas.ETipos.getTipo(ACEVentas.ETipos.TipoCosteo.Fletes)))
            If m_babas_costeos.Cargar(x_join, x_where) Then
               m_flete = m_babas_costeos.ABAS_Costeos
            Else
               m_flete = New EABAS_Costeos
            End If
            '' Cargar Gastos
            x_where("COSTE_Item") = New ACWhere(0, ACWhere.TipoWhere.Menor)
            x_where("TIPOS_CodTipoCosteo") = New ACWhere(ACEVentas.ETipos.getTipo(ACEVentas.ETipos.TipoCosteo.Gastos))
            If m_babas_costeos.Cargar(x_join, x_where) Then
               m_gasto = m_babas_costeos.ABAS_Costeos
            Else
               m_gasto = New EABAS_Costeos
            End If
            '' Cargar Servicios
            x_where("COSTE_Item") = New ACWhere(0, ACWhere.TipoWhere.Menor)
            x_where("TIPOS_CodTipoCosteo") = New ACWhere(ACEVentas.ETipos.getTipo(ACEVentas.ETipos.TipoCosteo.Servicio))
            If m_babas_costeos.Cargar(x_join, x_where) Then
               m_servicios = m_babas_costeos.ABAS_Costeos
            Else
               m_servicios = New EABAS_Costeos
            End If
            '' Calcular el Numero de Descuento
            Dim max As Integer = 0
            '' Cargar Descuentos
            Dim _tipo As Type = GetType(EABAS_DocsCompraDetalle)
            Dim _info As PropertyInfo
            x_where("COSTE_Item") = New ACWhere(0, ACWhere.TipoWhere.Mayor)
            x_where("TIPOS_CodTipoCosteo") = New ACWhere(ACEVentas.ETipos.getTipo(ACEVentas.ETipos.TipoCosteo.Descuentos))
            If m_babas_costeos.CargarTodos(x_where) Then
               For Each Item As EABAS_DocsCompraDetalle In m_eabas_docscompra.ListEABAS_DocsCompraDetalle
                  Dim _filter As New ACFiltrador(Of EABAS_Costeos)
                  _filter.ACFiltro = String.Format("DOCCD_Item={0}", Item.DOCCD_Item)
                  Item.CCosteos = New List(Of EABAS_Costeos)
                  Dim index As Short = 1
                  For Each Costeo As EABAS_Costeos In _filter.ACFiltrar(m_babas_costeos.ListABAS_Costeos)
                     Dim x_campo As String = String.Format("Descuento_{0}", index.ToString())
                     _info = _tipo.GetProperty(x_campo)
                     _info.SetValue(Item, Costeo.COSTE_Porcentaje, Nothing)
                     index += 1
                  Next
                  If _filter.ACListaFiltrada.Count > max Then max = _filter.ACListaFiltrada.Count
               Next
            End If
            x_max = max
            '' Cargar Servicios
            x_where("COSTE_Item") = New ACWhere(0, ACWhere.TipoWhere.Mayor)
            x_where("TIPOS_CodTipoCosteo") = New ACWhere(ACEVentas.ETipos.getTipo(ACEVentas.ETipos.TipoCosteo.Servicio))
            If m_babas_costeos.CargarTodos(_join, x_where) Then
               For Each Item As EABAS_DocsCompraDetalle In m_eabas_docscompra.ListEABAS_DocsCompraDetalle
                  Dim _filter As New ACFiltrador(Of EABAS_Costeos)
                  _filter.ACFiltro = String.Format("DOCCD_Item={0}", Item.DOCCD_Item)
                  If _filter.ACFiltrar(m_babas_costeos.ListABAS_Costeos).Count > 0 Then
                     Item.CServicios = _filter.ACListaFiltrada(0)
                     Item.ARTIC_CodServicio = Item.CServicios.ARTIC_Codigo
                     Item.ARTIC_DesServicio = Item.CServicios.ARTIC_Descripcion
                     Item.COSTE_Cantidad = Item.CServicios.COSTE_Cantidad
                  End If
               Next
            End If
            Return True
         Else
            Return False
         End If


      Catch ex As Exception
         Throw ex
      End Try
   End Function


#End Region

End Class

