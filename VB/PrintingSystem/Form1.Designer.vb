Namespace RichEdit_PrintingSystem

    Partial Class Form1

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Me.components IsNot Nothing) Then
                Me.components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.btn_PrintFromServer = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            ' 
            ' btn_PrintFromServer
            ' 
            Me.btn_PrintFromServer.Location = New System.Drawing.Point(180, 50)
            Me.btn_PrintFromServer.Name = "btn_PrintFromServer"
            Me.btn_PrintFromServer.Size = New System.Drawing.Size(146, 23)
            Me.btn_PrintFromServer.TabIndex = 2
            Me.btn_PrintFromServer.Text = "Load and Print"
            AddHandler Me.btn_PrintFromServer.Click, New System.EventHandler(AddressOf Me.btn_PrintFromServer_Click)
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(506, 130)
            Me.Controls.Add(Me.btn_PrintFromServer)
            Me.Name = "Form1"
            Me.Text = "Form1"
            Me.ResumeLayout(False)
        End Sub

#End Region
        Private btn_PrintFromServer As System.Windows.Forms.Button
    End Class
End Namespace
