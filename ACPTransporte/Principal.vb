Imports ACPTransportes
Imports ACFramework
Imports System.Security.Cryptography
Imports DAConexion
Imports System.Threading
Imports System.Windows
Imports ACSeguridad
Imports ACBTransporte
Imports ACETransporte
Imports System.IO
Imports System.Text
Imports System.Globalization
Imports ACEVentas
Imports RestSharp

Public Class Principal

#Region " Variables "
   Private Shared m_usuario As String
   Private Shared m_basedatos As String
   Private Shared m_empresa As String
   Private Shared m_aplicacion As String
   Private Shared m_baseadmin As String
   Private Shared m_servidor As String
   Private Shared m_userSql As String
   Private Shared m_passSql As String
   Private Shared m_tag As String
   Private Shared nameFilePrv As String
   Private Shared m_cmdArgs As ObjectModel.ReadOnlyCollection(Of String)
   Private m_tsplash As Integer = 3

   Private m_msg_nodisponible As String = "Opción no disponible."
   Private m_msg_mensaje As String = "Consulte al administrador de sistema para habilitar opciones."

   Private m_formatofecha As String


    'variables para los Seguros 
    Private managerB_TRAN__VehiculosSeguros As BTRAN_VehiculosSeguros
    Private managerE_TRAN__VehiculosSeguros As ETRAN_VehiculosSeguros
    Private managerB_TRAN_Entidades As MEntidad

    Private managerB_TRAN_VehiculosMantenimiento As BTRAN_VehiculosMantenimiento
    Private managerE_TRAN_VehiculosMantenimiento As ETRAN_VehiculosMantenimiento
    Private bindingSource_Seguros As BindingSource
    Private bindingSource_Mantenimiento As BindingSource

    Private m_picture As PictureBox
#End Region

#Region " Propiedades "

#End Region

#Region " Constructores "
    ' <summary>
    ' Cadena de Conexion 
    ' Usuario%BaseDatos%Empresa%Aplicacion%BaseDatosAdmin%Servidor%UsuarioBD%PasswordBD
    ' Cadena encriptada - Clave Privada
    ' Desarrollo
    ' 40975980%BDAcerosComerTransportes%ACERO%TRA%ACADMIN%192.168.30.3\SQL8%SA%varserv123%
    ' CTMtM9si9c7gN4OgykWu2JXgnNt8yImzbT6OEAX6hbwomoYNBAS29fAR+TgGJLNQGb6IH8+UUhMP1C7jl77Lx5fJ8dYjod9BxcSfMdHJfIdVxpvd++1Jf3ZIaHS+D1Lr26vilNoGvL3GKWeBPdy6NoCijXXln6gvjTK/PN3ppSw=
    'F1WkdrgnrrUKtwo6cPSgta7XMj5FMEBt4doIuU//WOD8cBqm07ASF9DzFhcklDyvKqQ2OojzPIC4uQhGMo87no0rYk8eRgAjvQ+jx5RQjlrWeuLf6YDlvVMv4K+wp6FswOBZ/6eTKG8tOsABzxtjLxKzjzVZjmNAh7Ck+bVYN/c= 
    ' 
    ' Aceros Comerciales
    ' 40975980%BDAcerosComer%ACERO%TRA%ACADMIN%192.168.30.2\SQL8%SA%varserv123%
    ' mLlE3lWHLX84zh67LHaaGVcBEzSdhlNdNMk7wFApMsYffco/89r6XzPEBPJJvppukkQzJdDOWQTnajLpRqEuOJXw1R8xisKQ6YWvunUybaPpvGxp90juVYScfXyk3ikHJCPs4BiumRpP/Ozkr9ga+R1awfTbJDeeN+nR3iQPDtg=
    ' Jose Raul Ancori Muñoz
    ' 40975980%BDJRAncori%JRANC%TRA%ACADMIN%192.168.30.2\SQL8%SA%varserv123%
    ' EA2UylsPkcflqAEdTyTK5ngCUhWBkJ3+fpPrp2rKUHWAO4h77jRvaHK4OWDBMj4b6GL1VQsr2JPBKpIzlETAYyTh3E/VaXh2WUBoDJv+kqDzxUkpK+aLjdNXiLMk5R3Xp7/G8ba2DfE4l7VrSbmsSu3UglK+xQVdHPyLgH+UGV4=
    ' 
    '*********************************************************************
    ' 44274911%BDAceCom%ACERO%TRA%ACADMIN%192.168.30.5\SQL8%SA%varserv123%
    ' AGCJ7BdkrhjVUz830CSxmgrpNfd8OcU+utCY9D3M5HGjR+ZbeCYSeZCHGpUPYfowqG15HQB5U4dsVORxdFBnP6euJnMlWrtszADHFsuXOImob+XQLM44uo0lFTAOs2LeZ0bkWl0wFYaaESNzwB4RfeZQOSpcqB6xUQJKdAXPRuc=
    ' 
    'Cadena Milagros Aceros Comerciales
    ' qtwoPh92Du2rV2RdcONdg3EsStKl4UGEM9yilJSvfnq5UXNzWoCmq9/q17RHkluD/V06nORqUpmdwsFQljJs5ynYFMHqIuLFW0UAkrBtUyjXPJ4iy5AU93KJW2ZC3jnfJZvzNgoxTNGCwY60qsyBVfy3POAhLi2m5cgqyo+PPII= 
    'cadena alex 30.3     
    'GYiIJVYK/WA+CxYdNq3Un3LdtJaByDHNyxUcVmft7gCbdLpxFnef3knxfNZw1/Lt00mmXtlMd/bksoXzzGLg45ec8pjtqroBtwaHlSyuNERMm+YjlZw20W+YXdiJbxJTeANBiRli4AI6jABWavK3UvnhEYyFZg9hbaisAtlJWEs=   
    'cadena alex 30.2     
    'YXBtmwpzK6yZpMVMprgIdEL1n3mAOHJ9w3p4PTCDU+12Vbpc87jSgv9Cg6YED/akUFYzhLAH+0gI5WMuP5pbXptjyK2WE4sgEOnJF1rmJpEMGZy/+JIYvp7UQ0JqiKip0c4KIIztJJamiQ6tGKOzF43q1BtK+E66eaVYEbBLFwo=
    '==================================================================================================================================================================================================================================================================================

    'Cadena Conexion Usuario SA FRANK  192.168.30.2\SQL8
    'Sxt+PI3lfA/JRMDdlAmLIBYfMduJt5AC+rJ1jcKnXemYIG3dQRYkrogNZa3mw6hae4tiecpABAEMlSnp/C9cCqAaq6hzpYr7B4c9icgReekl6cgclG3XTnj0Z27OVqjQoyMy6EduZT2BQsRBeViV8liX9Ly4oUyUJz8o8/ERMfk=
    'Cadena Conexion Usuario SA FRANK 192.168.30.235\SQL8
    'BXDI3yCJtc05KDOPhvhETEEK77PuBOL0BCxThNyopmpuCmdjT43bE+jyH6dkIzkau4b53yQU5OelJ0A3/FS2Z30HRHIuHRh6tj9vRyfs+5YLWFY5kH+WxgNrBrVKylWHoLw6waYkKt5x7pSOAiq1fm+gyOCAf8Z/1rcI9wAQELI=

    'Cadena Conexion Usuario Frank 192.168.30.235\SQL8


    'Cadena Conexion FRANK 192.168.30.235 SIN EXTENSION  
    'LYVh79ogfva8DQQji7DcxrF7Scmv1/JIZO+BC488vWXhRT9ZbHxQ8K6tURPyxOihqtTJcz0z1b6UaYTH81MnExn4GlZEunICLA3zH1zI6Vr8Z6qARp4t5eTb6h1CnCRVMfARMlMKxxEpKuFkheozCCiy2u29pvWLzt5CNHJBIhg=


    '===================================================================================================================================================================================================================================================================================
    ' F1WkdrgnrrUKtwo6cPSgta7XMj5FMEBt4doIuU//WOD8cBqm07ASF9DzFhcklDyvKqQ2OojzPIC4uQhGMo87no0rYk8eRgAjvQ+jx5RQjlrWeuLf6YDlvVMv4K+wp6FswOBZ/6eTKG8tOsABzxtjLxKzjzVZjmNAh7Ck+bVYN/c=
    ' Privada
    ' <RSAKeyValue><Modulus>zEqM6HLkF6wv2j+wSgfiFvdpKqAXTDTCqOxnW5R7mK4voDvH3sTOCjZ7eEkgh78ZQarTIXs0rOeGD+cSy8Msv2nape/UJp+ehmPmyEqEucxV/M6cOtT+F0+MbX3y4BKX/IntFhVkjKt8OXD2LHBhD4nPUIaePQoNJ5IUFwKLYn0=</Modulus><Exponent>AQAB</Exponent><P>/CWkisV1jWko18lbA89iO6EnZ1gn+o3YhqNra0R3vzQeImGDmIJcmN9k1S3D1nr8ktjhFnabVE6rrgfU1UyoAw==</P><Q>z2m0IcrQtLAKIf9R8YhYHn0MhzcY+/gi/o4gF1XR4utIxRxePmWr6AELIAaCd42IhjJ+HCKNbjmBe2jDjoQDfw==</Q><DP>DjFsPqd4w3n845Cg/+jnhaW/mxCaR38+he2i+UnEV83uOE824hnMbop8mYdW87a+iuGMYgBRJAC9pzEnqM4E0w==</DP><DQ>ksZhg1xLruG4efB842gxu3mQaQszcfNZiDu5N+oyOdt4RoxZoNw/91Dtt38DymhsyVJn7a8B2JN3LoanhG2lLw==</DQ><InverseQ>G82lJlLrAJMmtiJMnCpulBuhlXmYF7hG1CRQ3LoOc9/zCajA6iQkj08x5LrIjB9HNMW8+t+yh6TfZmOiwRHeEQ==</InverseQ><D>ZNqBCdh+Znlo/lPm0gVmRnRKBPMXzVVWrFJZDEsXYV7MwEwC9iUumrge6FkhqCJdc5/Dr4nFjX6XHo6zJsjp84qMHk6Q2dkRkwaWamP4XPukMpT5kvmTThTuHRYau9o2jZitUZtvmUf3tNZV+SkHkQDumtshzssoCP9Th5URFHk=</D></RSAKeyValue>
    ' Publica
    ' <RSAKeyValue><Modulus>zEqM6HLkF6wv2j+wSgfiFvdpKqAXTDTCqOxnW5R7mK4voDvH3sTOCjZ7eEkgh78ZQarTIXs0rOeGD+cSy8Msv2nape/UJp+ehmPmyEqEucxV/M6cOtT+F0+MbX3y4BKX/IntFhVkjKt8OXD2LHBhD4nPUIaePQoNJ5IUFwKLYn0=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>
    ' 
    ' </summary>
    ' <remarks></remarks>
    Public Sub New()

      ' This call is required by the Windows Form Designer.
      InitializeComponent()
      m_formatofecha = "yyyy-MM-dd HH:mm:ss.fff"
      Try
         ' Add any initialization after the InitializeComponent() call.

         m_cmdArgs = My.Application.CommandLineArgs
         Dim tAux As New Thread(New ThreadStart(AddressOf InicializarAplicacion))
         tAux.Start()
         While Not tAux.IsAlive
         End While

         spVersion.Text = String.Format(spVersion.Text, My.Application.Info.Version.ToString())
         ' & Application.ProductVersion.ToString()
         Dim frmss As New SSInicio(m_tsplash, tAux)
         frmss.ShowDialog(Me)
         frmss.Dispose()

         m_visible = True
         tsbtnShowHide_Click(Nothing, Nothing)

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Iniciando Aplicación", ex)
         End
      End Try
   End Sub

   Private Sub Principal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         If GApp.EUsuario.NIVE_Codigo.Equals("001") Then
            tsbtnGenerarMenu.Visible = True
            tsbtnGenerarMenu.Enabled = True
         Else
            tsbtnGenerarMenu.Visible = False
            tsbtnGenerarMenu.Enabled = False
         End If
         '' Cargar el entorno de Trabajo
         Using _frmentorno As New ACEntornoTrabajo()
            If _frmentorno.ShowDialog() = Windows.Forms.DialogResult.OK Then
               ' Cargar los permisos de la base de administración
               Dim x_validar As New ACGenerarMenu(GApp.DataConexion, GApp.DataUsuario, mnuPrincipal, ACTypeQueryMenu.asignarMenu, m_formatofecha)
               Dim _empresa As New ACBVentas.BEntidades
               If _empresa.Cargar(x_validar.Empresa.EMPR_RUC) Then
                  x_validar.Empresa.EMPR_Desc = _empresa.Entidades.ENTID_RazonSocial
               End If
               GApp.SetEmpresa(x_validar.Empresa)

               tspUsuario.Text = GApp.EUsuarioEntidad.ENTID_Nombres
               ' Cargar Valores de Informacion del sistema y de la conexion
               Dim _cad As String = "| Servidor: {0}    | Base Datos: {1}    | Sucursal : {2}  | Punto de Venta : {3}"
               tslblUbicacion.Text = String.Format(_cad, GApp.Servidor, GApp.BaseDatos, GApp.ESucursal.SUCUR_Nombre, GApp.EPuntoVenta.PVENT_Descripcion)
               Me.Text = String.Format("{0} - {1} ({2}/{3}) ", GApp.EEmpresa.EMPR_Desc, My.Application.Info.Title, GApp.ESucursal.SUCUR_Nombre, GApp.EPuntoVenta.PVENT_Descripcion)
               spVersion.Text = String.Format("Version: {0}", My.Application.Info.Version.ToString())
               '' Verificar version
               Dim _bool As Boolean
               Dim _version As String = Parametros.GetParametro("pg_VersionTRA", _bool).ToString()
               If Not _version.Equals(My.Application.Info.Version.ToString()) Then
                  spVersion.ForeColor = Color.White
                  spVersion.BackColor = Color.Red
                  spVersion.Font = New Font(spVersion.Font, FontStyle.Bold)
               End If
               If CType(Utilitarios.cConfig("pathfondo"), PXML).Valor <> "" Then
                  Dim PictureFile As String = CType(Utilitarios.cConfig("pathfondo"), PXML).Valor
                  Me.BackgroundImageLayout = Utilitarios.cConfiguracion.FondoLayout
                  If GApp.EmpresaCodigo.Equals("ACERO") Then
                     Me.BackgroundImage = Overlay(System.Drawing.Image.FromFile(PictureFile), ACPTransportes.My.Resources.Logo_Sistema_419x63, Color.White)
                  ElseIf GApp.EmpresaCodigo.Equals("JRANC") Then
                     Me.BackgroundImage = Overlay(System.Drawing.Image.FromFile(PictureFile), ACPTransportes.My.Resources.Logo_Sistema_JRAM_419x63, Color.White)
                  Else
                     Me.BackgroundImage = Overlay(System.Drawing.Image.FromFile(PictureFile))
                  End If
               ElseIf GApp.EmpresaCodigo.Equals("ACERO") Then
                  Me.BackgroundImageLayout = ImageLayout.Stretch
                  Me.BackgroundImage = Overlay(ACPTransportes.My.Resources.Wallpaper_Transportes_1204x768, ACPTransportes.My.Resources.Logo_Sistema_419x63, Color.White)
               ElseIf GApp.EmpresaCodigo.Equals("JRANC") Then
                  Me.BackgroundImageLayout = ImageLayout.Stretch
                  Me.BackgroundImage = Overlay(ACPTransportes.My.Resources.Wallpaper_Transportes_JRAM_1024x768, ACPTransportes.My.Resources.Logo_Sistema_JRAM_419x63, Color.White)
               Else
                  Me.BackgroundImageLayout = ImageLayout.Stretch
                  Me.BackgroundImage = Overlay(ACPTransportes.My.Resources.Wallpaper_Transportes_1204x768)
               End If
            Else
               Me.Close()
            End If
         End Using
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede cargar los dialogos iniciales", ex)
         Me.Close()
      End Try
   End Sub

