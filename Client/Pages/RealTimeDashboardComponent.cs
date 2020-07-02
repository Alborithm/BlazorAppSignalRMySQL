using Blazor.Extensions;
using Blazor.Extensions.Canvas.Canvas2D;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using BlazorSignalRApp.Shared.Models.OEE;
using System.Collections.Generic;

namespace BlazorSignalRApp.Client.Pages
{
    public class RealTimeDashboardComponent : ComponentBase
    {
        private Canvas2DContext _context;

        protected BECanvasComponent _canvasReference;

        public List<RealTime> equipmentList;

        //public RealTimeDashboardComponent _componentReference;

        //public RealTimeDashboardComponent()
        //{
        //    _componentReference = this;
        //}
        protected List<BECanvasComponent> _canvasList = new List<BECanvasComponent>() {null,null,null};

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            int i = 0;
            foreach (RealTime equipment in equipmentList)
            {
                this._context = await this._canvasList[i].CreateCanvas2DAsync();
                //await this._canvasReference.CreateCanvas2DAsync();
                i++;

                string statusColor;
                string lineName = equipment.LineName;
                string opName = equipment.OpName;

                if (equipment.Available == true)
                {
                    statusColor = "rgb(0, 179, 0)";
                }
                else
                {
                    statusColor = "rgb(255, 0, 0)";
                }

                await this._context.SetFillStyleAsync(statusColor);
                await this._context.FillRectAsync(10, 10, 280, 140);

                await this._context.SetFontAsync("32px helvetica");
                await this._context.SetFillStyleAsync("rgb(0, 0, 0)");
                await this._context.FillTextAsync(string.Format("{0} - {1}", equipment.LineName, equipment.OpName), 12, 44);
            }
            /*
            this._context = await this._canvasReference.CreateCanvas2DAsync();

            string statusColor;
            string lineName;
            string opName;

            if (equipmentList[0].Available == true)
            {
                statusColor = "rgb(0, 179, 0)";
            }
            else
            {
                statusColor = "rgb(255, 0, 0)";
            }

            await this._context.SetFillStyleAsync(statusColor);
            await this._context.FillRectAsync(10, 10, 280, 140);

            await this._context.SetFillStyleAsync("rgba(0, 0, 200, 0.5)");
            await this._context.FillRectAsync(30, 30, 50, 50);

            await this._context.SetFontAsync("32px serif");
            await this._context.SetFillStyleAsync("rgb(0, 0, 0)");
            await this._context.FillTextAsync("Línea 1 operación 10", 12, 44);
            */
        }
    }
}