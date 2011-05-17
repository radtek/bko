<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCartr_Add_Zap
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
        Me.lblRealNumber = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkRef = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbPost = New System.Windows.Forms.ComboBox
        Me.txtAvR = New System.Windows.Forms.TextBox
        Me.dtAvR = New System.Windows.Forms.DateTimePicker
        Me.dtDateZ = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.txtCashe = New System.Windows.Forms.NumericUpDown
        Me.txtPage = New System.Windows.Forms.NumericUpDown
        CType(Me.txtCashe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblRealNumber
        '
        Me.lblRealNumber.AutoSize = True
        Me.lblRealNumber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRealNumber.Location = New System.Drawing.Point(139, 9)
        Me.lblRealNumber.Name = "lblRealNumber"
        Me.lblRealNumber.Size = New System.Drawing.Size(2, 15)
        Me.lblRealNumber.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(63, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Заправка №"
        '
        'chkRef
        '
        Me.chkRef.AutoSize = True
        Me.chkRef.Location = New System.Drawing.Point(343, 7)
        Me.chkRef.Name = "chkRef"
        Me.chkRef.Size = New System.Drawing.Size(92, 17)
        Me.chkRef.TabIndex = 9
        Me.chkRef.Text = "Востановлен"
        Me.chkRef.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(57, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Сервис центр"
        '
        'cmbPost
        '
        Me.cmbPost.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbPost.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPost.FormattingEnabled = True
        Me.cmbPost.Location = New System.Drawing.Point(139, 36)
        Me.cmbPost.Name = "cmbPost"
        Me.cmbPost.Size = New System.Drawing.Size(296, 21)
        Me.cmbPost.TabIndex = 11
        '
        'txtAvR
        '
        Me.txtAvR.Location = New System.Drawing.Point(139, 64)
        Me.txtAvR.Name = "txtAvR"
        Me.txtAvR.Size = New System.Drawing.Size(125, 20)
        Me.txtAvR.TabIndex = 12
        '
        'dtAvR
        '
        Me.dtAvR.Location = New System.Drawing.Point(310, 63)
        Me.dtAvR.Name = "dtAvR"
        Me.dtAvR.Size = New System.Drawing.Size(125, 20)
        Me.dtAvR.TabIndex = 15
        Me.dtAvR.Value = New Date(2010, 4, 1, 0, 0, 0, 0)
        '
        'dtDateZ
        '
        Me.dtDateZ.Location = New System.Drawing.Point(139, 142)
        Me.dtDateZ.Name = "dtDateZ"
        Me.dtDateZ.Size = New System.Drawing.Size(125, 20)
        Me.dtDateZ.TabIndex = 16
        Me.dtDateZ.Value = New Date(2010, 4, 1, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(129, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Акт выполненных работ"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(276, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(18, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "от"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(71, 93)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Стоимость"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 119)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(116, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Колличество страниц"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(71, 146)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Заправлен"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(7, 192)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 22
        Me.btnAdd.Text = "Добавить"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(98, 192)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 23
        Me.btnCancel.Text = "Отмена"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txtCashe
        '
        Me.txtCashe.Location = New System.Drawing.Point(139, 90)
        Me.txtCashe.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.txtCashe.Name = "txtCashe"
        Me.txtCashe.Size = New System.Drawing.Size(125, 20)
        Me.txtCashe.TabIndex = 24
        '
        'txtPage
        '
        Me.txtPage.Location = New System.Drawing.Point(139, 117)
        Me.txtPage.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.txtPage.Name = "txtPage"
        Me.txtPage.Size = New System.Drawing.Size(125, 20)
        Me.txtPage.TabIndex = 25
        '
        'frmCartr_Add_Zap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(440, 224)
        Me.Controls.Add(Me.txtPage)
        Me.Controls.Add(Me.txtCashe)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtDateZ)
        Me.Controls.Add(Me.dtAvR)
        Me.Controls.Add(Me.txtAvR)
        Me.Controls.Add(Me.cmbPost)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.chkRef)
        Me.Controls.Add(Me.lblRealNumber)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmCartr_Add_Zap"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Добавление (редактирование) заправки"
        CType(Me.txtCashe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblRealNumber As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkRef As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbPost As System.Windows.Forms.ComboBox
    Friend WithEvents txtAvR As System.Windows.Forms.TextBox
    Friend WithEvents dtAvR As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtDateZ As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtCashe As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtPage As System.Windows.Forms.NumericUpDown
End Class
