#pragma checksum "C:\Users\Natalija\Desktop\Projekat2\Pages\SkupParkinzi.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bcc234580b9db8e80ea5eea317f627c7f5f65b53"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_SkupParkinzi), @"mvc.1.0.razor-page", @"/Pages/SkupParkinzi.cshtml")]
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
#line 2 "C:\Users\Natalija\Desktop\Projekat2\Pages\SkupParkinzi.cshtml"
using Projekat2.Pages;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bcc234580b9db8e80ea5eea317f627c7f5f65b53", @"/Pages/SkupParkinzi.cshtml")]
    public class Pages_SkupParkinzi : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\Natalija\Desktop\Projekat2\Pages\SkupParkinzi.cshtml"
  
    ViewData["Title"]="Skup Parkinzi";
    Layout="_Layout";

#line default
#line hidden
#nullable disable
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n    <link rel=\"stylesheet\" href=\"Styles/Style.css\">\r\n");
            }
            );
            WriteLiteral("<a class=\"novi\" href=\"CreateParkinzi\">Create new</a>\r\n<table>\r\n    <tr>\r\n        <th>Parkinzi</th>\r\n        <th>Broj</th>\r\n        <th>N</th>\r\n        <th>M</th>\r\n        <th>Edit</th>\r\n        <th>Delete</th>\r\n    </tr>\r\n");
#nullable restore
#line 21 "C:\Users\Natalija\Desktop\Projekat2\Pages\SkupParkinzi.cshtml"
     foreach (var v in Model.Skup)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 24 "C:\Users\Natalija\Desktop\Projekat2\Pages\SkupParkinzi.cshtml"
           Write(v.Naziv);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 25 "C:\Users\Natalija\Desktop\Projekat2\Pages\SkupParkinzi.cshtml"
           Write(v.Num);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 26 "C:\Users\Natalija\Desktop\Projekat2\Pages\SkupParkinzi.cshtml"
           Write(v.N);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 27 "C:\Users\Natalija\Desktop\Projekat2\Pages\SkupParkinzi.cshtml"
           Write(v.M);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td><a");
            BeginWriteAttribute("href", " href=\"", 612, "\"", 642, 2);
            WriteAttributeValue("", 619, "UpdateParkinzi?id=", 619, 18, true);
#nullable restore
#line 28 "C:\Users\Natalija\Desktop\Projekat2\Pages\SkupParkinzi.cshtml"
WriteAttributeValue("", 637, v.ID, 637, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Update</a></td>\r\n            <td><a");
            BeginWriteAttribute("href", " href=\"", 679, "\"", 709, 2);
            WriteAttributeValue("", 686, "DeleteParkinzi?id=", 686, 18, true);
#nullable restore
#line 29 "C:\Users\Natalija\Desktop\Projekat2\Pages\SkupParkinzi.cshtml"
WriteAttributeValue("", 704, v.ID, 704, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete</a></td>\r\n        </tr>\r\n");
#nullable restore
#line 31 "C:\Users\Natalija\Desktop\Projekat2\Pages\SkupParkinzi.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SkupParkinziModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<SkupParkinziModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<SkupParkinziModel>)PageContext?.ViewData;
        public SkupParkinziModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591