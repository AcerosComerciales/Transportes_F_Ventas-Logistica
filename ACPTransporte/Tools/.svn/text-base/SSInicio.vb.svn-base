Imports System.Threading

Public NotInheritable Class SSInicio

#Region " Variables "
   Private m_subProcess As Thread
#End Region

   Public Sub New(ByVal x_time As Integer, ByVal t As Thread)

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      m_subProcess = t
      Try
         tmrSplashTimer.Interval = x_time * 1000
         If Not (tmrSplashTimer.Enabled) Then tmrSplashTimer.Enabled = True
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   'TODO: This form can easily be set as the splash screen for the application by going to the "Application" tab
   '  of the Project Designer ("Properties" under the "Project" menu).


   Private Sub SSInicio_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      'Set up the dialog text at runtime according to the application's assembly information.  

      'TODO: Customize the application's assembly information in the "Application" pane of the project 
      '  properties dialog (under the "Project" menu).

      'Application title
      If My.Application.Info.Title <> "" Then
         ApplicationTitle.Text = My.Application.Info.Title
      Else
         'If the application title is missing, use the application name, without the extension
         ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
      End If

      'Format the version information using the text set into the Version control at design time as the
      '  formatting string.  This allows for effective localization if desired.
      '  Build and revision information could be included by using the following code and changing the 
      '  Version control's designtime text to "Version {0}.{1:00}.{2}.{3}" or something similar.  See
      '  String.Format() in Help for more information.
      '
      '    Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

      Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)

      'Copyright info
      Copyright.Text = My.Application.Info.Copyright
   End Sub

   Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrSplashTimer.Tick
      tmrSplashTimer.Stop()
      If m_subProcess.IsAlive Then
         If tmrSplashTimer.Interval <> 1000 Then
            tmrSplashTimer.Interval = 1000
         End If
         tmrSplashTimer.Start()
      Else
         Me.Close()
      End If
   End Sub
End Class
