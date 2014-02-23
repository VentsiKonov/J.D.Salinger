using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waits
{
    public class ConsoleRenderer : IRenderer
    {
       int renderContextMatrixRows;
       int renderContextMatrixCols;
       char[,] renderContextMatrix;

       public ConsoleRenderer(int visibleConsoleRows, int visibleConsoleCols)
       {
           //Sets initial field by the passed dimensions.
           renderContextMatrix = new char[visibleConsoleRows, visibleConsoleCols];

           this.renderContextMatrixRows = renderContextMatrix.GetLength(0);
           this.renderContextMatrixCols = renderContextMatrix.GetLength(1);

           this.ClearQueue(); //Used to get the initial field.
       }

       public void EnqueueForRendering(IRenderable obj)
       {
           //Each object implementing the interface IRenderable is represented as a image which is drawn over
           //the initial field. 
           char[,] objImage = obj.GetImage();

           int imageRows = objImage.GetLength(0);
           int imageCols = objImage.GetLength(1);

           MatrixCoords objTopLeft = obj.GetTopLeftCoordOfPosition();

           int lastRow = Math.Min(objTopLeft.Row + imageRows, this.renderContextMatrixRows);
           int lastCol = Math.Min(objTopLeft.Col + imageCols, this.renderContextMatrixCols);

           for (int row = obj.GetTopLeftCoordOfPosition().Row; row < lastRow; row++)
           {
               for (int col = obj.GetTopLeftCoordOfPosition().Col; col < lastCol; col++)
               {
                   if (row >= 0 && row < renderContextMatrixRows &&
                       col >= 0 && col < renderContextMatrixCols)
                   {
                       renderContextMatrix[row, col] = 
                           objImage[row - obj.GetTopLeftCoordOfPosition().Row, col - obj.GetTopLeftCoordOfPosition().Col];
                   }
               }
           }
       }

       public void RenderAll()
       {
           //Pasing the filed as a string to the console.
           Console.SetCursorPosition(0, 0);

           for (int row = 0; row < this.renderContextMatrixRows; row++)
           {
               for (int col = 0; col < this.renderContextMatrixCols; col++)
               {
                   char symbol = this.renderContextMatrix[row, col];
                   ColorSymbol(symbol);
                   Console.Write(symbol);
               }
               Console.WriteLine();
           }

       }

       private void ColorSymbol(char symbol)
       {
           switch (symbol)
           {
               case '\u2591':
                   Console.ForegroundColor = ConsoleColor.Red;
                   break;
               case '\u2593': 
                   Console.ForegroundColor = ConsoleColor.DarkCyan;
                   break;
               case (char)64:
                   Console.ForegroundColor = ConsoleColor.DarkGreen;
                   break;
               default:
                   Console.ForegroundColor = ConsoleColor.DarkGray;
                   break;
           }
       }

       public void ClearQueue()
       {
           //Sets the field to its initial image.
           for (int row = 0; row < this.renderContextMatrixRows; row++)
           {
               for (int col = 0; col < this.renderContextMatrixCols; col++)
               {
                   this.renderContextMatrix[row, col] = '-';
               }
           }
       }

       
    }
}
