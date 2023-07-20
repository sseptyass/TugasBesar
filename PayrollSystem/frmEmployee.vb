Public Class frmEmployee

    Private Sub frmEmployee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sql = "SELECT `emp_code` AS 'CODE',CONCAT( `emp_fname`,' ', `emp_lname`,' ', `emp_mname`) AS 'NAME'" _
      & ", `emp_age` AS 'AGE', `emp_sex` AS 'GENDER', `status` AS 'STATUS', `address` AS 'ADDRESS', `contact` AS 'CONTACT'  FROM `employee`"
        reload(sql, dtgemplist)
        Call btnempnew_Click(sender, e)
    End Sub
    Dim rdo As String
    Private Sub btnempsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnempsave.Click
        Try

            If txtcode.Text = "" Or txtfname.Text = "" Or txtlname.Text = "" Or txtmname.Text = "" _
            Or txtaddress.Text = "" Or txtcontact.Text = "" Or txtstatus.Text = "" Or txtbplace.Text = "" _
            Or txtage.Text = "" Or txtemerg.Text = "" Or txtdrate.Text = "" Or txtposition.Text = "" Then


                MsgBox("One of the box is empty. It needed to be filled up.", MsgBoxStyle.Exclamation)

            Else
                If rdomale.Checked = True Then
                    rdo = "MALE"
                Else
                    rdo = "FEMALE"
                End If
                sql = "INSERT INTO `employee_workinfo` (`emp_code`, `d_rate`, `p_method`, `position`, `w_status`, `d_hired`)" _
                        & " VALUES ('" & txtcode.Text & "','" & txtdrate.Text & "','" & txtpmethod.Text & "','" & txtposition.Text _
                        & "','" & txtworkstatus.Text & "','" & dtpdhired.Text & "')"
                createsub(sql)

                sql = "INSERT INTO `employee` (`emp_code`, `emp_fname`, `emp_lname`, `emp_mname`" _
                & ", `address`, `contact`, `status`, `birth_date`, `birth_place`, `emp_sex`, `emp_age`" _
                & ", `emerg_contct`) VALUES ('" & txtcode.Text & "','" & txtfname.Text & "','" & txtlname.Text _
                & "','" & txtmname.Text & "','" & txtaddress.Text & "','" & txtcontact.Text & "','" & txtstatus.Text _
                & "','" & dtpdbirth.Text & "','" & txtbplace.Text & "','" & rdo & "','" & txtage.Text & "','" & txtcontact.Text & "')"
                create(sql)
                Call btnempnew_Click(sender, e)
            End If
            btnempsave.Enabled = True
            btnempupdate.Enabled = False
        Catch ex As Exception
            'MsgBox(ex.Message & " btnempsave_Click", MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub TabControl2_Selected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles TabControl2.Selected
        sql = "SELECT `emp_code` AS 'CODE',CONCAT( `emp_fname`,' ', `emp_lname`,' ', `emp_mname`) AS 'NAME'" _
        & ", `emp_age` AS 'AGE', `emp_sex` AS 'GENDER', `status` AS 'STATUS', `address` AS 'ADDRESS', `contact` AS 'CONTACT'  FROM `employee`"
        reload(sql, dtgemplist)
    End Sub

    Private Sub btnempupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnempupdate.Click
        Try
            If rdomale.Checked = True Then
                rdo = "MALE"
            Else
                rdo = "FEMALE"
            End If
            sql = "UPDATE `employee_workinfo` SET  `d_rate`='" & txtdrate.Text _
                    & "', `p_method`='" & txtpmethod.Text & "', `position`='" & txtposition.Text _
                    & "', `w_status`='" & txtworkstatus.Text & "', `d_hired`='" & dtpdhired.Text & "' WHERE `emp_code`='" & txtcode.Text & "'"
            createsub(sql)

            sql = "UPDATE `employee` SET  `emp_fname`='" & txtfname.Text _
            & "', `emp_lname`='" & txtlname.Text & "', `emp_mname`='" & txtmname.Text _
            & "', `address`='" & txtaddress.Text & "', `contact`='" & txtcontact.Text & "', `status`='" & txtstatus.Text _
            & "', `birth_date`='" & dtpdbirth.Text & "', `birth_place`='" & txtbplace.Text & "', `emp_sex`='" & rdo _
            & "', `emp_age`='" & txtage.Text & "', `emerg_contct`='" & txtcontact.Text _
            & "' WHERE `emp_code`='" & txtcode.Text & "'"
            updates(sql)
            Call btnempnew_Click(sender, e)
            btnempsave.Enabled = True
            btnempupdate.Enabled = False
        Catch ex As Exception
            'MsgBox(ex.Message & " btnempsave_Click", MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Public empcode As String
    Private Sub dtgemplist_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgemplist.DoubleClick
        empcode = dtgemplist.CurrentRow.Cells(0).Value
        TabControl2.SelectedTab = TabPage6
        txtcode.Text = empcode
        btnempsave.Enabled = False
        btnempupdate.Enabled = True
    End Sub

    Private Sub txtcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcode.TextChanged
        sql = "SELECT * FROM `employee` e, `employee_workinfo` ew " _
        & " WHERE e.`emp_code`=ew.`emp_code` AND e.emp_code ='" & txtcode.Text & "'"
        filltxt(sql)
        If dt.Rows.Count > 0 Then
            txtdrate.Text = dt.Rows(0).Item("d_rate")
            txtpmethod.Text = dt.Rows(0).Item("p_method")
            txtposition.Text = dt.Rows(0).Item("position")
            txtworkstatus.Text = dt.Rows(0).Item("w_status")
            dtpdhired.Text = dt.Rows(0).Item("d_hired")

            txtfname.Text = dt.Rows(0).Item("emp_fname")
            txtlname.Text = dt.Rows(0).Item("emp_lname")
            txtmname.Text = dt.Rows(0).Item("emp_mname")
            txtaddress.Text = dt.Rows(0).Item("address")
            txtcontact.Text = dt.Rows(0).Item("contact")
            txtstatus.Text = dt.Rows(0).Item("status")
            dtpdbirth.Text = dt.Rows(0).Item("birth_date")
            txtbplace.Text = dt.Rows(0).Item("birth_place")
            If dt.Rows(0).Item("emp_sex") = "MALE" Then
                rdomale.Checked = True
            Else
                rdofemale.Checked = True
            End If
            txtage.Text = dt.Rows(0).Item("emp_age")
            txtcontact.Text = dt.Rows(0).Item("emerg_contct")
        Else
            cleartxt(GroupBox10)
            cleartxt(GroupBox9)
        End If
    End Sub



    Private Sub btnempnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnempnew.Click
        cleartxt(GroupBox10)
        cleartxt(GroupBox9)
        btnempsave.Enabled = True
        btnempupdate.Enabled = False
        txtcode.Clear()
    End Sub

    Private Sub txtempsearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtempsearch.TextChanged
        sql = "SELECT `emp_code` AS 'CODE',CONCAT( `emp_fname`,' ', `emp_lname`,' ', `emp_mname`) AS 'NAME'" _
              & ", `emp_age` AS 'AGE', `emp_sex` AS 'GENDER', `status` AS 'STATUS', `address` AS 'ADDRESS'" _
              & ", `contact` AS 'CONTACT'  FROM `employee` WHERE `emp_code` LIKE '%" & txtempsearch.Text & "%'" _
              & " OR emp_fname LIKE '%" & txtempsearch.Text & "%' OR emp_lname LIKE '%" & txtempsearch.Text & "%'"
        reload(sql, dtgemplist)
    End Sub
    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        sql = "DELETE FROM employee WHERE emp_code = '" & dtgemplist.CurrentRow.Cells(0).Value & "'"
        deletes(sql)
        sql = "DELETE FROM employee_workinfo WHERE emp_code = '" & dtgemplist.CurrentRow.Cells(0).Value & "'"
        deletes(sql)

        sql = "DELETE FROM other_deduction WHERE emp_code = '" & dtgemplist.CurrentRow.Cells(0).Value & "'"
        deletes(sql)
        MsgBox("Employee has been deleted.", MsgBoxStyle.Information)
        sql = "SELECT `emp_code` AS 'CODE',CONCAT( `emp_fname`,' ', `emp_lname`,' ', `emp_mname`) AS 'NAME'" _
        & ", `emp_age` AS 'AGE', `emp_sex` AS 'GENDER', `status` AS 'STATUS', `address` AS 'ADDRESS', `contact` AS 'CONTACT'  FROM `employee`"
        reload(sql, dtgemplist)
    End Sub
End Class