#End Region

#Region " Metodos "
   
Private Shared Sub InicializarAplicacion()
      'Dim nameFilePub As String = "cpb_" + DateTime.Now.ToString("yyyyMMddhh") & ".xml"
      nameFilePrv = Path.Combine(Application.StartupPath.ToString, String.Format("cpv_{0:yyyyMMddhh}.xml", DateTime.Now))
      Try
         If (m_cmdArgs(0).ToString().Length = 13) Then
            'Return
            Throw New Exception("Error")
         Else
            Dim x_cprivada As New StringBuilder()
            Dim res As String = ""
            If (m_cmdArgs.Count > 1) Then
               Dim _clave As String = "<RSAKeyValue xmlns="""">"
               _clave &= m_cmdArgs(1)
               _clave &= "</RSAKeyValue>"
               res = ACFramework.ACUtilitarios.ACDesEncriptarRSA(m_cmdArgs(0), _clave)
            Else
               Dim exe As Boolean = True
               Dim i As Integer = 0
               While exe
                  If Not (File.Exists(nameFilePrv)) Then
                     System.Threading.Thread.Sleep(1000)
                     Application.DoEvents()
                     i += 10
                     If i > 10 Then Exit While
                  Else
                     exe = False
                  End If
               End While
               If (File.Exists(nameFilePrv)) Then
                  Dim stream As New FileStream(nameFilePrv, FileMode.Open, FileAccess.Read)
                  Dim reader As New StreamReader(stream, Encoding.UTF8)
                  While reader.Peek() > -1
                     x_cprivada.Append(reader.ReadLine())
                  End While
                  reader.Close()
                  res = ACFramework.ACUtilitarios.ACDesEncriptarRSA(m_cmdArgs(0), x_cprivada.ToString())
               Else
                  Dim _clave As String = "<RSAKeyValue xmlns="""">"
                  _clave &= "<Modulus>zEqM6HLkF6wv2j+wSgfiFvdpKqAXTDTCqOxnW5R7mK4voDvH3sTOCjZ7eEkgh78ZQarTIXs0rOeGD+cSy8Msv2nape/UJp+ehmPmyEqEucxV/M6cOtT+F0+MbX3y4BKX/IntFhVkjKt8OXD2LHBhD4nPUIaePQoNJ5IUFwKLYn0=</Modulus><Exponent>AQAB</Exponent><P>/CWkisV1jWko18lbA89iO6EnZ1gn+o3YhqNra0R3vzQeImGDmIJcmN9k1S3D1nr8ktjhFnabVE6rrgfU1UyoAw==</P><Q>z2m0IcrQtLAKIf9R8YhYHn0MhzcY+/gi/o4gF1XR4utIxRxePmWr6AELIAaCd42IhjJ+HCKNbjmBe2jDjoQDfw==</Q><DP>DjFsPqd4w3n845Cg/+jnhaW/mxCaR38+he2i+UnEV83uOE824hnMbop8mYdW87a+iuGMYgBRJAC9pzEnqM4E0w==</DP><DQ>ksZhg1xLruG4efB842gxu3mQaQszcfNZiDu5N+oyOdt4RoxZoNw/91Dtt38DymhsyVJn7a8B2JN3LoanhG2lLw==</DQ><InverseQ>G82lJlLrAJMmtiJMnCpulBuhlXmYF7hG1CRQ3LoOc9/zCajA6iQkj08x5LrIjB9HNMW8+t+yh6TfZmOiwRHeEQ==</InverseQ><D>ZNqBCdh+Znlo/lPm0gVmRnRKBPMXzVVWrFJZDEsXYV7MwEwC9iUumrge6FkhqCJdc5/Dr4nFjX6XHo6zJsjp84qMHk6Q2dkRkwaWamP4XPukMpT5kvmTThTuHRYau9o2jZitUZtvmUf3tNZV+SkHkQDumtshzssoCP9Th5URFHk=</D>"
                  _clave &= "</RSAKeyValue>"
                  Try
                     res = ACFramework.ACUtilitarios.ACDesEncriptarRSA(m_cmdArgs(0), _clave)
                     exe = True
                  Catch ex As Exception
                     MsgBox(String.Format("Error: No existe configuracion de seguridad {0}{1}", vbNewLine, ex.Message))
                  End Try
                  If Not exe Then Throw New Exception(String.Format("Error: {0}", vbNewLine)) 'Return
               End If
            End If

            Dim _argumentos As String() = res.ToString().Split("%"c)
            If (_argumentos.Length > 0) Then m_usuario = _argumentos(0)
            If (_argumentos.Length > 1) Then m_basedatos = _argumentos(1)
            If (_argumentos.Length > 2) Then m_empresa = _argumentos(2)
            If (_argumentos.Length > 3) Then m_aplicacion = _argumentos(3)
            If (_argumentos.Length > 4) Then m_baseadmin = _argumentos(4)
            If (_argumentos.Length > 5) Then m_servidor = _argumentos(5)
            If (_argumentos.Length > 6) Then m_userSql = _argumentos(6)
            If (_argumentos.Length > 7) Then : m_passSql = _argumentos(7)
            Else : m_passSql = ""
            End If
            If (_argumentos.Length > 7) Then : m_tag = _argumentos(7)
            Else : m_tag = ""
            End If

            If ACUtilitarios.ACCrearCadena("StrConn", m_servidor, m_basedatos, m_userSql, m_passSql) Then
               DAEnterprise.Instanciar("StrConn")
               GApp.Inicializar(m_empresa, m_aplicacion, m_usuario, m_servidor, m_basedatos, m_baseadmin, m_userSql, m_passSql)
               Colecciones.Inicializar(True)
            Else
               MessageBox.Show("Error inicializando datos")
               Throw New Exception("Error General de Conexion")
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(String.Format("Error inicializando datos{0}{1}", vbNewLine, ex.Message))
         Throw ex
      End Try
   End Sub

   Public Function Overlay(ByVal SourceImage As Image, ByVal OverlayImage As Bitmap, ByVal ColorTransparent As Color) As Bitmap
      Try
         Dim g As Graphics
         'Obtengo Graphic de la imagen de fondo para poder dibujar sobe ella
         g = Drawing.Graphics.FromImage(SourceImage)
         'Hago trasparente la imagen que vamos a superponer	
         OverlayImage.MakeTransparent(ColorTransparent)
         ' Calcular la Posicion de la Imagen
         Dim x_source As Integer = SourceImage.Width : Dim y_source As Integer = SourceImage.Height
         Dim x_over As Integer = OverlayImage.Width : Dim y_over As Integer = OverlayImage.Height
         Dim x_posbelow As Integer = x_source - (x_over + 5) : Dim y_posbelow As Integer = y_source - (y_over + 5)
         Dim x_posover As Integer = 5 : Dim y_posover As Integer = 5
         'Dibujo la imagen sobre el fondo
         g.DrawImageUnscaledAndClipped(OverlayImage, New Rectangle(New Point(x_posbelow, y_posbelow), New Size(x_over, y_over)))
         g.DrawImageUnscaledAndClipped(OverlayImage, New Rectangle(New Point(x_posover, y_posover), New Size(x_over, y_over)))
         'Elimino manejador grafico
         g.Dispose()
         'Devuelve la imagen mezclada
         Return SourceImage
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function Overlay(ByVal SourceImage As Image) As Bitmap
      Try
         Dim g As Graphics
         'Obtengo Graphic de la imagen de fondo para poder dibujar sobe ella
         g = Drawing.Graphics.FromImage(SourceImage)
         Return SourceImage
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Sub GrabarLayout()
      If Me.BackgroundImageLayout.ToString() <> CType(Utilitarios.cConfig("layout"), PXML).Valor Then
         Utilitarios.cConfig("layout") = New PXML(Me.BackgroundImageLayout.ToString(), "layout")
         Utilitarios.saveXML()
      End If
   End Sub

   Private Function Change_BackgroundImage(ByVal _path As String) As Boolean
      Dim imagepath As String = _path
      Dim fs As System.IO.FileStream
      ' MDI Form image background layout change here
      '(Remember control imagebakground layout take default form background layount )
      Me.BackgroundImageLayout = ImageLayout.Stretch
      ' Checking File exists if yes go --->
      If System.IO.File.Exists(imagepath) Then
         ' Read Image file
         fs = System.IO.File.OpenRead(imagepath)
         fs.Position = 0
         ' Change MDI From back ground picture
         For Each ctl As Control In Me.Controls
            If TypeOf ctl Is MdiClient Then
               'ctl.BackColor = Color.AntiqueWhite;
               If System.Drawing.Image.FromStream(fs).Width > 500 And System.Drawing.Image.FromStream(fs).Height > 130 Then
                  If GApp.Empresa.Equals("ACERO") Then
                     ctl.BackgroundImage = Overlay(System.Drawing.Image.FromStream(fs), ACPTransportes.My.Resources.Logo_Sistema_419x63, Color.White)
                  Else
                     ctl.BackgroundImage = Overlay(System.Drawing.Image.FromStream(fs))
                  End If
               Else
                  ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Error: {0}", Me.Text), "La resolucion de la imagen no es adecuada")
                  Return False
               End If
               Exit For
            End If
         Next
         Return True
      End If
   End Function

