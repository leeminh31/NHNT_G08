#pragma checksum "D:\BTL_WNC_G08\NHNT_G08\NHNT_G08\Views\Home\DanhGia.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b184dee27ad379abe79c3557f31f067bbda0206e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_DanhGia), @"mvc.1.0.view", @"/Views/Home/DanhGia.cshtml")]
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
#line 1 "D:\BTL_WNC_G08\NHNT_G08\NHNT_G08\Views\_ViewImports.cshtml"
using NHNT_G08;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\BTL_WNC_G08\NHNT_G08\NHNT_G08\Views\_ViewImports.cshtml"
using NHNT_G08.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b184dee27ad379abe79c3557f31f067bbda0206e", @"/Views/Home/DanhGia.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"395356eb8ec5931927962e6d3a923b66818a6340", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_DanhGia : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Pagination<Phong>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/index.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            DefineSection("Style", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b184dee27ad379abe79c3557f31f067bbda0206e4270", async() => {
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
            }
            );
            WriteLiteral("\r\n<!-- Phần thân trang web -->\r\n<div class=\"main\">\r\n    <fieldset class=\"fieldset_item\" id=\"fieldset_item-mienbac\">\r\n        <legend class=\"fieldset_item-title\">\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 280, "\"", 287, 0);
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 288, "\"", 293, 0);
            EndWriteAttribute();
            WriteLiteral(">****** Thông tin phòng trọ *****</a>\r\n        </legend>\r\n        <div class=\"grid item\">\r\n\r\n");
