#pragma checksum "C:\Users\root\Desktop\c_sharp\Wedding_Planner\Views\Home\ShowWedding.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9db901a89cea6b586a77f5e5ae82fb03ebf7ebe5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ShowWedding), @"mvc.1.0.view", @"/Views/Home/ShowWedding.cshtml")]
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
#line 1 "C:\Users\root\Desktop\c_sharp\Wedding_Planner\Views\_ViewImports.cshtml"
using Wedding_Planner;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\root\Desktop\c_sharp\Wedding_Planner\Views\_ViewImports.cshtml"
using Wedding_Planner.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9db901a89cea6b586a77f5e5ae82fb03ebf7ebe5", @"/Views/Home/ShowWedding.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"84b0732bfebbac067a62d1314c0d18406fc96ec4", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ShowWedding : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Wedding>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1><a href=\"/dashboard\">Dashboard</a></h1>\r\n<br>\r\n<h2>-*-*-*-*-*-*-*-*-*-*-*-*-*-*</h2>\r\n<br>\r\n<h2>*-*-*-*-*-*-*-*-*-*-*-*-*-*-</h2>\r\n<br>\r\n\r\n");
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 10 "C:\Users\root\Desktop\c_sharp\Wedding_Planner\Views\Home\ShowWedding.cshtml"
Write(ViewBag.ShownWedding.Wedder_1);

#line default
#line hidden
#nullable disable
            WriteLiteral(" and ");
#nullable restore
#line 10 "C:\Users\root\Desktop\c_sharp\Wedding_Planner\Views\Home\ShowWedding.cshtml"
                                  Write(ViewBag.ShownWedding.Wedder_2);

#line default
#line hidden
#nullable disable
            WriteLiteral("\'s Wedding</h1>\r\n\r\n<h2>Date: ");
#nullable restore
#line 12 "C:\Users\root\Desktop\c_sharp\Wedding_Planner\Views\Home\ShowWedding.cshtml"
     Write(ViewBag.ShownWedding.WeddingDate.ToString("d"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<h2>Address: ");
#nullable restore
#line 13 "C:\Users\root\Desktop\c_sharp\Wedding_Planner\Views\Home\ShowWedding.cshtml"
        Write(ViewBag.ShownWedding.Wedding_Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<h3>Guests: </h3>\r\n");
#nullable restore
#line 15 "C:\Users\root\Desktop\c_sharp\Wedding_Planner\Views\Home\ShowWedding.cshtml"
 foreach (var item in @ViewBag.ShownWedding.Association)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h4>");
#nullable restore
#line 17 "C:\Users\root\Desktop\c_sharp\Wedding_Planner\Views\Home\ShowWedding.cshtml"
   Write(item.User.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 17 "C:\Users\root\Desktop\c_sharp\Wedding_Planner\Views\Home\ShowWedding.cshtml"
                        Write(item.User.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n");
#nullable restore
#line 18 "C:\Users\root\Desktop\c_sharp\Wedding_Planner\Views\Home\ShowWedding.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Wedding> Html { get; private set; }
    }
}
#pragma warning restore 1591