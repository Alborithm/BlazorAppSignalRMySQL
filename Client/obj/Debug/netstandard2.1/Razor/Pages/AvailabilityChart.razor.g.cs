#pragma checksum "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/AvailabilityChart.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e919775ee461de7f1e2816bdc132dfb79ce5954d"
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
#line 3 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/AvailabilityChart.razor"
using BlazorSignalRApp.Shared.Models.OEE;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/AvailabilityChart.razor"
using Microsoft.AspNetCore.SignalR.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/AvailabilityChart.razor"
using ChartJs.Blazor.ChartJS.PieChart;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/AvailabilityChart.razor"
using ChartJs.Blazor.Charts;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/AvailabilityChart.razor"
using ChartJs.Blazor.ChartJS.Common.Properties;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/AvailabilityChart.razor"
using ChartJs.Blazor.Util;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/AvailabilityChart.razor"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/availabilityChart")]
    public partial class AvailabilityChart : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>Availability</h1>\n\n");
            __builder.AddMarkupContent(1, "<p>Using charts</p>\n\n");
#nullable restore
#line 18 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/AvailabilityChart.razor"
 if (availabilityList == null)
{

}
else
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(2, "    ");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "containter");
            __builder.AddMarkupContent(5, "\n        ");
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "class", "row");
            __builder.AddMarkupContent(8, "\n            <div class=\"col\"></div>\n            ");
            __builder.OpenElement(9, "div");
            __builder.AddAttribute(10, "class", "col-6");
            __builder.AddMarkupContent(11, "\n                ");
            __builder.OpenComponent<ChartJs.Blazor.Charts.ChartJsPieChart>(12);
            __builder.AddAttribute(13, "Config", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<ChartJs.Blazor.ChartJS.PieChart.PieConfig>(
#nullable restore
#line 28 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/AvailabilityChart.razor"
                                                             _config

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(14, "Width", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32?>(
#nullable restore
#line 28 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/AvailabilityChart.razor"
                                                                             300

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(15, "Height", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32?>(
#nullable restore
#line 28 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/AvailabilityChart.razor"
                                                                                          150

#line default
#line hidden
#nullable disable
            ));
            __builder.AddComponentReferenceCapture(16, (__value) => {
#nullable restore
#line 28 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/AvailabilityChart.razor"
                                       _pieChartJs = (ChartJs.Blazor.Charts.ChartJsPieChart)__value;

#line default
#line hidden
#nullable disable
            }
            );
            __builder.CloseComponent();
            __builder.AddMarkupContent(17, "\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(18, "\n            <div class=\"col\"></div>\n\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(19, "\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\n    ");
            __builder.OpenElement(21, "div");
            __builder.AddMarkupContent(22, "\n        ");
            __builder.OpenElement(23, "table");
            __builder.AddAttribute(24, "class", "tableDowntime");
            __builder.AddMarkupContent(25, "\n            ");
            __builder.AddMarkupContent(26, "<thead>\n                <tr>\n                    <th>Uptime</th>\n                    <th>Downtime</th>\n                </tr>\n            </thead>\n            ");
            __builder.OpenElement(27, "tbody");
            __builder.AddMarkupContent(28, "\n                ");
            __builder.OpenElement(29, "tr");
            __builder.AddMarkupContent(30, "\n                    ");
            __builder.OpenElement(31, "td");
            __builder.AddContent(32, 
#nullable restore
#line 44 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/AvailabilityChart.razor"
                         dataDowntime[0]

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(33, "\n                    ");
            __builder.OpenElement(34, "td");
            __builder.AddContent(35, 
#nullable restore
#line 45 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/AvailabilityChart.razor"
                         dataDowntime[1]

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(36, "\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(37, "\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(38, "\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(39, "\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(40, "\n    ");
            __builder.OpenElement(41, "div");
            __builder.AddMarkupContent(42, "\n        ");
            __builder.OpenElement(43, "table");
            __builder.AddAttribute(44, "class", "table");
            __builder.AddMarkupContent(45, "\n        ");
            __builder.AddMarkupContent(46, @"<thead> 
            <tr>
                <th>Department</th>
                <th>Area</th>
                <th>Line</th>
                <th>Operation</th>
                <th>Available</th>
                <th>Fail Code</th>
                <th>Event Time</th>
            </tr>
        </thead>
        ");
            __builder.OpenElement(47, "tbody");
            __builder.AddMarkupContent(48, "\n");
#nullable restore
#line 64 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/AvailabilityChart.razor"
             foreach (var field in availabilityList)
            {

#line default
#line hidden
#nullable disable
            __builder.AddContent(49, "                ");
            __builder.OpenElement(50, "tr");
            __builder.AddMarkupContent(51, "\n                    ");
            __builder.OpenElement(52, "td");
            __builder.AddContent(53, 
#nullable restore
#line 67 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/AvailabilityChart.razor"
                         field.Department

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(54, "\n                    ");
            __builder.OpenElement(55, "td");
            __builder.AddContent(56, 
#nullable restore
#line 68 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/AvailabilityChart.razor"
                         field.Area

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(57, "\n                    ");
            __builder.OpenElement(58, "td");
            __builder.AddContent(59, 
#nullable restore
#line 69 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/AvailabilityChart.razor"
                         field.LineName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(60, "\n                    ");
            __builder.OpenElement(61, "td");
            __builder.AddContent(62, 
#nullable restore
#line 70 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/AvailabilityChart.razor"
                         field.OpName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(63, "\n                    ");
            __builder.OpenElement(64, "td");
            __builder.AddContent(65, 
#nullable restore
#line 71 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/AvailabilityChart.razor"
                         field.Available

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(66, "\n                    ");
            __builder.OpenElement(67, "td");
            __builder.AddContent(68, 
#nullable restore
#line 72 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/AvailabilityChart.razor"
                         field.FailCode

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(69, "\n                    ");
            __builder.OpenElement(70, "td");
            __builder.AddContent(71, 
#nullable restore
#line 73 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/AvailabilityChart.razor"
                         field.EventTime

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(72, "\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(73, "\n");
#nullable restore
#line 75 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/AvailabilityChart.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.AddContent(74, "        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(75, "\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(76, "\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(77, "\n");
#nullable restore
#line 79 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/AvailabilityChart.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 82 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/AvailabilityChart.razor"
      
    private List<Availability> availabilityList;
    private HubConnection hubConnection;
    private ChartJsPieChart _pieChartJs;
    private PieConfig _config;
    private PieDataset pieSet;
    private double[] dataDowntime;


    protected override async Task OnInitializedAsync()
    {
        hubConnection = new HubConnectionBuilder()  
            .WithUrl(NavigationManager.ToAbsoluteUri("/oeeHub"))  
            .Build();

        _config = new PieConfig
        {
            Options = new PieOptions
            {
                Title = new OptionsTitle
                {
                    Display = true,
                    Text = "Sample chart from Blazor"
                },
                Responsive = true,
                Animation = new ArcAnimation
                {
                    AnimateRotate = true,
                    AnimateScale = true
                }
            }
        };

        _config.Data.Labels.AddRange(new[] {"Uptime", "Downtime"});

        pieSet = new PieDataset
        {
            BackgroundColor = new[] { "#009900", "#ff0000" },
            BorderWidth = 0,
            HoverBackgroundColor = ColorUtil.RandomColorString(),
            HoverBorderColor = ColorUtil.RandomColorString(),
            HoverBorderWidth = 1,
            BorderColor = "#ffffff",
        };

        pieSet.Data.AddRange(new double[] {1, 0});
        _config.Data.Datasets.Add(pieSet);
  
        hubConnection.On("ReceiveMessage", () =>  
        {  
            CallLoadData();  
            StateHasChanged();  
        });  
  
        await hubConnection.StartAsync();  
  
        await LoadData();
    }

    private void CallLoadData()   
    {  
        Task.Run(async () =>  
        {  
            await LoadData();  
        });  
    }  
  
    protected async Task LoadData()  
    {  
        FromToTime timeInterval = new FromToTime()
            {From = new DateTime(2020, 06, 23),
            To = new DateTime(2020, 06, 24)};

        /*using (var client = new HttpClient())
        {
        var res = client.GetFromJsonAsync("api/oee/availability/1/10/timeFilter", 
            new StringContent(JsonConvert.SerializeObject(timeInterval)));

        try
        {
            res.Result.EnsureSuccessStatusCode();
        } 
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
        } */  
        
        availabilityList = await Http.GetFromJsonAsync<List<Availability>>("api/oee/availability/1/10/20200623T0000Z/20200624T0000Z");
        dataDowntime = CalculateDowntime(availabilityList);

        pieSet.Data.Clear();
        _config.Data.Datasets.Clear();
        pieSet.Data.AddRange(dataDowntime);
        _config.Data.Datasets.Add(pieSet);

        StateHasChanged();  
    }

    public class FromToTime
        {
            private DateTime _from;
            public DateTime From
            {
                get { return _from; }
                set { _from = value; }
            }
            
            private DateTime _to;
            public DateTime To
            {
                get { return _to; }
                set { _to = value; }
            }
        }

    private double[] CalculateDowntime(List<Availability> availabilityList)
    {
        double[] output = new double[] {0,0};

        // Sorting should not be necessary 
        //availabilityList.Sort(delegate(Availability x, Availability y)
        //{
        //    if(x.EventTime == null && y.EventTime == null) return 0;
        //    else if (x.EventTime == null) return -1;
        //    else if (y.EventTime == null) return 1;
        //    else return x.EventTime.CompareTo(y.EventTime);
        //});

        double uptime = 0;
        double downtime = 0;
        double prevTicks = availabilityList.First().EventTime.Ticks;

        double totalTicks = (availabilityList.First().EventTime.Ticks - availabilityList.Last().EventTime.Ticks);

        foreach (Availability item in availabilityList)
        {
            if(item.Available == false)
            {
                downtime += prevTicks - item.EventTime.Ticks;
            }
            else
            {
                uptime += prevTicks - item.EventTime.Ticks;
            }

            prevTicks = item.EventTime.Ticks;
        }

        output[0] = ((uptime) / totalTicks * 100 );
        output[1] = ((downtime) / totalTicks * 100);

        return output;
    }
  
    public bool IsConnected =>  
        hubConnection.State == HubConnectionState.Connected;  
  
    public void Dispose()  
    {  
        _ = hubConnection.DisposeAsync();  
    }  

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
