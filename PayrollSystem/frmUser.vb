Public Class frmUser

    Private Sub frmUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        reload("SELECT user_id as Id,name as Name,username as Username,type as Type FROM user", dtg_userList)
        lbl_id.Text = "id"
    End Sub
    Private Sub btnMUdel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMUdel.Click


        Try
            If MessageBox.Show("Do you want to delete this record?", _
                               "DELETE", MessageBoxButtons.YesNo, _
                               MessageBoxIcon.Information) _
                               = Windows.Forms.DialogResult.Yes Then
                sql = "DELETE FROM user WHERE user_id = '" & dtg_userList.CurrentRow.Cells(0).Value & "'"
                deletes(sql)
                MsgBox("User has been deleted.", MsgBoxStyle.Information)
                Call Button6_Click(sender, e)
            Else

                MsgBox("Operation has been cancel.", , "Cancel")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If lbl_id.Text = "" Or _
            txtname.Text = "" Or _
            txtuser.Text = "" Or txtpass.Text = "" Then
            MsgBox("One of the box is empty. Data is required.", MsgBoxStyle.Exclamation)
        Else
            If btnsave.Text = "Add" Then
                'put the string value to sql 
                sql = "INSERT INTO `user` (`name`,`username`, `pass`, `type` ) VALUES ('" & txtname.Text & "','" _
                & txtuser.Text & "',sha('" & txtpass.Text & "'),'" & cbotype.Text & "')"
                create(sql)
            Else
                sql = "UPDATE user set name='" & txtname.Text & "',username='" & txtuser.Text _
                 & "', pass = sha('" & txtpass.Text & "') Where user_id='" & lbl_id.Text & "'"
                updates(sql)


            End If
            'call your sub name and put the sql in the parameters list.

            Call Button6_Click(sender, e)
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_update.Click
        'If lbl_id.Text = "Id" Then
        'Else
        '    sql = "UPDATE user set name='" & txtname.Text & "',username='" & txtuser.Text _
        '    & "', pass = sha('" & txtpass.Text & "') Where user_id='" & lbl_id.Text & "'"
        '    updates(sql)
        '    userlist()
        '    Call Button6_Click(sender, e)
        'End If
        lbl_id.Text = dtg_userList.CurrentRow.Cells(0).Value
        txtname.Text = dtg_userList.CurrentRow.Cells(1).Value
        txtuser.Text = dtg_userList.CurrentRow.Cells(2).Value
        btnsave.Text = "Save"
    End Sub
    Public Sub userlist()
        reload("SELECT user_id as Id,name as Name,username as Username,type as Type FROM user", dtg_userList)
        lbl_id.Text = "id"
        btnsave.Text = "Add"
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        cleartxt(GroupBox11)
        userlist()

    End Sub
End Class