#nullable restore
#line 15 "D:\BTL_WNC_G08\NHNT_G08\NHNT_G08\Views\Home\DanhGia.cshtml"
             foreach (var phong in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"grid_col_4 item_travel\">\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 521, "\"", 528, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                        <div class=""item_travel-item1"" style=""background-image: url('/img/anhtro/anh1.jpg');""></div>
                    </a>
                    <div class=""item_travel-item2"">
                        <div class=""item_travel-item2-con"">
                            <i class=""item_travel-item2-icon fa fa-star"" aria-hidden=""true""></i>
                            <i class=""item_travel-item2-icon fa fa-star"" aria-hidden=""true""></i>
                            <i class=""item_travel-item2-icon fa fa-star"" aria-hidden=""true""></i>
                            <i class=""item_travel-item2-icon fa fa-star"" aria-hidden=""true""></i>
                            <i class=""item_travel-item2-icon fa-sharp fa-regular fa-star""></i>

                            <span class=""item_travel-item2-con-price"">");
#nullable restore
#line 29 "D:\BTL_WNC_G08\NHNT_G08\NHNT_G08\Views\Home\DanhGia.cshtml"
                                                                 Write(phong.giaPhong.ToString("#,#"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" Đ</span>\r\n                        </div>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 1450, "\"", 1457, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"item_travel-item2-title\">");
#nullable restore
#line 31 "D:\BTL_WNC_G08\NHNT_G08\NHNT_G08\Views\Home\DanhGia.cshtml"
                                                              Write(phong.tenPhong);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>

                        <div class=""item_travel-item2-info"">
                            <div>
                                <p>
                                    <i class=""fa-sharp fa-solid fa-location-dot""></i>
                                    <span class=""travel-item2-info--span"">Địa chỉ: ");
#nullable restore
#line 37 "D:\BTL_WNC_G08\NHNT_G08\NHNT_G08\Views\Home\DanhGia.cshtml"
                                                                              Write(phong.diaChi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                </p>\r\n                                <p>\r\n                                    <i class=\"fa-sharp fa-solid fa-bolt\"></i>\r\n                                    <span class=\"travel-item2-info--span\">Giá điện: ");
#nullable restore
#line 41 "D:\BTL_WNC_G08\NHNT_G08\NHNT_G08\Views\Home\DanhGia.cshtml"
                                                                               Write(phong.giaDien.ToString("#,#"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" Đ</span>\r\n                                </p>\r\n                                <p>\r\n                                    <i class=\"fa-sharp fa-solid fa-droplet\"></i>\r\n                                    <span class=\"travel-item2-info--span\">Giá nước: ");
#nullable restore
#line 45 "D:\BTL_WNC_G08\NHNT_G08\NHNT_G08\Views\Home\DanhGia.cshtml"
                                                                               Write(phong.giaNuoc.ToString("#,#"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" Đ</span>\r\n                                </p>\r\n                            </div>\r\n\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 52 "D:\BTL_WNC_G08\NHNT_G08\NHNT_G08\Views\Home\DanhGia.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 54 "D:\BTL_WNC_G08\NHNT_G08\NHNT_G08\Views\Home\DanhGia.cshtml"
              
                var previousDisabled = !Model.HasPreviousPage ? "disabled" : "";
                var nextDisabled = !Model.HasNextPage ? "disabled" : "";
            

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"m-auto pt-3\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b184dee27ad379abe79c3557f31f067bbda0206e10605", async() => {
                WriteLiteral("\r\n                    Previous\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-pageIndex", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 60 "D:\BTL_WNC_G08\NHNT_G08\NHNT_G08\Views\Home\DanhGia.cshtml"
                                                WriteLiteral(Model.PageIndex -1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageIndex"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-pageIndex", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageIndex"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2895, "btn", 2895, 3, true);
            AddHtmlAttributeValue(" ", 2898, "btn-primary", 2899, 12, true);
#nullable restore
#line 60 "D:\BTL_WNC_G08\NHNT_G08\NHNT_G08\Views\Home\DanhGia.cshtml"
AddHtmlAttributeValue(" ", 2910, previousDisabled, 2911, 17, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b184dee27ad379abe79c3557f31f067bbda0206e13440", async() => {
                WriteLiteral("\r\n                    Next\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-pageIndex", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 64 "D:\BTL_WNC_G08\NHNT_G08\NHNT_G08\Views\Home\DanhGia.cshtml"
                                                WriteLiteral(Model.PageIndex +1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageIndex"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-pageIndex", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageIndex"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3075, "btn", 3075, 3, true);
            AddHtmlAttributeValue(" ", 3078, "btn-primary", 3079, 12, true);
#nullable restore
#line 64 "D:\BTL_WNC_G08\NHNT_G08\NHNT_G08\Views\Home\DanhGia.cshtml"
AddHtmlAttributeValue(" ", 3090, nextDisabled, 3091, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>


        </div>

    </fieldset>

    <br><br><br>

    <div class=""grid"">
        <p style=""color:rgb(43, 172, 17);font-size: 27px;margin: 30px 0;"">Top Phòng Có Đánh Giá Cao Nhất</p>
        <div class=""news"">

            <div class=""grid_col_3 travel_news"">
                <a");
            BeginWriteAttribute("href", " href=\"", 3469, "\"", 3476, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    <div class=""travel_news-item1"" style=""background-image: url('https://recmiennam.com/wp-content/uploads/2018/01/hinh-anh-vinh-ha-long-1.jpg');""></div>
                </a>
                <div class=""travel_news-item2"">

                    <a");
            BeginWriteAttribute("href", " href=\"", 3746, "\"", 3753, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"travel-news-title\">Bạn muốn biết thêm về Hội An</a>\r\n\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 3839, "\"", 3846, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"travel-item2-detail\">\r\n                        <p");
            BeginWriteAttribute("style", " style=\"", 3904, "\"", 3912, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                            Nếu được một lần đặt chân đến vùng đất miến trung thân thương, xin hãy ghé thăm phố cổ hội an, dành thời gian
                            để tận hưởng khám phá rọn vẹn vẻ đẹp và văn hóa nơi đây.....
                        </p>

                    </a>
                </div>
            </div>

            <div class=""grid_col_3 travel_news"">
                <a");
            BeginWriteAttribute("href", " href=\"", 4317, "\"", 4324, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    <div class=""travel_news-item1"" style=""background-image: url('https://kenh14cdn.com/thumb_w/660/2020/7/30/photo-1-15960830616942085771134.jpg');""></div>
                </a>
                <div class=""travel_news-item2"">

                    <a");
            BeginWriteAttribute("href", " href=\"", 4596, "\"", 4603, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"travel-news-title\">Bạn muốn biết thêm về Hội An</a>\r\n\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 4689, "\"", 4696, 0);
            EndWriteAttribute();
            WriteLiteral(@" class=""travel-item2-detail"">
                        <p>
                            Nếu được một lần đặt chân đến vùng đất miến trung thân thương, xin hãy ghé thăm phố cổ hội an, dành thời gian
                            để tận hưởng khám phá rọn vẹn vẻ đẹp và văn hóa nơi đây.....
                        </p>

                    </a>
                </div>
            </div>

            <div class=""grid_col_3 travel_news"">
                <a");
            BeginWriteAttribute("href", " href=\"", 5158, "\"", 5165, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    <div class=""travel_news-item1"" style=""background-image: url('https://afamilycdn.com/2020/1/25/photo-1579917193675-15799171936821461273161.png');""></div>
                </a>
                <div class=""travel_news-item2"">

                    <a");
            BeginWriteAttribute("href", " href=\"", 5438, "\"", 5445, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"travel-news-title\">Bạn muốn biết thêm về Hội An</a>\r\n\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 5531, "\"", 5538, 0);
            EndWriteAttribute();
            WriteLiteral(@" class=""travel-item2-detail"">
                        <p>
                            Nếu được một lần đặt chân đến vùng đất miến trung thân thương, xin hãy ghé thăm phố cổ hội an, dành thời gian
                            để tận hưởng khám phá rọn vẹn vẻ đẹp và văn hóa nơi đây.....
                        </p>

                    </a>
                </div>
            </div>
        </div>
    </div>

    <div class=""grid"">
        <p style=""color:rgb(43, 172, 17);font-size: 27px;margin: 30px 0;"">Biết hơn về HALOTRAVEL</p>
        <p style=""padding: 10px; text-align: justify;"">
            Tính đến hết năm 2014, Việt Nam có 28 lễ hội được đưa vào danh mục Di sản văn hóa phi vật thể cấp quốc gia gồm:
            Hội Gióng đền Phù Đổng và đền Sóc (Hà Nội), Lễ hội Yên Thế (Bắc Giang), Lễ hội Đền Đô (Bắc Ninh), Lễ hội Nhảy lửa
            của người Pà Thẻn (Hà Giang), Lễ hội Côn Sơn (Hải Dương), Lễ hội Kiếp Bạc (Hải Dương), Lễ hội Chọi trâu Đồ Sơn (Hải Phòng),
            Lễ hội Cầu Ngư ở Kh");
            WriteLiteral(@"ánh Hòa (Khánh Hòa), Lễ hội Gầu Tào (Lào Cai, Hà Giang), Lễ hội Kỳ Yên ở đình Gia Lộc (Tây Ninh), Lễ hội
            Tháp Bà (Ponagar) Nha Trang (Khánh Hòa), Lễ hội Lồng Tông của người Tày (Tuyên Quang).[25]. Lễ hội Phủ Dầy, xã Kim Thái,
            huyện Vụ Bản, tỉnh Nam Định; Hội Lim, Tiên Du,Bắc Ninh,Lễ hội Nghinh Ông, huyện Cần Giờ, Thành phố Hồ Chí Minh. Lễ hội Roóng
            poọc của người Giáy (Tả Van, Sa Pa, Lào Cai) và Lễ Pút tồng của người Dao đỏ (Sa Pa, Lào Cai). Lễ hội Đền Trần Nam Định, Lễ
            hội Hoa Lư Ninh Bình, Lễ hội miếu Bà Chúa Xứ núi Sam An Giang, Lễ hội Lồng tồng Ba Bể Bắc Kạn, Lễ hội làng Lệ Mật Hà Nội,

        </p>
    </div>

</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Pagination<Phong>> Html { get; private set; }
    }
}
#pragma warning restore 1591
