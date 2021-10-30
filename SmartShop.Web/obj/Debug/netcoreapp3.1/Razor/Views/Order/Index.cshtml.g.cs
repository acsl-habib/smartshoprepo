#pragma checksum "D:\ISDB\FinalProject\SmartShop\SmartShop.Web\Views\Order\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b35cb90edfbc3a89bc68117ca4958fd72a7944de"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_Index), @"mvc.1.0.view", @"/Views/Order/Index.cshtml")]
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
#line 2 "D:\ISDB\FinalProject\SmartShop\SmartShop.Web\Views\_ViewImports.cshtml"
using SmartShop.DataLib.Models.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\ISDB\FinalProject\SmartShop\SmartShop.Web\Views\_ViewImports.cshtml"
using SmartShop.Web.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b35cb90edfbc3a89bc68117ca4958fd72a7944de", @"/Views/Order/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb31386159708d264647a5b7b7d6dbdcc6786dc6", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OrderVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "OrderDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Order", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info btn-sm  rounded-0 text-white float-right d-lg-none d-md-none d-xl-none"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info rounded-0 btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Review", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 2 "D:\ISDB\FinalProject\SmartShop\SmartShop.Web\Views\Order\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n    <div class=\"tab-pane mt-5\" id=\"order-list\">\r\n  \r\n        <div class=\"row\">\r\n            <div class=\"col-lg-8 mx-auto ck-cart-info \">\r\n                <h5 class=\"mb-3\">YOUR PLACED ORDERS</h5>\r\n");
#nullable restore
#line 13 "D:\ISDB\FinalProject\SmartShop\SmartShop.Web\Views\Order\Index.cshtml"
                 if (Model.Orders.Count > 0)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "D:\ISDB\FinalProject\SmartShop\SmartShop.Web\Views\Order\Index.cshtml"
                     foreach (var o in Model.Orders)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <div class=""card shadow-lg mt-2"">
                            <div class=""card-body"">

                                <div class=""row d-flex align-items-center"">


                                    <div class=""col-lg-4 col-6"">
                                        <p>Order ID : <strong>#0000 ");
