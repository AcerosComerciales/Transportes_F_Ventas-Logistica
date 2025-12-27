<xml>
   <sql>
      <titulo>DGenerarReportes.GetArticulos</titulo>
      <descripcion></descripcion>
      <code>
			Select 
				SL.LINEA_Nombre As Linea
				,L.LINEA_Nombre As SubLinea
				,Art.ARTIC_Codigo As Codigo
				,Art.ARTIC_Descripcion As Descripción
				,TProd.TIPOS_Descripcion As [Tipo Producto]
				,TCat.TIPOS_Descripcion As [Categoría]
				,TUni.TIPOS_DescCorta As [Unidad Medida]
				,TUni.TIPOS_Descripcion As Unidad
				,Col.COLOR_Descripcion As Color
				,ARTIC_Peso As Peso
				,TMon.TIPOS_DescCorta As [Moneda]
				,TMon.TIPOS_Descripcion As MonedaDesc
				,ARTIC_Orden
			From Articulos Art
				Inner Join Lineas As L		On L.LINEA_Codigo = Art.LINEA_Codigo
				Inner Join Lineas As SL		On SL.LINEA_Codigo = L.LINEA_CodPadre
				Inner Join Tipos As TProd	On TProd.TIPOS_Codigo = Art.TIPOS_CodTipoProducto
				Inner Join Tipos As TCat	On TCat.TIPOS_Codigo = Art.TIPOS_CodCategoria
				Inner Join Tipos As TUni	On TUni.TIPOS_Codigo = Art.TIPOS_CodUnidadMedida
				Inner Join Tipos As TMon	On TMon.TIPOS_Codigo = Art.TIPOS_CodTipoMoneda
				Left Join Color As Col		On Col.COLOR_Id = Art.COLOR_Id
			{0}
			Order By ARTIC_Codigo, ARTIC_Detalle			
      </code>
   </sql>
   <sql>
      <titulo>DGenerarReportes.GetStocks</titulo>
      <descripcion></descripcion>
      <code>
			Select 
				 Li.LINEA_Codigo, SLi.LINEA_Codigo, Li.LINEA_Nombre As Linea, SLi.LINEA_Nombre As SubLinea
				,Art.ARTIC_Codigo As Codigo,Art.ARTIC_Descripcion As Descripcion
				,(Select SUM(Ingreso) - SUM(Salida) As STOCK_Cantidad
					From
					(
						Select LSt.ALMAC_Id, Alm.ALMAC_Descripcion, ARTIC_Codigo, STOCK_CantidadIngreso As Ingreso, STOCK_CantidadSalida As Salida 
						From Logistica.LOG_Stocks LSt
							Inner Join Almacenes As Alm On Alm.ALMAC_Id = LSt.ALMAC_Id
						Where ARTIC_Codigo = Art.ARTIC_Codigo 
							And Lst.ALMAC_Id = {1} 
							And PERIO_Codigo = '{2}'
							And Not LSt.STOCK_Estado = 'X'
							And ZONAS_Codigo = '{3}'
						Union All
						Select SI.ALMAC_Id, Alm.ALMAC_Descripcion, ARTIC_Codigo, STINI_Cantidad, 0 
						From Logistica.LOG_StockIniciales As SI
							Inner Join Almacenes As Alm On Alm.ALMAC_Id = SI.ALMAC_Id
						Where ARTIC_Codigo = Art.ARTIC_Codigo
							And SI.ALMAC_Id = {1}
							And PERIO_Codigo = '{2}'
							And ZONAS_Codigo = '{3}'
					)As C
					Group By ALMAC_Id, ARTIC_Codigo, ALMAC_Descripcion) As Stock
				,Convert(Integer, 0) As Orden
			From Articulos As Art
				Inner Join Lineas As Li On Li.LINEA_Codigo = Left(Art.LINEA_Codigo, 2)
				Inner Join Lineas As SLi On SLi.LINEA_Codigo = Art.LINEA_Codigo
			{0}
			Group By Art.ARTIC_Codigo, Art.ARTIC_Descripcion
				,Li.LINEA_Nombre, SLi.LINEA_Nombre, Li.LINEA_Codigo, SLi.LINEA_Codigo
			Order By Li.LINEA_Codigo, SLi.LINEA_Codigo
      </code>
   </sql>
      <sql>
      <titulo>DGenerarReportes.GetArticulosXLinea</titulo>
      <descripcion></descripcion>
      <code>
			Select
				 Li.LINEA_Codigo, SLi.LINEA_Codigo, Li.LINEA_Nombre As Linea, SLi.LINEA_Nombre As SubLinea
				,Det.ARTIC_Codigo, Art.ARTIC_Descripcion As Descripcion, Sum(IsNull(Det.DOCCD_PesoUnitario, 0) * IsNull(Det.DOCCD_Cantidad, 0)) As Peso
				,Sum(IsNull(Det.DOCCD_Cantidad, 0)) As Cantidad
				,(Select Sum(DOCCD_SubImporteCompra) From [Logistica].[ABAS_DocsCompraDetalle] As D
					Inner Join [Logistica].[ABAS_DocsCompra] As C On D.DOCCO_Codigo = C.DOCCO_Codigo 
						And D.ENTID_CodigoProveedor = C.ENTID_CodigoProveedor
					Where D.ARTIC_Codigo = Det.ARTIC_Codigo
						And C.TIPOS_CodTipoMoneda = 'MND1'
						And C.DOCCO_FechaDocumento Between '{1}' And '{2}'
					Group By D.ARTIC_Codigo
					)
					As Soles
				,(Select Sum(DOCCD_SubImporteCompra) From [Logistica].[ABAS_DocsCompraDetalle] As D
					Inner Join [Logistica].[ABAS_DocsCompra] As C On D.DOCCO_Codigo = C.DOCCO_Codigo 
						And D.ENTID_CodigoProveedor = C.ENTID_CodigoProveedor
					Where D.ARTIC_Codigo = Det.ARTIC_Codigo
						And C.TIPOS_CodTipoMoneda = 'MND2'
						And C.DOCCO_FechaDocumento Between '{1}' And '{2}'
					Group By D.ARTIC_Codigo
					)
					As Dolares
			From [Logistica].[ABAS_DocsCompra] As Doc
				Inner Join  [Logistica].[ABAS_DocsCompraDetalle] As Det On Det.DOCCO_Codigo = Doc.DOCCO_Codigo 
					And Det.ENTID_CodigoProveedor = Doc.ENTID_CodigoProveedor
				Inner Join Articulos As Art On Art.ARTIC_codigo = Det.ARTIC_codigo
				Inner Join Lineas As Li On Li.LINEA_Codigo = Left(Art.LINEA_Codigo, 2)
				Inner Join Lineas As SLi On SLi.LINEA_Codigo = Art.LINEA_Codigo
			Where Not Doc.DOCCO_Estado In ('X')
				And IsNull(Det.DOCCD_SubImporteCompra, 0) > 0 
				And Li.LINEA_Codigo = '{0}'
				And Doc.DOCCO_FechaDocumento Between '{1}' And '{2}'
			Group By Li.LINEA_Codigo, SLi.LINEA_Codigo, Li.LINEA_Nombre, SLi.LINEA_Nombre, Art.ARTIC_Descripcion
				,Det.ARTIC_Codigo
			Order By Li.LINEA_Codigo, SLi.LINEA_Codigo
      </code>
   </sql>
   <sql>
      <titulo>DGenerarReportes.GetComprasProveedorDetalle</titulo>
      <descripcion></descripcion>
      <code>
			Select
				 Li.LINEA_Codigo, SLi.LINEA_Codigo, Li.LINEA_Nombre As Linea, SLi.LINEA_Nombre As SubLinea
				,Det.ARTIC_Codigo, Art.ARTIC_Descripcion As Descripcion, Sum(IsNull(Det.DOCCD_PesoUnitario, 0) * IsNull(Det.DOCCD_Cantidad, 0)) As Peso
				,Sum(IsNull(Det.DOCCD_Cantidad, 0)) As Cantidad
				,(Select Sum(DOCCD_SubImporteCompra) From [Logistica].[ABAS_DocsCompraDetalle] As D
					Inner Join [Logistica].[ABAS_DocsCompra] As C On D.DOCCO_Codigo = C.DOCCO_Codigo 
						And D.ENTID_CodigoProveedor = C.ENTID_CodigoProveedor
					Where D.ARTIC_Codigo = Det.ARTIC_Codigo
						And C.TIPOS_CodTipoMoneda = 'MND1'
						And C.DOCCO_FechaDocumento Between '{1}' And '{2}'
					Group By D.ARTIC_Codigo
					)
					As Soles
				,(Select Sum(DOCCD_SubImporteCompra) From [Logistica].[ABAS_DocsCompraDetalle] As D
					Inner Join [Logistica].[ABAS_DocsCompra] As C On D.DOCCO_Codigo = C.DOCCO_Codigo 
						And D.ENTID_CodigoProveedor = C.ENTID_CodigoProveedor
					Where D.ARTIC_Codigo = Det.ARTIC_Codigo
						And C.TIPOS_CodTipoMoneda = 'MND2'
						And C.DOCCO_FechaDocumento Between '{1}' And '{2}'
					Group By D.ARTIC_Codigo
					)
					As Dolares
			From [Logistica].[ABAS_DocsCompra] As Doc
				Inner Join  [Logistica].[ABAS_DocsCompraDetalle] As Det On Det.DOCCO_Codigo = Doc.DOCCO_Codigo 
					And Det.ENTID_CodigoProveedor = Doc.ENTID_CodigoProveedor
				Inner Join Articulos As Art On Art.ARTIC_codigo = Det.ARTIC_codigo
				Inner Join Lineas As Li On Li.LINEA_Codigo = Left(Art.LINEA_Codigo, 2)
				Inner Join Lineas As SLi On SLi.LINEA_Codigo = Art.LINEA_Codigo
			Where Not Doc.DOCCO_Estado In ('X')
				And IsNull(Det.DOCCD_SubImporteCompra, 0) > 0 
				And Doc.DOCCO_FechaDocumento Between '{1}' And '{2}'
				And Doc.ENTID_CodigoProveedor = '{0}'
			Group By Li.LINEA_Codigo, SLi.LINEA_Codigo, Li.LINEA_Nombre, SLi.LINEA_Nombre, Art.ARTIC_Descripcion
				,Det.ARTIC_Codigo
			Order By Li.LINEA_Codigo, SLi.LINEA_Codigo
      </code>
   </sql>
   <sql>
      <titulo>DGenerarReportes.GetComprasXArticulo</titulo>
      <descripcion></descripcion>
      <code>
			Select 
				Doc.DOCCO_FechaDocumento As Fecha
				,Case Doc.TIPOS_CodTipoDocumento When 'CPD12' Then
						TDoc.TIPOS_DescCorta + ' ' + Right('0000' + Doc.DOCCO_Serie, 4) + '-' + Right('000000000' + RTrim(Doc.DOCCO_Numero), 9) 
					Else
						TDoc.TIPOS_DescCorta + ' ' + Right('000' + Doc.DOCCO_Serie, 3) + '-' + Right('0000000' + RTrim(Doc.DOCCO_Numero), 7) 
				  End As Documento
				, Doc.DOCCO_TotalPeso As Peso
				, Det.DOCCD_Cantidad As Cantidad
				, TMnd.TIPOS_Descripcion As Moneda
				, DOCCO_TotalCompra As Importe
				, DOCCD_Costo As Costo
				, Doc.ENTID_CodigoProveedor , Ent.ENTID_RazonSocial
				, Doc.DOCCO_Codigo
			From [Logistica].[ABAS_DocsCompra] As Doc
				Inner Join [Logistica].[ABAS_DocsCompraDetalle] As Det On Det.DOCCO_Codigo = Doc.DOCCO_Codigo And Det.ENTID_CodigoProveedor = Doc.ENTID_CodigoProveedor
					And IsNull(Det.DOCCD_Cantidad, 0) > 0
				Inner Join Entidades As Ent On Ent.ENTID_Codigo = Doc.ENTID_CodigoProveedor
				Inner Join Tipos As TDoc On TDoc.TIPOS_Codigo = Doc.TIPOS_CodTipoDocumento
				Inner Join Tipos As TMnd On TMnd.TIPOS_Codigo = Doc.TIPOS_CodTipoMoneda
			Where Det.ARTIC_Codigo = '{0}'
				And Not Doc.DOCCO_Estado = 'X'
				And Doc.DOCCO_FechaDocumento Between '{1}' And '{2}'
      </code>
   </sql>
   <sql>
      <titulo>DGenerarReportes.GetStocksArticulos</titulo>
      <descripcion>R06</descripcion>
      <code>
			Select 
				 Li.LINEA_Codigo, SLi.LINEA_Codigo, Li.LINEA_Nombre As Linea, SLi.LINEA_Nombre As SubLinea
				,Art.ARTIC_Codigo ,Left(Art.ARTIC_Codigo, 2) + '.' + Left(Right(Art.ARTIC_Codigo, 5), 2) + '.' + Right(Art.ARTIC_Codigo, 3) As Codigo
				,Art.ARTIC_Descripcion As Descripcion
				,Sum(St.STOCK_Cantidad) StockAlmacen
				, (Select IsNull(Sum(Det.ORDCD_Cantidad), 0.0) From [Logistica].[ABAS_OrdenesCompra] As Doc
						Inner Join [Logistica].[ABAS_OrdenesCompraDetalle] As Det On Det.ORDCO_Codigo = Doc.ORDCO_Codigo
					Where Det.ARTIC_Codigo = Art.ARTIC_Codigo And Not Doc.ORDCO_Estado In ('X', 'C')
				)
				As OrdenCompra
				, (Select IsNull(Sum(Det.INGCD_Cantidad), 0.0) From [Logistica].[ABAS_IngresosCompra] As Doc
						Inner Join [Logistica].[ABAS_IngresosCompraDetalle] As Det On Det.INGCO_Codigo = Doc.INGCO_Codigo
					Where Det.ARTIC_Codigo = Art.ARTIC_Codigo And Not Doc.INGCO_Estado In ('X', 'C')
				)
				As Transito
				,Convert(Integer, 0) As Orden
			From Articulos As Art
				Inner Join Stocks As St On St.ARTIC_Codigo = Art.ARTIC_Codigo
				Inner Join Lineas As Li On Li.LINEA_Codigo = Left(Art.LINEA_Codigo, 2)
				Inner Join Lineas As SLi On SLi.LINEA_Codigo = Art.LINEA_Codigo
			{0}
			Group By Art.ARTIC_Codigo, Art.ARTIC_Descripcion
				,Li.LINEA_Nombre, SLi.LINEA_Nombre, Li.LINEA_Codigo, SLi.LINEA_Codigo
			Order By Li.LINEA_Codigo, SLi.LINEA_Codigo
      </code>
   </sql>
   <sql>
      <titulo>DGenerarReportes.GetPendientesXProveedor</titulo>
      <descripcion>R07</descripcion>
      <code>
			Select CabDoc.DOCCO_Codigo, CabDoc.ENTID_CodigoProveedor
				,CabDoc.DOCCO_FechaDocumento
				,Case CabDoc.TIPOS_CodTipoDocumento When 'CPD12' Then
					TDoc.TIPOS_DescCorta + ' ' + Right('0000' + CabDoc.DOCCO_Serie, 4) + '-' + Right('000000000' + RTrim(CabDoc.DOCCO_Numero), 9) 
				Else
					TDoc.TIPOS_DescCorta + ' ' + Right('000' + CabDoc.DOCCO_Serie, 3) + '-' + Right('0000000' + RTrim(CabDoc.DOCCO_Numero), 7) 
				 End As Documento
				,Art.ARTIC_Descripcion
				,Art.ARTIC_Codigo
				,TUni.TIPOS_Descripcion As TIPOS_UnidadMedida
				,IsNull(DetDoc.DOCCD_PesoUnitario, 0.0) As INGCD_PesoUnitario
				,DetDoc.DOCCD_Cantidad As INGCD_CantidadTotal
				,IsNull(Det.INGCD_Cantidad, 0.0) As Ingresado
				,IsNull(DetTran.INGCD_Cantidad, 0.0) As Transito
				,(IsNull(DetDoc.DOCCD_Cantidad, 0.0) - (IsNull(Det.INGCD_Cantidad, 0.0) + IsNull(DetTran.INGCD_Cantidad, 0.0))) As Pendiente
			From Logistica.ABAS_DocsCompraDetalle As DetDoc
				Left Join [Logistica].[ABAS_DocsCompra] As CabDoc On CabDoc.DOCCO_Codigo = DetDoc.DOCCO_Codigo And CabDoc.ENTID_CodigoProveedor = DetDoc.ENTID_CodigoProveedor
				Left Join (
					Select ARTIC_Codigo, Sum(Det.INGCD_Cantidad) As INGCD_Cantidad
						,Ing.ENTID_CodigoProveedor, Ing.ORDCO_Codigo
					From Logistica.ABAS_IngresosCompra As Ing
						Inner Join Logistica.ABAS_IngresosCompraDetalle As Det
							On Det.ORDCO_Codigo = Ing.ORDCO_Codigo And Det.INGCO_Interno = Ing.INGCO_Interno
					Where Ing.ENTID_CodigoProveedor = '{0}' And Ing.INGCO_Estado = 'C'
						And Ing.INGCO_FechaDocumento Between '{1}' And '{2}'
					Group By ARTIC_Codigo, Ing.ENTID_CodigoProveedor, Ing.ORDCO_Codigo
				) As Det 
					On Det.ARTIC_Codigo = DetDoc.ARTIC_Codigo And Det.ENTID_CodigoProveedor = CabDoc.ENTID_CodigoProveedor
						And Det.ORDCO_Codigo = CabDoc.ORDCO_Codigo
				Left Join (
					Select ARTIC_Codigo, Sum(Det.INGCD_Cantidad) As INGCD_Cantidad
						,Ing.ENTID_CodigoProveedor, Ing.ORDCO_Codigo
					From Logistica.ABAS_IngresosCompra As Ing
						Inner Join Logistica.ABAS_IngresosCompraDetalle As Det
							On Det.ORDCO_Codigo = Ing.ORDCO_Codigo And Det.INGCO_Interno = Ing.INGCO_Interno
					Where Ing.ENTID_CodigoProveedor = '{0}' And Ing.INGCO_Estado = 'I'
							And Ing.INGCO_FechaDocumento Between '{1}' And '{2}'
					Group By ARTIC_Codigo, Ing.ENTID_CodigoProveedor, Ing.ORDCO_Codigo
				) As DetTran 
					On DetTran.ARTIC_Codigo = DetDoc.ARTIC_Codigo And DetTran.ENTID_CodigoProveedor = CabDoc.ENTID_CodigoProveedor
						And DetTran.ORDCO_Codigo = CabDoc.ORDCO_Codigo
				Inner Join Articulos As Art
					On Art.ARTIC_Codigo = DetDoc.ARTIC_Codigo
				Inner Join Tipos As TUni
					On TUni.TIPOS_Codigo = Art.TIPOS_CodUnidadMedida
				Inner Join Tipos As TDoc 
					On TDoc.TIPOS_Codigo = CabDoc.TIPOS_CodTipoDocumento
			Where DetDoc.ENTID_CodigoProveedor = '{0}'
				And (IsNull(DetDoc.DOCCD_Cantidad, 0.0) - IsNull(Det.INGCD_Cantidad, 0.0)) > 0
				And Not CabDoc.DOCCO_Estado = 'X'
				And CabDoc.DOCCO_FechaDocumento Between '{1}' And '{2}'
      </code>
   </sql>
   <sql>
      <titulo>DGenerarReportes.GetComprasXProveedorXFecha</titulo>
      <descripcion></descripcion>
      <code>
			Declare @AnhoIni As Integer	Set @AnhoIni = {1}
			Declare @MesIni As Integer	Set @MesIni = {2}
			Declare @AnhoFin As Integer	Set @AnhoFin = {3}
			Declare @MesFin As Integer	Set @MesFin = {4}
			Declare @FecIni As DateTime Set @FecIni = RTrim(@AnhoIni) + '-01-' + RTrim(@MesIni) 
			Declare @FecFin As DateTime Set @FecFin = RTrim(@AnhoFin) + '-01-' + RTrim(@MesFin) 

			Create Table #Fechas(Anho Integer, Mes Integer)

			While (@AnhoIni &lt; @AnhoFin)
			Begin
				If @MesIni = 13
				Begin
					Set @MesIni = 1
				End
				While (@MesIni &lt; 13)
				Begin
					Insert Into #Fechas(Anho, Mes) Values (@AnhoIni, @MesIni)
					Set @MesIni = @MesIni + 1
				End
				Set @AnhoIni = @AnhoIni + 1
			End

			Declare @i as Integer
			Set @i = 1
			While (@i &lt;= @MesFin)
			Begin
				Insert Into #Fechas(Anho, Mes) Values (@AnhoIni, @i)
				Set @i = @i + 1
			End

			Select Det.ARTIC_Codigo, Art.ARTIC_Descripcion Into #Artic From [Logistica].[ABAS_DocsCompra] As Cab
				Inner Join [Logistica].[ABAS_DocsCompraDetalle] As Det
					On Det.DOCCO_Codigo = Cab.DOCCO_Codigo And Det.ENTID_CodigoProveedor = Cab.ENTID_CodigoProveedor
				Inner Join Articulos As Art On Art.ARTIC_Codigo = Det.ARTIC_Codigo
			Where Not Cab.DOCCO_Estado = 'X'
				And Cab.ENTID_CodigoProveedor = '{0}'
			Group By Det.ARTIC_Codigo, Art.ARTIC_Descripcion

			Select * From #Fechas
			Select * From #Artic

			Select Det.ARTIC_Codigo, Art.ARTIC_Descripcion
				,Cab.DOCCO_FechaDocumento, Cab.ENTID_CodigoProveedor, Det.DOCCD_Cantidad From [Logistica].[ABAS_DocsCompra] As Cab
				Inner Join [Logistica].[ABAS_DocsCompraDetalle] As Det
					On Det.DOCCO_Codigo = Cab.DOCCO_Codigo And Det.ENTID_CodigoProveedor = Cab.ENTID_CodigoProveedor
				Inner Join Articulos As Art On Art.ARTIC_Codigo = Det.ARTIC_Codigo
			Where Not Cab.DOCCO_Estado = 'X'
				And Cab.ENTID_CodigoProveedor = '{0}'
				And Cab.DOCCO_FechaDocumento Between @FecIni And @FecFin

      </code>
   </sql>
   <sql>
      <titulo>R</titulo>
      <descripcion></descripcion>
      <code>

      </code>
   </sql>
</xml>