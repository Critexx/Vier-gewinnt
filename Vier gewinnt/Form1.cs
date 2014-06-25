using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vier_gewinnt
{
    public partial class Form1 : Form
    {
        GameHandler GameHandler;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            GameHandler = new GameHandler();
            GameHandler.NewGame(this, 7, 6, 70, 155, 100);
            label1.Visible = false;
            label1.Text = "Gewinn Label";
            label3.Text = "Rot";
            label3.ForeColor = System.Drawing.Color.Red;
            label3.Visible = true;
            label2.Visible = true;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (GameHandler != null)
            {
                GameHandler.PlayerClick(e);
                if (GameHandler.GetTurn() == 1)
                {
                    label3.Text = "Rot";
                    label3.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    label3.Text = "Gelb";
                    label3.ForeColor = System.Drawing.Color.Yellow;
                }
                if (GameHandler.GameFinished())
                {
                    if (GameHandler.GetWinner() == 0)
                        label1.Text = "Unentschieden!";
                    if (GameHandler.GetWinner() == 1)
                        label1.Text = "Rot hat gewonnen!";
                    if (GameHandler.GetWinner() == 2)
                        label1.Text = "Gelb hat gewonnen!";
                    label1.Visible = true;
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            GameHandler = null;
        }
    }
}
