using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class Form1 : Form
    {

        Random rand = new Random();
        List<string> icons = new List<string>()
        {"S", "S", "D", "D", "F", "F", "G", "H", "J", "C", "M", "G", "H", "J", "C", "M" };
        public Form1()
        {
            InitializeComponent();
            InitializeGrid();
            PutRandomIcons();
        }

        private void InitializeGrid()
        {
            this.DoubleBuffered = true;
            this.Width = 400;
            this.Height = 400;

            tlayoutGrid.BackColor = Color.LimeGreen;
            tlayoutGrid.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetDouble;

            AddLabelsToGrid();

            //tlayoutGrid.Controls.Add(new Label { Text = "Type:", Anchor = AnchorStyles.Left, AutoSize = true }, 0, 0);

            //SDFGHJCB
        }

        private void AddLabelsToGrid()
        {
            Label cellLabel;

            for (int c = 0; c < 4; c++)
            {
                for (int r = 0; r < 4; r++)
                {
                    cellLabel = new Label
                    {
                        Dock = DockStyle.Fill,
                        ForeColor = Color.Black,
                        AutoSize = false,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Text = " ",
                        Font = new Font("Webdings", 72, FontStyle.Bold),
                    };
                    tlayoutGrid.Controls.Add(cellLabel, c, r);
                }
            }
        }



        private void PutRandomIcons()
        {
            Label label;

            for(int i = 0; i < 16; i++)
            {
                int randomIndex = rand.Next(0, icons.Count);
                label = (Label)tlayoutGrid.Controls[i];
                label.Text = icons[randomIndex];
                icons.Remove(icons[randomIndex]);
            }


        }
    }
}
