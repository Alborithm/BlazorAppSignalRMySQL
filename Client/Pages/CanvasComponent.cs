using Blazor.Extensions;
using Blazor.Extensions.Canvas.Canvas2D;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using BlazorSignalRApp.Shared.Models.OEE;
using System.Collections.Generic;
using System;

namespace BlazorSignalRApp.Client.Pages
{
    public class CanvasComponent : ComponentBase
    {
        private Canvas2DContext _context;
        protected BECanvasComponent _canvasReference { set => _canvasReferenceList.Add(value);}

        protected List<BECanvasComponent> _canvasReferenceList = new List<BECanvasComponent>();

        // https://github.com/dotnet/aspnetcore/issues/13358 capture references in a loop
        protected List<RealTimeDashboardData> _dashboardData; //= new List<RealTimeDashboardData>(); 

        protected override void OnInitialized()
        {
            _dashboardData = new List<RealTimeDashboardData>();
            _dashboardData.Add(new RealTimeDashboardData(){
                LineName = "Line A",
                OperationName = "Operation 10",
                Availability = 0.87,
                TimeToRepair = "00:00:00",
                TotalDowntime = "01:09:48",
                Available = true
            });
            _dashboardData.Add(new RealTimeDashboardData(){
                LineName = "Line A",
                OperationName = "Operation 20",
                Availability = 0.64,
                TimeToRepair = "00:24:20",
                TotalDowntime = "02:52:03",
                Available = false
            });
            _dashboardData.Add(new RealTimeDashboardData(){
                LineName = "Line A",
                OperationName = "Operation 30",
                Availability = 0.58,
                TimeToRepair = "00:00:00",
                TotalDowntime = "03:38:30",
                Available = true
            });
            _dashboardData.Add(new RealTimeDashboardData(){
                LineName = "Line B",
                OperationName = "Operation 10",
                Availability = 0.92,
                TimeToRepair = "00:05:49",
                TotalDowntime = "00:31:08",
                Available = false
            });
            _dashboardData.Add(new RealTimeDashboardData(){
                LineName = "Line B",
                OperationName = "Operation 20",
                Availability = 0.71,
                TimeToRepair = "00:00:00",
                TotalDowntime = "02:32:21",
                Available = true
            });

            //_canvasReferenceList = new List<BECanvasComponent>() {null,null, null, null, null};
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            //this._context = await this._canvasReference.CreateCanvas2DAsync();


            int i= 0;
            //foreach (RealTimeDashboardData item in _dashboardData)
            //{
                //_canvasReferenceList.Add(null);

                //this._context = await _canvasReferenceList[i].CreateCanvas2DAsync();

                //await DrawAvailabilityCardAsync(item);
                //i++;
            //}
            //this._canvasReferenceList.Add(null);
            //this._context = await _canvasReferenceList[0].CreateCanvas2DAsync();
            
            // This last one works still seems not to be the correct way to do it.
            //this._canvasReferenceList = new List<BECanvasComponent>() {null};

            // LETS TRY THIS
            //this._context = await this._canvasReference.CreateCanvas2DAsync();
            //await DrawAvailabilityCardAsync(_dashboardData[2]);
            this._context = await this._canvasReferenceList[0].CreateCanvas2DAsync();
            await DrawAvailabilityCardAsync(_dashboardData[0]);

            this._context = await this._canvasReferenceList[1].CreateCanvas2DAsync();
            await DrawAvailabilityCardAsync(_dashboardData[1]);

            this._context = await this._canvasReferenceList[2].CreateCanvas2DAsync();
            await DrawAvailabilityCardAsync(_dashboardData[2]);

            this._context = await this._canvasReferenceList[3].CreateCanvas2DAsync();
            await DrawAvailabilityCardAsync(_dashboardData[3]);

            this._context = await this._canvasReferenceList[4].CreateCanvas2DAsync();
            await DrawAvailabilityCardAsync(_dashboardData[4]);

            //foreach (RealTimeDashboardData item in _dashboardData)
            //{
            //    this._context = await this._canvasReferenceList[i].CreateCanvas2DAsync();

              //  await DrawAvailabilityCardAsync(item);
            //}

        }

