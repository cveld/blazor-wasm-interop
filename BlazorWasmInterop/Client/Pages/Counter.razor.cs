using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using WebAssembly;
using WebAssembly.Browser.DOM;

namespace BlazorWasmInterop.Client.Pages
{
    public partial class Counter
    {
        private static Random random = new Random((int)DateTime.Now.Ticks);
        private static Window window;
        private static CanvasRenderingContext2D ctx;
        static double screenWidth = 0;
        static double screenHeight = 0;
        static Circle[] circles = null;

        public void TestInterop()
        {            
            //JSObject domBrowserInterface = (JSObject)((JSObject)Runtime.GetGlobalObject("WebAssembly_Browser_DOM")).GetObjectProperty("prototype");

            var document = Web.Document;

            var head = document.QuerySelector<HTMLHeadElement>("head");
            var style = document.CreateElement<HTMLStyleElement>();
            style.InnerHtml = "body { margin: 0; }";
            head.AppendChild(style);

            // Get the canvas object
            var canvas = document.QuerySelector<HTMLCanvasElement>("canvas");
            // Obtain a reference to the canvas's 2D context
            ctx = canvas.GetContext2D();

            window = Web.Window;

            // resize the canvas 
            canvas.Width = screenWidth = window.InnerWidth;
            canvas.Height = screenHeight = window.InnerHeight;

            circles = new Circle[100];

            for (int c = 0; c < circles.Length; c++)
            {
                var radius = 30;
                var x = random.NextDouble() * (screenWidth - radius * 2) + radius;
                var y = random.NextDouble() * (screenHeight - radius * 2) + radius;
                var dx = (random.NextDouble() - 0.5d);// * 8;
                var dy = (random.NextDouble() - 0.5d);// * 8;

                circles[c] = new Circle(x, y, dx, dy, radius);

            }

            // make sure we start the animation
            Animate();
        }

        public static void Animate(double time = 0)
        {
            window.RequestAnimationFrame(Animate);

            ctx.ClearRect(0, 0, screenWidth, screenHeight);

            for (int c = 0; c < circles.Length; c++)
            {

                circles[c].Update(ctx, screenWidth, screenHeight);

            }


        }



        [JSInvokable]
        public void CallFromJs(string s)
        {

        }
    }
}
