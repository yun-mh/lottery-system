using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LotterySystem
{
    /// <summary>
    /// 応募者の集まりを表すクラス 
    /// </summary>
    public class Group : List<Applicant>
    {
        // 応募結果
        public int rank { get; set; }

        // 応募者数
        public int number { get; set; }

        // 応募結果を表示する対象になるリストビュー
        public ListView listView { get; set; }

        /// <summary>
        /// コンストラクタ１
        /// </summary>
        public Group() { }

        /// <summary>
        /// コンストラクタ２
        /// </summary>
        /// <param name="rank">抽選結果</param>
        /// <param name="number">順位別に割り当てられた人員数</param>
        /// <param name="listView">結果を表示する対象になるリストビュー</param>
        public Group(int rank, int number, ListView listView)
        {
            this.rank = rank;
            this.number = number;
            this.listView = listView;
        }

        /// <summary>
        /// CSVから取得した情報を用いてグループに応募者たちを入れるメソッド
        /// </summary>
        /// <param name="filePath">CSVファイルのパス名</param>
        /// <param name="all">応募者全員のグループ(デフォルト：null)</param>
        public void insertApplicantsFromCsv(string filePath, Group all = null)
        {
            StreamReader stream = new StreamReader(filePath, Encoding.GetEncoding("shift_jis"));
            stream.ReadLine(); // CSVの最初の行を読み、ヘッダータイトルを排除する

            String filedata;
            while ((filedata = stream.ReadLine()) != null)
            {
                string[] csvSeperated = filedata.Split(',');
                this.Add(new Applicant() { number = csvSeperated[0], name = csvSeperated[1] });
                if (all != null) // 応募者全員のグループが引数として設定された場合(ブラックリストのケースのみ)
                {
                    all.RemoveAll(el => el.number == csvSeperated[0]);
                }
            }
            stream.Close();
        }

        /// <summary>
        /// グループリスト内の要素をシャッフルするメソッド 
        /// </summary>
        public void shuffleItems()
        {
            // リスト全体の中から一つの要素をランダムで取り、それを末尾の要素と交換することを繰り返す
            Random random = new Random();
            for (int i = this.Count - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                var tmp = this[i];
                this[i] = this[j];
                this[j] = tmp;
            }
        }
    }
}
