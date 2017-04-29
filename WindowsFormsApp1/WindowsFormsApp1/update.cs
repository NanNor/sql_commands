using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class update : Form
    {
        public List<Int32> id = new List<int>();
        public update()
        {
            InitializeComponent();
        }

        private void update_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < id.Count; i++)
            {
                comboBox1.Items.Add(id[i]);
            }
            comboBox1.Sorted = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new sql().update(comboBox1.SelectedItem.ToString(), textBox1.Text);
        }
    }
}
