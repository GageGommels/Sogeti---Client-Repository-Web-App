#pragma checksum "C:\Users\junth\Source\Repos\Sogeti---Client-Repository-Web-App\Sogeti_Client_Data_Repository\Views\Home\Application.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "228ad563ba9d8f9d2826a086a3d521756e7f8912"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Application), @"mvc.1.0.view", @"/Views/Home/Application.cshtml")]
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
#line 1 "C:\Users\junth\Source\Repos\Sogeti---Client-Repository-Web-App\Sogeti_Client_Data_Repository\Views\_ViewImports.cshtml"
using Sogeti_Client_Data_Repository;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\junth\Source\Repos\Sogeti---Client-Repository-Web-App\Sogeti_Client_Data_Repository\Views\_ViewImports.cshtml"
using Sogeti_Client_Data_Repository.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"228ad563ba9d8f9d2826a086a3d521756e7f8912", @"/Views/Home/Application.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7837b78baf9c7e7c09fbd68520dfbd81b6f9c317", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Application : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onload", new global::Microsoft.AspNetCore.Html.HtmlString("onLoad()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\junth\Source\Repos\Sogeti---Client-Repository-Web-App\Sogeti_Client_Data_Repository\Views\Home\Application.cshtml"
  
    ViewData["Title"] = "Application";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\junth\Source\Repos\Sogeti---Client-Repository-Web-App\Sogeti_Client_Data_Repository\Views\Home\Application.cshtml"
  
    dataTableEntry getData = new dataTableEntry("Application Name", "Department", "Department Manager", "Client", "Primary BA", "Technical Contact", "Application Type 1,Application Type 2", "Technology 1,Technology 2", "Production Server", "Production URL", "QA Server", "QA URL", "Development Server", "Development URL", "Some Place", "10", "10", "10", "10", "10", "Application ID 1");

#line default
#line hidden
#nullable disable
            WriteLiteral("<script>\r\n\r\n    function onLoad() {\r\n        document.getElementById(\"appName\").value = \"");
#nullable restore
#line 11 "C:\Users\junth\Source\Repos\Sogeti---Client-Repository-Web-App\Sogeti_Client_Data_Repository\Views\Home\Application.cshtml"
                                               Write(getData.App_name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\";\r\n        document.getElementById(\"dept\").value = \"");
#nullable restore
#line 12 "C:\Users\junth\Source\Repos\Sogeti---Client-Repository-Web-App\Sogeti_Client_Data_Repository\Views\Home\Application.cshtml"
                                            Write(getData.Department);

#line default
#line hidden
#nullable disable
            WriteLiteral("\";\r\n        document.getElementById(\"deptMgr\").value = \"");
#nullable restore
#line 13 "C:\Users\junth\Source\Repos\Sogeti---Client-Repository-Web-App\Sogeti_Client_Data_Repository\Views\Home\Application.cshtml"
                                               Write(getData.DepartmentManager);

#line default
#line hidden
#nullable disable
            WriteLiteral("\";\r\n        document.getElementById(\"client\").value = \"");
#nullable restore
#line 14 "C:\Users\junth\Source\Repos\Sogeti---Client-Repository-Web-App\Sogeti_Client_Data_Repository\Views\Home\Application.cshtml"
                                              Write(getData.Client);

#line default
#line hidden
#nullable disable
            WriteLiteral("\";\r\n        document.getElementById(\"ba\").value = \"");
#nullable restore
#line 15 "C:\Users\junth\Source\Repos\Sogeti---Client-Repository-Web-App\Sogeti_Client_Data_Repository\Views\Home\Application.cshtml"
                                          Write(getData.PrimaryBA);

#line default
#line hidden
#nullable disable
            WriteLiteral("\";\r\n        document.getElementById(\"contact\").value = \"");
#nullable restore
#line 16 "C:\Users\junth\Source\Repos\Sogeti---Client-Repository-Web-App\Sogeti_Client_Data_Repository\Views\Home\Application.cshtml"
                                               Write(getData.TechContact);

#line default
#line hidden
#nullable disable
            WriteLiteral("\";\r\n\r\n        var table, data, row, cell, input;\r\n\r\n        table = document.getElementById(\"myApplicationType\");\r\n        data = \"");
