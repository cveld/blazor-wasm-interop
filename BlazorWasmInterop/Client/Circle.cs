using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssembly.Browser.DOM;

namespace BlazorWasmInterop.Client
{
    public class Circle
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Radius { get; set; }
        public double DeltaX { get; set; }
        public double DeltaY { get; set; }

        public Circle(double x, double y, double dx, double dy, double radius)
        {
            X = x;
            Y = y;
            DeltaX = dx;
            DeltaY = dy;
            Radius = radius;
        }

        public void Draw(CanvasRenderingContext2D ctx)
        {
            ctx.BeginPath();
            ctx.Arc(X, Y, Radius, 0, Math.PI * 2, false);
            ctx.StrokeStyle = "blue";
            ctx.Stroke();
            //ctx.Fill();
            ctx.ClosePath();

        }

        public void Update(CanvasRenderingContext2D ctx, double screenWidth, double screenHeight)
        {
            if (X + Radius > screenWidth || X - Radius < 0)
            {
                DeltaX = -DeltaX;
            }

            if (Y + Radius > screenHeight || Y - Radius < 0)
            {
                DeltaY = -DeltaY;
            }
            X += DeltaX;
            Y += DeltaY;

            Draw(ctx);
        }

    }
}
