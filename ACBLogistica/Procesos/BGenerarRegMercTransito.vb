Imports System
Imports System.Data
Imports System.Collections.Generic

Imports ACELogistica
Imports ACDLogistica
Imports Microsoft.Practices.Unity
Imports Microsoft.Practices.Unity.Configuration
Imports System.Configuration
Imports DAConexion
Imports ACFramework
Imports ACEVentas

Public Class BGenerarRegMercTransito

#Region " Variables "

   Private m_dtGenerarRegMercTransito As DataTable
    Private m_listadetalle As BABAS_IngresosCompraDetalle
   Private ds_generarregmerctransito As DataSet
   Private d_generarregmerctransito As DGenerarRegMercTransito
    Private m_list_docsingresosdetalle As List(Of EABAS_IngresosCompraDetalle)
   Private m_abas_ingresoscompra As BABAS_IngresosCompra

   Private m_listABAS_DocsCompra As List(Of EABAS_DocsCompra)
   Private m_listABAS_OrdenesCompra As List(Of EABAS_OrdenesCompra)

   Private m_periodo As String


   Private m_abas_ordenescompra As BABAS_OrdenesCompra
   Private m_abas_docscompra As BABAS_DocsCompra

   Enum TConsulta
      Ordenes
      Compras
   End Enum

#End Region

#Region " Constructores "

   Public Sub New(ByVal x_periodo As String)
      d_generarregmerctransito = New DGenerarRegMercTransito
      m_periodo = x_periodo
   End Sub

#End Region

#Region " Propiedades "
   Public Property ListABAS_DocsCompra() As List(Of EABAS_DocsCompra)
      Get
         Return m_listABAS_DocsCompra
      End Get
      Set(ByVal value As List(Of EABAS_DocsCompra))
         m_listABAS_DocsCompra = value
      End Set
   End Property

   Public Property ABAS_IngresosCompra() As EABAS_IngresosCompra
      Get
         Return m_abas_ingresoscompra.ABAS_IngresosCompra
      End Get
      Set(ByVal value As EABAS_IngresosCompra)
         m_abas_ingresoscompra.ABAS_IngresosCompra = value
      End Set
   End Property

   Public Property BABAS_IngresosCompra() As BABAS_IngresosCompra
      Get
         Return m_abas_ingresoscompra
      End Get
      Set(ByVal value As BABAS_IngresosCompra)
         m_abas_ingresoscompra = value
      End Set
   End Property

   Public Property ListABAS_OrdenesCompra() As List(Of EABAS_OrdenesCompra)
      Get
         Return m_listABAS_OrdenesCompra
      End Get
      Set(ByVal value As List(Of EABAS_OrdenesCompra))
         m_listABAS_OrdenesCompra = value
      End Set
   End Property

   Public Property Periodo() As String
      Get
         Return m_periodo
      End Get
      Set(ByVal value As String)
         m_periodo = value
      End Set
   End Property

   Public Property ABAS_DocsCompra() As BABAS_DocsCompra
      Get
         Return m_abas_docscompra
      End Get
      Set(ByVal value As BABAS_DocsCompra)
         m_abas_docscompra = value
      End Set
   End Property

   Public Property ABAS_OrdenesCompra() As BABAS_OrdenesCompra
      Get
         Return m_abas_ordenescompra
      End Get
      Set(ByVal value As BABAS_OrdenesCompra)
         m_abas_ordenescompra = value
      End Set
   End Property
#End Region

#Region " Funciones para obtencion de datos "

#End Region

#Region " Metodos "

   ''' <summary>
   ''' Grabar el ingreso de compra
   ''' </summary>
   ''' <param name="x_usuario">Usuario</param>
   ''' <param name="x_msg">Mensaje que se devuelve en caso de problemas</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GrabaIngresoCompra(ByVal x_usuario As String, ByRef x_msg As String) As Boolean
      Try
         '' Inicializar Clase Negocio 
         Dim m_babas_ingresoscompra As New BABAS_IngresosCompra() With {.ABAS_IngresosCompra = m_abas_ingresoscompra.ABAS_IngresosCompra}
         '' Id
         If m_abas_ingresoscompra.ABAS_IngresosCompra.Nuevo Then
            Dim _where As New Hashtable
            _where.Add("ALMAC_Id", New ACWhere(m_abas_ingresoscompra.ABAS_IngresosCompra.ALMAC_Id))
            m_babas_ingresoscompra.ABAS_IngresosCompra.INGCO_Id = m_babas_ingresoscompra.getCorrelativo("INGCO_Id", _where)
         End If
         '' Item de Documento de Compras
         Dim _whereDoc As New Hashtable
         _whereDoc.Add("DOCCO_Codigo", New ACWhere(m_abas_ingresoscompra.ABAS_IngresosCompra.DOCCO_Codigo))
         _whereDoc.Add("ENTID_CodigoProveedor", New ACWhere(m_abas_ingresoscompra.ABAS_IngresosCompra.ENTID_CodigoProveedor))
         m_babas_ingresoscompra.ABAS_IngresosCompra.INGCO_DCItem = m_babas_ingresoscompra.getCorrelativo("INGCO_DCItem", _whereDoc)


            If m_babas_ingresoscompra.ABAS_IngresosCompra.TIPOS_CodTipoDocumento = "CPD09" Then
                m_babas_ingresoscompra.ABAS_IngresosCompra.INGCO_Codigo = String.Format("{0}{1}{2}", m_babas_ingresoscompra.ABAS_IngresosCompra.TIPOS_CodTipoDocumento.Substring(3, 2), _
                                                                                         m_babas_ingresoscompra.ABAS_IngresosCompra.INGCO_Serie.Trim().PadLeft(3, "0"), _
                                                                                         m_babas_ingresoscompra.ABAS_IngresosCompra.INGCO_Numero.ToString().Trim().PadLeft(7, "0"))
            Else
                m_babas_ingresoscompra.ABAS_IngresosCompra.INGCO_Codigo = String.Format("{0}{1}{2}", m_babas_ingresoscompra.ABAS_IngresosCompra.TIPOS_CodTipoDocumento.Substring(3, 2), _
                                                                                        m_babas_ingresoscompra.ABAS_IngresosCompra.INGCO_Serie.Trim().PadLeft(5, "0"), _
                                                                                        m_babas_ingresoscompra.ABAS_IngresosCompra.INGCO_Numero.ToString().Trim().PadLeft(8, "0"))
            End If


            '' Iniciar transaccion

            DAEnterprise.BeginTransaction()
             '' Eliminar Detalle Si existe
            Dim _whereEli As New Hashtable
            _whereEli.Add("INGCO_Id", New ACWhere(m_babas_ingresoscompra.ABAS_IngresosCompra.INGCO_Id))
            Dim _ingdetalle As New BABAS_IngresosCompraDetalle
            _ingdetalle.Eliminar(_whereEli)


            '' Grabar el Registro
            If m_babas_ingresoscompra.Guardar(x_usuario, New String() {"INGCO_FechaIngreso"}) Then
                Dim i As Integer = 1
                '' Grabar los detalles
                For Each Item As EABAS_IngresosCompraDetalle In m_babas_ingresoscompra.ABAS_IngresosCompra.ListABAS_IngresosCompraDetalle
                    If Item.INGCD_Cantidad > 0 Then
                        Item.ALMAC_Id = m_abas_ingresoscompra.ABAS_IngresosCompra.ALMAC_Id
                        Item.INGCO_Id = m_babas_ingresoscompra.ABAS_IngresosCompra.INGCO_Id
                        Item.INGCO_Codigo = m_abas_ingresoscompra.ABAS_IngresosCompra.INGCO_Codigo
                        Item.INGCD_Item = i

                        Item.Instanciar(ACEInstancia.Nuevo)
                        i += 1
                        Dim m_babas_ingresoscompradetalle As New BABAS_IngresosCompraDetalle() With {.ABAS_IngresosCompraDetalle = Item}
                        m_babas_ingresoscompradetalle.Guardar(x_usuario)
                    End If
                Next
            Else
                DAEnterprise.RollBackTransaction()
                x_msg &= String.Format("- No se completo el grabado de la cabecera del pedido{0}", vbNewLine)
                Return False
            End If
            '' Completar Operaciones adicionales con el Pedido/Cotizacion
            '' Culminar la transaccion
            DAEnterprise.CommitTransaction()
            Return True
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
   End Function
     ''' <summary>
   ''' Grabar el ingreso de compra
   ''' </summary>
   ''' <param name="x_usuario">Usuario</param>
   ''' <param name="x_msg">Mensaje que se devuelve en caso de problemas</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GrabaIngresoCompraConfirmada(ByVal x_usuario As String, ByRef x_msg As String) As Boolean
      Try
         '' Inicializar Clase Negocio 
         Dim m_babas_ingresoscompra As New BABAS_IngresosCompra() With {.ABAS_IngresosCompra = m_abas_ingresoscompra.ABAS_IngresosCompra}
         '' Id
         If m_abas_ingresoscompra.ABAS_IngresosCompra.Nuevo Then
            Dim _where As New Hashtable
            _where.Add("ALMAC_Id", New ACWhere(m_abas_ingresoscompra.ABAS_IngresosCompra.ALMAC_Id))
            m_babas_ingresoscompra.ABAS_IngresosCompra.INGCO_Id = m_babas_ingresoscompra.getCorrelativo("INGCO_Id", _where)
         End If
         '' Item de Documento de Compras
         Dim _whereDoc As New Hashtable
         _whereDoc.Add("DOCCO_Codigo", New ACWhere(m_abas_ingresoscompra.ABAS_IngresosCompra.DOCCO_Codigo))
         _whereDoc.Add("ENTID_CodigoProveedor", New ACWhere(m_abas_ingresoscompra.ABAS_IngresosCompra.ENTID_CodigoProveedor))
         m_babas_ingresoscompra.ABAS_IngresosCompra.INGCO_DCItem = m_babas_ingresoscompra.getCorrelativo("INGCO_DCItem", _whereDoc)


            If m_babas_ingresoscompra.ABAS_IngresosCompra.TIPOS_CodTipoDocumento = "CPD09" Then
                m_babas_ingresoscompra.ABAS_IngresosCompra.INGCO_Codigo = String.Format("{0}{1}{2}", m_babas_ingresoscompra.ABAS_IngresosCompra.TIPOS_CodTipoDocumento.Substring(3, 2), _
                                                                                         m_babas_ingresoscompra.ABAS_IngresosCompra.INGCO_Serie.Trim().PadLeft(3, "0"), _
                                                                                         m_babas_ingresoscompra.ABAS_IngresosCompra.INGCO_Numero.ToString().Trim().PadLeft(7, "0"))
            Else
                m_babas_ingresoscompra.ABAS_IngresosCompra.INGCO_Codigo = String.Format("{0}{1}{2}", m_babas_ingresoscompra.ABAS_IngresosCompra.TIPOS_CodTipoDocumento.Substring(3, 2), _
                                                                                        m_babas_ingresoscompra.ABAS_IngresosCompra.INGCO_Serie.Trim().PadLeft(5, "0"), _
                                                                                        m_babas_ingresoscompra.ABAS_IngresosCompra.INGCO_Numero.ToString().Trim().PadLeft(8, "0"))
            End If


            '' Iniciar transaccion

            DAEnterprise.BeginTransaction()
            


            '' Grabar el Registro
            If m_babas_ingresoscompra.Guardar(x_usuario, New String() {"INGCO_FechaIngreso"}) Then
             ' Return true
            Else
                DAEnterprise.RollBackTransaction()
                x_msg &= String.Format("- No se completo el grabado de la cabecera del pedido{0}", vbNewLine)
                Return False
            End If
            '' Completar Operaciones adicionales con el Pedido/Cotizacion
            '' Culminar la transaccion
            DAEnterprise.CommitTransaction()
            Return True
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
   End Function

