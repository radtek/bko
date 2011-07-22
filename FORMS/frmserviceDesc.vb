Imports System.Threading
Public Class frmserviceDesc

    Inherits System.Windows.Forms.Form
    Private m_SortingColumn As ColumnHeader
    Public rCOUNT As Integer
    Public r1COUNT As Integer
    Public EDTID As Integer
    Public rtxtC As String
    Private search_ As Boolean
    Public ZaiavkR As Boolean
    Public ZaiavkC As Integer
    Private FINDTXT_ As String

    Private Sub lstGroups_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles lstGroups.AfterSelect
        btnSBTAdd.Enabled = True
        On Error Resume Next
        lvRem.ListViewItemSorter = Nothing
        r1COUNT = 0
        rCOUNT = 0
        frmComputers.sCOUNT = 0

        If lstGroups.Nodes.Count <= 0 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim d() As String

        d = Split(lstGroups.SelectedNode.Tag, "|")

        'rtxtC = lstGroups.SelectedNode.Parent.Text
        rtxtC = lstGroups.SelectedNode.Text

        Select Case d(0)

            Case "C"

                Dim objIniFile As New IniFile(PrPath & "base.ini")
                objIniFile.WriteString("general", "DK", d(1))
                objIniFile.WriteString("general", "Default", 0)

            Case Else

                Dim objIniFile As New IniFile(PrPath & "base.ini")
                objIniFile.WriteString("general", "DK", 0)
                objIniFile.WriteString("general", "Default", lstGroups.SelectedNode.Tag)

        End Select

        Select Case d(0)

            Case "C"

                frmComputers.sPREF = Trim(d(0))
                frmComputers.sCOUNT = Trim(d(1))

                If search_ = True Then

                    Call Searche2(FINDTXT_)

                Else

                    LOAD_REPAIR(d(1), Me.lvRem)

                   


                End If



            Case "G"

                frmComputers.sPREF = Trim(d(0))
                frmComputers.sCOUNT = Trim(d(1))

                If search_ = True Then

                    Call Searche2(FINDTXT_)

                Else

                    LOAD_REPAIR(d(1), Me.lvRem)

                End If


            Case "O"

                frmComputers.sPREF = Trim(d(0))
                frmComputers.sCOUNT = Trim(d(1))

                If search_ = True Then

                    Call Searche2(FINDTXT_)

                Else

                    LOAD_REPAIR(d(1), Me.lvRem)

                End If

            Case "K"

                frmComputers.sPREF = Trim(d(0))
                frmComputers.sCOUNT = Trim(d(1))

                If search_ = True Then

                    Call Searche2(FINDTXT_)

                Else

                    LOAD_REPAIR(d(1), Me.lvRem)

                End If

        End Select

        Me.Cursor = Cursors.Default

    End Sub

    Public Sub LOAD_REPAIR(ByVal sID As String, ByVal lstGroups As ListView)
        On Error Resume Next

        lstGroups.Items.Clear()

        lvRem2.Items.Clear()
        lvRem.Columns.Clear()
        'Call LANG_frmserviceDesk()

        Dim LNGIniFile As New IniFile(sLANGPATH)
        lvRem.Columns.Add(LNGIniFile.GetString("frmserviceDesc", "lvRem1", ""), 20, HorizontalAlignment.Left)
        'lvRem.Columns.Add(LNGIniFile.GetString("frmserviceDesc", "lvRem2", ""), 300, HorizontalAlignment.Left)
        lvRem.Columns.Add(LNGIniFile.GetString("frmserviceDesc", "lvRem3", ""), 30, HorizontalAlignment.Left)
        lvRem.Columns.Add(LNGIniFile.GetString("frmserviceDesc", "lvRem4", ""), 90, HorizontalAlignment.Left)
        lvRem.Columns.Add(LNGIniFile.GetString("frmserviceDesc", "lvRem5", ""), 300, HorizontalAlignment.Left)
        lvRem.Columns.Add(LNGIniFile.GetString("frmserviceDesc", "lvRem6", ""), 100, HorizontalAlignment.Left)
        lvRem.Columns.Add(LNGIniFile.GetString("frmserviceDesc", "lvRem7", ""), 100, HorizontalAlignment.Left)
        lvRem.Columns.Add(LNGIniFile.GetString("frmserviceDesc", "lvRem8", ""), 100, HorizontalAlignment.Left)
        lvRem.Columns.Add(LNGIniFile.GetString("frmserviceDesc", "lvRem9", ""), 90, HorizontalAlignment.Left)
        lvRem.Columns.Add(LNGIniFile.GetString("frmserviceDesc", "lvRem10", ""), 100, HorizontalAlignment.Left)


        Dim zSTR As Integer

        Dim rs As ADODB.Recordset 'Объявляем рекордсет
        Dim sSQL As String 'Переменная, где будет размещён SQL запрос

        sSQL = "SELECT COUNT(*) as t_num FROM Remont"
        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            zSTR = .Fields("t_num").Value
        End With

        rs.Close()
        rs = Nothing

        If zSTR = 0 Then Exit Sub

        sSQL = "SELECT COUNT(*) AS t_number FROM Remont WHERE id_comp=" & frmComputers.sCOUNT & " and PREF='" & frmComputers.sPREF & "'"
        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            zSTR = .Fields("t_number").Value
        End With
        rs.Close()
        rs = Nothing


        If zSTR = 0 Then Exit Sub

        Select Case chkNZ.Checked

            Case False

                sSQL = "SELECT * FROM Remont WHERE id_comp=" & frmComputers.sCOUNT & " and PREF='" & frmComputers.sPREF & "' ORDER BY date DESC, id DESC"

            Case True

                sSQL = "SELECT * FROM Remont WHERE id_comp=" & frmComputers.sCOUNT & " AND zakryt=0 and PREF='" & frmComputers.sPREF & "' ORDER BY date DESC, id DESC"

        End Select

        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        Dim intCount As Integer
        Dim tID As Integer


        intCount = 0
        lstGroups.SmallImageList = ilsCMD

        Dim uname As Integer

        With rs
            .MoveFirst()
            Do While Not .EOF


                If .Fields("zakryt").Value = 1 Or .Fields("zakryt").Value = True Then

                    uname = 0
                Else
                    uname = 1

                End If

                Dim item As ListViewItem = lstGroups.Items.Add(.Fields(0).Value)
                item.ImageIndex = uname


                'lstGroups.Items.Add(.Fields(0).Value, uname) 'col no. 1

                tID = .Fields(0).Value

                If Not IsDBNull(.Fields("NomerRemKomp").Value) Then
                    lstGroups.Items(CInt(intCount)).SubItems.Add(.Fields("NomerRemKomp").Value)
                Else
                    lstGroups.Items(CInt(intCount)).SubItems.Add("")
                End If


                If Not IsDBNull(.Fields("Date").Value) Then
                    lstGroups.Items(CInt(intCount)).SubItems.Add(.Fields("Date").Value)
                Else
                    lstGroups.Items(CInt(intCount)).SubItems.Add("")
                End If

                If Not IsDBNull(.Fields("Remont").Value) Then
                    lstGroups.Items(CInt(intCount)).SubItems.Add(.Fields("Remont").Value)
                Else
                    lstGroups.Items(CInt(intCount)).SubItems.Add("")
                End If

                If Not IsDBNull(.Fields("Uroven").Value) Then
                    lstGroups.Items(CInt(intCount)).SubItems.Add(.Fields("Uroven").Value)
                Else
                    lstGroups.Items(CInt(intCount)).SubItems.Add("")
                End If

                If Not IsDBNull(.Fields("Master").Value) Then
                    lstGroups.Items(CInt(intCount)).SubItems.Add(.Fields("Master").Value)
                Else
                    lstGroups.Items(CInt(intCount)).SubItems.Add("")
                End If

                If Not IsDBNull(.Fields("vip").Value) Then
                    lstGroups.Items(CInt(intCount)).SubItems.Add(.Fields("vip").Value)
                Else
                    lstGroups.Items(CInt(intCount)).SubItems.Add("")
                End If

                If Not IsDBNull(.Fields("srok").Value) Then
                    lstGroups.Items(CInt(intCount)).SubItems.Add(.Fields("srok").Value)
                Else
                    lstGroups.Items(CInt(intCount)).SubItems.Add("")
                End If

                If Not IsDBNull(.Fields("UserName").Value) Then
                    lstGroups.Items(CInt(intCount)).SubItems.Add(.Fields("UserName").Value)
                Else
                    lstGroups.Items(CInt(intCount)).SubItems.Add("")
                End If
                intCount = intCount + 1

                .MoveNext()
            Loop
        End With
        rs.Close()
        rs = Nothing


        ResList(lstGroups)


    End Sub

    Public Sub LOAD_REPAIR2(ByVal lstGroups As ListView)
        On Error Resume Next
        lstGroups.Items.Clear()

        lvRem.Columns.Clear()


        Dim LNGIniFile As New IniFile(sLANGPATH)
        lvRem.Columns.Add(LNGIniFile.GetString("frmserviceDesc", "lvRem1", ""), 20, HorizontalAlignment.Left)
        lvRem.Columns.Add(LNGIniFile.GetString("frmserviceDesc", "lvRem2", ""), 300, HorizontalAlignment.Left)
        lvRem.Columns.Add(LNGIniFile.GetString("frmserviceDesc", "lvRem3", ""), 30, HorizontalAlignment.Left)
        lvRem.Columns.Add(LNGIniFile.GetString("frmserviceDesc", "lvRem4", ""), 90, HorizontalAlignment.Left)
        lvRem.Columns.Add(LNGIniFile.GetString("frmserviceDesc", "lvRem5", ""), 300, HorizontalAlignment.Left)
        lvRem.Columns.Add(LNGIniFile.GetString("frmserviceDesc", "lvRem6", ""), 100, HorizontalAlignment.Left)
        lvRem.Columns.Add(LNGIniFile.GetString("frmserviceDesc", "lvRem7", ""), 100, HorizontalAlignment.Left)
        lvRem.Columns.Add(LNGIniFile.GetString("frmserviceDesc", "lvRem8", ""), 100, HorizontalAlignment.Left)
        lvRem.Columns.Add(LNGIniFile.GetString("frmserviceDesc", "lvRem9", ""), 90, HorizontalAlignment.Left)
        lvRem.Columns.Add(LNGIniFile.GetString("frmserviceDesc", "lvRem10", ""), 100, HorizontalAlignment.Left)


        lvRem2.Items.Clear()

        Dim zSTR As Integer

        Dim rs As ADODB.Recordset 'Объявляем рекордсет
        Dim sSQL As String 'Переменная, где будет размещён SQL запрос

        sSQL = "SELECT COUNT(*) as t_num FROM Remont"
        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            zSTR = .Fields("t_num").Value
        End With

        rs.Close()
        rs = Nothing

        If zSTR = 0 Then Exit Sub

        sSQL = "SELECT * FROM Remont WHERE zakryt=0 ORDER BY date DESC, id DESC"


        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        Dim intCount As Integer
        Dim tID As Integer


        intCount = 0

        intCount = 0
        lstGroups.SmallImageList = ilsCMD

        Dim uname As Integer

        With rs
            .MoveFirst()
            Do While Not .EOF


                If .Fields("zakryt").Value = 1 Or .Fields("zakryt").Value = True Then

                    uname = 0
                Else
                    uname = 1

                End If

                Dim item As ListViewItem = lstGroups.Items.Add(.Fields(0).Value)
                item.ImageIndex = uname

                'lstGroups.Items.Add(.Fields(0).Value) 'col no. 1

                tID = .Fields(0).Value
                'Comp_Name

                If Not IsDBNull(.Fields("Comp_Name").Value) Then
                    lstGroups.Items(CInt(intCount)).SubItems.Add(.Fields("Comp_Name").Value & " - " & .Fields("Mesto_Compa").Value)
                Else
                    lstGroups.Items(CInt(intCount)).SubItems.Add(.Fields("Mesto_Compa").Value)
                End If


                If Not IsDBNull(.Fields("NomerRemKomp").Value) Then
                    lstGroups.Items(CInt(intCount)).SubItems.Add(.Fields("NomerRemKomp").Value)
                Else
                    lstGroups.Items(CInt(intCount)).SubItems.Add("")
                End If

                If Not IsDBNull(.Fields("Date").Value) Then
                    lstGroups.Items(CInt(intCount)).SubItems.Add(.Fields("Date").Value)
                Else
                    lstGroups.Items(CInt(intCount)).SubItems.Add("")
                End If

                If Not IsDBNull(.Fields("Remont").Value) Then
                    lstGroups.Items(CInt(intCount)).SubItems.Add(.Fields("Remont").Value)
                Else
                    lstGroups.Items(CInt(intCount)).SubItems.Add("")
                End If

                If Not IsDBNull(.Fields("Uroven").Value) Then
                    lstGroups.Items(CInt(intCount)).SubItems.Add(.Fields("Uroven").Value)
                Else
                    lstGroups.Items(CInt(intCount)).SubItems.Add("")
                End If

                If Not IsDBNull(.Fields("Master").Value) Then
                    lstGroups.Items(CInt(intCount)).SubItems.Add(.Fields("Master").Value)
                Else
                    lstGroups.Items(CInt(intCount)).SubItems.Add("")
                End If

                If Not IsDBNull(.Fields("vip").Value) Then
                    lstGroups.Items(CInt(intCount)).SubItems.Add(.Fields("vip").Value)
                Else
                    lstGroups.Items(CInt(intCount)).SubItems.Add("")
                End If

                If Not IsDBNull(.Fields("srok").Value) Then
                    lstGroups.Items(CInt(intCount)).SubItems.Add(.Fields("srok").Value)
                Else
                    lstGroups.Items(CInt(intCount)).SubItems.Add("")
                End If

                If Not IsDBNull(.Fields("UserName").Value) Then
                    lstGroups.Items(CInt(intCount)).SubItems.Add(.Fields("UserName").Value)
                Else
                    lstGroups.Items(CInt(intCount)).SubItems.Add("")
                End If
                intCount = intCount + 1

                .MoveNext()
            Loop
        End With
        rs.Close()
        rs = Nothing

        ResList(lstGroups)
    End Sub

    Private Sub lvRem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvRem.Click

        lvRem2.ListViewItemSorter = Nothing

        Dim z As Integer

        lvRem2.Items.Clear()

        For z = 0 To lvRem.SelectedItems.Count - 1
            r1COUNT = (lvRem.SelectedItems(z).Text)
        Next


        Call load_rplus(r1COUNT)

    End Sub

    Public Sub load_rplus(ByVal sSID As Integer)
        On Error GoTo err_1
        Dim unam As String

        lvRem2.Items.Clear()


        Dim rs As ADODB.Recordset 'Объявляем рекордсет
        Dim sSQL As String 'Переменная, где будет размещён SQL запрос

        sSQL = "SELECT zakryt FROM Remont WHERE id=" & sSID
        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            unam = .Fields("zakryt").Value
        End With
        rs.Close()
        rs = Nothing

        If unam = "1" Or unam = True Then

            btnSBTAdd.Enabled = False
            btnSendEmail.Enabled = False
        Else
            btnSBTAdd.Enabled = True
            btnSendEmail.Enabled = True
        End If




        sSQL = "SELECT COUNT(*) AS t_number FROM remonty_plus WHERE id_rem=" & sSID
        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            unam = .Fields("t_number").Value
        End With
        rs.Close()
        rs = Nothing

        If unam = 0 Then Exit Sub


        rs = New ADODB.Recordset
        sSQL = "SELECT * FROM remonty_plus WHERE id_rem =" & sSID

        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        Dim intj As Integer

        intj = 0

        With rs
            .MoveFirst()
            Do While Not .EOF

                lvRem2.Items.Add(.Fields(0).Value) 'col no. 1

                If Not IsDBNull(.Fields("data").Value) Then
                    lvRem2.Items(CInt(intj)).SubItems.Add(.Fields("data").Value)
                Else
                    lvRem2.Items(CInt(intj)).SubItems.Add("")
                End If

                If Not IsDBNull(.Fields("master").Value) Then
                    lvRem2.Items(CInt(intj)).SubItems.Add(.Fields("master").Value)
                Else
                    lvRem2.Items(CInt(intj)).SubItems.Add("")
                End If

                If Not IsDBNull(.Fields("otzyv").Value) Then
                    lvRem2.Items(CInt(intj)).SubItems.Add(.Fields("otzyv").Value)
                Else
                    lvRem2.Items(CInt(intj)).SubItems.Add("")
                End If

                intj = intj + 1

                .MoveNext()
                'DoEvents
            Loop
        End With

        rs.Close()
        rs = Nothing



        ResList(Me.lvRem2)

        Exit Sub
