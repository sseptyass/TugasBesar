<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUser
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox
        Me.btnMUdel = New System.Windows.Forms.Button
        Me.cbotype = New System.Windows.Forms.ComboBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.txtname = New System.Windows.Forms.TextBox
        Me.btn_update = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.Label39 = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.Label41 = New System.Windows.Forms.Label
        Me.txtpass = New System.Windows.Forms.TextBox
        Me.txtuser = New System.Windows.Forms.TextBox
        Me.btnsave = New System.Windows.Forms.Button
        Me.lbl_id = New System.Windows.Forms.Label
        Me.GroupBox12 = New System.Windows.Forms.GroupBox
        Me.dtg_userList = New System.Windows.Forms.DataGridView
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        CType(Me.dtg_userList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.btnMUdel)
        Me.GroupBox11.Controls.Add(Me.cbotype)
        Me.GroupBox11.Controls.Add(Me.Label38)
        Me.GroupBox11.Controls.Add(Me.txtname)
        Me.GroupBox11.Controls.Add(Me.btn_update)
        Me.GroupBox11.Controls.Add(Me.Button6)
        Me.GroupBox11.Controls.Add(Me.Label39)
        Me.GroupBox11.Controls.Add(Me.Label40)
        Me.GroupBox11.Controls.Add(Me.Label41)
        Me.GroupBox11.Controls.Add(Me.txtpass)
        Me.GroupBox11.Controls.Add(Me.txtuser)
        Me.GroupBox11.Controls.Add(Me.btnsave)
        Me.GroupBox11.Controls.Add(Me.lbl_id)
        Me.GroupBox11.Location = New System.Drawing.Point(85, 28)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(483, 199)
        Me.GroupBox11.TabIndex = 5
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Add New User"
        '
        'btnMUdel
        '
        Me.btnMUdel.Location = New System.Drawing.Point(328, 159)
        Me.btnMUdel.Name = "btnMUdel"
        Me.btnMUdel.Size = New System.Drawing.Size(75, 23)
        Me.btnMUdel.TabIndex = 15
        Me.btnMUdel.Text = "Delete"
        Me.btnMUdel.UseVisualStyleBackColor = True
        '
        'cbotype
        '
        Me.cbotype.FormattingEnabled = True
        Me.cbotype.Items.AddRange(New Object() {"Administrator", "Staff", "Guest"})
        Me.cbotype.Location = New System.Drawing.Point(163, 112)
        Me.cbotype.Name = "cbotype"
        Me.cbotype.Size = New System.Drawing.Size(121, 21)
        Me.cbotype.TabIndex = 2
        Me.cbotype.Text = "Administrator"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label38.ForeColor = System.Drawing.Color.White
        Me.Label38.Location = New System.Drawing.Point(113, 37)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(41, 13)
        Me.Label38.TabIndex = 14
        Me.Label38.Text = "Name :"
        '
        'txtname
        '
        Me.txtname.Location = New System.Drawing.Point(161, 34)
        Me.txtname.Name = "txtname"
        Me.txtname.Size = New System.Drawing.Size(218, 20)
        Me.txtname.TabIndex = 13
        '
        'btn_update
        '
        Me.btn_update.Location = New System.Drawing.Point(157, 159)
        Me.btn_update.Name = "btn_update"
        Me.btn_update.Size = New System.Drawing.Size(85, 23)
        Me.btn_update.TabIndex = 10
        Me.btn_update.Text = "Edit"
        Me.btn_update.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(247, 160)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 23)
        Me.Button6.TabIndex = 7
        Me.Button6.Text = "New"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label39.ForeColor = System.Drawing.Color.White
        Me.Label39.Location = New System.Drawing.Point(83, 115)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(71, 13)
        Me.Label39.TabIndex = 6
        Me.Label39.Text = "User's Level :"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label40.ForeColor = System.Drawing.Color.White
        Me.Label40.Location = New System.Drawing.Point(96, 89)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(59, 13)
        Me.Label40.TabIndex = 4
        Me.Label40.Text = "Password :"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label41.ForeColor = System.Drawing.Color.White
        Me.Label41.Location = New System.Drawing.Point(93, 63)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(61, 13)
        Me.Label41.TabIndex = 5
        Me.Label41.Text = "Username :"
        '
        'txtpass
        '
        Me.txtpass.Location = New System.Drawing.Point(163, 86)
        Me.txtpass.Name = "txtpass"
        Me.txtpass.Size = New System.Drawing.Size(218, 20)
        Me.txtpass.TabIndex = 1
        Me.txtpass.UseSystemPasswordChar = True
        '
        'txtuser
        '
        Me.txtuser.Location = New System.Drawing.Point(161, 60)
        Me.txtuser.Name = "txtuser"
        Me.txtuser.Size = New System.Drawing.Size(218, 20)
        Me.txtuser.TabIndex = 1
        '
        'btnsave
        '
        Me.btnsave.Location = New System.Drawing.Point(79, 160)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(75, 23)
        Me.btnsave.TabIndex = 0
        Me.btnsave.Text = "Add"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'lbl_id
        '
        Me.lbl_id.AutoSize = True
        Me.lbl_id.Location = New System.Drawing.Point(269, 63)
        Me.lbl_id.Name = "lbl_id"
        Me.lbl_id.Size = New System.Drawing.Size(15, 13)
        Me.lbl_id.TabIndex = 12
        Me.lbl_id.Text = "id"
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.dtg_userList)
        Me.GroupBox12.Location = New System.Drawing.Point(12, 233)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(658, 188)
        Me.GroupBox12.TabIndex = 4
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "List Of Users"
        '
        'dtg_userList
        '
        Me.dtg_userList.AllowUserToAddRows = False
        Me.dtg_userList.AllowUserToDeleteRows = False
        Me.dtg_userList.AllowUserToResizeColumns = False
        Me.dtg_userList.AllowUserToResizeRows = False
        Me.dtg_userList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtg_userList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_userList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtg_userList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtg_userList.Location = New System.Drawing.Point(3, 16)
        Me.dtg_userList.Name = "dtg_userList"
        Me.dtg_userList.RowHeadersVisible = False
        Me.dtg_userList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtg_userList.Size = New System.Drawing.Size(652, 169)
        Me.dtg_userList.TabIndex = 0
        '
        'frmUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(679, 428)
        Me.Controls.Add(Me.GroupBox11)
        Me.Controls.Add(Me.GroupBox12)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmUser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manage User"
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.GroupBox12.ResumeLayout(False)
        CType(Me.dtg_userList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents btnMUdel As System.Windows.Forms.Button
    Friend WithEvents cbotype As System.Windows.Forms.ComboBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents txtname As System.Windows.Forms.TextBox
    Friend WithEvents btn_update As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents txtpass As System.Windows.Forms.TextBox
    Friend WithEvents txtuser As System.Windows.Forms.TextBox
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents lbl_id As System.Windows.Forms.Label
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents dtg_userList As System.Windows.Forms.DataGridView
End Class
