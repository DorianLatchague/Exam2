#pragma checksum "/Users/dorianlatchague/Documents/c#_stack/c#_entity/Exam2/Views/Home/Activity.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1272fe700d18ee8f5cf4b07f7b217048441e0510"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Activity), @"mvc.1.0.view", @"/Views/Home/Activity.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Activity.cshtml", typeof(AspNetCore.Views_Home_Activity))]
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
#line 1 "/Users/dorianlatchague/Documents/c#_stack/c#_entity/Exam2/Views/_ViewImports.cshtml"
using Exam2;

#line default
#line hidden
#line 2 "/Users/dorianlatchague/Documents/c#_stack/c#_entity/Exam2/Views/_ViewImports.cshtml"
using Exam2.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1272fe700d18ee8f5cf4b07f7b217048441e0510", @"/Views/Home/Activity.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e098b516698c4c5922c1cc0f0dd392a04227191", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Activity : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Activities>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "/Users/dorianlatchague/Documents/c#_stack/c#_entity/Exam2/Views/Home/Activity.cshtml"
  
    ViewData["Title"] = "Activity";

#line default
#line hidden
            BeginContext(41, 368, true);
            WriteLiteral(@"<nav class=""navbar navbar-expand-lg navbar-light bg-light"">
    <a class=""navbar-brand"">Dojo Activity Center</a>
    <ul class=""navbar-nav mr-auto"">
        <li class=""nav-item active"">
            <a class=""nav-link"" href=""/home"">Home</a>                        
        </li>
    </ul>
    <a style=""color: black;"" class=""nav-link"" href=""/logout"">Log Off</a>
</nav>
");
            EndContext();
            BeginContext(427, 14, true);
            WriteLiteral("<div>\n    <h1>");
            EndContext();
            BeginContext(442, 11, false);
#line 15 "/Users/dorianlatchague/Documents/c#_stack/c#_entity/Exam2/Views/Home/Activity.cshtml"
   Write(Model.Title);

#line default
#line hidden
            EndContext();
            BeginContext(453, 6, true);
            WriteLiteral("</h1>\n");
            EndContext();
#line 16 "/Users/dorianlatchague/Documents/c#_stack/c#_entity/Exam2/Views/Home/Activity.cshtml"
     if(@Model.Creator.UsersId == @ViewBag.User.UsersId)
    {

#line default
#line hidden
            BeginContext(522, 67, true);
            WriteLiteral("        <td><a style=\"float: right;\" class=\"btn btn-outline-danger\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 589, "\"", 628, 2);
            WriteAttributeValue("", 596, "/home/delete/", 596, 13, true);
#line 18 "/Users/dorianlatchague/Documents/c#_stack/c#_entity/Exam2/Views/Home/Activity.cshtml"
WriteAttributeValue("", 609, Model.ActivitiesId, 609, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(629, 17, true);
            WriteLiteral(">Delete</a></td>\n");
            EndContext();
#line 19 "/Users/dorianlatchague/Documents/c#_stack/c#_entity/Exam2/Views/Home/Activity.cshtml"
    }
    else
    {
        bool isTrue = false;
        

#line default
#line hidden
#line 23 "/Users/dorianlatchague/Documents/c#_stack/c#_entity/Exam2/Views/Home/Activity.cshtml"
         foreach(Participants participant in @Model.Participants)
        {
            

#line default
#line hidden
#line 25 "/Users/dorianlatchague/Documents/c#_stack/c#_entity/Exam2/Views/Home/Activity.cshtml"
             if(@participant.UsersId == @ViewBag.User.UsersId)
            {
                isTrue = true;
            }

#line default
#line hidden
#line 28 "/Users/dorianlatchague/Documents/c#_stack/c#_entity/Exam2/Views/Home/Activity.cshtml"
             
        }

#line default
#line hidden
#line 30 "/Users/dorianlatchague/Documents/c#_stack/c#_entity/Exam2/Views/Home/Activity.cshtml"
         if(isTrue == false)
        {

#line default
#line hidden
            BeginContext(943, 72, true);
            WriteLiteral("            <td><a style=\"float: right;\" class=\"btn btn-outline-primary\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1015, "\"", 1061, 2);
            WriteAttributeValue("", 1022, "/home/participating/", 1022, 20, true);
#line 32 "/Users/dorianlatchague/Documents/c#_stack/c#_entity/Exam2/Views/Home/Activity.cshtml"
WriteAttributeValue("", 1042, Model.ActivitiesId, 1042, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1062, 15, true);
            WriteLiteral(">Join</a></td>\n");
            EndContext();
#line 33 "/Users/dorianlatchague/Documents/c#_stack/c#_entity/Exam2/Views/Home/Activity.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(1110, 71, true);
            WriteLiteral("            <td><a style=\"float: right;\" class=\"btn btn-outline-danger\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1181, "\"", 1230, 2);
            WriteAttributeValue("", 1188, "/home/notparticipating/", 1188, 23, true);
#line 36 "/Users/dorianlatchague/Documents/c#_stack/c#_entity/Exam2/Views/Home/Activity.cshtml"
WriteAttributeValue("", 1211, Model.ActivitiesId, 1211, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1231, 16, true);
            WriteLiteral(">Leave</a></td>\n");
            EndContext();
#line 37 "/Users/dorianlatchague/Documents/c#_stack/c#_entity/Exam2/Views/Home/Activity.cshtml"
        }

#line default
#line hidden
#line 37 "/Users/dorianlatchague/Documents/c#_stack/c#_entity/Exam2/Views/Home/Activity.cshtml"
         
    }

#line default
#line hidden
            BeginContext(1263, 30, true);
            WriteLiteral("</div>\n<h3>Event Coordinator: ");
            EndContext();
            BeginContext(1294, 23, false);
#line 40 "/Users/dorianlatchague/Documents/c#_stack/c#_entity/Exam2/Views/Home/Activity.cshtml"
                  Write(Model.Creator.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(1317, 31, true);
            WriteLiteral("</h3>\n<h3>Description:</h3>\n<p>");
            EndContext();
            BeginContext(1349, 17, false);
#line 42 "/Users/dorianlatchague/Documents/c#_stack/c#_entity/Exam2/Views/Home/Activity.cshtml"
Write(Model.Description);

#line default
#line hidden
            EndContext();
            BeginContext(1366, 33, true);
            WriteLiteral("</p>\n<h3>Participants:</h3>\n<ul>\n");
            EndContext();
#line 45 "/Users/dorianlatchague/Documents/c#_stack/c#_entity/Exam2/Views/Home/Activity.cshtml"
     foreach(Participants participant in @Model.Participants)
    {

#line default
#line hidden
            BeginContext(1467, 12, true);
            WriteLiteral("        <li>");
            EndContext();
            BeginContext(1480, 26, false);
#line 47 "/Users/dorianlatchague/Documents/c#_stack/c#_entity/Exam2/Views/Home/Activity.cshtml"
       Write(participant.User.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(1506, 6, true);
            WriteLiteral("</li>\n");
            EndContext();
#line 48 "/Users/dorianlatchague/Documents/c#_stack/c#_entity/Exam2/Views/Home/Activity.cshtml"
    }

#line default
#line hidden
            BeginContext(1518, 5, true);
            WriteLiteral("</ul>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Activities> Html { get; private set; }
    }
}
#pragma warning restore 1591