#Region " Tool Bar Lateral "

   Private m_numeroform As Integer
   Private m_visible As Boolean
   Public Property PROP_NumeroForm() As String
      Get
         m_numeroform += 1
         Return m_numeroform
      End Get
      Set(ByVal value As String)
         m_numeroform = value
      End Set
   End Property

   Private Sub MDIParent1_MdiChildActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.MdiChildActivate
      Try
         Dim lfrmFormulario As Form = DirectCast(sender, Form).ActiveMdiChild
         Dim lintNumForm As Integer = toolRecientes.Items.IndexOfKey(lfrmFormulario.Name)
         If lintNumForm < 0 Then
            Me.ppAgregarBoton(lfrmFormulario)
         End If
      Catch ex As Exception

      End Try
   End Sub

   Private Sub frmFormulario_Disposed(ByVal sender As Object, ByVal e As EventArgs)
      ppQuitarBoton(DirectCast(sender, Form))
   End Sub

   Private Sub ppAgregarBoton(ByVal xfrmHijo As Form)
      Dim lobjBoton As New ToolStripButton()
      '-------------------------------------------------------------//
      xfrmHijo.Name = xfrmHijo.Name + PROP_NumeroForm.ToString()
      AddHandler xfrmHijo.Disposed, AddressOf frmFormulario_Disposed
      '-------------------------------------------------------------//

      Dim lstrTexto As String = xfrmHijo.Text

      lobjBoton.Name = xfrmHijo.Name
      lobjBoton.Text = lstrTexto
      lobjBoton.ToolTipText = lstrTexto
      lobjBoton.Alignment = ToolStripItemAlignment.Left
      lobjBoton.TextAlign = ContentAlignment.MiddleLeft

      If m_visible Then
         lobjBoton.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
      Else
         lobjBoton.DisplayStyle = ToolStripItemDisplayStyle.Image
      End If

      AddHandler lobjBoton.Click, AddressOf lobjBoton_Click
      lobjBoton.Image = xfrmHijo.Icon.ToBitmap()

      toolRecientes.Items.Add(lobjBoton)
   End Sub

   Private Sub ppQuitarBoton(ByVal xfrmHijo As Form)
      Try
         Dim lintNumForm As Integer = toolRecientes.Items.IndexOfKey(xfrmHijo.Name)
         If lintNumForm >= 0 Then
            toolRecientes.Items.RemoveAt(lintNumForm)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.ToString())
      End Try
   End Sub

   Private Sub lobjBoton_Click(ByVal sender As Object, ByVal e As EventArgs)
      For Each lfrmHijo As Form In Me.MdiChildren
         If lfrmHijo.Name = DirectCast(sender, ToolStripButton).Name Then
            'Me.MdiChildActivate -= New System.EventHandler(Me.frmPrincipal_MdiChildActivate)
            RemoveHandler Me.MdiChildActivate, AddressOf MDIParent1_MdiChildActivate
            lfrmHijo.Activate()
            'Me.MdiChildActivate += New System.EventHandler(Me.frmPrincipal_MdiChildActivate)
            AddHandler Me.MdiChildActivate, AddressOf MDIParent1_MdiChildActivate
            Exit For
         End If
      Next
   End Sub

   Private Sub tsbtnShowHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnShowHide.Click
      Try
         m_visible = Not m_visible
         If m_visible Then
            For Each control As ToolStripItem In toolRecientes.Items
               If Not control.[GetType]() Is System.Type.[GetType]("System.Windows.Forms.ToolStripSeparator") Then
                  DirectCast(control, ToolStripItem).DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
               End If
            Next

            tsbtnShowHide.Image = Global.ACPTransportes.My.Resources.hidemenu
            tsbtnShowHide.ToolTipText = "Ocultar Menu"
            tsbtnShowHide.Text = "Ocultar Menu"
         Else
            For Each control As ToolStripItem In toolRecientes.Items
               If Not control.[GetType]() Is System.Type.[GetType]("System.Windows.Forms.ToolStripSeparator") Then
                  DirectCast(control, ToolStripItem).DisplayStyle = ToolStripItemDisplayStyle.Image
               End If
            Next

            tsbtnShowHide.Image = Global.ACPTransportes.My.Resources.showmenu
            tsbtnShowHide.ToolTipText = "Mostrar Menu"
         End If
      Catch ex As Exception

      End Try
   End Sub
#End Region
#End Region

#Region " Metodos de Controles"

   Private Sub tsbtnGenerarMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnGenerarMenu.Click
      Try
         If GApp.EUsuario.NIVE_Codigo.Equals("001") And ACControles.ACDialogos.ACMostrarMensajePregunta(String.Format("Generar Menu: {0}", Me.Text) _
                      , "Desea Generar el Menu de la Aplicación? " _
                      , "Al aceptar se volvera a recrear todo el menu en el administrador de aplicaciones" _
                      , ACControles.ACDialogos.LabelBotom.Si_No) = DialogResult.Yes Then
            Dim x_generar As New ACSeguridad.ACGenerarMenu(GApp.DataConexion, GApp.DataUsuario, mnuPrincipal, ACTypeQueryMenu.generarMenu, m_formatofecha)
            ACControles.ACDialogos.ACMostrarMensajeSatisfactorio(String.Format("Información: {0}", Me.Text), "Generado Satisfactoriamente")
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "Ocurrio un error en el proceso Generar Menu", ex)
      End Try
   End Sub

   Private Sub Principal_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
      Try
         If File.Exists(nameFilePrv) Then
            File.SetAttributes(nameFilePrv, FileAttributes.Normal)
            File.Delete(nameFilePrv)
         End If
      Catch ex As Exception

      End Try
   End Sub

#Region " Imagen de Fondo"

   Private Sub OptimizadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptimizadoToolStripMenuItem.Click
      Me.BackgroundImageLayout = ImageLayout.Tile
      GrabarLayout()
   End Sub

   Private Sub ImagenPorDefectoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImagenPorDefectoToolStripMenuItem.Click
      Try
         Utilitarios.cConfig("pathfondo") = New PXML("", "pathfondo")
         If GApp.EmpresaCodigo.Equals("ACERO") Then
            Me.BackgroundImageLayout = ImageLayout.Stretch
            Me.BackgroundImage = Overlay(ACPTransportes.My.Resources.Wallpaper_Transportes_1204x768, ACPTransportes.My.Resources.Logo_Sistema_419x63, Color.White)
         Else
            Me.BackgroundImageLayout = ImageLayout.Stretch
            Me.BackgroundImage = Overlay(ACPTransportes.My.Resources.Wallpaper_Transportes_1204x768)
         End If
         Utilitarios.saveXML()
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede cargar la imagen de fondo", ex)
      End Try
   End Sub

   Private Sub NormalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NormalToolStripMenuItem.Click
      Me.BackgroundImageLayout = ImageLayout.None
      GrabarLayout()
   End Sub

   Private Sub CentradoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CentradoToolStripMenuItem.Click
      Me.BackgroundImageLayout = ImageLayout.Center
      GrabarLayout()
   End Sub

   Private Sub AjustarImagenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AjustarImagenToolStripMenuItem.Click
      Me.BackgroundImageLayout = ImageLayout.Stretch
      GrabarLayout()
   End Sub

   Private Sub MaximizadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaximizadoToolStripMenuItem.Click
      Me.BackgroundImageLayout = ImageLayout.Zoom
      GrabarLayout()
   End Sub

   Private Sub CambiarImagenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CambiarImagenToolStripMenuItem.Click
      Try
         Dim openFileDialog1 As New OpenFileDialog
         openFileDialog1.Filter = "Jpg|*.jpg"
         If openFileDialog1.ShowDialog() Then
            Dim Backpath As String = openFileDialog1.FileName
            If Change_BackgroundImage(Backpath) Then
               Utilitarios.cConfig("layout") = New PXML(Me.BackgroundImageLayout.ToString(), "layout")
               Utilitarios.cConfig("pathfondo") = New PXML(Backpath, "pathfondo")
               Utilitarios.saveXML()
            End If
         End If
      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), "No se puede cargar la imagen de fondo", ex)
      End Try
   End Sub

#End Region

