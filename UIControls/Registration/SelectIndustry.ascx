<%@ Control Language="VB" AutoEventWireup="false" CodeFile="SelectIndustry.ascx.vb"
    Inherits="CMSModules_Membership_Controls_SelectIndustry" %>
<asp:Label runat="server" ID="lblError" Text="" ForeColor="Red"></asp:Label>
<asp:UpdatePanel runat="server" ID="UPfdh1">
    <ContentTemplate>
        <div style="height: 500px; overflow: auto;">
            <asp:RadioButtonList ID="rdIndustry" runat="server" RepeatLayout="Table" RepeatColumns="3"
                RepeatDirection="Vertical">
                <asp:ListItem Text="Accounting - Finance" Value="Accounting - Finance" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Advertising" Value="Advertising"></asp:ListItem>
                <asp:ListItem Text="Agriculture" Value="Agriculture"></asp:ListItem>
                <asp:ListItem Text="Airline - Aviation" Value="Airline - Aviation"></asp:ListItem>
                <asp:ListItem Text="Architecture - Building" Value="Architecture - Building"></asp:ListItem>
                <asp:ListItem Text="Art - Photography - Journalism" Value="Art - Photography - Journalism"></asp:ListItem>
                <asp:ListItem Text="Automotive - Motor Vehicles - Parts" Value="Automotive - Motor Vehicles - Parts"></asp:ListItem>
                <asp:ListItem Text="Banking - Financial Services" Value="Banking - Financial Services"></asp:ListItem>
                <asp:ListItem Text="Biotechnology" Value="Biotechnology"></asp:ListItem>
                <asp:ListItem Text="Broadcasting - Radio - TV" Value="Broadcasting - Radio - TV"></asp:ListItem>
                <asp:ListItem Text="Building Materials" Value="Building Materials"></asp:ListItem>
                <asp:ListItem Text="Chemical" Value="Chemical"></asp:ListItem>
                <asp:ListItem Text="Construction" Value="Construction"></asp:ListItem>
                <asp:ListItem Text="Computer Hardware" Value="Computer Hardware"></asp:ListItem>
                <asp:ListItem Text="Computer Software" Value="Computer Software"></asp:ListItem>
                <asp:ListItem Text="Consulting" Value="Consulting"></asp:ListItem>
                <asp:ListItem Text="Consumer Products" Value="Consumer Products"></asp:ListItem>
                <asp:ListItem Text="Credit - Loan - Collections" Value="Credit - Loan - Collections"></asp:ListItem>
                <asp:ListItem Text="Defense - Aerospace" Value="Defense - Aerospace"></asp:ListItem>
                <asp:ListItem Text="Education - Teaching - Administration" Value="Education - Teaching - Administration"></asp:ListItem>
                <asp:ListItem Text="Electronics" Value="Electronics"></asp:ListItem>
                <asp:ListItem Text="Employment - Recruiting - Staffing" Value="Employment - Recruiting - Staffing"></asp:ListItem>
                <asp:ListItem Text="Energy - Utilities - Gas - Electric" Value="Energy - Utilities - Gas - Electric"></asp:ListItem>
                <asp:ListItem Text="Entertainment" Value="Entertainment"></asp:ListItem>
                <asp:ListItem Text="Environmental" Value="Environmental"></asp:ListItem>
                <asp:ListItem Text="Exercise - Fitness" Value="Exercise - Fitness"></asp:ListItem>
                <asp:ListItem Text="Fashion - Apparel - Textile" Value="Fashion - Apparel - Textile"></asp:ListItem>
                <asp:ListItem Text="Food" Value="Food"></asp:ListItem>
                <asp:ListItem Text="Funeral - Cemetery" Value="Funeral - Cemetery"></asp:ListItem>
                <asp:ListItem Text="Government - Civil Service" Value="Government - Civil Service"></asp:ListItem>
                <asp:ListItem Text="Healthcare - Health Services" Value="Healthcare - Health Services"></asp:ListItem>
                <asp:ListItem Text="Homebuilding" Value="Homebuilding"></asp:ListItem>
                <asp:ListItem Text="Hospitality" Value="Hospitality"></asp:ListItem>
                <asp:ListItem Text="Hotel - Resort" Value="Hotel - Resort"></asp:ListItem>
                <asp:ListItem Text="HVAC" Value="HVAC"></asp:ListItem>
                <asp:ListItem Text="Import - Export" Value="Import - Export"></asp:ListItem>
                <asp:ListItem Text="Industrial" Value="Industrial"></asp:ListItem>
                <asp:ListItem Text="Insurance" Value="Insurance"></asp:ListItem>
                <asp:ListItem Text="Internet - E-Commerce" Value="Internet - E-Commerce"></asp:ListItem>
                <asp:ListItem Text="Landscaping" Value="Landscaping"></asp:ListItem>
                <asp:ListItem Text="Law Enforcement" Value="Law Enforcement"></asp:ListItem>
                <asp:ListItem Text="Legal" Value="Legal"></asp:ListItem>
                <asp:ListItem Text="Library Science" Value="Library Science"></asp:ListItem>
                <asp:ListItem Text="Managed Care" Value="Managed Care"></asp:ListItem>
                <asp:ListItem Text="Manufacturing" Value="Manufacturing"></asp:ListItem>
                <asp:ListItem Text="Medical Equipment" Value="Medical Equipment"></asp:ListItem>
                <asp:ListItem Text="Merchandising" Value="Merchandising"></asp:ListItem>
                <asp:ListItem Text="Military" Value="Military"></asp:ListItem>
                <asp:ListItem Text="Mortgage" Value="Mortgage"></asp:ListItem>
                <asp:ListItem Text="Newspaper" Value="Newspaper"></asp:ListItem>
                <asp:ListItem Text="Not for Profit - Charitable" Value="Not for Profit - Charitable"></asp:ListItem>
                <asp:ListItem Text="Office Supplies - Equipment" Value="Office Supplies - Equipment"></asp:ListItem>
                <asp:ListItem Text="Oil Refining - Petroleum - Drilling" Value="Oil Refining - Petroleum - Drilling"></asp:ListItem>
                <asp:ListItem Text="Other Great Industries" Value="Other Great Industries"></asp:ListItem>
                <asp:ListItem Text="Packaging" Value="Packaging"></asp:ListItem>
                <asp:ListItem Text="Pharmaceutical" Value="Pharmaceutical"></asp:ListItem>
                <asp:ListItem Text="Printing - Publishing" Value="Printing - Publishing"></asp:ListItem>
                <asp:ListItem Text="Public Relations" Value="Public Relations"></asp:ListItem>
                <asp:ListItem Text="Radio" Value="Radio"></asp:ListItem>
                <asp:ListItem Text="Real Estate - Property Mgt" Value="Real Estate - Property Mgt"></asp:ListItem>
                <asp:ListItem Text="Restaurant" Value="Restaurant"></asp:ListItem>
                <asp:ListItem Text="Retail" Value="Retail"></asp:ListItem>
                <asp:ListItem Text="Recreation" Value="Recreation"></asp:ListItem>
                <asp:ListItem Text="Sales - Marketing" Value="Sales - Marketing"></asp:ListItem>
                <asp:ListItem Text="Security" Value="Security"></asp:ListItem>
                <asp:ListItem Text="Securities" Value="Securities"></asp:ListItem>
                <asp:ListItem Text="Semiconductor" Value="Semiconductor"></asp:ListItem>
                <asp:ListItem Text="Social Services" Value="Social Services"></asp:ListItem>
                <asp:ListItem Text="Telecommunications" Value="Telecommunications"></asp:ListItem>
                <asp:ListItem Text="Training" Value="Training"></asp:ListItem>
                <asp:ListItem Text="Transportation" Value="Transportation"></asp:ListItem>
                <asp:ListItem Text="Travel" Value="Travel"></asp:ListItem>
                <asp:ListItem Text="Wireless" Value="Wireless"></asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <asp:Button runat="server" ID="btnSelect" Text="Select" />
    </ContentTemplate>
</asp:UpdatePanel>