err_1:
        MsgBox(Err.Description, MsgBoxStyle.Information, ProGramName)
    End Sub

    Private Sub lvRem_ClientSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvRem.ClientSizeChanged

    End Sub

    Private Sub lvRem_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvRem.ColumnClick
        Dim new_sorting_column As ColumnHeader = _
     lvRem.Columns(e.Column)
        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            sort_order = SortOrder.Ascending
        Else
            If new_sorting_column.Equals(m_SortingColumn) Then
                If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                sort_order = SortOrder.Ascending
            End If

            m_SortingColumn.Text = m_SortingColumn.Text.Substring(2)
        End If

        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "> " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "< " & m_SortingColumn.Text
        End If

        lvRem.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)

        lvRem.Sort()
    End Sub

    Private Sub lvRem_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvRem.DoubleClick

        If uLevelRepEd = False And uLevel <> "Admin" Then Exit Sub

        frmService_add.REMFU = False
        Call Load_Z_Form()

    End Sub

    Public Sub Load_Z_Form(Optional ByVal sSID As Integer = 0)
        If lvRem.Items.Count = 0 Then Exit Sub

        Dim z As Integer

        If sSID <> 0 Then

            rCOUNT = sSID

        Else

            For z = 0 To lvRem.SelectedItems.Count - 1
                rCOUNT = (lvRem.SelectedItems(z).Text)
            Next

        End If


        Dim sSQL As String
        Dim rs1 As ADODB.Recordset
        rs1 = New ADODB.Recordset

        sSQL = "SELECT * FROM Remont WHERE id=" & rCOUNT

        Dim LNGIniFile As New IniFile(sLANGPATH)

        frmService_add.Text = LNGIniFile.GetString("frmserviceDesc", "MSG1", "") & " " & lstGroups.SelectedNode.Text

        rs1.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        Dim sSw As Date
        Dim sSw2 As String

        With rs1
            .MoveFirst()
            Do While Not .EOF

                If Not IsDBNull(.Fields("istochnik").Value) Then frmService_add.cmbIst.Text = .Fields("istochnik").Value 'Источник
                If Not IsDBNull(.Fields("Master").Value) Then frmService_add.cmbMast.Text = .Fields("Master").Value 'Мастер


                If Not IsDBNull(.Fields("Date").Value) Then sSw = .Fields("Date").Value
                If Not IsDBNull(.Fields("srok").Value) Then sSw2 = .Fields("srok").Value

                If Len(sSw) = 0 Then
                    sSw = Date.Today
                End If

                If Len(sSw2) = 0 Then
                    sSw2 = Date.Today
                End If

                frmService_add.dtReg.Value = sSw 'Дата регистрации
                frmService_add.dtIsp.Value = sSw2 'Срок исполнения


                If Not IsDBNull(.Fields("phone").Value) Then frmService_add.txtPhone.Text = .Fields("phone").Value 'Телефон
                If Not IsDBNull(.Fields("name_of_remont").Value) Then frmService_add.txtHead.Text = .Fields("name_of_remont").Value 'Название
                If Not IsDBNull(.Fields("Remont").Value) Then frmService_add.txtRem.Text = .Fields("Remont").Value 'Сообщение
                If Not IsDBNull(.Fields("vip").Value) Then frmService_add.cmbStatus.Text = .Fields("vip").Value 'Статус
                If Not IsDBNull(.Fields("otvetstv").Value) Then frmService_add.cmbOtv.Text = .Fields("otvetstv").Value 'Ответственный

                If Not IsDBNull(.Fields("krit_rem").Value) Then frmService_add.cmbTip.Text = .Fields("krit_rem").Value 'Критичность
                If Not IsDBNull(.Fields("Uroven").Value) Then frmService_add.cmbKrit.Text = .Fields("Uroven").Value 'Тип


                If Not IsDBNull(.Fields("MeMo").Value) Then frmService_add.txtComent.Text = .Fields("MeMo").Value 'Комментарий

                If Not IsDBNull(.Fields("Summ").Value) Then frmService_add.RemCashe.Text = .Fields("Summ").Value 'Комментарий

                '.Fields("Summ").Value = RemCashe.Text 'Сумма

                If .Fields("zakryt").Value = -1 Then
                    frmService_add.chkClose.Checked = 1
                Else

                    frmService_add.chkClose.Checked = 0
                End If

                .MoveNext()
            Loop
        End With

        frmService_add.REMED = True

        frmService_add.cmbAdd.Text = LNGIniFile.GetString("frmserviceDesc", "MSG2", "")

        rs1.Close()
        rs1 = Nothing

        frmService_add.ShowDialog(Me)
    End Sub

    Private Sub frmserviceDesc_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ''My.Application.DoEvents()
        frmMain.SaveInfTehButton.Enabled = False
        frmMain.ToolStripDropDownButton1.Enabled = False

    End Sub

    Private Sub frmserviceDesc_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        SendFonts(Me)

        Dim newThread1 As New Thread(AddressOf LANG_frmserviceDesk)
        newThread1.Start()


        Dim objIniFile As New IniFile(PrPath & "base.ini")
        Dim uname As String
        FillComboNET(Me.treebranche, "FILIAL", "SPR_FILIAL", "", False, True)

        Dim LNGIniFile As New IniFile(sLANGPATH)
        treebranche.Items.Add(LNGIniFile.GetString("frmComputers", "MSG53", ""))
        uname = objIniFile.GetString("General", "branche", "")


        If Len(uname) = 0 Then
            treebranche.Text = LNGIniFile.GetString("frmComputers", "MSG53", "")

        Else
            treebranche.Text = uname

        End If


        Me.Cursor = Cursors.WaitCursor
        Me.Show()

        If lstGroups.Nodes.Count = 0 Then

            If Me.lstGroups.Nodes.Count = 0 Then
                Dim newThread5 As New Thread(AddressOf R_T_LOAD)
                newThread5.Start()

            End If

        End If


      

        Me.Cursor = Cursors.Default



    End Sub

    Private Sub R_T_LOAD()

        Me.lstGroups.BeginInvoke(New MethodInvoker(AddressOf R_T_LOAD_1))

    End Sub

    Private Sub R_T_LOAD_1()
        Call RefFilTree(Me.lstGroups)
    End Sub


    Private Sub btnRemAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemAdd.Click



        On Error GoTo Err_1
        frmService_add.REMFU = False
        frmService_add.REMED = False

        Dim d() As String

        d = Split(lstGroups.SelectedNode.Tag, "|")
        frmComputers.sPREF = d(0)
        frmComputers.sCOUNT = d(1)

        If frmComputers.sCOUNT = 0 Then Exit Sub

        If Len(frmComputers.sCOUNT) = 0 Then Exit Sub
        Dim LNGIniFile As New IniFile(sLANGPATH)
        frmService_add.Text = LNGIniFile.GetString("frmserviceDesc", "MSG1", "") & " " & lstGroups.SelectedNode.Text

        frmService_add.cmbIst.Text = ""
        frmService_add.cmbMast.Text = ""
        frmService_add.txtPhone.Text = ""
        frmService_add.dtReg.Value = Date.Today
        frmService_add.dtIsp.Value = Date.Today
        frmService_add.txtHead.Text = ""
        frmService_add.txtRem.Text = ""
        frmService_add.cmbStatus.Text = ""
        frmService_add.cmbOtv.Text = ""
        frmService_add.cmbKrit.Text = ""
        frmService_add.cmbTip.Text = ""
        frmService_add.txtComent.Text = ""
        frmService_add.RemCashe.Text = 0
        frmService_add.cmbAdd.Text = LNGIniFile.GetString("frmService_add", "cmbAdd", "")
        frmService_add.chkClose.Checked = 0

        frmService_add.ShowDialog(Me)

        Call SaveActivityToLogDB(LNGIniFile.GetString("frmserviceDesc", "MSG4", "") & " " & lstGroups.SelectedNode.Text)

        Exit Sub
