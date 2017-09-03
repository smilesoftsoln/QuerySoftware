
Partial Class test1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim name As EO.Web.StaticColumn = New EO.Web.StaticColumn()

        name.AllowSort = True
        name.HeaderText = "Full Name"
        Grid1.Columns.Add(name)

        name = New EO.Web.StaticColumn()
        name.AllowSort = True
        name.HeaderText = "Address"
        Grid1.Columns.Add(name)

        name = New EO.Web.StaticColumn()
        name.AllowSort = True
        name.HeaderText = "City"
        Grid1.Columns.Add(name)

        name = New EO.Web.StaticColumn()
        name.AllowSort = True
        name.HeaderText = "State"
        Grid1.Columns.Add(name)

        Dim row As EO.Web.GridItem = Grid1.CreateItem()
        row.Cells.Item(0).Value = "Sanjay Gulabani"
        row.Cells.Item(1).Value = "Shiv Srushti"
        row.Cells.Item(2).Value = "Mumbai"
        row.Cells.Item(3).Value = "Maharashtra"

        Grid1.Items.Add(row)

        'Grid1.


    End Sub
End Class
