#pragma checksum "C:\Users\Polad\source\repos\InstagramClone\Views\Account\Navigate.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ea8e200a30c7ac2ecf8402dc3c336811ecc15898"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Navigate), @"mvc.1.0.view", @"/Views/Account/Navigate.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ea8e200a30c7ac2ecf8402dc3c336811ecc15898", @"/Views/Account/Navigate.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bcbc1c3ac2cf3f6a98a750ac1641944d9fa8ecce", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Navigate : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<PostViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GetAllUsers", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Account", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Pics/icons8-comments-52.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("height:30px;width:30px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("caption-post-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("display:grid;grid-template-columns:80% 20%;height:100%;width:100%;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("autocomplete", new global::Microsoft.AspNetCore.Html.HtmlString("off"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("add-post-modal-content"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddPost", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n    <div id=\"container\">\r\n        <div id=\"get-all-users\">\r\n            <p>Discover All Users</p>\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ea8e200a30c7ac2ecf8402dc3c336811ecc158987772", async() => {
                WriteLiteral("See All Users");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n        <div id=\"get-all-users-posts\">\r\n");
#nullable restore
#line 9 "C:\Users\Polad\source\repos\InstagramClone\Views\Account\Navigate.cshtml"
             foreach (var p in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a>\r\n");
#nullable restore
#line 12 "C:\Users\Polad\source\repos\InstagramClone\Views\Account\Navigate.cshtml"
                     if (p.Picture != null)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div style=\"position:relative;width:100%;padding-bottom:100%;\" class=\"user-photo\">\r\n                            <img style=\'position:absolute; width:100%; height:100%\'");
            BeginWriteAttribute("src", " src=\"", 603, "\"", 668, 2);
            WriteAttributeValue("", 609, "data:image/jpeg;base64,", 609, 23, true);
#nullable restore
#line 15 "C:\Users\Polad\source\repos\InstagramClone\Views\Account\Navigate.cshtml"
WriteAttributeValue("", 632, Convert.ToBase64String(p.Picture), 632, 36, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-post-id=\"");
#nullable restore
#line 15 "C:\Users\Polad\source\repos\InstagramClone\Views\Account\Navigate.cshtml"
                                                                                                                                                               Write(p.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-author-id=\"");
#nullable restore
#line 15 "C:\Users\Polad\source\repos\InstagramClone\Views\Account\Navigate.cshtml"
                                                                                                                                                                                      Write(p.IUser_Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-number-likes=\"");
#nullable restore
#line 15 "C:\Users\Polad\source\repos\InstagramClone\Views\Account\Navigate.cshtml"
                                                                                                                                                                                                                      Write(p.Number_Of_Likes);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" />\r\n                            <div class=\"image-info\">\r\n\r\n                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 20 "C:\Users\Polad\source\repos\InstagramClone\Views\Account\Navigate.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </a>\r\n");
#nullable restore
#line 22 "C:\Users\Polad\source\repos\InstagramClone\Views\Account\Navigate.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </div>
        <div id=""post-modal"">
            <div id=""post-modal-content"">
                <div id=""photo-part"">

                </div>
                <div id=""comments-part"">
                    <div id=""comments-top-part"">

                    </div>
                    <div id=""comments-central-part"">

                    </div>
                    <div id=""comments-bottom-part"">
                        <div id=""post-actions-part"">
                            <div id=""icons-part"" style=""display:flex;height:100%;width:100%; align-items:center;"">
                                <div id=""like-picture-placeholder"" style=""margin-left:10px;margin-right:10px;"">

                                </div>
                                <a id=""add-comment-button"">
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ea8e200a30c7ac2ecf8402dc3c336811ecc1589813040", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                </a>
                                <a id=""bookmark-post-button"" style=""margin-left:auto;"">

                                </a>
                            </div>
                            <div id=""number-of-likes-part"" style=""display:flex;height:100%;"">
                                <p></p>
                            </div>
                            <div id=""date-part"" style=""display:flex;height:100%;"">

                            </div>
                        </div>
                        <div id=""post-caption-part"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ea8e200a30c7ac2ecf8402dc3c336811ecc1589814778", async() => {
                WriteLiteral(@"
                                <input id=""text-input"" required style=""border:none;margin:10px;"" type=""text"" placeholder=""Add new post..."" />
                                <input id=""caption-submit-button"" type=""submit"" style=""border:none;background-color:#FFFFFF;color:#3897F0;font-weight:bold;opacity: 0.4;filter: alpha(opacity=40);"" value=""Post"" />
                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n            <span id=\"post-modal-close\">&times;</span>\r\n\r\n        </div>\r\n        <div id=\"add-post-modal\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ea8e200a30c7ac2ecf8402dc3c336811ecc1589816907", async() => {
                WriteLiteral(@"

                <label style=""grid-column-start:1;grid-column-end:2;grid-row-start:1;grid-row-end:2;align-self:center;margin-left:auto;font-weight:bold;"">Caption</label>
                <textarea name=""caption"" form=""add-post-modal-content"" style=""grid-column-start:2;grid-column-end:3;grid-row-start:1;grid-row-end:2;margin:20px;resize:none;border-radius:10px;border:1px solid #DBDBDB; padding:10px;"" placeholder=""Write your caption here...""> </textarea>

                <label style=""grid-row-start:2;grid-row-end:3;grid-column-start:1;grid-column-end:2;align-self:center;margin-left:auto;font-weight:bold;"">File</label>
                <label style=""grid-row-start:2;grid-row-end:3;grid-column-start:2;grid-column-end:3;align-self:center;display:flex;align-items:center; margin-left:20px; cursor:pointer;"">
                    <input type=""file"" style=""display:none;"" class=""file-upload"" name=""img"" />
                    <span style=""margin-right:20px;border-radius:5px;border:1px solid #3897F0; background-co");
                WriteLiteral(@"lor:#3897F0; color:white;padding:10px;"">Upload Image</span>

                    <img id=""file-selected"" style=""width:50px;height:50px;display:none;"" />
                </label>
                <input type=""submit"" value=""Add Post"" style=""cursor:pointer; grid-row-start:3;grid-row-end:4;grid-column-start:1;grid-column-end:3;margin:20px;border-radius:5px;border:1px solid #3897F0; background-color:#3897F0; color:white;"" />
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            <span id=""add-post-modal-close"">&times;</span>
        </div>
    </div>



<script src=""https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.11.3.min.js""></script>
<script src=""https://ajax.aspnetcdn.com/ajax/jquery.validate/1.14.0/jquery.validate.min.js""></script>
<script src=""https://ajax.aspnetcdn.com/ajax/jquery.validation.unobtrusive/3.2.6/jquery.validate.unobtrusive.min.js""></script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<PostViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591