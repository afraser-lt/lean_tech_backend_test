#pragma checksum "C:\Users\Andrew\Desktop\Desk\Lean Tech Dev Test\repos\lean_tech_backend_test\lean_tech_backend_test\Demo\Views\UploadToDrive\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "89e1ba9fb0097eb6b7d489171adae0072a87ae95"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_UploadToDrive_Index), @"mvc.1.0.view", @"/Views/UploadToDrive/Index.cshtml")]
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
#line 1 "C:\Users\Andrew\Desktop\Desk\Lean Tech Dev Test\repos\lean_tech_backend_test\lean_tech_backend_test\Demo\Views\_ViewImports.cshtml"
using Demo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Andrew\Desktop\Desk\Lean Tech Dev Test\repos\lean_tech_backend_test\lean_tech_backend_test\Demo\Views\_ViewImports.cshtml"
using Demo.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"89e1ba9fb0097eb6b7d489171adae0072a87ae95", @"/Views/UploadToDrive/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e18407c5b9dabc62761fc6cdd8f67817f22bc556", @"/Views/_ViewImports.cshtml")]
    public class Views_UploadToDrive_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Demo.Models.ImportExcel>
    {
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "C:\Users\Andrew\Desktop\Desk\Lean Tech Dev Test\repos\lean_tech_backend_test\lean_tech_backend_test\Demo\Views\UploadToDrive\Index.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "89e1ba9fb0097eb6b7d489171adae0072a87ae953725", async() => {
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <title>How to Import Excel File into Database in ASP.NET Core 2.0 </title>\r\n");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "89e1ba9fb0097eb6b7d489171adae0072a87ae954838", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 16 "C:\Users\Andrew\Desktop\Desk\Lean Tech Dev Test\repos\lean_tech_backend_test\lean_tech_backend_test\Demo\Views\UploadToDrive\Index.cshtml"
     using (Html.BeginForm("Upload", "UploadToDrive", FormMethod.Post, new { enctype = "multipart/form-data" }))
    {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"<table>
            <tr>
                <td>File Upload:</td>
                <td>
                    <input type=""file"" id=""File_Upload"" name=""File""/>
                    <br />
                </td>
            </tr>
            <tr>

                <td>File Name:</td>
                <td>
                    ");
#nullable restore
#line 29 "C:\Users\Andrew\Desktop\Desk\Lean Tech Dev Test\repos\lean_tech_backend_test\lean_tech_backend_test\Demo\Views\UploadToDrive\Index.cshtml"
               Write(Html.EditorFor(model => model.Name, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    ");
#nullable restore
#line 30 "C:\Users\Andrew\Desktop\Desk\Lean Tech Dev Test\repos\lean_tech_backend_test\lean_tech_backend_test\Demo\Views\UploadToDrive\Index.cshtml"
               Write(Html.ValidationMessageFor(model => model.Name, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </td>\r\n            </tr>\r\n            <tr>\r\n                <td></td>\r\n                <td>\r\n                    <input type=\"submit\" value=\"Upload\" class=\"btn-default\" />\r\n                </td>\r\n            </tr>\r\n        </table>\r\n");
#nullable restore
#line 40 "C:\Users\Andrew\Desktop\Desk\Lean Tech Dev Test\repos\lean_tech_backend_test\lean_tech_backend_test\Demo\Views\UploadToDrive\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
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
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Demo.Models.ImportExcel> Html { get; private set; }
    }
}
#pragma warning restore 1591