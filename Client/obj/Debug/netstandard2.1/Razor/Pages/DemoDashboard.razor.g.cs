#pragma checksum "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/DemoDashboard.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7e63b42cf5d496bbe3584d0b3e2f47201e04120d"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorSignalRApp.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/_Imports.razor"
using BlazorSignalRApp.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/_Imports.razor"
using BlazorSignalRApp.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/_Imports.razor"
using Blazor.Extensions.Canvas;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/_Imports.razor"
using ChartJs.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/DemoDashboard.razor"
using BlazorSignalRApp.Shared.Models.OEE;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/DemoDashboard.razor"
using Microsoft.AspNetCore.SignalR.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/DemoDashboard.razor"
using Blazor.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/DemoDashboard.razor"
using System.Threading;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/demoDashboard")]
    public partial class DemoDashboard : DemoDashboardComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<div>\n    <h3>Real Time Dashboard</h3>\n</div>\n");
#nullable restore
#line 15 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/DemoDashboard.razor"
 if (_dashboardData == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(1, "    ");
            __builder.AddMarkupContent(2, "<p><em>Loading...</em></p>\n");
#nullable restore
#line 18 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/DemoDashboard.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(3, "    ");
            __builder.OpenElement(4, "div");
            __builder.AddAttribute(5, "class", "container");
            __builder.AddMarkupContent(6, "\n        ");
            __builder.OpenElement(7, "div");
            __builder.AddAttribute(8, "class", "row");
            __builder.AddMarkupContent(9, "\n");
#nullable restore
#line 23 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/DemoDashboard.razor"
          i = 0;
            // Get first item to start iteration for layout
            RealTime lastItem = _dashboardData.First();
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/DemoDashboard.razor"
         foreach (var item in _dashboardData)
        {
                // Creates horizontal line to divide between lines
                if(item.LineId != lastItem.LineId)
                {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(10, "                    <hr style=\"width:90%;text-align:left;margin-left:0\">\n");
#nullable restore
#line 33 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/DemoDashboard.razor"
                }

#line default
#line hidden
#nullable disable
            __builder.AddContent(11, "                ");
            __builder.OpenElement(12, "div");
            __builder.AddAttribute(13, "class", "col text-center");
            __builder.AddMarkupContent(14, "\n                    ");
            __builder.OpenComponent<Blazor.Extensions.Canvas.BECanvas>(15);
            __builder.AddAttribute(16, "Width", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int64>(
#nullable restore
#line 35 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/DemoDashboard.razor"
                                     250

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(17, "Height", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int64>(
#nullable restore
#line 35 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/DemoDashboard.razor"
                                                  200

#line default
#line hidden
#nullable disable
            ));
            __builder.AddComponentReferenceCapture(18, (__value) => {
#nullable restore
#line 35 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/DemoDashboard.razor"
                                                             _canvasReference = (Blazor.Extensions.Canvas.BECanvas)__value;

#line default
#line hidden
#nullable disable
            }
            );
            __builder.CloseComponent();
            __builder.AddMarkupContent(19, "\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\n");
#nullable restore
#line 37 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/DemoDashboard.razor"
                i++;
                lastItem = item;
        }

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(21, "        \n        \n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(22, "\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(23, "\n");
#nullable restore
#line 44 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/DemoDashboard.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 46 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/DemoDashboard.razor"
      

    protected override void OnInitialized()
    {
    _dashboardData = new List<RealTime>();
            _dashboardData.Add(new RealTime()
            {
                LineId = 1,
                LineName = "TestLine",
                OpNumber = 10,
                OpName = "OperationTest",
                Available = true,
                LastEventTime = DateTime.Now,
                TotalShiftDowntime = new DateTime(0,0,0,1,34,25),
                AvailabilityPercent = 0.78
            });
            _dashboardData.Add(new RealTime()
            {
                LineId = 1,
                LineName = "TestLine",
                OpNumber = 20,
                OpName = "OperationTest2",
                Available = true,
                LastEventTime = DateTime.Now,
                TotalShiftDowntime = new DateTime(0,0,0,1,34,25),
                AvailabilityPercent = 0.78
            });

            StateHasChanged();

    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
