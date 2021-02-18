using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KAFEM0.Temp
{
    
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Short and right on target
            string[] array = { "item1", "item2", "item3" };
            string output = string.Join("\n", array);
            MessageBox.Show(output);

            /*
            // For more extensibility.. 
            string output = string.Empty;
            string[] array = { "item1", "item2", "item3" };
            foreach (var item in array)
            {
                output += item + "\n";
            }

            MessageBox.Show(output);
            */
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Button button = new Button();
            button.Name = textBox1.Text;
            button.Text = textBox1.Text;
            flowLayoutPanel1.Controls.Add(button);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Button button = new Button();
            button.Name = textBox1.Text;
           
        //    flowLayoutPanel1.Controls.Remove();

        }
    }
}
