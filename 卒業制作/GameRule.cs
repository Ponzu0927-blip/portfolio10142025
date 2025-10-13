using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Data.SQLite;

namespace 卒業制作
{
    public partial class GameRule : Form
    {
        Game game;
        Rule rule;
        public GameRule()
        {
            InitializeComponent();
            this.game = new Game();
            this.rule = new Rule();

            // ボタンの境界線を消す
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;

            // ボタンを丸くする
            int diameter = Math.Min(button1.Width, button1.Height);
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, diameter, diameter);
            button1.Region = new Region(path);

            // サイズ変更時にも丸くする場合は以下を追加
            button1.Resize += (s, e) =>
            {
                int d = Math.Min(button1.Width, button1.Height);
                GraphicsPath p = new GraphicsPath();
                p.AddEllipse(0, 0, d, d);
                button1.Region = new Region(p);
            };
        }

        private void Gamestart(object sender, EventArgs e)
        {
            game.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rule.Show();
        }
    }
}
