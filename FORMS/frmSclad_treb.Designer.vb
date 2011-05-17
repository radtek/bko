<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSclad_treb
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtNom = New System.Windows.Forms.TextBox
        Me.cmbLich = New System.Windows.Forms.ComboBox
        Me.cmbLich2 = New System.Windows.Forms.ComboBox
        Me.cmbLich3 = New System.Windows.Forms.ComboBox
        Me.Combo1 = New System.Windows.Forms.ComboBox
        Me.txtkol = New System.Windows.Forms.TextBox
        Me.Combo3 = New System.Windows.Forms.ComboBox
        Me.Combo2 = New System.Windows.Forms.ComboBox
        Me.Text1 = New System.Windows.Forms.TextBox
        Me.Text2 = New System.Windows.Forms.TextBox
        Me.btnVipiska = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "№"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Через кого:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Затребовал:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Получил:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 110)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(133, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Привязать к устройству:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 154)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Количество:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 180)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Филиал:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 204)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Отдел:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 235)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Отпустил:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(178, 235)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 13)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Получил:"
        '
        'txtNom
        '
        Me.txtNom.Location = New System.Drawing.Point(85, 12)
        Me.txtNom.Name = "txtNom"
        Me.txtNom.Size = New System.Drawing.Size(100, 20)
        Me.txtNom.TabIndex = 10
        '
        'cmbLich
        '
        Me.cmbLich.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbLich.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbLich.FormattingEnabled = True
        Me.cmbLich.Location = New System.Drawing.Point(85, 37)
        Me.cmbLich.Name = "cmbLich"
        Me.cmbLich.Size = New System.Drawing.Size(223, 21)
        Me.cmbLich.TabIndex = 11
        '
        'cmbLich2
        '
        Me.cmbLich2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbLich2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbLich2.FormattingEnabled = True
        Me.cmbLich2.Location = New System.Drawing.Point(85, 62)
        Me.cmbLich2.Name = "cmbLich2"
        Me.cmbLich2.Size = New System.Drawing.Size(223, 21)
        Me.cmbLich2.TabIndex = 12
        '
        'cmbLich3
        '
        Me.cmbLich3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbLich3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbLich3.FormattingEnabled = True
        Me.cmbLich3.Location = New System.Drawing.Point(85, 86)
        Me.cmbLich3.Name = "cmbLich3"
        Me.cmbLich3.Size = New System.Drawing.Size(223, 21)
        Me.cmbLich3.TabIndex = 13
        '
        'Combo1
        '
        Me.Combo1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.Combo1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo1.FormattingEnabled = True
        Me.Combo1.Location = New System.Drawing.Point(15, 126)
        Me.Combo1.Name = "Combo1"
        Me.Combo1.Size = New System.Drawing.Size(295, 21)
        Me.Combo1.TabIndex = 14
        '
        'txtkol
        '
        Me.txtkol.Location = New System.Drawing.Point(85, 151)
        Me.txtkol.Name = "txtkol"
        Me.txtkol.Size = New System.Drawing.Size(100, 20)
        Me.txtkol.TabIndex = 15
        '
        'Combo3
        '
        Me.Combo3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.Combo3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo3.FormattingEnabled = True
        Me.Combo3.Location = New System.Drawing.Point(85, 201)
        Me.Combo3.Name = "Combo3"
        Me.Combo3.Size = New System.Drawing.Size(192, 21)
        Me.Combo3.TabIndex = 17
        '
        'Combo2
        '
        Me.Combo2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.Combo2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Combo2.FormattingEnabled = True
        Me.Combo2.Location = New System.Drawing.Point(85, 177)
        Me.Combo2.Name = "Combo2"
        Me.Combo2.Size = New System.Drawing.Size(192, 21)
        Me.Combo2.TabIndex = 16
        '
        'Text1
        '
        Me.Text1.Location = New System.Drawing.Point(16, 251)
        Me.Text1.Name = "Text1"
        Me.Text1.Size = New System.Drawing.Size(129, 20)
        Me.Text1.TabIndex = 18
        '
        'Text2
        '
        Me.Text2.Location = New System.Drawing.Point(181, 251)
        Me.Text2.Name = "Text2"
        Me.Text2.Size = New System.Drawing.Size(129, 20)
        Me.Text2.TabIndex = 19
        '
        'btnVipiska
        '
        Me.btnVipiska.Location = New System.Drawing.Point(16, 289)
        Me.btnVipiska.Name = "btnVipiska"
        Me.btnVipiska.Size = New System.Drawing.Size(75, 23)
        Me.btnVipiska.TabIndex = 20
        Me.btnVipiska.Text = "Выписать"
        Me.btnVipiska.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(109, 289)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 21
        Me.btnCancel.Text = "Отмена"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmSclad_treb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(320, 319)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnVipiska)
        Me.Controls.Add(Me.Text2)
        Me.Controls.Add(Me.Text1)
        Me.Controls.Add(Me.Combo3)
        Me.Controls.Add(Me.Combo2)
        Me.Controls.Add(Me.txtkol)
        Me.Controls.Add(Me.Combo1)
        Me.Controls.Add(Me.cmbLich3)
        Me.Controls.Add(Me.cmbLich2)
        Me.Controls.Add(Me.cmbLich)
        Me.Controls.Add(Me.txtNom)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmSclad_treb"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Данные для требования"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtNom As System.Windows.Forms.TextBox
    Friend WithEvents cmbLich As System.Windows.Forms.ComboBox
    Friend WithEvents cmbLich2 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbLich3 As System.Windows.Forms.ComboBox
    Friend WithEvents Combo1 As System.Windows.Forms.ComboBox
    Friend WithEvents txtkol As System.Windows.Forms.TextBox
    Friend WithEvents Combo3 As System.Windows.Forms.ComboBox
    Friend WithEvents Combo2 As System.Windows.Forms.ComboBox
    Friend WithEvents Text1 As System.Windows.Forms.TextBox
    Friend WithEvents Text2 As System.Windows.Forms.TextBox
    Friend WithEvents btnVipiska As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
