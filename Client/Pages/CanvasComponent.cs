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
        protected BECanvasComponent _canvasReference;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            this._context = await this._canvasReference.CreateCanvas2DAsync();

            string LineName = "Line X";
            string OperationName = "Operation Y";
            double Availability = 0.85;
            string TimeToRepair = "00:00:00";
            string TotalDowntime = "00:00:00";
            bool Available = false;

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
    }
}