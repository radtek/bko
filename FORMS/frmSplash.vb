Public Class frmSplash

    Private Sub frmSplash_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        'SendFonts(Me)

        'Dim sBackgroundImage As String = PrPath & "\img\BKO17.jpg"
        Call PreLoad()

        'Me.BackgroundImage = New System.Drawing.Bitmap(sBackgroundImage)
        Me.BackgroundImage = New System.Drawing.Bitmap(PrPath & "img\splash.png")

        Dim LNGIniFile As New IniFile(sLANGPATH)

        Version.Text = LNGIniFile.GetString("frmSplash", "MSG1", "") & " " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & "." & My.Application.Info.Version.Revision


    End Sub

End Class