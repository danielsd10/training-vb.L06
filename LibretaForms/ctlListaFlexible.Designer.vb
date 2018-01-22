<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlListaFlexible
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.txtValor = New System.Windows.Forms.TextBox()
        Me.lblEtiqueta = New System.Windows.Forms.Label()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnQuitar = New System.Windows.Forms.Button()
        Me.lstLista = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'txtValor
        '
        Me.txtValor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtValor.Location = New System.Drawing.Point(126, 10)
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Size = New System.Drawing.Size(210, 22)
        Me.txtValor.TabIndex = 0
        '
        'lblEtiqueta
        '
        Me.lblEtiqueta.AutoSize = True
        Me.lblEtiqueta.Location = New System.Drawing.Point(3, 12)
        Me.lblEtiqueta.Name = "lblEtiqueta"
        Me.lblEtiqueta.Size = New System.Drawing.Size(64, 17)
        Me.lblEtiqueta.TabIndex = 1
        Me.lblEtiqueta.Text = "Etiqueta:"
        '
        'btnAgregar
        '
        Me.btnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAgregar.Location = New System.Drawing.Point(342, 6)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(26, 23)
        Me.btnAgregar.TabIndex = 2
        Me.btnAgregar.Text = "+"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnQuitar
        '
        Me.btnQuitar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnQuitar.Enabled = False
        Me.btnQuitar.Location = New System.Drawing.Point(342, 38)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(26, 23)
        Me.btnQuitar.TabIndex = 3
        Me.btnQuitar.Text = "-"
        Me.btnQuitar.UseVisualStyleBackColor = True
        '
        'lstLista
        '
        Me.lstLista.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstLista.FormattingEnabled = True
        Me.lstLista.ItemHeight = 16
        Me.lstLista.Location = New System.Drawing.Point(3, 38)
        Me.lstLista.Name = "lstLista"
        Me.lstLista.Size = New System.Drawing.Size(333, 100)
        Me.lstLista.TabIndex = 4
        '
        'ctlListaFlexible
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lstLista)
        Me.Controls.Add(Me.btnQuitar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.lblEtiqueta)
        Me.Controls.Add(Me.txtValor)
        Me.Name = "ctlListaFlexible"
        Me.Size = New System.Drawing.Size(371, 141)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtValor As TextBox
    Friend WithEvents lblEtiqueta As Label
    Friend WithEvents btnAgregar As Button
    Friend WithEvents btnQuitar As Button
    Friend WithEvents lstLista As ListBox
End Class
