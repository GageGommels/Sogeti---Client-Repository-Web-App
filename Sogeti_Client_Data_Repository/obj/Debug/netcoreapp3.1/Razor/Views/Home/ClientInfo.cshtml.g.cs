#pragma checksum "C:\Users\gomme\Source\Repos\Sogeti---Client-Repository-Web-App\Sogeti_Client_Data_Repository\Views\Home\ClientInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "64a10517e2a77a1ac6920c856669711dc3f41e2d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ClientInfo), @"mvc.1.0.view", @"/Views/Home/ClientInfo.cshtml")]
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
#line 1 "C:\Users\gomme\Source\Repos\Sogeti---Client-Repository-Web-App\Sogeti_Client_Data_Repository\Views\_ViewImports.cshtml"
using Sogeti_Client_Data_Repository;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\gomme\Source\Repos\Sogeti---Client-Repository-Web-App\Sogeti_Client_Data_Repository\Views\_ViewImports.cshtml"
using Sogeti_Client_Data_Repository.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"64a10517e2a77a1ac6920c856669711dc3f41e2d", @"/Views/Home/ClientInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7837b78baf9c7e7c09fbd68520dfbd81b6f9c317", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ClientInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-inline"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\gomme\Source\Repos\Sogeti---Client-Repository-Web-App\Sogeti_Client_Data_Repository\Views\Home\ClientInfo.cshtml"
  
    ViewData["Title"] = "ClientInfo";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "64a10517e2a77a1ac6920c856669711dc3f41e2d4267", async() => {
                WriteLiteral(@"
    <style>
        .table-fixed tbody {
            height: 300px;
            overflow-y: auto;
            width: 100%;
        }

        .table-fixed thead,
        .table-fixed tbody,
        .table-fixed tr,
        .table-fixed td,
        .table-fixed th {
            display: block;
        }

            .table-fixed tbody td,
            .table-fixed tbody th,
            .table-fixed thead > tr > th {
                float: left;
                position: relative;
            }
    </style>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "64a10517e2a77a1ac6920c856669711dc3f41e2d5764", async() => {
                WriteLiteral("\r\n    <br>\r\n    <br>\r\n    <div class=\"container-fluid\">\r\n        <div class=\"row\">\r\n            <div class=\"col-md-2\"></div>\r\n            <div class=\"col-md-8\">\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "64a10517e2a77a1ac6920c856669711dc3f41e2d6218", async() => {
                    WriteLiteral(@"
                    <div class=""col-md-2"">
                        <input type=""text"" name=""ClientName"" placeholder=""Client Name"">
                    </div>
                    <div class=""col-md-5"">
                        <input type=""text"" name=""Description"" placeholder=""Description"">
                    </div>
                    <div class=""col-md-3""></div>
                    <div class=""col-md-2"">
                        <button type=""button"" class=""btn btn-info btn-block""> Search </button>
                    </div>
                ");
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
        <br>
        <div class=""row"">
            <div class=""col-md-2""></div>
            <div class=""col-md-8"">
                <table class=""table table-bordered table-hover table-fixed"">
                    <thead>
                        <tr>
                            <th scope=""col"" class=""col-3"">Client Names</th>
                            <th scope=""col"" class=""col-9"">Descriptions</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td scope=""col"" class=""col-3"">Client 1</td>
                            <td scope=""col"" class=""col-9"">Description 1</td>
                        </tr>
                        <tr>
                            <td scope=""col"" class=""col-3"">Client 2</td>
                            <td scope=""col"" class=""col-9"">Description 2</td>
                        </tr>
                        <tr>
                            <td ");
                WriteLiteral(@"scope=""col"" class=""col-3"">Client 3</td>
                            <td scope=""col"" class=""col-9"">Description 3</td>
                        </tr>
                        <tr>
                            <td scope=""col"" class=""col-3"">Client 3</td>
                            <td scope=""col"" class=""col-9"">Description 3</td>
                        </tr>
                        <tr>
                            <td scope=""col"" class=""col-3"">Client 3</td>
                            <td scope=""col"" class=""col-9"">Description 3</td>
                        </tr>
                        <tr>
                            <td scope=""col"" class=""col-3"">Client 3</td>
                            <td scope=""col"" class=""col-9"">Description 3</td>
                        </tr>
                        <tr>
                            <td scope=""col"" class=""col-3"">Client 3</td>
                            <td scope=""col"" class=""col-9"">Description 3</td>
                        </tr>
                        <t");
                WriteLiteral(@"r>
                            <td scope=""col"" class=""col-3"">Client 3</td>
                            <td scope=""col"" class=""col-9"">Description 3</td>
                        </tr>
                        <tr>
                            <td scope=""col"" class=""col-3"">Client 3</td>
                            <td scope=""col"" class=""col-9"">Description 3</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""row"">
                    <div class=""col-md-8""></div>
                    <div class=""col-md-2"">
                        <button type=""button"" class=""btn btn-info btn-block"">
                            New Client
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