#nullable restore
#line 21 "C:\Users\junth\Source\Repos\Sogeti---Client-Repository-Web-App\Sogeti_Client_Data_Repository\Views\Home\Application.cshtml"
           Write(getData.ApplicationType);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""".split("","");
        for (i = 0; i < data.length; i++) {
            row = table.insertRow(table.length);

            cell = row.insertCell(0);
            input = document.createElement('input');
            input.type = 'text';
            input.value = data[i];
            cell.appendChild(input);
        }

        table = document.getElementById(""myTechnology"");
        data = """);
#nullable restore
#line 33 "C:\Users\junth\Source\Repos\Sogeti---Client-Repository-Web-App\Sogeti_Client_Data_Repository\Views\Home\Application.cshtml"
           Write(getData.Tech);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""".split("","");
        for (i = 0; i < data.length; i++) {
            row = table.insertRow(table.length);

            cell = row.insertCell(0);
            input = document.createElement('input');
            input.type = 'text';
            input.value = data[i];
            cell.appendChild(input);
        }  

        var prod, qa, dev;

        table = document.getElementById(""myServers"");
        prod = """);
#nullable restore
#line 47 "C:\Users\junth\Source\Repos\Sogeti---Client-Repository-Web-App\Sogeti_Client_Data_Repository\Views\Home\Application.cshtml"
           Write(getData.ProductionServer);

#line default
#line hidden
#nullable disable
            WriteLiteral("\".split(\",\");\r\n        qa = \"");
#nullable restore
#line 48 "C:\Users\junth\Source\Repos\Sogeti---Client-Repository-Web-App\Sogeti_Client_Data_Repository\Views\Home\Application.cshtml"
         Write(getData.QaServer);

#line default
#line hidden
#nullable disable
            WriteLiteral("\".split(\",\");\r\n        dev = \"");
#nullable restore
#line 49 "C:\Users\junth\Source\Repos\Sogeti---Client-Repository-Web-App\Sogeti_Client_Data_Repository\Views\Home\Application.cshtml"
          Write(getData.DevlopmentServer);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""".split("","");
        for (i = 0; i < prod.length; i++) {
            row = table.insertRow(table.length);

            cell = row.insertCell(0);
            input = document.createElement('select');
            option = document.createElement('option');
            option.text = ""Production""
            input.add(option);
            input.disabled = true;
            cell.appendChild(input);

            cell = row.insertCell(1);
            input = document.createElement('input');
            input.type = 'text';
            input.value = prod[i];
            cell.appendChild(input);
        }
        for (i = 0; i < qa.length; i++) {
            row = table.insertRow(table.length);

            cell = row.insertCell(0);
            input = document.createElement('select');
            option = document.createElement('option');
            option.text = ""QA""
            input.add(option);
            input.disabled = true;
            cell.appendChild(input);

            cell ");
            WriteLiteral(@"= row.insertCell(1);
            input = document.createElement('input');
            input.type = 'text';
            input.value = qa[i];
            cell.appendChild(input);
        }
        for (i = 0; i < dev.length; i++) {
            row = table.insertRow(table.length);

            cell = row.insertCell(0);
            input = document.createElement('select');
            option = document.createElement('option');
            option.text = ""Development""
            input.add(option);
            input.disabled = true;
            cell.appendChild(input);

            cell = row.insertCell(1);
            input = document.createElement('input');
            input.type = 'text';
            input.value = dev[i];
            cell.appendChild(input);
        }


        table = document.getElementById(""myUrls"");
        prod = """);
#nullable restore
#line 104 "C:\Users\junth\Source\Repos\Sogeti---Client-Repository-Web-App\Sogeti_Client_Data_Repository\Views\Home\Application.cshtml"
           Write(getData.ProductionURL);

#line default
#line hidden
#nullable disable
            WriteLiteral("\".split(\",\");\r\n        qa = \"");
#nullable restore
#line 105 "C:\Users\junth\Source\Repos\Sogeti---Client-Repository-Web-App\Sogeti_Client_Data_Repository\Views\Home\Application.cshtml"
         Write(getData.QaURL);

#line default
#line hidden
#nullable disable
            WriteLiteral("\".split(\",\");\r\n        dev = \"");
