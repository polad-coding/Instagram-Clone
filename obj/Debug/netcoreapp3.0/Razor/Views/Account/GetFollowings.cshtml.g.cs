#pragma checksum "C:\Users\Polad\source\repos\InstagramClone\Views\Account\GetFollowings.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "403913fbff49adad634a9c894d962661da4bc770"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_GetFollowings), @"mvc.1.0.view", @"/Views/Account/GetFollowings.cshtml")]
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
#line 1 "C:\Users\Polad\source\repos\InstagramClone\Views\_ViewImports.cshtml"
using InstagramClone;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Polad\source\repos\InstagramClone\Views\_ViewImports.cshtml"
using InstagramClone.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Polad\source\repos\InstagramClone\Views\_ViewImports.cshtml"
using InstagramClone.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Polad\source\repos\InstagramClone\Views\_ViewImports.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"403913fbff49adad634a9c894d962661da4bc770", @"/Views/Account/GetFollowings.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bcbc1c3ac2cf3f6a98a750ac1641944d9fa8ecce", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_GetFollowings : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<UserViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Pics/standartPicture.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("position:absolute; width:100%; height:100%; border-radius:50%; margin-left:10px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("grid-row-start:1;grid-row-end:3;grid-column-start:1;grid-column-end:2;position:relative;width:100%;padding-bottom:100%;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Account", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UserAccount", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("grid-row-start:1;grid-row-end:2;grid-column-start:2;grid-column-end:3;margin-left:10px;font-weight:bold;text-decoration:none;color:black;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Polad\source\repos\InstagramClone\Views\Account\GetFollowings.cshtml"
 foreach (UserViewModel user in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"following-user\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "403913fbff49adad634a9c894d962661da4bc7706241", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\Polad\source\repos\InstagramClone\Views\Account\GetFollowings.cshtml"
             if (user.Profile_Picture_URI != null)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <img");
                BeginWriteAttribute("src", " src=\"", 416, "\"", 496, 2);
                WriteAttributeValue("", 422, "data:image/jpeg;base64,", 422, 23, true);
#nullable restore
#line 9 "C:\Users\Polad\source\repos\InstagramClone\Views\Account\GetFollowings.cshtml"
WriteAttributeValue("", 445, Convert.ToBase64String(user.Profile_Picture_URI), 445, 51, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" style=\"position:absolute; width:100%; height:100%; border-radius:50%; margin-left:10px;\" />\r\n");
#nullable restore
#line 10 "C:\Users\Polad\source\repos\InstagramClone\Views\Account\GetFollowings.cshtml"

            }
            else
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "403913fbff49adad634a9c894d962661da4bc7707626", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 15 "C:\Users\Polad\source\repos\InstagramClone\Views\Account\GetFollowings.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 6 "C:\Users\Polad\source\repos\InstagramClone\Views\Account\GetFollowings.cshtml"
                                                                                                                                                                                               WriteLiteral(user.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "403913fbff49adad634a9c894d962661da4bc77011354", async() => {
#nullable restore
#line 17 "C:\Users\Polad\source\repos\InstagramClone\Views\Account\GetFollowings.cshtml"
                                                                                                                                                                                                                                  Write(user.Username);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 17 "C:\Users\Polad\source\repos\InstagramClone\Views\Account\GetFollowings.cshtml"
                                                                                                                                                                                                                 WriteLiteral(user.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        <p style=\"grid-row-start:2;grid-row-end:3;grid-column-start:2;grid-column-end:3;margin-left:10px;color:darkgray;\">");
#nullable restore
#line 18 "C:\Users\Polad\source\repos\InstagramClone\Views\Account\GetFollowings.cshtml"
                                                                                                                     Write(user.Full_Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n        <div class=\"follow-unfollow-buttons\">\r\n");
#nullable restore
#line 21 "C:\Users\Polad\source\repos\InstagramClone\Views\Account\GetFollowings.cshtml"
             if (user.Current_User_Following == true)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a class=\"unfollow-button\" style=\"margin-right:10px;\" data-current-user-id=\"");
#nullable restore
#line 23 "C:\Users\Polad\source\repos\InstagramClone\Views\Account\GetFollowings.cshtml"
                                                                                       Write(user.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">Following</a>\r\n                <a class=\"follow-button\" style=\"display:none;margin-right:10px;\" data-current-user-id=\"");
#nullable restore
#line 24 "C:\Users\Polad\source\repos\InstagramClone\Views\Account\GetFollowings.cshtml"
                                                                                                  Write(user.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">Follow</a>\r\n");
#nullable restore
#line 25 "C:\Users\Polad\source\repos\InstagramClone\Views\Account\GetFollowings.cshtml"

            }
            else if (user.Current_User_Following == false && user.Id != ViewBag.CurrUserId)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a class=\"follow-button\" style=\"margin-right:10px;\" data-current-user-id=\"");
#nullable restore
#line 29 "C:\Users\Polad\source\repos\InstagramClone\Views\Account\GetFollowings.cshtml"
                                                                                     Write(user.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">Follow</a>\r\n                <a class=\"unfollow-button\" style=\"display:none;margin-right:10px;\" data-current-user-id=\"");
#nullable restore
#line 30 "C:\Users\Polad\source\repos\InstagramClone\Views\Account\GetFollowings.cshtml"
                                                                                                    Write(user.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">Following</a>\r\n");
#nullable restore
#line 31 "C:\Users\Polad\source\repos\InstagramClone\Views\Account\GetFollowings.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n");
#nullable restore
#line 34 "C:\Users\Polad\source\repos\InstagramClone\Views\Account\GetFollowings.cshtml"

}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script>
    $('.unfollow-button').click((e) => {
        console.log('fired');
        $.ajax({
            type: ""GET"",
            url: ""/Account/UnfollowUser"",
            data: { id: $(e.target).attr('data-current-user-id') },
            success: (responce) => {
                if ('");
#nullable restore
#line 45 "C:\Users\Polad\source\repos\InstagramClone\Views\Account\GetFollowings.cshtml"
                Write(ViewBag.UserProfileId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\' == \'");
#nullable restore
#line 45 "C:\Users\Polad\source\repos\InstagramClone\Views\Account\GetFollowings.cshtml"
                                            Write(ViewBag.CurrUserId);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"') {

                    $('#number-of-followings :first').text(`${parseInt($('#number-of-followings').text()) - 1}`);
                    $('#number-of-followings :last').text('followings');

                    $('#number-of-followings :first').css('font-weight', 'bold');
                }
                                    $(e.target).css('display', 'none');
                    $(e.target).siblings().css('display', 'inline');
            },
            error: (responce) => {
                alert('error');
            }
        });


    });
    $('.follow-button').click((e) => {
        console.log('fired');
        $.ajax({
            type: ""GET"",
            url: ""/Account/FollowUser"",
            data: { id: $(e.target).attr('data-current-user-id') },
            success: (responce) => {
                if ('");
#nullable restore
#line 69 "C:\Users\Polad\source\repos\InstagramClone\Views\Account\GetFollowings.cshtml"
                Write(ViewBag.UserProfileId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\' == \'");
#nullable restore
#line 69 "C:\Users\Polad\source\repos\InstagramClone\Views\Account\GetFollowings.cshtml"
                                            Write(ViewBag.CurrUserId);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"') {

                    $('#number-of-followings :first').text(`${parseInt($('#number-of-followings').text()) + 1}`);
                    $('#number-of-followings :last').text('followings');

                    $('#number-of-followings :first').css('font-weight', 'bold');
                }
                                    $(e.target).css('display', 'none');
                    $(e.target).siblings().css('display', 'inline');

            },
            error: (responce) => {
                alert('error');
            }
        });


    });
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<UserViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
