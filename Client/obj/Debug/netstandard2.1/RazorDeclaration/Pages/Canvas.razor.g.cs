#pragma checksum "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/Canvas.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "639a6cf568c2c7b7b177fb162eb3af766cd97f38"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

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
#line 3 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/Canvas.razor"
using BlazorSignalRApp.Shared.Models.OEE;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/Canvas.razor"
using Microsoft.AspNetCore.SignalR.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/Canvas.razor"
using Blazor.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/Canvas.razor"
using System.Threading;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/canvas")]
    public partial class Canvas : CanvasComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 62 "/Users/gerardoalbor/Repositories/BlazorTest/ChatTutorial/BlazorSignalRApp/Client/Pages/Canvas.razor"
      
    private List<RealTime> EquipmentList;
    private HubConnection hubConnection;
    private bool LoadedData = false;
    AutoResetEvent autoEvent = new AutoResetEvent(false);
    private bool TimerInitialized = false;
    private Timer DrawCallBack;

    protected override async Task OnInitializedAsync()
    {
        hubConnection = new HubConnectionBuilder()  
            .WithUrl(NavigationManager.ToAbsoluteUri("/oeeHub"))  
            .Build();  
  
        hubConnection.On("ReceiveMessage", () =>  
        {  
            CallLoadData();  
            StateHasChanged();  
        });

        await hubConnection.StartAsync();

        await LoadData();

        //InitializeCanvasReferenceList();
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
        EquipmentList = await Http.GetFromJsonAsync<List<RealTime>>("api/oee/realTime");
        _dashboardData = EquipmentList;

        StateHasChanged();
    }

    protected void InitializeCanvasReferenceList()
    {
        foreach (var item in _dashboardData)
        {
            _canvasReferenceList.Add(null);
        }
    }

    public bool IsConnected =>  
        hubConnection.State == HubConnectionState.Connected;  
  
    public void Dispose()  
    {  
        _ = hubConnection.DisposeAsync();  
    }

    public async void TimerRedraw(Object state)
    {
        AutoResetEvent autoEvent = (AutoResetEvent)state;
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
