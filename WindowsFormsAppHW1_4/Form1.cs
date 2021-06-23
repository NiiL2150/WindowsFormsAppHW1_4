using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppHW1_4
{
    public partial class Form1 : Form
    {
        int n = 0, x1 = 0, x2 = 0, y1 = 0, y2 = 0;
        const int minSize = 20;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            x1 = e.X;
            y1 = e.Y;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            x2 = e.X;
            y2 = e.Y;
            if(e.Button != System.Windows.Forms.MouseButtons.Left)
            {
                
            }
            else if ((x2 - x1 < minSize && x1 - x2 < minSize) || (y2 - y1 < minSize && y1 - y2 < minSize))
            {
                MessageBox.Show($"Can't spawn a button less than {minSize}x{minSize} in size", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DoubleClickButton button = new DoubleClickButton();
                button.Text = (++n).ToString();
                button.Name = $"button{n}";
                button.Enabled = true;
                button.Visible = true;
                this.Controls.Add(button);
                button.BringToFront();
                button.Size = new Size(x1 > x2 ? x1 - x2 : x2 - x1, y1 > y2 ? y1 - y2 : y2 - y1);
                button.Location = new Point(x1 > x2 ? x2 : x1, y1 > y2 ? y2 : y1);
                button.MouseDoubleClick += StaticButton_MouseDoubleClick;
                button.MouseUp += StaticButton_MouseUp;
            }
        }

        private void StaticButton_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Button button = sender as Button;
                Form1.ActiveForm.Controls.Remove(button);
            }
        }

        private void StaticButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                Button button = sender as Button;
                Form1.ActiveForm.Text = $"Size: {button.Size.Width}-{button.Size.Height}; Coords: {button.Location.X}-{button.Location.Y}";
            }
        }
    }
}
