<xml>
   <sql>
      <titulo>DDirecciones.DIRECS_TodosAyuda</titulo>
      <descripcion>Obtener las direcciones de una entidad especifica</descripcion>
      <code>
			SELECT top 100 0 As Codigo
				,m_Dir.UBIGO_Codigo As Ubigeo
				,m_Dir.ENTID_Direccion As Direccion
				,Dep.UBIGO_Descripcion As Departamento
				,Prov.UBIGO_Descripcion As Provincia
				,Dis.UBIGO_Descripcion As Distrito
			FROM Entidades As m_Dir
				Inner Join Ubigeos As Dep On Dep.UBIGO_Codigo = Left(m_Dir.UBIGO_Codigo, 2)
				Inner Join Ubigeos As Prov On Prov.UBIGO_Codigo = Left(m_Dir.UBIGO_Codigo, 5)
				Inner Join Ubigeos As Dis On Dis.UBIGO_Codigo = m_Dir.UBIGO_Codigo
			WHERE {0}
			Union
			SELECT m_Dir.DIREC_Id As Codigo
				,m_Dir.UBIGO_Codigo As Ubigeo
				,m_Dir.DIREC_Direccion As Direccion
				,Dep.UBIGO_Descripcion As Departamento
				,Prov.UBIGO_Descripcion As Provincia
				,Dis.UBIGO_Descripcion As Distrito
			FROM Direcciones As m_Dir
				Inner Join Ubigeos As Dep On Dep.UBIGO_Codigo = Left(m_Dir.UBIGO_Codigo, 2)
				Inner Join Ubigeos As Prov On Prov.UBIGO_Codigo = Left(m_Dir.UBIGO_Codigo, 5)
				Inner Join Ubigeos As Dis On Dis.UBIGO_Codigo = m_Dir.UBIGO_Codigo
			WHERE {0}
      </code>
   </sql>
   <sql>
      <titulo>DConsultaArticulos.cargarPrecios</titulo>
      <descripcion>Consultar los precios de los articulos incluyendole el calculo de procentaje para el precio de venta</descripcion>
      <code>
			Select Lista.LPREC_Id, Lista.LPREC_Descripcion,
				LArt.ALPRE_PorcentaVenta, Pre.PRECI_Precio
				,(LArt.ALPRE_PorcentaVenta + 100) * Pre.PRECI_Precio/100 As PrecioCalculado
				,(LArt.ALPRE_PorcentaVenta + 100) * Pre.PRECI_Precio/100 As PrecioOriginal
				,Pre.TIPOS_CodTipoMoneda
			from Articulos As Arti
				Inner Join [Ventas].[VENT_ListaPreciosArticulos] As LArt On LArt.ARTIC_Codigo = Arti.ARTIC_Codigo
				Inner Join [Ventas].[VENT_ListaPrecios] As Lista On Lista.LPREC_Id = LArt.LPREC_Id And Lista.ZONAS_Codigo = LArt.ZONAS_Codigo
				Inner Join Precios As Pre On Pre.ARTIC_Codigo = Arti.ARTIC_Codigo
			Where Arti.ARTIC_Codigo = '{0}'  And Lista.ZONAS_Codigo = '{1}'
			Order By Lista.LPREC_Id
      </code>
   </sql>
   <sql>
      <titulo>DEntidades.ENTISS_TodosAyudaConductor</titulo>
      <descripcion>Cargar los conductores de una entidad</descripcion>
      <code>
         Select 
				Ent.ENTID_Codigo As Codigo, Ent.ENTID_RazonSocial As [Razon Social], Ent.ENTID_Nombres As Nombre, Ent.ENTID_NroDocumento As [Doc./R.U.C.]
			From Entidades As Ent
				Inner Join EntidadesRoles As Rol On Rol.ENTID_Codigo = Ent.ENTID_Codigo And Rol.ROLES_Id = {0}
				Inner Join EntidadRelacion As Rel On Rel.ENTID_CodRelacion = Ent.ENTID_Codigo And Rel.ENTID_Codigo = '{1}' 
			Where
				Ent.{2} Like '%{3}%' 
      </code>
   </sql>
      <sql>
      <titulo>DConsultaArticulos.CargarUltimos</titulo>
      <descripcion></descripcion>
      <code>
			SELECT Top {0} Det.DOCCD_PrecioUnitario
				, TDoc.TIPOS_DescCorta + ' ' + Cab.DOCCO_Serie + '-' + Right('0000000' + RTrim(Cab.DOCCO_Numero), 7) As Documento
				,Cab.DOCCO_FechaDocumento, Ent.ENTID_RazonSocial, Mnd.TIPOS_DescCorta As TIPOS_TipoMoneda
			FROM [Logistica].[ABAS_DocsCompra] As Cab
				Inner Join [Logistica].[ABAS_DocsCompraDetalle] As Det 
					On Det.DOCCO_Codigo = Cab.DOCCO_Codigo
				Inner Join Articulos As Art	
					On Art.ARTIC_Codigo = Det.ARTIC_Codigo
				Inner Join Tipos As TDoc 
					On TDoc.TIPOS_Codigo = Cab.TIPOS_CodTipoDocumento
				Inner Join Entidades As Ent
					On Ent.ENTID_Codigo = Cab.ENTID_CodigoProveedor
				Inner Join Tipos As Mnd
					On Mnd.TIPOS_Codigo = Cab.TIPOS_CodTipoMoneda
			Where Det.ARTIC_Codigo = '{1}'
				And Det.DOCCD_PrecioUnitario > 0
			Order By Cab.DOCCO_FechaDocumento Desc
      </code>
   </sql>
   <sql>
      <titulo>DVENT_Pedidos.getBusqueda</titulo>
      <descripcion></descripcion>
      <code>
         Select m_vent_pedidos.* , Ent.ENTID_RazonSocial As ENTID_Cliente
				, Vend.ENTID_RazonSocial As ENTID_Vendedor
				, TDoc.TIPOS_Descripcion As TIPOS_TipoDocumento
				, TMon.TIPOS_Descripcion As TIPOS_TipoMoneda
				, TCon.TIPOS_DescCorta As TIPOS_CondicionPago
				, Us.ENTID_RazonSocial As Usuario
				, Ent.ENTID_NroDocumento
			Into #Ventas
			From Ventas.VENT_Pedidos As m_vent_pedidos 
				Inner Join dbo.Entidades As Ent On Ent.ENTID_Codigo = m_vent_pedidos.ENTID_CodigoCliente
				Inner Join dbo.Entidades As Vend On Vend.ENTID_Codigo = m_vent_pedidos.ENTID_CodigoVendedor
				Inner Join dbo.Tipos As TDoc On TDoc.TIPOS_Codigo = m_vent_pedidos.TIPOS_CodTipoDocumento
				Inner Join dbo.Tipos As TMon On TMon.TIPOS_Codigo = m_vent_pedidos.TIPOS_CodTipoMoneda
				Left Join dbo.Tipos As TCon On TCon.TIPOS_Codigo = m_vent_pedidos.TIPOS_CodCondicionPago
				Left Join dbo.Entidades As Us On Us.USUAR_Codigo = m_vent_pedidos.PEDID_UsrCrea 
			WHERE {0}

			Select * from #Ventas

			Select m_vent_pedidosdetalle.* , Art.ARTIC_Descripcion As ARTIC_Descripcion
				, Art.ARTIC_Codigo As ARTIC_Codigo
				, Alm.ALMAC_Descripcion As ALMAC_Descripcion
			From Ventas.VENT_PedidosDetalle As m_vent_pedidosdetalle 
				Inner Join dbo.Articulos As Art On Art.ARTIC_Codigo = m_vent_pedidosdetalle.ARTIC_Codigo
				Inner Join dbo.Almacenes As Alm On Alm.ALMAC_Id = m_vent_pedidosdetalle.ALMAC_Id 
			WHERE 
				ISNULL(m_VENT_PedidosDetalle.PEDID_Codigo, '') In (Select PEDID_Codigo From #Ventas)
      </code>
   </sql>
   <sql>
      <titulo>IDGenerarCancelacion.getAyuda</titulo>
      <descripcion></descripcion>
      <code>
         Select 
				DPAGO_Id As Interno
				,TDoc.TIPOS_Descripcion As [Documento]
				,Ban.BANCO_Descripcion As Banco
				,Cu.CUENT_Numero As Cuenta
				,TMon.TIPOS_DescCorta As Moneda
				,DPAGO_Fecha As [Fecha Giro/Deposito]
				,DPAGO_FechaVenc As [Fecha Cobro/Venc.]
				,DPAGO_Importe As Importe
				,DPAGO_TipoCambio As [Tipo Cambio]
			From Tesoreria.TESO_DocsPagos As Pag
				Inner Join Bancos As Ban On Ban.BANCO_Id = Pag.BANCO_Id
				Inner Join Cuentas As Cu On Cu.CUENT_Id = Pag.CUENT_Id
				Inner Join Tipos As TDoc On TDoc.TIPOS_Codigo = Pag.TIPOS_CodTipoDocumento 
				Inner Join Tipos As TMon On TMon.TIPOS_Codigo = Pag.TIPOS_CodTipoMoneda
			Where {0}
      </code>
   </sql>
	  <sql>
      <titulo>DVENT_DocsVenta.VENT_ReporteVentas</titulo>
      <descripcion></descripcion>
      <code>
			Select 
				 m_vent_docsventa.* , n_entidades.ENTID_RazonSocial As ENTID_Cliente
				, n_entidades.ENTID_NroDocumento As ENTID_NroDocumento
				, TMon.TIPOS_DescCorta As TIPOS_TipoMoneda
				, TDoc.TIPOS_Descripcion As TIPOS_TipoDocumento
				, TDoc.TIPOS_Desc2 As TIPOS_TipoDocCorta
				, Case m_vent_docsventa.TIPOS_CodTipoMoneda When 'MND1' 
					Then m_vent_docsventa.DOCVE_ImporteVenta
					Else m_vent_docsventa.DOCVE_ImporteVenta * TCam.TIPOC_VentaSunat
				  End As ImporteSoles
				, Case m_vent_docsventa.TIPOS_CodTipoMoneda When 'MND1' 
					Then m_vent_docsventa.DOCVE_ImporteIgv
					Else m_vent_docsventa.DOCVE_ImporteIgv * TCam.TIPOC_VentaSunat
				  End As IGVSoles
				, Case m_vent_docsventa.TIPOS_CodTipoMoneda When 'MND1' 
					Then m_vent_docsventa.DOCVE_TotalPagar
					Else m_vent_docsventa.DOCVE_TotalPagar * TCam.TIPOC_VentaSunat
				  End As TotalSoles
				, Case m_vent_docsventa.TIPOS_CodTipoMoneda When 'MND1' 
					Then Null
					Else m_vent_docsventa.DOCVE_TotalPagar
				  End As TotalDolares
				, TCam.TIPOC_VentaSunat
			 From Ventas.VENT_DocsVenta As m_vent_docsventa 
				 Inner Join dbo.Entidades As n_entidades On n_entidades.ENTID_Codigo = m_vent_docsventa.ENTID_CodigoCliente
				 Inner Join dbo.Tipos As TMon On TMon.TIPOS_Codigo = m_vent_docsventa.TIPOS_CodTipoMoneda
				 Inner Join dbo.Tipos As TDoc On TDoc.TIPOS_Codigo = m_vent_docsventa.TIPOS_CodTipoDocumento 
				 Left Join dbo.TipoCambio As TCam On TCam.TIPOC_Fecha = Convert(varchar,m_vent_docsventa.DOCVE_FechaDocumento, 112)
			 WHERE  ISNULL(m_VENT_DocsVenta.DOCVE_FechaDocumento, '') Between '{0}'
			 AND '{1}'
      </code>
   </sql>
	 <sql>
      <titulo>DEntidades.getSelectAyuda</titulo>
      <descripcion></descripcion>
      <code>
         SELECT Distinct 
				m_Ent.ENTID_Codigo As Codigo, m_Ent.ENTID_RazonSocial As [Razon Social]
				, m_Ent.ENTID_Nombres As Nombre, m_Ent.ENTID_NroDocumento As [Doc./R.U.C.]
				,IsNUll(ENTID_Direccion,'') + ' - ' + IsNull(Dis.UBIGO_Descripcion + ' / ' + Pro.UBIGO_Descripcion + ' / ' + Dep.UBIGO_Descripcion, '') As Dirección
				, m_Ent.ENTID_Id As Interno, m_Ent.UBIGO_Codigo As Ubigeo
			FROM Entidades as m_Ent
				Left Join Ubigeos As Dep On Dep.UBIGO_Codigo = LEFT(m_Ent.UBIGO_Codigo, 2)
				Left Join Ubigeos As Pro On Pro.UBIGO_Codigo = LEFT(m_Ent.UBIGO_Codigo, 5)
				Left Join Ubigeos As Dis On Dis.UBIGO_Codigo = m_Ent.UBIGO_Codigo
      </code>
   </sql>
	 <sql>
      <titulo>DEntidades.CargarDocIden</titulo>
      <descripcion></descripcion>
      <code>
			Select m_Ent.* , IsNUll(ENTID_Direccion,'') + ' - ' + IsNull(Dis.UBIGO_Descripcion + ' / ' + Pro.UBIGO_Descripcion + ' / ' + Dep.UBIGO_Descripcion, '') As Direccion
			From dbo.Entidades As m_Ent 
				Left Join Ubigeos As Dep On Dep.UBIGO_Codigo = LEFT(m_Ent.UBIGO_Codigo, 2)
				Left Join Ubigeos As Pro On Pro.UBIGO_Codigo = LEFT(m_Ent.UBIGO_Codigo, 5)
				Left Join Ubigeos As Dis On Dis.UBIGO_Codigo = m_Ent.UBIGO_Codigo

			WHERE   m_Ent.ENTID_NroDocumento = '{0}'
      </code>
   </sql>
   --Cambio para devoluciones conductores
   <sql>
      <titulo>DEntidades.CargarDocDevo</titulo>
      <descripcion></descripcion>
      <code>
			Select m_Ent.* , IsNUll(ENTID_Direccion,'') + ' - ' + IsNull(Dis.UBIGO_Descripcion + ' / ' + Pro.UBIGO_Descripcion + ' / ' + Dep.UBIGO_Descripcion, '') As Direccion
			From dbo.Entidades As m_Ent 
				Left Join Ubigeos As Dep On Dep.UBIGO_Codigo = LEFT(m_Ent.UBIGO_Codigo, 2)
				Left Join Ubigeos As Pro On Pro.UBIGO_Codigo = LEFT(m_Ent.UBIGO_Codigo, 5)
				Left Join Ubigeos As Dis On Dis.UBIGO_Codigo = m_Ent.UBIGO_Codigo

			WHERE   m_Ent.entid_codigo = '{0}' and not m_Ent.entid_estado ='X'
		</code>
   </sql>
   <sql>
      <titulo>DEntidades.ENTISS_CargarDirecciones</titulo>
      <descripcion></descripcion>
      <code>
         Select * 
				,IsNUll(DIREC_Direccion,'') + ' - ' + IsNull(Dis.UBIGO_Descripcion + ' / ' + Pro.UBIGO_Descripcion + ' / ' + Dep.UBIGO_Descripcion, '') As Direccion
			From Direcciones As Dir
				Left Join Ubigeos As Dep On Dep.UBIGO_Codigo = LEFT(Dir.UBIGO_Codigo, 2)
				Left Join Ubigeos As Pro On Pro.UBIGO_Codigo = LEFT(Dir.UBIGO_Codigo, 5)
				Left Join Ubigeos As Dis On Dis.UBIGO_Codigo = Dir.UBIGO_Codigo
			WHERE ENTID_Codigo = '{0}'
      </code>
   </sql>
	<sql>
      <titulo>DTRAN_Vehiculos.VEHISS_TodosAyuda</titulo>
      <descripcion>Obtener</descripcion>
      <code>
			SELECT  
				 m_Vehi.VEHIC_Id As Interno
				,TVehi.TIPOS_Descripcion As [T. Vehiculo]
				,TMar.TIPOS_Descripcion As Marca
				,m_Vehi.VEHIC_Codigo As Codigo
				,m_Vehi.VEHIC_Modelo As Modelo
				,m_Vehi.VEHIC_FecAdquisicion As Adquisicion
				,m_Vehi.VEHIC_Placa As Placa
				,m_Vehi.VEHIC_KmActual As [Kilometraje Actual]
				,m_Vehi.VEHIC_KmInicial As [Kilometraje Inicial]
				,m_Vehi.VEHIC_Certificado As Certificado
				,Ran.RANFL_Placa As [Placa Ranfla]
				,TMarR.TIPOS_Descripcion As [Marca Ranfla]
				,Ran.RANFL_Certificado As [Certificado Ranfla]
			 FROM Transportes.TRAN_Vehiculos As m_Vehi
				Inner Join Tipos As TVehi On TVehi.TIPOS_Codigo = m_Vehi.TIPOS_CodTipoVehiculo 
				Inner Join Tipos As TMar On TMar.TIPOS_Codigo = m_Vehi.TIPOS_CodMarca 
				Left Join [Transportes].[TRAN_VehiculosRanflas] As VRa On VRa.VEHIC_Id = m_Vehi.VEHIC_Id And VRa.VEHRN_Estado = 'A'
				Left Join [Transportes].[TRAN_Ranflas] As Ran On Ran.RANFL_Id = Vra.RANFL_Id	 
				Left Join Tipos As TMarR On TMarR.TIPOS_Codigo = Ran.TIPOS_CodMarca 
			 WHERE 
      </code>
   </sql>
	<sql>
      <titulo>DGenerarGuias.getCliente</titulo>
      <descripcion>Obtener a los clientes con documento de venta</descripcion>
      <code>
         Select
				Case When (Select Count(*) From [Logistica].[DIST_DocsTraslados] Where DOCVE_Codigo = m_vent_docsventa .DOCVE_Codigo And Left(DOTRA_Codigo, 2) = 'GR') > 0 Then Convert(Bit, 1) Else Convert(Bit, 0) End As Guias
				, Convert(Bit, 0)  Notas
				, Case When (Select Count(*) From [Logistica].[DIST_DocsTraslados] Where DOCVE_Codigo = m_vent_docsventa .DOCVE_Codigo And Left(DOTRA_Codigo, 2) = 'OR') > 0 Then Convert(Bit, 1) Else Convert(Bit, 0) End As Orden
				, Case DOCVE_EstEntrega When 'P' Then Convert(Bit, 1) Else Convert(Bit, 0) End As Pendiente
				, Case When DOCVE_FecAnulacion Is Null Then Convert(Bit, 0) Else Convert(Bit, 1) End As Anulada
				, m_vent_docsventa.* , Cli.ENTID_RazonSocial As ENTID_Cliente
				, Vend.ENTID_RazonSocial As ENTID_Vendedor
				, TDoc.TIPOS_Descripcion As TIPOS_TipoDocumento
				, TDoc.TIPOS_DescCorta As TIPOS_TipoDocCorta
				, TMon.TIPOS_DescCorta As TIPOS_TipoMoneda
				, TPag.TIPOS_DescCorta As TIPOS_TipoPago
				, Us.ENTID_RazonSocial As Usuario
         From Ventas.VENT_DocsVenta As m_vent_docsventa
				Inner Join dbo.Entidades As Cli On Cli.ENTID_Codigo = m_vent_docsventa.ENTID_CodigoCliente
				Inner Join dbo.Entidades As Vend On Vend.ENTID_Codigo = m_vent_docsventa.ENTID_CodigoVendedor
				Inner Join dbo.Tipos As TDoc On TDoc.TIPOS_Codigo = m_vent_docsventa.TIPOS_CodTipoDocumento
				Inner Join dbo.Tipos As TMon On TMon.TIPOS_Codigo = m_vent_docsventa.TIPOS_CodTipoMoneda
				Inner Join dbo.Tipos As TPag On TPag.TIPOS_Codigo = m_vent_docsventa.TIPOS_CodTipoPago
         Left Join dbo.Entidades As Us On Us.USUAR_Codigo = m_vent_docsventa.DOCVE_UsrCrea
      </code>
   </sql>
	<sql>
      <titulo>DGenerarGuias.getCliente.Where</titulo>
      <descripcion></descripcion>
      <code>
         	And (Select Sum(IsNull(DetOrd.DOCVD_Cantidad, 0) - IsNull(Det.DDTRA_Cantidad, 0)) As Cantidad
						From [Ventas].[VENT_DocsVentaDetalle] As DetOrd
							Inner Join [Ventas].[VENT_DocsVenta] As Cab On Cab.DOCVE_Codigo = DetOrd.DOCVE_Codigo
							Left Join (
								Select ARTIC_Codigo, Sum(Det.DDTRA_Cantidad) As DDTRA_Cantidad, ALMAC_IdOrigen
									from [Logistica].[DIST_DocsTraslados] As Ing
										Inner Join [Logistica].[DIST_DocsTrasladosDetalle] As Det
											On Det.DOTRA_Codigo = Ing.DOTRA_Codigo
												And Not DOTRA_Estado = 'X'
									Where Ing.DOCVE_Codigo = m_vent_docsventa.DOCVE_Codigo
										And Ing.ALMAC_IdOrigen = {0}
								Group By ARTIC_Codigo, ALMAC_IdOrigen
							) As Det 
								On Det.ARTIC_Codigo = DetOrd.ARTIC_Codigo And Det.ALMAC_IdOrigen = DetOrd.ALMAC_Id
							Inner Join Articulos As Art
								On Art.ARTIC_Codigo = DetOrd.ARTIC_Codigo
							Inner Join Tipos As TUni
								On TUni.TIPOS_Codigo = Art.TIPOS_CodUnidadMedida
						Where DetOrd.DOCVE_Codigo = m_vent_docsventa.DOCVE_Codigo 
								And DetOrd.ALMAC_Id = 3) > 0
      </code>
   </sql>
	<sql>
      <titulo>DConsultaArticulos.GetPreciosAlmacenes</titulo>
      <descripcion></descripcion>
      <code>
        Select ALMAC_Id, ALMAC_Descripcion, ARTIC_Codigo, SUM(Ingreso) - SUM(Salida) As STOCK_Cantidad
		From
		(
			Select LSt.ALMAC_Id, Alm.ALMAC_Descripcion, LSt.ARTIC_Codigo, STOCK_CantidadIngreso As Ingreso, STOCK_CantidadSalida As Salida 
			From Logistica.LOG_Stocks LSt
				Inner Join Almacenes As Alm On Alm.ALMAC_Id = LSt.ALMAC_Id
				Inner Join Articulos As Art On Art.ARTIC_Codigo = LSt.ARTIC_Codigo
			Where PERIO_Codigo = '{0}'
				And Not LSt.STOCK_Estado = 'X'
				And Art.LINEA_Codigo = '{1}'
				And Alm.ALMAC_Id = {2}
			Union All
			Select SI.ALMAC_Id, Alm.ALMAC_Descripcion, SI.ARTIC_Codigo, STINI_Cantidad, 0 
			From Logistica.LOG_StockIniciales As SI
				Inner Join Almacenes As Alm On Alm.ALMAC_Id = SI.ALMAC_Id
				Inner Join Articulos As Art On Art.ARTIC_Codigo = Si.ARTIC_Codigo
			Where PERIO_Codigo = '{0}'
				And Art.LINEA_Codigo = '{1}'
				And Alm.ALMAC_Id = {2}
		) As C
		Group By ALMAC_Id, ARTIC_Codigo, ALMAC_Descripcion
      </code>
   </sql>
	 <sql>
      <titulo>DConsultaArticulos.GetStockAlmacen</titulo>
      <descripcion></descripcion>
      <code>
         Select ALMAC_Id, ALMAC_Descripcion, ARTIC_Codigo, SUM(Ingreso) - SUM(Salida) As STOCK_Cantidad
			From
			(
				Select LSt.ALMAC_Id, Alm.ALMAC_Descripcion, LSt.ARTIC_Codigo, STOCK_CantidadIngreso As Ingreso, STOCK_CantidadSalida As Salida 
				From Logistica.LOG_Stocks LSt
					Inner Join Almacenes As Alm On Alm.ALMAC_Id = LSt.ALMAC_Id
					Inner Join Articulos As Art On Art.ARTIC_Codigo = LSt.ARTIC_Codigo
				Where PERIO_Codigo = '{0}'
					And Not LSt.STOCK_Estado = 'X'
					And Art.ARTIC_Codigo In ({1})
					And Alm.ALMAC_Id = {2}
				Union All
				Select SI.ALMAC_Id, Alm.ALMAC_Descripcion, SI.ARTIC_Codigo, STINI_Cantidad, 0 
				From Logistica.LOG_StockIniciales As SI
					Inner Join Almacenes As Alm On Alm.ALMAC_Id = SI.ALMAC_Id
					Inner Join Articulos As Art On Art.ARTIC_Codigo = Si.ARTIC_Codigo
				Where PERIO_Codigo = '{0}'
					And Art.ARTIC_Codigo In ({1})
					And Alm.ALMAC_Id = {2}
			) As C
			Group By ALMAC_Id, ARTIC_Codigo, ALMAC_Descripcion
      </code>
   </sql>
	 <sql>
      <titulo>t</titulo>
      <descripcion></descripcion>
      <code>
         
      </code>
   </sql>
</xml>