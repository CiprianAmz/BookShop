#pragma checksum "C:\Users\Cipri\OneDrive\Documents\GitHub\BookShop\BookShop\Views\Admin\OutOfStock.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "621d4d2845f70d2b3bf8ca276b61b37fe8c96dfe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_OutOfStock), @"mvc.1.0.view", @"/Views/Admin/OutOfStock.cshtml")]
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
#line 1 "C:\Users\Cipri\OneDrive\Documents\GitHub\BookShop\BookShop\Views\_ViewImports.cshtml"
using BookShop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Cipri\OneDrive\Documents\GitHub\BookShop\BookShop\Views\_ViewImports.cshtml"
using BookShop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"621d4d2845f70d2b3bf8ca276b61b37fe8c96dfe", @"/Views/Admin/OutOfStock.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ee4735df80bb67d1ce7d40fc94d37240032cc50", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_OutOfStock : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BookShop.Models.Admins.AdminBooksViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/site.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteBook", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditBook", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\Cipri\OneDrive\Documents\GitHub\BookShop\BookShop\Views\Admin\OutOfStock.cshtml"
  
    ViewData["Title"] = "Out of stock Books";

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "621d4d2845f70d2b3bf8ca276b61b37fe8c96dfe5482", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    <div class=\"row\" style=\"align-content\">\r\n");
#nullable restore
#line 7 "C:\Users\Cipri\OneDrive\Documents\GitHub\BookShop\BookShop\Views\Admin\OutOfStock.cshtml"
         foreach (var Book in Model.Books)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <!--\r\n        <div class=\"col-md-3 product-men\">\r\n            <div class=\"product-chr-info chr\">\r\n                <div class=\"img-thumbnail\" >\r\n                    <a>\r\n                        <img src=\"data:image/png;base64, ");
#nullable restore
#line 14 "C:\Users\Cipri\OneDrive\Documents\GitHub\BookShop\BookShop\Views\Admin\OutOfStock.cshtml"
                                                    Write(Book.ImageFile);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" width=\"300\" height=\"500\" alt=\"\" />\r\n                    </a>\r\n                </div>\r\n                <div class=\"caption\">\r\n                    <p>Name: ");
#nullable restore
#line 18 "C:\Users\Cipri\OneDrive\Documents\GitHub\BookShop\BookShop\Views\Admin\OutOfStock.cshtml"
                        Write(Book.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n                    <p>Id: ");
#nullable restore
#line 19 "C:\Users\Cipri\OneDrive\Documents\GitHub\BookShop\BookShop\Views\Admin\OutOfStock.cshtml"
                      Write(Book.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n                    <p>Price: ");
#nullable restore
#line 20 "C:\Users\Cipri\OneDrive\Documents\GitHub\BookShop\BookShop\Views\Admin\OutOfStock.cshtml"
                         Write(Book.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" $</p>\r\n                </div>\r\n                <a asp-controller=\"Admin\" asp-action=\"DeleteBook\" asp-route-id=\"");
#nullable restore
#line 22 "C:\Users\Cipri\OneDrive\Documents\GitHub\BookShop\BookShop\Views\Admin\OutOfStock.cshtml"
                                                                           Write(Book.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">Delete Book</a>\r\n                <a asp-controller=\"Admin\" asp-action=\"EditBook\" asp-route-id=\"");
#nullable restore
#line 23 "C:\Users\Cipri\OneDrive\Documents\GitHub\BookShop\BookShop\Views\Admin\OutOfStock.cshtml"
                                                                         Write(Book.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">Edit Book</a>\r\n            </div>\r\n        </div>\r\n\r\n        -->\r\n");
#nullable restore
#line 28 "C:\Users\Cipri\OneDrive\Documents\GitHub\BookShop\BookShop\Views\Admin\OutOfStock.cshtml"
             if ((Book.Id != Guid.Empty) && (Book.Stock == 0) )
            {


#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-xl-4 col-lg-4 col-md-6\" style=\"border-style: groove\">\r\n                    <div class=\"single-product mb-60\">\r\n                        <div class=\"product-img\">\r\n                            <img");
            BeginWriteAttribute("src", " src=\"", 1369, "\"", 1413, 2);
            WriteAttributeValue("", 1375, "data:image/png;base64,", 1375, 22, true);
#nullable restore
#line 34 "C:\Users\Cipri\OneDrive\Documents\GitHub\BookShop\BookShop\Views\Admin\OutOfStock.cshtml"
WriteAttributeValue(" ", 1397, Book.ImageFile, 1398, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"350\" height=\"500\"");
            BeginWriteAttribute("alt", " alt=\"", 1439, "\"", 1445, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n                        </div>\r\n                        <div class=\"product-caption\">\r\n                            <h4 align=\"center\">");
#nullable restore
#line 37 "C:\Users\Cipri\OneDrive\Documents\GitHub\BookShop\BookShop\Views\Admin\OutOfStock.cshtml"
                                          Write(Book.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                            <h4 align=\"center\">");
#nullable restore
#line 38 "C:\Users\Cipri\OneDrive\Documents\GitHub\BookShop\BookShop\Views\Admin\OutOfStock.cshtml"
                                          Write(Book.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h4>\r\n                        </div>\r\n                        <div align=\"center\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "621d4d2845f70d2b3bf8ca276b61b37fe8c96dfe11305", async() => {
                WriteLiteral("Delete Book");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 41 "C:\Users\Cipri\OneDrive\Documents\GitHub\BookShop\BookShop\Views\Admin\OutOfStock.cshtml"
                                                                                                       WriteLiteral(Book.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "621d4d2845f70d2b3bf8ca276b61b37fe8c96dfe13850", async() => {
                WriteLiteral("Edit Book");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 42 "C:\Users\Cipri\OneDrive\Documents\GitHub\BookShop\BookShop\Views\Admin\OutOfStock.cshtml"
                                                                                                     WriteLiteral(Book.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 46 "C:\Users\Cipri\OneDrive\Documents\GitHub\BookShop\BookShop\Views\Admin\OutOfStock.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "C:\Users\Cipri\OneDrive\Documents\GitHub\BookShop\BookShop\Views\Admin\OutOfStock.cshtml"
             
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n<a  class=\"btn btn-danger\"");
            BeginWriteAttribute("href", " href=\'", 2174, "\'", 2212, 1);
#nullable restore
#line 49 "C:\Users\Cipri\OneDrive\Documents\GitHub\BookShop\BookShop\Views\Admin\OutOfStock.cshtml"
WriteAttributeValue("", 2181, Url.Action("AddBook", "Admin"), 2181, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Add Book</a>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BookShop.Models.Admins.AdminBooksViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
