#pragma checksum "D:\ASPNET Core\RSB_Ofish_System\rsb_ofish\Views\Shared\_oprationJsView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fe7aec6a8f1c3382c53320a4173c7d3feea56dd1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__oprationJsView), @"mvc.1.0.view", @"/Views/Shared/_oprationJsView.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fe7aec6a8f1c3382c53320a4173c7d3feea56dd1", @"/Views/Shared/_oprationJsView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3673d9081be9c8578d62ba0ebe73fc541c4ef889", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__oprationJsView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<script>
    function showCard(id) {

        $.ajax({
            url: '/Ofish/showCard/',
            data: { Id: id },
            type: 'get',
            success: function (result) {
                
                $('#myModalBody').html(result);
                $('#myModal').modal(""show"");
            },
            error: function (err) {

            }


        });
    }
    function showVehicle(id) {

        $.ajax({
            url: '/Ofish/showVehicle/',
            data: { Id: id },
            type: 'get',
            success: function (result) {

                $('#myModalBody').html(result);
                $('#myModal').modal(""show"");
            },
            error: function (err) {

            }


        });
    }
</script>

<script>
    function Exit(id) {

        $.ajax({
            url: '/Ofish/Exit/',
            data: { Id: id },
            type: 'get',
            success: function (result) {

                if (result.isSucc");
            WriteLiteral(@"ess == true) {
                    swal.fire(
                        result.title,
                        result.message,
                        result.status
                    ).then(function (isConfirm) {
                        window.location.replace(""/"")
                    });
                } else if (result.isSuccess == false) {
                    swal.fire(result.title,
                        result.message,
                        result.status);
                }
            },
            error: function (err) {

            }

        });
    }
</script>");
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
