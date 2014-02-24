using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Waits
{
    public class GameEngine
    {
        private IRenderer renderer;
        private int waitMsPerTick;
        public IList<IRenderable> itemsToRender;
         public GameEngine(IRenderer inputRenderer, List<IRenderable> items = null, int waitMs = 1000)
        {
            this.renderer = inputRenderer;
            this.waitMsPerTick = waitMs;

            if (items != null)
            {
                this.itemsToRender = items;
            }
            else
            {
                this.itemsToRender = new List<IRenderable>();
            }
        }

         public void Run()
         {
             while (true)
             {
                 renderer.RenderAll();

                 renderer.ClearQueue();

                 foreach (var item in this.itemsToRender)
                 {
                     renderer.EnqueueForRendering(item);
                 }

                 Thread.Sleep(this.waitMsPerTick);
             }
         }
    }
}
