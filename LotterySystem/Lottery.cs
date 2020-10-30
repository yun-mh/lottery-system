using System;
using System.Collections.Generic;
using System.IO;
using System.Timers;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;

namespace LotterySystem
{
    /// <summary>
    /// 抽選を行うためのクラス
    /// </summary>
    public class Lottery
    {
        public Group all;
        public Group white;
        public Group black;
        public List<Group> winners;
        public TextBox selectedFile;
        public TextBox selectedBlack;
        public TextBox selectedWhite;
        public int sumTotal;
        public Boolean isChecked;

        /// <summary>
        /// 抽選クラスのコンストラクタ
        /// </summary>
        /// <param name="all">応募者全員のグループ</param>
        /// <param name="black">ブラックリストのグループ</param>
        /// <param name="white">ホワイトリストのグループ</param>
        /// <param name="winnerGroup">各順位グループの集まり</param>
        /// <param name="selectedFile">抽選対象者ファイルのパスが含まれるテキストボックス</param>
        /// <param name="selectedBlack">ブラックリストファイルのパスが含まれるテキストボックス</param>
        /// <param name="selectedWhite">ホワイトリストファイルのパスが含まれるテキストボックス</param>
        /// <param name="sumTotal">人数配分の入力欄に入った数値の合計</param>
        /// <param name="isChecked">重複のフラグ</param>
        public Lottery(Group all, Group black, Group white, WinnerGroup winnerGroup, TextBox selectedFile, TextBox selectedBlack, TextBox selectedWhite, int sumTotal, Boolean isChecked)
        {
            this.all = all;
            this.black = black;
            this.white = white;
            this.winners = winnerGroup.groupsList;
            this.selectedFile = selectedFile;
            this.selectedBlack = selectedBlack;
            this.selectedWhite = selectedWhite;
            this.sumTotal = sumTotal;
            this.isChecked = isChecked;
        }

