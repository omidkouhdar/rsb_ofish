#pragma checksum "D:\ASPNET Core\RSB_Ofish_System\rsb_ofish\Views\Shared\_ofishDataView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f78e92b69178be0acf3aff2bb68bd8e48e6c358b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ofishDataView), @"mvc.1.0.view", @"/Views/Shared/_ofishDataView.cshtml")]
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
#line 1 "D:\ASPNET Core\RSB_Ofish_System\rsb_ofish\Views\_ViewImports.cshtml"
using RSB_Ofish_System;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\ASPNET Core\RSB_Ofish_System\rsb_ofish\Views\_ViewImports.cshtml"
using RSB_Ofish_System.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f78e92b69178be0acf3aff2bb68bd8e48e6c358b", @"/Views/Shared/_ofishDataView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3673d9081be9c8578d62ba0ebe73fc541c4ef889", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ofishDataView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RSB_Ofish_System.Models.ViewModels.ListResultVM<RSB_Ofish_System.Models.ViewModels.OfishListVM>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_pagination", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\ASPNET Core\RSB_Ofish_System\rsb_ofish\Views\Shared\_ofishDataView.cshtml"
  
    int counter = 1;

#line default
#line hidden
#nullable disable
            WriteLiteral("<h2 style=\"padding-right:12px;\">");
#nullable restore
#line 5 "D:\ASPNET Core\RSB_Ofish_System\rsb_ofish\Views\Shared\_ofishDataView.cshtml"
                           Write(Model.ListTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>



<table class=""table"">
    <thead>
        <tr>
            <th>
                #
            </th>
            <th>
                ???? ??????
            </th>
            <th>
                ?????? ?? ?????? ????????????????
            </th>
            <th>
                ?????????? / ????????
            </th>
            <th>
                ???????????? ??????????
            </th>
            <th>
                ?????????? ????????<span><i class=""icon-calendar""></i></span>
            </th>
            <th>
                ?????????? ????????<span><i class=""icon-calendar""></i></span>
            </th>

            <th></th>
        </tr>
    </thead>
    <tbody id=""dataList"">
");
#nullable restore
#line 38 "D:\ASPNET Core\RSB_Ofish_System\rsb_ofish\Views\Shared\_ofishDataView.cshtml"
         foreach (var item in Model.DataList)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 42 "D:\ASPNET Core\RSB_Ofish_System\rsb_ofish\Views\Shared\_ofishDataView.cshtml"
               Write(counter);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 45 "D:\ASPNET Core\RSB_Ofish_System\rsb_ofish\Views\Shared\_ofishDataView.cshtml"
               Write(Html.DisplayFor(modelItem => item.NationCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 48 "D:\ASPNET Core\RSB_Ofish_System\rsb_ofish\Views\Shared\_ofishDataView.cshtml"
               Write(Html.DisplayFor(modelItem => item.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 51 "D:\ASPNET Core\RSB_Ofish_System\rsb_ofish\Views\Shared\_ofishDataView.cshtml"
               Write(Html.DisplayFor(modelItem => item.Office));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 54 "D:\ASPNET Core\RSB_Ofish_System\rsb_ofish\Views\Shared\_ofishDataView.cshtml"
               Write(Html.DisplayFor(modelItem => item.Staff));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 57 "D:\ASPNET Core\RSB_Ofish_System\rsb_ofish\Views\Shared\_ofishDataView.cshtml"
               Write(Html.DisplayFor(modelItem => item.OfishDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n");
#nullable restore
#line 60 "D:\ASPNET Core\RSB_Ofish_System\rsb_ofish\Views\Shared\_ofishDataView.cshtml"
                     if (item.IsExited)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 62 "D:\ASPNET Core\RSB_Ofish_System\rsb_ofish\Views\Shared\_ofishDataView.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ExitDateTime));

#line default
#line hidden
#nullable disable
#nullable restore
#line 62 "D:\ASPNET Core\RSB_Ofish_System\rsb_ofish\Views\Shared\_ofishDataView.cshtml"
                                                                        
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n                <td>\r\n                    <button");
            BeginWriteAttribute("onclick", " onclick=\"", 1822, "\"", 1852, 3);
            WriteAttributeValue("", 1832, "showCard(\'", 1832, 10, true);
#nullable restore
#line 66 "D:\ASPNET Core\RSB_Ofish_System\rsb_ofish\Views\Shared\_ofishDataView.cshtml"
WriteAttributeValue("", 1842, item.Id, 1842, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1850, "\')", 1850, 2, true);
            EndWriteAttribute();
            WriteLiteral(" type=\"button\" class=\"btn btn-default\" title=\"?????????? ???????? ??????????????\">\r\n\r\n                        <i class=\"fa fa-credit-card\"></i>\r\n\r\n                    </button>\r\n\r\n                    |\r\n");
#nullable restore
#line 73 "D:\ASPNET Core\RSB_Ofish_System\rsb_ofish\Views\Shared\_ofishDataView.cshtml"
                     if (!item.HasnotVehicle)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <button");
            BeginWriteAttribute("onclick", " onclick=\"", 2133, "\"", 2166, 3);
            WriteAttributeValue("", 2143, "showVehicle(\'", 2143, 13, true);
#nullable restore
#line 75 "D:\ASPNET Core\RSB_Ofish_System\rsb_ofish\Views\Shared\_ofishDataView.cshtml"
WriteAttributeValue("", 2156, item.Id, 2156, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2164, "\')", 2164, 2, true);
            EndWriteAttribute();
            WriteLiteral(" type=\"button\" class=\"btn btn-default\" title=\"?????????? ?????????? ??????????\">\r\n                   \r\n                    <i class=\"fa fa-automobile\"></i>\r\n\r\n                </button>\r\n");
#nullable restore
#line 80 "D:\ASPNET Core\RSB_Ofish_System\rsb_ofish\Views\Shared\_ofishDataView.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 83 "D:\ASPNET Core\RSB_Ofish_System\rsb_ofish\Views\Shared\_ofishDataView.cshtml"
                     if (!item.IsExited)
                    {


#line default
#line hidden
#nullable disable
            WriteLiteral("                        <button");
            BeginWriteAttribute("onclick", " onclick=\"", 2463, "\"", 2489, 3);
            WriteAttributeValue("", 2473, "Exit(\'", 2473, 6, true);
#nullable restore
#line 86 "D:\ASPNET Core\RSB_Ofish_System\rsb_ofish\Views\Shared\_ofishDataView.cshtml"
WriteAttributeValue("", 2479, item.Id, 2479, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2487, "\')", 2487, 2, true);
            EndWriteAttribute();
            WriteLiteral(" type=\"button\" class=\"btn btn-warning\" title=\"?????? ????????\">\r\n\r\n                            <i class=\"fa fa-sign-out\"></i>\r\n\r\n                        </button>\r\n");
#nullable restore
#line 91 "D:\ASPNET Core\RSB_Ofish_System\rsb_ofish\Views\Shared\_ofishDataView.cshtml"

                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n\r\n            </tr>\r\n");
#nullable restore
#line 98 "D:\ASPNET Core\RSB_Ofish_System\rsb_ofish\Views\Shared\_ofishDataView.cshtml"
            counter += 1;
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    \r\n\r\n");
            }
            );
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f78e92b69178be0acf3aff2bb68bd8e48e6c358b11268", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RSB_Ofish_System.Models.ViewModels.ListResultVM<RSB_Ofish_System.Models.ViewModels.OfishListVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
