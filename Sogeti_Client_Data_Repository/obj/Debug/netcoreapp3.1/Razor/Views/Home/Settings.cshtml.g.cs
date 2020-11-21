#pragma checksum "C:\Users\junth\Source\Repos\Sogeti---Client-Repository-Web-App\Sogeti_Client_Data_Repository\Views\Home\Settings.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ed6615e034ad92d7b605e616bfebfb406d664b86"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Settings), @"mvc.1.0.view", @"/Views/Home/Settings.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed6615e034ad92d7b605e616bfebfb406d664b86", @"/Views/Home/Settings.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7837b78baf9c7e7c09fbd68520dfbd81b6f9c317", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Settings : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\junth\Source\Repos\Sogeti---Client-Repository-Web-App\Sogeti_Client_Data_Repository\Views\Home\Settings.cshtml"
  
    ViewData["Title"] = "Settings";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""container-fluid"">
    <div class=""row"">
        <div class=""col-md-12"">
            <div class=""row"">
                <div class=""col-md-6"">
                    <table class=""table table-bordered table-hover"">
                        <thead>
                            <tr>
                                <th colspan=""2"">
                                    Home Filters
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    Application Name
                                </td>
                                <td>
                                    <input type=""text"" id=""hAppName"" name=""hAppName"">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Department
    ");
            WriteLiteral(@"                            </td>
                                <td>
                                    <input type=""text"" id=""hDept"" name=""hDept"">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Department Manager
                                </td>
                                <td>
                                    <input type=""text"" id=""hDeptMgr"" name=""hDeptMgr"">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Primary BA
                                </td>
                                <td>
                                    <input type=""text"" id=""hBa"" name=""hBa"">
                                </td>
                            </tr>
                            <tr>
                                <td>
          ");
            WriteLiteral(@"                          Client
                                </td>
                                <td>
                                    <input type=""text"" id=""hClient"" name=""hClient"">
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <table class=""table table-bordered table-hover"">
                        <thead>
                            <tr>
                                <th colspan=""2"">
                                    User Filters
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    User First Name
                                </td>
                                <td>
                                    <input type=""text"" id=""uFirstName"" name=""uFirstName"">
                   ");
            WriteLiteral(@"             </td>
                            </tr>
                            <tr>
                                <td>
                                    User Last Name
                                </td>
                                <td>
                                    <input type=""text"" id=""uLastName"" name=""uLastName"">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Username
                                </td>
                                <td>
                                    <input type=""text"" id=""uUsername"" name=""uUsername"">
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <table class=""table table-bordered table-hover"">
                        <thead>
                            <tr>
                                <th colspan=""2");
            WriteLiteral(@""">
                                    Client Filters
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    Client Name
                                </td>
                                <td>
                                    <input type=""text"" id=""cName"" name=""cName"">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Description
                                </td>
                                <td>
                                    <input type=""text"" id=""cDesc"" name=""cDesc"">
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class=""col-m");
            WriteLiteral(@"d-6"">
                    <table class=""table table-bordered table-hover"">
                        <thead>
                            <tr>
                                <th colspan=""3"">
                                    Database Filters
                                </th>
                            </tr>
                        </thead>
                        <thead>
                            <tr>
                                <th>
                                    Type
                                </th>
                                <th>
                                    Enabled
                                </th>
                                <th>
                                    Search
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    Application Name
           ");
            WriteLiteral(@"                     </td>
                                <td>
                                    <input type=""checkbox"" id=""dAppNameCheck"" name=""dAppNameCheck"">
                                </td>
                                <td>
                                    <input type=""text"" id=""dAppName"" name=""dAppName"">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Department
                                </td>
                                <td>
                                    <input type=""checkbox"" id=""dDeptCheck"" name=""dDeptCheck"">
                                </td>
                                <td>
                                    <input type=""text"" id=""dDept"" name=""dDept"">
                                </td>
                            </tr>
                            <tr>
                                <td>
                       ");
            WriteLiteral(@"             Department Manager
                                </td>
                                <td>
                                    <input type=""checkbox"" id=""dDeptMgrCheck"" name=""dDeptMgrCheck"">
                                </td>
                                <td>
                                    <input type=""text"" id=""dDeptMgr"" name=""dDeptMgr"">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Primary BA
                                </td>
                                <td>
                                    <input type=""checkbox"" id=""dBaCheck"" name=""dBaCheck"">
                                </td>
                                <td>
                                    <input type=""text"" id=""dBa"" name=""dBa"">
                                </td>
                            </tr>
                            <tr>
                         ");
            WriteLiteral(@"       <td>
                                    Client
                                </td>
                                <td>
                                    <input type=""checkbox"" id=""dClientCheck"" name=""dClientCheck"">
                                </td>
                                <td>
                                    <input type=""text"" id=""dClient"" name=""dClient"">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Tech Contact
                                </td>
                                <td>
                                    <input type=""checkbox"" id=""dTContactCheck"" name=""dTContactCheck"">
                                </td>
                                <td>
                                    <input type=""text"" id=""dTContact"" name=""dTContact"">
                                </td>
                            </tr>
             ");
            WriteLiteral(@"               <tr>
                                <td>
                                    Application Type
                                </td>
                                <td>
                                    <input type=""checkbox"" id=""dAppTypeCheck"" name=""dAppTypeCheck"">
                                </td>
                                <td>
                                    <input type=""text"" id=""dAppType"" name=""dAppType"">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Technologies
                                </td>
                                <td>
                                    <input type=""checkbox"" id=""dTechCheck"" name=""dTechCheck"">
                                </td>
                                <td>
                                    <input type=""text"" id=""dTech"" name=""dTech"">
                                </td>
    ");
            WriteLiteral(@"                        </tr>
                            <tr>
                                <td>
                                    P. Server
                                </td>
                                <td>
                                    <input type=""checkbox"" id=""dPServerCheck"" name=""dPServerCheck"">
                                </td>
                                <td>
                                    <input type=""text"" id=""dPServer"" name=""dPServer"">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    P. URL
                                </td>
                                <td>
                                    <input type=""checkbox"" id=""dPUrlCheck"" name=""dPUrlCheck"">
                                </td>
                                <td>
                                    <input type=""text"" id=""dPUrl"" name=""dPUrl"">
            ");
            WriteLiteral(@"                    </td>
                            </tr>
                            <tr>
                                <td>
                                    QA Server
                                </td>
                                <td>
                                    <input type=""checkbox"" id=""dQAServerCheck"" name=""dQAServerCheck"">
                                </td>
                                <td>
                                    <input type=""text"" id=""dQAServer"" name=""dQAServer"">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    QA URL
                                </td>
                                <td>
                                    <input type=""checkbox"" id=""dQAUrlCheck"" name=""dQAUrlCheck"">
                                </td>
                                <td>
                                    <input type=""text"" i");
            WriteLiteral(@"d=""dQAUrl"" name=""dQAUrl"">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Dev. Server
                                </td>
                                <td>
                                    <input type=""checkbox"" id=""dDevServerCheck"" name=""dDevServerCheck"">
                                </td>
                                <td>
                                    <input type=""text"" id=""dDevServer"" name=""dDevServer"">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Dev. URL
                                </td>
                                <td>
                                    <input type=""checkbox"" id=""dDevUrlCheck"" name=""dDevUrlCheck"">
                                </td>
                                <td>
       ");
            WriteLiteral(@"                             <input type=""text"" id=""dDevUrl"" name=""dDevUrl"">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Code Source
                                </td>
                                <td>
                                    <input type=""checkbox"" id=""dCodeSourceCheck"" name=""dCodeSourceCheck"">
                                </td>
                                <td>
                                    <input type=""text"" id=""dCodeSource"" name=""dCodeSource"">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Repository
                                </td>
                                <td>
                                    <input type=""checkbox"" id=""dRepoCheck"" name=""dRepoCheck"">
                               ");
            WriteLiteral(@" </td>
                                <td>
                                    <input type=""text"" id=""dRepo"" name=""dRepo"">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Stability
                                </td>
                                <td>
                                    <input type=""checkbox"" id=""dStabCheck"" name=""dStabCheck"">
                                </td>
                                <td>
                                    <input type=""text"" id=""dStab"" name=""dStab"">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Future Dev.
                                </td>
                                <td>
                                    <input type=""checkbox"" id=""dFutureCheck"" name=""dFutureCheck"">
   ");
            WriteLiteral(@"                             </td>
                                <td>
                                    <input type=""text"" id=""dFuture"" name=""dFuture"">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Sensitivity
                                </td>
                                <td>
                                    <input type=""checkbox"" id=""dSenCheck"" name=""dSenCheck"">
                                </td>
                                <td>
                                    <input type=""text"" id=""dSen"" name=""dSen"">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Criticality
                                </td>
                                <td>
                                    <input type=""checkbox"" id=""dCritChec");
            WriteLiteral(@"k"" name=""dCritCheck"">
                                </td>
                                <td>
                                    <input type=""text"" id=""dCrit"" name=""dCrit"">
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <div class=""row"">
                <div class=""col-md-3"">
                </div>
                <div class=""col-md-3"">

                    <button type=""button"" class=""btn btn-success btn-block"">
                        Save
                    </button>
                </div>
                <div class=""col-md-3"">

                    <button type=""button"" class=""btn btn-block btn-outline-secondary"">
                        Change Password
                    </button>
                </div>
                <div class=""col-md-3"">
                </div>
            </div>
        </div>
    </div>
</div>");
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
