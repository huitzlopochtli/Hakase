#pragma checksum "D:\Codes\Hakase\Views\Materials\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "31c62de09770cff7e5d8b27d0e9f14d635a69b8a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Materials_Details), @"mvc.1.0.view", @"/Views/Materials/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Materials/Details.cshtml", typeof(AspNetCore.Views_Materials_Details))]
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
#line 1 "D:\Codes\Hakase\Views\_ViewImports.cshtml"
using WebApplication1;

#line default
#line hidden
#line 2 "D:\Codes\Hakase\Views\_ViewImports.cshtml"
using WebApplication1.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"31c62de09770cff7e5d8b27d0e9f14d635a69b8a", @"/Views/Materials/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"729efaa87342638aecfe1a972ce9f9f8dff55b4c", @"/Views/_ViewImports.cshtml")]
    public class Views_Materials_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApplication1.Models.Material>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/AdminLTE/adminlte.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Materials", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(40, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Codes\Hakase\Views\Materials\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(132, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(134, 64, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8d11ebca75474b37a08e6f495b23425f", async() => {
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
            EndContext();
            BeginContext(198, 107, true);
            WriteLiteral("\r\n<link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/ionic/1.3.2/css/ionic.min.css\" />\r\n\r\n");
            EndContext();
            BeginContext(305, 57, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4876b203be8c41a1ad5313c200d74b12", async() => {
                BeginContext(354, 4, true);
                WriteLiteral("← 戻る");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(362, 253, true);
            WriteLiteral("\r\n<br />\r\n<br />\r\n<div class=\"info-box\">\r\n    <span class=\"info-box-icon bg-lime\"><i class=\"ion ion-ios-cart-outline\"></i></span>\r\n\r\n    <div class=\"info-box-content\">\r\n        <span class=\"info-box-text\"><h1>素材</h1></span>\r\n\r\n        <h2>\r\n            ");
            EndContext();
            BeginContext(616, 40, false);
#line 21 "D:\Codes\Hakase\Views\Materials\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(656, 16, true);
            WriteLiteral(": \r\n            ");
            EndContext();
            BeginContext(673, 36, false);
#line 22 "D:\Codes\Hakase\Views\Materials\Details.cshtml"
       Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(709, 90, true);
            WriteLiteral("\r\n        </h2>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"row\">\r\n    <div class=\"\">\r\n        <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 799, "\"", 820, 1);
#line 29 "D:\Codes\Hakase\Views\Materials\Details.cshtml"
WriteAttributeValue("", 805, Model.ImageUrl, 805, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(821, 208, true);
            WriteLiteral(" style=\"min-width: 300px; min-height: 300px; max-width: 300px; min-height: 300px;\"/>\r\n    </div>\r\n    <dl class=\"dl-horizontal right\">\r\n        <dt>\r\n            作成者\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1030, 42, false);
#line 36 "D:\Codes\Hakase\Views\Materials\Details.cshtml"
       Write(Html.DisplayFor(model => model.User.Email));

#line default
#line hidden
            EndContext();
            BeginContext(1072, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1116, 47, false);
#line 39 "D:\Codes\Hakase\Views\Materials\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DateCreated));

#line default
#line hidden
            EndContext();
            BeginContext(1163, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1207, 43, false);
#line 42 "D:\Codes\Hakase\Views\Materials\Details.cshtml"
       Write(Html.DisplayFor(model => model.DateCreated));

#line default
#line hidden
            EndContext();
            BeginContext(1250, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1294, 48, false);
#line 45 "D:\Codes\Hakase\Views\Materials\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DateModified));

#line default
#line hidden
            EndContext();
            BeginContext(1342, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1386, 44, false);
#line 48 "D:\Codes\Hakase\Views\Materials\Details.cshtml"
       Write(Html.DisplayFor(model => model.DateModified));

#line default
#line hidden
            EndContext();
            BeginContext(1430, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1474, 48, false);
#line 51 "D:\Codes\Hakase\Views\Materials\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.UserModified));

#line default
#line hidden
            EndContext();
            BeginContext(1522, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1566, 44, false);
#line 54 "D:\Codes\Hakase\Views\Materials\Details.cshtml"
       Write(Html.DisplayFor(model => model.UserModified));

#line default
#line hidden
            EndContext();
            BeginContext(1610, 117, true);
            WriteLiteral("\r\n        </dd>\r\n        <br />\r\n        <br />\r\n        <br />\r\n        <br />\r\n        <br />\r\n        <dt><button>");
            EndContext();
            BeginContext(1727, 84, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9b192853ead24de7a265be1e4f3e235a", async() => {
                BeginContext(1802, 5, true);
                WriteLiteral("削除する?");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 61 "D:\Codes\Hakase\Views\Materials\Details.cshtml"
                                                                        WriteLiteral(Model.Id);

#line default
#line hidden
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
            EndContext();
            BeginContext(1811, 35, true);
            WriteLiteral("</dt></button>\r\n    </dl>\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApplication1.Models.Material> Html { get; private set; }
    }
}
#pragma warning restore 1591