#nullable restore
#line 24 "D:\ISDB\FinalProject\SmartShop\SmartShop.Web\Views\Order\Index.cshtml"
                                                               Write(o.OrderId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></p>\r\n\r\n                                        <p>Total Amount : <strong>$     ");
#nullable restore
#line 26 "D:\ISDB\FinalProject\SmartShop\SmartShop.Web\Views\Order\Index.cshtml"
                                                                   Write(String.Format("{0:0.00}", Model.Total));

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></p>\r\n                                        <p>\r\n                                            <small> ");
#nullable restore
#line 28 "D:\ISDB\FinalProject\SmartShop\SmartShop.Web\Views\Order\Index.cshtml"
                                               Write(o.OrderDate);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</small>
                                        </p>
                                    </div>

                                    <div class=""col-lg-4 col-4"">
                                        <p class=""text-center"">
                                            <span class=""badge badge-warning"">
                                               
                                                    <span class=""badge badge-sccess"">Unpaid</span>
                                            
                                                    <span class=""badge badge-danger"">Unpaid</span>
                                                
                                            </span>

                                        </p>
                                        <p class=""text-center""><small>Expected delivery by: To be Determined</small></p>
                                    </div>
                                    <div class=""col-lg-4 col-2"">
                                 ");
            WriteLiteral("       ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b35cb90edfbc3a89bc68117ca4958fd72a7944de8784", async() => {
                WriteLiteral("<i class=\"fa fa-eye\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                                        <a class=\"btn btn-info btn-sm  rounded-0 text-white float-right d-none d-sm-block\" data-toggle=\"modal\" data-target=\"#productView-");
#nullable restore
#line 48 "D:\ISDB\FinalProject\SmartShop\SmartShop.Web\Views\Order\Index.cshtml"
                                                                                                                                                                    Write(o.OrderId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"><i class=\"fa fa-eye\"></i>View</a>\r\n                                    </div>\r\n                                </div>\r\n\r\n\r\n                            </div>\r\n                        </div>\r\n");
            WriteLiteral("                        <div class=\"modal fade modal-center\"");
            BeginWriteAttribute("id", " id=\"", 2710, "\"", 2737, 2);
            WriteAttributeValue("", 2715, "productView-", 2715, 12, true);
#nullable restore
#line 60 "D:\ISDB\FinalProject\SmartShop\SmartShop.Web\Views\Order\Index.cshtml"
WriteAttributeValue("", 2727, o.OrderId, 2727, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                            <div class=""modal-dialog modal-lg"">
                                <div class=""modal-content"">
                                    <!-- Modal Header -->
                                    <div class=""modal-header border-0 ck-cart-info"">
                                        <h5>Product Description</h5>
                                        <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
                                    </div>
                                    <!-- Modal body -->
                                    <div class=""modal-body"">
                                        <div class=""row"">
                                            <div class=""col-lg-12"">
                                                <div class=""card"">
                                                    <div class=""card-body p-0 table-responsive"">
                                                        <table class=""table table-bordered"">
              ");
            WriteLiteral(@"                                              <thead>
                                                                <tr>

                                                                    <th scope=""col"">Product Name</th>
                                                                    <th scope=""col"">Price</th>

                                                                    <th scope=""col"" width=""14%"">Qty</th>
                                                                    <th scope=""col"">Sub Total</th>

                                                                </tr>
                                                            </thead>
                                                            <tbody>
");
#nullable restore
#line 87 "D:\ISDB\FinalProject\SmartShop\SmartShop.Web\Views\Order\Index.cshtml"
                                                                  
                                                                    decimal total = 0;
                                                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 90 "D:\ISDB\FinalProject\SmartShop\SmartShop.Web\Views\Order\Index.cshtml"
                                                                 foreach (var c in o.OrderDetails)
                                                                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                <tr>\r\n                                                                    <td>");
#nullable restore
#line 94 "D:\ISDB\FinalProject\SmartShop\SmartShop.Web\Views\Order\Index.cshtml"
                                                                   Write(c.Product.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                                                                    <td>  ");
#nullable restore
#line 96 "D:\ISDB\FinalProject\SmartShop\SmartShop.Web\Views\Order\Index.cshtml"
                                                                     Write(String.Format("{0:0.00}", c.ProductPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                                                    <td>");
#nullable restore
#line 97 "D:\ISDB\FinalProject\SmartShop\SmartShop.Web\Views\Order\Index.cshtml"
                                                                   Write(c.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                                    <td>\r\n");
#nullable restore
#line 99 "D:\ISDB\FinalProject\SmartShop\SmartShop.Web\Views\Order\Index.cshtml"
                                                                          
                                                                            var subtotal = c.ProductPrice * c.Quantity;
                                                                            total = total + subtotal;
                                                                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                   \r\n                                                                        ");
#nullable restore
#line 104 "D:\ISDB\FinalProject\SmartShop\SmartShop.Web\Views\Order\Index.cshtml"
                                                                   Write(String.Format("{0:0.00}", subtotal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                                                    </td>\r\n                                                              \r\n                                                                        <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b35cb90edfbc3a89bc68117ca4958fd72a7944de16549", async() => {
                WriteLiteral("Add Review");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 108 "D:\ISDB\FinalProject\SmartShop\SmartShop.Web\Views\Order\Index.cshtml"
                                                                                                                                                                  WriteLiteral(c.ProductId);

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
            WriteLiteral("</td>\r\n                                                             \r\n                                                                        <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b35cb90edfbc3a89bc68117ca4958fd72a7944de19256", async() => {
                WriteLiteral("Update Review");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 110 "D:\ISDB\FinalProject\SmartShop\SmartShop.Web\Views\Order\Index.cshtml"
                                                                                                                                                                 WriteLiteral(c.ProductId);

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
            WriteLiteral("</td>\r\n                                                                    \r\n                                                                </tr>\r\n");
#nullable restore
#line 113 "D:\ISDB\FinalProject\SmartShop\SmartShop.Web\Views\Order\Index.cshtml"

                                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                                                <tr>
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td>Total</td>
                                                                    <td>
                                                                        <p>
                                                                            <strong>
                                                                             
                                                                                String.Format(""{0:0.00}"", Model.Total)
                                                                            </strong>
                                                                        </p>
                                                                    </td>
                                  ");
            WriteLiteral(@"                              </tr>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                                <div class=""card mt-4"">
                                                    <div class=""card-body"">
                                                        <h4>Timeline</h4>
                                                        <ul class=""timeline"">
                                                            <li class=""active"">
                                                                <h6>PICKED</h6>
                                                                <p class=""mb-0 text-muted"">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque Lorem ipsum dolor</p>
                                                                <o class=""text-muted"">
  ");
            WriteLiteral(@"                                                                  21 March, 2014
                                                                </o>
                                                            </li>
                                                            <li>
                                                                <h6>PICKED</h6>
                                                                <p class=""mb-0 text-muted"">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque</p>
                                                                <o class=""text-muted"">
                                                                    21 March, 2014
                                                                </o>
                                                            </li>
                                                            <li>
                                                                <h6>PICKED</h6>
                                         ");
            WriteLiteral(@"                       <p class=""mb-0 text-muted"">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque</p>
                                                                <o class=""text-muted"">
                                                                    21 March, 2014
                                                                </o>
                                                            </li>
                                                            <li>
                                                                <h6>PICKED</h6>
                                                                <p class=""mb-0 text-muted"">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque</p>
                                                                <o class=""text-muted"">
                                                                    21 March, 2014
                                                                </o>
                                             ");
            WriteLiteral(@"               </li>
                                                            <li>
                                                                <h6>PICKED</h6>
                                                                <p class=""mb-0 text-muted"">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque</p>
                                                                <o class=""text-muted"">
                                                                    21 March, 2014
                                                                </o>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                      ");
            WriteLiteral("      </div>\r\n                        </div>\r\n");
#nullable restore
#line 181 "D:\ISDB\FinalProject\SmartShop\SmartShop.Web\Views\Order\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 181 "D:\ISDB\FinalProject\SmartShop\SmartShop.Web\Views\Order\Index.cshtml"
                     
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <h4 class=\"text-info text-center\">You hav no order </h4>\r\n");
#nullable restore
#line 186 "D:\ISDB\FinalProject\SmartShop\SmartShop.Web\Views\Order\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n      \r\n\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OrderVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