#nullable restore
#line 106 "C:\Users\junth\Source\Repos\Sogeti---Client-Repository-Web-App\Sogeti_Client_Data_Repository\Views\Home\Application.cshtml"
          Write(getData.DevlopmentURL);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""".split("","");
        for (i = 0; i < prod.length; i++) {
            row = table.insertRow(table.length);

            cell = row.insertCell(0);
            input = document.createElement('select');
            option = document.createElement('option');
            option.text = ""Production""
            input.add(option);
            input.disabled = true;
            cell.appendChild(input);

            cell = row.insertCell(1);
            input = document.createElement('input');
            input.type = 'text';
            input.value = prod[i];
            cell.appendChild(input);
        }
        for (i = 0; i < qa.length; i++) {
            row = table.insertRow(table.length);

            cell = row.insertCell(0);
            input = document.createElement('select');
            option = document.createElement('option');
            option.text = ""QA""
            input.add(option);
            input.disabled = true;
            cell.appendChild(input);

            cell ");
            WriteLiteral(@"= row.insertCell(1);
            input = document.createElement('input');
            input.type = 'text';
            input.value = qa[i];
            cell.appendChild(input);
        }
        for (i = 0; i < dev.length; i++) {
            row = table.insertRow(table.length);

            cell = row.insertCell(0);
            input = document.createElement('select');
            option = document.createElement('option');
            option.text = ""Development""
            input.add(option);
            input.disabled = true;
            cell.appendChild(input);

            cell = row.insertCell(1);
            input = document.createElement('input');
            input.type = 'text';
            input.value = dev[i];
            cell.appendChild(input);
        }

        table = document.getElementById(""myNotes"");
        data = """);
#nullable restore
#line 160 "C:\Users\junth\Source\Repos\Sogeti---Client-Repository-Web-App\Sogeti_Client_Data_Repository\Views\Home\Application.cshtml"
           Write(getData.ApplicationType);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""".split("","");
        /*for (i = 0; i < data.length; i++) {
            row = table.insertRow(table.length);

            cell = row.insertCell(0);
            input = document.createElement('input');
            input.type = 'text';
            input.value = data[i];
            cell.appendChild(input);
        }*/

        document.getElementById(""source"").value = """);
#nullable restore
#line 171 "C:\Users\junth\Source\Repos\Sogeti---Client-Repository-Web-App\Sogeti_Client_Data_Repository\Views\Home\Application.cshtml"
                                              Write(getData.CodeSource);

#line default
#line hidden
#nullable disable
            WriteLiteral("\";\r\n        document.getElementById(\"stable\").value = \"");
#nullable restore
#line 172 "C:\Users\junth\Source\Repos\Sogeti---Client-Repository-Web-App\Sogeti_Client_Data_Repository\Views\Home\Application.cshtml"
                                              Write(getData.Stability);

#line default
#line hidden
#nullable disable
            WriteLiteral("\";\r\n        document.getElementById(\"future\").value = \"");
#nullable restore
#line 173 "C:\Users\junth\Source\Repos\Sogeti---Client-Repository-Web-App\Sogeti_Client_Data_Repository\Views\Home\Application.cshtml"
                                              Write(getData.FutureDevlopment);

#line default
#line hidden
#nullable disable
            WriteLiteral("\";\r\n        document.getElementById(\"repo\").value = \"");
#nullable restore
#line 174 "C:\Users\junth\Source\Repos\Sogeti---Client-Repository-Web-App\Sogeti_Client_Data_Repository\Views\Home\Application.cshtml"
                                            Write(getData.Repository);

#line default
#line hidden
#nullable disable
            WriteLiteral("\";\r\n        document.getElementById(\"sensitive\").value = \"");
#nullable restore
#line 175 "C:\Users\junth\Source\Repos\Sogeti---Client-Repository-Web-App\Sogeti_Client_Data_Repository\Views\Home\Application.cshtml"
                                                 Write(getData.Sensitivity);

#line default
#line hidden
#nullable disable
            WriteLiteral("\";\r\n        document.getElementById(\"crit\").value = \"");
#nullable restore
#line 176 "C:\Users\junth\Source\Repos\Sogeti---Client-Repository-Web-App\Sogeti_Client_Data_Repository\Views\Home\Application.cshtml"
                                            Write(getData.Criticality);

