Public Class frmService_add
    Private unamZ As String
    Public REMFU As Boolean
    Public REMED As Boolean

    Private Sub cmbAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmbAdd.Click
        On Error Resume Next
        On Error GoTo err_
        Dim objIniFile As New IniFile(sLANGPATH)

        If Len(cmbIst.Text) = 0 Then

            MsgBox(
                objIniFile.GetString("frmService_add", "MSG2", "Не указан") & " " &
                objIniFile.GetString("frmService_add", "MSG3", "источник"), MsgBoxStyle.Information, ProGramName)
            Exit Sub
        End If

        If Len(cmbMast.Text) = 0 Then

            MsgBox(
                objIniFile.GetString("frmService_add", "MSG2", "Не указан") & " " &
                objIniFile.GetString("frmService_add", "MSG4", "Мастер"), MsgBoxStyle.Information, ProGramName)
            Exit Sub
        End If

        If Len(txtRem.Text) = 0 Then

            MsgBox(
                objIniFile.GetString("frmService_add", "MSG2", "Не указан") & " " &
                objIniFile.GetString("frmService_add", "MSG5", "ремонт"), MsgBoxStyle.Information, ProGramName)
            Exit Sub
        End If

        If Len(cmbStatus.Text) = 0 Then

            MsgBox(
                objIniFile.GetString("frmService_add", "MSG2", "Не указан") & " " &
                objIniFile.GetString("frmService_add", "MSG6", "статус заявки"), MsgBoxStyle.Information, ProGramName)
            Exit Sub
        End If

        If Len(cmbOtv.Text) = 0 Then

            MsgBox(
                objIniFile.GetString("frmService_add", "MSG2", "Не указан") & " " &
                objIniFile.GetString("frmService_add", "MSG7", "ответственный"), MsgBoxStyle.Information, ProGramName)
            Exit Sub
        End If

        Dim sSQL As String
        Dim unamZ As String
        Dim sCOUNTER As String

        Dim rs As Recordset

        If Not (RSExists("otv", "name", Trim(cmbIst.Text))) Then
            AddOnePar(cmbIst.Text, "NAME", "SPR_OTV", cmbIst)
        End If

        Select Case frmComputers.sPREF

            Case "C"

                rs = New Recordset
                sSQL = "SELECT filial, mesto, net_name,kabn FROM kompy WHERE id=" & frmComputers.sCOUNT
                rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                With rs

                    unamZ = .Fields("filial").Value

                    If Len(.Fields("mesto").Value) <> 0 Then

                        unamZ = unamZ & "/" & .Fields("mesto").Value

                    End If

                    If Len(.Fields("kabn").Value) <> 0 Then

                        unamZ = unamZ & "/" & .Fields("kabn").Value

                    End If

                    frmserviceDesc.rtxtC = .Fields("net_name").Value
                End With

                rs.Close()
                rs = Nothing

        End Select

        rs = New Recordset
        sSQL = "SELECT count(*) as t_n FROM Remont WHERE Id_Comp=" & frmComputers.sCOUNT & " AND PREF='" &
               frmComputers.sPREF & "'"
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            sCOUNTER = .Fields("t_n").Value
        End With

        Dim ASRT As String
        ASRT = frmComputers.sCOUNT

        rs.Close()
        rs = Nothing

        If cmbAdd.Text = objIniFile.GetString("frmService_add", "MSG1", "Сохранить") Then
            sSQL = "SELECT * FROM Remont WHERE id=" & frmserviceDesc.rCOUNT

        Else
            sSQL = "SELECT * FROM Remont"
        End If

        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        Dim strTime As String
        strTime = TimeString

        'cmbMast

        If Not (RSExists("MASTER", "name", Trim(cmbMast.Text))) Then
            AddOnePar(cmbMast.Text, "NAME", "SPR_Master", cmbMast)
            FillComboNET(Me.cmbMast, "Name", "SPR_Master", "", False, True)
        End If

        If Not (RSExists("otv", "name", Trim(cmbIst.Text))) Then
            AddOnePar(cmbIst.Text, "NAME", "SPR_OTV", cmbIst)
        End If

        If Not (RSExists("SPR_Uroven", "Uroven", Trim(cmbKrit.Text))) Then
            AddOnePar(cmbKrit.Text, "Uroven", "SPR_Uroven", cmbKrit)
        End If

        If Not (RSExists("spr_vip", "name", Trim(cmbStatus.Text))) Then
            AddOnePar(cmbStatus.Text, "NAME", "spr_vip", cmbStatus)
        End If

        If Not (RSExists("spr_tip_z", "name", Trim(cmbTip.Text))) Then
            AddOnePar(cmbTip.Text, "NAME", "spr_tip_z", cmbTip)
        End If


        With rs
            If cmbAdd.Text = objIniFile.GetString("frmService_add", "MSG1", "Сохранить") Then

            Else
                .AddNew()

                .Fields("PREF").Value = frmComputers.sPREF

                'If frmComputers.sPREF <> "C" Then

                'Else
                .Fields("Id_Comp").Value = frmComputers.sCOUNT
                'End If

                .Fields("NomerRemKomp").Value = sCOUNTER + 1
                .Fields("starttime").Value = strTime 'Физическое нажатие начала ремонта
                .Fields("startdate").Value = Date.Today 'Физическое нажатие начала ремонта
                .Fields("Comp_name").Value = frmserviceDesc.rtxtC 'Имя устройства
                .Fields("Mesto_Compa").Value = unamZ 'Место установки устройства

            End If

            .Fields("Master").Value = cmbMast.Text 'Мастер
            .Fields("Date").Value = dtReg.Value 'Дата регистрации
            .Fields("Remont").Value = txtRem.Text 'Сообщение
            .Fields("UserName").Value = "" 'Текущий пользователь компа
            .Fields("vip").Value = cmbStatus.Text 'Статус
            .Fields("istochnik").Value = cmbIst.Text 'Источник
            .Fields("phone").Value = txtPhone.Text 'Телефон
            .Fields("srok").Value = dtIsp.Value 'Срок исполнения
            .Fields("name_of_remont").Value = txtHead.Text 'Название
            .Fields("otvetstv").Value = cmbOtv.Text 'Ответственный
            .Fields("krit_rem").Value = cmbTip.Text 'Критичность
            .Fields("Uroven").Value = cmbKrit.Text 'Тип
            .Fields("MeMo").Value = txtComent.Text 'Комментарий
            .Fields("Summ").Value = RemCashe.Text 'Сумма
            .Fields("GARANT").Value = dtGarRem.Value 'Гарантия

            Select Case chkClose.Checked

                Case True

                    If unamDB = "MS access" Then
                        .Fields("zakryt").Value = True
                    Else
                        .Fields("zakryt").Value = "1"
                    End If

                    .Fields("stopdate").Value = Date.Today 'Физическое нажатие закрытие ремонта
                    .Fields("stoptime").Value = strTime 'Физическое нажатие начала ремонта

                Case False

                    If unamDB = "MS access" Then
                        .Fields("zakryt").Value = False
                    Else
                        .Fields("zakryt").Value = "0"
                    End If

            End Select

            .Fields("UserName").Value = uUSERNAME

            .Update()
        End With
        rs.Close()
        rs = Nothing

        If REMFU = True Or REMED = True Then

            'Call LOAD_REPAIR(frmComputers.sCOUNT, frmComputers.lvRepair)


            Select frmComputers.sPREF

                Case "C"

                    Select Case TipTehn

                        Case "PC"
                            frmComputers.sSTAB1.SelectedTab = frmComputers.sSTAB1.TabPages("TabPage7")
                            LOAD_REPAIR(frmComputers.sCOUNT, frmComputers.lvRepair)

                        Case "NET"

                            LOAD_REPAIR(frmComputers.sCOUNT, frmComputers.lvRepairNET)

                        Case "Printer"

                            LOAD_REPAIR(frmComputers.sCOUNT, frmComputers.lvRepairPRN)

                        Case "KOpir"

                            LOAD_REPAIR(frmComputers.sCOUNT, frmComputers.lvRepairPRN)

                        Case "OT"

                            LOAD_REPAIR(frmComputers.sCOUNT, frmComputers.lvRepairOTH)

                        Case Else

                            LOAD_REPAIR(frmComputers.sCOUNT, frmComputers.lvRepairOTH)

                    End Select


                Case Else

                    Call LOAD_REPAIR(frmComputers.sCOUNT, frmComputers.lvRepairBR)

            End Select

        Else
            Call frmserviceDesc.LOAD_REPAIR(frmComputers.sCOUNT, frmserviceDesc.lvRem)
        End If


        REMFU = False
        REMED = False

        Call REM_CHECK()
        Me.Close()

        Exit Sub
        err_:
        MsgBox(Err.Description)
    End Sub

    Private Sub cmbCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCancel.Click

        Me.Close()

    End Sub

    Private Sub frmService_add_Activated(sender As Object, e As EventArgs) Handles Me.Activated

        If gbS.Visible = False Then
            Me.Height = 535
        Else
            Me.Height = 683
        End If
    End Sub

    Private Sub frmService_add_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        DeleteService.Image = New Bitmap(PrPath & "pic\iface\delete.png")

        SendFonts(Me)

        Dim objIniFile As New IniFile(sLANGPATH)

        Call frmService_add_Lang()

        If REMED = True Then
            cmbAdd.Text = objIniFile.GetString("frmService_add", "MSG1", "Сохранить")
            'cmbAdd 
        Else
            gbS.Visible = False
            Me.Height = 535

            'UserNames
            cmbIst.Text = UserNames

        End If


        FillComboNET(Me.cmbIst, "Name", "SPR_OTV", "", False, True)
        FillComboNET(Me.cmbMast, "Name", "SPR_Master", "", False, True)
        FillComboNET(Me.cmbOtv, "Name", "SPR_Master", "", False, True)
        FillComboNET(Me.cmbStatus, "name", "spr_vip", "", False, True)
        FillComboNET(Me.cmbKrit, "Uroven", "SPR_Uroven", "", False, True)
        FillComboNET(Me.cmbTip, "name", "spr_tip_z", "", False, True)


        If cmbAdd.Text = objIniFile.GetString("frmService_add", "MSG1", "Сохранить") Then

            chkClose.Enabled = True

        Else
            chkClose.Enabled = False
        End If


        If chkClose.Checked = True And REMED = True Then

            cmbIst.Enabled = False
            cmbMast.Enabled = False
            dtReg.Enabled = False
            txtPhone.Enabled = False
            dtIsp.Enabled = False
            txtHead.Enabled = False
            txtRem.Enabled = False
            cmbStatus.Enabled = False
            cmbOtv.Enabled = False
            cmbKrit.Enabled = False
            cmbTip.Enabled = False
            RemCashe.Enabled = False
            txtComent.Enabled = False
            dtGarRem.Enabled = False
            'cmbAdd.Enabled = False

        Else

            cmbIst.Enabled = True
            cmbMast.Enabled = True
            dtReg.Enabled = True
            txtPhone.Enabled = True
            dtIsp.Enabled = True
            txtHead.Enabled = True
            txtRem.Enabled = True
            cmbStatus.Enabled = True
            cmbOtv.Enabled = True
            cmbKrit.Enabled = True
            cmbTip.Enabled = True
            RemCashe.Enabled = True
            txtComent.Enabled = True
            dtGarRem.Enabled = True
            'cmbAdd.Enabled = True

        End If

        Dim LNGIniFile As New IniFile(sLANGPATH)

        lvRem2.Columns.Clear()
        lvRem2.Columns.Add(LNGIniFile.GetString("frmserviceDesc", "lvRem2_1", "id"), 20, HorizontalAlignment.Left)
        lvRem2.Columns.Add(LNGIniFile.GetString("frmserviceDesc", "lvRem2_2", "Дата"), 90, HorizontalAlignment.Left)
        lvRem2.Columns.Add(LNGIniFile.GetString("frmserviceDesc", "lvRem2_3", "Мастер"), 100, HorizontalAlignment.Left)
        lvRem2.Columns.Add(LNGIniFile.GetString("frmserviceDesc", "lvRem2_4", "Описание"), 300, HorizontalAlignment.Left)

    End Sub

    Private Sub chkClose_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkClose.CheckedChanged

        If chkClose.Checked = True And REMED = True Then

            cmbIst.Enabled = False
            cmbMast.Enabled = False
            dtReg.Enabled = False
            txtPhone.Enabled = False
            dtIsp.Enabled = False
            txtHead.Enabled = False
            txtRem.Enabled = False
            cmbStatus.Enabled = False
            cmbOtv.Enabled = False
            cmbKrit.Enabled = False
            cmbTip.Enabled = False
            RemCashe.Enabled = False
            txtComent.Enabled = False
            dtGarRem.Enabled = False
            gbS.Enabled = False
            'cmbAdd.Enabled = False

        Else

            cmbIst.Enabled = True
            cmbMast.Enabled = True
            dtReg.Enabled = True
            txtPhone.Enabled = True
            dtIsp.Enabled = True
            txtHead.Enabled = True
            txtRem.Enabled = True
            cmbStatus.Enabled = True
            cmbOtv.Enabled = True
            cmbKrit.Enabled = True
            cmbTip.Enabled = True
            RemCashe.Enabled = True
            txtComent.Enabled = True
            dtGarRem.Enabled = True
            gbS.Enabled = True
            'cmbAdd.Enabled = True

        End If
    End Sub

    Private Sub lvRem2_DoubleClick(sender As Object, e As System.EventArgs) Handles lvRem2.DoubleClick

        Call frmserviceDesc.LOAD_REM_PLUS_ED(lvRem2)


    End Sub

    Private Sub DeleteService_Click(sender As System.Object, e As System.EventArgs) Handles DeleteService.Click
        Dim langfile As New IniFile(sLANGPATH)

        If _
         MsgBox(langfile.GetString("frmComputers", "MSG23", "Вы уверены что хотите удалить?"), MsgBoxStyle.YesNo,
                ProGramName) = MsgBoxResult.Yes Then

            If lvRem2.Items.Count = 0 Then Exit Sub
            Dim tCOUNT As Integer

            For z = 0 To lvRem2.SelectedItems.Count - 1
                tCOUNT = (lvRem2.SelectedItems(z).Text)
            Next

            Dim rs1 As Recordset
            rs1 = New Recordset
            rs1.Open("Delete FROM remonty_plus WHERE id=" & tCOUNT, DB7, CursorTypeEnum.adOpenDynamic,
                     LockTypeEnum.adLockOptimistic)
            rs1 = Nothing

            Call frmserviceDesc.load_rplus(frmserviceDesc.rCOUNT, Me.lvRem2)

        Else

        End If
    End Sub

    Private Sub lvRem2_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lvRem2.MouseUp

        If lvRem2.Items.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Right Then

            CMServices.Show(CType(sender, Control), e.Location)

        Else

        End If

    End Sub

End Class