#Region " Opciones Menu "

   Private Sub CambiarDeSesionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CambiarDeSesionToolStripMenuItem.Click
      For Each item As Windows.Forms.Form In Me.MdiChildren
         item.Close()
      Next
      Dim _frmentorno As New ACEntornoTrabajo()
      If _frmentorno.ShowDialog() = Windows.Forms.DialogResult.OK Then
         tspUsuario.Text = GApp.EUsuarioEntidad.ENTID_Nombres
         ' Cargar Valores de Informacion del sistema y de la conexion
         Dim _cad As String = "| Servidor: {0}    | Base Datos: {1}    | Sucursal : {2}  | Punto de Venta : {3}"
         tslblUbicacion.Text = String.Format(_cad, GApp.Servidor, GApp.BaseDatos, GApp.ESucursal.SUCUR_Nombre, GApp.EPuntoVenta.PVENT_Descripcion)
         Me.Text = String.Format("{0} - {1} ({2}) ", GApp.EEmpresa.EMPR_Desc, My.Application.Info.Title, GApp.ESucursal.SUCUR_Nombre)
         spVersion.Text = String.Format("Version: {0}", My.Application.Info.Version.ToString())
         '' Verificar version
         Dim _bool As Boolean
         Dim _version As String = Parametros.GetParametro("pg_VersionTRA", _bool).ToString()
         If Not _version.Equals(My.Application.Info.Version.ToString()) Then
            spVersion.ForeColor = Color.White
            spVersion.BackColor = Color.Red
            spVersion.Font = New Font(spVersion.Font, FontStyle.Bold)
         End If
         ' Cargar los permisos de la base de administración
         Dim x_validar As New ACGenerarMenu(GApp.DataConexion, GApp.DataUsuario, mnuPrincipal, ACTypeQueryMenu.asignarMenu, m_formatofecha)
         GApp.SetEmpresa(x_validar.Empresa)
      Else
         Me.Close()
      End If
   End Sub

   Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
      Me.Close()
   End Sub

#Region " Mantenimientos "

#Region " Entidad "

   Private Sub TransportistaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransportistaToolStripMenuItem.Click
      Dim frmEnt As New MEntidad(MEntidad.Inicio.Normal, ACEVentas.EEntidades.TipoEntidad.Transportista) With {.MdiParent = Me, .StartPosition = FormStartPosition.CenterScreen}
      frmEnt.Show()
   End Sub

   Private Sub ConductoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConductoresToolStripMenuItem.Click
      If ConductoresToolStripMenuItem.Enabled Then
         Dim frmEnt As New MEntidad(MEntidad.Inicio.Normal, ACEVentas.EEntidades.TipoEntidad.Conductores) With {.MdiParent = Me, .StartPosition = FormStartPosition.CenterScreen}
         frmEnt.Show()
      Else
         ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), m_msg_nodisponible, m_msg_mensaje)
      End If
   End Sub

   Private Sub ProveedoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProveedoresToolStripMenuItem.Click
      If ProveedoresToolStripMenuItem.Enabled Then
         Dim frmEnt As New MEntidad(MEntidad.Inicio.Normal, ACEVentas.EEntidades.TipoEntidad.Proveedores) With {.MdiParent = Me, .StartPosition = FormStartPosition.CenterScreen}
         frmEnt.Show()
      Else
         ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), m_msg_nodisponible, m_msg_mensaje)
      End If
   End Sub

   Private Sub ClientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClientesToolStripMenuItem.Click
      If ClientesToolStripMenuItem.Enabled Then
         Dim frmEnt As New MEntidad(MEntidad.Inicio.Normal, ACEVentas.EEntidades.TipoEntidad.Clientes) With {.MdiParent = Me, .StartPosition = FormStartPosition.CenterScreen}
         frmEnt.Show()
      Else
         ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), m_msg_nodisponible, m_msg_mensaje)
      End If
   End Sub

   Private Sub GeneralToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeneralToolStripMenuItem.Click, tsbtnEntidad.Click
      If GeneralToolStripMenuItem.Enabled Then
         Dim frmEnt As New MEntidad(MEntidad.Inicio.Normal, ACEVentas.EEntidades.TipoEntidad.Todos) With {.MdiParent = Me, .StartPosition = FormStartPosition.CenterScreen}
         frmEnt.Show()
      Else
         ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), m_msg_nodisponible, m_msg_mensaje)
      End If
   End Sub
#End Region

#Region " Generales "
   Private Sub SucursalesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SucursalesToolStripMenuItem.Click
      If SucursalesToolStripMenuItem.Enabled Then
         Dim frmSuc As New MSucursales()
         frmSuc.MdiParent = Me
         frmSuc.StartPosition = FormStartPosition.CenterScreen
         frmSuc.Show()
      Else
         ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), m_msg_nodisponible, m_msg_mensaje)
      End If
   End Sub

   Private Sub AlmacenesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlmacenesToolStripMenuItem.Click
      If AlmacenesToolStripMenuItem.Enabled Then
         Dim frmAlma As New MAlmacenes()
         frmAlma.MdiParent = Me
         frmAlma.StartPosition = FormStartPosition.CenterScreen
         frmAlma.Show()
      Else
         ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), m_msg_nodisponible, m_msg_mensaje)
      End If
   End Sub

   Private Sub TiposToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TiposToolStripMenuItem1.Click
      If TiposToolStripMenuItem1.Enabled Then
         Dim frmTipos As New MTipos()
         frmTipos.MdiParent = Me
         frmTipos.StartPosition = FormStartPosition.CenterScreen
         frmTipos.Show()
      Else
         ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), m_msg_nodisponible, m_msg_mensaje)
      End If
   End Sub

   Private Sub UbigeosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UbigeosToolStripMenuItem1.Click
      If UbigeosToolStripMenuItem1.Enabled Then
         Dim frmUbi As New MUbigeos()
         frmUbi.MdiParent = Me
         frmUbi.StartPosition = FormStartPosition.CenterScreen
         frmUbi.Show()
      Else
         ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), m_msg_nodisponible, m_msg_mensaje)
      End If
   End Sub

   Private Sub rutasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RutasToolStripMenuItem.Click
      If RutasToolStripMenuItem.Enabled Then
         Dim frmRutas As New MRutas()
         frmRutas.MdiParent = Me
         frmRutas.StartPosition = FormStartPosition.CenterScreen
         frmRutas.Show()
      Else
         ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), m_msg_nodisponible, m_msg_mensaje)
      End If
   End Sub
#End Region

   Private Sub neumaticosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles neumaticosToolStripMenuItem.Click
      If neumaticosToolStripMenuItem.Enabled Then
         Dim frmNeum As New MNeumaticos()
         frmNeum.MdiParent = Me
         frmNeum.StartPosition = FormStartPosition.CenterScreen
         frmNeum.Show()
      Else
         ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), m_msg_nodisponible, m_msg_mensaje)
      End If
   End Sub

#Region " Ranflas "
   Private Sub MantenimientoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MantenimientoToolStripMenuItem.Click
      If MantenimientoToolStripMenuItem.Enabled Then
         Dim frmRan As New MRamflas()
         frmRan.MdiParent = Me
         frmRan.StartPosition = FormStartPosition.CenterScreen
         frmRan.Show()
      Else
         ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), m_msg_nodisponible, m_msg_mensaje)
      End If
   End Sub

   Private Sub AsignarNeumaticosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AsignarNeumaticosToolStripMenuItem.Click
      If AsignarNeumaticosToolStripMenuItem.Enabled Then
         Dim frmPNeuma As New PNeumaticosVehiculos(PNeumaticosVehiculos.TipoUnidad.Ranflas)
         frmPNeuma.MdiParent = Me
         frmPNeuma.StartPosition = FormStartPosition.CenterScreen
         frmPNeuma.Show()
      Else
         ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), m_msg_nodisponible, m_msg_mensaje)
      End If
   End Sub
#End Region

#Region " Vehiculos "
   Private Sub PropiedadesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropiedadesToolStripMenuItem.Click
      If PropiedadesToolStripMenuItem.Enabled Then
         Dim frmVehi As New MVehiculos()
         frmVehi.MdiParent = Me
         frmVehi.StartPosition = FormStartPosition.CenterScreen
         frmVehi.Show()
      Else
         ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), m_msg_nodisponible, m_msg_mensaje)
      End If
   End Sub

   Private Sub GeneralidadesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeneralidadesToolStripMenuItem1.Click, tsbtnVehiculo.Click
      If GeneralidadesToolStripMenuItem1.Enabled Then
         Dim frmPVehiculos As New PVehiculos()
         frmPVehiculos.MdiParent = Me
         frmPVehiculos.StartPosition = FormStartPosition.CenterScreen
         frmPVehiculos.Show()
      Else
         ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), m_msg_nodisponible, m_msg_mensaje)
      End If
   End Sub

   Private Sub tsbtnRanflas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnRanflas.Click
      If MantenimientoToolStripMenuItem.Enabled Then
         Dim frmMRanflas As New MRamflas()
         frmMRanflas.MdiParent = Me
         frmMRanflas.StartPosition = FormStartPosition.CenterScreen
         frmMRanflas.Show()
      Else
         ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), m_msg_nodisponible, m_msg_mensaje)
      End If
   End Sub

   Private Sub tsbtnCotizaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnCotizaciones.Click
      If CotizacionesToolStripMenuItem.Enabled Then
         Dim frmPCotizaciones As New FCotizaciones()
         frmPCotizaciones.MdiParent = Me
         frmPCotizaciones.StartPosition = FormStartPosition.CenterScreen
         frmPCotizaciones.Show()
      Else
         ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), m_msg_nodisponible, m_msg_mensaje)
      End If
   End Sub


   Private Sub AsignaciónDeRanflasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AsignaciónDeRanflasToolStripMenuItem.Click
      If AsignaciónDeRanflasToolStripMenuItem.Enabled Then
         Dim frmPVehiculos As New PVehiculos(PVehiculos.TipoEdicion.Ranflas)
         frmPVehiculos.MdiParent = Me
         frmPVehiculos.StartPosition = FormStartPosition.CenterScreen
         frmPVehiculos.Show()
      Else
         ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), m_msg_nodisponible, m_msg_mensaje)
      End If
   End Sub

   Private Sub NeumaticosToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NeumaticosToolStripMenuItem2.Click
      If NeumaticosToolStripMenuItem2.Enabled Then
         Dim frmPNeuma As New PNeumaticosVehiculos()
         frmPNeuma.MdiParent = Me
         frmPNeuma.StartPosition = FormStartPosition.CenterScreen
         frmPNeuma.Show()
      Else
         ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), m_msg_nodisponible, m_msg_mensaje)
      End If
   End Sub

   Private Sub AsignarConductoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AsignarConductoresToolStripMenuItem.Click
      If AsignarConductoresToolStripMenuItem.Enabled Then
         Dim frmPVehiculos As New PVehiculos(PVehiculos.TipoEdicion.Conductores)
         frmPVehiculos.MdiParent = Me
         frmPVehiculos.StartPosition = FormStartPosition.CenterScreen
         frmPVehiculos.Show()
      Else
         ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), m_msg_nodisponible, m_msg_mensaje)
      End If
   End Sub

    Private Sub RegistroDeSegurosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistroDeSegurosToolStripMenuItem.Click
        If RegistroDeSegurosToolStripMenuItem.Enabled Then
            Dim frmPVehiculos As New PVehiculos(PVehiculos.TipoEdicion.Seguros)
            frmPVehiculos.MdiParent = Me
            frmPVehiculos.StartPosition = FormStartPosition.CenterScreen
            frmPVehiculos.Show()
        Else
            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), m_msg_nodisponible, m_msg_mensaje)
        End If
    End Sub
    Private Sub MantenimientosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles MantenimientosToolStripMenuItem1.Click
        'Mantenimiento _ Creador de  0
        If MantenimientosToolStripMenuItem1.Enabled Then
            Dim frmPVehiculos As New PVehiculos(PVehiculos.TipoEdicion.Mantenimiento)
            frmPVehiculos.MdiParent = Me
            frmPVehiculos.StartPosition = FormStartPosition.CenterScreen
            frmPVehiculos.Show()
        Else
            ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), m_msg_nodisponible, m_msg_mensaje)
        End If
    End Sub

    Private Sub RegistroDeIncidenciasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistroDeIncidenciasToolStripMenuItem.Click
      If RegistroDeIncidenciasToolStripMenuItem.Enabled Then
         Dim frmPVehiculos As New PVehiculos(PVehiculos.TipoEdicion.Incidencias)
         frmPVehiculos.MdiParent = Me
         frmPVehiculos.StartPosition = FormStartPosition.CenterScreen
         frmPVehiculos.Show()
      Else
         ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), m_msg_nodisponible, m_msg_mensaje)
      End If
   End Sub

