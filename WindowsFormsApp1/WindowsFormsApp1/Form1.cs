using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        List<int> id = new List<int>();
        sql sql = new sql();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            id.Clear();
            sql.opencon();
            OleDbDataReader dr = sql.reader("Select id from irgendwas");
            while (dr.Read())
            {
                id.Add(dr.GetInt32(0));
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            insert insert = new insert();
            insert.id = id;
            insert.ShowDialog();
            id.Add(insert.newid);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            delete delete = new delete();
            delete.id = id;
            delete.ShowDialog();
            id.Remove(delete.selectedid);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            update update = new update();
            update.id = id;
            update.ShowDialog();
          

        }
    }
    public class sql {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source = Database1.accdb");
        public void opencon()
        {
            con.Open();
        }
        public void closecon()
        {
            con.Close();
        }
        public OleDbDataReader reader(String sqlstatement)
        {
            return new OleDbCommand(sqlstatement, con).ExecuteReader();
        }
        public void insert(String id, String name)
        {
            con.Open();
            new OleDbCommand(String.Format("insert into irgendwas (id, Name) values ({0},'{1}')", id, name),con).ExecuteNonQuery();
        }
        public void delete(String id)
        {
            con.Open();
            new OleDbCommand(String.Format("delete * from irgendwas where id = {0}", id), con).ExecuteNonQuery();
        }
        public void update(String id, String name)
        {
            con.Open();
            new OleDbCommand(String.Format("update irgendwas set  name = '{1}' where id = {0}", id, name), con).ExecuteNonQuery();
        }
        }
}
