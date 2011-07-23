Public Class frmDirectory
    Private m_SortingColumn As ColumnHeader
    Private dSID As Integer
    Private eDTI As Boolean
    Private sREALNAME As String

    'Public Shared Function GetUser(ByVal UserName As String, ByVal Password As String) As directoryEntry

    'End Function


    Private Sub TreeDirectoryFill()
        Dim objIniFile As New IniFile(sLANGPATH)

        tvDirectory.ImageList = Me.ilsCommands

        Dim nodeRoot As New TreeNode(objIniFile.GetString("frmDirectory", "MSG1", ""), 0, 0)
        nodeRoot.Tag = "ROOT" & GENID()

        tvDirectory.Nodes.Add(nodeRoot)
        '#############################################################
        'Создаем группу в дереве
        Dim TempNode As New TreeNode(objIniFile.GetString("frmDirectory", "MSG2", ""), 1, 1)
        TempNode.Tag = "G|" & GENID()
        nodeRoot.Nodes.Add(TempNode)

        Dim TEHNode1 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG3", ""), 2, 2) '--------------VIP_Graff Обновлен------------------
        TEHNode1.Tag = "C|" & GENID()
        TempNode.Nodes.Add(TEHNode1)

        Dim TEHNode2 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG4", ""), 3, 3)
        TEHNode2.Tag = "C|" & GENID()
        TempNode.Nodes.Add(TEHNode2)

        Dim TEHNode3 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG5", ""), 4, 4)
        TEHNode3.Tag = "C|" & GENID()
        TempNode.Nodes.Add(TEHNode3)

        Dim TEHNode4 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG6", ""), 5, 5) '--------------VIP_Graff Обновлен------------------
        TEHNode4.Tag = "C|" & GENID()
        TempNode.Nodes.Add(TEHNode4)

        Dim TEHNode5 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG7", ""), 6, 6)
        TEHNode5.Tag = "C|" & GENID()
        TempNode.Nodes.Add(TEHNode5)

        Dim TEHNode6 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG8", ""), 7, 7)
        TEHNode6.Tag = "C|" & GENID()
        TempNode.Nodes.Add(TEHNode6)

        Dim TEHNode8 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG9", ""), 8, 8)
        TEHNode8.Tag = "C|" & GENID()
        TempNode.Nodes.Add(TEHNode8)

        Dim TEHNode9 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG10", ""), 9, 9)
        TEHNode9.Tag = "C|" & GENID()
        TempNode.Nodes.Add(TEHNode9)

        Dim TEHNode10 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG11", ""), 10, 10)
        TEHNode10.Tag = "C|" & GENID()
        TempNode.Nodes.Add(TEHNode10)

        Dim TEHNode11 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG12", ""), 11, 11)
        TEHNode11.Tag = "C|" & GENID()
        TempNode.Nodes.Add(TEHNode11)

        Dim TEHNode12 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG13", ""), 12, 12) '--------------VIP_Graff Обновлен------------------
        TEHNode12.Tag = "C|" & GENID()
        TempNode.Nodes.Add(TEHNode12)

        Dim TEHNode13 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG14", ""), 13, 13) '--------------VIP_Graff Обновлен------------------
        TEHNode13.Tag = "C|" & GENID()
        TempNode.Nodes.Add(TEHNode13)

        Dim TEHNode14 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG15", ""), 14, 14)
        TEHNode14.Tag = "C|" & GENID()
        TempNode.Nodes.Add(TEHNode14)

        Dim TEHNode15 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG16", ""), 15, 15) '(4,4)
        TEHNode15.Tag = "C|" & GENID()
        TempNode.Nodes.Add(TEHNode15)

        Dim TEHNode16 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG17", ""), 16, 16) '--------------VIP_Graff Обновлен------------------
        TEHNode16.Tag = "C|" & GENID()
        TempNode.Nodes.Add(TEHNode16)

        Dim TEHNode17 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG18", ""), 17, 17)
        TEHNode17.Tag = "C|" & GENID()
        TempNode.Nodes.Add(TEHNode17)
        '#############################################################
        'Создаем группу в дереве
        Dim TempNode2 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG19", ""), 18, 18)
        TempNode2.Tag = "G|" & GENID()
        nodeRoot.Nodes.Add(TempNode2)

        Dim TEHNode18 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG20", ""), 19, 19)
        TEHNode18.Tag = "C|" & GENID()
        TempNode2.Nodes.Add(TEHNode18)

        Dim TEHNode19 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG21", ""), 20, 20)
        TEHNode19.Tag = "C|" & GENID()
        TempNode2.Nodes.Add(TEHNode19)

        Dim TEHNode20 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG22", ""), 21, 21)
        TEHNode20.Tag = "C|" & GENID()
        TempNode2.Nodes.Add(TEHNode20)

        Dim TEHNode21 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG23", ""), 22, 22)
        TEHNode21.Tag = "C|" & GENID()
        TempNode2.Nodes.Add(TEHNode21)

        Dim TEHNode27 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG24", ""), 23, 23)
        TEHNode27.Tag = "C|" & GENID()
        TempNode2.Nodes.Add(TEHNode27)

        Dim TEHNode22 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG25", ""), 24, 24)
        TEHNode22.Tag = "C|" & GENID()
        TempNode2.Nodes.Add(TEHNode22)

        Dim TEHNode23 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG26", ""), 25, 25)
        TEHNode23.Tag = "C|" & GENID()
        TempNode2.Nodes.Add(TEHNode23)

        'Добавляем узлы
        Dim TEHNode As New TreeNode(objIniFile.GetString("frmDirectory", "MSG27", ""), 26, 26)
        TEHNode.Tag = "C|" & GENID()
        TempNode2.Nodes.Add(TEHNode)

        Dim TEHNode24 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG28", ""), 27, 27)
        TEHNode24.Tag = "C|" & GENID()
        TempNode2.Nodes.Add(TEHNode24)

        Dim TEHNode25 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG29", ""), 28, 28)
        TEHNode25.Tag = "C|" & GENID()
        TempNode2.Nodes.Add(TEHNode25)

        Dim TEHNode26 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG30", ""), 29, 29)
        TEHNode26.Tag = "C|" & GENID()
        TempNode2.Nodes.Add(TEHNode26)

        '#############################################################
        Dim TEHNode44 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG31", ""), 30, 30)
        TEHNode44.Tag = "C|" & GENID()
        TempNode2.Nodes.Add(TEHNode44)

        Dim TEHNode48 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG33", ""), 31, 31)
        TEHNode48.Tag = "C|" & GENID()
        TempNode2.Nodes.Add(TEHNode48)

        Dim TEHNode7 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG34", ""), 32, 32)
        TEHNode7.Tag = "C|" & GENID()
        TempNode2.Nodes.Add(TEHNode7)


        '#############################################################

        'Создаем группу в дереве
        Dim TempNode3 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG35", ""), 33, 33)
        TempNode3.Tag = "G|" & GENID()
        nodeRoot.Nodes.Add(TempNode3)

        Dim TEHNode28 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG36", ""), 34, 34)
        TEHNode28.Tag = "C|" & GENID()
        TempNode3.Nodes.Add(TEHNode28)

        Dim TEHNode29 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG37", ""), 35, 35)
        TEHNode29.Tag = "C|" & GENID()
        TempNode3.Nodes.Add(TEHNode29)

        'Пользователь - экспереминтально
        Dim TEHNode57 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG57", ""), 36, 36)
        TEHNode57.Tag = "C|" & GENID()
        TempNode3.Nodes.Add(TEHNode57)


        'Создаем группу в дереве
        Dim TempNode4 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG38", ""), 37, 37)
        TempNode4.Tag = "G|" & GENID()
        nodeRoot.Nodes.Add(TempNode4)

        Dim TEHNode30 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG39", ""), 38, 38)
        TEHNode30.Tag = "C|" & GENID()
        TempNode4.Nodes.Add(TEHNode30)

        Dim TEHNode31 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG40", ""), 39, 39)
        TEHNode31.Tag = "C|" & GENID()
        TempNode4.Nodes.Add(TEHNode31)

        Dim TEHNode32 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG41", ""), 40, 40)
        TEHNode32.Tag = "C|" & GENID()
        TempNode4.Nodes.Add(TEHNode32)

        '#############################################################
        'Создаем группу в дереве
        Dim TempNode5 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG42", ""), 41, 41)
        TempNode5.Tag = "G|" & GENID()
        nodeRoot.Nodes.Add(TempNode5)

        Dim TEHNode33 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG43", ""), 42, 42)
        TEHNode33.Tag = "C|" & GENID()
        TempNode5.Nodes.Add(TEHNode33)

        Dim TEHNode34 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG44", ""), 43, 43)
        TEHNode34.Tag = "C|" & GENID()
        TempNode5.Nodes.Add(TEHNode34)

        Dim TEHNode35 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG45", ""), 44, 44)
        TEHNode35.Tag = "C|" & GENID()
        TempNode5.Nodes.Add(TEHNode35)

        '#############################################################
        'Создаем группу в дереве
        Dim TempNode6 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG46", ""), 45, 45)
        TempNode6.Tag = "G|" & GENID()
        nodeRoot.Nodes.Add(TempNode6)

        Dim TEHNode36 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG47", ""), 46, 46)
        TEHNode36.Tag = "C|" & GENID()
        TempNode6.Nodes.Add(TEHNode36)

        Dim TEHNode37 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG48", ""), 47, 47)
        TEHNode37.Tag = "C|" & GENID()
        TempNode6.Nodes.Add(TEHNode37)

        Dim TEHNode38 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG49", ""), 48, 48)
        TEHNode38.Tag = "C|" & GENID()
        TempNode6.Nodes.Add(TEHNode38)

        Dim TEHNode39 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG50", ""), 49, 49)
        TEHNode39.Tag = "C|" & GENID()
        TempNode6.Nodes.Add(TEHNode39)

        Dim TEHNode40 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG51", ""), 50, 50)
        TEHNode40.Tag = "C|" & GENID()
        TempNode6.Nodes.Add(TEHNode40)

        Dim TEHNode47 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG52", ""), 51, 51)
        TEHNode47.Tag = "C|" & GENID()
        TempNode6.Nodes.Add(TEHNode47)

        Dim TEHNode41 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG53", ""), 52, 52)
        TEHNode41.Tag = "C|" & GENID()
        TempNode6.Nodes.Add(TEHNode41)

        Dim TEHNode42 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG54", ""), 53, 53)
        TEHNode42.Tag = "C|" & GENID()
        TempNode6.Nodes.Add(TEHNode42)

        Dim TEHNode43 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG55", ""), 54, 54)
        TEHNode43.Tag = "C|" & GENID()
        TempNode6.Nodes.Add(TEHNode43)

        Dim TEHNode46 As New TreeNode(objIniFile.GetString("frmDirectory", "MSG56", ""), 55, 55)
        TEHNode46.Tag = "C|" & GENID()
        TempNode6.Nodes.Add(TEHNode46)

        tvDirectory.SelectedNode = nodeRoot
        Dim tNode As New TreeNode
        tNode = tvDirectory.Nodes(0)
        tNode.Expand()

    End Sub

    Private Sub frmDirectory_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        frmMain.SaveInfTehButton.Enabled = False
        frmMain.ToolStripDropDownButton1.Enabled = False

    End Sub

    Private Sub frmDirectory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        SendFonts(Me)

        Call frmDirectory_Lang()

        Me.TreeDirectoryFill()



    End Sub

    Private Sub tvDirectory_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvDirectory.AfterSelect
        lvDirectory.ListViewItemSorter = Nothing

        Call LOAD_LIST_SPR()
        ResList(Me.lvDirectory)
    End Sub

    Private Sub LOAD_LIST_SPR()
        On Error GoTo err_
        chkCont.Visible = False

        eDTI = False
        Dim objIniFile As New IniFile(sLANGPATH)


        Dim d() As String
        d = Split(tvDirectory.SelectedNode.Tag, "|")

        If d(0) = "G" Then Exit Sub



        btnDirAdd.Text = objIniFile.GetString("frmDirectory", "btnDirAdd", "")
        cmbName.Items.Clear()
        cmbName2.Items.Clear()
        cmbName3.Items.Clear()
        cmb1.Items.Clear()
        cmb2.Items.Clear()
        cmb1.Text = ""
        cmb2.Text = ""
        cmbName.Text = ""
        cmbName2.Text = ""
        cmbName3.Text = ""
        txtMemo.Text = ""
        Label3.Text = objIniFile.GetString("frmDirectory", "Label3", "")
        Label1.Text = objIniFile.GetString("frmDirectory", "Label2", "")

        Me.lvDirectory.Columns.Clear()
        Me.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "lvDirectory1", ""), 1, HorizontalAlignment.Left)
        Me.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "lvDirectory2", ""), 300, HorizontalAlignment.Left)
        Me.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "lvDirectory3", ""), 300, HorizontalAlignment.Left)

        FillComboNET(Me.cmbName3, "PROIZV", "SPR_PROIZV", "", False, True)

        lbl1.Visible = False
        gb1.Visible = False
        gb2.Visible = False
        gbOther.Visible = False
        cmbName2.Visible = False
        Label2.Visible = False
        txtName.Visible = False
        Label3.Visible = True
        txtName.Visible = False
        cmbName3.Visible = True
        chkVisibleSTR.Visible = False
        cmbName.Visible = True
        Label1.Visible = True

        lvDirectory.Items.Clear()

        Dim sSQL As String

        Select Case tvDirectory.SelectedNode.Text

            Case objIniFile.GetString("frmDirectory", "MSG57", "")
                '#######################################
                'Пользователь экспериментально
                '#######################################

                Label3.Visible = False
                txtName.Visible = False
                cmbName3.Visible = False
                gb1.Visible = False
                gb2.Visible = False

                Me.lvDirectory.Columns.Clear()
                Me.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "lvDirectory1", ""), 1, HorizontalAlignment.Left)
                Me.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "lvDirectory2", ""), 300, HorizontalAlignment.Left)
                Me.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "lvDirectory4", ""), 300, HorizontalAlignment.Left)

                sSQL = "SELECT id, name, A from SPR_USER ORDER BY NAME"

                cmbName2.Visible = True
                Label2.Visible = True
                cmbName3.Visible = False
                Label3.Visible = False

                Label1.Text = "Имя пользователя"
                Label2.Text = "ФИО"



            Case objIniFile.GetString("frmDirectory", "MSG27", "")


                sSQL = "SELECT SPR_OPTICAL.Id, SPR_OPTICAL.Name, SPR_PROIZV.PROIZV FROM SPR_PROIZV INNER JOIN SPR_OPTICAL ON (SPR_PROIZV.iD = SPR_OPTICAL.Proizv) AND (SPR_PROIZV.iD = SPR_OPTICAL.Proizv) WHERE ((SPR_OPTICAL.Proizv=SPR_PROIZV.iD)) ORDER BY NAME"


                lbl1.Visible = True
                gb1.Visible = True
                gb2.Visible = True

                cmbName2.Visible = False
                Label2.Visible = False
                txtName.Visible = False

                cmb1.Items.Clear()
                gb1.Text = objIniFile.GetString("frmDirectory", "MSG98", "")
                For intj = 1 To 77
                    cmb1.Items.Add(intj & "x")
                Next
                lbl1.Text = objIniFile.GetString("frmDirectory", "MSG57", "")

                cmb2.Items.Clear()
                gb2.Text = objIniFile.GetString("frmDirectory", "MSG98", "")
                For intj = 1 To 77
                    cmb2.Items.Add(intj & "x")
                Next
                lbl2.Text = objIniFile.GetString("frmDirectory", "MSG58", "")

            Case objIniFile.GetString("frmDirectory", "MSG3", "")
                lbl1.Visible = True
                gb1.Visible = True
                gb1.Text = objIniFile.GetString("frmDirectory", "MSG59", "")

                For intj = 1 To 3
                    cmb1.Items.Add(intj & "x")
                Next
                lbl1.Text = objIniFile.GetString("frmDirectory", "MSG59", "")

                sSQL = "SELECT SPR_USB.Id, SPR_USB.Name, SPR_PROIZV.PROIZV FROM SPR_PROIZV INNER JOIN SPR_USB ON (SPR_PROIZV.id = SPR_USB.Proizv) AND (SPR_PROIZV.iD = SPR_USB.Proizv) WHERE ((SPR_USB.Proizv=SPR_PROIZV.iD)) ORDER BY NAME"

            Case objIniFile.GetString("frmDirectory", "MSG4", "")

                sSQL = "SELECT spr_zip.Id, spr_zip.NAME, SPR_PROIZV.PROIZV FROM SPR_PROIZV INNER JOIN spr_zip ON (SPR_PROIZV.id = spr_zip.Proizv) AND (SPR_PROIZV.iD = spr_zip.Proizv) WHERE ((spr_zip.Proizv=SPR_PROIZV.iD)) ORDER BY NAME"

            Case objIniFile.GetString("frmDirectory", "MSG5", "")
                lbl1.Visible = True
                gb1.Visible = True
                gb1.Text = objIniFile.GetString("frmDirectory", "MSG5", "")
                cmb1.Items.Add("2.0")
                cmb1.Items.Add("2.1")
                cmb1.Items.Add("5.0")
                cmb1.Items.Add("5.1")
                cmb1.Items.Add("6.1")
                cmb1.Items.Add("7.1")
                cmb1.Items.Add("8.1")

                lbl1.Text = objIniFile.GetString("frmDirectory", "MSG5", "")
                sSQL = "SELECT SPR_ASISTEM.Id, SPR_ASISTEM.Name, SPR_PROIZV.PROIZV FROM SPR_PROIZV INNER JOIN SPR_ASISTEM ON (SPR_PROIZV.id = SPR_ASISTEM.Proizv) AND (SPR_PROIZV.iD = SPR_ASISTEM.Proizv) WHERE ((SPR_ASISTEM.Proizv=SPR_PROIZV.iD)) ORDER BY NAME"

            Case objIniFile.GetString("frmDirectory", "MSG6", "")

                lbl1.Visible = True
                gb1.Visible = True
                gb1.Text = objIniFile.GetString("frmDirectory", "MSG60", "")
                lbl1.Text = objIniFile.GetString("frmDirectory", "MSG61", "")

                sSQL = "SELECT SPR_IBP.Id, SPR_IBP.Name, SPR_PROIZV.PROIZV FROM SPR_PROIZV INNER JOIN SPR_IBP ON (SPR_PROIZV.id = SPR_IBP.Proizv) AND (SPR_PROIZV.iD = SPR_IBP.Proizv) WHERE ((SPR_IBP.Proizv=SPR_PROIZV.iD)) ORDER BY NAME"

            Case objIniFile.GetString("frmDirectory", "MSG7", "")

                sSQL = "SELECT SPR_KEYBOARD.Id, SPR_KEYBOARD.Name, SPR_PROIZV.PROIZV FROM SPR_PROIZV INNER JOIN SPR_KEYBOARD ON (SPR_PROIZV.id = SPR_KEYBOARD.Proizv) AND (SPR_PROIZV.iD = SPR_KEYBOARD.Proizv) WHERE ((SPR_KEYBOARD.Proizv=SPR_PROIZV.iD)) ORDER BY NAME"

            Case objIniFile.GetString("frmDirectory", "MSG8", "")
                lbl1.Visible = True
                gb1.Visible = True
                cmb1.Items.Clear()
                gb1.Text = objIniFile.GetString("frmDirectory", "MSG62", "")
                For intj = 1 To 5
                    cmb1.Items.Add("A" & intj)
                Next
                lbl1.Text = objIniFile.GetString("frmDirectory", "MSG63", "")

                lbl2.Visible = True
                gb2.Visible = True
                cmb2.Items.Clear()
                gb2.Text = objIniFile.GetString("frmDirectory", "MSG64", "")

                FillComboNET(Me.cmb2, "name", "spr_cart", "", False, True)

                lbl2.Text = objIniFile.GetString("frmDirectory", "MSG64", "")

                sSQL = "SELECT SPR_KOPIR.Id, SPR_KOPIR.Name, SPR_PROIZV.PROIZV FROM SPR_PROIZV INNER JOIN SPR_KOPIR ON (SPR_PROIZV.iD = SPR_KOPIR.Proizv) AND (SPR_PROIZV.iD = SPR_KOPIR.Proizv) WHERE ((SPR_KOPIR.Proizv=SPR_PROIZV.iD)) ORDER BY NAME"

            Case objIniFile.GetString("frmDirectory", "MSG34", "")
                lbl1.Visible = True
                gb1.Visible = True
                gb1.Text = objIniFile.GetString("frmDirectory", "MSG65", "")
                lbl1.Text = objIniFile.GetString("frmDirectory", "MSG65", "")


                sSQL = "SELECT SPR_MODEM.Id, SPR_MODEM.Name, SPR_PROIZV.PROIZV FROM SPR_PROIZV INNER JOIN SPR_MODEM ON (SPR_PROIZV.id = SPR_MODEM.Proizv) AND (SPR_PROIZV.iD = SPR_MODEM.Proizv) WHERE ((SPR_MODEM.Proizv=SPR_PROIZV.iD)) ORDER BY NAME"

            Case objIniFile.GetString("frmDirectory", "MSG9", "")

                lbl1.Visible = True
                gb1.Visible = True
                gb1.Text = objIniFile.GetString("frmDirectory", "gb1", "")
                lbl1.Text = objIniFile.GetString("frmDirectory", "MSG66", "")
                cmb1.Items.Add("14 LCD")
                cmb1.Items.Add("15 LCD")
                cmb1.Items.Add("17 LCD")
                cmb1.Items.Add("19 LCD")
                cmb1.Items.Add("20 LCD")
                cmb1.Items.Add("21 LCD")
                cmb1.Items.Add("23 LCD")
                cmb1.Items.Add("25 LCD")
                cmb1.Items.Add("27 LCD")
                cmb1.Items.Add("14 CRT")
                cmb1.Items.Add("15 CRT")
                cmb1.Items.Add("17 CRT")
                cmb1.Items.Add("19 CRT")
                cmb1.Items.Add("20 CRT")
                cmb1.Items.Add("21 CRT")

                sSQL = "SELECT SPR_MONITOR.Id, SPR_MONITOR.Name, SPR_PROIZV.PROIZV FROM SPR_PROIZV INNER JOIN SPR_MONITOR ON (SPR_PROIZV.id = SPR_MONITOR.Proizv) AND (SPR_PROIZV.iD = SPR_MONITOR.Proizv) WHERE ((SPR_MONITOR.Proizv=SPR_PROIZV.iD)) ORDER BY NAME"

            Case objIniFile.GetString("frmDirectory", "MSG10", "")
                lbl1.Visible = True
                gb1.Visible = True
                cmb1.Items.Clear()
                gb1.Text = objIniFile.GetString("frmDirectory", "MSG62", "")
                For intj = 1 To 5
                    cmb1.Items.Add("A" & intj)
                Next
                lbl1.Text = objIniFile.GetString("frmDirectory", "MSG63", "")

                lbl2.Visible = True
                gb2.Visible = True
                cmb2.Items.Clear()
                gb2.Text = objIniFile.GetString("frmDirectory", "MSG64", "")

                FillComboNET(Me.cmb2, "name", "spr_cart", "", False, True)

                lbl2.Text = objIniFile.GetString("frmDirectory", "MSG64", "")

                sSQL = "SELECT SPR_MFU.Id, SPR_MFU.Name, SPR_PROIZV.PROIZV FROM SPR_PROIZV INNER JOIN SPR_MFU ON (SPR_PROIZV.iD = SPR_MFU.Proizv) AND (SPR_PROIZV.iD = SPR_MFU.Proizv) WHERE ((SPR_MFU.Proizv=SPR_PROIZV.iD)) ORDER BY NAME"

            Case objIniFile.GetString("frmDirectory", "MSG11", "")

                sSQL = "SELECT SPR_MOUSE.Id, SPR_MOUSE.Name, SPR_PROIZV.PROIZV FROM SPR_PROIZV INNER JOIN SPR_MOUSE ON (SPR_PROIZV.id = SPR_MOUSE.Proizv) AND (SPR_PROIZV.iD = SPR_MOUSE.Proizv) WHERE ((SPR_MOUSE.Proizv=SPR_PROIZV.iD)) ORDER BY NAME"

            Case objIniFile.GetString("frmDirectory", "MSG12", "")
                lbl1.Visible = True
                gb1.Visible = True
                cmb1.Items.Clear()
                gb1.Text = objIniFile.GetString("frmDirectory", "MSG62", "")
                For intj = 1 To 5
                    cmb1.Items.Add("A" & intj)
                Next
                lbl1.Text = objIniFile.GetString("frmDirectory", "MSG63", "")

                lbl2.Visible = True
                gb2.Visible = True
                cmb2.Items.Clear()
                gb2.Text = objIniFile.GetString("frmDirectory", "MSG64", "")

                FillComboNET(Me.cmb2, "name", "spr_cart", "", False, True)

                lbl2.Text = objIniFile.GetString("frmDirectory", "MSG64", "")

                sSQL = "SELECT SPR_PRINTER.Id, SPR_PRINTER.Name, SPR_PROIZV.PROIZV FROM SPR_PROIZV INNER JOIN SPR_PRINTER ON (SPR_PROIZV.id = SPR_PRINTER.Proizv) AND (SPR_PROIZV.iD = SPR_PRINTER.Proizv) WHERE ((SPR_PRINTER.Proizv=SPR_PROIZV.iD)) ORDER BY NAME"

            Case objIniFile.GetString("frmDirectory", "MSG13", "")

                sSQL = "SELECT SPR_FS.Id, SPR_FS.Name, SPR_PROIZV.PROIZV FROM SPR_PROIZV INNER JOIN SPR_FS ON (SPR_PROIZV.id = SPR_FS.Proizv) AND (SPR_PROIZV.iD = SPR_FS.Proizv) WHERE ((SPR_FS.Proizv=SPR_PROIZV.iD)) ORDER BY NAME"

            Case objIniFile.GetString("frmDirectory", "MSG14", "")
                gb1.Visible = True
                gb2.Visible = True
                gb1.Text = objIniFile.GetString("frmDirectory", "MSG67", "")
                lbl1.Text = ""
                gb2.Text = objIniFile.GetString("frmDirectory", "MSG68", "")
                lbl2.Text = ""
                FillComboNET(Me.cmb1, "name", "SPR_NET_DEV", "", False, True)

                sSQL = "SELECT SPR_DEV_NET.Id, SPR_DEV_NET.Name, SPR_PROIZV.PROIZV FROM SPR_PROIZV INNER JOIN SPR_DEV_NET ON (SPR_PROIZV.id = SPR_DEV_NET.Proizv) AND (SPR_PROIZV.iD = SPR_DEV_NET.Proizv) WHERE ((SPR_DEV_NET.Proizv=SPR_PROIZV.iD)) ORDER BY NAME"

            Case objIniFile.GetString("frmDirectory", "MSG15", "")
                gb1.Visible = True

                sSQL = "SELECT SPR_SCANER.Id, SPR_SCANER.Name, SPR_PROIZV.PROIZV FROM SPR_PROIZV INNER JOIN SPR_SCANER ON (SPR_PROIZV.id = SPR_SCANER.Proizv) AND (SPR_PROIZV.iD = SPR_SCANER.Proizv) WHERE ((SPR_SCANER.Proizv=SPR_PROIZV.iD)) ORDER BY NAME"

            Case objIniFile.GetString("frmDirectory", "MSG16", "")
                gb1.Visible = True
                sSQL = "SELECT spr_phone.Id, spr_phone.NAME, SPR_PROIZV.PROIZV FROM SPR_PROIZV INNER JOIN spr_phone ON (SPR_PROIZV.id = spr_phone.Proizv) AND (SPR_PROIZV.iD = spr_phone.Proizv) WHERE ((spr_phone.Proizv=SPR_PROIZV.iD)) ORDER BY NAME"

            Case objIniFile.GetString("frmDirectory", "MSG17", "")
                gb1.Visible = True
                sSQL = "SELECT spr_fax.Id, spr_fax.NAME, SPR_PROIZV.PROIZV FROM SPR_PROIZV INNER JOIN spr_fax ON (SPR_PROIZV.id = spr_fax.Proizv) AND (SPR_PROIZV.iD = spr_fax.Proizv) WHERE ((spr_fax.Proizv=SPR_PROIZV.iD)) ORDER BY NAME"

            Case objIniFile.GetString("frmDirectory", "MSG18", "")
                gb1.Visible = True
                gb2.Visible = True
                gb1.Text = objIniFile.GetString("frmDirectory", "MSG69", "")
                lbl1.Text = objIniFile.GetString("frmDirectory", "MSG70", "")
                gb2.Text = objIniFile.GetString("frmDirectory", "MSG71", "")
                lbl2.Text = objIniFile.GetString("frmDirectory", "MSG71", "")
                sSQL = "SELECT spr_photo.Id, spr_photo.NAME, SPR_PROIZV.PROIZV FROM SPR_PROIZV INNER JOIN spr_photo ON (SPR_PROIZV.id = spr_photo.Proizv) AND (SPR_PROIZV.iD = spr_photo.Proizv) WHERE ((spr_photo.Proizv=SPR_PROIZV.iD)) ORDER BY NAME"

            Case objIniFile.GetString("frmDirectory", "MSG20", "")
                lbl1.Visible = True
                gb1.Visible = True
                gb1.Text = objIniFile.GetString("frmDirectory", "MSG72", "")
                lbl1.Text = objIniFile.GetString("frmDirectory", "MSG73", "")


                sSQL = "SELECT SPR_SVGA.Id, SPR_SVGA.Name, SPR_PROIZV.PROIZV FROM SPR_PROIZV INNER JOIN SPR_SVGA ON (SPR_PROIZV.id = SPR_SVGA.Proizv) AND (SPR_PROIZV.iD = SPR_SVGA.Proizv) WHERE ((SPR_SVGA.Proizv=SPR_PROIZV.iD)) ORDER BY NAME"

            Case objIniFile.GetString("frmDirectory", "MSG21", "")
                lbl1.Visible = True
                gb1.Visible = True
                cmb1.Items.Add("3.5")
                cmb1.Items.Add("5.5")

                gb1.Text = objIniFile.GetString("frmDirectory", "MSG74", "")
                lbl1.Text = objIniFile.GetString("frmDirectory", "MSG75", "")

                sSQL = "SELECT SPR_FDD.Id, SPR_FDD.Name, SPR_PROIZV.PROIZV FROM SPR_PROIZV INNER JOIN SPR_FDD ON (SPR_PROIZV.id = SPR_FDD.Proizv) AND (SPR_PROIZV.iD = SPR_FDD.Proizv) WHERE ((SPR_FDD.Proizv=SPR_PROIZV.iD)) ORDER BY NAME"


            Case objIniFile.GetString("frmDirectory", "MSG22", "")
                lbl1.Visible = True
                gb1.Visible = True
                gb1.Text = objIniFile.GetString("frmDirectory", "MSG76", "")
                lbl1.Text = objIniFile.GetString("frmDirectory", "MSG77", "")

                sSQL = "SELECT SPR_HDD.Id, SPR_HDD.Name, SPR_PROIZV.PROIZV FROM SPR_PROIZV INNER JOIN SPR_HDD ON (SPR_PROIZV.id = SPR_HDD.Proizv) AND (SPR_PROIZV.iD = SPR_HDD.Proizv) WHERE ((SPR_HDD.Proizv=SPR_PROIZV.iD)) ORDER BY NAME"

            Case objIniFile.GetString("frmDirectory", "MSG23", "")
                lbl1.Visible = True
                gb1.Visible = True
                gb1.Text = objIniFile.GetString("frmDirectory", "MSG78", "")
                lbl1.Text = objIniFile.GetString("frmDirectory", "MSG79", "")
                sSQL = "SELECT SPR_SOUND.Id, SPR_SOUND.Name, SPR_PROIZV.PROIZV FROM SPR_PROIZV INNER JOIN SPR_SOUND ON (SPR_PROIZV.id = SPR_SOUND.Proizv) AND (SPR_PROIZV.iD = SPR_SOUND.Proizv) WHERE ((SPR_SOUND.Proizv=SPR_PROIZV.iD)) ORDER BY NAME"

            Case objIniFile.GetString("frmDirectory", "MSG24", "")
                lbl1.Visible = True
                gb1.Visible = True
                gb1.Text = objIniFile.GetString("frmDirectory", "MSG78", "")
                lbl1.Text = objIniFile.GetString("frmDirectory", "MSG79", "")
                sSQL = "SELECT SPR_CREADER.Id, SPR_CREADER.Name, SPR_PROIZV.PROIZV FROM SPR_PROIZV INNER JOIN SPR_CREADER ON (SPR_PROIZV.id = SPR_CREADER.Proizv) AND (SPR_PROIZV.iD = SPR_CREADER.Proizv) WHERE ((SPR_CREADER.Proizv=SPR_PROIZV.iD)) ORDER BY NAME"


            Case objIniFile.GetString("frmDirectory", "MSG25", "")
                lbl1.Visible = True
                gb1.Visible = True
                gb1.Text = objIniFile.GetString("frmDirectory", "MSG80", "")
                lbl1.Text = objIniFile.GetString("frmDirectory", "MSG81", "")

                sSQL = "SELECT SPR_MB.Id, SPR_MB.Name, SPR_PROIZV.PROIZV FROM SPR_PROIZV INNER JOIN SPR_MB ON (SPR_PROIZV.id = SPR_MB.Proizv) AND (SPR_PROIZV.iD = SPR_MB.Proizv) WHERE ((SPR_MB.Proizv=SPR_PROIZV.iD)) ORDER BY NAME"

            Case objIniFile.GetString("frmDirectory", "MSG26", "")
                lbl1.Visible = True
                gb1.Visible = True
                gb1.Text = objIniFile.GetString("frmDirectory", "MSG82", "")
                lbl1.Text = objIniFile.GetString("frmDirectory", "MSG83", "")
                sSQL = "SELECT SPR_RAM.Id, SPR_RAM.Name, SPR_PROIZV.PROIZV FROM SPR_PROIZV INNER JOIN SPR_RAM ON (SPR_PROIZV.id = SPR_RAM.Proizv) AND (SPR_PROIZV.iD = SPR_RAM.Proizv) WHERE ((SPR_RAM.Proizv=SPR_PROIZV.iD)) ORDER BY NAME"

            Case objIniFile.GetString("frmDirectory", "MSG28", "")
                lbl1.Visible = True
                gb1.Visible = True
                gb2.Visible = True

                cmbName2.Visible = False
                Label2.Visible = False
                txtName.Visible = False

                cmb1.Items.Clear()
                gb1.Text = objIniFile.GetString("frmDirectory", "MSG84", "")
                lbl1.Text = objIniFile.GetString("frmDirectory", "MSG85", "")

                cmb2.Items.Clear()
                gb2.Text = objIniFile.GetString("frmDirectory", "MSG86", "")
                lbl2.Text = objIniFile.GetString("frmDirectory", "MSG87", "")

                sSQL = "SELECT SPR_CPU.Id, SPR_CPU.Name, SPR_PROIZV.PROIZV FROM SPR_PROIZV INNER JOIN SPR_CPU ON (SPR_PROIZV.id = SPR_CPU.Proizv) AND (SPR_PROIZV.iD = SPR_CPU.Proizv) WHERE ((SPR_CPU.Proizv=SPR_PROIZV.iD)) ORDER BY NAME"


            Case objIniFile.GetString("frmDirectory", "MSG29", "")

                sSQL = "SELECT SPR_NET.Id, SPR_NET.Name, SPR_PROIZV.PROIZV FROM SPR_PROIZV INNER JOIN SPR_NET ON (SPR_PROIZV.id = SPR_NET.Proizv) AND (SPR_PROIZV.iD = SPR_NET.Proizv) WHERE ((SPR_NET.Proizv=SPR_PROIZV.iD)) ORDER BY NAME"

            Case objIniFile.GetString("frmDirectory", "MSG30", "")

                sSQL = "SELECT SPR_PCI.Id, SPR_PCI.Name, SPR_PROIZV.PROIZV FROM SPR_PROIZV INNER JOIN SPR_PCI ON (SPR_PROIZV.id = SPR_PCI.Proizv) AND (SPR_PROIZV.iD = SPR_PCI.Proizv) WHERE ((SPR_PCI.Proizv=SPR_PROIZV.iD)) ORDER BY NAME"

            Case objIniFile.GetString("frmDirectory", "MSG36", "")
                Label3.Visible = False
                txtName.Visible = False
                cmbName3.Visible = False
                cmbName2.Visible = True
                Label2.Visible = True
                Label2.Text = objIniFile.GetString("frmDirectory", "MSG88", "")

                gb1.Visible = True
                gb1.Text = objIniFile.GetString("frmDirectory", "MSG89", "")

                gb2.Visible = True
                gb2.Text = objIniFile.GetString("frmDirectory", "MSG90", "")

                Dim rs1 As ADODB.Recordset
                rs1 = New ADODB.Recordset
                rs1.Open("SELECT * FROM T_User", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                With rs1
                    .MoveFirst()
                    Do While Not .EOF
                        cmbName2.Items.Add(.Fields("name").Value)
                        .MoveNext()
                    Loop
                End With
                rs1.Close()
                rs1 = Nothing

                Me.lvDirectory.Columns.Clear()
                Me.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "lvDirectory1", ""), 1, HorizontalAlignment.Left)
                Me.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "lvDirectory2", ""), 300, HorizontalAlignment.Left)
                'Me.lotd.Columns.Add(("Производитель"), 300, HorizontalAlignment.Left)

                sSQL = "SELECT id, Name,A FROM SPR_Master ORDER BY NAME"

            Case objIniFile.GetString("frmDirectory", "MSG37", "")
                Label2.Visible = False
                cmbName2.Visible = False
                Label3.Visible = False
                txtName.Visible = False
                cmbName3.Visible = False
                gb1.Visible = False
                gb2.Visible = False

                Me.lvDirectory.Columns.Clear()
                Me.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "lvDirectory1", ""), 1, HorizontalAlignment.Left)
                Me.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "lvDirectory2", ""), 300, HorizontalAlignment.Left)

                sSQL = "SELECT id, Name FROM SPR_OTV ORDER BY NAME"

            Case objIniFile.GetString("frmDirectory", "MSG39", "")

                chkVisibleSTR.Visible = True
                Label3.Visible = False
                txtName.Visible = False
                cmbName3.Visible = False

                Me.lvDirectory.Columns.Clear()
                Me.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "lvDirectory1", ""), 1, HorizontalAlignment.Left)
                Me.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "lvDirectory2", ""), 300, HorizontalAlignment.Left)

                sSQL = "SELECT Id, filial FROM SPR_FILIAL ORDER BY filial"

            Case objIniFile.GetString("frmDirectory", "MSG40", "")
                Label1.Text = objIniFile.GetString("frmDirectory", "MSG39", "")

                chkVisibleSTR.Visible = True
                Label3.Text = objIniFile.GetString("frmDirectory", "MSG40", "")
                txtName.Visible = True
                cmbName3.Visible = False
                cmbName.Items.Clear()
                FillComboNET(Me.cmbName, "FILIAL", "SPR_FILIAL", "", False, True)

                Me.lvDirectory.Columns.Clear()
                Me.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "lvDirectory1", ""), 1, HorizontalAlignment.Left)
                Me.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "MSG39", ""), 300, HorizontalAlignment.Left)
                Me.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "MSG40", ""), 300, HorizontalAlignment.Left)

                sSQL = "SELECT id, filial, n_otd FROM SPR_OTD_FILIAL ORDER BY filial"

            Case objIniFile.GetString("frmDirectory", "MSG41", "")
                Label1.Text = objIniFile.GetString("frmDirectory", "MSG39", "")
                chkVisibleSTR.Visible = True
                Label3.Text = objIniFile.GetString("frmDirectory", "MSG41", "")
                Label2.Text = objIniFile.GetString("frmDirectory", "MSG40", "")
                Label2.Visible = True
                cmbName2.Visible = True
                txtName.Visible = True
                cmbName3.Visible = False
                cmbName.Items.Clear()

                FillComboNET(Me.cmbName, "FILIAL", "SPR_FILIAL", "", False, True)



                sSQL = "SELECT id, N_F, N_M, Name FROM SPR_KAB ORDER BY Name"

                Me.lvDirectory.Columns.Clear()
                Me.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "lvDirectory1", ""), 1, HorizontalAlignment.Left)
                Me.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "MSG39", ""), 250, HorizontalAlignment.Left)
                Me.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "MSG40", ""), 250, HorizontalAlignment.Left)
                Me.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "MSG41", ""), 250, HorizontalAlignment.Left)

            Case objIniFile.GetString("frmDirectory", "MSG43", "")
                Label2.Visible = False
                cmbName2.Visible = False
                Label3.Visible = False
                txtName.Visible = False
                cmbName3.Visible = False
                gb1.Visible = False
                gb2.Visible = False
                sSQL = "SELECT id, uroven  FROM SPR_Uroven order by uroven"
                Me.lvDirectory.Columns.Clear()
                Me.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "lvDirectory1", ""), 1, HorizontalAlignment.Left)
                Me.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "lvDirectory2", ""), 300, HorizontalAlignment.Left)

            Case objIniFile.GetString("frmDirectory", "MSG44", "")
                Label2.Visible = False
                cmbName2.Visible = False
                Label3.Visible = False
                txtName.Visible = False
                cmbName3.Visible = False
                gb1.Visible = False
                gb2.Visible = False
                sSQL = "SELECT id, name FROM spr_vip order by name"

                Me.lvDirectory.Columns.Clear()
                Me.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "lvDirectory1", ""), 1, HorizontalAlignment.Left)
                Me.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "lvDirectory2", ""), 300, HorizontalAlignment.Left)

            Case objIniFile.GetString("frmDirectory", "MSG45", "")
                Label2.Visible = False
                cmbName2.Visible = False
                Label3.Visible = False
                txtName.Visible = False
                cmbName3.Visible = False
                gb1.Visible = False
                gb2.Visible = False
                sSQL = "SELECT id, name FROM spr_tip_z order by name"

                Me.lvDirectory.Columns.Clear()
                Me.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "lvDirectory1", ""), 1, HorizontalAlignment.Left)
                Me.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "lvDirectory2", ""), 300, HorizontalAlignment.Left)

            Case objIniFile.GetString("frmDirectory", "MSG47", "")
                Label3.Visible = False
                txtName.Visible = False
                cmbName3.Visible = False

                sSQL = "SELECT id, Name FROM SPR_Postav ORDER BY Name"

                Me.lvDirectory.Columns.Clear()
                Me.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "lvDirectory1", ""), 1, HorizontalAlignment.Left)
                Me.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "lvDirectory2", ""), 300, HorizontalAlignment.Left)

            Case objIniFile.GetString("frmDirectory", "MSG48", "")
                cmbName3.Visible = False
                txtName.Visible = False
                Label3.Visible = False

                sSQL = "SELECT SPR_PROIZV.Id, SPR_PROIZV.PROIZV FROM SPR_PROIZV ORDER BY PROIZV"

                Me.lvDirectory.Columns.Clear()
                Me.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "lvDirectory1", ""), 1, HorizontalAlignment.Left)
                Me.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "lvDirectory2", ""), 300, HorizontalAlignment.Left)

            Case objIniFile.GetString("frmDirectory", "MSG49", "")
                Label2.Visible = False
                cmbName2.Visible = False
                Label3.Visible = False
                txtName.Visible = False
                cmbName3.Visible = False
                gb1.Visible = False
                gb2.Visible = False
                sSQL = "SELECT id, tip FROM SPR_TIP ORDER BY tip"

                Me.lvDirectory.Columns.Clear()
                Me.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "lvDirectory1", ""), 1, HorizontalAlignment.Left)
                Me.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "lvDirectory2", ""), 300, HorizontalAlignment.Left)

            Case objIniFile.GetString("frmDirectory", "MSG50", "")
                Label2.Visible = False
                cmbName2.Visible = False
                Label3.Visible = True
                txtName.Visible = False
                cmbName3.Visible = True
                gb1.Visible = True
                gb2.Visible = False
                cmb1.Items.Clear()
                gb1.Text = objIniFile.GetString("frmDirectory", "gb1", "")
                cmb1.Items.Add(objIniFile.GetString("frmDirectory", "MSG91", ""))
                cmb1.Items.Add(objIniFile.GetString("frmDirectory", "MSG92", ""))
                cmb1.Items.Add(objIniFile.GetString("frmDirectory", "MSG93", ""))
                cmb1.Items.Add(objIniFile.GetString("frmDirectory", "MSG94", ""))
                cmb1.Items.Add(objIniFile.GetString("frmDirectory", "MSG95", ""))
                cmb1.Items.Add(objIniFile.GetString("frmDirectory", "MSG96", ""))


                sSQL = "SELECT spr_cart.Id, spr_cart.Name, SPR_PROIZV.PROIZV FROM SPR_PROIZV INNER JOIN spr_cart ON (SPR_PROIZV.iD = spr_cart.Proizv) AND (SPR_PROIZV.iD = spr_cart.Proizv) WHERE ((spr_cart.Proizv=SPR_PROIZV.iD)) ORDER BY Name"

            Case objIniFile.GetString("frmDirectory", "MSG51", "")

                chkCont.Visible = True
                gbOther.Visible = True
                Dim intj As Decimal

                cmbIcon.Items.Clear()

                Select Case sICONS

                    Case "32*32"

                        For intj = 0 To frmComputers.ImageList1.Images.Count - 1
                            cmbIcon.Items.Add(intj)
                        Next

                    Case Else

                        For intj = 0 To frmComputers.ilsCommands.Images.Count - 1
                            cmbIcon.Items.Add(intj)
                        Next

                End Select


                

                Me.lvDirectory.Columns.Clear()
                Me.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "lvDirectory1", ""), 1, HorizontalAlignment.Left)
                Me.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "lvDirectory2", ""), 300, HorizontalAlignment.Left)

                'sSQL = "SELECT spr_other.Id, spr_other.Name, SPR_PROIZV.PROIZV FROM SPR_PROIZV INNER JOIN SPR_PCI ON (SPR_PROIZV.id = spr_other.Proizv) AND (SPR_PROIZV.iD = spr_other.Proizv) WHERE ((spr_other.Proizv=SPR_PROIZV.iD)) ORDER BY Name"
                sSQL = "SELECT Id, Name FROM spr_other"


            Case objIniFile.GetString("frmDirectory", "MSG52", "")
                lbl1.Visible = True
                gb1.Visible = True
                gb1.Text = objIniFile.GetString("frmDirectory", "gb1", "")
                lbl1.Text = objIniFile.GetString("frmDirectory", "gb1", "")

                FillComboNET(Me.cmb1, "Name", "spr_other", "", False, True)

                sSQL = "SELECT SPR_OTH_DEV.Id, SPR_OTH_DEV.Name, SPR_PROIZV.PROIZV FROM SPR_PROIZV INNER JOIN SPR_OTH_DEV ON (SPR_PROIZV.id = SPR_OTH_DEV.Proizv) AND (SPR_PROIZV.iD = SPR_OTH_DEV.Proizv) WHERE ((SPR_OTH_DEV.Proizv=SPR_PROIZV.iD)) ORDER BY NAME"


            Case objIniFile.GetString("frmDirectory", "MSG53", "")
                Label2.Visible = False
                cmbName2.Visible = False
                Label3.Visible = False
                txtName.Visible = False
                cmbName3.Visible = False
                gb1.Visible = False
                gb2.Visible = False

                sSQL = "SELECT SPR_LIC.Id, SPR_LIC.name FROM SPR_LIC ORDER BY Name"

                Me.lvDirectory.Columns.Clear()
                Me.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "lvDirectory1", ""), 1, HorizontalAlignment.Left)
                Me.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "lvDirectory2", ""), 300, HorizontalAlignment.Left)

            Case objIniFile.GetString("frmDirectory", "MSG54", "")
                Label2.Visible = False
                cmbName2.Visible = False
                Label3.Visible = False
                txtName.Visible = False
                cmbName3.Visible = False
                gb1.Visible = False
                gb2.Visible = False

                sSQL = "SELECT id, Name FROM SPR_TIP_PO order by Name"

                Me.lvDirectory.Columns.Clear()
                Me.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "lvDirectory1", ""), 1, HorizontalAlignment.Left)
                Me.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "lvDirectory2", ""), 300, HorizontalAlignment.Left)

            Case objIniFile.GetString("frmDirectory", "MSG55", "")
                Label2.Visible = False
                cmbName2.Visible = False
                Label3.Visible = False
                txtName.Visible = False
                cmbName3.Visible = False
                gb1.Visible = False
                gb2.Visible = False

                sSQL = "SELECT Id, Name FROM SPR_Complect ORDER BY Name"

                Me.lvDirectory.Columns.Clear()
                Me.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "lvDirectory1", ""), 1, HorizontalAlignment.Left)
                Me.lvDirectory.Columns.Add(objIniFile.GetString("frmDirectory", "lvDirectory2", ""), 300, HorizontalAlignment.Left)

            Case objIniFile.GetString("frmDirectory", "MSG56", "")
                cmbName2.Visible = True
                Label2.Visible = True
                Label2.Text = objIniFile.GetString("frmDirectory", "gb1", "")

                FillComboNET(Me.cmbName2, "Name", "SPR_TIP_PO", "", False, True)

                sSQL = "SELECT SPR_PO.Id, SPR_PO.Name, SPR_PROIZV.PROIZV FROM SPR_PROIZV INNER JOIN SPR_PO ON (SPR_PROIZV.id = SPR_PO.Proizv) AND (SPR_PROIZV.iD = SPR_PO.Proizv) WHERE ((SPR_PO.Proizv=SPR_PROIZV.iD)) ORDER BY NAME"


            Case objIniFile.GetString("frmDirectory", "MSG33", "")
                lbl1.Visible = True
                gb1.Visible = True
                gb1.Text = objIniFile.GetString("frmDirectory", "MSG78", "")
                lbl1.Text = objIniFile.GetString("frmDirectory", "MSG79", "")
                sSQL = "SELECT SPR_CASE.Id, SPR_CASE.Name, SPR_PROIZV.PROIZV FROM SPR_PROIZV INNER JOIN SPR_CASE ON (SPR_PROIZV.id = SPR_CASE.Proizv) AND (SPR_PROIZV.iD = SPR_CASE.Proizv) WHERE ((SPR_CASE.Proizv=SPR_PROIZV.iD)) ORDER BY NAME"

            Case objIniFile.GetString("frmDirectory", "MSG31", "")
                lbl1.Visible = True
                gb1.Visible = True
                gb1.Text = objIniFile.GetString("frmDirectory", "MSG78", "")
                lbl1.Text = objIniFile.GetString("frmDirectory", "MSG79", "")
                sSQL = "SELECT SPR_BP.Id, SPR_BP.Name, SPR_PROIZV.PROIZV FROM SPR_PROIZV INNER JOIN SPR_BP ON (SPR_PROIZV.id = SPR_BP.Proizv) AND (SPR_PROIZV.iD = SPR_BP.Proizv) WHERE ((SPR_BP.Proizv=SPR_PROIZV.iD)) ORDER BY NAME"



        End Select

        'sSQL = "SELECT id, Name FROM SPR_NET_DEV order by Name"

        If Len(sSQL) = 0 Then Exit Sub



        Dim rs As ADODB.Recordset
        rs = New ADODB.Recordset


        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        ' Dim intCount As Decimal = 0

        Dim FirstColumn As Boolean

        Do Until rs.EOF

            FirstColumn = True      'FIRST COLUMN IS A LISTITEM, REST ARE LISTSUBITEMS
            For lngCounter = 0 To rs.Fields.Count - 1

                If FirstColumn Then
                    If Not IsDBNull(rs.Fields(lngCounter).Value) Then
                        lvDirectory.Items.Add(rs.Fields(lngCounter).Value)
                    Else
                        lvDirectory.Items.Add("")  'NULL FIELDS NEED A BLANK ITEM
                    End If                  'TO KEEP DATA FROM SHIFTING LEFT
                    FirstColumn = False
                Else
                    If Not IsDBNull(rs.Fields(lngCounter).Value) Then
                        lvDirectory.Items(lvDirectory.Items.Count - 1).SubItems.Add(rs.Fields(lngCounter).Value)
                    Else
                        lvDirectory.Items(lvDirectory.Items.Count - 1).SubItems.Add("")
                    End If
                End If
            Next

            ' If Not IsMissing(Owner) Then Owner.pbrProgress.Value = (rs.AbsolutePosition / rs.RecordCount) * 100

            rs.MoveNext()
        Loop

        FirstColumn = False
        rs.Close()
        rs = Nothing





        Exit Sub
