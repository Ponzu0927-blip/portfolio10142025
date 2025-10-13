using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace 卒業制作
{
    enum PokerHandRank
    {
        HighCard = 0,
        OnePair = 1,
        TwoPair = 2,
        ThreeCard = 3,
        FullHouse = 4,
        FourCard = 5,
        FiveCard = 6,
    }
    public partial class Game : Form
    {
        int[] dice = new int[5];
        int[] conDice = new int[5];
        bool canReroll = true;
        //int[] test = {1,1,3,4,5};
        //int[] contest = { 1, 1, 3, 4, 2 };
        Random rand = new Random();

        public Game()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResetDiceImages();
            RollMyDice();
            RollOpponentDice();

            // 振り直しを有効化
            canReroll = true;
            button2.Enabled = true;
            button1.Enabled = false; // ゲーム中は無効化
            button3.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RollMyDice();
            RollOpponentDice();

            // 振り直しは1回まで
            canReroll = false;
            button2.Enabled = false;
            button1.Enabled = false;
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox6.Visible = true;
            pictureBox7.Visible = true;
            pictureBox8.Visible = true;
            pictureBox9.Visible = true;
            pictureBox10.Visible = true;
            JudgePokerWinner();
            ResetDiceImages();
            button1.Enabled = true; // ゲーム終了後に再度プレイ可能に
            button2.Enabled = false; // 振り直しボタンは無効化
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
            button3.Enabled = false;
        }

        private void RollMyDice()
        {
            PictureBox[] boxes = { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5 };
            for (int i = 0; i < 5; i++)
            {
                dice[i] = rand.Next(1, 7); // 1から6までのランダムな数値を生成
                switch (dice[i])
                {
                    case 1:
                        boxes[i].Image = Properties.Resources.サイコロ9;
                        break;
                    case 2:
                        boxes[i].Image = Properties.Resources.サイコロ10;
                        break;
                    case 3:
                        boxes[i].Image = Properties.Resources.サイコロJ;
                        break;
                    case 4:
                        boxes[i].Image = Properties.Resources.サイコロQ;
                        break;
                    case 5:
                        boxes[i].Image = Properties.Resources.サイコロK;
                        break;
                    case 6:
                        boxes[i].Image = Properties.Resources.サイコロA;
                        break;
                }
            }
            // テスト用の固定値

            //PictureBox[] boxestest = { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5 };
            //for(int i =0; i<test.Length; i++)
            //{
            //    dice[i] = test[i]; // テスト用の固定値
            //    switch (test[i])
            //    {
            //        case 1:
            //            boxestest[i].Image = Properties.Resources.サイコロ9;
            //            break;
            //        case 2:
            //            boxestest[i].Image = Properties.Resources.サイコロ10;
            //            break;
            //        case 3:
            //            boxestest[i].Image = Properties.Resources.サイコロJ;
            //            break;
            //        case 4:
            //            boxestest[i].Image = Properties.Resources.サイコロQ;
            //            break;
            //        case 5:
            //            boxestest[i].Image = Properties.Resources.サイコロK;
            //            break;
            //        case 6:
            //            boxestest[i].Image = Properties.Resources.サイコロA;
            //            break;
            //    }
            //}
        }
        private void RollOpponentDice()
        {
            for (int i = 0; i < 5; i++)
            {
                PictureBox[] boxes1 = { pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10 };
                conDice[i] = rand.Next(1, 7); // 1から6までのランダムな数値を生成
                switch (conDice[i])
                {
                    case 1:
                        boxes1[i].Image = Properties.Resources.サイコロ9;
                        break;
                    case 2:
                        boxes1[i].Image = Properties.Resources.サイコロ10;
                        break;
                    case 3:
                        boxes1[i].Image = Properties.Resources.サイコロJ;
                        break;
                    case 4:
                        boxes1[i].Image = Properties.Resources.サイコロQ;
                        break;
                    case 5:
                        boxes1[i].Image = Properties.Resources.サイコロK;
                        break;
                    case 6:
                        boxes1[i].Image = Properties.Resources.サイコロA;
                        break;
                }
            }

            // テスト用の固定値

            //PictureBox[] boxes2 = { pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10 };
            //for (int i = 0; i < contest.Length; i++)
            //{
            //    conDice[i] = contest[i]; // テスト用の固定値
            //    switch (contest[i])
            //    {
            //        case 1:
            //            boxes2[i].Image = Properties.Resources.サイコロ9;
            //            break;
            //        case 2:
            //            boxes2[i].Image = Properties.Resources.サイコロ10;
            //            break;
            //        case 3:
            //            boxes2[i].Image = Properties.Resources.サイコロJ;
            //            break;
            //        case 4:
            //            boxes2[i].Image = Properties.Resources.サイコロQ;
            //            break;
            //        case 5:
            //            boxes2[i].Image = Properties.Resources.サイコロK;
            //            break;
            //        case 6:
            //            boxes2[i].Image = Properties.Resources.サイコロA;
            //            break;
            //    }
            //}
        }

        private string GetPokerHandRankKanji(PokerHandRank rank)
        {
            switch (rank)
            {
                case PokerHandRank.FiveCard:
                    return "5カード";
                case PokerHandRank.FourCard:
                    return "4カード";
                case PokerHandRank.FullHouse:
                    return "フルハウス";
                case PokerHandRank.ThreeCard:
                    return "3カード";
                case PokerHandRank.TwoPair:
                    return "2ペア";
                case PokerHandRank.OnePair:
                    return "1ペア";
                default:
                    return "ブタ";
            }
        }
        private PokerHandRank GetPokerHandRank(int[]dice)
        {
            var counts = new int[7]; // サイコロの目は1から6までなので、インデックス0は使用しない
            foreach (var d in dice)
            {
                counts[d]++;
            }

            bool isStraight = false;
            for (int i = 1; i <= 2; i++)
            {
                if (counts[i] == 1 && counts[i + 1] == 1 && counts[i + 2] == 1 && counts[i + 3] == 1 && counts[i + 4] == 1)
                {
                    isStraight = true;
                }
            }
            int maxCount = counts.Max();
            int pairCount = counts.Count(c => c == 2);

            if(maxCount == 5) return PokerHandRank.FiveCard;
            if (maxCount == 4) return PokerHandRank.FourCard;
            if (maxCount == 3 && pairCount == 1) return PokerHandRank.FullHouse;
            if(maxCount == 3) return PokerHandRank.ThreeCard;
            if (pairCount == 2) return PokerHandRank.TwoPair;
            if (pairCount == 1) return PokerHandRank.OnePair;
            return PokerHandRank.HighCard;
        }
        private void JudgePokerWinner()
        {
            var myRank = GetPokerHandRank(dice);
            var conRank = GetPokerHandRank(conDice);

            string myHand = GetPokerHandRankKanji(myRank);
            string conHand = GetPokerHandRankKanji(conRank);

            string result = "";
            if (myRank > conRank)
            {
                result = "あなたの勝ちです！";
            }
            else if (myRank < conRank)
            {
                result = "コンピュータの勝ちです！";
            }
            else
            {
                // 役が同じ場合、サイコロの目を降順で比較
                int[]mySorted = dice.OrderByDescending(x => x).ToArray();
                int[]conSorted = conDice.OrderByDescending(x => x).ToArray();
                string myRate = string.Join(",", mySorted);
                string conRate = string.Join(",", conSorted);

                // 目の強さで判定
                bool decided = false;
                for(int i = 0; i < 5; i++)
                {
                    if(mySorted[i] > conSorted[i])
                    {
                        result = $"あなたの勝ちです！\n(目の強さ:{myRate} > {conRate})";
                        decided = true;
                        break;
                    }
                    else if(mySorted[i] < conSorted[i])
                    {
                        result = $"コンピュータの勝ちです！\n(目の強さ:{myRate} < {conRate})";
                        decided = true;
                        break;
                    }
                }
                if(!decided)
                {
                    result = $"引き分けです！\n(目の強さ:{myRate} = {conRate})";
                }
            }
            MessageBox.Show($"あなたの役: {myHand}\nコンピュータの役: {conHand}\n{result}","勝敗判定");
            MessageBox.Show("もう一度プレイするには、サイコロを振るボタンを押してください。","再戦");
        }
        private void ResetDiceImages()
        {
            PictureBox[] myBoxes = { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5 };
            PictureBox[] conBoxes = { pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10 };
            foreach (var box in myBoxes)
            {
                box.Image = null;
            }
            foreach (var box in conBoxes)
            {
                box.Image = null;
            }
        }

    }
}