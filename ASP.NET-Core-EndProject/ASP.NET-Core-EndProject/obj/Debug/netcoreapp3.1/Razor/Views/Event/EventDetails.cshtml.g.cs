#pragma checksum "C:\Users\ASUS\Desktop\ASP.NET Core Final Project\ASP.NET-Core-EndProject\ASP.NET-Core-EndProject\Views\Event\EventDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7f28ef805e6e7d0f309c20e2486957e8dfb856ff"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Event_EventDetails), @"mvc.1.0.view", @"/Views/Event/EventDetails.cshtml")]
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
using ASP.NET_Core_EndProject.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ASUS\Desktop\ASP.NET Core Final Project\ASP.NET-Core-EndProject\ASP.NET-Core-EndProject\Views\_ViewImports.cshtml"
using ASP.NET_Core_EndProject.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7f28ef805e6e7d0f309c20e2486957e8dfb856ff", @"/Views/Event/EventDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f078ff3a0f7fd7618b89c0b887d885109365ab35", @"/Views/_ViewImports.cshtml")]
    public class Views_Event_EventDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EventDetailsVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:400px;height:300px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("event-details"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:120px;height:120px;border-radius:50%"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("speaker"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("contact-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("http://demo.devitems.com/eduhome/mail.php"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("search"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("#"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\ASUS\Desktop\ASP.NET Core Final Project\ASP.NET-Core-EndProject\ASP.NET-Core-EndProject\Views\Event\EventDetails.cshtml"
  
    ViewData["Title"] = "EventDetails";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""banner-area-wrapper"">
    <div class=""banner-area text-center"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-xs-12"">
                    <div class=""banner-content-wrapper"">
                        <div class=""banner-content"">
                            <h2>event / details</h2>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- Banner Area End -->
<!-- Event Details Start -->
<div class=""event-details-area blog-area pt-150 pb-140"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-8"">
                <div class=""event-details"">
                    <div class=""event-details-img"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "7f28ef805e6e7d0f309c20e2486957e8dfb856ff8066", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 900, "~/assets/img/event/", 900, 19, true);
#nullable restore
#line 29 "C:\Users\ASUS\Desktop\ASP.NET Core Final Project\ASP.NET-Core-EndProject\ASP.NET-Core-EndProject\Views\Event\EventDetails.cshtml"
AddHtmlAttributeValue("", 919, Model.Event.Image, 919, 18, false);

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
            WriteLiteral("\r\n                        <div class=\"event-date\">\r\n                            <h3>");
#nullable restore
#line 31 "C:\Users\ASUS\Desktop\ASP.NET Core Final Project\ASP.NET-Core-EndProject\ASP.NET-Core-EndProject\Views\Event\EventDetails.cshtml"
                           Write(Model.Event.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"event-details-content\">\r\n                        <h2>");
#nullable restore
#line 35 "C:\Users\ASUS\Desktop\ASP.NET Core Final Project\ASP.NET-Core-EndProject\ASP.NET-Core-EndProject\Views\Event\EventDetails.cshtml"
                       Write(Model.Event.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                        <ul>\r\n                            <li><span>time : </span>");
#nullable restore
#line 37 "C:\Users\ASUS\Desktop\ASP.NET Core Final Project\ASP.NET-Core-EndProject\ASP.NET-Core-EndProject\Views\Event\EventDetails.cshtml"
                                               Write(Model.Event.Time);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                            <li><span>venue : </span>");
#nullable restore
#line 38 "C:\Users\ASUS\Desktop\ASP.NET Core Final Project\ASP.NET-Core-EndProject\ASP.NET-Core-EndProject\Views\Event\EventDetails.cshtml"
                                                Write(Model.Event.Location);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                        </ul>\r\n                        <p>");
#nullable restore
#line 40 "C:\Users\ASUS\Desktop\ASP.NET Core Final Project\ASP.NET-Core-EndProject\ASP.NET-Core-EndProject\Views\Event\EventDetails.cshtml"
                      Write(Model.Event.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        \r\n                        <div class=\"speakers-area fix\">\r\n                            <h4>speakers</h4>\r\n");
#nullable restore
#line 44 "C:\Users\ASUS\Desktop\ASP.NET Core Final Project\ASP.NET-Core-EndProject\ASP.NET-Core-EndProject\Views\Event\EventDetails.cshtml"
                             foreach (var eventSpeaker in Model.Event.EventSpeakers)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"single-speaker\">\r\n                                    <div class=\"speaker-img\">\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "7f28ef805e6e7d0f309c20e2486957e8dfb856ff12438", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2018, "~/assets/img/teacher/", 2018, 21, true);
#nullable restore
#line 48 "C:\Users\ASUS\Desktop\ASP.NET Core Final Project\ASP.NET-Core-EndProject\ASP.NET-Core-EndProject\Views\Event\EventDetails.cshtml"
AddHtmlAttributeValue("", 2039, eventSpeaker.Teacher.Image, 2039, 27, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    </div>\r\n                                    <div class=\"speaker-name\">\r\n                                        <h5>");
#nullable restore
#line 51 "C:\Users\ASUS\Desktop\ASP.NET Core Final Project\ASP.NET-Core-EndProject\ASP.NET-Core-EndProject\Views\Event\EventDetails.cshtml"
                                       Write(eventSpeaker.Teacher.Fullname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                        <p>");
#nullable restore
#line 52 "C:\Users\ASUS\Desktop\ASP.NET Core Final Project\ASP.NET-Core-EndProject\ASP.NET-Core-EndProject\Views\Event\EventDetails.cshtml"
                                      Write(eventSpeaker.Teacher.Profession);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n                                    </div>\r\n                                </div>\r\n");
#nullable restore
#line 55 "C:\Users\ASUS\Desktop\ASP.NET Core Final Project\ASP.NET-Core-EndProject\ASP.NET-Core-EndProject\Views\Event\EventDetails.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                        </div>
                    </div>
                    <div class=""reply-area"">
                        <h3>LEAVE A REPLY</h3>
                        <p>I must explain to you how all this a mistaken idea of ncing great explorer of the rut<br> the is lder of human happinescias unde omnis iste natus error sit volptatem </p>
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7f28ef805e6e7d0f309c20e2486957e8dfb856ff15765", async() => {
                WriteLiteral(@"
                            <div class=""row"">
                                <div class=""col-md-12"">
                                    <p>Name</p>
                                    <input type=""text"" name=""name"" id=""name"">
                                </div>
                                <div class=""col-md-12"">
                                    <p>Email</p>
                                    <input type=""text"" name=""email"" id=""email"">
                                </div>
                                <div class=""col-md-12"">
                                    <p>Subject</p>
                                    <input type=""text"" name=""subject"" id=""subject"">
                                    <p>Massage</p>
                                    <textarea name=""message"" id=""message"" cols=""15"" rows=""10""></textarea>
                                </div>
                            </div>
                            <a class=""reply-btn"" href=""#"" data-text=""send""><span>send message");
                WriteLiteral("</span></a>\r\n                            <p class=\"form-messege\"></p>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    </div>
                </div>
            </div>
            <div class=""col-md-4"">
                <div class=""blog-sidebar right"">
                    <div class=""single-blog-widget mb-50"">
                        <h3>search</h3>
                        <div class=""blog-search"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7f28ef805e6e7d0f309c20e2486957e8dfb856ff18905", async() => {
                WriteLiteral(@"
                                <input type=""search"" placeholder=""Search..."" name=""search"" />
                                <button type=""submit"">
                                    <span><i class=""fa fa-search""></i></span>
                                </button>
                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                    ");
#nullable restore
#line 99 "C:\Users\ASUS\Desktop\ASP.NET Core Final Project\ASP.NET-Core-EndProject\ASP.NET-Core-EndProject\Views\Event\EventDetails.cshtml"
               Write(await Component.InvokeAsync("Sidebar"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EventDetailsVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