Err_1:
        MsgBox(Err.Description, MsgBoxStyle.Information, ProGramName)
    End Sub

    Private Sub chkNZ_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNZ.CheckedChanged

        Call LOAD_REPAIR(frmComputers.sCOUNT, Me.lvRem)

    End Sub

    Private Sub SplitContainer1_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles SplitContainer1.Move
        Call Resizer()
    End Sub

    Private Sub SplitContainer1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles SplitContainer1.Resize
        Call Resizer()
    End Sub

    Private Sub SplitContainer1_SplitterMoved(ByVal sender As Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles SplitContainer1.SplitterMoved
        Call Resizer()
    End Sub

    Private Sub serviceDesc_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

        Call Resizer()

    End Sub

    Private Sub Resizer()

        If Me.Height < 768 Then Me.Height = 768
        If Me.Width < 1024 Then Me.Width = 1024


        If SplitContainer1.SplitterDistance > 450 Then SplitContainer1.SplitterDistance = 450
        If SplitContainer1.SplitterDistance < 250 Then SplitContainer1.SplitterDistance = 250

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Me.Cursor = Cursors.WaitCursor
        search_ = False
        txtSearch.Text = ""

        Dim newThread5 As New Thread(AddressOf R_T_LOAD)
        newThread5.Start()


        Me.Cursor = Cursors.Default


    End Sub

    Private Sub Search2(ByVal sFindText As String, Optional ByVal MtchWord As Byte = 0, Optional ByVal MtchCase As Byte = 0)

        lstGroups.Nodes.Clear()

        search_ = True
        Dim FirstColumn As Boolean

        Dim rs3 As ADODB.Recordset 'Объявляем рекордсет
        Dim sSQL3 As String 'Переменная, где будет размещён SQL запрос
        Dim rs As ADODB.Recordset 'Объявляем рекордсет
        Dim sSQL As String 'Переменная, где будет размещён SQL запрос

        Dim rs4 As ADODB.Recordset 'Объявляем рекордсет
        Dim sSQL4 As String 'Переменная, где будет размещён SQL запрос



        On Error Resume Next

        Dim GID As Integer


        If MtchWord = 1 And MtchCase = 1 Then
            mde = 3
        Else
            If MtchWord = 1 And MtchCase = 0 Then
                mde = 2
            Else
                If MtchCase = 1 And MtchWord = 0 Then
                    mde = 1
                Else
                    If MtchCase = 0 And MtchWord = 0 Then
                        mde = 0
                    End If
                End If
            End If
        End If
        Dim LNGIniFile As New IniFile(sLANGPATH)

        Dim nodeRoot As New TreeNode(ProGramName, 0, 0)
        nodeRoot.Tag = "ROOT" & GENID()

        lstGroups.Nodes.Add(nodeRoot)

        Dim TempNode As New TreeNode(LNGIniFile.GetString("frmserviceDesc", "MSG5", ""), 0, 0)
        TempNode.Tag = "G1|2"
        nodeRoot.Nodes.Add(TempNode)


        Dim TempNode2 As New TreeNode(LNGIniFile.GetString("frmserviceDesc", "MSG6", ""), 0, 0)
        TempNode.Tag = "G1|2"
        nodeRoot.Nodes.Add(TempNode2)


        sSQL = "SELECT * FROM Remont WHERE Id like '%" & sFindText & "%' or Date like '%" & sFindText & "%' or Id_Comp like '%" & sFindText & "%' or Remont like '%" & sFindText & "%' or Uroven like '%" & sFindText & "%' or Master like '%" & sFindText & "%' or NomerRemKomp like '%" & sFindText & "%' or Comp_Name like '%" & sFindText & "%' or Mesto_Compa like '%" & sFindText & "%' or vip like '%" & sFindText & "%' or UserName like '%" & sFindText & "%' or istochnik like '%" & sFindText & "%' or phone like '%" & sFindText & "%' or srok like '%" & sFindText & "%' or name_of_remont like '%" & sFindText & "%' or otvetstv like '%" & sFindText & "%' or krit_rem like '%" & sFindText & "%' or MeMo like '%" & sFindText & "%' or zakryt like '%" & sFindText & "%' or PREF like '%" & sFindText & "%' or Summ like '%" & sFindText & "%'"


        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)


        'sFindText = txtSearch.Text

        'sSQL3 = "SELECT * FROM kompy order by PSEVDONIM, filial"
        sSQL3 = "SELECT * FROM kompy where ID like '%" & sFindText & "%' or CPU1 like '%" & sFindText & "%' or CPUmhz1 like '%" & sFindText & "%' or CPU2 like '%" & sFindText & "%' or CPUmhz2 like '%" & sFindText & "%' or CPU3 like '%" & sFindText & "%' or CPUmhz3 like '%" & sFindText & "%' or CPU4 like '%" & sFindText & "%' or CPUmhz4 like '%" & sFindText & "%' or Mb like '%" & sFindText & "%' or Mb_Chip like '%" & sFindText & "%' or Mb_Proizvod like '%" & sFindText & "%' or RAM_1 like '%" & sFindText & "%' or RAM_2 like '%" & sFindText & "%' or RAM_3 like '%" & sFindText & "%' or RAM_4 like '%" & sFindText & "%' or HDD_Name_1 like '%" & sFindText & "%' or HDD_OB_1 like '%" & sFindText & "%' or HDD_SN_1 like '%" & sFindText & "%' or HDD_Name_2 like '%" & sFindText & "%' or HDD_OB_2 like '%" & sFindText & "%' or HDD_SN_2 like '%" & sFindText & "%' or HDD_Name_3 like '%" & sFindText & "%' or HDD_OB_3 like '%" & sFindText & "%' or HDD_SN_3 like '%" & sFindText & "%' or HDD_Name_4 like '%" & sFindText & "%' or HDD_OB_4 like '%" & sFindText & "%' or HDD_SN_4 like '%" & sFindText & "%' or SVGA_NAME like '%" & sFindText & "%' or SVGA_SN like '%" & sFindText & "%' or SOUND_NAME like '%" & sFindText & "%' or CD_NAME like '%" & sFindText & "%' or CD_SPEED like '%" & sFindText & "%' or CD_SN like '%" & sFindText & "%' or CDRW_NAME like '%" & sFindText & "%' or CDRW_SPEED like '%" & sFindText & "%' or CDRW_SN like '%" & sFindText & "%' or DVD_NAME like '%" & sFindText & "%' or DVD_SPEED like '%" & sFindText & "%' or DVD_SN like '%" & sFindText & "%' or NET_NAME_1 like '%" & sFindText & "%' or NET_IP_1 like '%" & sFindText & "%' or NET_NAME_2 like '%" & sFindText & "%' or NET_IP_2 like '%" & sFindText & "%' or NET_MAC_2 like '%" & sFindText & "%' or MODEM_NAME like '%" & sFindText & "%' or MODEM_SN like '%" & sFindText & "%' or MONITOR_NAME like '%" & sFindText & "%' or MONITOR_NAME2 like '%" & sFindText & "%' or AS_NAME like '%" & sFindText & "%' or AS_PROIZV like '%" & sFindText & "%' or IBP_NAME like '%" & sFindText & "%' or FILTR_NAME like '%" & sFindText & "%' or PRINTER_NAME_1 like '%" & sFindText & "%' or PRINTER_SN_1 like '%" & sFindText & "%' or PORT_1 like '%" & sFindText & "%' or PRINTER_PROIZV_1 like '%" & sFindText & "%' or PRINTER_NAME_2 like '%" & sFindText & "%' or PORT_2 like '%" & sFindText & "%' or PRINTER_SN_2 like '%" & sFindText & "%' or PRINTER_PROIZV_2 like '%" & sFindText & "%' or PRINTER_NAME_3 like '%" & sFindText & "%' or PORT_3 like '%" & sFindText & "%' or PRINTER_SN_3 like '%" & sFindText & "%' or PRINTER_PROIZV_3 like '%" & sFindText & "%' or PORT_4 like '%" & sFindText & "%' or PRINTER_NAME_4 like '%" & sFindText & "%' or PRINTER_SN_4 like '%" & sFindText & "%' or PRINTER_PROIZV_4 like '%" & sFindText & "%' or SCANER_NAME like '%" & sFindText & "%' or NET_NAME like '%" & sFindText & "%' or PSEVDONIM like '%" & sFindText & "%' or MESTO like '%" & sFindText & "%' or kabn like '%" & sFindText & "%' or FILIAL like '%" & sFindText & "%' or TELEPHONE like '%" & sFindText & "%' or INV_NO_SYSTEM like '%" & sFindText & "%' or INV_NO_PRINTER like '%" & sFindText & "%' or INV_NO_MODEM like '%" & sFindText & "%' or INV_NO_SCANER like '%" & sFindText & "%' or INV_NO_MONITOR like '%" & sFindText & "%' or INV_NO_IBP like '%" & sFindText & "%' or OTvetstvennyj like '%" & sFindText & "%' or Ser_N_SIS like '%" & sFindText & "%' or BLOCK like '%" & sFindText & "%' or SN_BLOCK like '%" & sFindText & "%' or CREADER_NAME like '%" & sFindText & "%' or CASE_NAME like '%" & sFindText & "%' or CASE_SN like '%" & sFindText & "%' or CASE_PROIZV like '%" & sFindText & "%' or SYS_PR like '%" & sFindText & "%' order by PSEVDONIM, filial"

        rs3 = New ADODB.Recordset
        rs3.Open(sSQL3, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs3
            .MoveFirst()
            Do While Not .EOF

                'My.Application.DoEvents()
                FINDTXT = ""
                FirstColumn = True
                'Ищем то что нам нужно

                For lngCounter = 0 To 184

                    If FirstColumn Then

                        If Not IsDBNull(.Fields(lngCounter).Value) Then If isThere(.Fields(lngCounter).Value, sFindText, mde) = True Then GoTo Foundit

                    Else

                    End If                  'TO KEEP DATA FROM SHIFTING LEFT

                Next

Foundit:



                If Len(FINDTXT) = 0 Then

                Else


                    Select Case .Fields("tiptehn").Value

                        Case "PC"

                            Dim iC, iA As String
                            iC = .Fields("TIP_COMPA").Value


                            If iC = "Ноутбук" Or iC = "notebook" Or iC = "Notebook" Or iC = "NoteBook" Then
                                iC = "Ноутбук"
                            End If

                            If iC = "КПК" Or iC = "Pocket PC" Or iC = "Pocket" Or iC = "Palm" Then
                                iC = "КПК"
                            End If

                            If iC = "Сервер" Or iC = "Server" Or iC = "Сервер для тонких клиентов" Or iC = "Сервер видео наблюдения" Then
                                iC = "Сервер"
                            End If

                            'Pocket PC

                            Select Case iC

                                Case "Рабочая станция"
                                    iA = 4


                                Case "Сервер"

                                    iA = 3

                                Case "КПК"
                                    iA = 31

                                Case "Ноутбук"
                                    iA = 5

                                Case Else
                                    iA = 4

                            End Select

                            Dim TEHNode As New TreeNode(.Fields("NET_NAME").Value, iA, iA)
                            TEHNode.Tag = "C|" & .Fields(0).Value
                            TempNode.Nodes.Add(TEHNode)

                        Case "Printer"
                            Dim TEHNode As New TreeNode(.Fields("NET_NAME").Value, 7, 7)
                            TEHNode.Tag = "C|" & .Fields(0).Value
                            TempNode.Nodes.Add(TEHNode)

                        Case "MFU"

                            Dim TEHNode As New TreeNode(.Fields("NET_NAME").Value, 8, 8)
                            TEHNode.Tag = "C|" & .Fields(0).Value
                            TempNode.Nodes.Add(TEHNode)

                        Case "KOpir"
                            Dim TEHNode As New TreeNode(.Fields("NET_NAME").Value, 9, 9)
                            TEHNode.Tag = "C|" & .Fields(0).Value
                            TempNode.Nodes.Add(TEHNode)

                        Case "NET"
                            Dim TEHNode As New TreeNode(.Fields("NET_NAME").Value, 10, 10)
                            TEHNode.Tag = "C|" & .Fields(0).Value
                            TempNode.Nodes.Add(TEHNode)

                        Case "PHOTO"
                            Dim TEHNode As New TreeNode(.Fields("NET_NAME").Value, 11, 11)
                            TEHNode.Tag = "C|" & .Fields(0).Value
                            TempNode.Nodes.Add(TEHNode)

                        Case "PHONE"
                            Dim TEHNode As New TreeNode(.Fields("NET_NAME").Value, 12, 12)
                            TEHNode.Tag = "C|" & .Fields(0).Value
                            TempNode.Nodes.Add(TEHNode)

                        Case "FAX"
                            Dim TEHNode As New TreeNode(.Fields("NET_NAME").Value, 13, 13)
                            TEHNode.Tag = "C|" & .Fields(0).Value
                            TempNode.Nodes.Add(TEHNode)
                        Case "SCANER"

                            Dim TEHNode As New TreeNode(.Fields("NET_NAME").Value, 14, 14)
                            TEHNode.Tag = "C|" & .Fields(0).Value
                            TempNode.Nodes.Add(TEHNode)
                        Case "ZIP"
                            Dim TEHNode As New TreeNode(.Fields("NET_NAME").Value, 15, 15)
                            TEHNode.Tag = "C|" & .Fields(0).Value
                            TempNode.Nodes.Add(TEHNode)

                        Case "OT"

                            Dim uname As String
                            Dim rsOT As ADODB.Recordset
                            rsOT = New ADODB.Recordset
                            rsOT.Open("SELECT A FROM spr_other where Name ='" & .Fields("NET_NAME").Value & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                            With rsOT
                                If Not IsDBNull(.Fields("A").Value) Then uname = .Fields("A").Value
                            End With

                            rsOT.Close()
                            rsOT = Nothing

                            Dim TEHNode As New TreeNode(.Fields("NET_NAME").Value, uname, uname)
                            TEHNode.Tag = "C|" & .Fields(0).Value
                            TempNode.Nodes.Add(TEHNode)

                        Case "MONITOR"
                            Dim TEHNode As New TreeNode(.Fields("NET_NAME").Value, 17, 17)
                            TEHNode.Tag = "C|" & .Fields(0).Value
                            TempNode.Nodes.Add(TEHNode)
                            '--------------VIP_Graff Добавление новой перефирии Начало-----------------
                        Case "USB"
                            Dim TEHNode As New TreeNode(.Fields("NET_NAME").Value, 18, 18)
                            TEHNode.Tag = "C|" & .Fields(0).Value
                            TempNode.Nodes.Add(TEHNode)

                        Case "SOUND"
                            Dim TEHNode As New TreeNode(.Fields("NET_NAME").Value, 44, 44)
                            TEHNode.Tag = "C|" & .Fields(0).Value
                            TempNode.Nodes.Add(TEHNode)

                        Case "IBP"
                            Dim TEHNode As New TreeNode(.Fields("NET_NAME").Value, 41, 41)
                            TEHNode.Tag = "C|" & .Fields(0).Value
                            TempNode.Nodes.Add(TEHNode)

                        Case "FS"
                            Dim TEHNode As New TreeNode(.Fields("NET_NAME").Value, 61, 61)
                            TEHNode.Tag = "C|" & .Fields(0).Value
                            TempNode.Nodes.Add(TEHNode)

                        Case "KEYB"
                            Dim TEHNode As New TreeNode(.Fields("NET_NAME").Value, 46, 46)
                            TEHNode.Tag = "C|" & .Fields(0).Value
                            TempNode.Nodes.Add(TEHNode)

                        Case "MOUSE"
                            Dim TEHNode As New TreeNode(.Fields("NET_NAME").Value, 47, 47)
                            TEHNode.Tag = "C|" & .Fields(0).Value
                            TempNode.Nodes.Add(TEHNode)
                            '--------------VIP_Graff Добавление новой перефирии Конец------------------

                        Case "CNT"

                            Dim uname As String
                            Dim rsOT As ADODB.Recordset
                            rsOT = New ADODB.Recordset
                            rsOT.Open("SELECT A FROM spr_other where Name ='" & .Fields("NET_NAME").Value & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                            With rsOT
                                If Not IsDBNull(.Fields("A").Value) Then uname = .Fields("A").Value
                            End With

                            rsOT.Close()
                            rsOT = Nothing

                            Dim TEHNode As New TreeNode(.Fields("NET_NAME").Value, uname, uname)
                            TEHNode.Tag = "C|" & .Fields(0).Value
                            TempNode.Nodes.Add(TEHNode)

                        Case Else

                    End Select

                End If

                .MoveNext()
            Loop
        End With
        rs3.Close()
        rs3 = Nothing

        With rs
            .MoveFirst()
            Do While Not .EOF
                FINDTXT = ""

                If Not IsDBNull(.Fields("Date").Value) Then If isThere(.Fields("Date").Value, sFindText, mde) = True Then GoTo FoundiR
                If Not IsDBNull(.Fields("Remont").Value) Then If isThere(.Fields("Remont").Value, sFindText, mde) = True Then GoTo FoundiR
                If Not IsDBNull(.Fields("Uroven").Value) Then If isThere(.Fields("Uroven").Value, sFindText, mde) = True Then GoTo FoundiR
                If Not IsDBNull(.Fields("Master").Value) Then If isThere(.Fields("Master").Value, sFindText, mde) = True Then GoTo FoundiR
                If Not IsDBNull(.Fields("NomerRemKomp").Value) Then If isThere(.Fields("NomerRemKomp").Value, sFindText, mde) = True Then GoTo FoundiR
                If Not IsDBNull(.Fields("Comp_Name").Value) Then If isThere(.Fields("Comp_Name").Value, sFindText, mde) = True Then GoTo FoundiR
                If Not IsDBNull(.Fields("Mesto_Compa").Value) Then If isThere(.Fields("Mesto_Compa").Value, sFindText, mde) = True Then GoTo FoundiR
                If Not IsDBNull(.Fields("vip")) Then If isThere(.Fields("vip").Value, sFindText, mde) = True Then GoTo FoundiR
                'If Not IsNull(.Fields("Name")) Then If isThere(.Fields("Name"), sFindText, mde) = True Then GoTo FoundiR:
                If Not IsDBNull(.Fields("name_of_remont").Value) Then If isThere(.Fields("name_of_remont").Value, sFindText, mde) = True Then GoTo FoundiR
                If Not IsDBNull(.Fields("MeMo").Value) Then If isThere(.Fields("MeMo").Value, sFindText, mde) = True Then GoTo FoundiR


FoundiR:
                If Len(FINDTXT) = 0 Then
                Else

                    Dim inising As String = .Fields("Id_Comp").Value

                    sSQL3 = "SELECT * FROM kompy where id=" & inising & " order by PSEVDONIM, filial"
                    rs3 = New ADODB.Recordset
                    rs3.Open(sSQL3, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                    With rs3
                        .MoveFirst()
                        Do While Not .EOF
                            If GID <> -1 Then

                                Select Case .Fields("tiptehn").Value

                                    Case "PC"

                                        Dim iC, iA As String
                                        iC = .Fields("TIP_COMPA").Value


                                        If iC = "Ноутбук" Or iC = "notebook" Or iC = "Notebook" Or iC = "NoteBook" Then
                                            iC = "Ноутбук"
                                        End If

                                        If iC = "КПК" Or iC = "Pocket PC" Or iC = "Pocket" Or iC = "Palm" Then
                                            iC = "КПК"
                                        End If

                                        If iC = "Сервер" Or iC = "Server" Or iC = "Сервер для тонких клиентов" Or iC = "Сервер видео наблюдения" Then
                                            iC = "Сервер"
                                        End If

                                        'Pocket PC

                                        Select Case iC

                                            Case "Рабочая станция"
                                                iA = 4


                                            Case "Сервер"

                                                iA = 3

                                            Case "КПК"
                                                iA = 31

                                            Case "Ноутбук"
                                                iA = 5

                                            Case Else
                                                iA = 4

                                        End Select

                                        Dim TEHNode As New TreeNode(.Fields("NET_NAME").Value, iA, iA)
                                        TEHNode.Tag = "C|" & .Fields(0).Value
                                        TempNode2.Nodes.Add(TEHNode)

                                    Case "Printer"
                                        Dim TEHNode As New TreeNode(.Fields("NET_NAME").Value, 7, 7)
                                        TEHNode.Tag = "C|" & .Fields(0).Value
                                        TempNode2.Nodes.Add(TEHNode)

                                    Case "MFU"

                                        Dim TEHNode As New TreeNode(.Fields("NET_NAME").Value, 8, 8)
                                        TEHNode.Tag = "C|" & .Fields(0).Value
                                        TempNode2.Nodes.Add(TEHNode)

                                    Case "KOpir"
                                        Dim TEHNode As New TreeNode(.Fields("NET_NAME").Value, 9, 9)
                                        TEHNode.Tag = "C|" & .Fields(0).Value
                                        TempNode2.Nodes.Add(TEHNode)

                                    Case "NET"
                                        Dim TEHNode As New TreeNode(.Fields("NET_NAME").Value, 10, 10)
                                        TEHNode.Tag = "C|" & .Fields(0).Value
                                        TempNode2.Nodes.Add(TEHNode)

                                    Case "PHOTO"
                                        Dim TEHNode As New TreeNode(.Fields("NET_NAME").Value, 11, 11)
                                        TEHNode.Tag = "C|" & .Fields(0).Value
                                        TempNode2.Nodes.Add(TEHNode)

                                    Case "PHONE"
                                        Dim TEHNode As New TreeNode(.Fields("NET_NAME").Value, 12, 12)
                                        TEHNode.Tag = "C|" & .Fields(0).Value
                                        TempNode2.Nodes.Add(TEHNode)

                                    Case "FAX"
                                        Dim TEHNode As New TreeNode(.Fields("NET_NAME").Value, 13, 13)
                                        TEHNode.Tag = "C|" & .Fields(0).Value
                                        TempNode2.Nodes.Add(TEHNode)
                                    Case "SCANER"

                                        Dim TEHNode As New TreeNode(.Fields("NET_NAME").Value, 14, 14)
                                        TEHNode.Tag = "C|" & .Fields(0).Value
                                        TempNode2.Nodes.Add(TEHNode)
                                    Case "ZIP"
                                        Dim TEHNode As New TreeNode(.Fields("NET_NAME").Value, 15, 15)
                                        TEHNode.Tag = "C|" & .Fields(0).Value
                                        TempNode2.Nodes.Add(TEHNode)

                                    Case "OT"

                                        Dim uname As String
                                        Dim rsOT As ADODB.Recordset
                                        rsOT = New ADODB.Recordset
                                        rsOT.Open("SELECT A FROM spr_other where Name ='" & .Fields("NET_NAME").Value & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                                        With rsOT
                                            If Not IsDBNull(.Fields("A").Value) Then uname = .Fields("A").Value
                                        End With

                                        rsOT.Close()
                                        rsOT = Nothing

                                        Dim TEHNode As New TreeNode(.Fields("NET_NAME").Value, uname, uname)
                                        TEHNode.Tag = "C|" & .Fields(0).Value
                                        TempNode2.Nodes.Add(TEHNode)

                                    Case "MONITOR"
                                        Dim TEHNode As New TreeNode(.Fields("NET_NAME").Value, 17, 17)
                                        TEHNode.Tag = "C|" & .Fields(0).Value
                                        TempNode2.Nodes.Add(TEHNode)
                                        '--------------VIP_Graff Добавление новой перефирии Начало-----------------
                                    Case "USB"
                                        Dim TEHNode As New TreeNode(.Fields("NET_NAME").Value, 18, 18)
                                        TEHNode.Tag = "C|" & .Fields(0).Value
                                        TempNode2.Nodes.Add(TEHNode)

                                    Case "SOUND"
                                        Dim TEHNode As New TreeNode(.Fields("NET_NAME").Value, 44, 44)
                                        TEHNode.Tag = "C|" & .Fields(0).Value
                                        TempNode2.Nodes.Add(TEHNode)

                                    Case "IBP"
                                        Dim TEHNode As New TreeNode(.Fields("NET_NAME").Value, 41, 41)
                                        TEHNode.Tag = "C|" & .Fields(0).Value
                                        TempNode2.Nodes.Add(TEHNode)

                                    Case "FS"
                                        Dim TEHNode As New TreeNode(.Fields("NET_NAME").Value, 61, 61)
                                        TEHNode.Tag = "C|" & .Fields(0).Value
                                        TempNode2.Nodes.Add(TEHNode)

                                    Case "KEYB"
                                        Dim TEHNode As New TreeNode(.Fields("NET_NAME").Value, 46, 46)
                                        TEHNode.Tag = "C|" & .Fields(0).Value
                                        TempNode2.Nodes.Add(TEHNode)

                                    Case "MOUSE"
                                        Dim TEHNode As New TreeNode(.Fields("NET_NAME").Value, 47, 47)
                                        TEHNode.Tag = "C|" & .Fields(0).Value
                                        TempNode2.Nodes.Add(TEHNode)
                                        '--------------VIP_Graff Добавление новой перефирии Конец------------------

                                    Case "CNT"

                                        Dim uname As String
                                        Dim rsOT As ADODB.Recordset
                                        rsOT = New ADODB.Recordset
                                        rsOT.Open("SELECT A FROM spr_other where Name ='" & .Fields("NET_NAME").Value & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                                        With rsOT
                                            If Not IsDBNull(.Fields("A").Value) Then uname = .Fields("A").Value
                                        End With

                                        rsOT.Close()
                                        rsOT = Nothing

                                        Dim TEHNode As New TreeNode(.Fields("NET_NAME").Value, uname, uname)
                                        TEHNode.Tag = "C|" & .Fields(0).Value
                                        TempNode2.Nodes.Add(TEHNode)

                                    Case Else

                                End Select

                            End If

                            .MoveNext()
                        Loop
                    End With
                    rs3.Close()
                    rs3 = Nothing

                End If
                .MoveNext()
            Loop
        End With
        rs.Close()
        rs = Nothing


        lstGroups.SelectedNode = nodeRoot

        Dim tNode As New TreeNode
        tNode = lstGroups.Nodes(0)
        tNode.Expand()





    End Sub

    Private Sub Searche2(ByVal sFindText As String, Optional ByVal MtchWord As Byte = 0, Optional ByVal MtchCase As Byte = 0)
        Dim rs3 As ADODB.Recordset 'Объявляем рекордсет
        Dim sSQL3 As String 'Переменная, где будет размещён SQL запрос


        Dim FirstColumn As Boolean



        On Error GoTo Error_
        lvRem.Items.Clear()


        'sSQL3 = "SELECT * FROM Remont where id_comp =" & frmMain.nomerPCAbs & " order by Date desc"
        sSQL3 = "SELECT id, NomerRemKomp, date, Remont, Uroven, Master, vip, username, zakryt FROM Remont WHERE id_comp=" & frmComputers.sCOUNT & " ORDER BY date DESC, id DESC"



        rs3 = New ADODB.Recordset
        rs3.Open(sSQL3, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        If MtchWord = 1 And MtchCase = 1 Then
            mde = 3
        Else
            If MtchWord = 1 And MtchCase = 0 Then
                mde = 2
            Else
                If MtchCase = 1 And MtchWord = 0 Then
                    mde = 1
                Else
                    If MtchCase = 0 And MtchWord = 0 Then
                        mde = 0
                    End If
                End If
            End If
        End If

        Dim intCount As Integer
        intCount = 0
        With rs3
            .MoveFirst()
            Do While Not .EOF
                FirstColumn = True
                FINDTXT = ""


                For lngCounter = 0 To 8

                    If FirstColumn Then

                        If Not IsDBNull(.Fields(lngCounter).Value) Then If isThere(.Fields(lngCounter).Value, sFindText, mde) = True Then GoTo FoundiR

                    Else

                    End If                  'TO KEEP DATA FROM SHIFTING LEFT

                Next

FoundiR:
                If Len(FINDTXT) = 0 Then

                Else


                    lvRem.Items.Add(.Fields(0).Value) 'col no. 1

                    'tID = .Fields(0).Value

                    If Not IsDBNull(.Fields("NomerRemKomp").Value) Then
                        lvRem.Items(CInt(intCount)).SubItems.Add(.Fields("NomerRemKomp").Value)
                    Else
                        lvRem.Items(CInt(intCount)).SubItems.Add("")
                    End If

                    If Not IsDBNull(.Fields("Date").Value) Then
                        lvRem.Items(CInt(intCount)).SubItems.Add(.Fields("Date").Value)
                    Else
                        lvRem.Items(CInt(intCount)).SubItems.Add("")
                    End If

                    If Not IsDBNull(.Fields("Remont").Value) Then
                        lvRem.Items(CInt(intCount)).SubItems.Add(.Fields("Remont").Value)
                    Else
                        lvRem.Items(CInt(intCount)).SubItems.Add("")
                    End If

                    If Not IsDBNull(.Fields("Uroven").Value) Then
                        lvRem.Items(CInt(intCount)).SubItems.Add(.Fields("Uroven").Value)
                    Else
                        lvRem.Items(CInt(intCount)).SubItems.Add("")
                    End If

                    If Not IsDBNull(.Fields("Master").Value) Then
                        lvRem.Items(CInt(intCount)).SubItems.Add(.Fields("Master").Value)
                    Else
                        lvRem.Items(CInt(intCount)).SubItems.Add("")
                    End If

                    If Not IsDBNull(.Fields("vip").Value) Then
                        lvRem.Items(CInt(intCount)).SubItems.Add(.Fields("vip").Value)
                    Else
                        lvRem.Items(CInt(intCount)).SubItems.Add("")
                    End If

                    If Not IsDBNull(.Fields("UserName").Value) Then
                        lvRem.Items(CInt(intCount)).SubItems.Add(.Fields("UserName").Value)
                    Else
                        lvRem.Items(CInt(intCount)).SubItems.Add("")
                    End If
                    intCount = intCount + 1

                End If

                .MoveNext()
            Loop
        End With
        rs3.Close()
        rs3 = Nothing

        'txtSearch.Text = ""

        Exit Sub
Error_:


    End Sub



    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown

        Select Case e.KeyCode

            Case Keys.Enter

                search_ = True
                Search2(txtSearch.Text)
                FINDTXT_ = txtSearch.Text

        End Select



    End Sub

    Private Sub btnSBTAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSBTAdd.Click
        On Error GoTo err_1

        If lvRem.Items.Count = 0 Then Exit Sub
        If r1COUNT = 0 Then Exit Sub


        ZaiavkR = False

        Dim d() As String

        d = Split(lstGroups.SelectedNode.Tag, "|")
        frmComputers.sPREF = d(0)
        frmComputers.sCOUNT = d(1)

        If Len(frmComputers.sCOUNT) = 0 Then Exit Sub


        frmservice_add_otvets.cmbMaster.Text = ""
        frmservice_add_otvets.txtOtzyv.Text = ""
        frmservice_add_otvets.cmbMaster.Text = ""
        frmservice_add_otvets.dtPic.Value = Date.Today
        frmservice_add_otvets.cmbStat.Text = ""
        frmservice_add_otvets.cmbOtv.Text = ""
        frmservice_add_otvets.cmbKrit.Text = ""
        frmservice_add_otvets.cmbMaster.Text = ""
        frmservice_add_otvets.cmbTip.Text = "Base"


        frmservice_add_otvets.ShowDialog(Me)

        Exit Sub
err_1:
        MsgBox(Err.Description, MsgBoxStyle.Information, ProGramName)


    End Sub

    Private Sub lvRem2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)

        If lvRem2.Items.Count = 0 Then Exit Sub

        Dim z As Integer

        For z = 0 To lvRem2.SelectedItems.Count - 1
            rCOUNT = (lvRem2.SelectedItems(z).Text)
        Next

        ZaiavkR = True

        Dim rs As ADODB.Recordset
        rs = New ADODB.Recordset
        rs.Open("SELECT * FROM remonty_plus WHERE id=" & rCOUNT, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            .MoveFirst()
            Do While Not .EOF

                'If Not IsNull(.Fields("otzyv")) Then service_add_otvets.Text1.Text = .Fields("otzyv") 'Отзыв
                frmservice_add_otvets.txtOtzyv.Text = .Fields("otzyv").Value
                'If Not IsNull(.Fields("Name")) Then service_add_otvets.Combo1.Text = .Fields("Name") 'Мастер
                frmservice_add_otvets.cmbMaster.Text = .Fields("Master").Value
                'If Not IsNull(.Fields("Data")) Then service_add_otvets.DTPicker1.Value = .Fields("Data") 'Дата регистрации
                frmservice_add_otvets.dtPic.Value = .Fields("Data").Value
                r1COUNT = .Fields("id_rem").Value
                .MoveNext()
                'DoEvents
            Loop
        End With

        rs.Close()
        rs = Nothing


        Dim rs1 As ADODB.Recordset
        rs1 = New ADODB.Recordset

        rs1.Open("SELECT * FROM Remont WHERE id=" & r1COUNT, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs1
            .MoveFirst()
            Do While Not .EOF

                If .Fields("zakryt").Value = 0 Or .Fields("zakryt").Value = False Then

                    frmservice_add_otvets.chcClose.Checked = False

                Else
                    frmservice_add_otvets.chcClose.Checked = True

                End If

                .MoveNext()
            Loop
        End With

        rs1.Close()
        rs1 = Nothing


        frmservice_add_otvets.ShowDialog(Me)



    End Sub

    Private Sub btnRemDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemDel.Click

        If lvRem.Items.Count = 0 Then Exit Sub

        Dim z As Integer

        For z = 0 To lvRem.SelectedItems.Count - 1
            r1COUNT = (lvRem.SelectedItems(z).Text)
        Next

        Dim unamZ As String

        If frmComputers.sPREF = "C" Then

            Dim rs2 As ADODB.Recordset
            rs2 = New ADODB.Recordset
            rs2.Open("SELECT * FROM kompy WHERE id=" & frmComputers.sCOUNT, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

            With rs2
                unamZ = .Fields("filial").Value & "/" & .Fields("mesto").Value
            End With
            rs2.Close()
            rs2 = Nothing

        End If

        Dim LNGIniFile As New IniFile(sLANGPATH)
        Dim rs1 As ADODB.Recordset

        rs1 = New ADODB.Recordset

        rs1.Open("Delete FROM remonty_plus WHERE id_rem=" & r1COUNT, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        rs1 = Nothing

        rs1 = New ADODB.Recordset

        rs1.Open("Delete FROM Remont WHERE id=" & r1COUNT, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        rs1 = Nothing


        Call SaveActivityToLogDB(LNGIniFile.GetString("frmserviceDesc", "MSG7", "") & " " & lstGroups.SelectedNode.Text & " " & LNGIniFile.GetString("frmserviceDesc", "MSG8", "") & unamZ)

        Call Me.LOAD_REPAIR(frmComputers.sCOUNT, Me.lvRem)

        Call REM_CHECK()

    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        On Error GoTo err_
        Select Case CheckBox2.Checked

            Case True

                LOAD_REPAIR2(Me.lvRem)

            Case False

                LOAD_REPAIR(frmComputers.sCOUNT, Me.lvRem)

        End Select

        Exit Sub
err_:

    End Sub

    Private Sub lvRem_ItemMouseHover(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemMouseHoverEventArgs) Handles lvRem.ItemMouseHover
        Dim stext As String
        stext = e.Item.SubItems(2).Text & vbCrLf & e.Item.SubItems(5).Text & vbCrLf & vbCrLf & e.Item.SubItems(3).Text & vbCrLf & vbCrLf & e.Item.SubItems(6).Text

        ToolTip1.ToolTipTitle = ProGramName

        If e.Item.SubItems(3).Text Is Nothing Then


        Else

            ToolTip1.SetToolTip(lvRem, WordWrap(stext))

        End If
    End Sub

    Friend Function WordWrap(ByVal MessageText As String) As String
        Dim Words() As String = Split(MessageText, " ")

        Dim LineLen As Integer
        WordWrap = ""

        For i As Integer = 0 To Words.Length - 1
            WordWrap &= Words(i) & " "
            LineLen += (Words(i).Length + 1)

            ' Add a wrap if adding next word overflows
            If i < Words.Length - 1 Then

                If LineLen + Words(i + 1).Length >= 40 Then
                    WordWrap &= vbCrLf
                    LineLen = 0
                End If
            End If
        Next
        Return WordWrap

    End Function

    Private Sub lvRem_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvRem.MouseMove
        If lvRem.GetItemAt(e.X, e.Y) Is Nothing Then
            ToolTip1.RemoveAll()
        End If
    End Sub

    Private Sub lvRem2_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvRem2.ColumnClick
        Dim new_sorting_column As ColumnHeader = _
    lvRem2.Columns(e.Column)
        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            sort_order = SortOrder.Ascending
        Else
            If new_sorting_column.Equals(m_SortingColumn) Then
                If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                sort_order = SortOrder.Ascending
            End If

            m_SortingColumn.Text = m_SortingColumn.Text.Substring(2)
        End If

        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "> " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "< " & m_SortingColumn.Text
        End If

        lvRem2.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)

        lvRem2.Sort()
    End Sub

    Private Sub btnSendEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendEmail.Click

        If lvRem.Items.Count = 0 Then Exit Sub

        Dim z As Integer

        For z = 0 To lvRem.SelectedItems.Count - 1
            r1COUNT = (lvRem.SelectedItems(z).Text)
        Next


        If r1COUNT = 0 Then Exit Sub

        Call REMONT_SEND_MASTER(r1COUNT)



    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If lvRem.Items.Count = 0 Then Exit Sub

        Dim z As Integer

        For z = 0 To lvRem.SelectedItems.Count - 1
            r1COUNT = (lvRem.SelectedItems(z).Text)
        Next


        Call SRASP(r1COUNT)


    End Sub

    Private Sub lstGroups_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles lstGroups.NodeMouseClick

        '#############################################
        'Выделение по правому клику мышкой
        '#############################################

        If e.Button = Windows.Forms.MouseButtons.Right Then
            Me.lstGroups.SelectedNode = e.Node
        End If

    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

    End Sub

    Private Sub treebranche_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles treebranche.SelectedIndexChanged
        Dim objIniFile As New IniFile(PrPath & "base.ini")
        objIniFile.WriteString("General", "branche", treebranche.Text)

        Dim newThread5 As New Thread(AddressOf R_T_LOAD)
        newThread5.Start()

    End Sub

    Private Sub btn_Z_to_Office_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Z_to_Office.Click
        If lvRem.Items.Count = 0 Then Exit Sub

        Dim z As Integer

        For z = 0 To lvRem.SelectedItems.Count - 1
            r1COUNT = (lvRem.SelectedItems(z).Text)
        Next


        Call SRASP2(r1COUNT)
    End Sub

    Private Sub lvRem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvRem.SelectedIndexChanged

    End Sub
End Class