Public Class frmPPR

    Private Sub frmPPR_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        cmbYear.Items.Clear()

        Dim z As Integer

        For z = 1 To 10
            cmbYear.Items.Add(Date.Today.Year + z)
        Next


    End Sub

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click

        If Len(cmbKvartal.Text) = 0 Then Exit Sub
        If Len(cmbYear.Text) = 0 Then Exit Sub

        'Код сохранения результатов в таблицу

        'TBL_PPR
        Dim sSQL As String
        Dim rs As ADODB.Recordset

        Dim sCOUNT As Integer

        sSQL = "SELECT count(*) as t_n FROM TBL_PPR WHERE id_comp=" & frmComputers.sCOUNT & " AND YEAR_TO='" & cmbYear.Text & "'" & " AND TIP_TO='" & frmComputers.TIP_TO & "'" & " AND KVARTAL_TO='" & cmbKvartal.Text & "'"
        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)


        With rs

            sCOUNT = .Fields("t_n").Value

        End With

        rs.Close()
        rs = Nothing

        If sCOUNT > 0 Then

            MsgBox("ТО для данного оборудования уже запланировано на выбранный год - смените год...", MsgBoxStyle.Information, ProGramName)

            Exit Sub

        End If






        sSQL = "SELECT * FROM TBL_PPR"

        rs = New ADODB.Recordset
        rs.Open(sSQL, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            .AddNew()

            .Fields("ID_COMP").Value = frmComputers.sCOUNT
            .Fields("TIP_TO").Value = frmComputers.TIP_TO

            .Fields("KVARTAL_TO").Value = cmbKvartal.Text
            .Fields("YEAR_TO").Value = cmbYear.Text


            .Update()
        End With
        rs.Close()
        rs = Nothing




        Me.Close()




    End Sub
End Class