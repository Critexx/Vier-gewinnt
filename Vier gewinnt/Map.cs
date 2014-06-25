using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Vier_gewinnt
{
    class Map
    {
        // ---------- Eigenschaften ----------
        private int LocationX;      // Fixpunkt der Map: linke obere Ecke
        private int LocationY;      // Fixpunkt der Map: linke obere Ecke
        private int FieldSize;      // Pixel eines Felds
        private int FieldCountX;    // Anzahl Felder Horizontal
        private int FieldCountY;    // Anzahl Felder Vertikal
        private Pen PenPlayground;
        private Graphics formGraphic;

        // ---------- Konstruktor ----------
        public Map(System.Windows.Forms.Form Form, int aFieldCountX, int aFieldCountY, int aFieldSize, int aLocationX, int aLocationY)
        {
            LocationX = aLocationX;
            LocationY = aLocationY;
            FieldSize = aFieldSize;
            FieldCountX = aFieldCountX;
            FieldCountY = aFieldCountY;
            
            PenPlayground = new System.Drawing.Pen(System.Drawing.Color.Black, 2);
            formGraphic = Form.CreateGraphics();
            formGraphic.Clear(System.Drawing.Color.Wheat);
            int LocationEndX = LocationX + FieldCountX * FieldSize;
            int LocationEndY = LocationY + FieldCountY * FieldSize;

            // Zeichnet die X Reihe  
            for (int i = 0; i < FieldCountY+1; i++)
            {
                formGraphic.DrawLine(PenPlayground, LocationX, LocationY + i * FieldSize, LocationEndX, LocationY + i * FieldSize);              
            }
            // Zeichnet die Y Reihe
            for (int i = 0; i < FieldCountX+1; i++)
            {
                formGraphic.DrawLine(PenPlayground, LocationX + i * FieldSize, LocationY, LocationX + i * FieldSize, LocationEndY);
            }
        }

        // ---------- Destruktor ----------
        ~Map()
        {
            PenPlayground.Dispose();
            formGraphic.Dispose();
        }      
  
        // ---------- Methods ----------
        public void PrintCircle(Color aColor, int aFieldCountX, int aFieldCountY)
        {
            int CircleRadius = FieldSize * 80 / 100; // Kreis 80% entspricht der Feldgrösse     

            // ((FieldSize - CircleRadius) / 2) bezweckt, dass der Kreis in der Mitte des Felds gezeichnet wird.
            int CircleLocationX = LocationX + (aFieldCountX - 1) * FieldSize + ((FieldSize - CircleRadius) / 2);    
            int CircleLocationY = LocationY + (aFieldCountY - 1) * FieldSize + ((FieldSize - CircleRadius) / 2);

            System.Drawing.SolidBrush BrushPlayground = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            formGraphic.FillEllipse(BrushPlayground, CircleLocationX -2, CircleLocationY-2, CircleRadius+4, CircleRadius+4); 
            BrushPlayground.Color = aColor;
            formGraphic.FillEllipse(BrushPlayground, CircleLocationX, CircleLocationY, CircleRadius, CircleRadius);  
            BrushPlayground.Dispose();
        }
        
        public int GetFieldX(int aX)
        {
            decimal Column = (decimal)(aX - LocationX) / FieldSize;
            return (int)Math.Ceiling(Column);
        }

        public bool ValidMapCoordinate(int aX, int aY)
        {
            return ((aX > LocationX) && (aX  < (LocationX + FieldCountX * FieldSize)) && (aY > LocationY) && (aY  < (LocationY + FieldCountY * FieldSize)));
        }
    }
}
