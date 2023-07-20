Public Class frmPayroll
    Public Sub clearing(ByVal grp As GroupBox)

        For Each txt As Control In grp.Controls
            If txt.GetType Is GetType(TextBox) Then
                If txt.Text = "" Then
                    txtTotaldeduc.Text = ""
                End If
            End If
        Next

    End Sub
    Private Sub frmPayroll_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        filltxt("SELECT concat(autoname,strnum) FROM autonumber WHERE id = 1")
        If dt.Rows.Count Then
            txttrancode.Text = dt.Rows(0).Item(0)
        End If

    End Sub
    Private Sub txtTotaldeduc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotaldeduc.TextChanged
        Try
            txtpnetincome.Text = Double.Parse(txtpnetincome.Text - txtTotaldeduc.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtpdeducttot_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpdeducttot.TextChanged
        Try
            txtpnetincome.Text = Double.Parse(txtpnetincome.Text - txtpdeducttot.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtpdeduct1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtpgincome_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpgincome.TextChanged
        txtpnetincome.Text = txtpgincome.Text
    End Sub
    Private Sub txtPAssignCode_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPAssignCode.TextChanged
        Try
            sql = "SELECT * FROM `employee` e, `employee_workinfo` ew " _
                 & " WHERE e.`emp_code`=ew.`emp_code` AND e.emp_code ='" & txtPAssignCode.Text & "'"
            filltxt(sql)

            If dt.Rows.Count > 0 Then
                txtPRateperday.Text = dt.Rows(0).Item("d_rate")
                txtPPayPeriod.Text = dt.Rows(0).Item("p_method")
                txtPEmployeeName.Text = dt.Rows(0).Item("emp_fname") _
                & " " & dt.Rows(0).Item("emp_lname") & " " & dt.Rows(0).Item("emp_mname")


            Else
                cleartxt(GroupBox1)
                cleartxt(GroupBox2)
                cleartxt(GroupBox3)
                cleartxt(GroupBox4)
                cleartxt(GroupBox5)
                cleartxt(GroupBox6)
                cleartxt(GroupBox7)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtPholPayDay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPholPayDay.TextChanged
        Try
            txtPholPay.Text = Double.Parse(txtPRateperday.Text * txtPholPayDay.Text)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnPsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPsave.Click
        Try
            If txtPNoDays.Text = "" Or txtPregOt.Text = "" Or txtPholPay.Text = "" _
            Then
                MsgBox("Missing data. Please fill up.", MsgBoxStyle.Exclamation)

            Else

                sql = "INSERT INTO `other_deduction` " _
                               & "(`emp_code`, `deduct1`, `ded_amount1`, `deduct2`, `ded_amount2`, `deduct3`, " _
                               & "`ded_amount3`, `deduct4`, `ded_amount4`, `total_ded`,trans_id)" _
                               & " VALUES ('" & txtPAssignCode.Text & "','" & txtpdeductname1.Text & "','" _
                               & txtpdeduct1.Text & "','" & txtpdeductname2.Text & "','" & txtpdeduct2.Text _
                               & "','" & txtpdeductname3.Text & "','" & txtpdeductname3.Text _
                               & "','" & txtpdeductname4.Text & "','" & txtpdeductname4.Text _
                               & "','" & txtpdeducttot.Text & "','" & txttrancode.Text & "')"
                createsub(sql)
                sql = "INSERT INTO  `payroll` " _
                & "(`emp_code`, `num_days`, `r_wage`, `overtime`, `hol_pay`, `gross_sal`" _
                & ", `cash_ad`, `bread_vale`, `philhealth`, `pag-ibig`, `net_income`, `remarks`,`dateissued`,trans_id)" _
                & " VALUES ('" & txtPAssignCode.Text & "','" & txtPNoDays.Text & "','" _
                & txtPrateWage.Text & "','" & txtPregOt.Text & "','" & txtPholPay.Text _
                & "','" & txtpgincome.Text & "','" & txtpcadvance.Text & "','" & txtbvale.Text _
                & "','" & txtpphic.Text & "','" & txtppagibig.Text & "','" & txtpnetincome.Text _
                & "','" & txtpremarks.Text & "',Now(),'" & txttrancode.Text & "')"
                create(sql)


                createsub("UPDATE autonumber SET strnum = strnum + increment WHERE id =1")
                txtPAssignCode.Text = ""


            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub TabControl3_Selected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles TabControl3.Selected


        sql = "SELECT DISTINCT (" & _
            "p.`trans_id`" & _
            "),e.emp_code as 'Assign Code', CONCAT(  `emp_fname` ,  ' ',  `emp_lname` ,  ' ',  `emp_mname` ) AS  'Employee'" & _
            ",  `d_rate` AS 'DailyRate' ,  `num_days` AS 'NumberOfDays' ,  `r_wage` AS 'RateWage', " _
            & " `gross_sal` AS 'GrossIncome', `total_ded` AS 'TotalDeduction',  `net_income` AS 'NetIncome' ,  " & _
            " `position` AS 'Postion',`remarks` AS 'Remarks' ,`dateissued` AS 'DateIssued'    " & _
            "FROM  `employee` e,  `payroll` p,  `employee_workinfo` ew,  `other_deduction` od " & _
            "WHERE e.`emp_code` = p.`emp_code` " & _
            "AND p.`emp_code` = ew.`emp_code` " & _
            "AND p.`trans_id` = od.`trans_id` "
        reload(sql, dtgParollList)
        dtgParollList.Columns(0).Visible = False
    End Sub
    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        txtPAssignCode.Text = ""
    End Sub

    Private Sub txtpcadvance_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpphic.Validated, txtppagibig.Validated, txtpdeduct4.Validated, txtpdeduct3.Validated, txtpdeduct2.Validated, txtpdeduct1.Validated, txtpcadvance.Validated, txtbvale.Validated
        Try
            txtpnetincome.Text = txtpgincome.Text
            clearing(GroupBox5)
            clearing(GroupBox6)
            txtpdeducttot.Text = Double.Parse(Val(txtpcadvance.Text) _
                                              + Val(txtbvale.Text) _
                                              + Val(txtpphic.Text) _
                                              + Val(txtppagibig.Text) _
                                               + Val(txtpdeduct1.Text) _
                                              + Val(txtpdeduct2.Text) _
                                              + Val(txtpdeduct3.Text) _
                                              + Val(txtpdeduct4.Text))
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtpcadvance_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpcadvance.TextChanged
        If Not IsNumeric(txtpcadvance.Text) Then
            txtpcadvance.Clear()
        End If
    End Sub

    Private Sub txtbvale_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbvale.TextChanged
        If Not IsNumeric(txtbvale.Text) Then
            txtbvale.Clear()
        End If
    End Sub

    Private Sub txtpphic_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpphic.TextChanged
        If Not IsNumeric(txtpphic.Text) Then
            txtpphic.Clear()
        End If
    End Sub

    Private Sub txtppagibig_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtppagibig.TextChanged
        If Not IsNumeric(txtppagibig.Text) Then
            txtppagibig.Clear()
        End If
    End Sub

    Private Sub txtpdeduct1_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpdeduct1.TextChanged
        If Not IsNumeric(txtpdeduct1.Text) Then
            txtpdeduct1.Clear()
        End If
    End Sub

    Private Sub txtpdeduct2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpdeduct2.TextChanged
        If Not IsNumeric(txtpdeduct2.Text) Then
            txtpdeduct2.Clear()
        End If
    End Sub

    Private Sub txtpdeduct3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpdeduct3.TextChanged
        If Not IsNumeric(txtpdeduct3.Text) Then
            txtpdeduct3.Clear()
        End If
    End Sub

    Private Sub txtpdeduct4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpdeduct4.TextChanged
        If Not IsNumeric(txtpdeduct4.Text) Then
            txtpdeduct4.Clear()
        End If
    End Sub
    Private Sub txtpsearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpsearch.TextChanged
        sql = "SELECT DISTINCT (" & _
             "p.`trans_id`" & _
             "),e.emp_code as 'Assign Code', CONCAT(  `emp_fname` ,  ' ',  `emp_lname` ,  ' ',  `emp_mname` ) AS  'Employee'" & _
             ",  `d_rate` AS 'DailyRate' ,  `num_days` AS 'NumberOfDays' ,  `r_wage` AS 'RateWage', " _
             & " `gross_sal` AS 'GrossIncome', `total_ded` AS 'TotalDeduction',  `net_income` AS 'NetIncome' ,  " & _
             " `position` AS 'Postion',`remarks` AS 'Remarks' ,`dateissued` AS 'DateIssued'    " & _
             "FROM  `employee` e,  `payroll` p,  `employee_workinfo` ew,  `other_deduction` od " & _
             "WHERE e.`emp_code` = p.`emp_code` " & _
             "AND p.`emp_code` = ew.`emp_code` " & _
             "AND p.`trans_id` = od.`trans_id` " & _
             "AND  (emp_fname  LIKE '%" & txtpsearch.Text & "%'" & _
             "OR  emp_lname  LIKE '%" & txtpsearch.Text & "%'" & _
             "OR e.emp_code LIKE '%" & txtpsearch.Text & "%')"
        reload(sql, dtgParollList)
        dtgParollList.Columns(0).Visible = False

    End Sub

    Private Sub txtPNoDays_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPNoDays.TextChanged
        Try
            If Not IsNumeric(txtPNoDays.Text) Then
                txtPNoDays.Clear()

            End If
            txtPrateWage.Text = Double.Parse(txtPRateperday.Text * txtPNoDays.Text)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtPRegOtHr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPRegOtHr.TextChanged
        Try
            If Not IsNumeric(txtPRegOtHr.Text) Then
                txtPRegOtHr.Clear()
            End If
            Dim total As Double
            If txtPRegOtHr.Text = "" Then
                txtPregOt.Clear()
            Else
                total = Double.Parse(txtPRateperday.Text / 8)
                txtPregOt.Text = Double.Parse(total * txtPRegOtHr.Text)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPrateWage_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrateWage.TextChanged
        Try
            txtpgincome.Text = txtPrateWage.Text
        Catch ex As Exception
            '  MsgBox(ex.Message & " txtPrateWage_TextChanged")
        End Try
    End Sub

    Private Sub txtPregOt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPregOt.TextChanged
        Try

            txtpgincome.Text = ((txtPrateWage.Text) + Val(txtPregOt.Text)).ToString("N2")
        Catch ex As Exception
            'MsgBox(ex.Message & " txtPregOt_TextChanged")
        End Try
    End Sub
End Class