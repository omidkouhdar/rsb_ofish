#pragma checksum "D:\ASPNET Core\RSB_Ofish_System\rsb_ofish\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cd494635fe530a3dc1eff49e27292a405a5741a1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd494635fe530a3dc1eff49e27292a405a5741a1", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3673d9081be9c8578d62ba0ebe73fc541c4ef889", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n    <div  id=\"dataList\">\r\n        \r\n    </div>\r\n\r\n\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@" 
     
    <script>       

        function getData(pageid) {
            var url = '/home/getTodayData';
            data = { pageId: pageid };
            $.ajax({
                url: url,
                data: data,
                type: 'get',
                success: function (result) {
                    $('#dataList').html(result);
                },
                error: function (err) {

                }

            });
        }
    </script>
<script>
    $(function () {
        getData(1);
    });
</script>
<script >
    function showCard(id) {
        
        $.ajax({
            url: '/Ofish/showCard/',
            data: { Id: id },
            type: 'get',
            success: function (result) {
               //$('#myModalLabel').html('تصویر کارت ملی');
                $('#myModalBody').html(result);
                $('#myModal').modal(""show"");
            },
            error: function (err) {

            }


        });
    }
</script>
");
                WriteLiteral("\n");
            }
            );
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
