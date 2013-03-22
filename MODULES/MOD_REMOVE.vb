Module MOD_REMOVE
    Public Sub REMOVE_TEHN(ByVal sSID As String)
        'On Error GoTo error

        On Error Resume Next
        'aaa$ = sContactID

        Dim Garant_ia As Recordset
        Garant_ia = New Recordset
        Dim garant_comp As Recordset
        garant_comp = New Recordset
        Dim Remont As Recordset
        Remont = New Recordset
        Dim SOFT_INSTALL As Recordset
        SOFT_INSTALL = New Recordset
        Dim Zametki As Recordset
        Zametki = New Recordset
        Dim uLOG As Recordset
        uLOG = New Recordset
        Dim USERCOMP As Recordset
        USERCOMP = New Recordset
        Dim TBLBIOS As Recordset
        TBLBIOS = New Recordset
        Dim BASECOMP As Recordset
        BASECOMP = New Recordset
        Dim CARTRIDG As Recordset
        CARTRIDG = New Recordset
        Dim CARTRIDG_Z As Recordset
        CARTRIDG_Z = New Recordset
        Dim AKT_SP_OS3 As Recordset
        AKT_SP_OS3 = New Recordset
        Dim ActOS As Recordset
        ActOS = New Recordset
        Dim TrebOvanie As Recordset
        TrebOvanie = New Recordset
        Dim dvig As Recordset
        dvig = New Recordset
        Dim net_port As Recordset
        net_port = New Recordset
        Dim tbl_ppr As Recordset
        tbl_ppr = New Recordset


        'frmComputers.RefContactList
        'With BASECOMP
        'If MsgBox("Вы желаете удалить объект? " & vbNewLine & vbNewLine & lstGroups.SelectedNode.Text, vbExclamation + vbYesNo, "Удаление техники") = vbNo Then Exit Sub

        Garant_ia.Open("DELETE FROM Garantia_sis WHERE Id_Comp=" & sSID, DB7, CursorTypeEnum.adOpenDynamic,
                       LockTypeEnum.adLockOptimistic)
        garant_comp.Open("DELETE FROM garant_comp WHERE Id_Comp=" & sSID, DB7, CursorTypeEnum.adOpenDynamic,
                         LockTypeEnum.adLockOptimistic)
        SOFT_INSTALL.Open("DELETE FROM SOFT_INSTALL WHERE Id_Comp=" & sSID, DB7, CursorTypeEnum.adOpenDynamic,
                          LockTypeEnum.adLockOptimistic)
        uLOG.Open("DELETE FROM Update_Log WHERE Id_Comp=" & sSID, DB7, CursorTypeEnum.adOpenDynamic,
                  LockTypeEnum.adLockOptimistic)
        USERCOMP.Open("DELETE FROM USER_COMP WHERE Id_Comp=" & sSID, DB7, CursorTypeEnum.adOpenDynamic,
                      LockTypeEnum.adLockOptimistic)
        TBLBIOS.Open("DELETE FROM tbl_bios WHERE Id_Comp=" & sSID, DB7, CursorTypeEnum.adOpenDynamic,
                     LockTypeEnum.adLockOptimistic)
        CARTRIDG.Open("DELETE FROM CARTRIDG WHERE Id_Comp=" & sSID, DB7, CursorTypeEnum.adOpenDynamic,
                      LockTypeEnum.adLockOptimistic)
        CARTRIDG_Z.Open("DELETE FROM CARTRIDG_Z WHERE Id_Comp=" & sSID, DB7, CursorTypeEnum.adOpenDynamic,
                        LockTypeEnum.adLockOptimistic)
        AKT_SP_OS3.Open("DELETE FROM AKT_SP_OS3 WHERE Id_Comp=" & sSID, DB7, CursorTypeEnum.adOpenDynamic,
                        LockTypeEnum.adLockOptimistic)
        ActOS.Open("DELETE FROM ActOS WHERE Id_Comp=" & sSID, DB7, CursorTypeEnum.adOpenDynamic,
                   LockTypeEnum.adLockOptimistic)
        TrebOvanie.Open("DELETE FROM TrebOvanie WHERE Id_Comp=" & sSID, DB7, CursorTypeEnum.adOpenDynamic,
                        LockTypeEnum.adLockOptimistic)
        dvig.Open("DELETE FROM dvig WHERE Id_Comp=" & sSID, DB7, CursorTypeEnum.adOpenDynamic,
                  LockTypeEnum.adLockOptimistic)

        net_port.Open("DELETE FROM net_port WHERE id_net=" & sSID, DB7, CursorTypeEnum.adOpenDynamic,
                      LockTypeEnum.adLockOptimistic)
        tbl_ppr.Open("DELETE FROM net_port WHERE Id_Comp=" & sSID, DB7, CursorTypeEnum.adOpenDynamic,
                     LockTypeEnum.adLockOptimistic)

        Dim rs As Recordset
        rs = New Recordset
        Dim rs1 As Recordset
        rs1 = New Recordset


        rs.Open("Select id FROM Remont where id_comp = " & sSID, DB7, CursorTypeEnum.adOpenDynamic,
                LockTypeEnum.adLockOptimistic)

        With rs
            .MoveFirst()
            Do While Not .EOF
                rs1.Open("Delete FROM remonty_plus WHERE id_rem =" & .Fields("id").Value, DB7,
                         CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)
                .MoveNext()
            Loop
        End With
        rs.Close()
        rs = Nothing
        rs1.Close()

        Remont.Open("DELETE FROM Remont WHERE Id_Comp=" & sSID, DB7, CursorTypeEnum.adOpenDynamic,
                    LockTypeEnum.adLockOptimistic)
        Zametki.Open("DELETE FROM Zametki WHERE Id_Comp=" & sSID, DB7, CursorTypeEnum.adOpenDynamic,
                     LockTypeEnum.adLockOptimistic)


        'Call clls()

        BASECOMP.Open("DELETE FROM kompy WHERE id=" & sSID, DB7, CursorTypeEnum.adOpenDynamic,
                      LockTypeEnum.adLockOptimistic)

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

        rs1 = New Recordset

        rs1.Open("Update kompy set PCL='0' where PCL = " & sSID, DB7, CursorTypeEnum.adOpenDynamic,
                 LockTypeEnum.adLockOptimistic)
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
            GoTo ERR1
        End If


        Dim rs As Recordset
        rs = New Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_CPU where Proizv=" & sMestoName, DB7, CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1


        rs = New Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_MB where Proizv=" & sMestoName, DB7, CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1


        rs = New Recordset
        rs.Open("SELECT count(*) as t_n FROM spr_cart where Proizv=" & sMestoName, DB7, CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1


        rs = New Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_SVGA where Proizv=" & sMestoName, DB7, CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1

        rs = New Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_RAM where Proizv=" & sMestoName, DB7, CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1


        rs = New Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_HDD where Proizv=" & sMestoName, DB7, CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1

        rs = New Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_SOUND where Proizv=" & sMestoName, DB7, CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1

        rs = New Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_OPTICAL where Proizv=" & sMestoName, DB7, CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1


        rs = New Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_NET where Proizv=" & sMestoName, DB7, CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1

        rs = New Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_FDD where Proizv=" & sMestoName, DB7, CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1


        rs = New Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_MODEM where Proizv=" & sMestoName, DB7, CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1


        rs = New Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_KEYBOARD where Proizv=" & sMestoName, DB7, CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1

        rs = New Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_MOUSE where Proizv=" & sMestoName, DB7, CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1

        rs = New Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_USB where Proizv=" & sMestoName, DB7, CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1


        rs = New Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_PCI where Proizv=" & sMestoName, DB7, CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1

        rs = New Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_MONITOR where Proizv=" & sMestoName, DB7, CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1


        rs = New Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_ASISTEM where Proizv=" & sMestoName, DB7, CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1

        rs = New Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_IBP where Proizv=" & sMestoName, DB7, CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1

        rs = New Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_FS where Proizv=" & sMestoName, DB7, CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1


        rs = New Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_PRINTER where Proizv=" & sMestoName, DB7, CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1

        rs = New Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_KOPIR where Proizv=" & sMestoName, DB7, CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1

        rs = New Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_SCANER where Proizv=" & sMestoName, DB7, CursorTypeEnum.adOpenKeyset)
        With rs
            asert = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If asert > 0 Then UC = UC + 1


        rs = New Recordset
        rs.Open("SELECT count(*) as t_n FROM SPR_DEV_NET where Proizv=" & sMestoName, DB7, CursorTypeEnum.adOpenKeyset)
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
            If _
                MsgBox(
                    LNGIniFile.GetString("MOD_REMOVE", "MSG1", "Найдено") & " " & UC & " " &
                    LNGIniFile.GetString("MOD_REMOVE", "MSG2",
                                         "производителей в справочниках, Ваше действие может привести к потере данных, желаете продолжить удаление?"),
                    MsgBoxStyle.Exclamation + vbYesNo, ProGramName) = vbNo Then GoTo ERR1

        Else


        End If

        rs = New Recordset
        rs.Open("delete FROM SPR_PROIZV WHERE id=" & sMestoName, DB7, CursorTypeEnum.adOpenDynamic,
                LockTypeEnum.adLockOptimistic)
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

        Dim rs As Recordset

        rs = New Recordset
        rs.Open("SELECT COUNT(*) AS total_number FROM kompy WHERE FILIAL='" & sGroupName & "'", DB7,
                CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            UC = .Fields("total_number").Value
        End With
        rs.Close()
        rs = Nothing

        'LNGIniFile.GetString("MOD_REMOVE", "MSG1", "Найдено")

        If UC > 0 Then
            'users are in this group
            If _
                MsgBox(
                    LNGIniFile.GetString("MOD_REMOVE", "MSG1", "Найдено") & " " & UC & " " &
                    LNGIniFile.GetString("MOD_REMOVE", "MSG3",
                                         "единиц техники в филиале, Ваше действие может привести к потере данных, желаете продолжить удаление -") &
                    " " & sGroupName & " ?" & vbCrLf &
                    LNGIniFile.GetString("MOD_REMOVE", "MSG6",
                                         "ри удалении структуры техника не удаляется. Будьте внимательны."),
                    vbExclamation + vbYesNo, ProGramName) = vbNo Then
                ' Exit Function
                GoTo ERR1
            End If


        Else

        End If

        rs = New Recordset
        rs.Open("DELETE FROM SPR_FILIAL WHERE FILIAL='" & sGroupName & "'", DB7, CursorTypeEnum.adOpenDynamic,
                LockTypeEnum.adLockOptimistic)
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
            GoTo ERR1
        End If


        If sKab = 0 Then GoTo ERR1
        If Len(sKab) = 0 Then GoTo ERR1

        Dim rs As Recordset
        rs = New Recordset
        rs.Open("Select * from SPR_OTD_FILIAL where id =" & sKab, DB7, CursorTypeEnum.adOpenDynamic,
                LockTypeEnum.adLockOptimistic)

        With rs
            sGroupName = .Fields("N_Otd").Value
            sFilName = .Fields("Filial").Value
        End With

        rs.Close()
        rs = Nothing

        rs = New Recordset
        rs.Open(
            "SELECT COUNT(*) AS total_number FROM kompy WHERE FILIAL='" & sFilName & "' and mesto='" & sGroupName & "'",
            DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            UC = .Fields("total_number").Value
        End With
        rs.Close()
        rs = Nothing
        Dim LNGIniFile As New IniFile(sLANGPATH)

        If UC > 0 Then
            'users are in this group

            If _
                MsgBox(
                    LNGIniFile.GetString("MOD_REMOVE", "MSG1", "Найдено") & " " & UC & " " &
                    LNGIniFile.GetString("MOD_REMOVE", "MSG4",
                                         "единиц техники в отделе, Ваше действие может привести к потере данных, желаете продолжить удаление") &
                    " " & sGroupName & " ?" & vbCrLf &
                    LNGIniFile.GetString("MOD_REMOVE", "MSG6",
                                         "При удалении структуры техника не удаляется. Будьте внимательны."),
                    vbExclamation + vbYesNo, ProGramName) = vbNo Then
                GoTo ERR1
            End If

        Else


        End If

        rs = New Recordset
        rs.Open("DELETE FROM SPR_OTD_FILIAL WHERE Id=" & sKab, DB7, CursorTypeEnum.adOpenDynamic,
                LockTypeEnum.adLockOptimistic)
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

        If Trim(sKab) = "" Then GoTo ERR1
        If sKab = 0 Then GoTo ERR1
        If Len(sKab) = 0 Then GoTo ERR1

        Dim rs As Recordset
        rs = New Recordset
        rs.Open("Select * from SPR_KAB where id =" & sKab, DB7, CursorTypeEnum.adOpenDynamic,
                LockTypeEnum.adLockOptimistic)

        With rs
            sDepart = .Fields("N_M").Value
            sBran = .Fields("N_F").Value
            sOffice = .Fields("Name").Value
        End With

        rs.Close()
        rs = Nothing

        rs = New Recordset
        rs.Open(
            "SELECT COUNT(*) AS total_number FROM kompy WHERE FILIAL='" & sBran & "' and mesto='" & sDepart &
            "' and kabn='" & sOffice & "'", DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            UC = .Fields("total_number").Value
        End With
        rs.Close()
        rs = Nothing

        Dim LNGIniFile As New IniFile(sLANGPATH)

        If UC > 0 Then

            If _
                MsgBox(
                    LNGIniFile.GetString("MOD_REMOVE", "MSG1", "Найдено") & " " & UC & " " &
                    LNGIniFile.GetString("MOD_REMOVE", "MSG5",
                                         "единиц техники в кабинете, Ваше действие может привести к потере данных, желаете продолжить удаление") &
                    " " & sOffice & " ?" & vbCrLf &
                    LNGIniFile.GetString("MOD_REMOVE", "MSG6",
                                         "При удалении структуры техника не удаляется. Будьте внимательны."),
                    vbExclamation + vbYesNo, ProGramName) = vbNo Then
                GoTo ERR1
            End If


        Else

        End If

        rs = New Recordset
        rs.Open("DELETE FROM SPR_KAB WHERE Id=" & sKab, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)
        rs = Nothing
        RemoveOffice = 1

        Call RefFilTree(frmComputers.lstGroups)


        Exit Function

        RemoveOffice = -1
        MsgBox(LNGIniFile.GetString("MOD_REMOVE", "MSG7", "Не найден кабинет") & " " & sOffice & "'",
               vbExclamation + vbApplicationModal, "Error!")


        Exit Function
ERR1:
    End Function
End Module
