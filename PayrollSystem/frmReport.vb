Public Class frmReport

    Private Sub frmReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Sub weeklypayroll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnweeklypayroll.Click
        reports("SELECT CONCAT(  `emp_lname` ,  ' , ',  `emp_fname` ),`num_days` ,  `d_rate` ,  `r_wage` ,  `overtime` , `hol_pay` ,  `gross_sal` ,  `cash_ad` ,  `bread_vale` ,  `philhealth` ,  `deduct1` ,  `ded_amount1` , `deduct2` ,  `ded_amount2` ,  `deduct3` ,  `ded_amount3` ,  `total_ded` ,  `net_income` ,`dateissued` " _
            & "FROM  `employee` e,  `employee_workinfo` we,  `payroll` p,  `other_deduction` od " _
            & "WHERE e.`emp_code` = p.`emp_code` " _
            & "AND p.`emp_code` = we.`emp_code` " _
            & "AND p.`trans_id` = od.`trans_id` ", "weeklypayroll", CrystalReportViewer1)
    End Sub

    Private Sub btnPayslip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPayslip.Click
        sql = "SELECT CONCAT(  `emp_lname` ,  ' , ',  `emp_fname` ) ,`num_days` , `d_rate` ,  `r_wage` " _
        & ",  `overtime` , `hol_pay` ,  `gross_sal` ,  `cash_ad` ,  `bread_vale` ,  `philhealth` , " _
        & "`pag-ibig`,  `deduct1` ,  `ded_amount1` , `deduct2` ,  `ded_amount2` ,  `deduct3` ,  " _
        & "`ded_amount3` ,  `total_ded` ,  `net_income` ,`dateissued`" & _
        " FROM  `employee` e,  `employee_workinfo` we,  `payroll` p,  `other_deduction` od " & _
        " WHERE e.`emp_code` = p.`emp_code` " & _
        " AND p.`emp_code` = we.`emp_code` " & _
        " AND p.`trans_id` = od.`trans_id` "
        reports(sql, "payslip", CrystalReportViewer1)

    End Sub
End Class