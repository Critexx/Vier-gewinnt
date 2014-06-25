using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Vier_gewinnt
{
    class GameHandler
    {
        VierGewinnt Game;
        Map Map;

        public void NewGame(System.Windows.Forms.Form Form, int aFieldCountX, int aFieldCountY, int aFieldSize, int aLocationX, int aLocationY)
        {
            Map = new Map(Form, aFieldCountX, aFieldCountY, aFieldSize, aLocationX, aLocationY);
            Game = new VierGewinnt(aFieldCountX, aFieldCountY);   
        }

        ~GameHandler()
        {
            Map = null;
            Game = null;
        }

        public void PlayerClick(MouseEventArgs e)
        {
            if (Map.ValidMapCoordinate(e.X, e.Y))
            {
                int FieldX = Map.GetFieldX(e.X);
                int FieldY = Game.Move(FieldX);
                if (!(FieldY == -1))
                {
                    Color Color;
                    if (Game.Turn == 2)
                        Color = System.Drawing.Color.Red;
                    else
                        Color = System.Drawing.Color.Yellow;
                    Map.PrintCircle(Color, FieldX, FieldY);
                }
            }
        }

        public bool GameFinished()
        {
            return Game.GameFinished;
        }

        public int GetWinner()
        {
            return Game.Winner;
        }

        public int GetTurn()
        {
            return Game.Turn;
        }
    }
}
