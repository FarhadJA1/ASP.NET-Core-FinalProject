#pragma checksum "C:\Users\ASUS\Desktop\ASP.NET Core Final Project\ASP.NET-Core-EndProject\ASP.NET-Core-EndProject\Views\Shared\_VideoPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b462eef0e9dc42ef0dff4637bfdfab2335858b54"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__VideoPartial), @"mvc.1.0.view", @"/Views/Shared/_VideoPartial.cshtml")]
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
#line 1 "C:\Users\ASUS\Desktop\ASP.NET Core Final Project\ASP.NET-Core-EndProject\ASP.NET-Core-EndProject\Views\_ViewImports.cshtml"
using ASP.NET_Core_EndProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ASUS\Desktop\ASP.NET Core Final Project\ASP.NET-Core-EndProject\ASP.NET-Core-EndProject\Views\_ViewImports.cshtml"
using ASP.NET_Core_EndProject.Utilities.Pagination;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ASUS\Desktop\ASP.NET Core Final Project\ASP.NET-Core-EndProject\ASP.NET-Core-EndProject\Views\_ViewImports.cshtml"
using ASP.NET_Core_EndProject.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ASUS\Desktop\ASP.NET Core Final Project\ASP.NET-Core-EndProject\ASP.NET-Core-EndProject\Views\_ViewImports.cshtml"
using ASP.NET_Core_EndProject.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b462eef0e9dc42ef0dff4637bfdfab2335858b54", @"/Views/Shared/_VideoPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7301741b40c7782f04eefdcde798cb9a54eb772b", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__VideoPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Video>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"col-md-6 col-sm-6 col-xs-12\">\r\n    <div class=\"notice-right-wrapper mb-25 pb-25\">\r\n        <h3>TAKE A VIDEO TOUR</h3>\r\n        <div class=\"notice-video\">\r\n            <div class=\"video-icon video-hover\">\r\n                <a class=\"video-popup\"");
            BeginWriteAttribute("href", " href=\"", 269, "\"", 287, 1);
#nullable restore
#line 7 "C:\Users\ASUS\Desktop\ASP.NET Core Final Project\ASP.NET-Core-EndProject\ASP.NET-Core-EndProject\Views\Shared\_VideoPartial.cshtml"
WriteAttributeValue("", 276, Model.Link, 276, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <i class=\"zmdi zmdi-play\"></i>\r\n                </a>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Video> Html { get; private set; }
    }
}
#pragma warning restore 1591
