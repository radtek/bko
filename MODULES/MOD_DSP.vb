Module mod_DSP
    'Private allowedExtensions() As String = {".ico", ".jpg", ".png"}
    Public Sub ResList(ByVal resizingListView As ListView)

        'resizingListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize)
        'resizingListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent)

        Dim columnIndex As Integer

        'If resizingListView.Items.Count = 0 Then

        For columnIndex = 1 To resizingListView.Columns.Count - 1
            resizingListView.AutoResizeColumn(columnIndex, ColumnHeaderAutoResizeStyle.HeaderSize)
        Next

        'Else

        '    For columnIndex = 1 To resizingListView.Columns.Count - 1
        '        resizingListView.AutoResizeColumn(columnIndex, ColumnHeaderAutoResizeStyle.ColumnContent)
        '    Next

        'End If
    End Sub

    'Function fillImlWithFilesFromDir(ByRef dirPath As String) As ImageList
    '    Dim imlTemp As New ImageList
    '    Dim dirFiles() As String = IO.Directory.GetFiles(dirPath)

    '    For Each dirFile As String In dirFiles
    '        For Each extension As String In allowedExtensions
    '            If extension = IO.Path.GetExtension(dirFile) Then
    '                imlTemp.Images.Add(Image.FromFile(dirFile))
    '            End If
    '        Next
    '    Next

    '    Return imlTemp
    'End Function


    Public Sub CLEAR_CPL()
        frmGarCPL.cmbCPU1.Text = ""
        frmGarCPL.cmbCPU2.Text = ""
        frmGarCPL.cmbCPU3.Text = ""
        frmGarCPL.cmbCPU4.Text = ""
        frmGarCPL.txtMHZ1.Text = ""
        frmGarCPL.txtMHZ2.Text = ""
        frmGarCPL.txtMHZ3.Text = ""
        frmGarCPL.txtMHZ4.Text = ""
        frmGarCPL.txtSoc1.Text = ""
        frmGarCPL.txtSoc2.Text = ""
        frmGarCPL.txtSoc3.Text = ""
        frmGarCPL.txtSoc4.Text = ""
        frmGarCPL.PROizV1.Text = ""
        frmGarCPL.PROizV2.Text = ""
        frmGarCPL.PROizV3.Text = ""
        frmGarCPL.PROizV4.Text = ""
    End Sub

    Public Sub Notes_Clear(ByVal btnNotes As ToolStripButton, ByVal dt As DateTimePicker, ByVal cmaster As ComboBox,
                           ByVal tNotes As TextBox)

        'MSG19 
        Dim objIniFile As New IniFile(sLANGPATH)

        btnNotes.Text = objIniFile.GetString("frmComputers", "MSG30", "Добавить")
        dt.Value = Date.Today
        cmaster.Text = ""
        tNotes.Text = ""
    End Sub

    Public Sub ClearForm(ByVal ControlContainer As Object)

        If frmComputers.OneStart = 1 Then frmComputers.OneStart = 0

        Dim A1 As String
        A1 = frmComputers.treebranche.Text

        For Each Ctl As Object In ControlContainer.Controls
            Try
                If Not Ctl.Controls Is Nothing Then

                    ClearForm(Ctl)

                    If TypeOf Ctl Is TextBox Then Ctl.ResetText()
                    If TypeOf Ctl Is ComboBox Then Ctl.ResetText()
                    If TypeOf Ctl Is ListView Then Ctl.items.clear()
                    'If TypeOf Ctl Is CheckBox Then Ctl.checked = False
                    If TypeOf Ctl Is RadioButton Then Ctl.checked = False

                    ' If TypeOf Ctl Is ToolStrip Then Ctl.rendermode = ToolStripRenderMode.System

                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next

        frmComputers.chkPCspis.Checked = False
        frmComputers.chkPCNNb.Checked = False
        frmComputers.chkPRNspis.Checked = False
        frmComputers.chkPRNNNb.Checked = False
        frmComputers.chkNETspis.Checked = False
        frmComputers.chkNETNNb.Checked = False
        frmComputers.chkOTHNNb.Checked = False
        frmComputers.chkOTHspis.Checked = False

        frmComputers.treebranche.Text = A1

        System.Windows.Forms.Application.DoEvents()

        If frmComputers.OneStart = 0 Then frmComputers.OneStart = 1

    End Sub


    Public Function SaveUpdateLogDB(ByVal A As String, ByVal A2 As String)
        Dim strTime As String
        Dim strDate As String

        On Error GoTo Error_

        'If UserId = "" Then UserId = UserName
        strDate = Format(Date.Today, "dd/mm/yyyy")
        With frmMain
            strTime = Format(TimeOfDay, "hh:mm")
        End With

        Dim rs As Recordset
        rs = New Recordset

        rs.Open("SELECT * FROM Update_Log", DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)
        With rs
            .AddNew()

            .Fields("Id_Comp").Value = frmComputers.sCOUNT
            .Fields("Komcl_old").Value = A
            .Fields("Kompl_new").Value = A2
            .Fields("Date").Value = Date.Today
            .Fields("Time").Value = strTime

            .Update()
        End With
        rs.Close()
        rs = Nothing

        'uLOG.Open "INSERT INTO Update_Log (Id_Comp, Komcl_old, Kompl_new, Date,Time) VALUES ('" & frmMain.nomerPCAbs & "', '" & A & "', '" & A2 & "', '" & strDate & "', '" & strTime & "')", DB7, adOpenDynamic, adLockOptimistic


        Exit Function