err_:
        MsgBox(Err.Description)

    End Sub

    Private Sub lvDirectory_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvDirectory.Click
        Call Load_SPR_TO_EDIT()
    End Sub

    Private Sub lvDirectory_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvDirectory.ColumnClick
        Dim new_sorting_column As ColumnHeader = _
      lvDirectory.Columns(e.Column)
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

        lvDirectory.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)

        lvDirectory.Sort()
    End Sub

    Private Sub lvDirectory_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvDirectory.DoubleClick

        Call Load_SPR_TO_EDIT()

    End Sub

    Private Sub Load_SPR_TO_EDIT()
        On Error Resume Next
        Dim objIniFile As New IniFile(sLANGPATH)

        eDTI = True

        cmb1.Text = ""
        cmb2.Text = ""
        cmbName.Text = ""
        cmbName2.Text = ""
        cmbName3.Text = ""
        txtMemo.Text = ""
        cmbIcon.Text = ""

        If lvDirectory.Items.Count = 0 Then Exit Sub

        Dim z As Integer

        For z = 0 To lvDirectory.SelectedItems.Count - 1
            dSID = (lvDirectory.SelectedItems(z).Text)
        Next

        Dim sSQL As String
        Dim rs As ADODB.Recordset

        Select Case tvDirectory.SelectedNode.Text
            

            Case objIniFile.GetString("frmDirectory", "MSG57", "")

                '######################################
                'Пользователи - экспериментально
                '######################################

                sSQL = "SELECT * FROM SPR_USER WHERE id =" & dSID



            Case objIniFile.GetString("frmDirectory", "MSG27", "")

                'SELECT * FROM SPR_OPTICAL INNER JOIN SPR_PROIZV ON SPR_OPTICAL.PROIZV = SPR_PROIZV.PROIZV AND ON SPR_OPTICAL.id =" & dSID

                sSQL = "SELECT * FROM SPR_OPTICAL WHERE id =" & dSID

            Case objIniFile.GetString("frmDirectory", "MSG3", "")

                sSQL = "SELECT * FROM SPR_USB WHERE id =" & dSID

            Case objIniFile.GetString("frmDirectory", "MSG4", "")

                sSQL = "SELECT * FROM spr_zip WHERE id =" & dSID

            Case objIniFile.GetString("frmDirectory", "MSG5", "")

                sSQL = "SELECT * FROM SPR_ASISTEM WHERE id =" & dSID

            Case objIniFile.GetString("frmDirectory", "MSG6", "")

                sSQL = "SELECT * FROM SPR_IBP WHERE id =" & dSID


            Case objIniFile.GetString("frmDirectory", "MSG7", "")

                sSQL = "SELECT * FROM SPR_KEYBOARD WHERE id =" & dSID

            Case objIniFile.GetString("frmDirectory", "MSG8", "")

                sSQL = "SELECT * FROM SPR_KOPIR WHERE id =" & dSID

            Case objIniFile.GetString("frmDirectory", "MSG34", "")

                sSQL = "SELECT * FROM SPR_MODEM WHERE id =" & dSID

            Case objIniFile.GetString("frmDirectory", "MSG9", "")

                sSQL = "SELECT * FROM SPR_MONITOR WHERE id =" & dSID

            Case objIniFile.GetString("frmDirectory", "MSG10", "")

                sSQL = "SELECT * FROM SPR_MFU WHERE id =" & dSID

            Case objIniFile.GetString("frmDirectory", "MSG11", "")

                sSQL = "SELECT * FROM SPR_MOUSE WHERE id =" & dSID

            Case objIniFile.GetString("frmDirectory", "MSG12", "")

                sSQL = "SELECT * FROM SPR_PRINTER WHERE id =" & dSID

            Case objIniFile.GetString("frmDirectory", "MSG13", "")

                sSQL = "SELECT * FROM SPR_FS WHERE id =" & dSID

            Case objIniFile.GetString("frmDirectory", "MSG14", "")

                sSQL = "SELECT * FROM SPR_DEV_NET WHERE id =" & dSID

            Case objIniFile.GetString("frmDirectory", "MSG15", "")

                sSQL = "SELECT * FROM SPR_SCANER WHERE id =" & dSID

            Case objIniFile.GetString("frmDirectory", "MSG16", "")

                sSQL = "SELECT * FROM spr_phone WHERE id =" & dSID

            Case objIniFile.GetString("frmDirectory", "MSG17", "")

                sSQL = "SELECT * FROM spr_fax WHERE id =" & dSID

            Case objIniFile.GetString("frmDirectory", "MSG18", "")

                sSQL = "SELECT * FROM spr_photo WHERE id =" & dSID

            Case objIniFile.GetString("frmDirectory", "MSG20", "")

                sSQL = "SELECT * FROM SPR_SVGA WHERE id =" & dSID

            Case objIniFile.GetString("frmDirectory", "MSG21", "")

                sSQL = "SELECT * FROM SPR_FDD WHERE id =" & dSID

            Case objIniFile.GetString("frmDirectory", "MSG22", "")

                sSQL = "SELECT * FROM SPR_HDD WHERE id =" & dSID

            Case objIniFile.GetString("frmDirectory", "MSG23", "")

                sSQL = "SELECT * FROM SPR_SOUND WHERE id =" & dSID


            Case objIniFile.GetString("frmDirectory", "MSG25", "")

                sSQL = "SELECT * FROM SPR_MB WHERE id =" & dSID

            Case objIniFile.GetString("frmDirectory", "MSG26", "")

                sSQL = "SELECT * FROM SPR_RAM WHERE id =" & dSID

            Case objIniFile.GetString("frmDirectory", "MSG28", "")

                sSQL = "SELECT * FROM SPR_CPU WHERE id =" & dSID

            Case objIniFile.GetString("frmDirectory", "MSG29", "")

                sSQL = "SELECT * FROM SPR_NET WHERE id =" & dSID

            Case objIniFile.GetString("frmDirectory", "MSG30", "")

                sSQL = "SELECT * FROM SPR_PCI WHERE id =" & dSID

            Case objIniFile.GetString("frmDirectory", "MSG36", "")

                sSQL = "SELECT * FROM SPR_Master WHERE id =" & dSID

            Case objIniFile.GetString("frmDirectory", "MSG37", "")

                sSQL = "SELECT * FROM SPR_OTV WHERE id =" & dSID

            Case objIniFile.GetString("frmDirectory", "MSG39", "")

                sSQL = "SELECT * FROM SPR_FILIAL WHERE id =" & dSID

                rs = New ADODB.Recordset
                rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                With rs

                    chkVisibleSTR.Checked = .Fields("ARHIV").Value

                    cmbName.Text = .Fields("FILIAL").Value

                    If Not IsDBNull(.Fields("A")) Then
                        cmb1.Text = .Fields("A").Value
                    End If

                    If Not IsDBNull(.Fields("B")) Then
                        cmb2.Text = .Fields("B").Value
                    End If

                    If Not IsDBNull(.Fields("prim")) Then
                        txtMemo.Text = .Fields("prim").Value
                    End If

                End With

                rs.Close()
                rs = Nothing

                sREALNAME = cmbName.Text
                btnDirAdd.Text = objIniFile.GetString("frmDirectory", "MSG97", "")

                Exit Sub


            Case objIniFile.GetString("frmDirectory", "MSG40", "")

                sSQL = "SELECT * FROM SPR_OTD_FILIAL WHERE id =" & dSID

                rs = New ADODB.Recordset
                rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                With rs

                    chkVisibleSTR.Checked = .Fields("ARHIV").Value

                    cmbName.Text = .Fields("Filial").Value
                    txtName.Text = .Fields("N_Otd").Value

                    If Not IsDBNull(.Fields("A")) Then
                        cmb1.Text = .Fields("A").Value
                    End If

                    If Not IsDBNull(.Fields("B")) Then
                        cmb2.Text = .Fields("B").Value
                    End If

                    If Not IsDBNull(.Fields("prim")) Then
                        txtMemo.Text = .Fields("prim").Value
                    End If

                End With

                rs.Close()
                rs = Nothing

                sREALNAME = txtName.Text
                btnDirAdd.Text = objIniFile.GetString("frmDirectory", "MSG97", "")
                Exit Sub


            Case objIniFile.GetString("frmDirectory", "MSG41", "")

                sSQL = "SELECT * FROM SPR_KAB WHERE id =" & dSID

                rs = New ADODB.Recordset
                rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                With rs

                    chkVisibleSTR.Checked = .Fields("ARHIV").Value

                    cmbName.Text = .Fields("N_F").Value
                    cmbName2.Text = .Fields("N_M").Value
                    txtName.Text = .Fields("Name").Value

                    If Not IsDBNull(.Fields("A")) Then
                        cmb1.Text = .Fields("A").Value
                    End If

                    If Not IsDBNull(.Fields("B")) Then
                        cmb2.Text = .Fields("B").Value
                    End If

                    If Not IsDBNull(.Fields("prim")) Then
                        txtMemo.Text = .Fields("prim").Value
                    End If

                End With

                rs.Close()
                rs = Nothing

                sREALNAME = txtName.Text
                btnDirAdd.Text = objIniFile.GetString("frmDirectory", "MSG97", "")

                Exit Sub

            Case objIniFile.GetString("frmDirectory", "MSG43", "")

                sSQL = "SELECT id, uroven as name, proizv, Prim, a, b, c FROM SPR_Uroven WHERE id =" & dSID

            Case objIniFile.GetString("frmDirectory", "MSG44", "")

                sSQL = "SELECT * FROM spr_vip WHERE id =" & dSID

            Case objIniFile.GetString("frmDirectory", "MSG45", "")

                sSQL = "SELECT * FROM spr_tip_z WHERE id =" & dSID

            Case objIniFile.GetString("frmDirectory", "MSG47", "")

                sSQL = "SELECT * FROM SPR_Postav WHERE id =" & dSID

            Case objIniFile.GetString("frmDirectory", "MSG48", "")

                sSQL = "SELECT * FROM SPR_PROIZV WHERE id =" & dSID

            Case objIniFile.GetString("frmDirectory", "MSG49", "")

                sSQL = "SELECT * FROM SPR_TIP WHERE id =" & dSID

            Case objIniFile.GetString("frmDirectory", "MSG50", "")

                sSQL = "SELECT * FROM spr_cart WHERE id =" & dSID

            Case objIniFile.GetString("frmDirectory", "MSG51", "")

                sSQL = "SELECT * FROM spr_other WHERE id =" & dSID

            Case objIniFile.GetString("frmDirectory", "MSG52", "")

                sSQL = "SELECT * FROM SPR_OTH_DEV WHERE id =" & dSID



            Case objIniFile.GetString("frmDirectory", "MSG53", "")

                sSQL = "SELECT * FROM SPR_LIC WHERE id =" & dSID

            Case objIniFile.GetString("frmDirectory", "MSG54", "")

                sSQL = "SELECT * FROM SPR_TIP_PO WHERE id =" & dSID

            Case objIniFile.GetString("frmDirectory", "MSG55", "")

                sSQL = "SELECT * FROM SPR_Complect WHERE id =" & dSID

            Case objIniFile.GetString("frmDirectory", "MSG56", "")

                sSQL = "SELECT * FROM SPR_PO WHERE id =" & dSID

            Case objIniFile.GetString("frmDirectory", "MSG33", "")

                sSQL = "SELECT * FROM SPR_CASE WHERE id =" & dSID

            Case objIniFile.GetString("frmDirectory", "MSG24", "")

                sSQL = "SELECT * FROM SPR_CREADER WHERE id =" & dSID

            Case objIniFile.GetString("frmDirectory", "MSG31", "")

                sSQL = "SELECT * FROM SPR_BP WHERE id =" & dSID

        End Select



        Dim uname As String

        Dim PROYZV As ADODB.Recordset
        PROYZV = New ADODB.Recordset


        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs

            If tvDirectory.SelectedNode.Text = objIniFile.GetString("frmDirectory", "MSG48", "") Then

                cmbName.Text = .Fields("PROIZV").Value
            Else
                cmbName.Text = .Fields("Name").Value

                If Not IsDBNull(.Fields("Proizv").Value) Then uname = .Fields("Proizv").Value
                PROYZV.Open("Select * from SPR_PROIZV WHERE id =" & uname, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                With PROYZV
                    If Not IsDBNull(.Fields("Proizv").Value) Then cmbName3.Text = .Fields("Proizv").Value
                End With

                PROYZV.Close()
                PROYZV = Nothing
            End If

            Select Case tvDirectory.SelectedNode.Text


                Case objIniFile.GetString("frmDirectory", "MSG36", "")

                    If Not IsDBNull(.Fields("A")) Then
                        cmbName2.Text = .Fields("A").Value
                        cmb1.Text = .Fields("B").Value
                    End If

                Case objIniFile.GetString("frmDirectory", "MSG51", "")

                    If Not IsDBNull(.Fields("A")) Then
                        cmbIcon.Text = .Fields("A").Value
                    End If


                Case objIniFile.GetString("frmDirectory", "MSG56", "")

                    If Not IsDBNull(.Fields("A")) Then
                        cmbName2.Text = .Fields("A").Value
                    End If

                Case objIniFile.GetString("frmDirectory", "MSG57", "")

                    If Not IsDBNull(.Fields("A")) Then
                        cmbName2.Text = .Fields("A").Value
                    End If


                Case Else

                    If Not IsDBNull(.Fields("A")) Then
                        cmb1.Text = .Fields("A").Value
                    End If
            End Select

            If tvDirectory.SelectedNode.Text = objIniFile.GetString("frmDirectory", "MSG36", "") Then

                If Not IsDBNull(.Fields("C")) Then
                    cmb2.Text = .Fields("C").Value
                End If

            Else
                If Not IsDBNull(.Fields("B")) Then
                    cmb2.Text = .Fields("B").Value
                End If
            End If


            If tvDirectory.SelectedNode.Text = objIniFile.GetString("frmDirectory", "MSG51", "") Then
                chkCont.Checked = False


                If Not IsDBNull(.Fields("C")) Then

                    Dim A1 As String = .Fields("C").Value


                    Select Case A1

                        Case "1"
                            chkCont.Checked = True

                        Case Else
                            chkCont.Checked = False

                    End Select

                End If

            End If

            If Not IsDBNull(.Fields("prim")) Then
                txtMemo.Text = .Fields("prim").Value
            End If


        End With

        rs.Close()
        rs = Nothing

        sREALNAME = cmbName.Text
        btnDirAdd.Text = objIniFile.GetString("frmDirectory", "MSG97", "")



    End Sub

    Private Sub btnDirAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDirAdd.Click
        'Тут код редактирования, добавления
        If Len(cmbName.Text) = 0 Then Exit Sub

        Dim sSQL As String
        Dim sPRID As String
        Dim sNAME As String
        Dim sPRIM As String
        Dim sPAR1 As String
        Dim sPAR2 As String
        Dim sPAR3 As String

        Dim objIniFile As New IniFile(sLANGPATH)

        If tvDirectory.SelectedNode.Text = objIniFile.GetString("frmDirectory", "MSG47", "") Or tvDirectory.SelectedNode.Text = objIniFile.GetString("frmDirectory", "MSG39", "") Or tvDirectory.SelectedNode.Text = objIniFile.GetString("frmDirectory", "MSG40", "") Or tvDirectory.SelectedNode.Text = objIniFile.GetString("frmDirectory", "MSG41", "") Or tvDirectory.SelectedNode.Text = objIniFile.GetString("frmDirectory", "MSG48", "") Or tvDirectory.SelectedNode.Text = objIniFile.GetString("frmDirectory", "MSG36", "") Or tvDirectory.SelectedNode.Text = objIniFile.GetString("frmDirectory", "MSG37", "") Then


        Else
            If Len(cmbName3.Text) = 0 Then cmbName3.Text = "NoName"

            If Not (RSExists("PROYZV", "PROiZV", cmbName3.Text)) Then
                AddPr(cmbName3.Text)
            End If

            Dim rs1 As ADODB.Recordset
            rs1 = New ADODB.Recordset

            rs1.Open("SELECT * FROM SPR_PROIZV WHERE PROIZV='" & cmbName3.Text & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

            With rs1

                sPRID = .Fields("ID").Value

            End With
            rs1.Close()
            rs1 = Nothing

        End If


        sNAME = cmbName.Text
        sPRIM = txtMemo.Text
        sPAR1 = cmb1.Text
        sPAR2 = cmb2.Text

        Dim rs As ADODB.Recordset


        Select Case tvDirectory.SelectedNode.Text

            Case objIniFile.GetString("frmDirectory", "MSG57", "")

                '#######################################
                'Пользователь экспериментально
                '#######################################

                If eDTI = False Then
                    sSQL = "SELECT * FROM SPR_USER"

                Else
                    sSQL = "SELECT * FROM SPR_USER WHERE id =" & dSID
                End If

                sPAR1 = cmbName2.Text



            Case objIniFile.GetString("frmDirectory", "MSG27", "")

                If eDTI = False Then
                    sSQL = "SELECT * FROM SPR_OPTICAL"

                Else
                    sSQL = "SELECT * FROM SPR_OPTICAL WHERE id =" & dSID
                End If

            Case objIniFile.GetString("frmDirectory", "MSG3", "")

                If eDTI = False Then
                    sSQL = "SELECT * FROM SPR_USB"
                Else
                    sSQL = "SELECT * FROM SPR_USB WHERE id =" & dSID
                End If


            Case objIniFile.GetString("frmDirectory", "MSG4", "")

                If eDTI = False Then
                    sSQL = "SELECT * FROM spr_zip"
                Else
                    sSQL = "SELECT * FROM spr_zip WHERE id =" & dSID
                End If


            Case objIniFile.GetString("frmDirectory", "MSG5", "")

                If eDTI = False Then
                    sSQL = "SELECT * FROM SPR_ASISTEM"
                Else
                    sSQL = "SELECT * FROM SPR_ASISTEM WHERE id =" & dSID
                End If


            Case objIniFile.GetString("frmDirectory", "MSG6", "")

                If eDTI = False Then
                    sSQL = "SELECT * FROM SPR_IBP"
                Else
                    sSQL = "SELECT * FROM SPR_IBP WHERE id =" & dSID
                End If

            Case objIniFile.GetString("frmDirectory", "MSG7", "")

                If eDTI = False Then
                    sSQL = "SELECT * FROM SPR_KEYBOARD"
                Else
                    sSQL = "SELECT * FROM SPR_KEYBOARD WHERE id =" & dSID
                End If

            Case objIniFile.GetString("frmDirectory", "MSG8", "")

                If eDTI = False Then
                    sSQL = "SELECT * FROM SPR_KOPIR"
                Else
                    sSQL = "SELECT * FROM SPR_KOPIR WHERE id =" & dSID

                    Dim BASECOMP As ADODB.Recordset
                    BASECOMP = New ADODB.Recordset
                    BASECOMP.Open("UPDATE kompy SET PSEVDONIM='" & LTrim(sNAME) & "', PRINTER_NAME_1='" & LTrim(sNAME) & "', Net_name = '" & LTrim(sNAME) & "', printer_proizv_1 = '" & LTrim(cmbName3.Text) & "' WHERE TipTehn = 'KOpir' And Net_name = '" & LTrim(sREALNAME) & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                    BASECOMP = Nothing

                End If

            Case objIniFile.GetString("frmDirectory", "MSG34", "")

                If eDTI = False Then
                    sSQL = "SELECT * FROM SPR_MODEM"
                Else
                    sSQL = "SELECT * FROM SPR_MODEM WHERE id =" & dSID
                End If


            Case objIniFile.GetString("frmDirectory", "MSG9", "")

                If eDTI = False Then
                    sSQL = "SELECT * FROM SPR_MONITOR"
                Else
                    sSQL = "SELECT * FROM SPR_MONITOR WHERE id =" & dSID
                End If

            Case objIniFile.GetString("frmDirectory", "MSG10", "")

                If eDTI = False Then
                    sSQL = "SELECT * FROM SPR_MFU"
                Else
                    sSQL = "SELECT * FROM SPR_MFU WHERE id =" & dSID
                    Dim BASECOMP As ADODB.Recordset
                    BASECOMP = New ADODB.Recordset
                    BASECOMP.Open("UPDATE kompy SET PSEVDONIM='" & LTrim(sNAME) & "', PRINTER_NAME_1='" & LTrim(sNAME) & "', Net_name = '" & LTrim(sNAME) & "', printer_proizv_1 = '" & LTrim(cmbName3.Text) & "' WHERE TipTehn = 'MFU' And Net_name = '" & LTrim(sREALNAME) & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                    BASECOMP = Nothing
                End If

            Case objIniFile.GetString("frmDirectory", "MSG11", "")

                If eDTI = False Then
                    sSQL = "SELECT * FROM SPR_MOUSE"
                Else
                    sSQL = "SELECT * FROM SPR_MOUSE WHERE id =" & dSID
                End If

            Case objIniFile.GetString("frmDirectory", "MSG12", "")

                If eDTI = False Then
                    sSQL = "SELECT * FROM SPR_PRINTER"
                Else
                    sSQL = "SELECT * FROM SPR_PRINTER WHERE id =" & dSID
                    Dim BASECOMP As ADODB.Recordset
                    BASECOMP = New ADODB.Recordset
                    BASECOMP.Open("UPDATE kompy SET PSEVDONIM='" & LTrim(sNAME) & "', PRINTER_NAME_1='" & LTrim(sNAME) & "', Net_name = '" & LTrim(sNAME) & "', printer_proizv_1 = '" & LTrim(cmbName3.Text) & "' WHERE TipTehn = 'Printer' And Net_name = '" & LTrim(sREALNAME) & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                    BASECOMP = Nothing
                End If

            Case objIniFile.GetString("frmDirectory", "MSG13", "")

                If eDTI = False Then
                    sSQL = "SELECT * FROM SPR_FS"
                Else
                    sSQL = "SELECT * FROM SPR_FS WHERE id =" & dSID
                End If

            Case objIniFile.GetString("frmDirectory", "MSG14", "")

                If eDTI = False Then
                    sSQL = "SELECT * FROM SPR_DEV_NET"
                Else
                    sSQL = "SELECT * FROM SPR_DEV_NET WHERE id =" & dSID
                End If

            Case objIniFile.GetString("frmDirectory", "MSG15", "")

                If eDTI = False Then
                    sSQL = "SELECT * FROM SPR_SCANER"
                Else
                    sSQL = "SELECT * FROM SPR_SCANER WHERE id =" & dSID
                End If

            Case objIniFile.GetString("frmDirectory", "MSG16", "")

                If eDTI = False Then
                    sSQL = "SELECT * FROM spr_phone"
                Else
                    sSQL = "SELECT * FROM spr_phone WHERE id =" & dSID
                End If

            Case objIniFile.GetString("frmDirectory", "MSG17", "")

                If eDTI = False Then
                    sSQL = "SELECT * FROM spr_fax"
                Else
                    sSQL = "SELECT * FROM spr_fax WHERE id =" & dSID
                End If

            Case objIniFile.GetString("frmDirectory", "MSG18", "")

                If eDTI = False Then
                    sSQL = "SELECT * FROM spr_photo"
                Else
                    sSQL = "SELECT * FROM spr_photo WHERE id =" & dSID
                End If

            Case objIniFile.GetString("frmDirectory", "MSG20", "")

                If eDTI = False Then
                    sSQL = "SELECT * FROM SPR_SVGA"
                Else
                    sSQL = "SELECT * FROM SPR_SVGA WHERE id =" & dSID
                End If

            Case objIniFile.GetString("frmDirectory", "MSG21", "")

                If eDTI = False Then
                    sSQL = "SELECT * FROM SPR_FDD"
                Else
                    sSQL = "SELECT * FROM SPR_FDD WHERE id =" & dSID
                End If

            Case objIniFile.GetString("frmDirectory", "MSG22", "")

                If eDTI = False Then
                    sSQL = "SELECT * FROM SPR_HDD"
                Else
                    sSQL = "SELECT * FROM SPR_HDD WHERE id =" & dSID
                End If

            Case objIniFile.GetString("frmDirectory", "MSG23", "")
                If eDTI = False Then
                    sSQL = "SELECT * FROM SPR_SOUND"
                Else
                    sSQL = "SELECT * FROM SPR_SOUND WHERE id =" & dSID
                End If


            Case objIniFile.GetString("frmDirectory", "MSG25", "")

                If eDTI = False Then
                    sSQL = "SELECT * FROM SPR_MB"
                Else
                    sSQL = "SELECT * FROM SPR_MB WHERE id =" & dSID
                End If

            Case objIniFile.GetString("frmDirectory", "MSG26", "")

                If eDTI = False Then
                    sSQL = "SELECT * FROM SPR_RAM"
                Else
                    sSQL = "SELECT * FROM SPR_RAM WHERE id =" & dSID
                End If

            Case objIniFile.GetString("frmDirectory", "MSG28", "")

                If eDTI = False Then
                    sSQL = "SELECT * FROM SPR_CPU"
                Else
                    sSQL = "SELECT * FROM SPR_CPU WHERE id =" & dSID
                End If

            Case objIniFile.GetString("frmDirectory", "MSG29", "")

                If eDTI = False Then
                    sSQL = "SELECT * FROM SPR_NET"
                Else
                    sSQL = "SELECT * FROM SPR_NET WHERE id =" & dSID
                End If

            Case objIniFile.GetString("frmDirectory", "MSG30", "")

                If eDTI = False Then
                    sSQL = "SELECT * FROM SPR_PCI"
                Else
                    sSQL = "SELECT * FROM SPR_PCI WHERE id =" & dSID
                End If

            Case objIniFile.GetString("frmDirectory", "MSG36", "")

                If eDTI = False Then
                    sSQL = "SELECT * FROM SPR_Master"
                Else
                    sSQL = "SELECT * FROM SPR_Master WHERE id =" & dSID
                End If
                sPAR1 = cmbName2.Text
                sPAR2 = cmb1.Text
                sPAR3 = cmb2.Text

                Dim rscount As ADODB.Recordset
                rscount = New ADODB.Recordset
                rscount.Open("SELECT COUNT(*) AS total_number FROM Remont where master ='" & sREALNAME & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                Dim sNUM As Decimal
                With rscount
                    sNUM = .Fields("total_number").Value
                End With
                rscount.Close()
                rscount = Nothing

                If sNUM > 0 Then
                    rscount = New ADODB.Recordset
                    rscount = New ADODB.Recordset
                    rscount.Open("UPDATE Remont SET master='" & sNAME & "' WHERE master='" & sREALNAME & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                    rscount = Nothing
                End If

                rscount = New ADODB.Recordset
                rscount.Open("SELECT COUNT(*) AS total_number FROM Zametki where master ='" & sREALNAME & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                With rscount
                    sNUM = .Fields("total_number").Value
                End With
                rscount.Close()
                rscount = Nothing

                If sNUM > 0 Then
                    rscount = New ADODB.Recordset
                    rscount = New ADODB.Recordset
                    rscount.Open("UPDATE Zametki SET master='" & sNAME & "' WHERE master='" & sREALNAME & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                    rscount = Nothing
                End If


                rscount = New ADODB.Recordset
                rscount.Open("SELECT COUNT(*) AS total_number FROM ZAM_OTD where master ='" & sREALNAME & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                With rscount
                    sNUM = .Fields("total_number").Value
                End With
                rscount.Close()
                rscount = Nothing

                If sNUM > 0 Then
                    rscount = New ADODB.Recordset
                    rscount = New ADODB.Recordset
                    rscount.Open("UPDATE ZAM_OTD SET master='" & sNAME & "' WHERE master='" & sREALNAME & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                    rscount = Nothing
                End If

                rscount = New ADODB.Recordset
                rscount.Open("SELECT COUNT(*) AS total_number FROM remonty_plus where master ='" & sREALNAME & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                With rscount
                    sNUM = .Fields("total_number").Value
                End With
                rscount.Close()
                rscount = Nothing

                If sNUM > 0 Then
                    rscount = New ADODB.Recordset
                    rscount = New ADODB.Recordset
                    rscount.Open("UPDATE remonty_plus SET master='" & sNAME & "' WHERE master='" & sREALNAME & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                    rscount = Nothing
                End If

            Case objIniFile.GetString("frmDirectory", "MSG37", "")
               

                If eDTI = False Then
                    sSQL = "SELECT * FROM SPR_OTV"

                Else
                    sSQL = "SELECT * FROM SPR_OTV WHERE id =" & dSID

                    Dim rscount As ADODB.Recordset
                    Dim sNUM As Decimal
                    rscount = New ADODB.Recordset
                    rscount.Open("SELECT COUNT(*) AS total_number FROM kompy where OTvetstvennyj ='" & sREALNAME & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                    With rscount
                        sNUM = .Fields("total_number").Value
                    End With
                    rscount.Close()
                    rscount = Nothing

                    If sNUM > 0 Then
                        rscount = New ADODB.Recordset
                        rscount = New ADODB.Recordset
                        rscount.Open("UPDATE kompy SET OTvetstvennyj='" & sNAME & "' WHERE OTvetstvennyj='" & sREALNAME & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                        rscount = Nothing
                    End If

                End If



                
                'Добавить код проверяющий в оргтехники ответственного


            Case objIniFile.GetString("frmDirectory", "MSG39", "")

                If eDTI = False Then

                    If Not (RSExists("FILIAL", "FILIAL", cmbName.Text)) Then
                        AddOnePar(Me.cmbName.Text, "FILIAL", "SPR_FILIAL", Me.cmbName)
                    End If

                Else

                    Dim Sck As String
                    If chkVisibleSTR.Checked = False Then
                        Sck = 0
                    Else
                        Sck = 1
                    End If

                    Dim rs1 As ADODB.Recordset
                    rs1 = New ADODB.Recordset
                    rs1.Open("UPDATE SPR_FILIAL SET filial='" & LTrim(cmbName.Text) & "', Prim='" & txtMemo.Text & "', A ='" & cmb1.Text & "', B ='" & cmb2.Text & "', C='" & "', ARHIV=" & Sck & " WHERE ID=" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                    rs1 = Nothing

                    Dim rscount As ADODB.Recordset
                    rscount = New ADODB.Recordset
                    rscount.Open("SELECT COUNT(*) AS total_number FROM kompy where filial ='" & sREALNAME & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                    Dim sNUM As Decimal
                    With rscount
                        sNUM = .Fields("total_number").Value
                    End With
                    rscount.Close()
                    rscount = Nothing

                    If sNUM > 0 Then
                        rscount = New ADODB.Recordset
                        rscount.Open("UPDATE kompy SET filial='" & sNAME & "' WHERE filial='" & sREALNAME & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                        rscount = Nothing

                        rscount = New ADODB.Recordset
                        rscount.Open("UPDATE SPR_OTD_FILIAL SET filial='" & sNAME & "' WHERE filial='" & sREALNAME & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                        rscount = Nothing

                        rscount = New ADODB.Recordset
                        rscount.Open("UPDATE SPR_KAB SET N_F='" & sNAME & "' WHERE N_F='" & sREALNAME & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                        rscount = Nothing

                    End If

                End If

                Call LOAD_LIST_SPR()

                Call RefFilTree(frmComputers.lstGroups)

                btnDirAdd.Text = objIniFile.GetString("frmDirectory", "btnDirAdd", "")
                eDTI = False
                Exit Sub

            Case objIniFile.GetString("frmDirectory", "MSG40", "")

                If eDTI = False Then

                    If Not (RSExistsDB(cmbName.Text, txtName.Text)) Then
                        AddDepartment(cmbName.Text, txtName.Text)
                    End If

                Else

                    Dim Sck As String
                    If chkVisibleSTR.Checked = False Then
                        Sck = 0
                    Else
                        Sck = 1
                    End If

                    Dim rs1 As ADODB.Recordset
                    rs1 = New ADODB.Recordset
                    rs1.Open("UPDATE SPR_OTD_FILIAL SET N_Otd='" & LTrim(txtName.Text) & "', Filial='" & LTrim(cmbName.Text) & "', Prim='" & txtMemo.Text & "', A ='" & cmb1.Text & "', B ='" & cmb2.Text & "', C='" & "', ARHIV=" & Sck & " WHERE ID=" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                    rs1 = Nothing

                    Dim rscount As ADODB.Recordset
                    rscount = New ADODB.Recordset
                    rscount.Open("SELECT COUNT(*) AS total_number FROM kompy where mesto ='" & sREALNAME & "' and filial ='" & LTrim(cmbName.Text) & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                    Dim sNUM As String
                    With rscount
                        sNUM = .Fields("total_number").Value
                    End With
                    rscount.Close()
                    rscount = Nothing

                    If sNUM > 0 Then
                        rscount = New ADODB.Recordset
                        rscount.Open("UPDATE kompy SET mesto='" & LTrim(txtName.Text) & "' WHERE mesto='" & sREALNAME & "' and filial ='" & LTrim(cmbName.Text) & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                        rscount = Nothing

                        rscount = New ADODB.Recordset
                        rscount.Open("UPDATE SPR_KAB SET N_M='" & LTrim(txtName.Text) & "' WHERE N_M='" & sREALNAME & "' AND N_F='" & LTrim(cmbName.Text) & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                        rscount = Nothing


                    End If


                End If

                Call LOAD_LIST_SPR()
                Call RefFilTree(frmComputers.lstGroups)
                btnDirAdd.Text = objIniFile.GetString("frmDirectory", "btnDirAdd", "")
                eDTI = False
                Exit Sub

            Case objIniFile.GetString("frmDirectory", "MSG41", "")

                If eDTI = False Then

                    If Not (RSExistsDBO(cmbName.Text, cmbName2.Text, txtName.Text)) Then
                        AddOffice(cmbName.Text, cmbName2.Text, txtName.Text)
                    End If

                Else

                    Dim rs1 As ADODB.Recordset
                    rs1 = New ADODB.Recordset

                    Dim Sck As String
                    If chkVisibleSTR.Checked = False Then
                        Sck = 0
                    Else
                        Sck = 1
                    End If


                    rs1.Open("UPDATE SPR_KAB SET Name='" & LTrim(txtName.Text) & "', N_M='" & LTrim(cmbName2.Text) & "', N_F='" & LTrim(cmbName.Text) & "', Prim='" & txtMemo.Text & "', A ='" & cmb1.Text & "', B ='" & cmb2.Text & "', C='" & "', ARHIV=" & Sck & " WHERE ID=" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                    rs1 = Nothing

                    Dim rscount As ADODB.Recordset
                    rscount = New ADODB.Recordset
                    rscount.Open("SELECT COUNT(*) AS total_number FROM kompy where kabn ='" & sREALNAME & "' and filial ='" & LTrim(cmbName.Text) & "' and mesto ='" & LTrim(cmbName2.Text) & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                    Dim sNUM As String
                    With rscount
                        sNUM = .Fields("total_number").Value
                    End With
                    rscount.Close()
                    rscount = Nothing

                    If sNUM > 0 Then
                        rscount = New ADODB.Recordset
                        rscount.Open("UPDATE kompy SET kabn='" & txtName.Text & "' WHERE kabn='" & sREALNAME & "' and filial ='" & LTrim(cmbName.Text) & "' and mesto ='" & LTrim(cmbName2.Text) & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                        rscount = Nothing
                    End If


                End If


                Call LOAD_LIST_SPR()
                Call RefFilTree(frmComputers.lstGroups)

                btnDirAdd.Text = objIniFile.GetString("frmDirectory", "btnDirAdd", "")
                eDTI = False

                Exit Sub

            Case objIniFile.GetString("frmDirectory", "MSG43", "")

                If eDTI = False Then
                    sSQL = "SELECT * FROM SPR_Uroven"
                    'sSQL = "SELECT id, uroven as name, proizv, Prim, a, b, c FROM SPR_Uroven WHERE id =" & dSID
                Else
                    sSQL = "SELECT * FROM SPR_Uroven WHERE id =" & dSID
                End If


                rs = New ADODB.Recordset
                rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                With rs
                    If eDTI = False Then
                        .AddNew()
                    End If

                    .Fields("uroven").Value = LTrim(sNAME)
                    .Fields("Proizv").Value = sPRID
                    .Fields("A").Value = sPAR1
                    .Fields("B").Value = sPAR2
                    .Fields("C").Value = " "
                    .Fields("Prim").Value = sPRIM

                    .Update()
                End With

                rs.Close()
                rs = Nothing

                Call LOAD_LIST_SPR()

                btnDirAdd.Text = objIniFile.GetString("frmDirectory", "btnDirAdd", "")
                eDTI = False

                Exit Sub


            Case objIniFile.GetString("frmDirectory", "MSG44", "")

                If eDTI = False Then
                    sSQL = "SELECT * FROM spr_vip"
                Else
                    sSQL = "SELECT * FROM spr_vip WHERE id =" & dSID
                End If

            Case objIniFile.GetString("frmDirectory", "MSG45", "")

                If eDTI = False Then
                    sSQL = "SELECT * FROM spr_tip_z"
                Else
                    sSQL = "SELECT * FROM spr_tip_z WHERE id =" & dSID
                End If

            Case objIniFile.GetString("frmDirectory", "MSG47", "")

                If eDTI = False Then
                    sSQL = "SELECT * FROM SPR_Postav"
                Else
                    sSQL = "SELECT * FROM SPR_Postav WHERE id =" & dSID
                End If

            Case objIniFile.GetString("frmDirectory", "MSG48", "")

                If eDTI = False Then

                    If Not (RSExists("PROYZV", "PROiZV", cmbName.Text)) Then
                        AddPr(cmbName.Text)
                    End If

                    ' sSQL = "SELECT * FROM SPR_PROIZV"
                Else
                    sSQL = "SELECT * FROM SPR_PROIZV WHERE id =" & dSID

                    Dim rs1 As ADODB.Recordset
                    rs1 = New ADODB.Recordset
                    rs1.Open("UPDATE SPR_PROIZV SET PROIZV='" & LTrim(cmbName.Text) & "', Prim='" & txtMemo.Text & "', A ='" & cmb1.Text & "', B ='" & cmb2.Text & "', C='" & " ' WHERE ID=" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                    rs1 = Nothing

                End If

                btnDirAdd.Text = objIniFile.GetString("frmDirectory", "btnDirAdd", "")
                eDTI = False
                Call LOAD_LIST_SPR()

                'Выходим из процедуры за ненадобностью
                Exit Sub

            Case objIniFile.GetString("frmDirectory", "MSG49", "")

                If eDTI = False Then
                    sSQL = "SELECT * FROM SPR_TIP"
                Else
                    sSQL = "SELECT * FROM SPR_TIP WHERE id =" & dSID
                End If


            Case objIniFile.GetString("frmDirectory", "MSG50", "")

                If eDTI = False Then
                    sSQL = "SELECT * FROM spr_cart"
                Else
                    sSQL = "SELECT * FROM spr_cart WHERE id =" & dSID
                End If


            Case objIniFile.GetString("frmDirectory", "MSG51", "")

                If eDTI = False Then
                    sSQL = "SELECT * FROM spr_other"
                Else
                    sSQL = "SELECT * FROM spr_other WHERE id =" & dSID

                    Dim rs1 As ADODB.Recordset
                    rs1 = New ADODB.Recordset
                    rs1.Open("UPDATE SPR_OTH_DEV SET A='" & LTrim(sNAME) & "' WHERE A='" & sREALNAME & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                    rs1 = Nothing

                    rs1 = New ADODB.Recordset
                    rs1.Open("UPDATE kompy SET TIP_COMPA='" & LTrim(sNAME) & "' WHERE TIP_COMPA='" & sREALNAME & "' and TipTehn='OT'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                    rs1 = Nothing

                    'TIP_COMPA
                End If
                sPAR1 = cmbIcon.Text

                If chkCont.Checked = True Then sPAR3 = 1 Else sPAR3 = ""



            Case objIniFile.GetString("frmDirectory", "MSG52", "")

                If eDTI = False Then
                    sSQL = "SELECT * FROM SPR_OTH_DEV"
                Else
                    sSQL = "SELECT * FROM SPR_OTH_DEV WHERE id =" & dSID
                End If

                'sPAR1 = cmbIcon.Text


            Case objIniFile.GetString("frmDirectory", "MSG53", "")

                If eDTI = False Then
                    sSQL = "SELECT * FROM SPR_LIC"
                Else
                    sSQL = "SELECT * FROM SPR_LIC WHERE id =" & dSID
                End If

            Case objIniFile.GetString("frmDirectory", "MSG54", "")


                If eDTI = False Then
                    sSQL = "SELECT * FROM SPR_TIP_PO"
                Else
                    sSQL = "SELECT * FROM SPR_TIP_PO WHERE id =" & dSID

                    Dim rscount As ADODB.Recordset
                    rscount = New ADODB.Recordset
                    rscount.Open("SELECT count(*) as t_n from SPR_PO Where A ='" & sREALNAME & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                    Dim sCCC As String

                    With rscount

                        sCCC = .Fields("t_n").Value

                    End With
                    rscount.Close()
                    rscount = Nothing

                    If sCCC > 0 Then

                        rscount = New ADODB.Recordset
                        rscount.Open("UPDATE SPR_PO SET A='" & sNAME & "' WHERE A='" & sREALNAME & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                        rscount = Nothing

                    End If


                End If




            Case objIniFile.GetString("frmDirectory", "MSG55", "")

                If eDTI = False Then
                    sSQL = "SELECT * FROM SPR_Complect"
                Else
                    sSQL = "SELECT * FROM SPR_Complect WHERE id =" & dSID
                End If

            Case objIniFile.GetString("frmDirectory", "MSG56", "")

                If eDTI = False Then
                    sSQL = "SELECT * FROM SPR_PO"
                Else
                    sSQL = "SELECT * FROM SPR_PO WHERE id =" & dSID
                End If

                If Not (RSExists("TIPPO", "Name", cmbName2.Text)) Then

                    AddOnePar(cmbName2.Text, "Name", "SPR_TIP_PO", cmbName2)

                End If

                sPAR1 = cmbName2.Text


            Case objIniFile.GetString("frmDirectory", "MSG24", "")


                If eDTI = False Then
                    sSQL = "SELECT * FROM SPR_CREADER"
                Else
                    sSQL = "SELECT * FROM SPR_CREADER WHERE id =" & dSID
                End If


            Case objIniFile.GetString("frmDirectory", "MSG31", "")


                If eDTI = False Then
                    sSQL = "SELECT * FROM SPR_BP"
                Else
                    sSQL = "SELECT * FROM SPR_BP WHERE id =" & dSID
                End If

            Case objIniFile.GetString("frmDirectory", "MSG33", "")


                If eDTI = False Then
                    sSQL = "SELECT * FROM SPR_CASE"
                Else
                    sSQL = "SELECT * FROM SPR_CASE WHERE id =" & dSID
                End If

        End Select


        If Len(sPAR1) = 0 Then sPAR1 = " "
        If Len(sPAR2) = 0 Then sPAR2 = " "
        If Len(sPAR3) = 0 Then sPAR3 = " "
        If Len(sPRIM) = 0 Then sPRIM = " "

        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            If eDTI = False Then
                .AddNew()
            End If


            If tvDirectory.SelectedNode.Text = objIniFile.GetString("frmDirectory", "MSG49", "") Then
                .Fields("tip").Value = LTrim(sNAME)
            Else
                .Fields("Name").Value = LTrim(sNAME)
            End If


            If tvDirectory.SelectedNode.Text = objIniFile.GetString("frmDirectory", "MSG53", "") Or tvDirectory.SelectedNode.Text = objIniFile.GetString("frmDirectory", "MSG45", "") Or tvDirectory.SelectedNode.Text = objIniFile.GetString("frmDirectory", "MSG44", "") Or tvDirectory.SelectedNode.Text = objIniFile.GetString("frmDirectory", "MSG43", "") Or tvDirectory.SelectedNode.Text = objIniFile.GetString("frmDirectory", "MSG55", "") Or tvDirectory.SelectedNode.Text = objIniFile.GetString("frmDirectory", "MSG54", "") Then

            Else
                .Fields("Proizv").Value = sPRID
                .Fields("A").Value = sPAR1
                .Fields("B").Value = sPAR2
                .Fields("C").Value = sPAR3
            End If

            .Fields("Prim").Value = sPRIM

            .Update()
        End With

        rs.Close()
        rs = Nothing


        Call LOAD_LIST_SPR()
        btnDirAdd.Text = objIniFile.GetString("frmDirectory", "btnDirAdd", "")
        eDTI = False
    End Sub

    Private Sub frmDirectory_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        tvDirectory.Height = Me.Height - 65

        lvDirectory.Height = Me.Height - (gbSpr.Height + 70)
        gbSpr.Top = lvDirectory.Height + 10

        gbSpr.Width = Me.Width - (tvDirectory.Width + 20)
        lvDirectory.Width = Me.Width - (tvDirectory.Width + 20)

    End Sub

    Private Sub cmbName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbName.SelectedIndexChanged
        On Error GoTo err_
        Dim objIniFile As New IniFile(sLANGPATH)

        If tvDirectory.SelectedNode.Text = objIniFile.GetString("frmDirectory", "MSG41", "") Then


            cmbName2.Items.Clear()
            Dim rs1 As ADODB.Recordset
            rs1 = New ADODB.Recordset
            rs1.Open("select * from SPR_OTD_FILIAL WHERE Filial='" & cmbName.Text & "' ORDER BY N_Otd", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
            cmbName2.Items.Clear()
            With rs1
                .MoveFirst()
                Do While Not .EOF

                    If Not IsDBNull(.Fields("N_Otd").Value) Then cmbName2.Items.Add(.Fields("N_Otd").Value)

                    .MoveNext()
                Loop
            End With

            rs1.Close()
            rs1 = Nothing

        End If

        Exit Sub
err_:
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Тут код на удаление
        Dim rs As ADODB.Recordset
        Dim objIniFile As New IniFile(sLANGPATH)

        Select Case tvDirectory.SelectedNode.Text

            Case objIniFile.GetString("frmDirectory", "MSG57", "")

                '#######################################
                'Пользователь экспериментально
                '#######################################
                rs = New ADODB.Recordset
                rs.Open("Delete FROM SPR_USER WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing


            Case objIniFile.GetString("frmDirectory", "MSG27", "")
                rs = New ADODB.Recordset
                rs.Open("Delete FROM SPR_OPTICAL WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing

            Case objIniFile.GetString("frmDirectory", "MSG3", "")

                rs = New ADODB.Recordset
                rs.Open("Delete FROM SPR_USB WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing

            Case objIniFile.GetString("frmDirectory", "MSG4", "")
                rs = New ADODB.Recordset
                rs.Open("Delete FROM spr_zip WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing


            Case objIniFile.GetString("frmDirectory", "MSG5", "")

                rs = New ADODB.Recordset
                rs.Open("Delete FROM SPR_ASISTEM WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing

            Case objIniFile.GetString("frmDirectory", "MSG6", "")

                rs = New ADODB.Recordset
                rs.Open("Delete FROM SPR_IBP WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing


            Case objIniFile.GetString("frmDirectory", "MSG7", "")
                rs = New ADODB.Recordset
                rs.Open("Delete FROM SPR_KEYBOARD WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing


            Case objIniFile.GetString("frmDirectory", "MSG8", "")
                rs = New ADODB.Recordset
                rs.Open("Delete FROM SPR_KOPIR WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing


            Case objIniFile.GetString("frmDirectory", "MSG34", "")
                rs = New ADODB.Recordset
                rs.Open("Delete FROM SPR_MODEM WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing


            Case objIniFile.GetString("frmDirectory", "MSG9", "")
                rs = New ADODB.Recordset
                rs.Open("Delete FROM SPR_MONITOR WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing


            Case objIniFile.GetString("frmDirectory", "MSG10", "")

                rs = New ADODB.Recordset
                rs.Open("Delete FROM SPR_MFU WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing

            Case objIniFile.GetString("frmDirectory", "MSG11", "")
                rs = New ADODB.Recordset
                rs.Open("Delete FROM SPR_MOUSE WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing


            Case objIniFile.GetString("frmDirectory", "MSG12", "")
                rs = New ADODB.Recordset
                rs.Open("Delete FROM SPR_PRINTER WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing


            Case objIniFile.GetString("frmDirectory", "MSG13", "")
                rs = New ADODB.Recordset
                rs.Open("Delete FROM SPR_FS WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing


            Case objIniFile.GetString("frmDirectory", "MSG14", "")
                rs = New ADODB.Recordset
                rs.Open("Delete FROM SPR_DEV_NET WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing


            Case objIniFile.GetString("frmDirectory", "MSG15", "")
                rs = New ADODB.Recordset
                rs.Open("Delete FROM SPR_SCANER WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing


            Case objIniFile.GetString("frmDirectory", "MSG16", "")
                rs = New ADODB.Recordset
                rs.Open("Delete FROM spr_phone WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing


            Case objIniFile.GetString("frmDirectory", "MSG17", "")
                rs = New ADODB.Recordset
                rs.Open("Delete FROM spr_fax WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing


            Case objIniFile.GetString("frmDirectory", "MSG18", "")
                rs = New ADODB.Recordset
                rs.Open("Delete FROM spr_photo WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing

            Case objIniFile.GetString("frmDirectory", "MSG20", "")
                rs = New ADODB.Recordset
                rs.Open("Delete FROM SPR_SVGA WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing


            Case objIniFile.GetString("frmDirectory", "MSG21", "")
                rs = New ADODB.Recordset
                rs.Open("Delete FROM SPR_FDD WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing


            Case objIniFile.GetString("frmDirectory", "MSG22", "")
                rs = New ADODB.Recordset
                rs.Open("Delete FROM SPR_HDD WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing

            Case objIniFile.GetString("frmDirectory", "MSG23", "")
                rs = New ADODB.Recordset
                rs.Open("Delete FROM SPR_SOUND WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing


            Case objIniFile.GetString("frmDirectory", "MSG25", "")
                rs = New ADODB.Recordset
                rs.Open("Delete FROM SPR_MB WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing



            Case objIniFile.GetString("frmDirectory", "MSG26", "")
                rs = New ADODB.Recordset
                rs.Open("Delete FROM SPR_RAM WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing


            Case objIniFile.GetString("frmDirectory", "MSG28", "")
                rs = New ADODB.Recordset
                rs.Open("Delete FROM SPR_CPU WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing


            Case objIniFile.GetString("frmDirectory", "MSG29", "")
                rs = New ADODB.Recordset
                rs.Open("Delete FROM SPR_NET WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing


            Case objIniFile.GetString("frmDirectory", "MSG30", "")
                rs = New ADODB.Recordset
                rs.Open("Delete FROM SPR_PCI WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing



            Case objIniFile.GetString("frmDirectory", "MSG37", "")
                rs = New ADODB.Recordset
                rs.Open("Delete FROM SPR_OTV WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing


            Case objIniFile.GetString("frmDirectory", "MSG39", "")

                RemoveBrainch(lvDirectory.Items.Item(lvDirectory.FocusedItem.Index).SubItems(1).Text)

            Case objIniFile.GetString("frmDirectory", "MSG40", "")

                RemoveDepartment(dSID)

            Case objIniFile.GetString("frmDirectory", "MSG41", "")

                RemoveOffice(dSID)

            Case objIniFile.GetString("frmDirectory", "MSG43", "")
                rs = New ADODB.Recordset
                rs.Open("Delete FROM SPR_Uroven WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing


            Case objIniFile.GetString("frmDirectory", "MSG44", "")
                rs = New ADODB.Recordset
                rs.Open("Delete FROM spr_vip WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing


            Case objIniFile.GetString("frmDirectory", "MSG45", "")
                rs = New ADODB.Recordset
                rs.Open("Delete FROM spr_tip_z WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing


            Case objIniFile.GetString("frmDirectory", "MSG47", "")
                rs = New ADODB.Recordset
                rs.Open("Delete FROM SPR_Postav WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing


            Case objIniFile.GetString("frmDirectory", "MSG48", "")

                Call RemoveProyzv(dSID)

            Case objIniFile.GetString("frmDirectory", "MSG49", "")
                rs = New ADODB.Recordset
                rs.Open("Delete FROM SPR_TIP WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing


            Case objIniFile.GetString("frmDirectory", "MSG50", "")
                rs = New ADODB.Recordset
                rs.Open("Delete FROM spr_cart WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing


            Case objIniFile.GetString("frmDirectory", "MSG51", "")
                rs = New ADODB.Recordset
                rs.Open("Delete FROM spr_other WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing

            Case objIniFile.GetString("frmDirectory", "MSG52", "")
                rs = New ADODB.Recordset
                rs.Open("Delete FROM SPR_OTH_DEV WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing

            Case objIniFile.GetString("frmDirectory", "MSG53", "")
                rs = New ADODB.Recordset
                rs.Open("Delete FROM SPR_LIC WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing


            Case objIniFile.GetString("frmDirectory", "MSG54", "")
                rs = New ADODB.Recordset
                rs.Open("Delete FROM SPR_TIP_PO WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing


            Case objIniFile.GetString("frmDirectory", "MSG55", "")
                rs = New ADODB.Recordset
                rs.Open("Delete FROM SPR_Complect WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing


            Case objIniFile.GetString("frmDirectory", "MSG56", "")
                rs = New ADODB.Recordset
                rs.Open("Delete FROM SPR_PO WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing

            Case objIniFile.GetString("frmDirectory", "MSG33", "")
                rs = New ADODB.Recordset
                rs.Open("Delete FROM SPR_CASE WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing

            Case objIniFile.GetString("frmDirectory", "MSG24", "")
                rs = New ADODB.Recordset
                rs.Open("Delete FROM SPR_CREADER WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing

            Case objIniFile.GetString("frmDirectory", "MSG31", "")
                rs = New ADODB.Recordset
                rs.Open("Delete FROM SPR_BP WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing

            Case objIniFile.GetString("frmDirectory", "MSG36", "")
                rs = New ADODB.Recordset
                rs.Open("Delete FROM SPR_Master WHERE id =" & dSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                rs = Nothing


        End Select

        Call LOAD_LIST_SPR()

        btnDirAdd.Text = objIniFile.GetString("frmDirectory", "btnDirAdd", "")
        eDTI = False
    End Sub

    Private Sub lvDirectory_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvDirectory.MouseUp

    End Sub

    Private Sub lvDirectory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvDirectory.SelectedIndexChanged

    End Sub

    Private Sub cmbIcon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbIcon.SelectedIndexChanged
        'pbOtherICO.Image=

        Dim s1 As Integer
        s1 = cmbIcon.Text
        'frmComputers.ilsCommands.ImageSize = New System.Drawing.Size(32, 32)


        Select Case sICONS

            Case "32*32"

                pbOtherICO.Image = frmComputers.ImageList1.Images(s1)
            Case Else

                pbOtherICO.Image = frmComputers.ilsCommands.Images(s1)

        End Select



        'frmMain.imglist_cont.ListImages(s1).Picture
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Cursor = Cursors.WaitCursor

        Call LoadSPR()

        Me.Cursor = Cursors.Default
        Me.Close()


    End Sub

    Private Sub btnCancell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancell.Click
        Dim objIniFile As New IniFile(sLANGPATH)
        eDTI = False

        btnDirAdd.Text = objIniFile.GetString("frmDirectory", "btnDirAdd", "")

        cmbName.Text = ""
        cmbName2.Text = ""
        txtName.Text = ""
        cmbName3.Text = ""
        txtMemo.Text = ""
        cmb1.Text = ""
        cmb2.Text = ""
        cmbIcon.Text = ""
        chkVisibleSTR.Checked = False


    End Sub
End Class