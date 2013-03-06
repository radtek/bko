Imports System
Imports System.IO
Public Class frmLogin
    Private sLoad As Boolean


    Private Sub frmLogin_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        PrPath = Directory.GetParent(Application.ExecutablePath).ToString & "\"
        txtPassword.Focus()
        txtPassword.SelectAll()
        txtPassword.Focus()
    End Sub

    Private Sub Find_LANG()
        cmbLang.Items.Clear()

        Try
            ' Only get files that begin with the letter "c."
            Dim dirs As String() = Directory.GetFiles(PrPath & "lang\", "*.ini")
            ' Console.WriteLine("The number of files starting with c is {0}.", dirs.Length)
            Dim dir As String

            For Each dir In dirs
                Dim d() As String
                d = Split(dir, "\")

                cmbLang.Items.Add(d(d.Length - 1))
            Next
        Catch e1 As Exception
            'Console.WriteLine("The process failed: {0}", e1.ToString())
        End Try


    End Sub

    Private Sub Find_DB()
        cmbBD.Items.Clear()

        Try
            ' Only get files that begin with the letter "c."
            Dim dirs As String() = Directory.GetFiles(BasePath, "*.mdb")
            ' Console.WriteLine("The number of files starting with c is {0}.", dirs.Length)
            Dim dir As String

            For Each dir In dirs
                Dim d() As String
                d = Split(dir, "\")

                cmbBD.Items.Add(d(d.Length - 1))
            Next
        Catch e1 As Exception
            'Console.WriteLine("The process failed: {0}", e1.ToString())
        End Try

        'ITEM_DB_COUNT = cmbBD.Items.Count

    End Sub

    Private Sub User_fill()

        On Error GoTo err_

        If DATAB = False Then
            Call LoadDatabase()
            Exit Sub
        Else
        End If

        cmbUser.Items.Clear()

        Dim rs As ADODB.Recordset

        Dim zcn As Integer
        Dim sSQL As String

        sSQL = "select count(*) as t_n from T_User"
        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            zcn = .Fields("t_n").Value

        End With
        rs.Close()
        rs = Nothing

        If zcn = 0 Then
            sSQL = "select * from T_User"
            rs = New ADODB.Recordset
            rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

            With rs
                .AddNew()
                .Fields("User_ID").Value = "ADMINISTRATOR"
                .Fields("Password").Value = "SWY\X"
                .Fields("Name").Value = "ADMINISTRATOR"
                .Fields("Level").Value = "Admin"

                .Update()
            End With
            rs.Close()
            rs = Nothing

        End If


        rs = New ADODB.Recordset
        sSQL = "select * from T_User WHERE Name <> ' '  ORDER BY Name"

        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            .MoveFirst()
            Do While Not .EOF

                cmbUser.Items.Add(.Fields("Name").Value)

                .MoveNext()
                'DoEvents
            Loop
        End With
        rs.Close()
        rs = Nothing


        rs = New ADODB.Recordset
        rs.Open("UPDATE spr_other SET C='0' WHERE C=''", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        'rs.Close()
        rs = Nothing


        Exit Sub

err_:

        MsgBox(Err.Description)
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click


        If Len(txtPassword.Text) = 0 Then Exit Sub
        
        Me.Enabled = False
        Call User_Pro()
        

        Me.Enabled = True

        'Call User_Pro()


    End Sub

    Private Sub User_Pro()
START:

        Dim objIniFile As New IniFile(PrPath & "base.ini")
        objIniFile.WriteString("general", "DefaultUser", cmbUser.Text)
        objIniFile.WriteString("DB", "DB", unamDB)

        If cmbSUBD.Text <> "MS Access" Then

            objIniFile.WriteString("DB", "SERVER", TextBox1.Text)
            objIniFile.WriteString("DB", "PORT", TextBox2.Text)
            objIniFile.WriteString("DB", "BD", TextBox3.Text)
            objIniFile.WriteString("DB", "USER", TextBox4.Text)
            objIniFile.WriteString("DB", "PASSWORD", TextBox5.Text)

        Else
            Base_Name = cmbBD.Text
            objIniFile.WriteString("general", "file", cmbBD.Text)

        End If

        If DATAB = False Then

            Call LoadDatabase()
        Else

        End If

        Dim rscount As ADODB.Recordset
        Dim QWERT As Long
        rscount = New ADODB.Recordset
        rscount.Open("SELECT COUNT(*) AS total_number FROM CONFIGURE", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rscount
            QWERT = .Fields("total_number").Value
        End With

        rscount.Close()
        rscount = Nothing

        If QWERT <= 0 Then

            Dim rs25 As ADODB.Recordset
            rs25 = New ADODB.Recordset
            rs25.Open("SELECT * FROM CONFIGURE", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

            With rs25
                .AddNew()
                .Fields("ORG").Value = "BKO.SHATKI.INFO"
                .Fields("SISADM").Value = "SISADM"
                .Fields("Name_Prog").Value = "BKO.NET"
                .Fields("Nr").Value = "Yes"
                .Fields("access").Value = "1.7.3.5.1"
                .Update()
            End With
            rs25.Close()
            rs25 = Nothing

        End If

        Dim rs As ADODB.Recordset
        rs = New ADODB.Recordset

        Dim tVER As String
        Dim sPass1 As String = ""

        Dim LNGIniFile As New IniFile(sLANGPATH)

        rs = New ADODB.Recordset
        rs.Open("select * from CONFIGURE", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs

            sVERSIA = .Fields("access").Value

        End With
        rs.Close()
        rs = Nothing

        tVER = My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build

        If sVERSIA >= "1.7.3.5.1" Then


        Else

            MsgBox(LNGIniFile.GetString("frmLogin", "MSG1", "Версия базы данных не является эталонной") & vbCrLf & LNGIniFile.GetString("frmLogin", "MSG2", "воспользуйтесь конвертором"), MsgBoxStyle.Information, "BKO.NET - " & tVER)
            MsgBox("Пробуем внести изменения в базу, в случае не удачи пользуйтесь конвертором", MsgBoxStyle.Information, "BKO.NET - " & tVER)

            _DBALTER = True

            'Вносим изменения в базу
            Call ALTER_DB()

            If _DBALTER = True Then

                MsgBox("Внесение изменений провалилось", MsgBoxStyle.Critical, "BKO.NET - " & tVER)

                End

            Else

                GoTo START

            End If


        End If

        If Len(txtPassword.Text) = 0 Then Exit Sub

        strPassword = Trim(txtPassword.Text)
        Call EncryptDecrypt(strPassword)
        txtPassword.Text = Temp

        Dim sCOUNT As Integer
        Dim T_User As ADODB.Recordset

        T_User = New ADODB.Recordset
        T_User.Open("SELECT count(*) as t_n FROM T_User where Name ='" & cmbUser.Text & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With T_User
            sCOUNT = .Fields("t_n").Value
        End With
        T_User.Close()
        T_User = Nothing

        If sCOUNT = 0 Then
            MsgBox("This User is not valid", MsgBoxStyle.Critical, "Error!!!")
            Exit Sub
        End If

        T_User = New ADODB.Recordset
        T_User.Open("SELECT * FROM T_User where Name ='" & cmbUser.Text & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With T_User
            '   .MoveFirst()
            '   Do While Not .EOF

            If cmbUser.Text = .Fields("Name").Value Then

                If cmbUser.Text = .Fields("Name").Value And txtPassword.Text = .Fields("password").Value Then

                    uLevel = .Fields("Level").Value
                    uSERID = .Fields("User_ID").Value
                    UserNames = .Fields("Name").Value

                    If uLevel = "Admin" Then

                    Else

                        If .Fields("SETUP").Value = 1 Or .Fields("SETUP").Value = True Then
                            uLevelSetup = True
                        Else
                            uLevelSetup = False
                        End If
                        If .Fields("PCADD").Value = 1 Or .Fields("PCADD").Value = True Then
                            uLevelTehAdd = True
                        Else
                            uLevelTehAdd = False
                        End If
                        If .Fields("PCDEL").Value = 1 Or .Fields("PCDEL").Value = True Then
                            uLevelTehDel = True
                        Else
                            uLevelTehDel = False
                        End If
                        If .Fields("CAPADD").Value = 1 Or .Fields("CAPADD").Value = True Then
                            uLevelNotesAdd = True
                        Else
                            uLevelNotesAdd = False
                        End If

                        If .Fields("CAPDEL").Value = 1 Or .Fields("CAPDEL").Value = True Then
                            uLevelNotesDel = True
                        Else
                            uLevelNotesDel = False
                        End If
                        If .Fields("REPADD").Value = 1 Or .Fields("REPADD").Value = True Then
                            uLevelRepAdd = True
                        Else
                            uLevelRepAdd = False
                        End If

                        If .Fields("REPDEL").Value = 1 Or .Fields("REPDEL").Value = True Then
                            uLevelRepDel = True
                        Else
                            uLevelRepDel = False
                        End If
                        If .Fields("REPed").Value = 1 Or .Fields("REPed").Value = True Then
                            uLevelRepEd = True
                        Else
                            uLevelRepEd = False
                        End If

                        If .Fields("POADD").Value = 1 Or .Fields("POADD").Value = True Then
                            uLevelPOAdd = True
                        Else
                            uLevelPOAdd = False
                        End If
                        If .Fields("PODEL").Value = 1 Or .Fields("PODEL").Value = True Then
                            uLevelPODel = True
                        Else
                            uLevelPODel = False
                        End If
                        If .Fields("CARTR").Value = 1 Or .Fields("CARTR").Value = True Then
                            uLevelCart = True
                        Else
                            uLevelCart = False
                        End If
                        If .Fields("PO").Value = 1 Or .Fields("PO").Value = True Then
                            uLevelPO = True
                        Else
                            uLevelPO = False
                        End If
                        If .Fields("SCLAD").Value = 1 Or .Fields("SCLAD").Value = True Then
                            uLevelWarehause = True
                        Else
                            uLevelWarehause = False
                        End If

                    End If

                    Call SaveActivityToLogDB(LNGIniFile.GetString("frmLogin", "MSG3", "Вход в программу"))

                    Me.Hide()

                    If sRelogin = True Then
                        sRelogin = False
                        'Какой модуль запускать
                        Dim sText As String
                        sText = objIniFile.GetString("general", "MOD", 0)

                        If Len(sText) > 2 Then sText = 0

                        Select Case sText

                            Case 0

                                'frmComputers.Visible = False
                                frmComputers.MdiParent = frmMain
                                ' My.Application.DoEvents()
                                frmComputers.Show()
                                ' My.Application.DoEvents()

                            Case 1
                                frmserviceDesc.MdiParent = frmMain
                                ' My.Application.DoEvents()
                                frmserviceDesc.Show()
                                ' My.Application.DoEvents()
                            Case 2

                                frmSoftware.MdiParent = frmMain
                                '  My.Application.DoEvents()
                                frmSoftware.Show()
                                '  My.Application.DoEvents()
                            Case 3

                                frmCRT3.MdiParent = frmMain
                                '  My.Application.DoEvents()
                                frmCRT3.Show()
                                '   My.Application.DoEvents()
                        End Select

                        'frmComputers.MdiParent = frmMain
                        'frmComputers.Show()
                        'frmComputers.Focus()
                    Else

                        frmMain.Show()

                    End If


                    '  T_User.Close()
                    '  T_User = Nothing
                    Me.Close()

                Else

                    Call SaveActivityToLogDB(LNGIniFile.GetString("frmLogin", "MSG4", "Ввод не верного пароля"))

                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                    Me.Enabled = True
                    MsgBox("This Password is not valid", MsgBoxStyle.Critical, "Error!!!")
                    txtPassword.Text = ""
                    txtPassword.Focus()
                    Me.Enabled = True
                End If

            Else
            End If
            '  .MoveNext()
            'DoEvents
            ' Loop
        End With
        T_User.Close()
        T_User = Nothing

        Exit Sub
err_:
        txtPassword.Text = ""
        txtPassword.Focus()
        Me.Enabled = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        DBserv = TextBox1.Text
        DBtabl = TextBox3.Text
        DBuser = TextBox4.Text
        DBpass = TextBox5.Text
        DBport = TextBox2.Text


        If DATAB = True Then

            UnLoadDatabase()
            Call LoadDatabase()

        Else
            Call LoadDatabase()
        End If

        Call User_fill()

    End Sub

    Private Sub txtPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown

        If Len(txtPassword.Text) = 0 Then Exit Sub

        Select Case e.KeyCode

            Case Keys.Enter
                Me.Enabled = False
                Call User_Pro()

        End Select

    End Sub

    Private Sub frmLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'SendFonts(Me)


        Call LANG_frmLogin()

        Dim objIniFile As New IniFile(PrPath & "base.ini")
        cmbLang.Text = objIniFile.GetString("general", "LANG", "ru.ini")

        Call Find_LANG()

        sLoad = True

        'Me.Height = 230
        'gbData.Top = 54
        'cmbBD.Enabled = True
        'btnLogin.Top = 174
        'btnCancel.Top = btnLogin.Top
        'gbsql.Top = 205





        Call sSUBD()
        Call User_fill()

        Me.Focus()
        txtPassword.Focus()


    End Sub

    Private Sub sSUBD()

        If sLoad = False Then Exit Sub

        Dim langIni As New IniFile(PrPath & "base.ini")
        cmbUser.Text = langIni.GetString("general", "DefaultUser", "")
        cmbSUBD.Text = langIni.GetString("DB", "DB", "")


        If Len(cmbSUBD.Text) = 0 Then cmbSUBD.Text = "MS Access"

        If DATAB = False Then
            Call LoadDatabase()
        Else
            Call UnLoadDatabase()
            Call LoadDatabase()
        End If


        Select Case cmbSUBD.Text

            Case "MS Access"


                gbsql.Visible = False


                Me.Height = Me.Height - gbsql.Height

                'Me.Height = 245
                'gbData.Top = 53
                cmbBD.Enabled = True
                btnDBDir.Enabled = True
                'btnLogin.Top = 194
                'btnCancel.Top = btnLogin.Top
                'gbsql.Top = 225

                unamDB = cmbSUBD.Text

                cmbBD.Text = langIni.GetString("general", "file", "")

                langIni.WriteString("DB", "DB", cmbSUBD.Text)


                Call Find_DB()


            Case "MS SQL 2008-file"

                gbsql.Visible = False


                Me.Height = Me.Height - gbsql.Height

                'Me.Height = 245
                'gbData.Top = 53
                cmbBD.Enabled = True
                btnDBDir.Enabled = True
                'btnLogin.Top = 194
                'btnCancel.Top = btnLogin.Top
                'gbsql.Top = 225

                unamDB = cmbSUBD.Text

                cmbBD.Text = langIni.GetString("general", "file", "")

                langIni.WriteString("DB", "DB", cmbSUBD.Text)


            Case Else

                gbsql.Visible = True

                'Me.Height = 408
                'gbData.Top = 214
                'gbsql.Top = 50

                cmbBD.Enabled = False
                btnDBDir.Enabled = False
                'btnLogin.Top = 355
                'btnCancel.Top = btnLogin.Top
                'gbData.Top = 205

                Me.AutoSize = True

                unamDB = cmbSUBD.Text

                TextBox1.Text = langIni.GetString("DB", "SERVER", "")
                TextBox2.Text = langIni.GetString("DB", "PORT", "")
                TextBox3.Text = langIni.GetString("DB", "BD", "")
                TextBox4.Text = langIni.GetString("DB", "USER", "")
                TextBox5.Text = langIni.GetString("DB", "PASSWORD", "")

                DBserv = TextBox1.Text
                DBtabl = TextBox3.Text
                DBuser = TextBox4.Text
                DBpass = TextBox5.Text
                DBport = TextBox2.Text

                langIni.WriteString("DB", "DB", cmbSUBD.Text)


        End Select



        Call User_fill()

    End Sub

    Private Sub cmbSUBD_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSUBD.SelectedIndexChanged

        If sLoad = False Then Exit Sub

        Dim objIniFile As New IniFile(PrPath & "base.ini")
        objIniFile.WriteString("DB", "DB", cmbSUBD.Text)

        Call sSUBD()

    End Sub

    Private Sub cmbBD_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBD.SelectedIndexChanged

        If Len(BasePath) = 0 Then
            BasePath = Directory.GetParent(Application.ExecutablePath).ToString & "\database\"
        End If


        If cmbBD.Text = "" Or Len(cmbBD.Text) = 0 Then Exit Sub

        Base_Name = cmbBD.Text

        If DATAB = True Then

            UnLoadDatabase()
            Call LoadDatabase()

        Else
            Call LoadDatabase()
        End If
        Call User_fill()
    End Sub

    Private Sub btnDBDir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDBDir.Click
        Dim DirectoryBrowser As New FolderBrowserDialog

        ' Then use the following code to create the Dialog window
        ' Change the .SelectedPath property to the default location
        With DirectoryBrowser
            ' Desktop is the root folder in the dialog.

            .RootFolder = Environment.SpecialFolder.Desktop

            If Len(BasePath) = 0 Then
                ' Select the C:\Windows directory on entry.
                .SelectedPath = PrPath
            Else
                .SelectedPath = BasePath
            End If

            ' Prompt the user with a custom message.
            .Description = "Select the source directory"

            If .ShowDialog = DialogResult.OK Then
                ' Display the selected folder if the user clicked on the OK button.
                BasePath = .SelectedPath
            End If

        End With

        Dim objIniFile As New IniFile(PrPath & "base.ini")
        objIniFile.WriteString("general", "BasePath", BasePath & "\")

        BasePath = BasePath & "\"
        Call Find_DB()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        End
    End Sub

    Private Sub cmbLang_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLang.SelectedIndexChanged


        Dim objIniFile As New IniFile(PrPath & "base.ini")
        objIniFile.WriteString("general", "LANG", cmbLang.Text)


        sLANGPATH = PrPath & "lang\" & cmbLang.Text

        Call LANG_frmLogin()

    End Sub

    Private Sub txtPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassword.TextChanged

    End Sub
End Class
