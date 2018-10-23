Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class FrmGL
    Dim CompanyNames As String
    Public Compstr As String

    Private Sub FrmGL_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Left = 0
        Me.Top = 0
        Module1.Opencn()
        Me.Width = Screen.PrimaryScreen.Bounds.Width - 4
        Me.Height = Screen.PrimaryScreen.Bounds.Height - 4



        Dim sts As Boolean

        Module1.DatasetFill("select * from CompannySetUp", "CompannySetUp")
        Try
            CompanyNames = ds.Tables("CompannySetUp").Rows(0).Item(0)
        Catch ex As Exception

        End Try


        sts = Module1.GetValue("AccStatus", "FinancialPeriod", "PID=N'" & Frm.LblPeriod.Text & "'")
        Module1.DatasetFill("Select * from GlReport order by Date", "GLReport")

        '''''''''''''''''''''''''''''for Crystal Report '''''''''''''''''''''''''''''''''''''''''''


        '  Call ReportShow()


        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        'Module1.DatasetFill("Select * from VuPermission Where GroupID=" & Frm.GID.Text & " and PerName='Vouchers'", "VuPermission")
        'If ds.Tables("VuPermission").Rows(0).Item("ReadOnly") = False And ds.Tables("VuPermission").Rows(0).Item("Created") = False And ds.Tables("VuPermission").Rows(0).Item("CModify") = False Then
        '    Me.Close()
        '    MsgBox("You have no right to view this Form . For further detail contact your administrator", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Alert")
        '    Exit Sub
        Module1.DatasetFill("Select CustomerID,CustomerName from Customer", "Customer")
        cmbCustomer.DataSource = ds.Tables("Customer")
        cmbCustomer.DisplayMember = ("CustomerName")
        cmbCustomer.ValueMember = ("CustomerID")



        Module1.DatasetFill("Select * from Vendor", "Vendor")
        cmbRecord.DataSource = ds.Tables("Vendor")
        cmbRecord.DisplayMember = ("Name")
        cmbRecord.ValueMember = ("VID")

        Module1.DatasetFill("Select * from VuGL where  FullName in(N" & Compstr & ") and PID=N'" & Frm.LblPeriod.Text & "' order by Date ", "VuGL")
        Module1.DatasetFill("Select * from Chartofaccount", "Chartofacc")
        'CmbHeads.DataSource = ds.Tables("Chartofacc")
        'CmbHeads.ValueMember = "HeadName"
        'CmbHeads.DisplayMember = "HeadID"
     
        Module1.DatasetFill("Select * from VuChart", "VuChart")
        CmbHeads.DataSource = ds.Tables("VuChart")
        CmbHeads.DisplayMember = "HeadName"
        CmbHeads.ValueMember = "HeadID"

        'Fahim's code for Izat Afghan Limited
        cmbHeadCode.DataSource = ds.Tables("VuChart")
        cmbHeadCode.DisplayMember = "HeadName"
        cmbHeadCode.ValueMember = "HeadID"
        'Ended here
        DtHead1.Value = Now
        DtHead2.Value = Now
        CV.Dock = DockStyle.None
        CV.Top = 192 ' Panel3.Bottom
        CV.Width = Me.Width
        CV.Height = Me.Height - Panel3.Height

    End Sub

    Private Sub BtnHeads_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHeads.Click
        'Fahim's Code for IAL
        If chkSpecificSubHead.Checked.Equals(True) Then
            Cursor = Cursors.WaitCursor
            Dim drow As DataRow
            Module1.DeleteRecord("GlReport")
            Dim Balan As Decimal
            '       Dim dr As Decimal
            '        Dim cr As Decimal


            'MessageBox.Show(ds.Tables("VuGL").Rows.Count)

            For Each drow In ds.Tables("VuGl").Rows
                Try

                    If drow("HeadID") = cmbHeadCode.SelectedValue And drow("SubName") = cmbSubHeadName.Text And drow("date") >= Me.DtHead1.Value.Date And drow("date") <= Me.DtHead2.Value.Date Then
                        Balan = Balan + drow("Dr") - drow("Cr")
                        Module1.InsertRecord("GlReport", "'" & drow("Vno") & "','" & drow("Date") & "','" & drow("HeadID") & "','" & drow("HeadName") & "','" & drow("SubName") & "','" & drow("descr") & "'," & Val(drow("Dr")) & "," & Val(drow("Cr")) & "," & Balan & ",'" & drow("CompanyName") & "'")
                    End If



                Catch ex As Exception

                End Try
            Next
            Call ReportShow()
            Cursor = Cursors.Default
        Else


            Dim drow As DataRow
            Module1.DeleteRecord("GlReport")
            Dim Balan As Decimal
            '       Dim dr As Decimal
            '        Dim cr As Decimal
            For Each drow In ds.Tables("VuGl").Rows
                If drow("HeadID") = CmbHeads.SelectedValue And drow("date") >= Me.DtHead1.Value.Date And drow("date") <= Me.DtHead2.Value.Date Then
                    Balan = Balan + drow("Dr") - drow("Cr")
                    Module1.InsertRecord("GlReport", "'" & drow("Vno") & "','" & drow("Date") & "','" & drow("HeadID") & "','" & drow("HeadName") & "','" & drow("SubName") & "','" & drow("descr") & "'," & Val(drow("Dr")) & "," & Val(drow("Cr")) & "," & Balan & ",'" & drow("CompanyName") & "'")
                End If

            Next
            Call ReportShow()
        End If
    End Sub

    Sub ReportShow()
        Dim PField As New ParameterField
        Dim DSv As New ParameterDiscreteValue
        Dim ps As New ParameterFields
        Module1.DatasetFill("Select * from GlReport order by Date", "GLReport")
        Dim rpt As New RptGL
        rpt.SetDataSource(ds.Tables("GlReport"))

        PField.ParameterFieldName = "CompanyName"
        DSv.Value = CompanyNames
        PField.CurrentValues.Add(DSv)
        ps.Add(PField)

        CV.ParameterFieldInfo = ps
        CV.ReportSource = rpt

    End Sub
    Sub ReportShowIzatAfghan()
        Dim PField As New ParameterField
        Dim DSv As New ParameterDiscreteValue
        Dim ps As New ParameterFields
        Module1.DatasetFill("Select * from CompanyRecord", "CompanyRecord")
        Dim rpt As New RptCompanyRecord
        rpt.SetDataSource(ds.Tables("CompanyRecord"))

        PField.ParameterFieldName = "CompanyName"
        DSv.Value = CompanyNames
        PField.CurrentValues.Add(DSv)
        ps.Add(PField)

        CV.ParameterFieldInfo = ps
        CV.ReportSource = rpt

    End Sub

    'Private Sub RBHeads_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBHeads.CheckedChanged
    '    PanDate.Visible = False
    '    Panel2.Visible = True
    'End Sub

    'Private Sub RBDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBDate.CheckedChanged
    '    PanDate.Visible = True
    '    Panel2.Visible = False
    'End Sub

    Private Sub CV_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CV.DoubleClick
        'If Panel1.Visible = False Then
        '    Panel1.Visible = True
        '    PanDate.Visible = True
        '    Panel2.Visible = True
        '    If RBHeads.Checked = True Then
        '        PanDate.Visible = False
        '        Panel2.Visible = False

        '    Else
        '        PanDate.Visible = False
        '        Panel2.Visible = False

        '    End If
        'Else
        '    Panel1.Visible = False
        '    PanDate.Visible = False
        '    Panel2.Visible = False
        'End If


    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim drow As DataRow
        Dim NewDrow As DataRow
        Dim FirstTotal As Double
        Dim SecandTotal As Double
        Dim GrandTotal As Double

        Module1.DeleteRecord("CompanyRecord")
        Cursor = Cursors.WaitCursor
        Dim Balan As Decimal
        '       Dim dr As Decimal
        '        Dim cr As Decimal
        Module1.DatasetFill("Select * from VuCompanyRecord where SubID=" & cmbRecord.SelectedValue, "VuCompanyRecord")
        SecandTotal = 0
        For Each drow In ds.Tables("VuCompanyRecord").Rows
            If drow("SubID") = cmbRecord.SelectedValue And drow("date") >= Me.DtDate1.Value.Date And drow("date") <= Me.DtDate2.Value.Date Then
                Module1.DatasetFill("Select * from PurchasePayment where PurchaseID=" & drow("PurchaseID") & "", "PurchasePayment")
                Balan = 0
                Balan = Balan + drow("Dr") - drow("Cr")
                FirstTotal = Balan
                If ds.Tables("PurchasePayment").Rows.Count = 0 Then
                    FirstTotal = SecandTotal + FirstTotal
                End If
                'if 
                '    Dim aziz_dewana As Integer = drow("Dr")
                '    Dim aziz_mastana As Integer = drow("Cr")

                Module1.InsertRecord("CompanyRecord", "'" & drow("Vno") & "','" & drow("Date") & "','" & drow("HeadName") & "','" & drow("SubName") & "'," & drow("Dr") & "," & drow("Cr") & "," & Balan & ",'" & drow("CompanyName") & "'," & FirstTotal & "")
                'Module1.InsertRecord("CompanyRecord", "'" & drow("Vno") & "','" & drow("dtDate") & "','Cash','" & drow("SubName") & "',0," & Val(drow("Amount")) & "," & Balan & ",'" & drow("CompanyName") & "'")

                For Each NewDrow In ds.Tables("PurchasePayment").Rows
                    If NewDrow("PurchaseID") = drow("PurchaseID") Then
                        Balan = Balan - NewDrow("Amount")
                        GrandTotal = SecandTotal + Balan
                        'Module1.InsertRecord("CompanyRecord", "'" & drow("Vno") & "','" & drow("Date") & "','" & drow("HeadName") & "','" & drow("SubName") & "'," & Val(drow("Dr")) & "," & Val(drow("Cr")) & "," & Balan & ",'" & drow("CompanyName") & "'")
                        Module1.InsertRecord("CompanyRecord", "'" & drow("Vno") & "','" & NewDrow("dtDate") & "','Cash','" & drow("SubName") & "',0," & NewDrow("Amount") & "," & Balan & ",'" & drow("CompanyName") & "'," & GrandTotal & "")
                    End If
                Next
                SecandTotal = GrandTotal
            End If
        Next
        Call ReportShowIzatAfghan()
        Cursor = Cursors.Default
    End Sub

    Private Sub CV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CV.Load

    End Sub

    Private Sub CmbHeads_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbHeads.KeyDown
        If e.KeyCode = Keys.F1 Then
            'Dim frm As FrmFind
            'Dim frm As New FrmFind("SELECT HEADCODE as 'Head Code',HEADNAME as 'Head Name' FROM CHARTOFACC")
            FrmFind2.Obj = Me
            ' If FrmFind.Visible = True Then Exit Sub
            FrmFind2.Show()
        End If
    End Sub

    Private Sub CmbHeads_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbHeads.SelectedIndexChanged

    End Sub

    Private Sub PanDate_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanDate.Paint

    End Sub

    Private Sub cmbHeadCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbHeadCode.SelectedIndexChanged
        Try
            'Fahim's code for Izat Afghan Limited
            Module1.DatasetFill("Select Distinct(SubName) from VuSubHeadCode where HeadID ='" & cmbHeadCode.SelectedValue & "'", "VuSubHeadCode")
            cmbSubHeadName.DataSource = ds.Tables("VuSubHeadCode")
            cmbSubHeadName.DisplayMember = "SubName"
            cmbSubHeadName.ValueMember = "SubID"
            'Ended here
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkSpecificSubHead_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSpecificSubHead.CheckedChanged
        If chkSpecificSubHead.Checked.Equals(True) Then
            cmbHeadCode.Visible = True
            cmbSubHeadName.Visible = True
            CmbHeads.Visible = False
            Label4.Visible = True
            Label7.Visible = True
            Label3.Visible = False
        Else
            CmbHeads.Visible = True
            cmbHeadCode.Visible = False
            cmbSubHeadName.Visible = False
            Label4.Visible = False
            Label7.Visible = False
            Label3.Visible = True
        End If
    End Sub

    Private Sub btnCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomer.Click
        Dim drow As DataRow
        Dim NewDrow As DataRow
        Dim FirstTotal As Decimal
        Dim SecandTotal As Decimal
        Dim GrandTotal As Decimal

        Dim FinalGrand As Decimal
        Cursor = Cursors.WaitCursor
        Module1.DeleteRecord("CompanyRecord")
        Dim Balan As Decimal
        '       Dim dr As Decimal
        '        Dim cr As Decimal
        Module1.DatasetFill("Select * from VuCustomerRecordDetail where SubID=" & cmbCustomer.SelectedValue, "VuCustomerRecordDetail")
        If ds.Tables("VuCustomerRecordDetail").Rows.Count <> 0 Then
            SecandTotal = 0
            Balan = 0
            For Each drow In ds.Tables("VuCustomerRecordDetail").Rows

                If drow("SubID") = cmbCustomer.SelectedValue And drow("Date") >= Me.dtFromCustomer.Value.Date And drow("Date") <= Me.dtToCustomer.Value.Date Then


                    Module1.DatasetFill("Select * from SalePayment where SaleID=" & drow("SaleID") & "", "SalePayment")

                    If drow("HeadName") = "Sale" Then
                        Balan = Balan + drow("Dr") - drow("Cr")
                        FirstTotal = Balan
                    Else
                        Dim newrcd As Decimal = drow("Cr") - drow("Dr")
                        Balan = Balan - newrcd
                        FirstTotal = Balan
                    End If
                    If ds.Tables("SalePayment").Rows.Count = 0 Then
                        FirstTotal = SecandTotal + FirstTotal
                    End If

                    Module1.InsertRecord("CompanyRecord", "'" & drow("Vno") & "','" & drow("Date") & "','" & drow("HeadName") & "','" & drow("SubName") & "'," & Val(drow("Dr")) & "," & Val(drow("Cr")) & "," & Balan & ",'" & drow("CompanyName") & "'," & FirstTotal & "")
                    'Module1.InsertRecord("CompanyRecord", "'" & drow("Vno") & "','" & drow("dtDate") & "','Cash','" & drow("SubName") & "',0," & Val(drow("Amount")) & "," & Balan & ",'" & drow("CompanyName") & "'")
                    If drow("HeadName") = "Sale" Then
                        For Each NewDrow In ds.Tables("SalePayment").Rows
                            If NewDrow("SaleID") = drow("SaleID") Then
                                Balan = Balan - NewDrow("Amount")
                                GrandTotal = SecandTotal + Balan
                                'Module1.InsertRecord("CompanyRecord", "'" & drow("Vno") & "','" & drow("Date") & "','" & drow("HeadName") & "','" & drow("SubName") & "'," & Val(drow("Dr")) & "," & Val(drow("Cr")) & "," & Balan & ",'" & drow("CompanyName") & "'")
                                Module1.InsertRecord("CompanyRecord", "'" & drow("Vno") & "','" & NewDrow("PaymentDate") & "','Cash','" & drow("SubName") & "',0," & Val(NewDrow("Amount")) & "," & Balan & ",'" & drow("CompanyName") & "'," & GrandTotal & "")
                            End If
                        Next
                        SecandTotal = GrandTotal
                    End If

                End If
            Next
            Module1.DatasetFill("Select * from VuObrayeeForAccount where CustomerID=" & drow("SubID"), "VuObrayeeForAccount")
            Dim UpperTotal As Decimal = Balan
            Dim TheFinalistGrand As Decimal
            For Each NewOneDrow As DataRow In ds.Tables("VuObrayeeForAccount").Rows


                Dim ObrayeeID As String = "Obrayee" & "-" & NewOneDrow("ObrayeID")
                'Dim FinalTotal As Decimal = FinalGrand - FirstTotal - NewOneDrow("Paid")
                UpperTotal = UpperTotal - NewOneDrow("Paid")

                FinalGrand = UpperTotal - FinalGrand + TheFinalistGrand
                Module1.InsertRecord("CompanyRecord", "'" & ObrayeeID & "','" & NewOneDrow("ObrayeDate") & "','Cash Through Obrayee','" & drow("SubName") & "',0," & Val(NewOneDrow("Paid")) & "," & UpperTotal & ",'" & drow("CompanyName") & "'," & FinalGrand & "")
                TheFinalistGrand = FinalGrand
            Next
        End If
        Call ReportShowIzatAfghan()
        Cursor = Cursors.Default
    End Sub

End Class