Public Function GrabaIngresoCompraT(ByVal x_usuario As String, ByRef x_msg As String) As Boolean
      Try
         '' Inicializar Clase Negocio 
         Dim m_babas_ingresoscompra As New BABAS_IngresosCompra() With {.ABAS_IngresosCompra = m_abas_ingresoscompra.ABAS_IngresosCompra}
         '' Id
         If m_abas_ingresoscompra.ABAS_IngresosCompra.Nuevo Then
            Dim _where As New Hashtable
            _where.Add("ALMAC_Id", New ACWhere(m_abas_ingresoscompra.ABAS_IngresosCompra.ALMAC_Id))
            m_babas_ingresoscompra.ABAS_IngresosCompra.INGCO_Id = m_babas_ingresoscompra.getCorrelativo("INGCO_Id", _where)
         End If
         '' Item de Documento de Compras
         Dim _whereDoc As New Hashtable
         _whereDoc.Add("DOCCO_Codigo", New ACWhere(m_abas_ingresoscompra.ABAS_IngresosCompra.DOCCO_Codigo))
         _whereDoc.Add("ENTID_CodigoProveedor", New ACWhere(m_abas_ingresoscompra.ABAS_IngresosCompra.ENTID_CodigoProveedor))
         m_babas_ingresoscompra.ABAS_IngresosCompra.INGCO_DCItem = m_babas_ingresoscompra.getCorrelativo("INGCO_DCItem", _whereDoc)


            If m_babas_ingresoscompra.ABAS_IngresosCompra.TIPOS_CodTipoDocumento = "CPD09" Then
                m_babas_ingresoscompra.ABAS_IngresosCompra.INGCO_Codigo = String.Format("{0}{1}{2}", m_babas_ingresoscompra.ABAS_IngresosCompra.TIPOS_CodTipoDocumento.Substring(3, 2), _
                                                                                         m_babas_ingresoscompra.ABAS_IngresosCompra.INGCO_Serie.Trim().PadLeft(3, "0"), _
                                                                                         m_babas_ingresoscompra.ABAS_IngresosCompra.INGCO_Numero.ToString().Trim().PadLeft(7, "0"))
            Else
                m_babas_ingresoscompra.ABAS_IngresosCompra.INGCO_Codigo = String.Format("{0}{1}{2}", m_babas_ingresoscompra.ABAS_IngresosCompra.TIPOS_CodTipoDocumento.Substring(3, 2), _
                                                                                        m_babas_ingresoscompra.ABAS_IngresosCompra.INGCO_Serie.Trim().PadLeft(5, "0"), _
                                                                                        m_babas_ingresoscompra.ABAS_IngresosCompra.INGCO_Numero.ToString().Trim().PadLeft(8, "0"))
            End If


            '' Iniciar transaccion

            DAEnterprise.BeginTransaction()
             '' Eliminar Detalle Si existe
            Dim _whereEli As New Hashtable
            _whereEli.Add("INGCO_Id", New ACWhere(m_babas_ingresoscompra.ABAS_IngresosCompra.INGCO_Id))
            Dim _ingdetalle As New BABAS_IngresosCompraDetalle
            _ingdetalle.Eliminar(_whereEli)


            '' Grabar el Registro
            If m_babas_ingresoscompra.Guardar(x_usuario, New String() {"INGCO_FechaIngreso"}) Then
                Dim i As Integer = 1
                '' Grabar los detalles
                For Each Item As EABAS_IngresosCompraDetalle In m_babas_ingresoscompra.ABAS_IngresosCompra.ListABAS_IngresosCompraDetalle
                    If Item.INGCD_Cantidad > 0 Then
                        Item.ALMAC_Id = m_abas_ingresoscompra.ABAS_IngresosCompra.ALMAC_Id
                        Item.INGCO_Id = m_babas_ingresoscompra.ABAS_IngresosCompra.INGCO_Id
                        Item.INGCO_Codigo = m_abas_ingresoscompra.ABAS_IngresosCompra.INGCO_Codigo
                        Item.INGCD_Item = i

                        Item.Instanciar(ACEInstancia.Nuevo)
                        i += 1
                        Dim m_babas_ingresoscompradetalle As New BABAS_IngresosCompraDetalle() With {.ABAS_IngresosCompraDetalle = Item}
                        m_babas_ingresoscompradetalle.Guardar(x_usuario)
                    End If
                Next

                For Each Item As EABAS_IngresosCompraDetalle In m_abas_ingresoscompra.ABAS_IngresosCompra.ListABAS_IngresosCompraDetalle
                    ' Actualiza el registro si este fue modificado
                 

                    Dim m_manejarStocks As New BManejarStock()
                    m_manejarStocks.LOG_Stocks = New ELOG_Stocks
                    m_manejarStocks.LOG_Stocks.TIPOS_CodTipoUnidad = Item.TIPOS_CodUnidadMedida
                    m_manejarStocks.LOG_Stocks.INGCO_Id = Item.INGCO_Id
                    m_manejarStocks.LOG_Stocks.STOCK_LoteGeneral=Item.INGCD_Lotegeneral
                    m_manejarStocks.LOG_Stocks.STOCK_Lote=Item.INGCD_Lote
                    m_manejarStocks.LOG_Stocks.INGCD_Item = Item.INGCD_Item
               '' Actualizar los Stock del articulo Actual
                        m_manejarStocks.Ingreso(m_periodo, Item.ARTIC_Codigo, Item.TIPOS_CodUnidadMedida, m_abas_ingresoscompra.ABAS_IngresosCompra.ALMAC_Id, Item.INGCD_Cantidad, m_abas_ingresoscompra.ABAS_IngresosCompra.INGCO_FechaIngreso, ACEVentas.ETipos.getTipo(ACEVentas.ETipos.TMovimientoStock.IngresoCompra), x_usuario)
                   
                    ''
                Next



            Else
                DAEnterprise.RollBackTransaction()
                x_msg &= String.Format("- No se completo el grabado de la cabecera del pedido{0}", vbNewLine)
                Return False
            End If
            '' Completar Operaciones adicionales con el Pedido/Cotizacion
            '' Culminar la transaccion
            DAEnterprise.CommitTransaction()
            Return True
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
   End Function




    Public Function GrabaIngresoCompradetalle(ByVal m_lista_detalle As List(Of EABAS_IngresosCompraDetalle),
                                              ByVal usuario As String) As Boolean
        Try
            '' Inicializar Clase Negocio 
            Dim _detallesIngreos As New EABAS_IngresosCompraDetalle
            'managerlprecios.ListABAS_IngresosCompraDetalle = New List(Of EABAS_IngresosCompraDetalle)
            m_list_docsingresosdetalle = New List(Of EABAS_IngresosCompraDetalle)
            'managerlprecios.ListABAS_IngresosCompraDetalle = m_listadetalle
            m_list_docsingresosdetalle = m_lista_detalle



            '' Grabar los detalles
            For Each Item As EABAS_IngresosCompraDetalle In m_list_docsingresosdetalle
                If Item.INGCD_Cantidad > 0 Then
                    
                    'Item.ARTIC_Codigo = _detallesIngreos.ARTIC_Codigo
                    'Item.INGCD_Item = _detallesIngreos.INGCD_Item
                    'Item.INGCO_Id = _detallesIngreos.INGCO_Id
                    'Item.INGCO_Revisado = _detallesIngreos.INGCO_Revisado
                    'Item.INGCO_REVISADO_USER = _detallesIngreos.INGCO_REVISADO_USER
                    'Item.INGCO_REVISADO_FECHA = _detallesIngreos.INGCO_REVISADO_FECHA

                    'Item.ALMAC_Id = _detallesIngreos.ALMAC_Id
                    'Item.TIPOS_CodTipoDestino = _detallesIngreos.TIPOS_CodTipoDestino
                    'Item.INGCD_CantidadTotal = _detallesIngreos.INGCD_CantidadTotal
                    'Item.INGCD_Cantidad = _detallesIngreos.INGCD_Cantidad
                    'Item.INGCD_PesoUnitario = _detallesIngreos.INGCD_PesoUnitario
                    'Item.INGCD_UsrCrea = _detallesIngreos.INGCD_UsrCrea
                    'Item.INGCD_FecCrea = _detallesIngreos.INGCD_FecCrea
                    'Item.INGCD_UsrMod = _detallesIngreos.INGCD_UsrMod
                    'Item.INGCD_FecMod = _detallesIngreos.INGCD_FecMod
                    'Item.INGCO_Codigo = _detallesIngreos.INGCO_Codigo



                    Item.Instanciar(ACEInstancia.Modificado)

                    Dim m_babas_ingresoscompradetalle As New BABAS_IngresosCompraDetalle() With {.ABAS_IngresosCompraDetalle = Item}
                    m_babas_ingresoscompradetalle.Guardardet_a(usuario)
                Else
                    DAEnterprise.RollBackTransaction()
                    MsgBox(String.Format("- No se completo el grabado de la cabecera del pedido{0}", vbNewLine))
                    Return False
                End If
            Next

            DAEnterprise.CommitTransaction()
            Return True
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
    End Function



   ''' <summary>
   ''' grabar confirmacion de ingreso de compras
   ''' </summary>
   ''' <param name="x_usuario"></param>
   ''' <param name="x_msg"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GrabaIngresoCompraCOnfirmacion(ByVal x_usuario As String, ByRef x_msg As String) As Boolean
      Try
         '' Inicializar Clase Negocio 
         Dim m_babas_ingresoscompra As New BABAS_IngresosCompra() With {.ABAS_IngresosCompra = m_abas_ingresoscompra.ABAS_IngresosCompra}
         '' Id
         Dim _where As New Hashtable
         _where.Add("ALMAC_Id", New ACWhere(m_abas_ingresoscompra.ABAS_IngresosCompra.ALMAC_Id))
         m_babas_ingresoscompra.ABAS_IngresosCompra.INGCO_Id = m_babas_ingresoscompra.getCorrelativo("INGCO_Id", _where)
         '' Item de Documento de Compras
         Dim _whereDoc As New Hashtable
         _whereDoc.Add("DOCCO_Codigo", New ACWhere(m_abas_ingresoscompra.ABAS_IngresosCompra.DOCCO_Codigo))
         _whereDoc.Add("ENTID_CodigoProveedor", New ACWhere(m_abas_ingresoscompra.ABAS_IngresosCompra.ENTID_CodigoProveedor))
         m_babas_ingresoscompra.ABAS_IngresosCompra.INGCO_DCItem = m_babas_ingresoscompra.getCorrelativo("INGCO_DCItem", _whereDoc)
         '' Iniciar transaccion

            If m_babas_ingresoscompra.ABAS_IngresosCompra.TIPOS_CodTipoDocumento = "CPD09" Then
                m_babas_ingresoscompra.ABAS_IngresosCompra.INGCO_Codigo = String.Format("{0}{1}{2}", m_babas_ingresoscompra.ABAS_IngresosCompra.TIPOS_CodTipoDocumento.Substring(3, 2), _
                                                                                         m_babas_ingresoscompra.ABAS_IngresosCompra.INGCO_Serie.Trim().PadLeft(3, "0"), _
                                                                                         m_babas_ingresoscompra.ABAS_IngresosCompra.INGCO_Numero.ToString().Trim().PadLeft(7, "0"))
            Else
                m_babas_ingresoscompra.ABAS_IngresosCompra.INGCO_Codigo = String.Format("{0}{1}{2}", m_babas_ingresoscompra.ABAS_IngresosCompra.TIPOS_CodTipoDocumento.Substring(3, 2), _
                                                                                        m_babas_ingresoscompra.ABAS_IngresosCompra.INGCO_Serie.Trim().PadLeft(5, "0"), _
                                                                                        m_babas_ingresoscompra.ABAS_IngresosCompra.INGCO_Numero.ToString().Trim().PadLeft(8, "0"))
            End If

         DAEnterprise.BeginTransaction()
         If m_babas_ingresoscompra.Guardar(x_usuario) Then
            Dim i As Integer = 1
            '' Grabar los detalles
            For Each Item As EABAS_IngresosCompraDetalle In m_babas_ingresoscompra.ABAS_IngresosCompra.ListABAS_IngresosCompraDetalle
               If Item.INGCD_Cantidad > 0 Then
                  Item.ALMAC_Id = m_abas_ingresoscompra.ABAS_IngresosCompra.ALMAC_Id
                  Item.INGCO_Id = m_babas_ingresoscompra.ABAS_IngresosCompra.INGCO_Id
                  Item.INGCD_Item = i
                  Item.Instanciar(ACEInstancia.Nuevo)
                  i += 1
                  Dim m_babas_ingresoscompradetalle As New BABAS_IngresosCompraDetalle() With {.ABAS_IngresosCompraDetalle = Item}
                  m_babas_ingresoscompradetalle.Guardar(x_usuario)
                  Item.Instanciar(ACEInstancia.Consulta)
               End If
            Next
            GrabarConfirmacion(m_babas_ingresoscompra.ABAS_IngresosCompra.ALMAC_Id, m_babas_ingresoscompra.ABAS_IngresosCompra.TIPOS_CodTipoDocumento, x_usuario, False)
         Else
            DAEnterprise.RollBackTransaction()
            x_msg &= String.Format("- No se completo el grabado de la cabecera del pedido{0}", vbNewLine)
            Return False
         End If
         DAEnterprise.CommitTransaction()
         Return True
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Cargar el detalle de la orden de cargar con la diferencia faltante
   ''' </summary>
   ''' <param name="x_ordco_codigo"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function cargarDetDif(ByVal x_ordco_codigo As String) As Boolean
      Try
         m_abas_ingresoscompra.ABAS_IngresosCompra.ListABAS_IngresosCompraDetalle = New List(Of EABAS_IngresosCompraDetalle)()
         Return d_generarregmerctransito.cargarDetDif(m_abas_ingresoscompra.ABAS_IngresosCompra.ListABAS_IngresosCompraDetalle, x_ordco_codigo)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Cargar la diferencia pendiente
   ''' </summary>
   ''' <param name="x_docco_codigo">codigo del documento de compra</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function cargarDetDifDocCompra(ByVal x_docco_codigo As String) As Boolean
      Try
         m_abas_ingresoscompra.ABAS_IngresosCompra.ListABAS_IngresosCompraDetalle = New List(Of EABAS_IngresosCompraDetalle)()
         Return d_generarregmerctransito.LOG_DOCCOSS_ObtenerSaldoEntrega(m_abas_ingresoscompra.ABAS_IngresosCompra.ListABAS_IngresosCompraDetalle, x_docco_codigo)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' cargar la diferencia de la orden de compra
   ''' </summary>
   ''' <param name="x_ordco_codigo">codigo de la orden de compra</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function cargarDetDifOrden(ByVal x_ordco_codigo As String) As Boolean
      Try
         m_abas_ingresoscompra.ABAS_IngresosCompra.ListABAS_IngresosCompraDetalle = New List(Of EABAS_IngresosCompraDetalle)()
         Return d_generarregmerctransito.LOG_ORDENSS_ObtenerSaldoEntrega(m_abas_ingresoscompra.ABAS_IngresosCompra.ListABAS_IngresosCompraDetalle, x_ordco_codigo)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Grabar comnfirmacion de ingreso de compra
   ''' </summary>
   ''' <param name="x_almac_id">codigo del almacen</param>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <param name="x_tipos_codtipodocumento">codigo de tipo de documento</param>
   ''' <param name="x_tran">opcion para iniciar las transacciones</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GrabarConfirmacion(ByVal x_almac_id As Short, ByVal x_usuario As String, ByVal x_tipos_codtipodocumento As String, ByVal x_tran As Boolean) As Boolean
      Try
         If x_tran Then DAEnterprise.BeginTransaction()
            Dim m_babas_ingresoacompradetalle As New BABAS_IngresosCompraDetalle

            Dim m_babas_ingresoacompra As New BABAS_IngresosCompra
            If (m_abas_ingresoscompra.ABAS_IngresosCompra.TIPOS_CodTipoDocumento = "CPD07" And m_abas_ingresoscompra.ABAS_IngresosCompra.ORDCO_Codigo <> Nothing) Then

                m_babas_ingresoacompra.ABAS_IngresosCompra = New EABAS_IngresosCompra
                m_babas_ingresoacompra.ABAS_IngresosCompra.INGCO_Serie = m_abas_ingresoscompra.ABAS_IngresosCompra.INGCO_Serie
                m_babas_ingresoacompra.ABAS_IngresosCompra.INGCO_Numero = m_abas_ingresoscompra.ABAS_IngresosCompra.INGCO_Numero
                m_babas_ingresoacompra.ABAS_IngresosCompra.ORDCO_Codigo = m_abas_ingresoscompra.ABAS_IngresosCompra.ORDCO_Codigo
                m_babas_ingresoacompra.ABAS_IngresosCompra.INGCO_Id = m_abas_ingresoscompra.ABAS_IngresosCompra.INGCO_Id
                m_babas_ingresoacompra.ABAS_IngresosCompra.ALMAC_Id = m_abas_ingresoscompra.ABAS_IngresosCompra.ALMAC_Id
                m_babas_ingresoacompra.ABAS_IngresosCompra.Instanciar(ACEInstancia.Modificado)
                m_babas_ingresoacompra.ABAS_IngresosCompra.INGCO_Estado = EABAS_IngresosCompra.getEstado(EABAS_IngresosCompra.Estado.Confirmado)
                If m_babas_ingresoacompra.Guardar(x_usuario) Then
                    If x_tran Then DAEnterprise.CommitTransaction()
                    Return True
                Else
                    If x_tran Then DAEnterprise.RollBackTransaction()
                    Return False
                End If

            Else
                For Each Item As EABAS_IngresosCompraDetalle In m_abas_ingresoscompra.ABAS_IngresosCompra.ListABAS_IngresosCompraDetalle
                    ' Actualiza el registro si este fue modificado
                    m_babas_ingresoacompradetalle.ABAS_IngresosCompraDetalle = Item
                    'm_babas_ingresoacompradetalle.Guardar(x_usuario)

                    Dim m_manejarStocks As New BManejarStock()
                    m_manejarStocks.LOG_Stocks = New ELOG_Stocks
                    m_manejarStocks.LOG_Stocks.TIPOS_CodTipoUnidad = Item.TIPOS_CodUnidadMedida
                    m_manejarStocks.LOG_Stocks.INGCO_Id = Item.INGCO_Id
                    m_manejarStocks.LOG_Stocks.INGCD_Item = Item.INGCD_Item
                    m_manejarStocks.LOG_Stocks.STOCK_LoteGeneral=Item.INGCD_LoteGeneral
                    m_manejarStocks.LOG_Stocks.STOCK_Lote=Item.INGCD_Lote
                    If x_tipos_codtipodocumento.Equals(ACEVentas.ETipos.getTipoComprobante(ACEVentas.ETipos.TipoComprobanteVenta.NotaCredito)) Then
                        '' Actualizar los Stock del articulo Actual
                        m_manejarStocks.Egreso(m_periodo, Item.ARTIC_Codigo, Item.TIPOS_CodUnidadMedida, x_almac_id, Item.INGCD_Cantidad, m_abas_ingresoscompra.ABAS_IngresosCompra.INGCO_FechaIngreso, ACEVentas.ETipos.getTipo(ACEVentas.ETipos.TMovimientoStock.IngresoCompra), x_usuario)
                    Else
                        '' Actualizar los Stock del articulo Actual
                        m_manejarStocks.Ingreso(m_periodo, Item.ARTIC_Codigo, Item.TIPOS_CodUnidadMedida, x_almac_id, Item.INGCD_Cantidad, m_abas_ingresoscompra.ABAS_IngresosCompra.INGCO_FechaIngreso, ACEVentas.ETipos.getTipo(ACEVentas.ETipos.TMovimientoStock.IngresoCompra), x_usuario)
                    End If

                    ''
                Next

                ' Cambiar de estado al ingreso con confirmado

                m_babas_ingresoacompra.ABAS_IngresosCompra = New EABAS_IngresosCompra
                m_babas_ingresoacompra.ABAS_IngresosCompra.INGCO_Serie = m_abas_ingresoscompra.ABAS_IngresosCompra.INGCO_Serie
                m_babas_ingresoacompra.ABAS_IngresosCompra.INGCO_Numero = m_abas_ingresoscompra.ABAS_IngresosCompra.INGCO_Numero
                m_babas_ingresoacompra.ABAS_IngresosCompra.ORDCO_Codigo = m_abas_ingresoscompra.ABAS_IngresosCompra.ORDCO_Codigo
                m_babas_ingresoacompra.ABAS_IngresosCompra.INGCO_Id = m_abas_ingresoscompra.ABAS_IngresosCompra.INGCO_Id
                m_babas_ingresoacompra.ABAS_IngresosCompra.ALMAC_Id = m_abas_ingresoscompra.ABAS_IngresosCompra.ALMAC_Id
                m_babas_ingresoacompra.ABAS_IngresosCompra.Instanciar(ACEInstancia.Modificado)
                m_babas_ingresoacompra.ABAS_IngresosCompra.INGCO_Estado = EABAS_IngresosCompra.getEstado(EABAS_IngresosCompra.Estado.Confirmado)
                If m_babas_ingresoacompra.Guardar(x_usuario) Then
                    If x_tran Then DAEnterprise.CommitTransaction()
                    Return True
                Else
                    If x_tran Then DAEnterprise.RollBackTransaction()
                    Return False
                End If
            End If
        Catch ex As Exception
            If x_tran Then DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
   End Function

   ''' <summary>
   ''' busqueda de documentos de compra registrados
   ''' </summary>
   ''' <param name="x_cadena">cadena de busqueda</param>
   ''' <param name="x_campo">campo de busqueda</param>
   ''' <param name="x_todos">cargar todos los registros, incluidos los anulados</param>
   ''' <param name="x_fecini">fecha inicial de busqueda</param>
   ''' <param name="x_fecfin">fecha final de busqueda</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function BusquedaDocsRegCompra(ByVal x_cadena As String, ByVal x_campo As String, ByVal x_todos As Boolean, ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime) As Boolean
      Try
         Dim _join As New List(Of ACJoin)
         _join.Add(New ACJoin(EEntidades.Esquema, EEntidades.Tabla, "Ent", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_CodigoProveedor")} _
                            , New ACCampos() {New ACCampos("ENTID_RazonSocial", "ENTID_Proveedor")}))
         _join.Add(New ACJoin(EAlmacenes.Esquema, EAlmacenes.Tabla, "Alma", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("ALMAC_Id", "ALMAC_Id")} _
                            , New ACCampos() {New ACCampos("ALMAC_Descripcion", "ALMAC_Descripcion")}))
         _join.Add(New ACJoin(ACEVentas.ETipos.Esquema, ACEVentas.ETipos.Tabla, "TDoc", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoDocumento")} _
                            , New ACCampos() {New ACCampos("TIPOS_DescCorta", "TIPOS_Documento")}))
         _join.Add(New ACJoin(ACEVentas.ETipos.Esquema, ACEVentas.ETipos.Tabla, "TMone", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoMoneda")} _
                            , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_TipoMoneda")}))
         _join.Add(New ACJoin(ACEVentas.ETipos.Esquema, ACEVentas.ETipos.Tabla, "TPag", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoPago")} _
                            , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_TipoPago")}))

         Dim _where As New Hashtable()
         If x_campo.Contains("ENTID") Then
            _where.Add(x_campo, New ACWhere(x_cadena, "Ent", "System.String", ACWhere.TipoWhere._Like))
         Else
            _where.Add(x_campo, New ACWhere(x_cadena, ACWhere.TipoWhere._Like))
         End If
         _where.Add("DOCCO_FechaDocumento", New ACWhere(x_fecini, x_fecfin, ACWhere.TipoWhere.Between))
         If Not x_todos Then
            _where.Add("DOCCO_Estado", New ACWhere(EABAS_IngresosCompra.getEstado(EABAS_IngresosCompra.Estado.Anulado), ACWhere.TipoWhere.Diferente))
         End If

         m_listABAS_DocsCompra = New List(Of EABAS_DocsCompra)
         Return d_generarregmerctransito.BusquedaDocsRegCompra(m_listABAS_DocsCompra, EABAS_DocsCompra.Esquema, EABAS_DocsCompra.Tabla, _join, _where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Busqueda de coumentos registrados usando la orden de compra
   ''' </summary>
   ''' <param name="x_cadena">cadena de busqueda</param>
   ''' <param name="x_campo">campo de busqueda</param>
   ''' <param name="x_todos">mostrar todos incluidos los anulados</param>
   ''' <param name="x_fecini">fecha inicial de buqeuda</param>
   ''' <param name="x_fecfin">fecha final de busqueda</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function BusquedaDocsRegCompraOrden(ByVal x_cadena As String, ByVal x_campo As String, ByVal x_todos As Boolean, ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime) As Boolean
      Try
         Dim _join As New List(Of ACJoin)
         _join.Add(New ACJoin(EEntidades.Esquema, EEntidades.Tabla, "Ent", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_CodigoProveedor")} _
                            , New ACCampos() {New ACCampos("ENTID_RazonSocial", "ENTID_Proveedor")}))
         _join.Add(New ACJoin(EAlmacenes.Esquema, EAlmacenes.Tabla, "Alma", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("ALMAC_Id", "ALMAC_Id")} _
                            , New ACCampos() {New ACCampos("ALMAC_Descripcion", "ALMAC_Descripcion")}))
         _join.Add(New ACJoin(ACEVentas.ETipos.Esquema, ACEVentas.ETipos.Tabla, "TMone", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoMoneda")} _
                            , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_TipoMoneda")}))

         Dim _where As New Hashtable()
         If x_campo.Contains("ENTID") Then
            _where.Add(x_campo, New ACWhere(x_cadena, "Ent", "System.String", ACWhere.TipoWhere._Like))
         Else
            _where.Add(x_campo, New ACWhere(x_cadena, ACWhere.TipoWhere._Like))
         End If
         _where.Add("ORDCO_FechaDocumento", New ACWhere(x_fecini, x_fecfin, ACWhere.TipoWhere.Between))
         If Not x_todos Then
            _where.Add("ORDCO_Estado", New ACWhere(EABAS_IngresosCompra.getEstado(EABAS_IngresosCompra.Estado.Anulado), ACWhere.TipoWhere.Diferente))
         End If

         m_listABAS_OrdenesCompra = New List(Of EABAS_OrdenesCompra)
         Return d_generarregmerctransito.BusquedaDocsRegCompraOrden(m_listABAS_OrdenesCompra, EABAS_OrdenesCompra.Esquema, EABAS_OrdenesCompra.Tabla, _join, _where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary> 
   ''' Capa de Negocio: LOG_INGCOSS_IngresoCompras
   ''' </summary>
   ''' <param name="x_cadena">Parametro 1: </param> 
   ''' <param name="x_opcion">Parametro 2: </param> 
   ''' <param name="x_todos">Parametro 3: </param> 
   ''' <param name="x_fecini">Parametro 4: </param> 
   ''' <param name="x_fecfin">Parametro 5: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function LOG_INGCOSS_IngresoCompras(ByVal x_cadena As String, ByVal x_opcion As Short, ByVal x_todos As Boolean, ByVal x_fecini As Date, ByVal x_fecfin As Date) As Boolean
      m_listabas_ordenescompra = New List(Of EABAS_OrdenesCompra)
      Try
         Return d_generarregmerctransito.LOG_INGCOSS_IngresoCompras(m_listABAS_OrdenesCompra, x_cadena, x_opcion, x_todos, x_fecini, x_fecfin)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Busqueda de documentos de compra
   ''' </summary>
   ''' <param name="x_doc"></param>
   ''' <param name="x_serie"></param>
   ''' <param name="x_numero"></param>
   ''' <param name="x_todos"></param>
   ''' <param name="x_fecini"></param>
   ''' <param name="x_fecfin"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function BusquedaDocsRegCompra(ByVal x_doc As String, ByVal x_serie As String, ByVal x_numero As String, ByVal x_todos As Boolean _
                            , ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime) As Boolean
      Try
         Dim _join As New List(Of ACJoin)
         _join.Add(New ACJoin(EEntidades.Esquema, EEntidades.Tabla, "Ent", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_CodigoProveedor")} _
                            , New ACCampos() {New ACCampos("ENTID_RazonSocial", "ENTID_Proveedor")}))
         _join.Add(New ACJoin(EAlmacenes.Esquema, EAlmacenes.Tabla, "Alma", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("ALMAC_Id", "ALMAC_Id")} _
                            , New ACCampos() {New ACCampos("ALMAC_Descripcion", "ALMAC_Descripcion")}))
         _join.Add(New ACJoin(ACEVentas.ETipos.Esquema, ACEVentas.ETipos.Tabla, "TDoc", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoDocumento")} _
                            , New ACCampos() {New ACCampos("TIPOS_DescCorta", "TIPOS_Documento")}))
         _join.Add(New ACJoin(ACEVentas.ETipos.Esquema, ACEVentas.ETipos.Tabla, "TMone", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoMoneda")} _
                            , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_TipoMoneda")}))
         _join.Add(New ACJoin(ACEVentas.ETipos.Esquema, ACEVentas.ETipos.Tabla, "TPag", ACJoin.TipoJoin.Inner _
                            , New ACCampos() {New ACCampos("TIPOS_Codigo", "TIPOS_CodTipoPago")} _
                            , New ACCampos() {New ACCampos("TIPOS_Descripcion", "TIPOS_TipoPago")}))
         Dim _where As New Hashtable()
         _where.Add("TIPOS_CodTipoDocumento", New ACWhere(x_doc, ACWhere.TipoWhere._Like))
         _where.Add("DOCCO_Serie", New ACWhere(x_serie, ACWhere.TipoWhere._Like))
         _where.Add("DOCCO_Numero", New ACWhere(x_numero, ACWhere.TipoWhere._Like))
         _where.Add("DOCCO_FechaDocumento", New ACWhere(x_fecini, x_fecfin, ACWhere.TipoWhere.Between))
         If Not x_todos Then
            _where.Add("DOCCO_Estado", New ACWhere(EABAS_IngresosCompra.getEstado(EABAS_IngresosCompra.Estado.Ingresado), ACWhere.TipoWhere.Igual))
         End If
         m_listABAS_DocsCompra = New List(Of EABAS_DocsCompra)
         Return d_generarregmerctransito.BusquedaDocsRegCompra(m_listABAS_DocsCompra, EABAS_DocsCompra.Esquema, EABAS_DocsCompra.Tabla, _join, _where)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Busqueda de documentos 
   ''' </summary>
   ''' <param name="x_cadena">cadena de busqueda</param>
   ''' <param name="x_campo">campo de busqueda</param>
   ''' <param name="x_todos">mostrar todos los registros incluidos los anulados</param>
   ''' <param name="x_fecini">fecha inicialde busqueda</param>
   ''' <param name="x_fecfin">fecha final de busqueda</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function Busqueda(ByVal x_cadena As String, ByVal x_campo As String, ByVal x_todos As Boolean, ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime) As Boolean
      Try
         m_abas_ingresoscompra = New BABAS_IngresosCompra
         Return m_abas_ingresoscompra.Busqueda(x_cadena, x_campo, x_todos, x_fecini, x_fecfin)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Consulta de documentos de compra
   ''' </summary>
   ''' <param name="x_cadena">cadena de busqueda</param>
   ''' <param name="x_campo">campo de busqueda</param>
   ''' <param name="x_todos">mostrar todos los registros</param>
   ''' <param name="x_fecini">fecha inicial de busquedaq</param>
   ''' <param name="x_fecfin">fecha final de busqueda</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function Consulta(ByVal x_cadena As String, ByVal x_campo As Short, ByVal x_todos As Boolean, ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime) As Boolean
      Try
         m_abas_ingresoscompra = New BABAS_IngresosCompra
         Return m_abas_ingresoscompra.Consulta(x_cadena, x_campo, x_todos, x_fecini, x_fecfin)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

     ''' <summary>
   ''' Consulta de documentos ingreso por transformacion
   ''' </summary>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function ConsultaIT(ByVal x_cadena As String, ByVal x_campo As Short, ByVal x_tipo As String, ByVal x_todos As Boolean, ByVal x_fecini As DateTime, ByVal x_fecfin As DateTime) As Boolean
      Try
         m_abas_ingresoscompra = New BABAS_IngresosCompra
         Return m_abas_ingresoscompra.ConsultaIT(x_cadena, x_campo , x_tipo, x_todos, x_fecini, x_fecfin)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' busqueda de documentos de compras
   ''' </summary>
   ''' <param name="x_tconsulta">tipo de consulta</param>
   ''' <param name="x_cadena">cadena de busqueda</param>
   ''' <param name="x_opciontc">opcion de busqueda de tipo de consulta</param>
   ''' <param name="x_todos">mostrar todos los registros incluidos los anulados</param>
   ''' <param name="x_fecini">fecha inicial de busqueda</param>
   ''' <param name="x_fecfin">fecha final de busqueda</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function BusquedaOrdenesCompras(ByVal x_tconsulta As TConsulta, ByVal x_cadena As String, ByVal x_opciontc As Short, ByVal x_todos As Boolean, ByVal x_fecini As Date, ByVal x_fecfin As Date) As Boolean
      Try
         If x_tconsulta = TConsulta.Ordenes Then
            m_abas_ordenescompra = New BABAS_OrdenesCompra
            m_abas_ordenescompra.ListABAS_OrdenesCompra = New List(Of EABAS_OrdenesCompra)
            Return m_abas_ordenescompra.ConsultaOrdenes(x_cadena, x_opciontc, x_todos, x_fecini, x_fecfin)
         ElseIf x_tconsulta = TConsulta.Compras Then
            m_abas_docscompra = New BABAS_DocsCompra
            m_abas_docscompra.ListABAS_DocsCompra = New List(Of EABAS_DocsCompra)
            Return m_abas_docscompra.ConsultaCompras(x_cadena, x_opciontc, x_todos, x_fecini, x_fecfin)
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' Convertir orden de compra en ingreso de compra
   ''' </summary>
   ''' <param name="x_tconsulta"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function ConvertToIngreso(ByVal x_tconsulta As TConsulta) As Boolean
      Try
         If x_tconsulta = TConsulta.Compras Then
            ToIngreso()
         ElseIf x_tconsulta = TConsulta.Ordenes Then
            OrdenesToIngreso(m_abas_ordenescompra.ABAS_OrdenesCompra.ORDCO_Codigo)
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' convertir a ingreso de compra
   ''' </summary>
   ''' <remarks></remarks>
   Private Sub ToIngreso()
      Try
         If m_abas_docscompra.Cargar(m_abas_docscompra.ABAS_DocsCompra.DOCCO_Codigo, m_abas_docscompra.ABAS_DocsCompra.ENTID_CodigoProveedor) Then
            m_abas_ordenescompra = New BABAS_OrdenesCompra
            If IsNothing(m_abas_docscompra.ABAS_DocsCompra.ORDCO_Codigo) Then
               ComprasToIngresos(m_abas_docscompra.ABAS_DocsCompra.DOCCO_Codigo, m_abas_docscompra.ABAS_DocsCompra.ENTID_CodigoProveedor)
            Else
               OrdenesToIngreso(m_abas_docscompra.ABAS_DocsCompra.ORDCO_Codigo)
            End If
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   ''' <summary>
   ''' convertir documento de compra en ingreso de compra
   ''' </summary>
   ''' <param name="x_docco_codigo">codigo de documento de compra</param>
   ''' <param name="x_entid_codigo">codigo de entidad</param>
   ''' <remarks></remarks>
   Private Sub ComprasToIngresos(ByVal x_docco_codigo As String, ByVal x_entid_codigo As String)
      Try
         If m_abas_docscompra.Cargar(x_docco_codigo, x_entid_codigo, True) Then
            m_abas_ingresoscompra.ABAS_IngresosCompra = New EABAS_IngresosCompra
            cargarDetDifDocCompra(x_docco_codigo)
            m_abas_ingresoscompra.ABAS_IngresosCompra.Instanciar(ACEInstancia.Nuevo)
            m_abas_ingresoscompra.ABAS_IngresosCompra.ALMAC_Id = m_abas_docscompra.ABAS_DocsCompra.ALMAC_Id
                'm_abas_ingresoscompra.ABAS_IngresosCompra.ORDCO_Codigo = m_abas_docscompra.ABAS_DocsCompra.DOCCO_Codigo
            m_abas_ingresoscompra.ABAS_IngresosCompra.ENTID_CodigoProveedor = m_abas_docscompra.ABAS_DocsCompra.ENTID_CodigoProveedor
            m_abas_ingresoscompra.ABAS_IngresosCompra.ENTID_Proveedor = m_abas_docscompra.ABAS_DocsCompra.ENTID_Proveedor
            m_abas_ingresoscompra.ABAS_IngresosCompra.INGCO_Estado = EABAS_IngresosCompra.getEstado(EABAS_IngresosCompra.Estado.Ingresado)

         Else
            m_abas_ingresoscompra.ABAS_IngresosCompra.ListABAS_IngresosCompraDetalle = New List(Of EABAS_IngresosCompraDetalle)
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   ''' <summary>
   ''' convertir orden de compra a ingreso de compra
   ''' </summary>
   ''' <param name="x_ordco_codigo">orden de compra</param>
   ''' <remarks></remarks>
   Private Sub OrdenesToIngreso(ByVal x_ordco_codigo As String)
      Try
         If m_abas_ordenescompra.Cargar(x_ordco_codigo, False) Then
            m_abas_ingresoscompra.ABAS_IngresosCompra = New EABAS_IngresosCompra
            cargarDetDifOrden(m_abas_ordenescompra.ABAS_OrdenesCompra.ORDCO_Codigo)
            m_abas_ingresoscompra.ABAS_IngresosCompra.Instanciar(ACEInstancia.Nuevo)
            m_abas_ingresoscompra.ABAS_IngresosCompra.ALMAC_Id = m_abas_ordenescompra.ABAS_OrdenesCompra.ALMAC_Id
                'm_abas_ingresoscompra.ABAS_IngresosCompra.ORDCO_Codigo = m_abas_ordenescompra.ABAS_OrdenesCompra.ORDCO_Codigo
            m_abas_ingresoscompra.ABAS_IngresosCompra.ENTID_CodigoProveedor = m_abas_ordenescompra.ABAS_OrdenesCompra.ENTID_CodigoProveedor
            m_abas_ingresoscompra.ABAS_IngresosCompra.ENTID_Proveedor = m_abas_ordenescompra.ABAS_OrdenesCompra.ENTID_Proveedor
            m_abas_ingresoscompra.ABAS_IngresosCompra.INGCO_Estado = EABAS_IngresosCompra.getEstado(EABAS_IngresosCompra.Estado.Ingresado)

         Else
            m_abas_ingresoscompra.ABAS_IngresosCompra.ListABAS_IngresosCompraDetalle = New List(Of EABAS_IngresosCompraDetalle)
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   ''' <summary>
   ''' cargar ingreso de compra
   ''' </summary>
   ''' <param name="x_ingco_id">codigo de ingreso de compra</param>
   ''' <param name="x_almac_id">codigo de almacen</param>
   ''' <param name="x_opcion">opcion de busqueda</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function CargarIngreso(ByVal x_ingco_id As Long, ByVal x_almac_id As Short, ByVal x_opcion As Boolean) As Boolean
      Try
         m_abas_ingresoscompra = New BABAS_IngresosCompra
         Return m_abas_ingresoscompra.Cargar(x_ingco_id, x_almac_id, x_opcion)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   ''' <summary>
   ''' anular confirmacion de mercaderia en transito
   ''' </summary>
   ''' <param name="x_stock">opcion para confirmar la anulacion de movimiento de stoc</param>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function AnularConfMercaderia(ByVal x_stock As Boolean, ByVal x_usuario As String) As Boolean
      Try
         DAEnterprise.BeginTransaction()
         Dim _bingcompra As New BABAS_IngresosCompra
         _bingcompra.ABAS_IngresosCompra = New EABAS_IngresosCompra
         _bingcompra.ABAS_IngresosCompra.Instanciar(ACEInstancia.Modificado)
         _bingcompra.ABAS_IngresosCompra.ALMAC_Id = m_abas_ingresoscompra.ABAS_IngresosCompra.ALMAC_Id
         _bingcompra.ABAS_IngresosCompra.INGCO_Id = m_abas_ingresoscompra.ABAS_IngresosCompra.INGCO_Id
         _bingcompra.ABAS_IngresosCompra.INGCO_Estado = ACEVentas.Constantes.getEstado(ACEVentas.Constantes.Estado.Anulado)
         If _bingcompra.Guardar(x_usuario) Then

            If x_stock Then
               For Each item As EABAS_IngresosCompraDetalle In m_abas_ingresoscompra.ABAS_IngresosCompra.ListABAS_IngresosCompraDetalle
                  '' Realizar el egreso de Stock
                  Dim m_bmanejarstocks As New ACBLogistica.BManejarStock()
                  m_bmanejarstocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
                  m_bmanejarstocks.LOG_Stocks.INGCO_Id = item.INGCO_Id
                  m_bmanejarstocks.LOG_Stocks.INGCD_Item = item.INGCD_Item
                  m_bmanejarstocks.AnulacionIngresoCompra(m_periodo, item.ARTIC_Codigo, item.ALMAC_Id, item.INGCO_Id, item.INGCD_Item, item.INGCD_Cantidad, x_usuario)
               Next
            End If
            DAEnterprise.CommitTransaction()
            Return True
         Else
            Throw New Exception("No puede completar el proceso Anular Ingreso de Mercaderia")
         End If
         Return False
      Catch ex As Exception
         DAEnterprise.RollBackTransaction()
         Throw ex
      End Try
   End Function
    ''' <summary>
   ''' Anular registro de mercaderia
   ''' </summary>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function AnularRegMercaderia_Log(ByVal x_usuario As String, ByVal X_LENGH As Integer) As Boolean
      Try
         DAEnterprise.BeginTransaction()
         Dim _bingcompra As New BABAS_IngresosCompra
         _bingcompra.ABAS_IngresosCompra = New EABAS_IngresosCompra
         _bingcompra.ABAS_IngresosCompra.Instanciar(ACEInstancia.Modificado)
         _bingcompra.ABAS_IngresosCompra.ALMAC_Id = m_abas_ingresoscompra.ABAS_IngresosCompra.ALMAC_Id
         _bingcompra.ABAS_IngresosCompra.INGCO_Id = m_abas_ingresoscompra.ABAS_IngresosCompra.INGCO_Id
            _bingcompra.ABAS_IngresosCompra.INGCO_Estado = ACEVentas.Constantes.getEstado(ACEVentas.Constantes.Estado.Ingresado)

            If _bingcompra.Guardar(x_usuario) Then
                If  m_abas_ingresoscompra.ABAS_IngresosCompra.TIPOS_CodTipoDocumento = "CPD07" And X_LENGH<1  Then

                    ELSE
                    For Each item As EABAS_IngresosCompraDetalle In m_abas_ingresoscompra.ABAS_IngresosCompra.ListABAS_IngresosCompraDetalle
                        '' Realizar el egreso de Stock
                        Dim m_bmanejarstocks As New ACBLogistica.BManejarStock()
                        m_bmanejarstocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
                        m_bmanejarstocks.LOG_Stocks.INGCO_Id = item.INGCO_Id
                        m_bmanejarstocks.LOG_Stocks.INGCD_Item = item.INGCD_Item
                        

                        If Not m_bmanejarstocks.EliminarIngresoMercaderia(m_periodo, item.ARTIC_Codigo, item.ALMAC_Id, item.INGCO_Id, item.INGCD_Item, item.INGCD_Cantidad, x_usuario) Then
                            Throw New Exception(String.Format("No puede completar el proceso de Eliminar Ingreso: Item {0} / {1} - {2}", item.INGCD_Item, item.ARTIC_Codigo, item.ARTIC_Descripcion))
                        End If
                    Next
                End If
                DAEnterprise.CommitTransaction()
                Return True
            Else
                Throw New Exception("No puede completar el proceso Anular Ingreso de Mercaderia")
            End If
            Return False
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
   End Function



    Public Function AnularRegMercaderia_LogT(ByVal x_usuario As String, ByVal X_LENGH As Integer) As Boolean
      Try
         DAEnterprise.BeginTransaction()
         Dim _bingcompra As New BABAS_IngresosCompra
         _bingcompra.ABAS_IngresosCompra = New EABAS_IngresosCompra
         _bingcompra.ABAS_IngresosCompra.Instanciar(ACEInstancia.Modificado)
         _bingcompra.ABAS_IngresosCompra.ALMAC_Id = m_abas_ingresoscompra.ABAS_IngresosCompra.ALMAC_Id
         _bingcompra.ABAS_IngresosCompra.INGCO_Id = m_abas_ingresoscompra.ABAS_IngresosCompra.INGCO_Id
            _bingcompra.ABAS_IngresosCompra.INGCO_Estado = ACEVentas.Constantes.getEstado(ACEVentas.Constantes.Estado.Confirmado)

            If _bingcompra.Guardar(x_usuario) Then
                If  m_abas_ingresoscompra.ABAS_IngresosCompra.TIPOS_CodTipoDocumento = "CPD07" And X_LENGH<1  Then

                    ELSE
                    For Each item As EABAS_IngresosCompraDetalle In m_abas_ingresoscompra.ABAS_IngresosCompra.ListABAS_IngresosCompraDetalle
                        '' Realizar el egreso de Stock
                        Dim m_bmanejarstocks As New ACBLogistica.BManejarStock()
                        m_bmanejarstocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
                        m_bmanejarstocks.LOG_Stocks.INGCO_Id = item.INGCO_Id
                        m_bmanejarstocks.LOG_Stocks.INGCD_Item = item.INGCD_Item
                        

                        If Not m_bmanejarstocks.EliminarIngresoMercaderia(m_periodo, item.ARTIC_Codigo, item.ALMAC_Id, item.INGCO_Id, item.INGCD_Item, item.INGCD_Cantidad, x_usuario) Then
                            Throw New Exception(String.Format("No puede completar el proceso de Eliminar Ingreso: Item {0} / {1} - {2}", item.INGCD_Item, item.ARTIC_Codigo, item.ARTIC_Descripcion))
                        End If
                    Next
                End If
                DAEnterprise.CommitTransaction()
                Return True
            Else
                Throw New Exception("No puede completar el proceso Anular Ingreso de Mercaderia")
            End If
            Return False
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
   End Function




   ''' <summary>
   ''' Anular registro de mercaderia
   ''' </summary>
   ''' <param name="x_usuario">codigo de usuario</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
  Public Function AnularRegMercaderia(ByVal x_usuario As String) As Boolean
      Try
         DAEnterprise.BeginTransaction()
         Dim _bingcompra As New BABAS_IngresosCompra
         _bingcompra.ABAS_IngresosCompra = New EABAS_IngresosCompra
         _bingcompra.ABAS_IngresosCompra.Instanciar(ACEInstancia.Modificado)
         _bingcompra.ABAS_IngresosCompra.ALMAC_Id = m_abas_ingresoscompra.ABAS_IngresosCompra.ALMAC_Id
         _bingcompra.ABAS_IngresosCompra.INGCO_Id = m_abas_ingresoscompra.ABAS_IngresosCompra.INGCO_Id
            _bingcompra.ABAS_IngresosCompra.INGCO_Estado = ACEVentas.Constantes.getEstado(ACEVentas.Constantes.Estado.Ingresado)

            If _bingcompra.Guardar(x_usuario) Then
                If Not m_abas_ingresoscompra.ABAS_IngresosCompra.TIPOS_CodTipoDocumento = "CPD07" Then

                    For Each item As EABAS_IngresosCompraDetalle In m_abas_ingresoscompra.ABAS_IngresosCompra.ListABAS_IngresosCompraDetalle
                        '' Realizar el egreso de Stock
                        Dim m_bmanejarstocks As New ACBLogistica.BManejarStock()
                        m_bmanejarstocks.LOG_Stocks = New ACELogistica.ELOG_Stocks
                        m_bmanejarstocks.LOG_Stocks.INGCO_Id = item.INGCO_Id
                        m_bmanejarstocks.LOG_Stocks.INGCD_Item = item.INGCD_Item
                        If Not m_bmanejarstocks.EliminarIngresoMercaderia(m_periodo, item.ARTIC_Codigo, item.ALMAC_Id, item.INGCO_Id, item.INGCD_Item, item.INGCD_Cantidad, x_usuario) Then
                            Throw New Exception(String.Format("No puede completar el proceso de Eliminar Ingreso: Item {0} / {1} - {2}", item.INGCD_Item, item.ARTIC_Codigo, item.ARTIC_Descripcion))
                        End If
                    Next
                End If
                DAEnterprise.CommitTransaction()
                Return True
            Else
                Throw New Exception("No puede completar el proceso Anular Ingreso de Mercaderia")
            End If
            Return False
        Catch ex As Exception
            DAEnterprise.RollBackTransaction()
            Throw ex
        End Try
   End Function

   ''' <summary> 
   ''' Capa de Negocio: LOG_INGCOSS_ObtenerIngresoCompra
   ''' </summary>
   ''' <param name="x_almac_id">Parametro 1: </param> 
   ''' <param name="x_ingco_id">Parametro 2: </param> 
   ''' <returns></returns> 
   ''' <remarks></remarks> 
   Public Function ObtenerIngresoCompra(ByVal x_almac_id As Short, ByVal x_ingco_id As Long) As Boolean
      m_abas_ingresoscompra = New BABAS_IngresosCompra
      m_abas_ingresoscompra.ABAS_IngresosCompra = New EABAS_IngresosCompra
      Try
         Return d_generarregmerctransito.LOG_INGCOSS_ObtenerIngresoCompra(m_abas_ingresoscompra.ABAS_IngresosCompra, x_almac_id, x_ingco_id)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#End Region

End Class

