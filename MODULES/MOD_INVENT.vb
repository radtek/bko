Module MOD_INVENT


    Public Sub INVENT()

        Dim  uname As String
        Dim LNGIniFile As New IniFile(sLANGPATH)


        Dim TEH1 As String
        Dim TEH2 As String
        Dim TEH3 As String
        Dim TEH4 As String
        Dim TEH5 As String
        Dim TEH6 As String
        Dim TEH7 As String
        Dim TEH8 As String
        Dim TEH9 As String
        Dim TEH10 As String
        Dim TEH11 As String
        Dim TEH12 As String
        Dim TEH13 As String
        Dim TEH14 As String
        Dim TEH15 As String
        Dim TEH16 As String
        Dim TEH17 As String
        Dim TEH18 As String

        Dim rs As ADODB.Recordset
        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM kompy where tiptehn='PC'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            TEH1 = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM kompy where tiptehn='Printer'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            TEH2 = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM kompy where tiptehn='MFU'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            TEH3 = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM kompy where tiptehn='KOpir'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            TEH4 = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM kompy where tiptehn='OT'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            TEH5 = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM kompy where tiptehn='PHOTO'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            TEH6 = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing


        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM kompy where tiptehn='FAX'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            TEH7 = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM kompy where tiptehn='PHONE'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            TEH8 = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM kompy where tiptehn='ZIP'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            TEH9 = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM kompy where tiptehn='SCANER'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            TEH10 = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM kompy where tiptehn='NET'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            TEH11 = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM kompy where tiptehn='MONITOR'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            TEH12 = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM kompy where tiptehn='USB'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            TEH13 = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM kompy where tiptehn='SOUND'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            TEH14 = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM kompy where tiptehn='IBP'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            TEH15 = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM kompy where tiptehn='FS'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            TEH16 = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM kompy where tiptehn='KEYB'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            TEH17 = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        rs = New ADODB.Recordset
        rs.Open("SELECT count(*) as t_n FROM kompy where tiptehn='MOUSE'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        With rs
            TEH18 = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing


        'Dim rs As ADODB.Recordset
        rs = New ADODB.Recordset
        rs.Open("SELECT * FROM CONFIGURE", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)


        With rs
            If Not IsDBNull(.Fields("ORG")) Then uname = .Fields("ORG").Value
        End With
        rs.Close()
        rs = Nothing


         Select sOfficePACK

            Case "OpenOffice.org"

                Dim oSM As Object                 'Root object for accessing OpenOffice FROM VB
                Dim oDesk, oDoc As Object 'First objects FROM the API
                Dim arg(-1) As Object                 'Ignore it for the moment !
                'Dim mmerge As Object
                Dim objCoreReflection As Object ' objects from OOo API 

                'Instanciate OOo : this line is mandatory with VB for OOo API
                oSM = CreateObject("com.sun.star.ServiceManager")
                'Create the first and most important service
                objCoreReflection = oSM.createInstance("com.sun.star.reflection.CoreReflection")

                oDesk = oSM.createInstance("com.sun.star.frame.Desktop")
                'Create a new doc

                oDoc = oDesk.loadComponentFROMURL("private:factory/swriter", "_blank", 0, arg)

                ' jon code
                Dim objText As Object, objCursor As Object

                Dim objTable As Object ' objects from OOo API 
                Dim objRows, objRow As Object

                objText = oDoc.GetText
                objCursor = objText.createTextCursor

                ' replace all
                ' Dim oSrch As Object


                objCursor.setPropertyValue("CharColor", 255)
                objCursor.setPropertyValue("CharShadowed", True)

                'LNGIniFile.GetString("MOD_INVENT", "MSG1", "Количество единиц техники по типам:")


                objText.insertString(objCursor, LNGIniFile.GetString("MOD_INVENT", "MSG1", "Количество единиц техники по типам:") & " " & vbLf, False)

                objText.insertString(objCursor, " " & vbLf, False)
                objCursor.setPropertyValue("CharColor", 255)
                objCursor.setPropertyValue("CharShadowed", True)
                objText.insertString(objCursor, LNGIniFile.GetString("MOD_INVENT", "MSG2", "Организация:") & " " & uname & vbLf, False)
                objText.insertString(objCursor, " " & vbLf, False)
                'objText.insertString objCursor, " " & vbLf, False

                objTable = oDoc.createInstance("com.sun.star.text.TextTable")
                objTable.Initialize(19, 2)

                'Insert the table
                objText.insertTextContent(objCursor, objTable, False)

                'Get first row
                objRows = objTable.GetRows
                objRow = objRows.getByIndex(0)

                'Set the table background color
                'objTable.setPropertyValue("BackTransparent", False)
                'objTable.setPropertyValue("BackColor", Color.White)

                objText.insertString(objCursor, " " & vbLf, False)
                objCursor.setPropertyValue("CharColor", 255)
                objCursor.setPropertyValue("CharShadowed", True)

                insertIntoCell("A1", LNGIniFile.GetString("MOD_INVENT", "MSG3", "Тип техники"), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                insertIntoCell("B1", LNGIniFile.GetString("MOD_INVENT", "MSG4", "Кол-во"), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable

                insertIntoCell("A2", LNGIniFile.GetString("MOD_INVENT", "MSG5", "Компьютеров"), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                insertIntoCell("B2", TEH1, objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable

                insertIntoCell("A3", LNGIniFile.GetString("MOD_INVENT", "MSG6", "Принтеров"), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                insertIntoCell("B3", TEH2, objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable

                insertIntoCell("A4", LNGIniFile.GetString("MOD_INVENT", "MSG7", "МФУ"), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                insertIntoCell("B4", TEH3, objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable

                insertIntoCell("A5", LNGIniFile.GetString("MOD_INVENT", "MSG8", "Копиров"), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                insertIntoCell("B5", TEH4, objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable

                insertIntoCell("A6", LNGIniFile.GetString("MOD_INVENT", "MSG9", "Другое"), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                insertIntoCell("B6", TEH5, objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable

                insertIntoCell("A7", LNGIniFile.GetString("MOD_INVENT", "MSG10", "Фотоаппаратов"), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                insertIntoCell("B7", TEH6, objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable

                insertIntoCell("A8", LNGIniFile.GetString("MOD_INVENT", "MSG11", "Факсов"), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                insertIntoCell("B8", TEH7, objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable

                insertIntoCell("A9", LNGIniFile.GetString("MOD_INVENT", "MSG12", "Телефонов"), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                insertIntoCell("B9", TEH8, objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable

                insertIntoCell("A10", LNGIniFile.GetString("MOD_INVENT", "MSG13", "ZIP"), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                insertIntoCell("B10", TEH9, objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable

                insertIntoCell("A11", LNGIniFile.GetString("MOD_INVENT", "MSG14", "Сканеров"), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                insertIntoCell("B11", TEH10, objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable

                insertIntoCell("A12", LNGIniFile.GetString("MOD_INVENT", "MSG15", "Сетевого оборудования"), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                insertIntoCell("B12", TEH11, objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable

                insertIntoCell("A13", LNGIniFile.GetString("MOD_INVENT", "MSG16", "Мониторов"), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                insertIntoCell("B13", TEH12, objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable

                insertIntoCell("A14", LNGIniFile.GetString("MOD_INVENT", "MSG17", "USB устройств"), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                insertIntoCell("B14", TEH13, objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable

                insertIntoCell("A15", LNGIniFile.GetString("MOD_INVENT", "MSG18", "Акустики"), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                insertIntoCell("B15", TEH14, objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable

                insertIntoCell("A16", LNGIniFile.GetString("MOD_INVENT", "MSG19", "Источников бесперебойного питания"), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                insertIntoCell("B16", TEH15, objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable

                insertIntoCell("A17", LNGIniFile.GetString("MOD_INVENT", "MSG20", "Сетевых фильтров"), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                insertIntoCell("B17", TEH16, objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable

                insertIntoCell("A18", LNGIniFile.GetString("MOD_INVENT", "MSG21", "Клавиатур"), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                insertIntoCell("B18", TEH17, objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable

                insertIntoCell("A19", LNGIniFile.GetString("MOD_INVENT", "MSG22", "Мышей"), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                insertIntoCell("B19", TEH18, objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable


                'objText.insertString objCursor, " " & vbLf, False
                objText.insertString(objCursor, " " & vbLf, False)
                objText.insertString(objCursor, LNGIniFile.GetString("MOD_INVENT", "MSG23", "Из них по филиалам (отделам)") & vbLf, False)
                objText.insertString(objCursor, " " & vbLf, False)
                'objText.insertString objCursor, " " & vbLf, False

                Dim zint As Integer = 1
                Dim intj As Integer = 2


                Dim rs1 As ADODB.Recordset
                rs = New ADODB.Recordset
                rs.Open("SELECT FILIAL FROM SPR_FILIAL", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                With rs
                    .MoveFirst()
                    Do While Not .EOF

                        rs1 = New ADODB.Recordset
                        rs1.Open("SELECT count(*) as t_n FROM kompy where filial ='" & .Fields("filial").Value & "' AND tiptehn='PC'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                        zint = 1

                        With rs1
                            TEH1 = .Fields("t_n").Value
                            If .Fields("t_n").Value <> 0 Then
                                zint = zint + 1
                            End If

                        End With
                        rs1.Close()
                        rs1 = Nothing

                        rs1 = New ADODB.Recordset
                        rs1.Open("SELECT count(*) as t_n FROM kompy where filial ='" & .Fields("filial").Value & "' AND tiptehn='Printer'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                        With rs1
                            TEH2 = .Fields("t_n").Value
                            If .Fields("t_n").Value <> 0 Then
                                zint = zint + 1
                            End If
                        End With
                        rs1.Close()
                        rs1 = Nothing

                        rs1 = New ADODB.Recordset
                        rs1.Open("SELECT count(*) as t_n FROM kompy where filial ='" & .Fields("filial").Value & "' AND tiptehn='MFU'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                        With rs1
                            TEH3 = .Fields("t_n").Value
                            If .Fields("t_n").Value <> 0 Then
                                zint = zint + 1
                            End If
                        End With
                        rs1.Close()
                        rs1 = Nothing

                        rs1 = New ADODB.Recordset
                        rs1.Open("SELECT count(*) as t_n FROM kompy where filial ='" & .Fields("filial").Value & "' AND tiptehn='KOpir'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                        With rs1
                            TEH4 = .Fields("t_n").Value
                            If .Fields("t_n").Value <> 0 Then
                                zint = zint + 1
                            End If
                        End With
                        rs1.Close()
                        rs1 = Nothing

                        rs1 = New ADODB.Recordset
                        rs1.Open("SELECT count(*) as t_n FROM kompy where filial ='" & .Fields("filial").Value & "' AND tiptehn='OT'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                        With rs1
                            TEH5 = .Fields("t_n").Value
                            If .Fields("t_n").Value <> 0 Then
                                zint = zint + 1
                            End If
                        End With
                        rs1.Close()
                        rs1 = Nothing

                        rs1 = New ADODB.Recordset
                        rs1.Open("SELECT count(*) as t_n FROM kompy where filial ='" & .Fields("filial").Value & "' AND tiptehn='PHOTO'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                        With rs1
                            TEH6 = .Fields("t_n").Value
                            If .Fields("t_n").Value <> 0 Then
                                zint = zint + 1
                            End If
                        End With
                        rs1.Close()
                        rs1 = Nothing


                        rs1 = New ADODB.Recordset
                        rs1.Open("SELECT count(*) as t_n FROM kompy where filial ='" & .Fields("filial").Value & "' AND tiptehn='FAX'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                        With rs1
                            TEH7 = .Fields("t_n").Value
                            If .Fields("t_n").Value <> 0 Then
                                zint = zint + 1
                            End If
                        End With
                        rs1.Close()
                        rs1 = Nothing

                        rs1 = New ADODB.Recordset
                        rs1.Open("SELECT count(*) as t_n FROM kompy where filial ='" & .Fields("filial").Value & "' AND tiptehn='PHONE'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                        With rs1
                            TEH8 = .Fields("t_n").Value
                            If .Fields("t_n").Value <> 0 Then
                                zint = zint + 1
                            End If
                        End With
                        rs1.Close()
                        rs1 = Nothing

                        rs1 = New ADODB.Recordset
                        rs1.Open("SELECT count(*) as t_n FROM kompy where filial ='" & .Fields("filial").Value & "' AND tiptehn='ZIP'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                        With rs1
                            TEH9 = .Fields("t_n").Value
                            If .Fields("t_n").Value <> 0 Then
                                zint = zint + 1
                            End If
                        End With
                        rs1.Close()
                        rs1 = Nothing

                        rs1 = New ADODB.Recordset
                        rs1.Open("SELECT count(*) as t_n FROM kompy where filial ='" & .Fields("filial").Value & "' AND tiptehn='SCANER'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                        With rs1
                            TEH10 = .Fields("t_n").Value
                            If .Fields("t_n").Value <> 0 Then
                                zint = zint + 1
                            End If
                        End With
                        rs1.Close()
                        rs1 = Nothing

                        rs1 = New ADODB.Recordset
                        rs1.Open("SELECT count(*) as t_n FROM kompy where filial ='" & .Fields("filial").Value & "' AND tiptehn='NET'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                        With rs1
                            TEH11 = .Fields("t_n").Value
                            If .Fields("t_n").Value <> 0 Then
                                zint = zint + 1
                            End If
                        End With
                        rs1.Close()
                        rs1 = Nothing

                        rs1 = New ADODB.Recordset
                        rs1.Open("SELECT count(*) as t_n FROM kompy where filial ='" & .Fields("filial").Value & "' AND tiptehn='MONITOR'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                        With rs1
                            TEH12 = .Fields("t_n").Value
                            If .Fields("t_n").Value <> 0 Then
                                zint = zint + 1
                            End If
                        End With
                        rs1.Close()
                        rs1 = Nothing

                        rs1 = New ADODB.Recordset
                        rs1.Open("SELECT count(*) as t_n FROM kompy where filial ='" & .Fields("filial").Value & "' AND tiptehn='USB'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                        With rs1
                            TEH13 = .Fields("t_n").Value
                            If .Fields("t_n").Value <> 0 Then
                                zint = zint + 1
                            End If
                        End With
                        rs1.Close()
                        rs1 = Nothing

                        rs1 = New ADODB.Recordset
                        rs1.Open("SELECT count(*) as t_n FROM kompy where filial ='" & .Fields("filial").Value & "' AND tiptehn='SOUND'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                        With rs1
                            TEH14 = .Fields("t_n").Value
                            If .Fields("t_n").Value <> 0 Then
                                zint = zint + 1
                            End If
                        End With
                        rs1.Close()
                        rs1 = Nothing

                        rs1 = New ADODB.Recordset
                        rs1.Open("SELECT count(*) as t_n FROM kompy where filial ='" & .Fields("filial").Value & "' AND tiptehn='IBP'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                        With rs1
                            TEH15 = .Fields("t_n").Value
                            If .Fields("t_n").Value <> 0 Then
                                zint = zint + 1
                            End If
                        End With
                        rs1.Close()
                        rs1 = Nothing

                        rs1 = New ADODB.Recordset
                        rs1.Open("SELECT count(*) as t_n FROM kompy where filial ='" & .Fields("filial").Value & "' AND tiptehn='FS'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                        With rs1
                            TEH16 = .Fields("t_n").Value
                            If .Fields("t_n").Value <> 0 Then
                                zint = zint + 1
                            End If
                        End With
                        rs1.Close()
                        rs1 = Nothing

                        rs1 = New ADODB.Recordset
                        rs1.Open("SELECT count(*) as t_n FROM kompy where filial ='" & .Fields("filial").Value & "' AND tiptehn='KEYB'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                        With rs1
                            TEH17 = .Fields("t_n").Value
                            If .Fields("t_n").Value <> 0 Then
                                zint = zint + 1
                            End If
                        End With
                        rs1.Close()
                        rs1 = Nothing

                        rs1 = New ADODB.Recordset
                        rs1.Open("SELECT count(*) as t_n FROM kompy where filial ='" & .Fields("filial").Value & "' AND tiptehn='MOUSE'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                        With rs1
                            TEH18 = .Fields("t_n").Value
                            If .Fields("t_n").Value <> 0 Then
                                zint = zint + 1
                            End If
                        End With
                        rs1.Close()
                        rs1 = Nothing


                        objText.insertString(objCursor, LNGIniFile.GetString("MOD_INVENT", "MSG24", "Филиал (отдел):") & " " & .Fields("filial").Value & vbLf, False)


                        'objText.insertString objCursor, " " & vbLf, False
                        'objText.insertString objCursor, " " & vbLf, False
                        objTable = oDoc.createInstance("com.sun.star.text.TextTable")
                        objTable.Initialize(zint, 2)

                        'Insert the table
                        objText.insertTextContent(objCursor, objTable, False)

                        'Get first row
                        objRows = objTable.GetRows
                        objRow = objRows.getByIndex(0)

                        'Set the table background color
                        'objTable.setPropertyValue("BackTransparent", False)
                        'objTable.setPropertyValue("BackColor", Color.White)

                        objText.insertString(objCursor, " " & vbLf, False)
                        objCursor.setPropertyValue("CharColor", 255)
                        objCursor.setPropertyValue("CharShadowed", True)

                        insertIntoCell("A1", LNGIniFile.GetString("MOD_INVENT", "MSG3", "Тип техники"), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                        insertIntoCell("B1", LNGIniFile.GetString("MOD_INVENT", "MSG4", "Кол-во"), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable


                        intj = 2

                        If TEH1 <> 0 Then
                            insertIntoCell("A" & intj, LNGIniFile.GetString("MOD_INVENT", "MSG5", "Компьютеров"), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            insertIntoCell("B" & intj, TEH1, objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            intj = intj + 1
                        End If

                        If TEH2 <> 0 Then
                            insertIntoCell("A" & intj, LNGIniFile.GetString("MOD_INVENT", "MSG6", "Принтеров"), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            insertIntoCell("B" & intj, TEH2, objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            intj = intj + 1
                        End If

                        If TEH3 <> 0 Then
                            insertIntoCell("A" & intj, LNGIniFile.GetString("MOD_INVENT", "MSG7", "МФУ"), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            insertIntoCell("B" & intj, TEH3, objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            intj = intj + 1
                        End If

                        If TEH4 <> 0 Then
                            insertIntoCell("A" & intj, LNGIniFile.GetString("MOD_INVENT", "MSG8", "Копиров"), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            insertIntoCell("B" & intj, TEH4, objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            intj = intj + 1
                        End If

                        If TEH5 <> 0 Then
                            insertIntoCell("A" & intj, LNGIniFile.GetString("MOD_INVENT", "MSG9", "Другое"), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            insertIntoCell("B" & intj, TEH5, objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            intj = intj + 1
                        End If

                        If TEH6 <> 0 Then
                            insertIntoCell("A" & intj, LNGIniFile.GetString("MOD_INVENT", "MSG10", "Фотоаппаратов"), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            insertIntoCell("B" & intj, TEH6, objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            intj = intj + 1
                        End If

                        If TEH7 <> 0 Then
                            insertIntoCell("A" & intj, LNGIniFile.GetString("MOD_INVENT", "MSG11", "Факсов"), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            insertIntoCell("B" & intj, TEH7, objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            intj = intj + 1
                        End If

                        If TEH8 <> 0 Then
                            insertIntoCell("A" & intj, LNGIniFile.GetString("MOD_INVENT", "MSG12", "Телефонов"), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            insertIntoCell("B" & intj, TEH8, objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            intj = intj + 1
                        End If

                        If TEH9 <> 0 Then
                            insertIntoCell("A" & intj, LNGIniFile.GetString("MOD_INVENT", "MSG13", "ZIP"), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            insertIntoCell("B" & intj, TEH9, objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            intj = intj + 1
                        End If

                        If TEH10 <> 0 Then
                            insertIntoCell("A" & intj, LNGIniFile.GetString("MOD_INVENT", "MSG14", "Сканеров"), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            insertIntoCell("B" & intj, TEH10, objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            intj = intj + 1
                        End If

                        If TEH11 <> 0 Then
                            insertIntoCell("A" & intj, LNGIniFile.GetString("MOD_INVENT", "MSG15", "Сетевого оборудования"), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            insertIntoCell("B" & intj, TEH11, objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            intj = intj + 1
                        End If

                        If TEH12 <> 0 Then
                            insertIntoCell("A" & intj, LNGIniFile.GetString("MOD_INVENT", "MSG16", "Мониторов"), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            insertIntoCell("B" & intj, TEH12, objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            intj = intj + 1
                        End If

                        If TEH13 <> 0 Then
                            insertIntoCell("A" & intj, LNGIniFile.GetString("MOD_INVENT", "MSG17", "USB устройств"), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            insertIntoCell("B" & intj, TEH13, objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            intj = intj + 1
                        End If

                        If TEH14 <> 0 Then
                            insertIntoCell("A" & intj, LNGIniFile.GetString("MOD_INVENT", "MSG18", "Акустики"), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            insertIntoCell("B" & intj, TEH14, objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            intj = intj + 1
                        End If

                        If TEH15 <> 0 Then
                            insertIntoCell("A" & intj, LNGIniFile.GetString("MOD_INVENT", "MSG19", "Источников бесперебойного питания"), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            insertIntoCell("B" & intj, TEH15, objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            intj = intj + 1
                        End If

                        If TEH16 <> 0 Then
                            insertIntoCell("A" & intj, LNGIniFile.GetString("MOD_INVENT", "MSG20", "Сетевых фильтров"), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            insertIntoCell("B" & intj, TEH16, objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            intj = intj + 1
                        End If

                        If TEH17 <> 0 Then
                            insertIntoCell("A" & intj, LNGIniFile.GetString("MOD_INVENT", "MSG21", "Клавиатур"), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            insertIntoCell("B" & intj, TEH17, objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            intj = intj + 1
                        End If

                        If TEH18 <> 0 Then
                            insertIntoCell("A" & intj, LNGIniFile.GetString("MOD_INVENT", "MSG22", "Мышей"), objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            insertIntoCell("B" & intj, TEH18, objTable) 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            intj = intj + 1
                        End If

                        objText.insertString(objCursor, " " & vbLf, False)
                        .MoveNext()
                        ''DoEvents
                    Loop
                End With
                rs.Close()
                rs = Nothing





                'Dim rs As ADODB.Recordset
                rs = New ADODB.Recordset
                rs.Open("SELECT * FROM CONFIGURE", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                With rs
                    If Not IsDBNull(.Fields("SISADM").Value) Then uname = .Fields("SISADM").Value
                End With
                rs.Close()
                rs = Nothing
                objText.insertString(objCursor, uname & vbLf, False)

            Case Else

                Dim oWord As Word.Application
                Dim oDoc As Word.Document
                Dim oTable As Word.Table
                Dim oPara1 As Word.Paragraph ', oPara2 As Word.Paragraph

                'Dim oPara3 As Word.Paragraph, oPara4 As Word.Paragraph
                'Dim oRng As Word.Range
                'Dim oShape As Word.InlineShape
                'Dim oChart As Object
                'Dim Pos As Double

                oWord = CreateObject("Word.Application")
                oWord.Visible = True
                oDoc = oWord.Documents.Add

                'Insert a paragraph at the beginning of the document.
                oPara1 = oDoc.Content.Paragraphs.Add

                oPara1.Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG1", "Количество единиц техники по типам:") & " "
                oPara1.Range.Font.Bold = True
                oPara1.Format.SpaceAfter = 24    '24 pt spacing after paragraph.
                oPara1.Range.InsertParagraphAfter()


                oPara1.Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG2", "Организация:") & " " & uname
                oPara1.Range.Font.Bold = True
                oPara1.Format.SpaceAfter = 24    '24 pt spacing after paragraph.
                oPara1.Range.InsertParagraphAfter()

                oTable = oDoc.Tables.Add(oDoc.Bookmarks.Item("\endofdoc").Range, 19, 2)
                oTable.Range.ParagraphFormat.SpaceAfter = 6

                oTable.Cell(1, 1).Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG3", "Тип техники")
                oTable.Cell(1, 2).Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG4", "Кол-во")

                oTable.Cell(2, 1).Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG5", "Компьютеров")
                oTable.Cell(2, 2).Range.Text = TEH1
                oTable.Cell(3, 1).Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG6", "Принтеров")
                oTable.Cell(3, 2).Range.Text = TEH2
                oTable.Cell(4, 1).Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG7", "МФУ")
                oTable.Cell(4, 2).Range.Text = TEH3

                oTable.Cell(5, 1).Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG8", "Копиров")
                oTable.Cell(5, 2).Range.Text = TEH4

                oTable.Cell(6, 1).Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG9", "Другое")
                oTable.Cell(6, 2).Range.Text = TEH5

                oTable.Cell(7, 1).Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG10", "Фотоаппаратов")
                oTable.Cell(7, 2).Range.Text = TEH6

                oTable.Cell(8, 1).Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG11", "Факсов")
                oTable.Cell(8, 2).Range.Text = TEH7

                oTable.Cell(9, 1).Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG12", "Телефонов")
                oTable.Cell(9, 2).Range.Text = TEH8

                oTable.Cell(10, 1).Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG13", "ZIP")
                oTable.Cell(10, 2).Range.Text = TEH9

                oTable.Cell(11, 1).Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG14", "Сканеров")
                oTable.Cell(11, 2).Range.Text = TEH10

                oTable.Cell(12, 1).Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG15", "Сетевого оборудования")
                oTable.Cell(12, 2).Range.Text = TEH11

                oTable.Cell(13, 1).Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG16", "Мониторов")
                oTable.Cell(13, 2).Range.Text = TEH12

                oTable.Cell(14, 1).Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG17", "USB устройств")
                oTable.Cell(14, 2).Range.Text = TEH13

                oTable.Cell(15, 1).Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG18", "Акустики")
                oTable.Cell(15, 2).Range.Text = TEH14

                oTable.Cell(16, 1).Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG19", "Источников бесперебойного питания")
                oTable.Cell(16, 2).Range.Text = TEH15

                oTable.Cell(17, 1).Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG20", "Сетевых фильтров")
                oTable.Cell(17, 2).Range.Text = TEH16

                oTable.Cell(18, 1).Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG21", "Клавиатур")
                oTable.Cell(18, 2).Range.Text = TEH17

                oTable.Cell(19, 1).Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG22", "Мышей")
                oTable.Cell(19, 2).Range.Text = TEH18

                oTable.Rows.Item(1).Range.Font.Bold = True
                oTable.Rows.Item(1).Range.Font.Italic = False



                oPara1 = oDoc.Content.Paragraphs.Add
                oPara1.Range.Text = ""
                oPara1.Range.Font.Bold = True
                oPara1.Format.SpaceAfter = 12    '24 pt spacing after paragraph.
                oPara1.Range.InsertParagraphAfter()


                oPara1 = oDoc.Content.Paragraphs.Add
                oPara1.Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG23", "Из них по филиалам (отделам)")
                oPara1.Range.Font.Bold = True
                oPara1.Format.SpaceAfter = 12    '24 pt spacing after paragraph.
                oPara1.Range.InsertParagraphAfter()


                '###########################################################
                '###########################################################


                Dim zint As Integer = 1
                Dim intj As Integer = 2


                Dim rs1 As ADODB.Recordset
                rs = New ADODB.Recordset
                rs.Open("SELECT FILIAL FROM SPR_FILIAL", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                With rs
                    .MoveFirst()
                    Do While Not .EOF

                        rs1 = New ADODB.Recordset
                        rs1.Open("SELECT count(*) as t_n FROM kompy where filial ='" & .Fields("filial").Value & "' AND tiptehn='PC'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                        zint = 1

                        With rs1
                            TEH1 = .Fields("t_n").Value
                            If .Fields("t_n").Value <> 0 Then
                                zint = zint + 1
                            End If

                        End With
                        rs1.Close()
                        rs1 = Nothing

                        rs1 = New ADODB.Recordset
                        rs1.Open("SELECT count(*) as t_n FROM kompy where filial ='" & .Fields("filial").Value & "' AND tiptehn='Printer'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                        With rs1
                            TEH2 = .Fields("t_n").Value
                            If .Fields("t_n").Value <> 0 Then
                                zint = zint + 1
                            End If
                        End With
                        rs1.Close()
                        rs1 = Nothing

                        rs1 = New ADODB.Recordset
                        rs1.Open("SELECT count(*) as t_n FROM kompy where filial ='" & .Fields("filial").Value & "' AND tiptehn='MFU'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                        With rs1
                            TEH3 = .Fields("t_n").Value
                            If .Fields("t_n").Value <> 0 Then
                                zint = zint + 1
                            End If
                        End With
                        rs1.Close()
                        rs1 = Nothing

                        rs1 = New ADODB.Recordset
                        rs1.Open("SELECT count(*) as t_n FROM kompy where filial ='" & .Fields("filial").Value & "' AND tiptehn='KOpir'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                        With rs1
                            TEH4 = .Fields("t_n").Value
                            If .Fields("t_n").Value <> 0 Then
                                zint = zint + 1
                            End If
                        End With
                        rs1.Close()
                        rs1 = Nothing

                        rs1 = New ADODB.Recordset
                        rs1.Open("SELECT count(*) as t_n FROM kompy where filial ='" & .Fields("filial").Value & "' AND tiptehn='OT'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                        With rs1
                            TEH5 = .Fields("t_n").Value
                            If .Fields("t_n").Value <> 0 Then
                                zint = zint + 1
                            End If
                        End With
                        rs1.Close()
                        rs1 = Nothing

                        rs1 = New ADODB.Recordset
                        rs1.Open("SELECT count(*) as t_n FROM kompy where filial ='" & .Fields("filial").Value & "' AND tiptehn='PHOTO'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                        With rs1
                            TEH6 = .Fields("t_n").Value
                            If .Fields("t_n").Value <> 0 Then
                                zint = zint + 1
                            End If
                        End With
                        rs1.Close()
                        rs1 = Nothing


                        rs1 = New ADODB.Recordset
                        rs1.Open("SELECT count(*) as t_n FROM kompy where filial ='" & .Fields("filial").Value & "' AND tiptehn='FAX'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                        With rs1
                            TEH7 = .Fields("t_n").Value
                            If .Fields("t_n").Value <> 0 Then
                                zint = zint + 1
                            End If
                        End With
                        rs1.Close()
                        rs1 = Nothing

                        rs1 = New ADODB.Recordset
                        rs1.Open("SELECT count(*) as t_n FROM kompy where filial ='" & .Fields("filial").Value & "' AND tiptehn='PHONE'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                        With rs1
                            TEH8 = .Fields("t_n").Value
                            If .Fields("t_n").Value <> 0 Then
                                zint = zint + 1
                            End If
                        End With
                        rs1.Close()
                        rs1 = Nothing

                        rs1 = New ADODB.Recordset
                        rs1.Open("SELECT count(*) as t_n FROM kompy where filial ='" & .Fields("filial").Value & "' AND tiptehn='ZIP'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                        With rs1
                            TEH9 = .Fields("t_n").Value
                            If .Fields("t_n").Value <> 0 Then
                                zint = zint + 1
                            End If
                        End With
                        rs1.Close()
                        rs1 = Nothing

                        rs1 = New ADODB.Recordset
                        rs1.Open("SELECT count(*) as t_n FROM kompy where filial ='" & .Fields("filial").Value & "' AND tiptehn='SCANER'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                        With rs1
                            TEH10 = .Fields("t_n").Value
                            If .Fields("t_n").Value <> 0 Then
                                zint = zint + 1
                            End If
                        End With
                        rs1.Close()
                        rs1 = Nothing

                        rs1 = New ADODB.Recordset
                        rs1.Open("SELECT count(*) as t_n FROM kompy where filial ='" & .Fields("filial").Value & "' AND tiptehn='NET'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                        With rs1
                            TEH11 = .Fields("t_n").Value
                            If .Fields("t_n").Value <> 0 Then
                                zint = zint + 1
                            End If
                        End With
                        rs1.Close()
                        rs1 = Nothing

                        rs1 = New ADODB.Recordset
                        rs1.Open("SELECT count(*) as t_n FROM kompy where filial ='" & .Fields("filial").Value & "' AND tiptehn='MONITOR'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                        With rs1
                            TEH12 = .Fields("t_n").Value
                            If .Fields("t_n").Value <> 0 Then
                                zint = zint + 1
                            End If
                        End With
                        rs1.Close()
                        rs1 = Nothing

                        rs1 = New ADODB.Recordset
                        rs1.Open("SELECT count(*) as t_n FROM kompy where filial ='" & .Fields("filial").Value & "' AND tiptehn='USB'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                        With rs1
                            TEH13 = .Fields("t_n").Value
                            If .Fields("t_n").Value <> 0 Then
                                zint = zint + 1
                            End If
                        End With
                        rs1.Close()
                        rs1 = Nothing

                        rs1 = New ADODB.Recordset
                        rs1.Open("SELECT count(*) as t_n FROM kompy where filial ='" & .Fields("filial").Value & "' AND tiptehn='SOUND'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                        With rs1
                            TEH14 = .Fields("t_n").Value
                            If .Fields("t_n").Value <> 0 Then
                                zint = zint + 1
                            End If
                        End With
                        rs1.Close()
                        rs1 = Nothing

                        rs1 = New ADODB.Recordset
                        rs1.Open("SELECT count(*) as t_n FROM kompy where filial ='" & .Fields("filial").Value & "' AND tiptehn='IBP'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                        With rs1
                            TEH15 = .Fields("t_n").Value
                            If .Fields("t_n").Value <> 0 Then
                                zint = zint + 1
                            End If
                        End With
                        rs1.Close()
                        rs1 = Nothing

                        rs1 = New ADODB.Recordset
                        rs1.Open("SELECT count(*) as t_n FROM kompy where filial ='" & .Fields("filial").Value & "' AND tiptehn='FS'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                        With rs1
                            TEH16 = .Fields("t_n").Value
                            If .Fields("t_n").Value <> 0 Then
                                zint = zint + 1
                            End If
                        End With
                        rs1.Close()
                        rs1 = Nothing

                        rs1 = New ADODB.Recordset
                        rs1.Open("SELECT count(*) as t_n FROM kompy where filial ='" & .Fields("filial").Value & "' AND tiptehn='KEYB'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                        With rs1
                            TEH17 = .Fields("t_n").Value
                            If .Fields("t_n").Value <> 0 Then
                                zint = zint + 1
                            End If
                        End With
                        rs1.Close()
                        rs1 = Nothing

                        rs1 = New ADODB.Recordset
                        rs1.Open("SELECT count(*) as t_n FROM kompy where filial ='" & .Fields("filial").Value & "' AND tiptehn='MOUSE'", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                        With rs1
                            TEH18 = .Fields("t_n").Value
                            If .Fields("t_n").Value <> 0 Then
                                zint = zint + 1
                            End If
                        End With
                        rs1.Close()
                        rs1 = Nothing


                        oPara1 = oDoc.Content.Paragraphs.Add
                        oPara1.Range.Text = ""
                        oPara1.Range.Font.Bold = True
                        oPara1.Format.SpaceAfter = 12    '24 pt spacing after paragraph.
                        oPara1.Range.InsertParagraphAfter()

                        oPara1.Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG24", "Филиал (отдел):") & " " & .Fields("filial").Value
                        oPara1.Range.Font.Bold = True
                        oPara1.Format.SpaceAfter = 24    '24 pt spacing after paragraph.
                        oPara1.Range.InsertParagraphAfter()

                        oTable = oDoc.Tables.Add(oDoc.Bookmarks.Item("\endofdoc").Range, zint, 2)
                        oTable.Range.ParagraphFormat.SpaceAfter = 6

                        oTable.Cell(1, 1).Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG3", "Тип техники")
                        oTable.Cell(1, 2).Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG4", "Кол-во")


                        intj = 2

                        If TEH1 <> 0 Then
                            oTable.Cell(intj, 1).Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG5", "Компьютеров")  'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            oTable.Cell(intj, 2).Range.Text = TEH1 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            intj = intj + 1
                        End If

                        If TEH2 <> 0 Then
                            oTable.Cell(intj, 1).Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG6", "Принтеров")  'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            oTable.Cell(intj, 2).Range.Text = TEH2 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            intj = intj + 1
                        End If

                        If TEH3 <> 0 Then
                            oTable.Cell(intj, 1).Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG7", "МФУ")  'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            oTable.Cell(intj, 2).Range.Text = TEH3 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            intj = intj + 1
                        End If

                        If TEH4 <> 0 Then
                            oTable.Cell(intj, 1).Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG8", "Копиров")  'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            oTable.Cell(intj, 2).Range.Text = TEH4 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            intj = intj + 1
                        End If

                        If TEH5 <> 0 Then
                            oTable.Cell(intj, 1).Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG9", "Другое")  'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            oTable.Cell(intj, 2).Range.Text = TEH5 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            intj = intj + 1
                        End If

                        If TEH6 <> 0 Then
                            oTable.Cell(intj, 1).Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG10", "Фотоаппаратов")  'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            oTable.Cell(intj, 2).Range.Text = TEH6 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            intj = intj + 1
                        End If

                        If TEH7 <> 0 Then
                            oTable.Cell(intj, 1).Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG11", "Факсов")  'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            oTable.Cell(intj, 2).Range.Text = TEH7 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            intj = intj + 1
                        End If

                        If TEH8 <> 0 Then
                            oTable.Cell(intj, 1).Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG12", "Телефонов")  'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            oTable.Cell(intj, 2).Range.Text = TEH8 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            intj = intj + 1
                        End If

                        If TEH9 <> 0 Then
                            oTable.Cell(intj, 1).Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG13", "ZIP")  'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            oTable.Cell(intj, 2).Range.Text = TEH9 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            intj = intj + 1
                        End If

                        If TEH10 <> 0 Then
                            oTable.Cell(intj, 1).Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG14", "Сканеров")  'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            oTable.Cell(intj, 2).Range.Text = TEH10 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            intj = intj + 1
                        End If

                        If TEH11 <> 0 Then
                            oTable.Cell(intj, 1).Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG15", "Сетевого оборудования")  'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            oTable.Cell(intj, 2).Range.Text = TEH11 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            intj = intj + 1
                        End If

                        If TEH12 <> 0 Then
                            oTable.Cell(intj, 1).Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG16", "Мониторов")  'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            oTable.Cell(intj, 2).Range.Text = TEH12 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            intj = intj + 1
                        End If

                        If TEH13 <> 0 Then
                            oTable.Cell(intj, 1).Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG17", "USB устройств")  'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            oTable.Cell(intj, 2).Range.Text = TEH13 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            intj = intj + 1
                        End If

                        If TEH14 <> 0 Then
                            oTable.Cell(intj, 1).Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG18", "Акустики")  'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            oTable.Cell(intj, 2).Range.Text = TEH14 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            intj = intj + 1
                        End If

                        If TEH15 <> 0 Then
                            oTable.Cell(intj, 1).Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG19", "Источников бесперебойного питания")  'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            oTable.Cell(intj, 2).Range.Text = TEH15 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            intj = intj + 1
                        End If

                        If TEH16 <> 0 Then
                            oTable.Cell(intj, 1).Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG20", "Сетевых фильтров")  'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            oTable.Cell(intj, 2).Range.Text = TEH16 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            intj = intj + 1
                        End If

                        If TEH17 <> 0 Then
                            oTable.Cell(intj, 1).Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG21", "Клавиатур")  'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            oTable.Cell(intj, 2).Range.Text = TEH17 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            intj = intj + 1
                        End If

                        If TEH18 <> 0 Then
                            oTable.Cell(intj, 1).Range.Text = LNGIniFile.GetString("MOD_INVENT", "MSG22", "Мышей")  'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            oTable.Cell(intj, 2).Range.Text = TEH18 'lv_teh_fil_otd.SELECTedItem.Text, objTable
                            intj = intj + 1
                        End If


                        .MoveNext()
                        ''DoEvents
                    Loop
                End With
                rs.Close()
                rs = Nothing


                oPara1.Range.InsertParagraphAfter()


                'Dim rs As ADODB.Recordset
                rs = New ADODB.Recordset
                rs.Open("SELECT * FROM CONFIGURE", DB7, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

                With rs
                    If Not IsDBNull(.Fields("SISADM").Value) Then uname = .Fields("SISADM").Value
                End With
                rs.Close()
                rs = Nothing

                oPara1 = oDoc.Content.Paragraphs.Add
                oPara1.Range.Text = uname
                oPara1.Range.Font.Bold = True
                oPara1.Format.SpaceAfter = 24    '24 pt spacing after paragraph.
                oPara1.Range.InsertParagraphAfter()



        End Select




    End Sub




End Module
