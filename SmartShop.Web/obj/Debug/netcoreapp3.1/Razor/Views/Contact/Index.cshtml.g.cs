#pragma checksum "D:\OL04\SmartShop\SmartShop.Web\Views\Contact\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8095efd93cde2a687c809d6a0970c445eee35dd1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Contact_Index), @"mvc.1.0.view", @"/Views/Contact/Index.cshtml")]
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
#line 2 "D:\OL04\SmartShop\SmartShop.Web\Views\_ViewImports.cshtml"
using SmartShop.DataLib.Models.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\OL04\SmartShop\SmartShop.Web\Views\_ViewImports.cshtml"
using SmartShop.Web.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8095efd93cde2a687c809d6a0970c445eee35dd1", @"/Views/Contact/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb31386159708d264647a5b7b7d6dbdcc6786dc6", @"/Views/_ViewImports.cshtml")]
    public class Views_Contact_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/action_page.php"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\OL04\SmartShop\SmartShop.Web\Views\Contact\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container"">
    <section class=""contact-section mt-5"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-8 mx-auto"">
                    <div class=""d-flex justify-content-center  p-3 bg-white"" style=""box-shadow: 0 1rem 3rem rgba(0,0,0,.175)!important;"">
                        <div class=""p-2 w-50"">
                            <div class=""contact-form "">
                                <div class=""contact-form-container"">
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8095efd93cde2a687c809d6a0970c445eee35dd14352", async() => {
                WriteLiteral(@"
                                        <div class=""form-group"">
                                            <input type=""email"" class=""rounded-0 form-control"" placeholder=""Enter email"" id=""email"" required>
                                        </div>
                                        <div class=""form-group"">
                                            <input type=""text"" class=""rounded-0 form-control"" placeholder=""Enter subject"" id=""email"" required>
                                        </div>
                                        <div class=""form-group"">
                                            <textarea class=""rounded-0 form-control"" rows=""4"" placeholder=""Your Message""></textarea>
                                        </div>
                                       
                                        <button type=""submit"" class=""rounded-0 btn btn-dark btn-sm btn-block  text-white  d-block""");
                BeginWriteAttribute("id", " id=\"", 1591, "\"", 1596, 0);
                EndWriteAttribute();
                WriteLiteral("><i class=\"fa fa-paper-plane\"></i></button>\r\n                               ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
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
                        <div class=""p-2  w-50"">
                            <ul class=""contact-list"">
                                <li class=""list-item""><i class=""fa fa-map-marker fa-2x""><span class=""contact-text place"">City, State</span></i></li>
                                <li class=""list-item""><i class=""fa fa-phone fa-2x""><span class=""contact-text phone"">(212) 555-2368</span></i></li>
                                <li class=""list-item""><i class=""fa fa-envelope fa-2x""><span class=""contact-text gmail"">example@gmail.com</span></i></li>
                            </ul>
                            <hr>
                            <ul class=""social-media-list"">
                                <li>
                                    <a href=""#"" target=""_blank"" class=""contact-icon"">
                                        <i class=""fa fa-github"" aria-hidden=""true""></i>
       ");
            WriteLiteral(@"                             </a>
                                </li>
                                <li>
                                    <a href=""#"" target=""_blank"" class=""contact-icon"">
                                        <i class=""fa fa-codepen"" aria-hidden=""true""></i>
                                    </a>
                                </li>
                                <li>
                                    <a href=""#"" target=""_blank"" class=""contact-icon"">
                                        <i class=""fa fa-twitter"" aria-hidden=""true""></i>
                                    </a>
                                </li>
                                <li>
                                    <a href=""#"" target=""_blank"" class=""contact-icon"">
                                        <i class=""fa fa-instagram"" aria-hidden=""true""></i>
                                    </a>
                                </li>
                            </ul>
                        <");
            WriteLiteral("/div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </section>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