#End Region

#End Region

#Region " Administracion "
#Region " Viajes "
   Private Sub DatosDelViajesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DatosDelViajesToolStripMenuItem.Click, tsbtnViajes.Click
      If DatosDelViajesToolStripMenuItem.Enabled Then
         Dim frmViajes As New FViajes(FViajes.TipoCarga.Base) With {.MdiParent = Me, .WindowState = FormWindowState.Maximized, .StartPosition = FormStartPosition.CenterScreen}
         frmViajes.Show()
      Else
         ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), m_msg_nodisponible, m_msg_mensaje)
      End If
   End Sub

   Private Sub GastosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GastosToolStripMenuItem.Click
      If GastosToolStripMenuItem.Enabled Then
         Dim frmViajesGastos As New PGastosViaje(FViajes.TipoCarga.Gastos, DateTime.Now)
         frmViajesGastos.MdiParent = Me
         frmViajesGastos.WindowState = FormWindowState.Maximized
         frmViajesGastos.StartPosition = FormStartPosition.CenterScreen
         frmViajesGastos.Show()
      Else
         ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), m_msg_nodisponible, m_msg_mensaje)
      End If
   End Sub

   Private Sub IngresosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresosToolStripMenuItem.Click
      If IngresosToolStripMenuItem.Enabled Then
         Dim frmViajesIngresos As New PIngresosViajes(FViajes.TipoCarga.Ingresos, DateTime.Now)
         frmViajesIngresos.MdiParent = Me
         frmViajesIngresos.WindowState = FormWindowState.Maximized
         frmViajesIngresos.StartPosition = FormStartPosition.CenterScreen
         frmViajesIngresos.Show()
      Else
         ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), m_msg_nodisponible, m_msg_mensaje)
      End If
   End Sub

   Private Sub IncidenciasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IncidenciasToolStripMenuItem.Click
      If IncidenciasToolStripMenuItem.Enabled Then
         Dim frmViajes As New FViajes(FViajes.TipoCarga.Incidencias)
         frmViajes.MdiParent = Me
         frmViajes.WindowState = FormWindowState.Maximized
         frmViajes.StartPosition = FormStartPosition.CenterScreen
         frmViajes.Show()
      Else
         ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), m_msg_nodisponible, m_msg_mensaje)
      End If
   End Sub

   Private Sub ConsumoDeCombustibleToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsumoDeCombustibleToolStripMenuItem1.Click
      If ConsumoDeCombustibleToolStripMenuItem1.Enabled Then
         Dim frmConsCombustible As New FViajes(FViajes.TipoCarga.ConsCombustible)
         frmConsCombustible.MdiParent = Me
         frmConsCombustible.WindowState = FormWindowState.Maximized
         frmConsCombustible.StartPosition = FormStartPosition.CenterScreen
         frmConsCombustible.Show()
      Else
         ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), m_msg_nodisponible, m_msg_mensaje)
      End If
   End Sub

   Private Sub FletesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FletesToolStripMenuItem.Click
      If FletesToolStripMenuItem.Enabled Then
         Dim frmViajes As New FViajes(FViajes.TipoCarga.Fletes)
         frmViajes.MdiParent = Me
         frmViajes.WindowState = FormWindowState.Maximized
         frmViajes.StartPosition = FormStartPosition.CenterScreen
         frmViajes.Show()
      Else
         ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), m_msg_nodisponible, m_msg_mensaje)
      End If
   End Sub

   Private Sub VehiculoRanflaYConductorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VehiculoRanflaYConductorToolStripMenuItem.Click
      If VehiculoRanflaYConductorToolStripMenuItem.Enabled Then
         Dim frmViajes As New FViajes(FViajes.TipoCarga.Base)
         frmViajes.MdiParent = Me
         frmViajes.WindowState = FormWindowState.Maximized
         frmViajes.StartPosition = FormStartPosition.CenterScreen
         frmViajes.Show()
      Else
         ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), m_msg_nodisponible, m_msg_mensaje)
      End If
   End Sub

   Private Sub InventarioDeNeumaticosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InventarioDeNeumaticosToolStripMenuItem.Click
      If InventarioDeNeumaticosToolStripMenuItem.Enabled Then
         Dim frmViajes As New FViajes(FViajes.TipoCarga.Neumaticos)
         frmViajes.MdiParent = Me
         frmViajes.WindowState = FormWindowState.Maximized
         frmViajes.StartPosition = FormStartPosition.CenterScreen
         frmViajes.Show()
      Else
         ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), m_msg_nodisponible, m_msg_mensaje)
      End If
   End Sub
#End Region

#Region " Neumaticos "
   Private Sub MovimientoNeumaticosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MovimientoNeumaticosToolStripMenuItem1.Click
      If MovimientoNeumaticosToolStripMenuItem1.Enabled Then
         Dim frmMNeuma As New FMovimientoNeumatico()
         frmMNeuma.MdiParent = Me
         frmMNeuma.StartPosition = FormStartPosition.CenterScreen
         frmMNeuma.WindowState = FormWindowState.Maximized
         frmMNeuma.Show()
      Else
         ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), m_msg_nodisponible, m_msg_mensaje)
      End If
   End Sub

#End Region
#End Region

#Region " Movimientos "

   Private Sub RemitenteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemitenteToolStripMenuItem.Click
      Dim frmGuiaT As New FGuiaRemiRemitente() With {.MdiParent = Me, .StartPosition = FormStartPosition.CenterScreen, .WindowState = FormWindowState.Maximized}
      frmGuiaT.Show()
   End Sub

   Private Sub RemitenteDeFacturaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemitenteDeFacturaToolStripMenuItem.Click
        'aca se realiza FACTURAS 
        Dim frmGuiaT As New PGuiaRemiRemitenteFactura() With {.MdiParent = Me, .StartPosition = FormStartPosition.CenterScreen, .WindowState = FormWindowState.Maximized}
        frmGuiaT.Show()
   End Sub

   Private Sub TransportistaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransportistaToolStripMenuItem1.Click
      Dim frmGuiaT As New PGuiaRemiTransportista() With {.MdiParent = Me, .StartPosition = FormStartPosition.CenterScreen, .WindowState = FormWindowState.Maximized}
      frmGuiaT.Show()
   End Sub

   Private Sub DeTransporteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeTransporteToolStripMenuItem.Click
      If CotizacionesToolStripMenuItem.Enabled Then
         Dim frmFCotizaciones As New FCotizaciones() With {.MdiParent = Me, .StartPosition = FormStartPosition.CenterScreen}
         frmFCotizaciones.Show()
      Else
         ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), m_msg_nodisponible, m_msg_mensaje)
      End If
   End Sub

   Private Sub ParaFacturaciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParaFacturaciónToolStripMenuItem.Click
      'Dim frmPCotizaciones As New PCotizaciones() With {.MdiParent = Me, .StartPosition = FormStartPosition.CenterScreen, .WindowState = FormWindowState.Maximized}
      'frmPCotizaciones.Show()
   End Sub

   Private Sub RegistraIncidenciasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistraIncidenciasToolStripMenuItem.Click
      Dim frmIncNeu As New PNeumaticosIncidencias() With {.MdiParent = Me, .StartPosition = FormStartPosition.CenterScreen}
      frmIncNeu.Show()
   End Sub

   Private Sub RegistrarIncidenciasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistrarIncidenciasToolStripMenuItem.Click
      Dim frmIncVehi As New PVehiculosIncidencias() With {.MdiParent = Me, .StartPosition = FormStartPosition.CenterScreen}
      frmIncVehi.Show()
   End Sub

   Private Sub DivisiónTransportesAcerosComercialesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DivTransACToolStripMenuItem.Click
        Dim frmFactDivTrans As New PFacturacion() With {.MdiParent = Me, .StartPosition = FormStartPosition.CenterScreen, .WindowState = FormWindowState.Maximized}
        frmFactDivTrans.Show()
   End Sub
#End Region

#Region " Reportes "
#Region " Viajes "

   Private Sub InventariosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InventariosToolStripMenuItem.Click
      If InventariosToolStripMenuItem.Enabled Then
         Dim frmViajesReporteInv As New FViajes(FViajes.TipoFormulario.Reporte_Inv) With {.MdiParent = Me, .WindowState = FormWindowState.Maximized, .StartPosition = FormStartPosition.CenterScreen}
         frmViajesReporteInv.Show()
      Else
         ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), m_msg_nodisponible, m_msg_mensaje)
      End If
   End Sub
#End Region

#Region " Neumaticos "
   Private Sub HistorialToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HistorialToolStripMenuItem.Click
      If HistorialToolStripMenuItem.Enabled Then
         Dim frmRHistorial As New RNeumaticos() With {.MdiParent = Me, .WindowState = FormWindowState.Maximized, .StartPosition = FormStartPosition.CenterScreen}
         frmRHistorial.Show()
      Else
         ACControles.ACDialogos.ACMostrarMensajeInformacion(String.Format("Información: {0}", Me.Text), m_msg_nodisponible, m_msg_mensaje)
      End If
   End Sub
