Imports CommonLibrary
Imports UserLibrary
Partial Class UIControls_PollsAddEdit
    Inherits System.Web.UI.UserControl
    Public Event HideControl()

    Public Property PollID As Integer
        Get
            If Not IsNothing(ViewState("PollID")) AndAlso IsNumeric(ViewState("PollID")) Then
                Return CInt(ViewState("PollID"))
            Else
                Return 0
            End If
        End Get
        Set(value As Integer)
            ViewState("PollID") = value
        End Set
    End Property
    Public Property UnionversealPoll As Boolean
        Get
            If Not IsNothing(ViewState("UnionversealPoll")) AndAlso IsNumeric(ViewState("UnionversealPoll")) Then
                Return CBool(ViewState("UnionversealPoll"))
            Else
                Return False
            End If
        End Get
        Set(value As Boolean)
            ViewState("UnionversealPoll") = value
        End Set
    End Property
    Public Property PorfitSpendingPolls As Boolean
        Get
            If Not IsNothing(ViewState("PorfitSpendingPolls")) AndAlso IsNumeric(ViewState("PorfitSpendingPolls")) Then
                Return CBool(ViewState("PorfitSpendingPolls"))
            Else
                Return False
            End If
        End Get
        Set(value As Boolean)
            ViewState("PorfitSpendingPolls") = value
        End Set
    End Property
    Public Property ParentCategoryID As Integer
        Get
            If Not IsNothing(ViewState("ParentCategoryID")) AndAlso IsNumeric(ViewState("ParentCategoryID")) Then
                Return CInt(ViewState("ParentCategoryID"))
            Else
                Return 0
            End If
        End Get
        Set(value As Integer)
            ViewState("ParentCategoryID") = value
        End Set
    End Property
    Public Property CategoryID As Integer
        Get
            If Not IsNothing(ViewState("CategoryID")) AndAlso IsNumeric(ViewState("CategoryID")) Then
                Return CInt(ViewState("CategoryID"))
            Else
                Return 0
            End If
        End Get
        Set(value As Integer)
            ViewState("CategoryID") = value
        End Set
    End Property

    Public ReadOnly Property UserID As Integer
        Get
            If Not IsNothing(Session("Users")) AndAlso CType(Session("Users"), Users).UserID > 0 Then
                Return CType(Session("Users"), Users).UserID
            Else
                Return 0
            End If
        End Get
    End Property
    Public Sub LoadData()
        Me.ddParentCategory.SelectedValue = ParentCategoryID
        If ParentCategoryID = 1 Then
            Me.ddGovernmentsubCategory.Visible = False
            Me.ddBusinessSubCategory.Visible = True
            Me.ddBusinessSubCategory.SelectedValue = CategoryID

        ElseIf ParentCategoryID = 2 Then
            Me.ddGovernmentsubCategory.Visible = True
            Me.ddGovernmentsubCategory.SelectedValue = CategoryID
            Me.ddBusinessSubCategory.Visible = False
        Else
            Me.ddGovernmentsubCategory.Visible = False
            Me.ddBusinessSubCategory.Visible = False
        End If

        LoadCountryState()
        Dim oPoll As New Polls(PollID)
        If Not IsNothing(oPoll) AndAlso oPoll.PollID > 0 Then
            Me.txtQuestion.Text = oPoll.PollQuestion
            Me.txtDescription.Text = oPoll.PollDescription
            If oPoll.CountryCode.Trim.Length > 0 Then
                If Not IsNothing(Me.ddCountry) AndAlso Me.ddCountry.Items.Count > 0 AndAlso Not IsNothing(Me.ddCountry.Items.FindByValue(oPoll.CountryCode)) Then
                    Me.ddCountry.SelectedValue = oPoll.CountryCode
                End If
            End If
            If oPoll.StateCode.Trim.Length > 0 Then
                If Not IsNothing(Me.ddState) AndAlso Me.ddState.Items.Count > 0 AndAlso Not IsNothing(Me.ddState.Items.FindByValue(oPoll.StateCode)) Then
                    Me.ddState.SelectedValue = oPoll.StateCode
                End If
            End If
            If Not IsNothing(Me.ddParentCategory) AndAlso Me.ddParentCategory.Items.Count > 0 AndAlso Not IsNothing(Me.ddParentCategory.Items.FindByValue(oPoll.ParentCategoryID)) Then
                Me.ddParentCategory.SelectedValue = oPoll.ParentCategoryID
            End If
            Me.txtCity.Text = oPoll.City
            Me.txtZipCode.Text = oPoll.ZipCode
            Me.chkIsUnionversal.Checked = oPoll.IsUnionversal
            Me.chkIsProfitSpending.Checked = oPoll.IsProfitSpending
            If oPoll.PollID > 0 Then
                Me.phAnswers.Visible = True
            End If

            If oPoll.ParentCategoryID = 1 Then
                Me.ddGovernmentsubCategory.Visible = False
                Me.ddBusinessSubCategory.Visible = True
                Me.ddBusinessSubCategory.SelectedValue = oPoll.CategoryID

            ElseIf oPoll.ParentCategoryID = 2 Then
                Me.ddGovernmentsubCategory.Visible = True
                Me.ddGovernmentsubCategory.SelectedValue = oPoll.CategoryID
                Me.ddBusinessSubCategory.Visible = False

            Else
                Me.ddGovernmentsubCategory.Visible = False
                Me.ddBusinessSubCategory.Visible = False
            End If

        Else
            Me.phAnswers.Visible = False
            Me.txtQuestion.Text = ""
            Me.txtDescription.Text = ""
            Me.txtCity.Text = ""
            Me.txtZipCode.Text = ""
            Me.chkIsUnionversal.Checked = UnionversealPoll
            Me.chkIsProfitSpending.Checked = PorfitSpendingPolls
        End If
        LoadGrid()
    End Sub

    Public Function IsValidate() As Boolean
        Me.lblError.Text = ""
        If Me.ddParentCategory.SelectedValue = 0 Then
            Me.lblError.Text = "Please Select Poll Category."
            Return False
        End If
        If Me.txtQuestion.Text.Trim.Length = 0 Then
            Me.lblError.Text = ""
            Return False
        End If
        Return True
    End Function
    Public Sub SaveData()
        Dim oPoll As New Polls(PollID)
        If IsNothing(oPoll) OrElse oPoll.PollID <= 0 Then
            oPoll = New Polls
            oPoll.ByUserID = UserID
            oPoll.PollGUID = Guid.NewGuid
            oPoll.AllowMultipleAnswer = True
            oPoll.DateCreated = DateTime.Now
            oPoll.DateOpenFrom = DateTime.Now
            oPoll.DateOpenTo = DateTime.Now.AddYears(1)
            oPoll.LastModified = DateTime.Now
            oPoll.IsActive = True
            oPoll.IsLocked = False


        End If
        oPoll.ParentCategoryID = Me.ddParentCategory.SelectedItem.Value
        oPoll.ParentCategoryName = Me.ddParentCategory.SelectedItem.Text

        If Me.ddParentCategory.SelectedValue = 1 Then
            oPoll.CategoryID = Me.ddBusinessSubCategory.SelectedItem.Value
            oPoll.CategoryName = Me.ddBusinessSubCategory.SelectedItem.Text
        ElseIf Me.ddParentCategory.SelectedValue = 2 Then
            oPoll.CategoryID = Me.ddGovernmentsubCategory.SelectedItem.Value
            oPoll.CategoryName = Me.ddGovernmentsubCategory.SelectedItem.Text
        End If

        oPoll.CountryCode = Me.ddCountry.SelectedItem.Value
        oPoll.CountryName = Me.ddCountry.SelectedItem.Text
        oPoll.StateCode = Me.ddState.SelectedItem.GetHashCode
        oPoll.StateName = Me.ddState.SelectedItem.Text
        oPoll.City = Me.txtCity.Text.Trim
        oPoll.ZipCode = Me.txtZipCode.Text.Trim

        oPoll.PollQuestion = Me.txtQuestion.Text.Trim
        oPoll.PollDescription = Me.txtDescription.Text.Trim
        oPoll.IsUnionversal = Me.chkIsUnionversal.Checked
        oPoll.IsProfitSpending = Me.chkIsProfitSpending.Checked
        oPoll.save()

        PollID = oPoll.PollID
        LoadData()
    End Sub
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If IsValidate() Then
            SaveData()
        End If
    End Sub
    Protected Sub ddCountry_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddCountry.SelectedIndexChanged
        UIHelper.LoadStatesByCountry(Me.ddState, "-- Select State --", CInt(Me.ddCountry.SelectedValue))
        If Me.ddState.Items.Count = 0 Then
            Me.ddState.Visible = False
        Else
            Me.ddState.Visible = True
        End If
    End Sub
    Public Sub LoadCountryState()
        UIHelper.LoadCountry(Me.ddCountry, "--Select Country")
        Me.ddCountry.SelectedValue = "271"

        UIHelper.LoadStatesByCountry(Me.ddState, "-- Select State --", CInt(Me.ddCountry.SelectedValue))
        If Me.ddState.Items.Count = 0 Then
            Me.ddState.Visible = False
        Else
            Me.ddState.Visible = True
        End If

    End Sub

    Public Sub LoadGrid()
        Dim oPO As New PollOptions
        Dim Arl As New ArrayList
        If PollID > 0 Then
            Arl = oPO.GetByFillter(0, PollID)
        End If
        If IsNothing(Arl) Then
            Arl = New ArrayList
        End If
        Me.rpPollOpyion.DataSource = Arl
        Me.rpPollOpyion.DataBind()
        If Arl.Count > 0 Then
            Me.rpPollOpyion.Visible = True
            Me.btnSaveAll.Visible = True
        Else
            Me.rpPollOpyion.Visible = False
            Me.btnSaveAll.Visible = False
        End If
    End Sub

    Protected Sub btnAnswer_Click(sender As Object, e As EventArgs) Handles btnAnswer.Click
        If IsValidateAnswer() Then
            Dim oPO As New PollOptions()
            oPO.OptionText = Me.txtAnswer.Text.Trim
            oPO.PollID = PollID
            oPO.OptionOrder = 0
            oPO.save()
            Me.txtAnswer.Text = ""
            LoadGrid()
        End If
    End Sub
    Public Function IsValidateAnswer() As Boolean
        Me.lblError.Text = ""
        If PollID <= 0 Then
            Me.lblError.Text = "Please save question answer first."
            Return False
        End If
        If Me.txtAnswer.Text.Trim.Length = 0 Then
            Me.lblError.Text = "Please enter answer."
            Return False
        End If
        Return True
    End Function

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        RaiseEvent HideControl()
    End Sub

    Protected Sub rpPollOpyion_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rpPollOpyion.ItemCommand
        If e.CommandName.ToUpper = "DELETE" Then
            Dim oPO As New PollOptions
            oPO.Delete(CInt(e.CommandArgument))
            LoadGrid()
        End If
    End Sub

    Protected Sub btnSaveAll_Click(sender As Object, e As EventArgs) Handles btnSaveAll.Click
        For Each rpi As RepeaterItem In Me.rpPollOpyion.Items
            Dim oPO As New PollOptions(CInt(CType(rpi.FindControl("lblPollOptionID"), Label).Text))
            oPO.OptionText = CType(rpi.FindControl("txtOptionText"), TextBox).Text
            oPO.save()
        Next
        LoadGrid()
    End Sub

    Protected Sub ddParentCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddParentCategory.SelectedIndexChanged
        ParentCategoryID = ddParentCategory.SelectedValue
        If ParentCategoryID = 1 Then
            Me.ddGovernmentsubCategory.Visible = False
            Me.ddBusinessSubCategory.Visible = True
            Me.ddBusinessSubCategory.SelectedValue = CategoryID

        ElseIf ParentCategoryID = 2 Then
            Me.ddGovernmentsubCategory.Visible = True
            Me.ddGovernmentsubCategory.SelectedValue = CategoryID
            Me.ddBusinessSubCategory.Visible = False

        Else
            Me.ddGovernmentsubCategory.Visible = False
            Me.ddBusinessSubCategory.Visible = False
        End If
    End Sub
End Class
