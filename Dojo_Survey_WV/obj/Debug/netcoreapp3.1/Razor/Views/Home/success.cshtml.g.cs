#pragma checksum "C:\Users\root\Desktop\c_sharp\Dojo_Survey_WV\Views\Home\success.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d6351b48d601948d5abbf5067bc67bb37b98ddcb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_success), @"mvc.1.0.view", @"/Views/Home/success.cshtml")]
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
#line 1 "C:\Users\root\Desktop\c_sharp\Dojo_Survey_WV\Views\_ViewImports.cshtml"
using Dojo_Survey_WV;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\root\Desktop\c_sharp\Dojo_Survey_WV\Views\_ViewImports.cshtml"
using Dojo_Survey_WV.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d6351b48d601948d5abbf5067bc67bb37b98ddcb", @"/Views/Home/success.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"820aa6448ea619e2762106fc3b36bc0b200b08ce", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_success : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<User>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h1>Your Name: ");
#nullable restore
#line 3 "C:\Users\root\Desktop\c_sharp\Dojo_Survey_WV\Views\Home\success.cshtml"
          Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n<h2>Your Location: ");
#nullable restore
#line 4 "C:\Users\root\Desktop\c_sharp\Dojo_Survey_WV\Views\Home\success.cshtml"
              Write(Model.Location);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<h2>your fav language: ");
#nullable restore
#line 5 "C:\Users\root\Desktop\c_sharp\Dojo_Survey_WV\Views\Home\success.cshtml"
                  Write(Model.Language);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<h2>your comment: ");
#nullable restore
#line 6 "C:\Users\root\Desktop\c_sharp\Dojo_Survey_WV\Views\Home\success.cshtml"
             Write(Model.Comment);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<User> Html { get; private set; }
    }
}
#pragma warning restore 1591