#End Region

   Private Sub ReporteDeCuadreDeCajaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporteDeCuadreDeCajaToolStripMenuItem.Click
      Dim frmCaja As New RCCaja() With {.MdiParent = Me, .WindowState = FormWindowState.Normal, .StartPosition = FormStartPosition.CenterScreen, .MaximizeBox = False}
      frmCaja.Show()
      frmCaja.WindowState = FormWindowState.Normal
   End Sub

   Private Sub ReporteDeCuadreDePendientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporteDeCuadreDePendientesToolStripMenuItem.Click
      Dim frmPendientes As New RCPendientes() With {.MdiParent = Me, .WindowState = FormWindowState.Normal, .StartPosition = FormStartPosition.CenterScreen, .MaximizeBox = False}
      frmPendientes.Show()
      frmPendientes.WindowState = FormWindowState.Normal
   End Sub

   Private Sub CuadreDeCajaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CuadreDeCajaToolStripMenuItem.Click
      Dim frmCuadre As New CFletesCaja() With {.MdiParent = Me, .WindowState = FormWindowState.Maximized, .StartPosition = FormStartPosition.CenterScreen}
      frmCuadre.Show()
   End Sub

   Private Sub CuadreDeGastosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CuadreDeGastosToolStripMenuItem.Click
      Dim frmCuadreG As New RGastos() With {.MdiParent = Me, .WindowState = FormWindowState.Maximized, .StartPosition = FormStartPosition.CenterScreen}
      frmCuadreG.Show()
   End Sub

   Private Sub ConductoresToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConductoresToolStripMenuItem1.Click
      Dim frmSueldos As New RSueldoConductor() With {.MdiParent = Me, .WindowState = FormWindowState.Maximized, .StartPosition = FormStartPosition.CenterScreen}
      frmSueldos.Show()
   End Sub

   Private Sub FletesPendientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FletesPendientesToolStripMenuItem.Click
      Dim frmPendientes As New RPendientes() With {.MdiParent = Me, .WindowState = FormWindowState.Maximized, .StartPosition = FormStartPosition.CenterScreen}
      frmPendientes.Show()
   End Sub

   Private Sub FacturasYGuiasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturasYGuiasToolStripMenuItem.Click
      Dim frmFactGuia As New CFacturasGuias() With {.MdiParent = Me, .WindowState = FormWindowState.Maximized, .StartPosition = FormStartPosition.CenterScreen}
      frmFactGuia.Show()
   End Sub

   Private Sub GuiasDeSucursalesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuiasDeSucursalesToolStripMenuItem.Click
      Dim frmGuia As New CGuiasRemisionAC() With {.MdiParent = Me, .WindowState = FormWindowState.Maximized, .StartPosition = FormStartPosition.CenterScreen}
      frmGuia.Show()
   End Sub

   Private Sub RecibosDeViajeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecibosDeViajeToolStripMenuItem.Click
      Dim frmRec As New RRecibos() With {.MdiParent = Me, .WindowState = FormWindowState.Maximized, .StartPosition = FormStartPosition.CenterScreen}
      frmRec.Show()
   End Sub

   Private Sub FletesPorViajeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FletesPorViajeToolStripMenuItem.Click
      Dim frmViaFle As New CViajesFletes() With {.MdiParent = Me, .WindowState = FormWindowState.Maximized, .StartPosition = FormStartPosition.CenterScreen}
      frmViaFle.Show()
   End Sub

#End Region

#Region " Organizar Ventanas "
   Private Sub OrganizarTodosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrganizarTodosToolStripMenuItem.Click
      Me.LayoutMdi(Windows.Forms.MdiLayout.ArrangeIcons)
   End Sub

   Private Sub MozaicoHorizontalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MozaicoHorizontalToolStripMenuItem.Click
      Me.LayoutMdi(Windows.Forms.MdiLayout.TileHorizontal)
   End Sub

   Private Sub MozaicoVerticalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MozaicoVerticalToolStripMenuItem.Click
      Me.LayoutMdi(Windows.Forms.MdiLayout.TileVertical)
   End Sub

   Private Sub EnCascadaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnCascadaToolStripMenuItem.Click
      Me.LayoutMdi(Windows.Forms.MdiLayout.Cascade)
   End Sub

   Private Sub CerrarTodoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarTodoToolStripMenuItem.Click
      For Each item As Windows.Forms.Form In Me.MdiChildren
         item.Close()
      Next
   End Sub
#End Region

   Private Sub RelacionarViajesYVentasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RelacionarViajesYVentasToolStripMenuItem1.Click
      Dim frmViajesVentas As New PViajesVentas() With {.MdiParent = Me, .WindowState = FormWindowState.Maximized, .StartPosition = FormStartPosition.CenterScreen}
      frmViajesVentas.Show()
   End Sub

   Private Sub CancelacionDocumentosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelacionDocumentosToolStripMenuItem.Click
      Dim frmCanFac As New PCamFecFacturas() With {.MdiParent = Me, .WindowState = FormWindowState.Normal, .StartPosition = FormStartPosition.CenterScreen}
      frmCanFac.Show()
      frmCanFac.WindowState = FormWindowState.Normal
   End Sub

   Private Sub CancelacionDeFletesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelacionDeFletesToolStripMenuItem.Click
      Dim frmCanDoc As New TCancelacion() With {.MdiParent = Me, .WindowState = FormWindowState.Maximized, .StartPosition = FormStartPosition.CenterScreen}
      frmCanDoc.Show()
   End Sub

   Private Sub FacturacionDeFletesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturacionDeFletesToolStripMenuItem.Click
      Dim frmFactDivTrans As New PFacturacionFletes(PFacturacionFletes.TInicio.Normal) With {.MdiParent = Me, .StartPosition = FormStartPosition.CenterScreen, .WindowState = FormWindowState.Maximized}
      frmFactDivTrans.Show()
   End Sub

   Private Sub ParaFacturaciónConFletesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParaFacturaciónConFletesToolStripMenuItem.Click
      Dim frmPCotizaciones As New PCotizacionesFletes() With {.MdiParent = Me, .StartPosition = FormStartPosition.CenterScreen, .WindowState = FormWindowState.Maximized}
      frmPCotizaciones.Show()
   End Sub

   Private Sub PendientesPorViajesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PendientesPorViajesToolStripMenuItem.Click
      Dim frmRPenfecha As New RPendientesPorFecha() With {.MdiParent = Me, .StartPosition = FormStartPosition.CenterScreen}
      frmRPenfecha.Show()
   End Sub

   Private Sub PendientesDeFletesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PendientesDeFletesToolStripMenuItem.Click
      Dim frmFlePendientes As New RFletesPendientes() With {.MdiParent = Me, .StartPosition = FormStartPosition.CenterScreen}
      frmFlePendientes.Show()
   End Sub

   Private Sub IngresosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresosToolStripMenuItem1.Click
      Dim frmIngEfec As New PIngresoEfectivo(ACETransporte.Constantes.TipoIngEgre.Ingreso) With {.StartPosition = FormStartPosition.CenterScreen}
      frmIngEfec.ShowDialog()
   End Sub

   Private Sub EgresosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EgresosToolStripMenuItem.Click
      Dim frmIngEfec As New PIngresoEfectivo(ACETransporte.Constantes.TipoIngEgre.Egreso) With {.StartPosition = FormStartPosition.CenterScreen}
      frmIngEfec.ShowDialog()
   End Sub

   Private Sub RegistrarConsumoDeCombustibleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistrarConsumoDeCombustibleToolStripMenuItem.Click
      Dim frmCComb As New PConCombustible() With {.MdiParent = Me, .StartPosition = FormStartPosition.CenterScreen}
      frmCComb.Show()
   End Sub

   Private Sub ModificarConsumoDeCombustibleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarConsumoDeCombustibleToolStripMenuItem.Click
      Dim frmCComb As New PConCombustible(PConCombustible.Origen.Modificar) With {.MdiParent = Me, .StartPosition = FormStartPosition.CenterScreen}
      frmCComb.Show()
   End Sub

   Private Sub RegistrarMantenimientosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistrarMantenimientosToolStripMenuItem.Click
      Dim frmVMante As New MVehiculosMantenimiento() With {.MdiParent = Me, .StartPosition = FormStartPosition.CenterScreen, .WindowState = FormWindowState.Maximized}
        frmVMante.MinimizeBox = True
        frmVMante.MaximizeBox = True
        frmVMante.Show()
    End Sub

   Private Sub FacturacionSimpleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturacionSimpleToolStripMenuItem.Click
      Dim frmFact As New PFacturacionSimple() With {.MdiParent = Me, .StartPosition = FormStartPosition.CenterScreen, .WindowState = FormWindowState.Maximized}
      frmFact.Show()
   End Sub

   Private Sub AdministrarAccesosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdministrarAccesosToolStripMenuItem.Click
      Dim frmAdmin As New MAdministrar() With {.MdiParent = Me, .WindowState = FormWindowState.Maximized, .StartPosition = FormStartPosition.CenterScreen}
      frmAdmin.Show()
   End Sub

   Private Sub ChequeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChequeToolStripMenuItem.Click
      Dim frmMDoc As New MDocsPago(ACEVentas.ETipos.TipoDocPago.Cheque, False, MDocsPago.TipoInicio.Normal) With {.MdiParent = Me, .StartPosition = FormStartPosition.CenterScreen}
      frmMDoc.Show()
   End Sub

   Private Sub DepositosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DepositosToolStripMenuItem.Click
      Dim frmMDoc As New MDocsPago(ACEVentas.ETipos.TipoDocPago.Deposito, True, MDocsPago.TipoInicio.Normal) With {.MdiParent = Me, .StartPosition = FormStartPosition.CenterScreen}
      frmMDoc.Show()
   End Sub

   Private Sub LetrasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LetrasToolStripMenuItem.Click
      Dim frmMDoc As New MDocsPago(ACEVentas.ETipos.TipoDocPago.Letra, False, MDocsPago.TipoInicio.Normal) With {.MdiParent = Me, .StartPosition = FormStartPosition.CenterScreen}
      frmMDoc.Show()
   End Sub

   Private Sub DetraccionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetraccionesToolStripMenuItem.Click
      Dim frmMDoc As New MDocsPago(ACEVentas.ETipos.TipoDocPago.Detraccion, False, MDocsPago.TipoInicio.Normal) With {.MdiParent = Me, .StartPosition = FormStartPosition.CenterScreen}
      frmMDoc.Show()
   End Sub

   Private Sub ConsultasDePagosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaDePagosToolStripMenuItem.Click
      Dim frmCFleC As New CFletesCancelados() With {.MdiParent = Me, .WindowState = FormWindowState.Maximized, .StartPosition = FormStartPosition.CenterParent}
      frmCFleC.Show()
   End Sub

   Private Sub EstadoDePagosPorClienteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstadoDePagosPorClienteToolStripMenuItem.Click
      Dim frmEstCuenta As New CEstPagosPorCliente() With {.MdiParent = Me, .WindowState = FormWindowState.Maximized, .StartPosition = FormStartPosition.CenterParent}
      frmEstCuenta.Show()
   End Sub

