Imports System.Xml
'Imports DBCon
Public Class FrmSqlConfig
    'Private myCon As New DBCon.DBClass

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click

        Try
            Dim xtw As XmlTextWriter = New XmlTextWriter("XMLFile1.xml", Nothing)
            With xtw
                .Formatting = Formatting.Indented
                .WriteStartDocument(False)
                .WriteStartElement("Name")
                .WriteElementString("Server", Me.TxtServer.Text)
                .WriteElementString("Uname", Me.TxtName.Text)
                .WriteElementString("Pws", Me.TxtPWd.Text)
                .WriteEndElement()
                .Flush()
                .Close()
            End With

            ' Frm.Show()
            Me.Close()
            'Call myCon.Opencn()
            'If Not myCon.cn.State.Equals(ConnectionState.Open) Then
            If (MessageBox.Show("connection could not open, please try again", "Error in connection", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)) = Windows.Forms.DialogResult.Retry Then
                Me.Close()
                Dim newchild As New FrmSqlConfig
                newchild.Show()
            End If
            'Else
            'MessageBox.Show("Connection succeeded", "Connected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            'End If

            'Me.Hide()
        Catch es As Exception
            'FrmMDI.Close()
            '   Me.Show()
            MsgBox(es.Message)

        End Try
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub
End Class