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
    public partial class insert : Form
    {
        public List<int> id = new List<int>();
        public int newid = 1;
        public insert()
        {
            InitializeComponent();
        }

        private void insert_Load(object sender, EventArgs e)
        {
            
            bool find = false;
            for(int i = 0; i < id.Count && find == false; i++)
            {
                if(id.Contains(newid))
                {
                    newid++; 
                }
                else
                {
                    find = true;
                }
            }
            textBox1.Text = newid.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
            {
                new sql().insert(textBox1.Text, textBox2.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Sie haben nichts eingegeben!");
            }
        }
    }
}