#End Region
#End Region

   Private Sub PiezasPartesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PiezasPartesToolStripMenuItem.Click
      Dim frmPiezas As New MPiezas()
      frmPiezas.MdiParent = Me
      frmPiezas.StartPosition = FormStartPosition.CenterScreen
      frmPiezas.Show()
   End Sub

   Private Sub ModificarMantenimientoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarMantenimientoToolStripMenuItem.Click
      Dim frmVMante As New MVehiculosMantenimiento(MVehiculosMantenimiento.TMante.Modificar) With {.MdiParent = Me, .StartPosition = FormStartPosition.CenterScreen, .WindowState = FormWindowState.Maximized}
        frmVMante.MaximizeBox = True
        frmVMante.MinimizeBox = True
        frmVMante.Show()

    End Sub

   Private Sub ImprimirLineasSimplesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirLineasSimplesToolStripMenuItem.Click
      Dim frmImp As New PImpLinea() With {.MdiParent = Me, .StartPosition = FormStartPosition.CenterScreen}
      frmImp.Show()
   End Sub

   Private Sub ConsultaDeDepositosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaDeDepositosToolStripMenuItem.Click
      Dim frmImp As New CPagosPorDepositos() With {.MdiParent = Me, .StartPosition = FormStartPosition.CenterScreen, .WindowState = FormWindowState.Maximized}
      frmImp.Show()
   End Sub

   Private Sub RecojoDeCementoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecojoDeCementoToolStripMenuItem.Click
      Dim frmImp As New CGuiasPorFactura() With {.MdiParent = Me, .StartPosition = FormStartPosition.CenterScreen, .WindowState = FormWindowState.Maximized}
      frmImp.Show()
   End Sub

   Private Sub NotasDeDebitoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotasDeDebitoToolStripMenuItem.Click
      Dim frmNot As New PFacturacionNotas(PFacturacionNotas.TNota.Debito) With {.MdiParent = Me, .StartPosition = FormStartPosition.CenterScreen, .WindowState = FormWindowState.Maximized}
      frmNot.Show()
   End Sub

   Private Sub ManualDeUsuariosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManualDeUsuariosToolStripMenuItem.Click
      Try

         Dim archivo As String
         archivo = Path.Combine(Application.StartupPath, "Documentos")
         archivo = Path.Combine(archivo, "ManualUsuario-Transportes.pdf")

         Process.Start(archivo)

      Catch ex As Exception
         ACControles.ACDialogos.ACMostrarMensajeError(String.Format("Error: {0}", Me.Text), String.Format(Colecciones.getError("00101"), "Cargar el Manual de Usuario"), ex)
      End Try
   End Sub

   Private Sub InventariosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InventariosToolStripMenuItem1.Click
      Dim frmNot As New TInventarioVehiculo() With {.MdiParent = Me, .StartPosition = FormStartPosition.CenterScreen, .WindowState = FormWindowState.Maximized}
      frmNot.Show()
   End Sub

   Private Sub FletesPorRutaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FletesPorRutaToolStripMenuItem.Click
      Dim frmFle As New MFletesPorRuta() With {.MdiParent = Me, .StartPosition = FormStartPosition.CenterScreen, .WindowState = FormWindowState.Maximized}
      frmFle.Show()
   End Sub

   Private Sub RegistroDeGastosDeCajaChicaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroDeGastosDeCajaChicaToolStripMenuItem.Click
      Dim frmFle As New PIngGasCajaChica(RegistroDeGastosDeCajaChicaToolStripMenuItem.Image) With {.MdiParent = Me, .StartPosition = FormStartPosition.CenterScreen, .WindowState = FormWindowState.Maximized}
      frmFle.Show()
   End Sub

   Private Sub CuadroComparativoCombustibleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CuadroComparativoCombustibleToolStripMenuItem.Click
      Dim frmFle As New CCompCombustible(CuadroComparativoCombustibleToolStripMenuItem.Image) With {.MdiParent = Me, .StartPosition = FormStartPosition.CenterScreen, .WindowState = FormWindowState.Maximized}
      frmFle.Show()
   End Sub

   Private Sub RegistrarDocumentosDeCompraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarDocumentosDeCompraToolStripMenuItem.Click
      Dim frmFle As New MDocumentosCompra(RegistrarDocumentosDeCompraToolStripMenuItem.Image, MDocumentosCompra.TInicio.Normal) With {.MdiParent = Me, .StartPosition = FormStartPosition.CenterScreen, .WindowState = FormWindowState.Normal}
      frmFle.Show()
   End Sub

   Private Sub ReporteDeCuentasCorrientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeCuentasCorrientesToolStripMenuItem.Click
      Dim frmCaja As New RCuentasCorrientes(ReporteDeCuentasCorrientesToolStripMenuItem.Image) With {.MdiParent = Me, .WindowState = FormWindowState.Normal, .StartPosition = FormStartPosition.CenterScreen, .MaximizeBox = False}
      frmCaja.Show()
      frmCaja.WindowState = FormWindowState.Normal
   End Sub

    Private Sub NotasDeCreditoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NotasDeCreditoToolStripMenuItem.Click
        Dim frmNot As New PFacturacionNotas(PFacturacionNotas.TNota.Credito) With {.MdiParent = Me, .StartPosition = FormStartPosition.CenterScreen, .WindowState = FormWindowState.Maximized}
        frmNot.Show()
    End Sub

    Private Function CargarAvisoSeguros()
        Try

            bindingSource_Seguros = New BindingSource()
            managerE_TRAN__VehiculosSeguros = New ETRAN_VehiculosSeguros()
            managerB_TRAN__VehiculosSeguros = New BTRAN_VehiculosSeguros()

            'Dim Seguro_Aseguradora As String '
            Dim Seguro_EntidCodigo As String '
            Dim Seguro_Descripcion As String
            Dim Color As String
            Dim Seguro_Inicio As DateTime
            Dim Seguro_Fin As DateTime
            Dim Seguro_Tiempo_Contrato As String

            managerB_TRAN__VehiculosSeguros.TRAN_SEGUROS_ActualizarColores()

            If managerB_TRAN__VehiculosSeguros.TRAN_Seguros_DiasDiferencia() Then
                'bs_PendientesPago = New BindingSource
                bindingSource_Seguros.DataSource = managerB_TRAN__VehiculosSeguros.ListTRAN_VehiculosSeguros

                For Each Item As ETRAN_VehiculosSeguros In bindingSource_Seguros.DataSource 'managerGenerarDocsVenta.ListVENT_DocsVenta    
                    Seguro_Descripcion = Item.SEGVH_Descripcion
                    Seguro_Inicio = Item.SEGVH_FecInicio
                    Seguro_Fin = Item.SEGVH_FecFin
                    Color = Item.SEGVH_Color
                    Seguro_Tiempo_Contrato = Item.SEGVH_FecInicio
                    Seguro_EntidCodigo = Item.SEGVH_Conductor
                    Seguro_Descripcion = Item.SEGVH_Descripcion
                    Me.AgregarBotonSeguros(Seguro_Descripcion, Color, Seguro_Inicio, Seguro_Fin, Seguro_EntidCodigo)
                Next
            Else

            End If
            ToolSeguros.Width = 350
        Catch ex As Exception
            MessageBox.Show("Error", ex.Message())
        End Try
    End Function

    Private Function CargarAvisoMantenimientos()
        Try

            bindingSource_Mantenimiento = New BindingSource()
            managerB_TRAN_VehiculosMantenimiento = New BTRAN_VehiculosMantenimiento
            managerE_TRAN_VehiculosMantenimiento = New ETRAN_VehiculosMantenimiento
            'Dim Seguro_Aseguradora As String '
            Dim Mant_Creador As String '
            Dim Mant_Observaciones As String
            Dim Mant_Color As String
            Dim Mant_FecCreacion As DateTime
            Dim Mant_FecMod As DateTime
            Dim Mant_VMAN_Km As String
            Dim Mant_Vehic_Placa As String


            Dim x_join As New List(Of ACJoin)
            x_join.Add(New ACJoin(EEntidades.Esquema, EEntidades.Tabla, "Ent", ACJoin.TipoJoin.Inner _
            , New ACCampos() {New ACCampos("ENTID_Codigo", "ENTID_Codigo")} _
             , New ACCampos() {New ACCampos("ENTID_Nombres", "ENTID_Nombres")}))
            x_join.Add(New ACJoin(ETRAN_Vehiculos.Esquema, ETRAN_Vehiculos.Tabla, "Veh", ACJoin.TipoJoin.Left _
                                       , New ACCampos() {New ACCampos("VEHIC_Id", "VEHIC_Id")} _
                                       , New ACCampos() {New ACCampos("VEHIC_Placa", "VEHIC_Placa")}))
            Dim x_where As New Hashtable()
            x_where.Add("VMAN_Estado", New ACWhere("I", ACWhere.TipoWhere.Igual))

            If managerB_TRAN_VehiculosMantenimiento.CargarTodos(x_join, x_where) Then
                'bs_PendientesPago = New BindingSource
                bindingSource_Mantenimiento.DataSource = managerB_TRAN_VehiculosMantenimiento.ListTRAN_VehiculosMantenimiento

                For Each Item As ETRAN_VehiculosMantenimiento In bindingSource_Mantenimiento.DataSource 'managerGenerarDocsVenta.ListVENT_DocsVenta    
                    Mant_Observaciones = Item.VMAN_Observaciones
                    Mant_FecCreacion = Item.VMAN_FecCrea
                    Mant_FecMod = Item.VMAN_FecMod
                    Mant_Color = Item.VEHIC_Placa
                    ' Seguro_Tiempo_Contrato = Item.SEGVH_FecInicio
                    Mant_Creador = Item.VMAN_UsrCrea
                    Mant_VMAN_Km = Item.ENTID_RazonSocial
                    Mant_Vehic_Placa = Item.VEHIC_Placa
                    Me.AgregarBotonMantenimientos(Mant_Observaciones, Mant_Color, Mant_FecCreacion, Mant_FecMod, Mant_VMAN_Km, Mant_Vehic_Placa)
                Next
            Else

            End If
            ToolSeguros.Width = 350
        Catch ex As Exception
            MessageBox.Show("Error", ex.Message())
        End Try
    End Function
    Private Sub AgregarBotonSeguros(ByVal Seguro_Descripcion As String, ByVal Color_ As String, ByVal Seguro_Inicio As DateTime, ByVal Seguro_Fin As DateTime, ByVal Seguro_EntidCodigo As String)
        Dim lobjButton As New ToolStripButton()
        lobjButton.RightToLeft = RightToLeft.No
        lobjButton.AutoSize = False
        lobjButton.Size = New Size(350, 50)
        lobjButton.Name = Seguro_Descripcion
        lobjButton.Text = Seguro_Descripcion & vbCrLf & "Vehiculo/Ranfla : " & Seguro_EntidCodigo & " / Inicio : " & ControlChars.CrLf & Seguro_Inicio & "/ Termina : " & Seguro_Fin
        lobjButton.TextAlign = ContentAlignment.MiddleLeft

        ' Asigna color según los días restantes
        'Dim diasRestantes As Integer = CalcularDiasRestantes(Seguro_Inicio, Seguro_Fin)
        'If diasRestantes >= 30 Then
        '    lobjButton.BackColor = Color.Green
        '    lobjButton.ForeColor = Color.White
        '    'botonesVerdes.Add(lobjButton) ' Agrega al listado de botones verdes
        'ElseIf diasRestantes >= 15 And diasRestantes < 30 Then
        '    lobjButton.BackColor = Color.Orange
        '    lobjButton.ForeColor = Color.White
        '    'botonesNaranjas.Add(lobjButton) ' Agrega al listado de botones naranjas
        'ElseIf diasRestantes < 15 Then
        '    lobjButton.BackColor = Color.Red
        '    lobjButton.ForeColor = Color.White
        '    ' botonesRojos.Add(lobjButton) ' Agrega al listado de botones rojos
        'Else
        '    lobjButton.BackColor = Color.Red
        '    lobjButton.ForeColor = Color.White
        '    '  botonesRojos.Add(lobjButton) ' Por defecto agrega al listado de botones rojos
        'End If
        If Color_ = "C" Then
            lobjButton.BackColor = Color.Green
            lobjButton.ForeColor = Color.White
            'botonesVerdes.Add(lobjButton) ' Agrega al listado de botones verdes
        ElseIf Color_ = "B" Then
            lobjButton.BackColor = Color.Orange
            lobjButton.ForeColor = Color.White
            'botonesNaranjas.Add(lobjButton) ' Agrega al listado de botones naranjas
        ElseIf Color_ = "A" Then
            lobjButton.BackColor = Color.Red
            lobjButton.ForeColor = Color.White
            ' botonesRojos.Add(lobjButton) ' Agrega al listado de botones rojos
        Else
            lobjButton.BackColor = Color.Red
            lobjButton.ForeColor = Color.White
            '  botonesRojos.Add(lobjButton) ' Por defecto, agrega al listado de botones rojos
        End If


        'ToolsSeguros.Controls.Add(lobjButton)
        ToolSeguros.Items.Add(lobjButton)
        'OrdenarBotonesPorColor() ' Llama a la función para ordenar y agregar los botones al control ToolsSeguros
    End Sub
    Private Sub AgregarBotonMantenimientos(ByVal Mant_Observacion As String, ByVal Mant_Color_ As String, ByVal Mant_FecCrea As DateTime, ByVal Mant_FecMod As DateTime, ByVal Mant_Creador As String, ByVal Mant_vehi_placa As String)
        Dim lobjButton As New ToolStripButton()
        lobjButton.RightToLeft = RightToLeft.No
        lobjButton.AutoSize = False
        lobjButton.Size = New Size(350, 50)
        lobjButton.Name = Mant_Observacion
        lobjButton.Text = "Observaciones :" & Mant_Observacion & vbCrLf & "Vehiculo/Ranfla :" & Mant_vehi_placa & "/ Inicio : " & ControlChars.CrLf & Mant_FecCrea & "/ Modificado : " & Mant_FecMod
        lobjButton.TextAlign = ContentAlignment.MiddleLeft
        ToolSeguros.Items.Add(lobjButton)
        'OrdenarBotonesPorColor() ' Llama a la función para ordenar y agregar los botones al control ToolsSeguros
    End Sub

    Private Function CalcularDiasRestantes(Fecha_Inicio As DateTime, Fecha_Fin As DateTime) As Integer
        Dim DiasRestantes As Integer = 0
        Dim FechaActual As DateTime = DateTime.Now
        ' Calcula la diferencia en días entre la fecha actual y la fecha de fin del seguro
        DiasRestantes = DateDiff(DateInterval.Day, FechaActual, Fecha_Fin)
        Return DiasRestantes
    End Function
    Private Sub QuitarToolsBotonesSeguros_2()
        Try
            ' ToolSeguros.Width = 30

            ' Limpiar los controles en ToolsSeguros para Mantenimientos 
            'ToolSeguros.Items.Clear()
            For i As Integer = Me.ToolSeguros.Items.Count - 1 To 0 Step -1
                If i > 2 Then
                    Me.ToolSeguros.Items.RemoveAt(i)

                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error al Cargar Los Mantenimientos ", ex.Message())
        End Try
    End Sub
    Private Sub QuitarToolsBotonesMantenimiento_2()
        Try
            ' ToolSeguros.Width = 30

            ' Limpiar los controles en ToolsSeguros
            'ToolSeguros.Items.Clear()
            For i As Integer = Me.ToolSeguros.Items.Count - 1 To 0 Step -1

                If i > 2 Then

                    Me.ToolSeguros.Items.RemoveAt(i)

                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error al Cargar Los Seguros Pendientes", ex.Message())
        End Try
    End Sub

    Private Sub Btn_flag_seguros_Click(sender As Object, e As EventArgs)
        'Cuando se Presiona se Oculta o cambia de tamaño 
        Dim flag As Boolean
        'Ocultar Seguros
        If (ToolStripBtnSeguros.Text = "Ocultar Seguros") Then
            ' Panel_MsgPrincipal.Width = 34
            flag = False
            Me.ToolSeguros.Visible = False
        Else
            ' Panel_MsgPrincipal.Width = 360
            ToolStripBtnSeguros.Text = "Ver Seguros"
            Me.ToolSeguros.Visible = True
            flag = True
        End If

        If flag Then
            CargarAvisoSeguros()
            For Each control As ToolStripItem In ToolSeguros.Items
                If Not control.[GetType]() Is System.Type.[GetType]("System.Windows.Forms.ToolStripSeparator") Then
                    DirectCast(control, ToolStripItem).DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
                End If
            Next

            ToolStripBtnSeguros.Image = Global.ACPTransportes.My.Resources.hidemenu
            ToolStripBtnSeguros.ToolTipText = "Ocultar Seguros"
            ' ToolStripBtnSeguros.Text = "Ocultar Pendientes"
            ToolStripBtnSeguros.Text = "Ocultar Seguros"

        Else
            QuitarToolsBotonesSeguros_2()
            For Each control As ToolStripItem In ToolSeguros.Items
                If Not control.[GetType]() Is System.Type.[GetType]("System.Windows.Forms.ToolStripSeparator") Then
                    DirectCast(control, ToolStripItem).DisplayStyle = ToolStripItemDisplayStyle.Image
                End If
            Next

            ToolStripBtnSeguros.Image = Global.ACPTransportes.My.Resources.showmenu
            ToolStripBtnSeguros.Text = "Ver Seguros"
        End If

    End Sub
    Private Sub ToolStripBtnSeguros_Click(sender As Object, e As EventArgs) Handles ToolStripBtnSeguros.Click
        Try
            Dim m_visiblependientes As Boolean
            m_visiblependientes = Not m_visiblependientes
            If ToolSeguros.Text = "Ocultar Seguros" Then
                m_visiblependientes = False
            Else
                m_visiblependientes = True
            End If
            If m_visiblependientes Then
                CargarAvisoSeguros()
                For Each control As ToolStripItem In ToolSeguros.Items
                    If Not control.[GetType]() Is System.Type.[GetType]("System.Windows.Forms.ToolStripSeparator") Then
                        DirectCast(control, ToolStripItem).DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
                    End If
                Next

                ToolStripBtnSeguros.Image = Global.ACPTransportes.My.Resources.hidemenu
                ToolStripBtnSeguros.ToolTipText = "Ocultar Seguros"
                ' ToolStripBtnSeguros.Text = "Ocultar Pendientes"
                ToolStripBtnSeguros.Text = "Ocultar Seguros"
                ' ToolStripBtnMantenimientos.Text = "Ver Mantenimientos"

                ToolSeguros.Text = "Ocultar Seguros"

            Else
                QuitarToolsBotonesSeguros_2()
                For Each control As ToolStripItem In ToolSeguros.Items
                    If Not control.[GetType]() Is System.Type.[GetType]("System.Windows.Forms.ToolStripSeparator") Then
                        DirectCast(control, ToolStripItem).DisplayStyle = ToolStripItemDisplayStyle.Image
                    End If
                Next

                ToolStripBtnSeguros.Image = Global.ACPTransportes.My.Resources.showmenu

                ToolSeguros.Text = "Ver Seguros"

            End If
        Catch ex As Exception
            MessageBox.Show("Error", ex.Message())
        End Try
    End Sub

    Private Sub ReporteDeMantenimientoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeMantenimientoToolStripMenuItem.Click
        'Reporte de Mantenimeinto De Cero frank 
        Dim frmMantenimiento As New RMantenimiento() With {.MdiParent = Me, .StartPosition = FormStartPosition.CenterScreen, .WindowState = FormWindowState.Maximized}
        frmMantenimiento.Show()
    End Sub

    Private Sub RealizarMovimientoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RealizarMovimientoToolStripMenuItem.Click

    End Sub

    Private Sub ToolStripBtnMantenimientos_Click(sender As Object, e As EventArgs) Handles ToolStripBtnMantenimientos.Click
        'Click para el Mantenimientos
        Try
            QuitarToolsBotonesMantenimiento_2()
            Dim m_visiblependientes As Boolean
            ' Dim m_visiblemantenimientos As Boolean
            m_visiblependientes = Not m_visiblependientes
            If ToolSeguros.Text = "Ocultar Mantenimientos" Then
                m_visiblependientes = False
            Else
                m_visiblependientes = True
            End If
            If m_visiblependientes Then
                CargarAvisoMantenimientos()
                For Each control As ToolStripItem In ToolSeguros.Items
                    If Not control.[GetType]() Is System.Type.[GetType]("System.Windows.Forms.ToolStripSeparator") Then
                        DirectCast(control, ToolStripItem).DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
                    End If
                Next

                ToolStripBtnMantenimientos.Image = Global.ACPTransportes.My.Resources.hidemenu
                ToolStripBtnMantenimientos.ToolTipText = "Ocultar Mantenimientos"
                ' ToolStripBtnSeguros.Text = "Ocultar Pendientes"
                ToolStripBtnMantenimientos.Text = "Ocultar Mantenimientos"

                ToolSeguros.Text = "Ocultar Mantenimientos"

            Else
                QuitarToolsBotonesMantenimiento_2()
                For Each control As ToolStripItem In ToolSeguros.Items
                    If Not control.[GetType]() Is System.Type.[GetType]("System.Windows.Forms.ToolStripSeparator") Then
                        DirectCast(control, ToolStripItem).DisplayStyle = ToolStripItemDisplayStyle.Image
                    End If
                Next

                ToolStripBtnMantenimientos.Image = Global.ACPTransportes.My.Resources.showmenu

                ToolSeguros.Text = "Ver"
            End If
        Catch ex As Exception
            MessageBox.Show("Error", ex.Message())
        End Try


    End Sub

    Private Sub ReporteDeConsumoDeCombustibleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeConsumoDeCombustibleToolStripMenuItem.Click
        'Reporte de Combustible 
        'Pendiente 
    End Sub

    Private Sub UsuariosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles UsuariosToolStripMenuItem1.Click
        'Modulo de Administracion de Usuarios  de cero
        Dim frmAdmUsuarios As New MAdministracionUsuarios() With {.MdiParent = Me, .StartPosition = FormStartPosition.CenterScreen, .WindowState = FormWindowState.Maximized}
        frmAdmUsuarios.Show()
    End Sub

    Private Sub CancelacionDeDocumentosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelacionDeDocumentosToolStripMenuItem.Click

    End Sub

    Private Sub ReporteDeSaldoAFavorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeSaldoAFavorToolStripMenuItem.Click
        Dim frmSaldoAFavor As New RSaldosAFavor() With {.MdiParent = Me, .StartPosition = FormStartPosition.CenterScreen, .WindowState = FormWindowState.Maximized}
        frmSaldoAFavor.Show()
    End Sub

    Private Sub GeneralAppMovilToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GeneralAppMovilToolStripMenuItem.Click
        Dim frmAdmUsuarioMovil As New Administracion_AppMovil_Usuarios() With {.MdiParent = Me, .StartPosition = FormStartPosition.CenterScreen, .WindowState = FormWindowState.Maximized}
        frmAdmUsuarioMovil.Show()
    End Sub

    Private Sub GuiaDeTransportistaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuiaDeTransportistaToolStripMenuItem.Click

    End Sub

    Private Sub TransportisaAppMovilToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransportisaAppMovilToolStripMenuItem.Click

    End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    'eNVIERA RESPUESTA 
    '    Dim x As String = TextBox1.Text

    '    'clientesp pp 
    '    Dim client As New RestClient("http://192.168.30.235:8085/api/EnviosDocumentos/PruebaEnvio?data=" + TextBox1.Text)
    '    Dim request As New RestRequest("1", Method.POST)

    '    'Ejecutame esto pppapa
    '    Dim response As IRestResponse = client.Execute(request)


    '    If response.StatusCode = "200" Then
    '        Console.WriteLine("Respuesta del servidor__" + response.Server + "RESPUESTA  => SERVIDOOOOOR ")
    '        Console.WriteLine(response.Content)
    '    Else
    '        Console.WriteLine("Error en la solicitud___")
    '        Console.WriteLine(response.StatusCode.ToString())
    '        Console.WriteLine(response.ErrorMessage)
    '    End If

    '    Console.ReadLine()



    'End Sub
End Class
