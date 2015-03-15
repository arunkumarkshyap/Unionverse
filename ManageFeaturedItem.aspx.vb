
Partial Class ManageFeaturedItem
    Inherits System.Web.UI.Page

    Protected Sub FeaturedItems1_HideAllListers() Handles FeaturedItems1.HideAllListers
        ph1.Visible = True
        ph2.Visible = False
        ph3.Visible = False
    End Sub

    Protected Sub FeaturedItems2_HideAllListers() Handles FeaturedItems2.HideAllListers
        ph1.Visible = False
        ph2.Visible = True
        ph3.Visible = False
    End Sub

    Protected Sub FeaturedItems3_HideAllListers() Handles FeaturedItems3.HideAllListers
        ph1.Visible = False
        ph2.Visible = False
        ph3.Visible = True
    End Sub

    Protected Sub FeaturedItems1_ShowAllListers() Handles FeaturedItems1.ShowAllListers, FeaturedItems2.ShowAllListers, FeaturedItems3.ShowAllListers
        ph1.Visible = True
        ph2.Visible = True
        ph3.Visible = True
    End Sub

  
End Class
