#pragma checksum "C:\Users\ASUS\Desktop\ASP.NET Core Final Project\ASP.NET-Core-EndProject\ASP.NET-Core-EndProject\Areas\AdminArea\Views\Blog\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ee08d5bcd4733f62e2bac788710ea2f54686e6c2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_AdminArea_Views_Blog_Detail), @"mvc.1.0.view", @"/Areas/AdminArea/Views/Blog/Detail.cshtml")]
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
#line 1 "C:\Users\ASUS\Desktop\ASP.NET Core Final Project\ASP.NET-Core-EndProject\ASP.NET-Core-EndProject\Areas\AdminArea\Views\_ViewImports.cshtml"
using ASP.NET_Core_EndProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ASUS\Desktop\ASP.NET Core Final Project\ASP.NET-Core-EndProject\ASP.NET-Core-EndProject\Areas\AdminArea\Views\_ViewImports.cshtml"
using ASP.NET_Core_EndProject.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ASUS\Desktop\ASP.NET Core Final Project\ASP.NET-Core-EndProject\ASP.NET-Core-EndProject\Areas\AdminArea\Views\_ViewImports.cshtml"
using ASP.NET_Core_EndProject.ViewModels.Admin;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ee08d5bcd4733f62e2bac788710ea2f54686e6c2", @"/Areas/AdminArea/Views/Blog/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"65b2814a59586b2bb352b3aa1da7aec3a96dae8a", @"/Areas/AdminArea/Views/_ViewImports.cshtml")]
    public class Areas_AdminArea_Views_Blog_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Blog>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Alternate Text"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:350px;height:350px;border-radius:50%"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-warning mt-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\ASUS\Desktop\ASP.NET Core Final Project\ASP.NET-Core-EndProject\ASP.NET-Core-EndProject\Areas\AdminArea\Views\Blog\Detail.cshtml"
  
    ViewData["Title"] = "Detail";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n    <h1 class=\"text-warning\">Blog detail</h1>\r\n    <hr />\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ee08d5bcd4733f62e2bac788710ea2f54686e6c25529", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 155, "~/assets/img/blog/", 155, 18, true);
#nullable restore
#line 9 "C:\Users\ASUS\Desktop\ASP.NET Core Final Project\ASP.NET-Core-EndProject\ASP.NET-Core-EndProject\Areas\AdminArea\Views\Blog\Detail.cshtml"
AddHtmlAttributeValue("", 173, Model.Image, 173, 12, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    <hr />\r\n    <h3 class=\"text-info mt-3\" style=\"font-weight:bolder;font-family:sans-serif\">Title: <span style=\"color:grey;font-size:20px;font-weight:lighter\">");
#nullable restore
#line 11 "C:\Users\ASUS\Desktop\ASP.NET Core Final Project\ASP.NET-Core-EndProject\ASP.NET-Core-EndProject\Areas\AdminArea\Views\Blog\Detail.cshtml"
                                                                                                                                               Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> </h3>\r\n    <h3 class=\"text-info mt-3\" style=\"font-weight: bolder; font-family: sans-serif\">Description: <span style=\"color: grey; font-size: 20px; font-weight: lighter\">");
#nullable restore
#line 12 "C:\Users\ASUS\Desktop\ASP.NET Core Final Project\ASP.NET-Core-EndProject\ASP.NET-Core-EndProject\Areas\AdminArea\Views\Blog\Detail.cshtml"
                                                                                                                                                             Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> </h3>\r\n    <h3 class=\"text-info mt-3\" style=\"font-weight:bolder;font-family:sans-serif\">Date: <span style=\"color:grey;font-size:20px;font-weight:lighter\">");
#nullable restore
#line 13 "C:\Users\ASUS\Desktop\ASP.NET Core Final Project\ASP.NET-Core-EndProject\ASP.NET-Core-EndProject\Areas\AdminArea\Views\Blog\Detail.cshtml"
                                                                                                                                              Write(Model.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> </h3>\r\n\r\n    <h3 class=\"text-info mt-3\" style=\"font-weight:bolder;font-family:sans-serif\">From: <span style=\"color:grey;font-size:20px;font-weight:lighter\">");
#nullable restore
#line 15 "C:\Users\ASUS\Desktop\ASP.NET Core Final Project\ASP.NET-Core-EndProject\ASP.NET-Core-EndProject\Areas\AdminArea\Views\Blog\Detail.cshtml"
                                                                                                                                              Write(Model.From);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> </h3>\r\n    <h3 class=\"text-info mt-3\" style=\"font-weight:bolder;font-family:sans-serif\">Comments: <span style=\"color:grey;font-size:20px;font-weight:lighter\">");
#nullable restore
#line 16 "C:\Users\ASUS\Desktop\ASP.NET Core Final Project\ASP.NET-Core-EndProject\ASP.NET-Core-EndProject\Areas\AdminArea\Views\Blog\Detail.cshtml"
                                                                                                                                                  Write(Model.CommentCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> </h3>\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ee08d5bcd4733f62e2bac788710ea2f54686e6c210230", async() => {
                WriteLiteral("Go back");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Blog> Html { get; private set; }
    }
}
#pragma warning restore 1591
