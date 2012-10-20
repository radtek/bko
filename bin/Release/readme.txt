 Public Sub lstGroups_ItemDrag(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles lstGroups.ItemDrag
        On Error Resume Next

        If uLevelTehAdd = False And uLevel <> "Admin" Then Exit Sub

        Dim d() As String
        d = Split(lstGroups.SelectedNode.Tag, "|")

        Select Case d(0)

            Case "C"

                pDRAG = True

                DoDragDrop(e.Item, DragDropEffects.Move)

            Case Else

                pDRAG = False

        End Select



    End Sub

   

   

   