using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace 卒業制作
{
    public partial class Rule : Form
    {
        string constr;
        public Rule()
        {
            InitializeComponent();
            constr = @"Data Source= rulelist.sqlite; Version = 3";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "SELECT * FROM rulelist";
            DBExtract(str);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string str = $@"SELECT * FROM rulelist WHERE Role = '{textBox1.Text}'";
            DBExtract(str);
        }
        
        private void DBExtract(string sql)
        {
            using (SQLiteConnection con = new SQLiteConnection(constr))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                {
                    con.Open();
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dataGridView1.DataSource = dt;
                    }
                }
                con.Close();
            }
        }
        

    }
}