        protected async Task DrawAvailabilityCardAsync(
            RealTimeDashboardData data)
        {
            //if (canvasComponent is null)
            //{
            //    throw new ArgumentNullException(nameof(canvasComponent));
            //}

            //this._context = await canvasComponent.CreateCanvas2DAsync();
            
            string LineName = data.LineName;
            string OperationName = data.OperationName;
            double Availability = data.Availability;
            string TimeToRepair = data.TimeToRepair;
            string TotalDowntime = data.TotalDowntime;
            bool Available = data.Available;

            // Canvas margin
            await this._context.RectAsync(0,0,250,200);
            
            // Labels Repair times
            await this._context.SetFontAsync("16px Helvetica");
            await this._context.FillTextAsync("Time to Repair", 5, 18);
            await this._context.FillTextAsync("Total Downtime", 130, 18);

            // Time counters
            await this._context.MoveToAsync(2,20);
            await this._context.RectAsync(5,20,118,30);
            await this._context.MoveToAsync(127,25);
            await this._context.RectAsync(127,20,118,30);
            await this._context.StrokeAsync();

            // Counter Numbers
            await this._context.SetFontAsync("25px Helvetica");
            await this._context.FillTextAsync(TimeToRepair, 20, 45);
            await this._context.FillTextAsync(TotalDowntime, 140, 45);

            // Reporter Area
            await this._context.MoveToAsync(0,60);
            await this._context.RectAsync(5,55,240,140);
            await this._context.StrokeAsync();

            // Real Time Visual Block
            await this._context.MoveToAsync(7,57);
            await this._context.BeginPathAsync();
            await this._context.RectAsync(7,57,236,136);
            await this._context.ClosePathAsync();
            switch (Available)
            {
                case true:
                    await this._context.SetFillStyleAsync("green");
                    break;
                case false:
                    await this._context.SetFillStyleAsync("#cc0000");
                    break;
            }
            await this._context.FillAsync();

            // Real Time second Layer
            await this._context.MoveToAsync(9,59);
            await this._context.BeginPathAsync();
            await this._context.RectAsync(9,59,230,130);
            await this._context.ClosePathAsync();
            switch (Available)
            {
                case true:
                    await this._context.SetFillStyleAsync("#2ba745");
                    break;
                case false:
                    await this._context.SetFillStyleAsync("#dc3645");
                    break;
            }
            await this._context.FillAsync();

            // Operation Data
            await this._context.SetFontAsync("25px Helvetica");
            await this._context.SetFillStyleAsync("white");
            await this._context.FillTextAsync(LineName, 10, 85);
            await this._context.FillTextAsync(OperationName, 10, 110);

            // Arc representation of availability
            await this._context.BeginPathAsync();
            await this._context.MoveToAsync(65,180);
            await this._context.SetFillStyleAsync("gray");
            await this._context.ArcAsync(125, 180, 60, Math.PI, 0, false);
            await this._context.ArcAsync(125, 180, 40, 0, Math.PI, true);
            await this._context.ClosePathAsync();
            await this._context.StrokeAsync();
            await this._context.FillAsync();

            // Select colors for graph depending on Availability
            if (Availability < 0.60) 
            {
                await this._context.SetFillStyleAsync("red");
            }
            else if(Availability < 0.85)
            {
                await this._context.SetFillStyleAsync("yellow");
            }
            else
            {
                await this._context.SetFillStyleAsync("green");
            }

            // fill the arc with availability
            await this._context.BeginPathAsync();
            await this._context.MoveToAsync(65, 180);
            await this._context.ArcAsync(125, 180, 60, Math.PI, (Math.PI + Math.PI * Availability), false);
            await this._context.ArcAsync(125, 180, 40, (Math.PI + Math.PI * Availability), Math.PI, true);
            await this._context.ClosePathAsync();
            await this._context.FillAsync();
            
            // Text representation of availability
            await this._context.SetFillStyleAsync("white");
            await this._context.FillTextAsync("A = ", 15, 160);
            await this._context.FillTextAsync( (Availability*100).ToString() + " %", 98, 175); 

        }

        public class RealTimeDashboardData
        {
            private string _lineName;
            public string LineName
            {
                get { return _lineName; }
                set { _lineName = value; }
            }
            
            private string _operationName;
            public string OperationName
            {
                get { return _operationName; }
                set { _operationName = value; }
            }
            
            private double _availability;
            public double Availability
            {
                get { return _availability; }
                set { _availability = value; }
            }
            
            private string _timeToRepair;
            public string TimeToRepair
            {
                get { return _timeToRepair; }
                set { _timeToRepair = value; }
            }
            
            private string _totalDowntime;
            public string TotalDowntime
            {
                get { return _totalDowntime; }
                set { _totalDowntime = value; }
            }
            
            private bool _available;
            public bool Available
            {
                get { return _available; }
                set { _available = value; }
            }
            
        }
    }
}