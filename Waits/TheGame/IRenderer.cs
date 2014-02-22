using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trial_1._0
{
    public interface IRenderer
    {
        void EnqueueForRendering(IRenderable obj); //Sets the image of the object on the field.

        void RenderAll(); //Outputs the drawn field.

        void ClearQueue(); //Gets the initial look of the field.
    }
}
