#pragma checksum "C:\Users\akaro\Documents\GitHub\ASP.NET Core Projects\Admin-Portal\Admin-Portal\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bf9679dece2ffc43f2441b834e5116d294c810d8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\akaro\Documents\GitHub\ASP.NET Core Projects\Admin-Portal\Admin-Portal\Views\_ViewImports.cshtml"
using Admin_Portal;

#line default
#line hidden
#line 2 "C:\Users\akaro\Documents\GitHub\ASP.NET Core Projects\Admin-Portal\Admin-Portal\Views\_ViewImports.cshtml"
using Admin_Portal.Models;

#line default
#line hidden
#line 1 "C:\Users\akaro\Documents\GitHub\ASP.NET Core Projects\Admin-Portal\Admin-Portal\Views\Home\Index.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bf9679dece2ffc43f2441b834e5116d294c810d8", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"610cd48b3df1daaa48727c710097917ab80ae016", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(39, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\akaro\Documents\GitHub\ASP.NET Core Projects\Admin-Portal\Admin-Portal\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(140, 81, true);
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Welcome</h1>\r\n\r\n</div>\r\n\r\n");
            EndContext();
#line 13 "C:\Users\akaro\Documents\GitHub\ASP.NET Core Projects\Admin-Portal\Admin-Portal\Views\Home\Index.cshtml"
 if (sigInManager.IsSignedIn(User) && User.IsInRole("Admin"))
{

#line default
#line hidden
            BeginContext(287, 778, true);
            WriteLiteral(@"    <table class=""table"">
        <thead>
            <tr>
                <th scope=""col"">#</th>
                <th scope=""col"">Role</th>
                <th scope=""col"">Links</th>

            </tr>
        </thead>
        <tbody>
            <tr>
                <th scope=""row"">1</th>
                <td>Admin</td>
                <td><a href=""#"">Manage User Accounts</a></td>

            </tr>
            <tr>
                <th scope=""row"">2</th>
                <td>Admin</td>
                <td><a href=""#"">Assign Roles</a></td>

            </tr>
            <tr>
                <th scope=""row"">3</th>
                <td>Admin</td>
                <td><a href=""#"">Help Desk</a></td>
            </tr>
        </tbody>
    </table>
");
            EndContext();
#line 44 "C:\Users\akaro\Documents\GitHub\ASP.NET Core Projects\Admin-Portal\Admin-Portal\Views\Home\Index.cshtml"
}
else if (sigInManager.IsSignedIn(User) && User.IsInRole("Finance_Admin"))
{

#line default
#line hidden
            BeginContext(1146, 975, true);
            WriteLiteral(@"    <table class=""table"">
        <thead>
            <tr>
                <th scope=""col"">#</th>
                <th scope=""col"">Role</th>
                <th scope=""col"">Links</th>

            </tr>
        </thead>
        <tbody>
            <tr>
                <th scope=""row"">1</th>
                <td>Finance Admin</td>
                <td><a href=""#"">Finance Reports</a></td>

            </tr>
            <tr>
                <th scope=""row"">2</th>
                <td>Finance Admin</td>
                <td><a href=""#"">Accounts Payable</a></td>

            </tr>
            <tr>
                <th scope=""row"">3</th>
                <td>Finance Admin</td>
                <td><a href=""#"">Accounts Receivables</a></td>
            </tr>
            <tr>
                <th scope=""row"">4</th>
                <td>Finance Admin</td>
                <td><a href=""#"">Tax</a></td>
            </tr>
        </tbody>
    </table>
");
            EndContext();
#line 81 "C:\Users\akaro\Documents\GitHub\ASP.NET Core Projects\Admin-Portal\Admin-Portal\Views\Home\Index.cshtml"
}

#line default
#line hidden
            BeginContext(2124, 2, true);
            WriteLiteral("\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<ApplicationUser> sigInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591