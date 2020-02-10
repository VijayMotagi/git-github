<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="PetShopManagementSystem.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">  
    <title>Pet Shop Management : Register</title>  
    <style type="text/css">  
        .style1 {  
            width: 100%;  
        }  
    </style>  
</head>  
<body>  
    <form id="form1" runat="server">  
        <div>  
            <table class="style1">  
                <tr>  
                    <td>First Name:</td>  
                    <td>  
                        <asp:TextBox ID="TxtFName" runat="server"></asp:TextBox>  
                    </td>  
                </tr> 
                <tr>  
                    <td>Middle Name:</td>  
                    <td>  
                        <asp:TextBox ID="TxtMName" runat="server"></asp:TextBox>  
                    </td>  
                </tr> 
                <tr>  
                    <td>Last Name:</td>  
                    <td>  
                        <asp:TextBox ID="TxtLName" runat="server"></asp:TextBox>  
                    </td>  
                </tr> 
                <tr>  
                    <td>Email Id:</td>  
                    <td>  
                        <asp:TextBox ID="TxtEmailId" runat="server"></asp:TextBox>  
                    </td>  
                </tr>
                <tr>  
                    <td>Mobile No:</td>  
                    <td>  
                        <asp:TextBox ID="TxtMobileNo" runat="server" ></asp:TextBox>  
                    </td>  
                </tr>
                <tr>  
                    <td>Username:</td>  
                    <td>  
                        <asp:TextBox ID="TxtUserName" runat="server"></asp:TextBox>  
                    </td>  
                </tr>  
                <tr>  
                    <td>Password:</td>  
                    <td>  
                        <asp:TextBox ID="TxtPassword" runat="server"  
                                     TextMode="Password"></asp:TextBox>  
                    </td>  
                </tr>  
                <tr>  
                    <td>Confirm Password:</td>  
                    <td>  
                        <asp:TextBox ID="TxtConfirmPassword" runat="server"  
                                     TextMode="Password"></asp:TextBox>  
                    </td>  
                </tr>  
                <tr>  
                    <td>Address:</td>  
                    <td>  
                        <asp:TextBox ID="TxtAddress" runat="server"></asp:TextBox>  
                    </td>  
                </tr>  
                <tr>  
                    <td>Age:</td>  
                    <td>  
                        <asp:TextBox ID="TxtAge" runat="server"></asp:TextBox>  
                    </td>  
                </tr>  
                <tr>  
                    <td>Gender:</td>  
                    <td>  
                        <asp:DropDownList ID="DropDownList1" runat="server"  
                                          AppendDataBoundItems="true">  
                            <asp:ListItem Value="-1">Select</asp:ListItem>  
                            <asp:ListItem>Male</asp:ListItem>  
                            <asp:ListItem>Female</asp:ListItem>  
                        </asp:DropDownList>  
                    </td>  
                </tr>  
                <tr>  
                    <td>Country:</td>  
                    <td>  
                        <asp:DropDownList ID="DropDownList2" runat="server"  
                                          AppendDataBoundItems="true">  
                            <asp:ListItem Value="-1">Select</asp:ListItem>  
                            <asp:ListItem>India</asp:ListItem>  
                            <asp:ListItem>US</asp:ListItem>
                            <asp:ListItem>Australia</asp:ListItem>  
                        </asp:DropDownList>  
                    </td>  
                </tr> 
               
            </table>  
            
        </div>  
        <asp:Button ID="Button1" runat="server" Text="Register/Sign Up"  
                    onclick="Button1_Click" />  
         <div>
             <asp:Label ID="RegistartionLabel" runat="server" Font-Size="X-Large"></asp:Label>
             <asp:HyperLink ID="LoginLink" runat="server" BorderStyle="None" Font-Size="X-Large" Text="LOGIN" NavigateUrl="~/Default.aspx"></asp:HyperLink>
         </div>
        
    </form>  
</body>  
</html>  
