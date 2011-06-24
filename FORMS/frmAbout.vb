Public NotInheritable Class frmAbout

    Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        SendFonts(Me)

        ' Установить заголовок формы.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.ProductName
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("О программе {0}", ApplicationTitle)
        ' Инициализировать текст, отображаемый в окне "О программе".
        ' TODO: настроить сведения о сборке приложения в области "Приложение" диалогового окна 
        '    свойств проекта (в меню "Проект").

        If unamDB = "MS Access" Then

            Me.LabelProductName.Text = My.Application.Info.ProductName & " - " & unamDB & " - " & Base_Name

        Else

            Me.LabelProductName.Text = My.Application.Info.ProductName & " - " & unamDB & " - " & DBtabl

        End If



        Me.LabelVersion.Text = String.Format("Версия {0}", My.Application.Info.Version.ToString)
        Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.LabelCompanyName.Text = "Squee&Dragon"


        Dim sStr As String
        Dim sStr2 As String

        sStr = "Данная программа создавалась для облегчения труда системных администраторов муниципальных и бюджетных учреждений и организаций. Конечно я прекрасно понимаю, что это не шедевр, но не судите строго, я занимаюсь этим не профессионально - исключительно в свободное от работы время. В программе не исключены ошибки, но я стараюсь исправлять их сразу же, как только получаю Ваши сообщения о найденных ошибках. Программа была, есть и будет бесплатной на протяжении всей своей жизни, и если кто-то Вам будет пытаться ее продать, сообщите мне об этом. С Уважением Плотников Алексей"
        sStr2 = "Пенин Максим Сергеевич, VIP_Graff (Уфа), Алексей Киселёв, Евгений Панин, Evgen V Krukovich, Alik Trakhtman, DIMM, XXX, Romirez, Сергей Горевой, VAD, Каменев В.А, Карпухин Павел, Мацишин Игорь Иванович, yuronnchik, Алексей Казаков, Алексей Агапов, Константин (ОК Дагомыс), Vitaly A. Che, Паньков Алексей Викторович (Банк Юниаструм), Юрий Федотов, Владислав aka VlаdоkZzz, Сазанов Дмитрий (Rich), Влад Синеок (quad), Klop. И другим людям которые вольно или не вольно принимали участие в создании программы"

        Me.TextBoxDescription.Text = sStr & vbCrLf & vbCrLf & "Отдельные спасиббы:" & vbCrLf & vbCrLf & sStr2

    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

    Private Sub TextBoxDescription_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxDescription.TextChanged

    End Sub
End Class
