Imports System.ComponentModel

Public Class ctlListaFlexible

    Private _Etiqueta As String = "Etiqueta"

    <EditorAttribute(GetType(ctlListaFlexible),
    GetType(System.String))>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
    Public Property Etiqueta
        Get
            Return _Etiqueta
        End Get
        Set(value)
            _Etiqueta = value
            lblEtiqueta.Text = _Etiqueta & ":"
        End Set
    End Property
    Public Property Lista As List(Of String)
        Get
            Dim l As New List(Of String)
            Dim i As Integer
            For i = 0 To lstLista.Items.Count - 1
                l.Add(lstLista.Items(i))
            Next
            Return l
        End Get
        Set(value As List(Of String))
            Dim i As Integer
            lstLista.Items.Clear()
            For i = 0 To value.Count - 1
                lstLista.Items.Add(value.Item(i))
            Next
        End Set
    End Property

    Public Sub AgregarItem(txtValor As String)
        lstLista.Items.Add(txtValor)
    End Sub

    Public Sub EliminarItem(intIndice As Integer)
        Try
            lstLista.Items.RemoveAt(intIndice)
        Catch
            MessageBox.Show("No se indicó un elemento existente")
        End Try
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If txtValor.Text <> "" Then
            AgregarItem(txtValor.Text)
            txtValor.Text = ""
            btnQuitar.Enabled = False
            txtValor.Focus()
        Else
            MessageBox.Show("Se debe ingresar un valor")
        End If
    End Sub

    Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
        EliminarItem(lstLista.SelectedIndex)
    End Sub

    Private Sub lstLista_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstLista.SelectedIndexChanged
        btnQuitar.Enabled = lstLista.SelectedIndex > -1
    End Sub

    Private Sub ctlListaFlexible_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblEtiqueta.Text = _Etiqueta
    End Sub
End Class