Error_:

        MsgBox(Err.Description, vbCritical, "Error!!!")
    End Function

    Public Sub SECUR_LEVEL()

        If uLevel <> "Admin" Then

            frmMain.АктытребованияToolStripMenuItem.Enabled = False

            If uLevelCart = False Then
                frmMain.УчётКартриджейToolStripMenuItem.Enabled = False
                frmComputers.CartrAddToolStripMenuItem.Enabled = False
            End If


            If uLevelPO = False Then frmMain.УчётПрограммногоОбеспеченияToolStripMenuItem.Enabled = False

            If uLevelPOAdd = False Then frmComputers.btnAdd.Enabled = False
            If uLevelPOAdd = False Then frmComputers.ToolStripButton1.Enabled = False
            If uLevelPODel = False Then frmComputers.btnDelete.Enabled = False

            If uLevelWarehause = False Then frmMain.СкладToolStripMenuItem.Enabled = False
            If uLevelSetup = False Then frmMain.NewToolStripMenuItem.Enabled = False

            If uLevelTehAdd = False Then
                frmMain.ToolStripDropDownButton1.Enabled = False
                frmMain.SaveInfTehButton.Enabled = False
                frmComputers.CopyToolStripMenuItem.Enabled = False
                frmComputers.addFoldertoBranch.Enabled = False
                frmComputers.UpdateToolStripMenuItem.Enabled = False

            End If


            If uLevelTehDel = False Then
                frmComputers.mnuDeltoBranch.Enabled = False
                frmComputers.DeleteToolStripMenuItem.Enabled = False
                frmComputers.DeleteBranche.Enabled = False
            End If

            If uLevelRepAdd = False Then
                frmComputers.addRemToolStripMenuItem.Enabled = False
                frmMain.УчётЗаявокремонтовToolStripMenuItem.Enabled = False
                frmserviceDesc.btnRemAdd.Enabled = False
                frmComputers.RepAddBrToolStripMenuItem.Enabled = False
            End If

            If uLevelRepDel = False Then frmserviceDesc.btnRemDel.Enabled = False

            frmMain.ОбслуживаниеБДToolStripMenuItem.Enabled = False
            frmMain.ArhToolZipbutton.Enabled = False
            frmMain.ЖурналыПрограммыToolStripMenuItem.Enabled = False
            frmMain.ОрганизацияToolStripMenuItem.Enabled = False


            If uLevelNotesAdd = False Then
                frmComputers.btnNotesAdd.Enabled = False
                frmComputers.btnPRNNotesAdd.Enabled = False
                frmComputers.btnNETAdd.Enabled = False
                frmComputers.btnOTHAdd.Enabled = False
            End If

            If uLevelNotesDel = False Then
                frmComputers.btnNotesDel.Enabled = False
                frmComputers.btnPRNNotesDel.Enabled = False
                frmComputers.btnNETNotesDel.Enabled = False
                frmComputers.btnOTHNotesDel.Enabled = False
            End If


            frmMain.СправочникиОборудованияToolStripMenuItem.Enabled = False
            frmMain.netMagmnu.Enabled = False



        End If
    End Sub

    Public Sub SaveActivityToLogDB(ByVal Aktivitas As String)
        Dim objIniFile As New IniFile(PrPath & "base.ini")
        Dim uname As Integer
        uname = objIniFile.GetString("GENERAL", "LOG", "0")

        If uname = 1 Then Exit Sub


        Dim strDate As String
        Dim strTime As String

        strTime = Format(TimeOfDay, "hh:mm:ss")

        strDate = Date.Today


        Dim rs As Recordset
        rs = New Recordset
        rs.Open("SELECT * FROM T_Log", DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            .AddNew()
            .Fields("User_ID").Value = uSERID & "-on-" & uPCNAME
            .Fields("Activity").Value = Aktivitas
            .Fields("Date").Value = Date.Today
            .Fields("Time").Value = strTime
            .Update()
        End With
        rs.Close()
        rs = Nothing
    End Sub

    Public Sub COUNT_FIELDS(ByVal sID As String)
        On Error Resume Next


        If Len(sID) = 0 Then Exit Sub

        Dim rs As Recordset 'Объявляем рекордсет
        Dim sSQL As String 'Переменная, где будет размещён SQL запрос

        sSQL = "SELECT * FROM kompy WHERE id =" & sID
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)
        Dim icounter As Decimal = 0

        With rs
            'Процессоры
            If Len(.Fields("CPU1").Value) <> 0 Then icounter = icounter + 1

            If Len(.Fields("CPU2").Value) <> 0 Then icounter = icounter + 1


            If Not IsDBNull(.Fields("CPU3")) Then
                If Len(.Fields("CPU3").Value) <> 0 Then icounter = icounter + 1
            End If

            If Not IsDBNull(.Fields("CPU4")) Then
                If Len(.Fields("CPU4").Value) <> 0 Then icounter = icounter + 1
            End If

            'Материнская плата
            If Len(.Fields("MB_NAME").Value) <> 0 Then icounter = icounter + 1

            'Модули памяти

            If Len(.Fields("RAM_1").Value) <> 0 Then icounter = icounter + 1

            If Len(.Fields("RAM_2").Value) <> 0 Then icounter = icounter + 1

            If Len(.Fields("RAM_3").Value) <> 0 Then icounter = icounter + 1

            If Len(.Fields("RAM_4").Value) <> 0 Then icounter = icounter + 1

            'Жесткие диски

            If Len(.Fields("HDD_Name_1").Value) <> 0 Then icounter = icounter + 1

            If Len(.Fields("HDD_Name_2").Value) <> 0 Then icounter = icounter + 1

            If Len(.Fields("HDD_Name_3").Value) <> 0 Then icounter = icounter + 1

            If Len(.Fields("HDD_Name_4").Value) <> 0 Then icounter = icounter + 1

            'Видео карта
            If Len(.Fields("SVGA_NAME").Value) <> 0 Then icounter = icounter + 1

            'If len(.fields("SVGA_NAME").Value)<>0 Then icounter=icounter+1

            'Звуковая карта

            If Len(.Fields("SOUND_NAME").Value) <> 0 Then icounter = icounter + 1
            'Оптические накопители

            If Len(.Fields("CD_NAME").Value) <> 0 Then icounter = icounter + 1

            If Len(.Fields("CDRW_NAME").Value) <> 0 Then icounter = icounter + 1

            If Len(.Fields("DVD_NAME").Value) <> 0 Then icounter = icounter + 1

            'Сетевые карты
            If Len(.Fields("NET_NAME_1").Value) <> 0 Then icounter = icounter + 1

            If Len(.Fields("NET_NAME_2").Value) <> 0 Then icounter = icounter + 1

            'Дисковод
            If Len(.Fields("FDD_NAME").Value) <> 0 Then icounter = icounter + 1

            'Кардридер
            'If len(.fields("FDD_NAME").Value)<>0 Then icounter=icounter+1

            'Модем
            If Len(.Fields("MODEM_NAME").Value) <> 0 Then icounter = icounter + 1

            'Корпус
            'If len(.fields("MODEM_NAME").Value)<>0 Then icounter=icounter+1

            'Блок питания
            If Len(.Fields("BLOCK").Value) <> 0 Then icounter = icounter + 1

            'Производитель системного блока
            'If len(.Fields("SYS_PR").Value)<>0 Then icounter = icounter + 1

            'Серийный номер системного блока
            'If len(.Fields("Ser_N_SIS").Value)<>0 Then icounter = icounter + 1

            'Монитор
            '1
            If Len(.Fields("MONITOR_NAME").Value) <> 0 Then icounter = icounter + 1
            '2
            If Len(.Fields("MONITOR_NAME2").Value) <> 0 Then icounter = icounter + 1

            'Клавиатура
            If Len(.Fields("KEYBOARD_NAME").Value) <> 0 Then icounter = icounter + 1

            'Мышь
            If Len(.Fields("MOUSE_NAME").Value) <> 0 Then icounter = icounter + 1

            'Колонки

            If Len(.Fields("AS_NAME").Value) <> 0 Then icounter = icounter + 1

            'Сетевой фильтр
            If Len(.Fields("FILTR_NAME").Value) <> 0 Then icounter = icounter + 1


            'Подключенные принтеры
            If Len(.Fields("PRINTER_NAME_1").Value) <> 0 Then icounter = icounter + 1

            If Len(.Fields("PRINTER_NAME_2").Value) <> 0 Then icounter = icounter + 1

            If Len(.Fields("PRINTER_NAME_3").Value) <> 0 Then icounter = icounter + 1

            'If len(.Fields("NET_NAME").Value)<>0 Then icounter = icounter + 1


        End With

        iCOUNTFIELLDS = icounter

        rs.Close()
        rs = Nothing
    End Sub

    Public Sub LOAD_PCL(ByVal sFIL As String, ByVal sDEP As String, ByVal sOFF As String, ByVal sCMB As ComboBox, ByVal tmpOTV As String, ByVal sID As Integer)

        If Len(sFIL) = 0 Then Exit Sub

        Call LOAD_PCL_otv(sFIL, sDEP, sOFF, sCMB, tmpOTV, sID)

        On Error GoTo err_
        sCMB.Enabled = True

        Dim rs As Recordset
        Dim sSQL As String

        sSQL = "SELECT count(*) as t_n from spr_other where C='1'"
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        Dim A1 As String

        With rs
            A1 = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        Select Case TipTehn

            Case "PC"

                Select Case A1

                    Case 0

                    Case Else

                        sSQL = "Select NET_NAME From kompy where filial='" & sFIL & "' and mesto='" & sDEP & "' and kabn='" & sOFF & "' and TipTehn='CNT' and Otvetstvennyj<>'" & tmpOTV & "' ORDER BY NET_NAME"

                End Select

                rs = New Recordset
                rs.Open("Select count(*) as t_n From kompy where filial='" & sFIL & "' and mesto='" & sDEP & "' and kabn='" & sOFF & "' and TipTehn='CNT' and Otvetstvennyj<>'" & tmpOTV & "'", DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                With rs
                    A1 = .Fields("t_n").Value
                End With
                rs.Close()
                rs = Nothing

            Case "NET"

                Select Case A1

                    Case 0

                    Case Else

                        sSQL = "Select NET_NAME From kompy where filial='" & sFIL & "' and mesto='" & sDEP & "' and kabn='" & sOFF & "' and tipTehn<>'Printer' And tipTehn<>'MFU' And tipTehn<>'KOpir' And tipTehn<>'OT' And tipTehn<>'PHOTO' And tipTehn<>'FAX' And tipTehn<>'PHONE' And tipTehn<>'ZIP' And tipTehn<>'SCANER' And tipTehn<>'MONITOR' And tipTehn<>'USB' And tipTehn<>'SOUND' And tipTehn<>'IBP' And tipTehn<>'FS' And tipTehn<>'KEYB' And tipTehn<>'MOUSE' and tiptehn <>'PC' and Otvetstvennyj<>'" & tmpOTV & "' and id<>" & sID & " ORDER BY NET_NAME"

                End Select

                rs = New Recordset
                rs.Open("Select count(*) as t_n From kompy where filial='" & sFIL & "' and mesto='" & sDEP & "' and kabn='" & sOFF & "' and tipTehn<>'Printer' And tipTehn<>'MFU' And tipTehn<>'KOpir' And tipTehn<>'OT' And tipTehn<>'PHOTO' And tipTehn<>'FAX' And tipTehn<>'PHONE' And tipTehn<>'ZIP' And tipTehn<>'SCANER' And tipTehn<>'MONITOR' And tipTehn<>'USB' And tipTehn<>'SOUND' And tipTehn<>'IBP' And tipTehn<>'FS' And tipTehn<>'KEYB' And tipTehn<>'MOUSE' and tiptehn <>'PC' and Otvetstvennyj<>'" & tmpOTV & "' and id<>" & sID, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                With rs
                    A1 = .Fields("t_n").Value
                End With
                rs.Close()
                rs = Nothing

            Case Else

                Select Case A1

                    Case 0

                        sSQL = "Select NET_NAME From kompy where filial='" & sFIL & "' and mesto='" & sDEP & "' and kabn='" & sOFF & "' and tipTehn<>'Printer' And tipTehn<>'MFU' And tipTehn<>'KOpir' And tipTehn<>'OT' And tipTehn<>'FAX' And tipTehn<>'PHONE' And tipTehn<>'ZIP' And tipTehn<>'SCANER' And tipTehn<>'MONITOR' And tipTehn<>'NET' And tipTehn<>'USB' And tipTehn<>'SOUND' And tipTehn<>'IBP' And tipTehn<>'FS' And tipTehn<>'KEYB' And tipTehn<>'MOUSE' and Otvetstvennyj<>'" & tmpOTV & "' ORDER BY NET_NAME"

                    Case Else

                        sSQL = "Select NET_NAME From kompy where filial='" & sFIL & "' and mesto='" & sDEP & "' and kabn='" & sOFF & "' and tipTehn<>'Printer' And tipTehn<>'MFU' And tipTehn<>'KOpir' And tipTehn<>'OT' And tipTehn<>'FAX' And tipTehn<>'PHONE' And tipTehn<>'ZIP' And tipTehn<>'SCANER' And tipTehn<>'MONITOR' And tipTehn<>'NET' And tipTehn<>'USB' And tipTehn<>'SOUND' And tipTehn<>'IBP' And tipTehn<>'FS' And tipTehn<>'KEYB' And tipTehn<>'MOUSE' and Otvetstvennyj<>'" & tmpOTV & "' ORDER BY NET_NAME"

                End Select

                rs = New Recordset
                rs.Open("Select count(*) as t_n From kompy where filial='" & sFIL & "' and mesto='" & sDEP & "' and kabn='" & sOFF & "'  and tipTehn<>'Printer' And tipTehn<>'MFU' And tipTehn<>'KOpir' And tipTehn<>'OT' And tipTehn<>'FAX' And tipTehn<>'PHONE' And tipTehn<>'ZIP' And tipTehn<>'SCANER' And tipTehn<>'MONITOR' And tipTehn<>'NET' And tipTehn<>'USB' And tipTehn<>'SOUND' And tipTehn<>'IBP' And tipTehn<>'FS' And tipTehn<>'KEYB' And tipTehn<>'MOUSE' and Otvetstvennyj<>'" & tmpOTV & "'", DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                With rs
                    A1 = .Fields("t_n").Value
                End With
                rs.Close()
                rs = Nothing

        End Select

        Select Case A1

            Case 0

            Case Else

                rs = New Recordset
                rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                With rs
                    .MoveFirst()
                    Do While Not .EOF

                        sCMB.Items.Add(.Fields("NET_NAME").Value)

                        .MoveNext()
                    Loop
                End With
                rs.Close()
                rs = Nothing

        End Select

        If sCMB.Items.Count = 0 Then sCMB.Enabled = False

        Exit Sub
err_:
        MsgBox(Err.Description)
    End Sub
    
    Public Sub LOAD_PCL_otv(ByVal sFIL As String, ByVal sDEP As String, ByVal sOFF As String, ByVal sCMB As ComboBox, ByVal tmpOTV As String, ByVal sID As Integer)

        If Len(sFIL) = 0 Then Exit Sub

        On Error GoTo err_
        sCMB.Enabled = True

        Dim rs As Recordset
        Dim sSQL As String

        sSQL = "SELECT count(*) as t_n from spr_other where C='1'"
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        Dim A1 As String

        With rs
            A1 = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        sCMB.Items.Clear()

        Select Case TipTehn


            Case "PC"
                rs = New Recordset
                rs.Open("Select count(*) as t_n From kompy where filial='" & sFIL & "' and mesto='" & sDEP & "' and kabn='" & sOFF & "' and TipTehn='CNT' and Otvetstvennyj='" & tmpOTV & "'", DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                With rs
                    A1 = .Fields("t_n").Value
                End With
                rs.Close()
                rs = Nothing

                Select Case A1

                    Case 0

                    Case Else

                        sSQL = "Select NET_NAME From kompy where filial='" & sFIL & "' and mesto='" & sDEP & "' and kabn='" & sOFF & "' and TipTehn='CNT' and Otvetstvennyj='" & tmpOTV & "'"

                End Select

            Case "NET"

                rs = New Recordset
                rs.Open("Select count(*) as t_n From kompy where filial='" & sFIL & "' and mesto='" & sDEP & "' and kabn='" & sOFF & "' and tipTehn<>'Printer' And tipTehn<>'MFU' And tipTehn<>'KOpir' And tipTehn<>'OT' And tipTehn<>'PHOTO' And tipTehn<>'FAX' And tipTehn<>'PHONE' And tipTehn<>'ZIP' And tipTehn<>'SCANER' And tipTehn<>'MONITOR' And tipTehn<>'USB' And tipTehn<>'SOUND' And tipTehn<>'IBP' And tipTehn<>'FS' And tipTehn<>'KEYB' And tipTehn<>'MOUSE' and tiptehn <>'PC' and Otvetstvennyj='" & tmpOTV & "' and id<>" & sID, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                With rs

                    A1 = .Fields("t_n").Value
                End With
                rs.Close()
                rs = Nothing

                Select Case A1

                    Case 0

                    Case Else

                        sSQL = "Select NET_NAME From kompy where filial='" & sFIL & "' and mesto='" & sDEP & "' and kabn='" & sOFF & "' and tipTehn<>'Printer' And tipTehn<>'MFU' And tipTehn<>'KOpir' And tipTehn<>'OT' And tipTehn<>'PHOTO' And tipTehn<>'FAX' And tipTehn<>'PHONE' And tipTehn<>'ZIP' And tipTehn<>'SCANER' And tipTehn<>'MONITOR' And tipTehn<>'USB' And tipTehn<>'SOUND' And tipTehn<>'IBP' And tipTehn<>'FS' And tipTehn<>'KEYB' And tipTehn<>'MOUSE' and tiptehn <>'PC' and Otvetstvennyj='" & tmpOTV & "' and id<>" & sID

                End Select

            Case Else

                rs = New Recordset
                rs.Open("Select count(*) as t_n From kompy where filial='" & sFIL & "' and mesto='" & sDEP & "' and kabn='" & sOFF & "'  and tipTehn<>'Printer' And tipTehn<>'MFU' And tipTehn<>'KOpir' And tipTehn<>'OT' And tipTehn<>'FAX' And tipTehn<>'PHONE' And tipTehn<>'ZIP' And tipTehn<>'SCANER' And tipTehn<>'MONITOR' And tipTehn<>'NET' And tipTehn<>'USB' And tipTehn<>'SOUND' And tipTehn<>'IBP' And tipTehn<>'FS' And tipTehn<>'KEYB' And tipTehn<>'MOUSE' and Otvetstvennyj='" & tmpOTV & "'", DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                With rs
                    A1 = .Fields("t_n").Value
                End With
                rs.Close()
                rs = Nothing

                Select Case A1

                    Case 0

                        'sSQL = "Select NET_NAME From kompy where filial='" & sFIL & "' and mesto='" & sDEP & "' and kabn='" & sOFF & "' and tipTehn<>'Printer' And tipTehn<>'MFU' And tipTehn<>'KOpir' And tipTehn<>'OT' And tipTehn<>'FAX' And tipTehn<>'PHONE' And tipTehn<>'ZIP' And tipTehn<>'SCANER' And tipTehn<>'MONITOR' And tipTehn<>'NET' And tipTehn<>'USB' And tipTehn<>'SOUND' And tipTehn<>'IBP' And tipTehn<>'FS' And tipTehn<>'KEYB' And tipTehn<>'MOUSE' and Otvetstvennyj='" & tmpOTV & "'"

                    Case Else

                        sSQL = "Select NET_NAME From kompy where filial='" & sFIL & "' and mesto='" & sDEP & "' and kabn='" & sOFF & "' and tipTehn<>'Printer' And tipTehn<>'MFU' And tipTehn<>'KOpir' And tipTehn<>'OT' And tipTehn<>'FAX' And tipTehn<>'PHONE' And tipTehn<>'ZIP' And tipTehn<>'SCANER' And tipTehn<>'MONITOR' And tipTehn<>'NET' And tipTehn<>'USB' And tipTehn<>'SOUND' And tipTehn<>'IBP' And tipTehn<>'FS' And tipTehn<>'KEYB' And tipTehn<>'MOUSE' and Otvetstvennyj='" & tmpOTV & "'"

                End Select


        End Select


        Select Case A1

            Case 0

            Case Else

                rs = New Recordset
                rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                With rs
                    .MoveFirst()
                    Do While Not .EOF

                        sCMB.Items.Add(.Fields("NET_NAME").Value)

                        .MoveNext()
                    Loop
                End With
                rs.Close()
                rs = Nothing

        End Select

        Exit Sub
err_:
        MsgBox(Err.Description)
    End Sub

    Public Sub add_kabn_if_nothing()

        frmMain.Cursor = Cursors.WaitCursor


        Dim rs As Recordset
        Dim sSQL As String



        sSQL = "UPDATE kompy SET kabn='' WHERE MESTO='' AND kabn <> ''"

        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)
        rs = Nothing

        sSQL = "select filial, mesto, kabn from kompy"

        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            .MoveFirst()
            Do While Not .EOF

                '.Fields("kabn").Value

                If Not (RSExists("FILIAL", "FILIAL", .Fields("filial").Value)) Then
                    AddOnePar(.Fields("filial").Value, "FILIAL", "SPR_FILIAL", frmComputers.cmbBranch)
                End If


                If Not IsDBNull(.Fields("mesto").Value) Then
                    If Not (RSExistsDB(.Fields("filial").Value, .Fields("mesto").Value)) Then
                        AddDepartment(.Fields("filial").Value, .Fields("mesto").Value)
                    End If
                End If

                If Not IsDBNull(.Fields("kabn").Value) Then
                    If Not (RSExistsDBO(.Fields("filial").Value, .Fields("mesto").Value, .Fields("kabn").Value)) Then
                        AddOffice(.Fields("filial").Value, .Fields("mesto").Value, .Fields("kabn").Value)
                    End If
                End If

                .MoveNext()
            Loop
        End With

        rs.Close()
        rs = Nothing

        '####################################################################
        '####################################################################
        '####################################################################
        'Убираем поля с NULL

        rs = New Recordset
        rs.Open("select * from kompy", DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        Dim rs_ As ADODB.Recordset

        Dim uname As Integer

        If DB_N <> "MS Access" Then uname = 2 Else uname = 1

        On Error Resume Next
        For lngCounter = 0 To rs.Fields.Count - uname

            If rs.Fields(lngCounter).Name = "id" Or rs.Fields(lngCounter).Name = "ID" Then

            Else
                rs_ = New Recordset
                rs_.Open("UPDATE kompy SET " & rs.Fields(lngCounter).Name & "='' WHERE " & rs.Fields(lngCounter).Name & " IS NULL", DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)
                rs_ = Nothing

            End If
        Next

        rs.Close()
        rs = Nothing


        frmMain.Cursor = Cursors.Default


    End Sub
End Module
