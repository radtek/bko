Module MOD_REMOVE

    Public Sub REMOVE_TEHN(ByVal sSID As String)
        'On Error GoTo error

        On Error Resume Next
        'aaa$ = sContactID

        Dim Garant_ia As ADODB.Recordset
        Garant_ia = New ADODB.Recordset
        Dim garant_comp As ADODB.Recordset
        garant_comp = New ADODB.Recordset
        Dim Remont As ADODB.Recordset
        Remont = New ADODB.Recordset
        Dim SOFT_INSTALL As ADODB.Recordset
        SOFT_INSTALL = New ADODB.Recordset
        Dim Zametki As ADODB.Recordset
        Zametki = New ADODB.Recordset
        Dim uLOG As ADODB.Recordset
        uLOG = New ADODB.Recordset
        Dim USERCOMP As ADODB.Recordset
        USERCOMP = New ADODB.Recordset
        Dim TBLBIOS As ADODB.Recordset
        TBLBIOS = New ADODB.Recordset
        Dim BASECOMP As ADODB.Recordset
        BASECOMP = New ADODB.Recordset
        Dim CARTRIDG As ADODB.Recordset
        CARTRIDG = New ADODB.Recordset
        Dim CARTRIDG_Z As ADODB.Recordset
        CARTRIDG_Z = New ADODB.Recordset
        Dim AKT_SP_OS3 As ADODB.Recordset
        AKT_SP_OS3 = New ADODB.Recordset
        Dim ActOS As ADODB.Recordset
        ActOS = New ADODB.Recordset
        Dim TrebOvanie As ADODB.Recordset
        TrebOvanie = New ADODB.Recordset
        Dim dvig As ADODB.Recordset
        dvig = New ADODB.Recordset
        Dim net_port As ADODB.Recordset
        net_port = New ADODB.Recordset
        Dim tbl_ppr As ADODB.Recordset
        tbl_ppr = New ADODB.Recordset


        'frmComputers.RefContactList
        'With BASECOMP
        'If MsgBox("Вы желаете удалить объект? " & vbNewLine & vbNewLine & lstGroups.SelectedNode.Text, vbExclamation + vbYesNo, "Удаление техники") = vbNo Then Exit Sub

        Garant_ia.Open("DELETE FROM Garantia_sis WHERE Id_Comp=" & sSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        garant_comp.Open("DELETE FROM garant_comp WHERE Id_Comp=" & sSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        SOFT_INSTALL.Open("DELETE FROM SOFT_INSTALL WHERE Id_Comp=" & sSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        uLOG.Open("DELETE FROM Update_Log WHERE Id_Comp=" & sSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        USERCOMP.Open("DELETE FROM USER_COMP WHERE Id_Comp=" & sSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        TBLBIOS.Open("DELETE FROM tbl_bios WHERE Id_Comp=" & sSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        CARTRIDG.Open("DELETE FROM CARTRIDG WHERE Id_Comp=" & sSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        CARTRIDG_Z.Open("DELETE FROM CARTRIDG_Z WHERE Id_Comp=" & sSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        AKT_SP_OS3.Open("DELETE FROM AKT_SP_OS3 WHERE Id_Comp=" & sSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        ActOS.Open("DELETE FROM ActOS WHERE Id_Comp=" & sSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        TrebOvanie.Open("DELETE FROM TrebOvanie WHERE Id_Comp=" & sSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        dvig.Open("DELETE FROM dvig WHERE Id_Comp=" & sSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        net_port.Open("DELETE FROM net_port WHERE id_net=" & sSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        tbl_ppr.Open("DELETE FROM net_port WHERE Id_Comp=" & sSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        Dim rs As ADODB.Recordset
        rs = New ADODB.Recordset
        Dim rs1 As ADODB.Recordset
        rs1 = New ADODB.Recordset


        rs.Open("Select id FROM Remont where id_comp = " & sSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            .MoveFirst()
            Do While Not .EOF
                rs1.Open("Delete FROM remonty_plus WHERE id_rem =" & .Fields("id").Value, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                .MoveNext()
            Loop
        End With
        rs.Close()
        rs = Nothing
        rs1.Close()

        Remont.Open("DELETE FROM Remont WHERE Id_Comp=" & sSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        Zametki.Open("DELETE FROM Zametki WHERE Id_Comp=" & sSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)


        'Call clls()

        BASECOMP.Open("DELETE FROM kompy WHERE id=" & sSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        'frmMain.MNUCOMPARE_DB_Click

        CARTRIDG.Close()
        CARTRIDG_Z.Close()
        Remont.Close()
        SOFT_INSTALL.Close()
        Zametki.Close()
        AKT_SP_OS3.Close()
        ActOS.Close()
        TrebOvanie.Close()
        TBLBIOS.Close()
        USERCOMP.Close()
        uLOG.Close()
        dvig.Close()
        net_port.Close()
        BASECOMP.Close()
        tbl_ppr.Close()

        rs1 = New ADODB.Recordset

        rs1.Open("Update kompy set PCL='0' where PCL = " & sSID, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs1.Close()
        rs1 = Nothing

        Exit Sub
Error_:

    End Sub

    Public Function RemoveProyzv(ByVal sMestoName As String)
        On Error GoTo ERR1
        On Error Resume Next

        Dim UC As Long
        Dim asert As String
        If Trim(sMestoName) = "" Or sMestoName = 0 Then
            Exit Function
        End If



        Dim rs As ADODB.Recordset
        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_CPU where Proizv=" & sMestoName, DB7, ADODB.CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1


        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_MB where Proizv=" & sMestoName, DB7, ADODB.CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1


        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM spr_cart where Proizv=" & sMestoName, DB7, ADODB.CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1


        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_SVGA where Proizv=" & sMestoName, DB7, ADODB.CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1

        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_RAM where Proizv=" & sMestoName, DB7, ADODB.CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1


        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_HDD where Proizv=" & sMestoName, DB7, ADODB.CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1

        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_SOUND where Proizv=" & sMestoName, DB7, ADODB.CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1

        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_OPTICAL where Proizv=" & sMestoName, DB7, ADODB.CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1


        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_NET where Proizv=" & sMestoName, DB7, ADODB.CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1

        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_FDD where Proizv=" & sMestoName, DB7, ADODB.CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1


        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_MODEM where Proizv=" & sMestoName, DB7, ADODB.CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1


        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_KEYBOARD where Proizv=" & sMestoName, DB7, ADODB.CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1

        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_MOUSE where Proizv=" & sMestoName, DB7, ADODB.CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1

        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_USB where Proizv=" & sMestoName, DB7, ADODB.CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1


        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_PCI where Proizv=" & sMestoName, DB7, ADODB.CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1

        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_MONITOR where Proizv=" & sMestoName, DB7, ADODB.CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1


        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_ASISTEM where Proizv=" & sMestoName, DB7, ADODB.CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1

        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_IBP where Proizv=" & sMestoName, DB7, ADODB.CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1

        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_FS where Proizv=" & sMestoName, DB7, ADODB.CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1


        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_PRINTER where Proizv=" & sMestoName, DB7, ADODB.CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1

        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_KOPIR where Proizv=" & sMestoName, DB7, ADODB.CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1

        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_SCANER where Proizv=" & sMestoName, DB7, ADODB.CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1


        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_DEV_NET where Proizv=" & sMestoName, DB7, ADODB.CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1


        Dim LNGIniFile As New IniFile(sLANGPATH)
        'LNGIniFile.GetString("MOD_REMOVE", "MSG1", "Найдено")
        If UC > 0 Then
            'users are in this group
            If MsgBox(LNGIniFile.GetString("MOD_REMOVE", "MSG1", "Найдено") & " " & UC & " " & LNGIniFile.GetString("MOD_REMOVE", "MSG2", "производителей в справочниках, Ваше действие может привести к потере данных, желаете продолжить удаление?"), MsgBoxStyle.Exclamation + vbYesNo, ProGramName) = vbNo Then Exit Function

        Else



        End If

        rs = New ADODB.Recordset
        rs.Open("delete FROM SPR_PROIZV WHERE id=" & sMestoName, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs = Nothing

        RemoveProyzv = 1

        Exit Function

        RemoveProyzv = -1


        Exit Function
ERR1:

        MsgBox("Database error: " & vbNewLine & vbNewLine & Err.Description, vbCritical, "Database Error!")
    End Function

    Public Function RemoveBrainch(ByVal sGroupName As String)
        On Error GoTo ERR1
        Dim UC As Long
        Dim LNGIniFile As New IniFile(sLANGPATH)

        'If Trim(sGroupName) = "" Then Exit Function

        Dim rs As ADODB.Recordset

        rs = New ADODB.Recordset
        rs.Open("SELECT COUNT(*) AS total_number FROM kompy WHERE FILIAL='" & sGroupName & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            UC = .Fields("total_number").Value
        End With
        rs.Close()
        rs = Nothing

        'LNGIniFile.GetString("MOD_REMOVE", "MSG1", "Найдено")

        If UC > 0 Then
            'users are in this group
            If MsgBox(LNGIniFile.GetString("MOD_REMOVE", "MSG1", "Найдено") & " " & UC & " " & LNGIniFile.GetString("MOD_REMOVE", "MSG3", "единиц техники в филиале, Ваше действие может привести к потере данных, желаете продолжить удаление -") & " " & sGroupName & " ?" & vbCrLf & LNGIniFile.GetString("MOD_REMOVE", "MSG6", "ри удалении структуры техника не удаляется. Будьте внимательны."), vbExclamation + vbYesNo, ProGramName) = vbNo Then
                Exit Function
            End If


        Else

        End If

        rs = New ADODB.Recordset
        rs.Open("DELETE FROM SPR_FILIAL WHERE FILIAL='" & sGroupName & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs = Nothing

        RemoveBrainch = 1

        Call RefFilTree(frmComputers.lstGroups)
        Call LoadSPR()

        Exit Function


        RemoveBrainch = -1

        'MsgBox("Не найдено филиала " & sGroupName, vbExclamation + vbApplicationModal, "Error!")


        Exit Function
ERR1:


    End Function

    Public Function RemoveDepartment(ByVal sKab As Long)
        On Error GoTo ERR1

        Dim UC As Long

        Dim sFilName, sGroupName As String

        If Trim(sKab) = "" Then
            Exit Function
        End If


        If sKab = 0 Then Exit Function
        If Len(sKab) = 0 Then Exit Function

        Dim rs As ADODB.Recordset
        rs = New ADODB.Recordset
        rs.Open("Select * from SPR_OTD_FILIAL where id =" & sKab, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            sGroupName = .Fields("N_Otd").Value
            sFilName = .Fields("Filial").Value
        End With

        rs.Close()
        rs = Nothing

        rs = New ADODB.Recordset
        rs.Open("SELECT COUNT(*) AS total_number FROM kompy WHERE FILIAL='" & sFilName & "' and mesto='" & sGroupName & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            UC = .Fields("total_number").Value
        End With
        rs.Close()
        rs = Nothing
        Dim LNGIniFile As New IniFile(sLANGPATH)

        If UC > 0 Then
            'users are in this group

            If MsgBox(LNGIniFile.GetString("MOD_REMOVE", "MSG1", "Найдено") & " " & UC & " " & LNGIniFile.GetString("MOD_REMOVE", "MSG4", "единиц техники в отделе, Ваше действие может привести к потере данных, желаете продолжить удаление") & " " & sGroupName & " ?" & vbCrLf & LNGIniFile.GetString("MOD_REMOVE", "MSG6", "При удалении структуры техника не удаляется. Будьте внимательны."), vbExclamation + vbYesNo, ProGramName) = vbNo Then
                Exit Function
            End If

        Else


        End If

        rs = New ADODB.Recordset
        rs.Open("DELETE FROM SPR_OTD_FILIAL WHERE Id=" & sKab, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs = Nothing
        RemoveDepartment = 1

        Call RefFilTree(frmComputers.lstGroups)


        Exit Function

        RemoveDepartment = -1
        MsgBox("Не найден отдел" & " " & sGroupName & "'", vbExclamation + vbApplicationModal, "Error!")


        Exit Function
ERR1:


    End Function

    Public Function RemoveOffice(ByVal sKab As Long)
        On Error GoTo ERR1

        Dim UC As Long

        Dim sBran, sDepart, sOffice As String

        If Trim(sKab) = "" Then Exit Function
        If sKab = 0 Then Exit Function
        If Len(sKab) = 0 Then Exit Function

        Dim rs As ADODB.Recordset
        rs = New ADODB.Recordset
        rs.Open("Select * from SPR_KAB where id =" & sKab, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            sDepart = .Fields("N_M").Value
            sBran = .Fields("N_F").Value
            sOffice = .Fields("Name").Value
        End With

        rs.Close()
        rs = Nothing

        rs = New ADODB.Recordset
        rs.Open("SELECT COUNT(*) AS total_number FROM kompy WHERE FILIAL='" & sBran & "' and mesto='" & sDepart & "' and kabn='" & sOffice & "'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            UC = .Fields("total_number").Value
        End With
        rs.Close()
        rs = Nothing

        Dim LNGIniFile As New IniFile(sLANGPATH)

        If UC > 0 Then

            If MsgBox(LNGIniFile.GetString("MOD_REMOVE", "MSG1", "Найдено") & " " & UC & " " & LNGIniFile.GetString("MOD_REMOVE", "MSG5", "единиц техники в кабинете, Ваше действие может привести к потере данных, желаете продолжить удаление") & " " & sOffice & " ?" & vbCrLf & LNGIniFile.GetString("MOD_REMOVE", "MSG6", "При удалении структуры техника не удаляется. Будьте внимательны."), vbExclamation + vbYesNo, ProGramName) = vbNo Then
                Exit Function
            End If


        Else

        End If

        rs = New ADODB.Recordset
        rs.Open("DELETE FROM SPR_KAB WHERE Id=" & sKab, DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs = Nothing
        RemoveOffice = 1

        Call RefFilTree(frmComputers.lstGroups)


        Exit Function

        RemoveOffice = -1
        MsgBox(LNGIniFile.GetString("MOD_REMOVE", "MSG7", "Не найден кабинет") & " " & sOffice & "'", vbExclamation + vbApplicationModal, "Error!")


        Exit Function
ERR1:


    End Function
End Module
