Public Class frmLOG
    Private LOGLOAD As Decimal
    Private m_SortingColumn As ColumnHeader

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBPrLog.CheckedChanged

        LOGLOAD = 0

        If RBPrLog.Checked = True Then
            Call PROGRAMLOG_LOAD()

        End If

    End Sub

    Private Sub PROGRAMLOG_LOAD()
        On Error GoTo Err_
        Me.Cursor = Cursors.WaitCursor
        Dim objIniFile As New IniFile(sLANGPATH)


        Dim strDate As String

        lvLOG.Columns.Clear()
        lvLOG.Items.Clear()
        lvLOG.Columns.Add(objIniFile.GetString("frmLOG", "MSG1", ""), 1, HorizontalAlignment.Left)
        lvLOG.Columns.Add(objIniFile.GetString("frmLOG", "MSG2", ""), 130, HorizontalAlignment.Left)
        lvLOG.Columns.Add(objIniFile.GetString("frmLOG", "MSG3", ""), 400, HorizontalAlignment.Left)
        lvLOG.Columns.Add(objIniFile.GetString("frmLOG", "MSG4", ""), 70, HorizontalAlignment.Left)
        lvLOG.Columns.Add(objIniFile.GetString("frmLOG", "MSG5", ""), 70, HorizontalAlignment.Left)


        Dim a, b, c As String
        a = DTLOG.Value.Day

        b = DTLOG.Value.Month

        If Len(b) = 1 Then b = "0" & b

        c = DTLOG.Value.Year

        strDate = c & "-" & b & "-" & a


        Dim ZUG As Decimal = 0
        Dim rscount As ADODB.Recordset 'Объявляем рекордсет
        rscount = New ADODB.Recordset

        rscount.Open("SELECT COUNT(*) AS total_number FROM T_Log", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rscount
            ZUG = .Fields("total_number").Value
        End With

        rscount.Close()
        rscount = Nothing

        Dim sSQl As String


        ' sSQl = "SELECT * FROM T_Log WHERE DATE_FORMAT(DATE,'%yyyy-%mm-%dd') AS data='" & strDate & "'" 'WHERE (DATE=CONVERT(DATETIME, '" & DaSTE & "', 104))"
        sSQl = "SELECT * FROM T_Log"


        '"SELECT id, user_ID, Activity, DATE_FORMAT(data,'%Y-%m-%d') AS out_data, Time FROM T_Log ORDER BY out_data DESC LIMIT 1" 


        If ZUG > 0 Then

            Dim rs As ADODB.Recordset
            rs = New ADODB.Recordset
            rs.Open(sSQl, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

            Dim intCount As Decimal = 0
            With rs
                .MoveFirst()
                Do While Not .EOF
                    ''My.Application.DoEvents()

                    If DTLOG.Value <= .Fields("DATE").Value And DTLOG1.Value >= .Fields("DATE").Value Then

                        lvLOG.Items.Add(.Fields("id").Value) 'col no. 1

                        If Not IsDBNull(.Fields("user_ID").Value) Then
                            lvLOG.Items(CInt(intCount)).SubItems.Add(.Fields("user_ID").Value)
                        Else
                            lvLOG.Items(CInt(intCount)).SubItems.Add("")
                        End If

                        If Not IsDBNull(.Fields("Activity").Value) Then
                            lvLOG.Items(CInt(intCount)).SubItems.Add(.Fields("Activity").Value)
                        Else
                            lvLOG.Items(CInt(intCount)).SubItems.Add("")
                        End If

                        If Not IsDBNull(.Fields("DATE").Value) Then
                            lvLOG.Items(CInt(intCount)).SubItems.Add(.Fields("DATE").Value)
                        Else
                            lvLOG.Items(CInt(intCount)).SubItems.Add("")
                        End If

                        If Not IsDBNull(.Fields("Time").Value) Then
                            lvLOG.Items(CInt(intCount)).SubItems.Add(.Fields("Time").Value)
                        Else
                            lvLOG.Items(CInt(intCount)).SubItems.Add("")
                        End If


                        intCount = intCount + 1
                    Else
                    End If

                    .MoveNext()
                    'DoEvents

                Loop

            End With

            rs.Close()
            rs = Nothing

        End If

        Me.Cursor = Cursors.Default

        ResList(Me.lvLOG)

        Exit Sub
Err_:

        MsgBox(Err.Description)

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub MOVE_LOG()
        On Error GoTo Err_
        Me.Cursor = Cursors.WaitCursor
        Dim objIniFile As New IniFile(sLANGPATH)


        lvLOG.Columns.Clear()
        lvLOG.Items.Clear()
        lvLOG.Columns.Add(objIniFile.GetString("frmLOG", "MSG1", ""), 1, HorizontalAlignment.Left)
        lvLOG.Columns.Add(objIniFile.GetString("frmLOG", "MSG6", ""), 200, HorizontalAlignment.Left)
        lvLOG.Columns.Add(objIniFile.GetString("frmLOG", "MSG7", ""), 150, HorizontalAlignment.Left)
        lvLOG.Columns.Add(objIniFile.GetString("frmLOG", "MSG8", ""), 150, HorizontalAlignment.Left)
        lvLOG.Columns.Add(objIniFile.GetString("frmLOG", "MSG9", ""), 300, HorizontalAlignment.Left)
        lvLOG.Columns.Add(objIniFile.GetString("frmLOG", "MSG10", ""), 70, HorizontalAlignment.Left)
        lvLOG.Columns.Add(objIniFile.GetString("frmLOG", "MSG11", ""), 70, HorizontalAlignment.Left)


        Dim ZUG As Decimal = 0
        Dim rscount As ADODB.Recordset 'Объявляем рекордсет
        rscount = New ADODB.Recordset

        rscount.Open("SELECT COUNT(*) AS total_number FROM dvig", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rscount
            ZUG = .Fields("total_number").Value
        End With

        rscount.Close()
        rscount = Nothing

        Dim sSQl As String


        sSQl = "SELECT * FROM dvig"


        If ZUG > 0 Then

            Dim rs2 As ADODB.Recordset
            Dim Namr
            Dim rs As ADODB.Recordset
            rs = New ADODB.Recordset
            rs.Open(sSQl, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

            Dim intCount As Decimal = 0
            With rs
                .MoveFirst()
                Do While Not .EOF


                    If DTLOG.Value <= .Fields("data").Value And DTLOG1.Value >= .Fields("data").Value Then

                        lvLOG.Items.Add(.Fields("id").Value) 'col no. 1

                        rs2 = New ADODB.Recordset
                        rs2.Open("SELECT id, NET_name FROM kompy WHERE id = " & .Fields("Id_Comp").Value, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                        With rs2

                            If Not IsDBNull(.Fields("NET_name").Value) Then Namr = .Fields("NET_name").Value

                        End With
                        rs2.Close()
                        rs2 = Nothing

                        lvLOG.Items(CInt(intCount)).SubItems.Add(Namr)


                        If Not IsDBNull(.Fields("oldMesto").Value) Then
                            lvLOG.Items(CInt(intCount)).SubItems.Add(.Fields("oldMesto").Value)
                        Else
                            lvLOG.Items(CInt(intCount)).SubItems.Add("")
                        End If

                        If Not IsDBNull(.Fields("NewMesto").Value) Then
                            lvLOG.Items(CInt(intCount)).SubItems.Add(.Fields("NewMesto").Value)
                        Else
                            lvLOG.Items(CInt(intCount)).SubItems.Add("")
                        End If

                        If Not IsDBNull(.Fields("Prich").Value) Then
                            lvLOG.Items(CInt(intCount)).SubItems.Add(.Fields("Prich").Value)
                        Else
                            lvLOG.Items(CInt(intCount)).SubItems.Add("")
                        End If

                        If Not IsDBNull(.Fields("data").Value) Then
                            lvLOG.Items(CInt(intCount)).SubItems.Add(.Fields("data").Value)
                        Else
                            lvLOG.Items(CInt(intCount)).SubItems.Add("")
                        End If

                        If Not IsDBNull(.Fields("time").Value) Then
                            lvLOG.Items(CInt(intCount)).SubItems.Add(.Fields("time").Value)
                        Else
                            lvLOG.Items(CInt(intCount)).SubItems.Add("")
                        End If

                        intCount = intCount + 1
                    Else
                    End If

                    .MoveNext()
                    'DoEvents

                Loop

            End With

            rs.Close()
            rs = Nothing

        End If

        Me.Cursor = Cursors.Default

        ResList(Me.lvLOG)

        Exit Sub
Err_:

        MsgBox(Err.Description)

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub rbMove_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMove.CheckedChanged

        LOGLOAD = 1

        If rbMove.Checked = True Then
            Call MOVE_LOG()
        End If


    End Sub

    Private Sub rbUpdate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbUpdate.CheckedChanged
        LOGLOAD = 2
        Me.Cursor = Cursors.WaitCursor

        lvLOG.Columns.Clear()
        lvLOG.Items.Clear()

        If rbUpdate.Checked = True Then
            Call IZM_LOG()
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub frmLOG_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        frmMain.SaveInfTehButton.Enabled = False
        frmMain.ToolStripDropDownButton1.Enabled = False
    End Sub

    Private Sub frmLOG_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        SendFonts(Me)

        Call LANG_frmLOG()

       
        DTLOG.Value = Date.Today.AddDays(-1)
        DTLOG1.Value = Date.Today

        
    End Sub

    Private Sub frmLOG_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        lvLOG.Width = Me.Width - 15
        lvLOG.Height = Me.Height - 110
    End Sub

    Private Sub IZM_LOG()
        On Error GoTo Err_
        Me.Cursor = Cursors.WaitCursor
        Dim objIniFile As New IniFile(sLANGPATH)

        lvLOG.Columns.Clear()
        lvLOG.Items.Clear()
        lvLOG.Columns.Add(objIniFile.GetString("frmLOG", "MSG1", ""), 1, HorizontalAlignment.Left)
        lvLOG.Columns.Add(objIniFile.GetString("frmLOG", "MSG12", ""), 200, HorizontalAlignment.Left)
        lvLOG.Columns.Add(objIniFile.GetString("frmLOG", "MSG13", ""), 150, HorizontalAlignment.Left)
        lvLOG.Columns.Add(objIniFile.GetString("frmLOG", "MSG14", ""), 150, HorizontalAlignment.Left)
        lvLOG.Columns.Add(objIniFile.GetString("frmLOG", "MSG15", ""), 300, HorizontalAlignment.Left)
        lvLOG.Columns.Add(objIniFile.GetString("frmLOG", "MSG16", ""), 70, HorizontalAlignment.Left)


        Dim ZUG As Decimal = 0
        Dim rscount As ADODB.Recordset 'Объявляем рекордсет
        rscount = New ADODB.Recordset

        rscount.Open("SELECT COUNT(*) AS total_number FROM Update_Log", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rscount
            ZUG = .Fields("total_number").Value
        End With

        rscount.Close()
        rscount = Nothing

        Dim sSQl As String


        sSQl = "SELECT * FROM Update_Log"


        If ZUG > 0 Then

            Dim rs2 As ADODB.Recordset
            Dim Namr
            Dim rs As ADODB.Recordset
            rs = New ADODB.Recordset
            rs.Open(sSQl, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

            Dim intCount As Decimal = 0
            With rs
                .MoveFirst()
                Do While Not .EOF

                    If DTLOG.Value <= .Fields("date").Value And DTLOG1.Value >= .Fields("date").Value Then


                        lvLOG.Items.Add(.Fields("id").Value) 'col no. 1

                        rs2 = New ADODB.Recordset
                        rs2.Open("SELECT id, NET_name FROM kompy WHERE id = " & .Fields("Id_Comp").Value, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                        With rs2

                            If Not IsDBNull(.Fields("NET_name").Value) Then Namr = .Fields("NET_name").Value

                        End With
                        rs2.Close()
                        rs2 = Nothing

                        lvLOG.Items(CInt(intCount)).SubItems.Add(Namr)


                        If Not IsDBNull(.Fields("Komcl_old").Value) Then
                            lvLOG.Items(CInt(intCount)).SubItems.Add(.Fields("Komcl_old").Value)
                        Else
                            lvLOG.Items(CInt(intCount)).SubItems.Add("")
                        End If

                        If Not IsDBNull(.Fields("Kompl_new").Value) Then
                            lvLOG.Items(CInt(intCount)).SubItems.Add(.Fields("Kompl_new").Value)
                        Else
                            lvLOG.Items(CInt(intCount)).SubItems.Add("")
                        End If

                        If Not IsDBNull(.Fields("date").Value) Then
                            lvLOG.Items(CInt(intCount)).SubItems.Add(.Fields("date").Value)
                        Else
                            lvLOG.Items(CInt(intCount)).SubItems.Add("")
                        End If

                        If Not IsDBNull(.Fields("time").Value) Then
                            lvLOG.Items(CInt(intCount)).SubItems.Add(.Fields("time").Value)
                        Else
                            lvLOG.Items(CInt(intCount)).SubItems.Add("")
                        End If

                        intCount = intCount + 1
                    Else
                    End If

                    .MoveNext()
                    'DoEvents

                Loop

            End With

            rs.Close()
            rs = Nothing

        End If

        Me.Cursor = Cursors.Default

        ResList(Me.lvLOG)

        Exit Sub
Err_:

        MsgBox(Err.Description)

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        Select Case LOGLOAD

            Case 0

                Call PROGRAMLOG_LOAD()

            Case 1

                Call MOVE_LOG()

            Case 2

                Call IZM_LOG()

        End Select


    End Sub

    Private Sub lvLOG_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvLOG.ColumnClick
        Dim new_sorting_column As ColumnHeader = _
    lvLOG.Columns(e.Column)
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

        lvLOG.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)

        lvLOG.Sort()
    End Sub

    Private Sub lvLOG_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvLOG.SelectedIndexChanged

    End Sub
End Class