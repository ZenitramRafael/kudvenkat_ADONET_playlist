#pragma checksum "C:\Users\zenit\OneDrive\Documents\GitHub\kudvenkat_ADONET_playlist\kudvenkat_ADONET_playlist_p15u_WebApp\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "65bc3dd59f4f6c33e7bd540fb1df31c7e4ca644a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#nullable restore
#line 1 "C:\Users\zenit\OneDrive\Documents\GitHub\kudvenkat_ADONET_playlist\kudvenkat_ADONET_playlist_p15u_WebApp\Views\_ViewImports.cshtml"
using kudvenkat_ADONET_playlist_p15u_WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\zenit\OneDrive\Documents\GitHub\kudvenkat_ADONET_playlist\kudvenkat_ADONET_playlist_p15u_WebApp\Views\_ViewImports.cshtml"
using kudvenkat_ADONET_playlist_p15u_WebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"65bc3dd59f4f6c33e7bd540fb1df31c7e4ca644a", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bdec13e7102a29938e89d3e4e88e413c48eac040", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Student>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\zenit\OneDrive\Documents\GitHub\kudvenkat_ADONET_playlist\kudvenkat_ADONET_playlist_p15u_WebApp\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<table class=\"table table-sm-striped table-bordered\">\r\n    <thead>\r\n        <tr>\r\n            <th>studentID</th>\r\n            <th>name</th>\r\n            <th>gender</th>\r\n            <th>salary</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 16 "C:\Users\zenit\OneDrive\Documents\GitHub\kudvenkat_ADONET_playlist\kudvenkat_ADONET_playlist_p15u_WebApp\Views\Home\Index.cshtml"
         foreach(var student in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 19 "C:\Users\zenit\OneDrive\Documents\GitHub\kudvenkat_ADONET_playlist\kudvenkat_ADONET_playlist_p15u_WebApp\Views\Home\Index.cshtml"
                   Write(student.studentID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 20 "C:\Users\zenit\OneDrive\Documents\GitHub\kudvenkat_ADONET_playlist\kudvenkat_ADONET_playlist_p15u_WebApp\Views\Home\Index.cshtml"
                   Write(student.name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 21 "C:\Users\zenit\OneDrive\Documents\GitHub\kudvenkat_ADONET_playlist\kudvenkat_ADONET_playlist_p15u_WebApp\Views\Home\Index.cshtml"
                   Write(student.gender);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 22 "C:\Users\zenit\OneDrive\Documents\GitHub\kudvenkat_ADONET_playlist\kudvenkat_ADONET_playlist_p15u_WebApp\Views\Home\Index.cshtml"
                   Write(student.totalMarks);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 24 "C:\Users\zenit\OneDrive\Documents\GitHub\kudvenkat_ADONET_playlist\kudvenkat_ADONET_playlist_p15u_WebApp\Views\Home\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Student>> Html { get; private set; }
    }
}
#pragma warning restore 1591
