using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vier_gewinnt
{
    class VierGewinnt
    {
        // ---------- Eigenschaften ----------
        private int[,] Maparray;
        private int TurnCount = 0;      // Anzahl gespielte Runden, für Unentschieden beim letzten Move nötig
        private int _Turn;          // Welcher Spieler dran ist (1 = Spieler 1, 2 = Spieler 2)
        public int Turn
        {
            get { return _Turn; }
        }
        private bool _GameFinished;
        public bool GameFinished
        {
            get { return _GameFinished; }
        }
        private int _Winner = 0;
        public int Winner          //  (1 = Spieler 1, 2 = Spieler 2)
        {
            get { return _Winner; }
        }
        // ---------- Konstruktor ----------
        public VierGewinnt(int aFieldCountX, int aFieldCountY)
        {
            Maparray = new int[aFieldCountX, aFieldCountY];
            _Turn = 1;
            _GameFinished = false;
        }

        // ---------- Methoden ----------
        public int Move(int aFieldX)        
        {
            int FieldY = -1;
            if (!GameFinished)
            {               
                for (int i = Maparray.GetLength(1) - 1; i >= 0; i--) // Durch y interrieren
                {
                    if (Maparray[aFieldX - 1, i] == 0)
                    {
                        Maparray[aFieldX - 1, i] = _Turn;
                        TurnCount++;
                        FieldY = i + 1;
                        CheckWin(aFieldX, FieldY);
                        if (_Turn == 1)
                            _Turn = 2;
                        else
                            _Turn = 1;
                        return FieldY;
                    }
                }
            }
            return FieldY;                 
        }

        // Gewinn Methode
        public bool CheckWin(int aFieldX, int aFieldY)
        {
            int TokenCounter = 0;
            // Der vom Spieler gesetzte Stein
            int LastMoveFieldX = aFieldX - 1;
            int LastMoveFieldY = aFieldY - 1;
            // Rand der Map
            int MapLastRowX = (Maparray.GetLength(0)-1);
            int MapLastRowY = (Maparray.GetLength(1)-1);


            // Check Nordost - Südwest
            for (int i = 1; i <= 3; i++)
            {
                if (((LastMoveFieldX + i) <= MapLastRowX) && ((LastMoveFieldY - i) >= 0))
                {
                    if (Maparray[LastMoveFieldX + i, LastMoveFieldY - i] == Turn)
                    {
                        TokenCounter++;
                    }   
                    else
                    {
                        break;
                    }
                }
            }
            if (TokenCounter >= 3)
            {
                _GameFinished = true;
                _Winner = Turn;
                return true;
            }
            for (int i = 1; i <= 3; i++)
            {
                if (((LastMoveFieldX - i) >= 0) && ((LastMoveFieldY + i) <= MapLastRowY))
                {
                    if (Maparray[LastMoveFieldX - i, LastMoveFieldY + i] == Turn)
                    {
                        TokenCounter++;
                        if (TokenCounter >= 3)
                        {
                            _GameFinished = true;
                            _Winner = Turn;
                            return true;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            // Check Ost - West
            TokenCounter = 0;
            for (int i = 1; i <= 3; i++)
            {
                if ((LastMoveFieldX + i) <= MapLastRowX)
                {
                    if (Maparray[LastMoveFieldX + i, LastMoveFieldY] == Turn)
                    {
                        TokenCounter++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (TokenCounter >= 3)
            {
                _GameFinished = true;
                _Winner = Turn;
                return true;
            }
            for (int i = 1; i <= 3; i++)
            {
                if ((LastMoveFieldX - i) >= 0)
                {
                    if (Maparray[LastMoveFieldX - i, LastMoveFieldY] == Turn)
                    {
                        TokenCounter++;
                        if (TokenCounter >= 3)
                        {
                            _GameFinished = true;
                            _Winner = Turn;
                            return true;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            // Check Südost - Nordwest
            TokenCounter = 0;
            for (int i = 1; i <= 3; i++)
            {
                if (((LastMoveFieldX + i) <= MapLastRowX) && ((LastMoveFieldY + i) <= MapLastRowY))
                {
                    if (Maparray[LastMoveFieldX + i, LastMoveFieldY + i] == Turn)
                    {
                        TokenCounter++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (TokenCounter >= 3)
            {
                _GameFinished = true;
                _Winner = Turn;
                return true;
            }
            for (int i = 1; i <= 3; i++)
            {
                if (((LastMoveFieldX - i) >= 0) && ((LastMoveFieldY - i) >= 0))
                {
                    if (Maparray[LastMoveFieldX - i, LastMoveFieldY - i] == Turn)
                    {
                        TokenCounter++;
                        if (TokenCounter >= 3)
                        {
                            _GameFinished = true;
                            _Winner = Turn;
                            return true;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            
            // Check Süden
            TokenCounter = 0;
            for (int i = 1; i <= 3; i++)
            {
                if ((LastMoveFieldY + i) <= MapLastRowY)
                {
                    if (Maparray[LastMoveFieldX, LastMoveFieldY + i] == Turn)
                    {
                        TokenCounter++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (TokenCounter >= 3)
            {
                _GameFinished = true;
                _Winner = Turn;
                return true;
            }

            // Check Unentschieden
            if (TurnCount >= (Maparray.GetLength(0) * Maparray.GetLength(1)))
            {
                _GameFinished = true;
                _Winner = 0;
            }
            return false;
        }
    }
}
