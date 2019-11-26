#pragma checksum "Y:\Storage\Codes\C#\Hakase\Views\Paint\Upload.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fa7b23166aef2f874ffc5cdea30753dfe417bf2d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Paint_Upload), @"mvc.1.0.view", @"/Views/Paint/Upload.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Paint/Upload.cshtml", typeof(AspNetCore.Views_Paint_Upload))]
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
#line 1 "Y:\Storage\Codes\C#\Hakase\Views\_ViewImports.cshtml"
using WebApplication1;

#line default
#line hidden
#line 2 "Y:\Storage\Codes\C#\Hakase\Views\_ViewImports.cshtml"
using WebApplication1.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa7b23166aef2f874ffc5cdea30753dfe417bf2d", @"/Views/Paint/Upload.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"729efaa87342638aecfe1a972ce9f9f8dff55b4c", @"/Views/_ViewImports.cshtml")]
    public class Views_Paint_Upload : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApplication1.ViewModels.UploadReformListViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Paint", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Upload", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-group"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "Y:\Storage\Codes\C#\Hakase\Views\Paint\Upload.cshtml"
  
    ViewData["Title"] = "Upload";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(150, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 7 "Y:\Storage\Codes\C#\Hakase\Views\Paint\Upload.cshtml"
  
    bool isAdmin = Context.User.IsInRole("Admin");

#line default
#line hidden
            BeginContext(211, 31, true);
            WriteLiteral("\r\n<div class=\"container\">\r\n    ");
            EndContext();
            BeginContext(242, 293, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8b4cce4ed217427f8b8d33b25c919e09", async() => {
                BeginContext(340, 188, true);
                WriteLiteral("\r\n        <label class=\"control-label\"> 壁または床の写真をアップロードします。</label>\r\n        <input type=\"file\" id=\"paintFileUpload\" name=\"source\" class=\"form-control\" placeholder=\"this is a test\"/>\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(535, 14, true);
            WriteLiteral("\r\n    <br />\r\n");
            EndContext();
#line 17 "Y:\Storage\Codes\C#\Hakase\Views\Paint\Upload.cshtml"
     if (Context.User.Identity.IsAuthenticated)
    {

#line default
#line hidden
            BeginContext(605, 224, true);
            WriteLiteral("        <table class=\"table table-striped table-bordered\" style=\"width: 100%\" id=\"customerTable2\">\r\n            <thead>\r\n                <tr>\r\n                    <th>\r\n                        画像\r\n                    </th>\r\n");
            EndContext();
#line 25 "Y:\Storage\Codes\C#\Hakase\Views\Paint\Upload.cshtml"
                     if (isAdmin)
                    {

#line default
#line hidden
            BeginContext(887, 97, true);
            WriteLiteral("                        <th>\r\n                            画像のURL\r\n                        </th>\r\n");
            EndContext();
#line 30 "Y:\Storage\Codes\C#\Hakase\Views\Paint\Upload.cshtml"
                    }

#line default
#line hidden
            BeginContext(1007, 82, true);
            WriteLiteral("                    <th>\r\n                        作成日\r\n                    </th>\r\n");
            EndContext();
#line 34 "Y:\Storage\Codes\C#\Hakase\Views\Paint\Upload.cshtml"
                     if (isAdmin)
                    {


#line default
#line hidden
            BeginContext(1149, 94, true);
            WriteLiteral("                        <th>\r\n                            作成者\r\n                        </th>\r\n");
            EndContext();
            BeginContext(1245, 188, true);
            WriteLiteral("                        <th>\r\n                            変更日\r\n                        </th>\r\n                        <th>\r\n                            編集者\r\n                        </th>\r\n");
            EndContext();
#line 47 "Y:\Storage\Codes\C#\Hakase\Views\Paint\Upload.cshtml"
                    }

#line default
#line hidden
            BeginContext(1456, 99, true);
            WriteLiteral("                    <th></th>\r\n                </tr>\r\n            </thead>\r\n\r\n            <tbody>\r\n");
            EndContext();
#line 53 "Y:\Storage\Codes\C#\Hakase\Views\Paint\Upload.cshtml"
                 foreach (var item in Model.UploadedImages)
                {

#line default
#line hidden
            BeginContext(1635, 88, true);
            WriteLiteral("                    <tr>\r\n                        <th>\r\n                            <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 1723, "\"", 1743, 1);
#line 57 "Y:\Storage\Codes\C#\Hakase\Views\Paint\Upload.cshtml"
WriteAttributeValue("", 1729, item.ImageUrl, 1729, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1744, 78, true);
            WriteLiteral(" style=\"max-height: 40px; max-width: 40px\" />\r\n                        </th>\r\n");
            EndContext();
#line 59 "Y:\Storage\Codes\C#\Hakase\Views\Paint\Upload.cshtml"
                         if (isAdmin)
                        {


#line default
#line hidden
            BeginContext(1890, 66, true);
            WriteLiteral("                            <th>\r\n                                ");
            EndContext();
            BeginContext(1957, 13, false);
#line 63 "Y:\Storage\Codes\C#\Hakase\Views\Paint\Upload.cshtml"
                           Write(item.ImageUrl);

#line default
#line hidden
            EndContext();
            BeginContext(1970, 37, true);
            WriteLiteral("\r\n                            </th>\r\n");
            EndContext();
#line 65 "Y:\Storage\Codes\C#\Hakase\Views\Paint\Upload.cshtml"
                        }

#line default
#line hidden
            BeginContext(2034, 58, true);
            WriteLiteral("                        <td>\r\n                            ");
            EndContext();
            BeginContext(2093, 46, false);
#line 67 "Y:\Storage\Codes\C#\Hakase\Views\Paint\Upload.cshtml"
                       Write(Html.DisplayFor(modelItem => item.DateCreated));

#line default
#line hidden
            EndContext();
            BeginContext(2139, 33, true);
            WriteLiteral("\r\n                        </td>\r\n");
            EndContext();
#line 69 "Y:\Storage\Codes\C#\Hakase\Views\Paint\Upload.cshtml"
                         if (isAdmin)
                        {


#line default
#line hidden
            BeginContext(2240, 66, true);
            WriteLiteral("                            <td>\r\n                                ");
            EndContext();
            BeginContext(2307, 46, false);
#line 73 "Y:\Storage\Codes\C#\Hakase\Views\Paint\Upload.cshtml"
                           Write(Html.DisplayFor(modelItem => item.UserCreated));

#line default
#line hidden
            EndContext();
            BeginContext(2353, 37, true);
            WriteLiteral("\r\n                            </td>\r\n");
            EndContext();
            BeginContext(2392, 66, true);
            WriteLiteral("                            <td>\r\n                                ");
            EndContext();
            BeginContext(2459, 47, false);
#line 77 "Y:\Storage\Codes\C#\Hakase\Views\Paint\Upload.cshtml"
                           Write(Html.DisplayFor(modelItem => item.DateModified));

#line default
#line hidden
            EndContext();
            BeginContext(2506, 103, true);
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(2610, 47, false);
#line 80 "Y:\Storage\Codes\C#\Hakase\Views\Paint\Upload.cshtml"
                           Write(Html.DisplayFor(modelItem => item.UserModified));

#line default
#line hidden
            EndContext();
            BeginContext(2657, 37, true);
            WriteLiteral("\r\n                            </td>\r\n");
            EndContext();
#line 82 "Y:\Storage\Codes\C#\Hakase\Views\Paint\Upload.cshtml"
                        }

#line default
#line hidden
            BeginContext(2721, 58, true);
            WriteLiteral("                        <td>\r\n                            ");
            EndContext();
            BeginContext(2779, 86, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a5a77116fb2848d4b2b25efceba4e463", async() => {
                BeginContext(2857, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-imgUrl", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 84 "Y:\Storage\Codes\C#\Hakase\Views\Paint\Upload.cshtml"
                                                                              WriteLiteral(item.ImageUrl);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["imgUrl"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-imgUrl", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["imgUrl"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2865, 32, true);
            WriteLiteral(" |\r\n                            ");
            EndContext();
            BeginContext(2897, 57, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "92c06b0209e34cf4acf4a459c64cafa7", async() => {
                BeginContext(2944, 6, true);
                WriteLiteral("Delete");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 85 "Y:\Storage\Codes\C#\Hakase\Views\Paint\Upload.cshtml"
                                                     WriteLiteral(item.Id);

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
            BeginContext(2954, 60, true);
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
            EndContext();
#line 88 "Y:\Storage\Codes\C#\Hakase\Views\Paint\Upload.cshtml"
                }

#line default
#line hidden
            BeginContext(3033, 40, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n");
            EndContext();
            BeginContext(3075, 897, true);
            WriteLiteral(@"        <table class=""table table-striped table-bordered"" style=""width: 100%"" id=""customerTable"">
            <thead>
                <tr>
                    <th>
                        画像名
                    </th>
                    <th>
                        画像
                    </th>
                    <th>
                        元画像
                    </th>
                    <th>
                        画像のURL
                    </th>
                    <th>
                        作成日
                    </th>
                    <th>
                        作成者
                    </th>
                    <th>
                        変更日
                    </th>
                    <th>
                        編集者
                    </th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 123 "Y:\Storage\Codes\C#\Hakase\Views\Paint\Upload.cshtml"
                 foreach (var item in Model.ReformedImages)
                {

#line default
#line hidden
            BeginContext(4052, 84, true);
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(4137, 39, false);
#line 127 "Y:\Storage\Codes\C#\Hakase\Views\Paint\Upload.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
            EndContext();
            BeginContext(4176, 95, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 4271, "\"", 4305, 1);
#line 130 "Y:\Storage\Codes\C#\Hakase\Views\Paint\Upload.cshtml"
WriteAttributeValue("", 4277, item.UploadedImage.ImageUrl, 4277, 28, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4306, 140, true);
            WriteLiteral(" style=\"max-height: 40px; max-width: 40px\" />\r\n                        </td>\r\n                        <td>\r\n                            <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 4446, "\"", 4466, 1);
#line 133 "Y:\Storage\Codes\C#\Hakase\Views\Paint\Upload.cshtml"
WriteAttributeValue("", 4452, item.ImageUrl, 4452, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4467, 136, true);
            WriteLiteral(" style=\"max-height: 40px; max-width: 40px\" />\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(4604, 43, false);
#line 136 "Y:\Storage\Codes\C#\Hakase\Views\Paint\Upload.cshtml"
                       Write(Html.DisplayFor(modelItem => item.ImageUrl));

#line default
#line hidden
            EndContext();
            BeginContext(4647, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(4739, 46, false);
#line 139 "Y:\Storage\Codes\C#\Hakase\Views\Paint\Upload.cshtml"
                       Write(Html.DisplayFor(modelItem => item.DateCreated));

#line default
#line hidden
            EndContext();
            BeginContext(4785, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(4877, 46, false);
#line 142 "Y:\Storage\Codes\C#\Hakase\Views\Paint\Upload.cshtml"
                       Write(Html.DisplayFor(modelItem => item.UserCreated));

#line default
#line hidden
            EndContext();
            BeginContext(4923, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(5015, 47, false);
#line 145 "Y:\Storage\Codes\C#\Hakase\Views\Paint\Upload.cshtml"
                       Write(Html.DisplayFor(modelItem => item.DateModified));

#line default
#line hidden
            EndContext();
            BeginContext(5062, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(5154, 47, false);
#line 148 "Y:\Storage\Codes\C#\Hakase\Views\Paint\Upload.cshtml"
                       Write(Html.DisplayFor(modelItem => item.UserModified));

#line default
#line hidden
            EndContext();
            BeginContext(5201, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(5292, 82, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e18f71bfbe314b51abf595c477cf1946", async() => {
                BeginContext(5366, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 151 "Y:\Storage\Codes\C#\Hakase\Views\Paint\Upload.cshtml"
                                                                          WriteLiteral(item.ImageUrl);

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
            BeginContext(5374, 32, true);
            WriteLiteral(" |\r\n                            ");
            EndContext();
            BeginContext(5406, 57, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e00fc50d50a347ba8c1bc3804e77ec28", async() => {
                BeginContext(5453, 6, true);
                WriteLiteral("Delete");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 152 "Y:\Storage\Codes\C#\Hakase\Views\Paint\Upload.cshtml"
                                                     WriteLiteral(item.Id);

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
            BeginContext(5463, 60, true);
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
            EndContext();
#line 155 "Y:\Storage\Codes\C#\Hakase\Views\Paint\Upload.cshtml"
                }

#line default
#line hidden
            BeginContext(5542, 40, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n");
            EndContext();
#line 158 "Y:\Storage\Codes\C#\Hakase\Views\Paint\Upload.cshtml"
    }

#line default
#line hidden
            BeginContext(5589, 16, true);
            WriteLiteral("\r\n</div>\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApplication1.ViewModels.UploadReformListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
