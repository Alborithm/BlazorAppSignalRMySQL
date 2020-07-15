using Blazor.Extensions;
using Blazor.Extensions.Canvas.Canvas2D;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using BlazorSignalRApp.Shared.Models.OEE;
using System.Collections.Generic;
using System;
using BlazorSignalRApp.Shared.Models.OEE;

namespace BlazorSignalRApp.Client.Pages
{
    public class CanvasComponent : ComponentBase
    {
        private Canvas2DContext _context;
        private List<Canvas2DContext> _contextList = new List<Canvas2DContext>();
        protected int i;
        protected BECanvasComponent _canvasReference 
        { 
            set
            {
                //_canvasReferenceList[i] = value;
                /*
                if (_canvasReferenceList[i] != null)
                {
                    _canvasReferenceList[i] = value;
                }
                else
                {
                    _canvasReferenceList.Add(value);
                }*/
                if (_canvasReferenceList.Count == _dashboardData.Count)
                {
                    //_canvasReferenceList[i] = value; 
                }

                this._canvasReferenceList.Add(value);
            }
        }

        protected List<BECanvasComponent> _canvasReferenceList = new List<BECanvasComponent>();

        // https://github.com/dotnet/aspnetcore/issues/13358 capture references in a loop
        protected List<RealTime> _dashboardData;


        // Drawing vairables Colors
        private string RealTimePrimaryGreen = "#2ba745";
        private string RealTimeSecondaryGreen = "green";
        private string RealTimePrimaryRed = "#dc3645";
        private string RealTimeSecondaryRed = "#cc0000";
        private string TimerLabelsColor = "black";
        private string RealTimeFontColor = "white";
        private string FillBackgroundColor = "#d3d3d3";
        private string FillGreen = "#32cd32";
        private string FillYellow = "yellow";
        private string FillRed = "red";

        // Drawing variables fonts
        private string TimerLabelsFont = "16px Helvetica";
        private string TimerCountersFont = "25px Helvetica";
        private string RealTimeLabesFont = "25px Helvetica";
        private string AvailabilityLabelFont = "25px Helvetica";

        protected override void OnInitialized()
        {
            /*_dashboardData = new List<RealTimeDashboardData>();
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
            _dashboardData.Add(new RealTimeDashboardData(){
                LineName = "Line C",
                OperationName = "Operation 10",
                Availability = 0.35,
                TimeToRepair = "03:11:42",
                TotalDowntime = "05:18:04",
                Available = false
            });*/

        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            
            if (firstRender == false)
            {
                int j = 0;
                foreach (RealTime item in this._dashboardData)
                {
                    this._context = await this._canvasReferenceList[j].CreateCanvas2DAsync();
                    this._contextList.Add(this._context);
                    //Clear canvas
                    await this._context.ClearRectAsync(0, 0, _canvasReferenceList[j].Width, _canvasReferenceList[j].Height);
                    await this.DrawAvailabilityCardAsync(item);
                    j++;
                }
            }
            //else
            //{
            //    int j = 0;
            //    foreach (RealTime item in this._dashboardData)
            //    {
            //        this._context = this._contextList[j];

                    //Clear canvas
                    //await this._context.ClearRectAsync(0, 0, _canvasReferenceList[j].Width, _canvasReferenceList[j].Height);
                    //await this.DrawAvailabilityCardAsync(item);

                    //j++;
                //}
            //}

        }

        protected async Task DrawAvailabilityCardAsync(
            RealTime data)
        {
            //Random rnd = new Random();
            string LineName = data.LineName;
            string OperationName = data.OpName;
            double Availability = 0.75;
            string TimeToRepair;
            if (data.Available)
            {
                TimeToRepair = "00:00:00";
            }
            else
            {
                TimeToRepair = CalculateDowntimeTimer(data.LastEventTime);
            }
            string TotalDowntime = "00:00:00";
            bool Available = data.Available;

            // Canvas margin
            await this._context.RectAsync(0,0,250,200);
            
            // Timer Labels
            await this._context.SetFontAsync(TimerLabelsFont);
            await this._context.SetFillStyleAsync(TimerLabelsColor);
            await this._context.FillTextAsync("Downtime", 5, 18);
            await this._context.FillTextAsync("Total Downtime", 130, 18);

            // Time counters
            await this._context.MoveToAsync(2,20);
            await this._context.RectAsync(5,20,118,30);
            await this._context.MoveToAsync(127,25);
            await this._context.RectAsync(127,20,118,30);
            await this._context.StrokeAsync();

            // Counter Numbers
            await this._context.SetFontAsync(TimerCountersFont);
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
                    await this._context.SetFillStyleAsync(RealTimeSecondaryGreen);
                    break;
                case false:
                    await this._context.SetFillStyleAsync(RealTimeSecondaryRed);
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
                    await this._context.SetFillStyleAsync(RealTimePrimaryGreen);
                    break;
                case false:
                    await this._context.SetFillStyleAsync(RealTimePrimaryRed);
                    break;
            }
            await this._context.FillAsync();

            // Operation Data
            await this._context.SetFontAsync(RealTimeLabesFont);
            await this._context.SetFillStyleAsync(RealTimeFontColor);
            await this._context.FillTextAsync(LineName, 10, 85);
            await this._context.FillTextAsync(OperationName, 10, 110);

            // Arc representation of availability
            await this._context.BeginPathAsync();
            await this._context.MoveToAsync(65,180);
            await this._context.SetFillStyleAsync(FillBackgroundColor);
            await this._context.ArcAsync(125, 180, 60, Math.PI, 0, false);
            await this._context.ArcAsync(125, 180, 40, 0, Math.PI, true);
            await this._context.ClosePathAsync();
            await this._context.StrokeAsync();
            await this._context.FillAsync();

            // Select colors for graph depending on Availability
            if (Availability < 0.60) 
            {
                await this._context.SetFillStyleAsync(FillRed);
            }
            else if(Availability < 0.85)
            {
                await this._context.SetFillStyleAsync(FillYellow);
            }
            else
            {
                await this._context.SetFillStyleAsync(FillGreen);
            }

            // fill the arc with availability
            await this._context.BeginPathAsync();
            await this._context.MoveToAsync(65, 180);
            await this._context.ArcAsync(125, 180, 60, Math.PI, (Math.PI + Math.PI * Availability), false);
            await this._context.ArcAsync(125, 180, 40, (Math.PI + Math.PI * Availability), Math.PI, true);
            await this._context.ClosePathAsync();
            await this._context.FillAsync();
            
            // Text representation of availability
            await this._context.SetFillStyleAsync(RealTimeFontColor);
            await this._context.SetFontAsync(AvailabilityLabelFont);
            await this._context.FillTextAsync("A = ", 15, 160);
            await this._context.FillTextAsync( (Availability*100).ToString() + " %", 98, 175); 

        }

        private string CalculateDowntimeTimer(DateTime time)
        {
            TimeSpan outputTime = DateTime.UtcNow - time;

            string outputString = outputTime.ToString(@"hh\:mm\:ss", System.Globalization.CultureInfo.InvariantCulture);
            if(outputTime.Days >= 1)
            {
                outputString = outputTime.ToString(@"d\.hh\:mm\:ss", System.Globalization.CultureInfo.InvariantCulture);
            }

            //string outputString = $"{Math.Truncate(outputTime.TotalHours)}:{outputTime.Minutes}:{outputTime.Seconds}";
            
            // string outputString = String.Format("{0:c}", outputTime);

            return outputString;
        }
        /*
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
*/
    }
}