#line default
#line hidden
#nullable disable
            WriteLiteral("\";\r\n    }\r\n\r\n</script>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "228ad563ba9d8f9d2826a086a3d521756e7f891216806", async() => {
                WriteLiteral(@"
    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-md-12"">
                <table class=""table table-hover table-bordered"">
                    <tbody>
                        <tr>
                            <td>
                                Application Name:
                            </td>
                            <td>
                                <input type=""text"" id=""appName"" name=""appName"" value=""EXAMPLE"" readonly>
                            </td>
                            <td>
                                Client:
                            </td>
                            <td>
                                <input type=""text"" id=""client"" name=""client"" value=""EXAMPLE"" readonly>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Department:
                            </td>
                            <td>
           ");
                WriteLiteral(@"                     <input type=""text"" id=""dept"" name=""dept"" value=""EXAMPLE"" readonly>
                            </td>
                            <td>
                                Primary BA:
                            </td>
                            <td>
                                <input type=""text"" id=""ba"" name=""ba"" value=""EXAMPLE"" readonly>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Dept. Manager:
                            </td>
                            <td>
                                <input type=""text"" id=""deptMgr"" name=""deptMgr"" value=""EXAMPLE"" readonly>
                            </td>
                            <td>
                                Tech. Contact:
                            </td>
                            <td>
                                <input type=""text"" id=""contact"" name=""contact"" value=""EXAMPLE"" readonly>
           ");
                WriteLiteral(@"                 </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <div><br /></div>
        <div class=""row"">
            <div class=""col-md-6"">
                <table class=""table table-bordered table-hover table-sm"" id=""myApplicationType"">
                    <thead>
                        <tr>
                            <th>
                                Application Type
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>
                <div class=""row"">
                    <div class=""col-md-6"">

                        <button type=""button"" class=""btn btn-sm btn-block btn-info"" onclick=""applicationType()"">
                            Add
                        </button>
                    </div>
                    <div class=""col-md-6"">

                        <but");
                WriteLiteral(@"ton type=""button"" class=""btn btn-success btn-sm btn-block"">
                            Save
                        </button>
                    </div>
                </div>
            </div>
            <div class=""col-md-6"">
                <table class=""table table-bordered table-hover table-sm"" id=""myTechnology"">
                    <thead>
                        <tr>
                            <th>
                                Technology
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>
                <div class=""row"">
                    <div class=""col-md-6"">

                        <button type=""button"" class=""btn btn-block btn-sm btn-info"" onclick=""technology()"">
                            Add
                        </button>
                    </div>
                    <div class=""col-md-6"">

                        <button type=""butto");
                WriteLiteral(@"n"" class=""btn btn-success btn-block btn-sm"">
                            Save
                        </button>
                    </div>
                </div>
            </div>
        </div>
        <div><br /></div>
        <div class=""row"">
            <div class=""col-md-12"">
                <table class=""table table-bordered table-sm"" id=""myServers"">
                    <thead>
                        <tr>
                            <th colspan=""2"">
                                Servers
                            </th>
                        </tr>
                        <tr>
                            <th>
                                Type
                            </th>
                            <th>
                                Server Name
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>
                <div class=""row"">
        ");
                WriteLiteral(@"            <div class=""col-md-3"">
                    </div>
                    <div class=""col-md-3"">
                    </div>
                    <div class=""col-md-3"">

                        <button type=""button"" class=""btn btn-block btn-sm btn-info"" onclick=""servers()"">
                            Add
                        </button>
                    </div>
                    <div class=""col-md-3"">

                        <button type=""button"" class=""btn btn-success btn-block btn-sm"">
                            Save
                        </button>
                    </div>
                </div>
            </div>
        </div>
        <div><br /></div>
        <div class=""row"">
            <div class=""col-md-12"">
                <table class=""table table-bordered table-sm"" id=""myUrls"">
                    <thead>
                        <tr>
                            <th colspan=""2"">
                                URLs
                            </th>
    ");
                WriteLiteral(@"                    </tr>
                        <tr>
                            <th>
                                Type
                            </th>
                            <th>
                                URL
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>
                <div class=""row"">
                    <div class=""col-md-3"">
                    </div>
                    <div class=""col-md-3"">
                    </div>
                    <div class=""col-md-3"">

                        <button type=""button"" class=""btn btn-block btn-sm btn-info"" onclick=""urls()"">
                            Add
                        </button>
                    </div>
                    <div class=""col-md-3"">

                        <button type=""button"" class=""btn btn-success btn-block btn-sm"">
                            Save
               ");
                WriteLiteral(@"         </button>
                    </div>
                </div>
            </div>
        </div>
        <div><br /></div>
        <div class=""row"">
            <div class=""col-md-12"">
                <table class=""table table-hover table-bordered"">
                    <tbody>
                        <tr>
                            <td>
                                Code Source:
                            </td>
                            <td>
                                <input type=""text"" id=""source"" name=""source"" value=""EXAMPLE"">
                            </td>
                            <td>
                                Repository:
                            </td>
                            <td>
                                <input type=""text"" id=""repo"" name=""repo"" value=""EXAMPLE"">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Stability Rating:
 ");
                WriteLiteral(@"                           </td>
                            <td>
                                <input type=""text"" id=""stable"" name=""stable"" value=""EXAMPLE"">
                            </td>
                            <td>
                                Sensitive Data:
                            </td>
                            <td>
                                <input type=""text"" id=""sensitive"" name=""sensitive"" value=""EXAMPLE"">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Future Dev. Rating:
                            </td>
                            <td>
                                <input type=""text"" id=""future"" name=""future"" value=""EXAMPLE"">
                            </td>
                            <td>
                                Criticality:
                            </td>
                            <td>
                                <input typ");
                WriteLiteral(@"e=""text"" id=""crit"" name=""crit"" value=""EXAMPLE"">
                            </td>
                        </tr>
                    </tbody>
                </table>
                <div class=""row"">
                    <div class=""col-md-3"">
                    </div>
                    <div class=""col-md-3"">
                    </div>
                    <div class=""col-md-3"">
                    </div>
                    <div class=""col-md-3"">

                        <button type=""button"" class=""btn btn-success btn-block btn-sm"">
                            Save
                        </button>
                    </div>
                </div>
            </div>
        </div>
        <div><br /></div>
        <div class=""row"">
            <div class=""col-md-12"">
                <table class=""table table-sm table-hover table-bordered"" id=""myNotes"">
                    <thead>
                        <tr>
                            <th colspan=""2"">
                          ");
                WriteLiteral(@"      Notes
                            </th>
                        </tr>
                        <tr>
                            <th>
                                Username
                            </th>
                            <th>
                                Note Text
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>
                <div class=""row"">
                    <div class=""col-md-3"">
                    </div>
                    <div class=""col-md-3"">
                    </div>
                    <div class=""col-md-3"">

                        <button type=""button"" class=""btn btn-block btn-sm btn-info"" onclick=""notes()"">
                            Add
                        </button>
                    </div>
                    <div class=""col-md-3"">

                        <button type=""button"" class=""btn btn-success btn-sm");
                WriteLiteral(" btn-block\">\r\n                            Save\r\n                        </button>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<script>
    function applicationType() {
        var table = document.getElementById(""myApplicationType"");
        var length = table.rows.length;
        var row = table.insertRow(length);
        var cell = row.insertCell(0);

        var input = document.createElement('input');
        input.type = 'text';

        cell.appendChild(input);
    }

    function technology() {
        var table = document.getElementById(""myTechnology"");
        var length = table.rows.length;
        var row = table.insertRow(length);
        var cell = row.insertCell(0);

        var input = document.createElement('input');
        input.type = 'text';

        cell.appendChild(input);
    }

    function servers() {
        var table = document.getElementById(""myServers"");
        var length = table.rows.length;
        var row = table.insertRow(length);
        var cell1 = row.insertCell(0);
        var cell2 = row.insertCell(1);

        var input1 = document.createElement('select');
  ");
            WriteLiteral(@"      var option1 = document.createElement('option');
        option1.text = ""Development"";
        input1.add(option1);
        var option2 = document.createElement('option');
        option2.text = ""QA"";
        input1.add(option2);
        var option3 = document.createElement('option');
        option3.text = ""Production"";
        input1.add(option3);      

        var input2 = document.createElement('input');
        input2.type = 'text';

        cell1.appendChild(input1);
        cell2.appendChild(input2);
    }

    function urls() {
        var table = document.getElementById(""myUrls"");
        var length = table.rows.length;
        var row = table.insertRow(length);
        var cell1 = row.insertCell(0);
        var cell2 = row.insertCell(1);

        var input1 = document.createElement('select');
        var option1 = document.createElement('option');
        option1.text = ""Development"";
        input1.add(option1);
        var option2 = document.createElement('option'");
            WriteLiteral(@");
        option2.text = ""QA"";
        input1.add(option2);
        var option3 = document.createElement('option');
        option3.text = ""Production"";
        input1.add(option3);

        var input2 = document.createElement('input');
        input2.type = 'text';

        cell1.appendChild(input1);
        cell2.appendChild(input2);
    }

    function notes() {
        var table = document.getElementById(""myNotes"");
        var length = table.rows.length;
        var row = table.insertRow(length);
        var cell1 = row.insertCell(0);
        var cell2 = row.insertCell(1);

        var input1 = document.createElement('input');
        input1.type = 'text';
        var input2 = document.createElement('input');
        input2.type = 'text';

        cell1.appendChild(input1);
        cell2.appendChild(input2);
    }

                        //document.getElementById() USE THIS TO CHANGE CERTAIN VALUES

</script>
");
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
