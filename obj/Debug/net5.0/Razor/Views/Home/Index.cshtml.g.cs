#pragma checksum "/Applications/AMPPS/www/TestHendrikNet/Views/Home/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0861e32044b5032abc00770b4d5ae286dc8b68f2"
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
#line 1 "/Applications/AMPPS/www/TestHendrikNet/Views/_ViewImports.cshtml"
using TestHendrikNet;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Applications/AMPPS/www/TestHendrikNet/Views/_ViewImports.cshtml"
using TestHendrikNet.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0861e32044b5032abc00770b4d5ae286dc8b68f2", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"abac53a54300d3b61d44a4e62527676273dc722c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "/Applications/AMPPS/www/TestHendrikNet/Views/Home/Index.cshtml"
  
    ViewData["Title"] = "Book Library";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""container my-5"">
    <h3 class=""mt-5"">📊 Visualisasi</h3>
    <div class=""row"">
        <div class=""col-md-4"">
            <h6>Bar Chart: Buku per Tahun</h6>
            <svg id=""barChart"" preserveAspectRatio=""xMidYMid meet""></svg>
        </div>
        <div class=""col-md-4"">
            <h6>Pie Chart: Top Author</h6>
            <svg id=""pieChart"" preserveAspectRatio=""xMidYMid meet""></svg>
        </div>
        <div class=""col-md-4"">
            <h6>Line Chart: Tren Tahun</h6>
            <svg id=""lineChart"" preserveAspectRatio=""xMidYMid meet""></svg>
        </div>
    </div>

    <h2>📚 Daftar Buku Want to Read</h2>
    <table class=""display nowrap"" style=""width:100%"" id=""bookTable"">
        <thead>
            <tr>
                <th>Judul</th>
                <th>Author</th>
                <th>Tahun</th>
            </tr>
        </thead>
        <tbody></tbody>
    </table>
</div>
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
