using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        //int[] test = { 6, 6, 6, 1, 5 };
        //int[] contest = { 5, 5, 5, 4, 2 };
        Random rand = new Random();
        bool[] keepDice = new bool[5];  // tureならそのサイコロは残す


        public Game()
        {
            InitializeComponent();
            pictureBox1.Click += (s, e) => ToggleKeepDice(0, pictureBox1);
            pictureBox2.Click += (s, e) => ToggleKeepDice(1, pictureBox2);
            pictureBox3.Click += (s, e) => ToggleKeepDice(2, pictureBox3);
            pictureBox4.Click += (s, e) => ToggleKeepDice(3, pictureBox4);
            pictureBox5.Click += (s, e) => ToggleKeepDice(4, pictureBox5);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResetDiceImages();
            RollMyDice();
            RollOpponentDice();
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            pictureBox4.Visible = true;
            pictureBox5.Visible = true;

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
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
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
                if (!keepDice[i]) // 残さないダイスだけ振り直す
                {
                    dice[i] = rand.Next(1, 7); // 1から6までのランダムな数値を生成
                }
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
            //for (int i = 0; i < test.Length; i++)
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
        private PokerHandRank GetPokerHandRank(int[] dice)
        {
            var counts = new int[7]; // サイコロの目は1から6までなので、インデックス0は使用しない
            foreach (var d in dice)
            {
                counts[d]++;
            }

            int maxCount = counts.Max();
            int pairCount = counts.Count(c => c == 2);

            if (maxCount == 5) return PokerHandRank.FiveCard;
            if (maxCount == 4) return PokerHandRank.FourCard;
            if (maxCount == 3 && pairCount == 1) return PokerHandRank.FullHouse;
            if (maxCount == 3) return PokerHandRank.ThreeCard;
            if (pairCount == 2) return PokerHandRank.TwoPair;
            if (pairCount == 1) return PokerHandRank.OnePair;
            return PokerHandRank.HighCard;
        }

        private int[] GetRankValues(int[] dice, PokerHandRank rank)
        {
            var counts = new int[7];
            foreach (var d in dice) counts[d]++;
            List<int> result = new List<int>();

            switch (rank)
            {
                case PokerHandRank.FiveCard:
                    // 5枚揃いの目
                    result.Add(Array.IndexOf(counts, 5));
                    break;
                case PokerHandRank.FourCard:
                    // 4枚揃いの目＋残り
                    result.Add(Array.IndexOf(counts, 4));
                    result.Add(Array.IndexOf(counts, 1));
                    break;
                case PokerHandRank.FullHouse:
                    // 3枚揃いの目＋2枚揃いの目
                    result.Add(Array.IndexOf(counts, 3));
                    result.Add(Array.IndexOf(counts, 2));
                    break;
                case PokerHandRank.ThreeCard:
                    // 3枚揃いの目＋残り（大きい順）
                    result.Add(Array.IndexOf(counts, 3));
                    for (int i = 6; i >= 1; i--)
                        if (counts[i] == 1) result.Add(i);
                    break;
                case PokerHandRank.TwoPair:
                    // 2ペア（大きい順）＋残り
                    var pairs = new List<int>();
                    int single = 0;
                    for (int i = 6; i >= 1; i--)
                    {
                        if (counts[i] == 2) pairs.Add(i);
                        if (counts[i] == 1) single = i;
                    }
                    result.AddRange(pairs);
                    result.Add(single);
                    break;
                case PokerHandRank.OnePair:
                    // ペア＋残り（大きい順）
                    int pair = 0;
                    for (int i = 6; i >= 1; i--)
                    {
                        if (counts[i] == 2) pair = i;
                    }
                    result.Add(pair);
                    for (int i = 6; i >= 1; i--)
                        if (counts[i] == 1) result.Add(i);
                    break;
                case PokerHandRank.HighCard:
                    // 全て大きい順
                    for (int i = 6; i >= 1; i--)
                        for (int j = 0; j < counts[i]; j++)
                            result.Add(i);
                    break;
            }
            return result.ToArray();
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
                // 役が同じ場合、役ごとの出目で比較
                int[] myRankValues = GetRankValues(dice, myRank);
                int[] conRankValues = GetRankValues(conDice, conRank);
                string myRate = string.Join(",", myRankValues);
                string conRate = string.Join(",", conRankValues);

                bool decided = false;
                for (int i = 0; i < myRankValues.Length; i++)
                {
                    if (i >= conRankValues.Length) break;
                    if (myRankValues[i] > conRankValues[i])
                    {
                        result = $"あなたの勝ちです！\n(役の出目:{myRate} > {conRate})";
                        decided = true;
                        break;
                    }
                    else if (myRankValues[i] < conRankValues[i])
                    {
                        result = $"コンピュータの勝ちです！\n(役の出目:{myRate} < {conRate})";
                        decided = true;
                        break;
                    }
                }
                if (!decided)
                {
                    result = $"引き分けです！\n(役の出目:{myRate} = {conRate})";
                }
            }
            MessageBox.Show($"あなたの役: {myHand}\nコンピュータの役: {conHand}\n{result}", "勝敗判定");
            MessageBox.Show("もう一度プレイするには、サイコロを振るボタンを押してください。", "再戦");
        }
        private void ResetDiceImages()
        {
            PictureBox[] myBoxes = { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5 };
            PictureBox[] conBoxes = { pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10 };
            foreach (var box in myBoxes)
            {
                box.Image = null;
                box.BorderStyle = BorderStyle.None;
            }
            foreach (var box in conBoxes)
            {
                box.Image = null;
            }
            for(int i = 0; i < keepDice.Length; i++)
            {
                keepDice[i] = false;
            }
        }



        private void ToggleKeepDice(int index, PictureBox box)
        {
            keepDice[index] = !keepDice[index];
            box.BorderStyle = keepDice[index] ? BorderStyle.Fixed3D : BorderStyle.None;
        }
    }
}