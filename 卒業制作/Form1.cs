using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;

namespace 卒業制作
{
    public partial class Form1 : Form
    {
        int indx = 0;   //0:page1,1:page2(しんくん),2:page3(獅子神さん),3:page4(村雨先生),4:page5(黎明),5:page6(ゆみぴこ)
        Label label;
        GameRule rule;
        public Form1()
        {
            InitializeComponent();
            this.rule = new GameRule();
            
        }
     
        private void button1_Click(object sender, EventArgs e)
        {
            rule.Show();
        }

        private void labels_Click(object sender, EventArgs e)
        {
            // しんくん-label2-Tabpage2-TabIndex2  ラベルとTabpageとラベルのTabIndexプロパティの関連
            // 獅子神さん-label3-Tabpage3-TabIndex3
            // 村雨先生-label4-Tabpage4-TabIndex4
            // 黎明-label5-Tabpage5-TabIndex5
            // ゆみぴこ-label6-Tabpage6-TabIndex6
            label = (Label)sender;
            indx = label.TabIndex - 1;
            tabControl1.SelectedIndex = indx;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("https://x.com/itch_itch");
        }
    }
}
