#pragma checksum "D:\OL04\SmartShop\SmartShop.Web\Views\Home\_ProductPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7caf2d140f009f005e36af8e39cd287db3405326"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home__ProductPartial), @"mvc.1.0.view", @"/Views/Home/_ProductPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7caf2d140f009f005e36af8e39cd287db3405326", @"/Views/Home/_ProductPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb31386159708d264647a5b7b7d6dbdcc6786dc6", @"/Views/_ViewImports.cshtml")]
    public class Views_Home__ProductPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Product>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ProductDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\OL04\SmartShop\SmartShop.Web\Views\Home\_ProductPartial.cshtml"
 if (Model != null)
{


#line default
#line hidden
#nullable disable
            WriteLiteral("    <h5>");
#nullable restore
#line 6 "D:\OL04\SmartShop\SmartShop.Web\Views\Home\_ProductPartial.cshtml"
   Write(Model.FirstOrDefault()?.Subcategory.Category.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n");
#nullable restore
#line 8 "D:\OL04\SmartShop\SmartShop.Web\Views\Home\_ProductPartial.cshtml"
     foreach (var p in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""owl-carousel product-carousel  owl-theme owl-loaded mb-3 mt-2"">
            <div class=""owl-stage-outer"">
                <div class=""owl-stage product_img_item "">
                    <div class=""owl-item border bx"">

                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7caf2d140f009f005e36af8e39cd287db34053264657", async() => {
                WriteLiteral("<img");
                BeginWriteAttribute("src", " src=\"", 525, "\"", 594, 2);
                WriteAttributeValue("", 531, "http://localhost:5000/Images/", 531, 29, true);
#nullable restore
#line 15 "D:\OL04\SmartShop\SmartShop.Web\Views\Home\_ProductPartial.cshtml"
WriteAttributeValue("", 560, p.ProductImages.First().ImageName, 560, 34, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("alt", " alt=\"", 595, "\"", 601, 0);
                EndWriteAttribute();
                WriteLiteral(" class=\"image\">");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 15 "D:\OL04\SmartShop\SmartShop.Web\Views\Home\_ProductPartial.cshtml"
                                                                                  WriteLiteral(p.ProductId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        <div class=\"text-center p-2\">\r\n                            <h6>");
#nullable restore
#line 17 "D:\OL04\SmartShop\SmartShop.Web\Views\Home\_ProductPartial.cshtml"
                           Write(p.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n\r\n");
#nullable restore
#line 19 "D:\OL04\SmartShop\SmartShop.Web\Views\Home\_ProductPartial.cshtml"
                             if (p.ProductPrices.Count > 0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <p><strong>$");
#nullable restore
#line 21 "D:\OL04\SmartShop\SmartShop.Web\Views\Home\_ProductPartial.cshtml"
                                       Write(String.Format("{0:0.00}", p.ProductPrices.FirstOrDefault().Price));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </strong></p>\r\n");
#nullable restore
#line 22 "D:\OL04\SmartShop\SmartShop.Web\Views\Home\_ProductPartial.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n\r\n\r\n                    </div>\r\n\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 33 "D:\OL04\SmartShop\SmartShop.Web\Views\Home\_ProductPartial.cshtml"




    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "D:\OL04\SmartShop\SmartShop.Web\Views\Home\_ProductPartial.cshtml"
     
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591
