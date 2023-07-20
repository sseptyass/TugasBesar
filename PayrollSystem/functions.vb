Module functions
    Public Sub cleartxt(ByVal obj As Object)
        For Each txt As Control In obj.controls
            If txt.GetType Is GetType(TextBox) Then
                txt.Text = ""
            End If
        Next
        For Each txt As Control In obj.controls
            If txt.GetType Is GetType(RichTextBox) Then
                txt.Text = ""
            End If
        Next
    End Sub
   
End Module
