#pragma checksum "D:\ASPNET Core\RSB_Ofish_System\RSB_Ofish_System\Views\Shared\_pagination.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bbfbfa534c17ac86494949a4f2fea327cbc49b89"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__pagination), @"mvc.1.0.view", @"/Views/Shared/_pagination.cshtml")]
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
#line 1 "D:\ASPNET Core\RSB_Ofish_System\RSB_Ofish_System\Views\_ViewImports.cshtml"
using RSB_Ofish_System;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\ASPNET Core\RSB_Ofish_System\RSB_Ofish_System\Views\_ViewImports.cshtml"
using RSB_Ofish_System.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bbfbfa534c17ac86494949a4f2fea327cbc49b89", @"/Views/Shared/_pagination.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3673d9081be9c8578d62ba0ebe73fc541c4ef889", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__pagination : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n    <div class=\"row\">\r\n        <div class=\"col-md-3\">\r\n            <h4 style=\"font-family:\'zar\'\">\r\n                تعداد کل تردد ها : ");
#nullable restore
#line 5 "D:\ASPNET Core\RSB_Ofish_System\RSB_Ofish_System\Views\Shared\_pagination.cshtml"
                              Write(Model.TotalRows);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </h4>\r\n\r\n        </div>\r\n    </div>\r\n    <ul class=\"pagination\">\r\n");
#nullable restore
#line 11 "D:\ASPNET Core\RSB_Ofish_System\RSB_Ofish_System\Views\Shared\_pagination.cshtml"
          
            int CurrentPage = (int)ViewData["currenPage"];
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\ASPNET Core\RSB_Ofish_System\RSB_Ofish_System\Views\Shared\_pagination.cshtml"
         for (int i = 1; i <= Model.PageCount; i++)
        {
            if (CurrentPage == i)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"active\"><a href=\"#\">");
#nullable restore
#line 18 "D:\ASPNET Core\RSB_Ofish_System\RSB_Ofish_System\Views\Shared\_pagination.cshtml"
                                          Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 19 "D:\ASPNET Core\RSB_Ofish_System\RSB_Ofish_System\Views\Shared\_pagination.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li><a href=\"#\"");
            BeginWriteAttribute("onclick", " onclick=\"", 568, "\"", 591, 3);
            WriteAttributeValue("", 578, "getData(\'", 578, 9, true);
#nullable restore
#line 22 "D:\ASPNET Core\RSB_Ofish_System\RSB_Ofish_System\Views\Shared\_pagination.cshtml"
WriteAttributeValue("", 587, i, 587, 2, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 589, "\')", 589, 2, true);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 22 "D:\ASPNET Core\RSB_Ofish_System\RSB_Ofish_System\Views\Shared\_pagination.cshtml"
                                                   Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 23 "D:\ASPNET Core\RSB_Ofish_System\RSB_Ofish_System\Views\Shared\_pagination.cshtml"
            }
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </ul>\r\n\r\n");
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