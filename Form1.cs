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
        Label label1;
        Label label2;
        Timer labelTimer;

        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
            InitializeGrid();
            PutRandomIcons();
            InitializeTimer();
        }

        private void InitializeGrid()
        {
            this.DoubleBuffered = true;
            this.Width = 400;
            this.Height = 400;

            tlayoutGrid.BackColor = Color.Red;
            tlayoutGrid.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetDouble;

            AddLabelsToGrid();

            //tlayoutGrid.Controls.Add(new Label { Text = "Type:", Anchor = AnchorStyles.Left, AutoSize = true }, 0, 0);

            //SDFGHJCB
        }

        private void InitializeTimer()
        {
            labelTimer = new Timer();
            labelTimer.Interval = 1000;
            labelTimer.Tick += new EventHandler(CheckIfEqual);

        }

        private void CheckIfEqual(object sender, EventArgs e)
        {
            labelTimer.Stop();
            if (label1.Text == label2.Text)
            {
                label1.ForeColor = Color.Green;
                label2.ForeColor = Color.Green;
                label1.Click -= Label_Click;
                label2.Click -= Label_Click;
                label1 = null;
                label2 = null;
            }
            else
            {
                label1.ForeColor = tlayoutGrid.BackColor;
                label2.ForeColor = tlayoutGrid.BackColor;
                label1 = null;
                label2 = null;
            }
            CheckWin();
        }

        private void CheckWin()
        {
            int greenCount = 0;
            foreach (Label label in tlayoutGrid.Controls)
            {
                if (label.ForeColor == Color.Green)
                {
                    greenCount++;

                }
            }
            if (greenCount == 16)
            {
                MessageBox.Show("You Win!");
                PutRandomIcons();
            }

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
                        AutoSize = false,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Webdings", 72, FontStyle.Bold),                       
                    };
                    tlayoutGrid.Controls.Add(cellLabel, c, r);
                }
            }
        }

        private void Label_Click(object sender, EventArgs e)
        {
            if(labelTimer.Enabled == true)
            {
                return;
            }
            Label label = (Label)sender;
            if(label1 == null)
            {
                label1 = label;
            }
            else
            {
                label2 = label;
            }
            label.ForeColor = Color.Black;

            if(label1 != null && label2 != null)
            {
                if(label1 == label2)
                {
                    label2 = null;
                    return;
                }
                labelTimer.Start();


            }

        }

        private void PutRandomIcons()
        {
            Label label;
            List<string> icons = new List<string>()
        {"S", "S", "D", "D", "F", "F", "G", "H", "J", "C", "M", "G", "H", "J", "C", "M" };

            for (int i = 0; i < 16; i++)
            {
                int randomIndex = rand.Next(0, icons.Count);
                label = (Label)tlayoutGrid.Controls[i];
                label.Text = icons[randomIndex];
                label.ForeColor = tlayoutGrid.BackColor;
                label.Click += new EventHandler(Label_Click);
                icons.Remove(icons[randomIndex]);
            }


        }
    }
}
