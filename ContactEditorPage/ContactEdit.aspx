<%@ Page Language="C#" %>
<%@ Import Namespace="Asi.Business.Common" %>
<%@ Import Namespace="Asi.iBO.ContactManagement" %>
<%@ Import Namespace="Asi.Security" %>
<%@ Import Namespace="Asi.Web" %>

<!DOCTYPE html>

<script runat="server">
    protected override void OnLoad(EventArgs e)
    {
        var iMISUser = CContactUser.LoginByWebLogin(AppPrincipal.CurrentIdentity.LoginName);
        var contact = new CContact(iMISUser, "194");
        contact.FirstName = "M1";
        contact.LastName = "M2";
            contact.BirthDate = DateTime.Today.AddYears(-11);
        if (contact.Validate())
            contact.Save();
        
        Response.Write("Saved");
    } 

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
    </div>
    </form>
</body>
</html>