        /// <summary>
        /// 抽選を行うメソッド
        /// </summary>
        async public Task doLottery()
        {
            // 応募者全員のCSVファイルからデータを取得し応募者グループに入れる
            string filePath = this.selectedFile.Text;
            this.all.insertApplicantsFromCsv(filePath);

            // ブラックリストが設定された場合、応募者グループからブラックリスト上の応募者を除く
            if (!this.selectedBlack.Text.Equals(""))
            {
                string blacklistPath = this.selectedBlack.Text;

                try
                {
                    this.black.insertApplicantsFromCsv(blacklistPath, this.all);
                }
                catch (IOException)
                {
                    // 同じ名前のファイルが開いているときの例外処理
                    MessageBox.Show("読み込みしようとするCSVファイルが開いている状態です。ファイルを閉めてからもう一回試してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // ホワイトリストが設定された場合、ホワイトリスト上の応募者を等級別のグループに挿入する
            if (!this.selectedWhite.Text.Equals(""))
            {
                string whitelistPath = this.selectedWhite.Text;

                try
                {
                    this.white.insertApplicantsFromCsv(whitelistPath);
                }
                catch (IOException)
                {
                    // 同じ名前のファイルが開いているときの例外処理
                    MessageBox.Show("読み込みしようとするCSVファイルが開いている状態です。ファイルを閉めてからもう一回試してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ブラックリストとホワイトリストでの共通応募者がいる場合の例外処理
                if (!this.selectedBlack.Text.Equals(""))
                {
                    foreach (Applicant applicant in this.black)
                    {
                        if (this.white.Exists(el => el.number.Equals(applicant.number)))
                        {
                            throw new Exception();
                        }
                    }
                }
            }

            // 重複可否を判断して全体の抽選を行う
            if (this.isChecked == false)
            {
                await playWithoutDuplicate();
            }
            else
            {
                await playWithDuplicate();
            }
        }

        /// <summary>
        /// 重複なしで事前にホワイトリストのみ抽選を行っておく関数
        /// </summary>
        public void playWhiteFirst()
        {
            int acc = 0; // 各等級の配分数を積み重ねるための変数
            int total = 0; // ホワイトリストの抽選処理を繰り返す際に利用する変数

            foreach (Group group in this.winners)
            {
                // 割合で計算した各等級の配分数(少数)
                float amountByProb = (float)group.number / sumTotal * white.Count;
                
                // 上記のコードで得た結果を整数化する
                int roundedAmount;
                if (group.rank != 1)
                {
                    roundedAmount = (int)Math.Round(amountByProb);
                    acc += roundedAmount;
                }
                else // 1等のみ、ホワイトリストの全体数から各等級の配分数を積み重ねた数を引いた結果を1等の配分数とする
                {
                    roundedAmount = white.Count - acc;
                }

                // ホワイトリストを元に等級別のグループに入れる(事前抽選)
                for (int i = total; i < roundedAmount + total; i++)
                {
                    group.Add(white[i]);
                }
                total += roundedAmount;
            }
        }

        /// <summary>
        /// 重複なしで全体の抽選を行う関数
        /// </summary>
        async public Task playWithoutDuplicate()
        {
            // ホワイトリストが存在する場合、ホワイトリストだけの抽選を先に行う
            if (this.white.Count > 0)
            {
                // ホワイトリストの抽選は別で行うため、全体から除く
                foreach (Applicant applicant in this.white)
                {
                    this.all.RemoveAll(el => el.number.Equals(applicant.number));
                }

                // ホワイトグループのデータ数と当選対象者数を比較する
                if (this.sumTotal <= this.white.Count)
                {
                    // ホワイトグループの人数が当選対象者数以上の場合、当選対象者をホワイトグループに限定して抽選する
                    this.all = this.white;
                }
                else
                {
                    // ホワイトグループの人数が当選対象者数より少ない場合、等級別に当選者を配分する
                    this.white.shuffleItems();
                    playWhiteFirst();
                }
            }

            this.all.shuffleItems();

            // 応募者全員に対する抽選処理
            Random random = new Random();

            int defaultNum;

            foreach (Group group in this.winners)
            {
                defaultNum = group.Count; // 等級別のグループリストの要素数を取得する
                
                // 抽選人数分抽選処理を繰り返す
                for (int i = 0; i < group.number - defaultNum; i++)
                {
                    int index = random.Next(0, this.all.Count);
                    Applicant applicant = this.all[index];
                    group.Add(applicant);

                    // 重複不可の場合、抽選された結果をすべての応募者の配列から削除していく
                    this.all.Remove(applicant);
                }

                // 当選リストの整列(応募者番号の昇順)
                group.Sort();

                // リストビューに結果を表示するための処理
                group.listView.Enabled = true;
                foreach (Applicant applicant in group)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = applicant.number;
                    item.SubItems.Add(applicant.name);
                    group.listView.Items.Add(item);
                }

                // 演出のために各等級別の処理に時間差を置く
                await Task.Delay(500);
            }
        }

        /// <summary>
        /// 重複ありで全体の抽選を行う関数
        /// </summary>
        async public Task playWithDuplicate()
        {
            // ホワイトリストが存在する場合、ホワイトリストだけの抽選を先に行う
            if (this.white.Count > 0)
            {
                // ホワイトグループのデータ数と当選対象者数を比較する
                if (this.sumTotal <= this.white.Count)
                {
                    // ホワイトグループの人数が当選対象者数以上の場合、当選対象者をホワイトグループに限定して抽選する
                    this.all = this.white;
                }
                else
                {
                    // ホワイトグループの人数が当選対象者数より少ない場合、等級別に当選者を配分する
                    this.white.shuffleItems();
                    playWhiteFirst();
                }
            }

            // 応募対象者のリスト要素をシャッフルする
            this.all.shuffleItems();

            // 応募者全員に対する抽選処理
            Random random = new Random();

            foreach (Group group in this.winners)
            {
                int defaultNum = group.Count; // 等級別のグループリストの要素数を取得する

                // すべての応募者が格納されているリストを臨時のリストにコピーする(allの再利用のため)
                List<Applicant> tempAll = new List<Applicant>(this.all);

                // 既に各等級グループに当選者がいる場合、同じ等級内での重複は禁止するために抽選対象の応募者全員から事前に除く
                if (defaultNum > 0)
                {
                    for (int i = 0; i < defaultNum; i++)
                    {
                        tempAll.RemoveAll(el => el.number.Equals(group[i].number));
                    }
                }

                // 抽選人数分抽選処理を繰り返す
                for (int i = 0; i < group.number - defaultNum; i++)
                {
                    int index = random.Next(0, tempAll.Count);
                    Applicant applicant = tempAll[index];
                    group.Add(applicant);

                    // 重複不可の場合、抽選された結果をすべての応募者の配列から削除していく
                    tempAll.Remove(applicant);
                }

                // 当選リストの整列(応募者番号の昇順)
                group.Sort();

                // リストビューに結果を表示するための処理
                group.listView.Enabled = true;
                foreach (Applicant applicant in group)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = applicant.number;
                    item.SubItems.Add(applicant.name);
                    group.listView.Items.Add(item);
                }

                // 演出のために各等級別の処理に時間差を置く
                await Task.Delay(500);
            }
        }
    }
}
