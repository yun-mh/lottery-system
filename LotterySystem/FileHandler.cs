using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace LotterySystem
{
    /// <summary>
    /// CSVやXMLのインポートまたはエキスポートするためのクラス 
    /// </summary>
    public class FileHandler
    {
        public string filePath;
        public List<Group> winner;

        /// <summary>
        /// コンストラクタ1
        /// </summary>
        /// <param name="filePath">ファイルのパス名</param>
        public FileHandler(string filePath)
        {
            this.filePath = filePath;
        }

        /// <summary>
        /// コンストラクタ2
        /// </summary>
        /// <param name="filePath">ファイルのパス名</param>
        /// <param name="winnerGroup">当選者グループの集まり</param>
        public FileHandler(string filePath, WinnerGroup winnerGroup)
        {
            this.filePath = filePath;
            this.winner = winnerGroup.groupsList;
        }

        /// <summary>
        /// CSVファイルが正常か不正かチェックするためのメソッド
        /// </summary>
        /// <returns></returns>
        public int checkCsv()
        {
            try
            {
                StreamReader stream = new StreamReader(this.filePath, Encoding.GetEncoding("shift_jis"));
                string firstLine = stream.ReadLine(); // CSVの最初の行を読み、ヘッダー項目に該当する部分を排除する

                try
                {
                    string[] seperated = firstLine.Split(',');
                    if (seperated[0] == "応募者番号" && seperated[1] == "応募者名")
                    {
                        return 0;
                    }
                    return 1;
                }
                catch (NullReferenceException)
                {
                    return 1;
                }
            }
            catch (IOException)
            {
                return 2;
            }
        }

        /// <summary>
        /// CSVファイルのデータ件数を計算するためのメソッド 
        /// </summary>
        /// <returns>CSVファイルのデータ総件数</returns>
        public int calculateData()
        {
            StreamReader stream = new StreamReader(this.filePath, Encoding.GetEncoding("shift_jis"));
            stream.ReadLine(); // CSVの最初の行を読み、ヘッダー項目に該当する部分を排除する

            // 一行ずつ読み込んで総件数を計算する
            int total = 0;
            String filedata;
            while ((filedata = stream.ReadLine()) != null)
            {
                total++;
            }
            stream.Close();

            return total;
        }

        /// <summary>
        /// CSVファイルとしてデータを書き込むメソッド 
        /// </summary>
        public void writeCsv()
        {
            StreamWriter file = new StreamWriter(this.filePath, false, Encoding.GetEncoding("shift_jis"));
            file.WriteLine(string.Format("応募者番号, 応募者名, 応募結果")); // 最初に項目を追加する

            foreach (Group group in this.winner)
            {
                foreach (Applicant applicant in group)
                {
                    file.WriteLine(string.Format("{0},{1},{2}", applicant.number, applicant.name, group.rank));
                }
            }

            file.Close();
        }

        /// <summary>
        /// XMLファイルとしてデータを記録するメソッド 
        /// </summary>
        public void writeXml()
        {
            // XmlDocumentのインスタンスを生成する
            XmlDocument xmlDocument = new XmlDocument();

            // ルートタグを作成する
            XmlElement root = xmlDocument.CreateElement("当選者一覧");
            xmlDocument.AppendChild(root);

            // ルート内に当選者情報のタグ及びデータを記入する
            foreach (Group group in this.winner)
            {
                foreach (Applicant applicant in group)
                {
                    // 当選者情報タグを入れる
                    XmlElement winnerEl = xmlDocument.CreateElement("当選者情報");
                    root.AppendChild(winnerEl);

                    // 応募者番号タグを値と一緒に入れる
                    XmlElement winnerNumberEl = xmlDocument.CreateElement("応募者番号");
                    winnerNumberEl.InnerText = applicant.number;
                    winnerEl.AppendChild(winnerNumberEl);

                    // 応募者名タグを値と一緒に入れる
                    XmlElement winnerNameEl = xmlDocument.CreateElement("応募者名");
                    winnerNameEl.InnerText = applicant.name;
                    winnerEl.AppendChild(winnerNameEl);

                    // 応募結果タグを値と一緒に入れる
                    XmlElement winnerRankEl = xmlDocument.CreateElement("応募結果");
                    winnerRankEl.InnerText = group.rank.ToString();
                    winnerEl.AppendChild(winnerRankEl);
                }
            }

            xmlDocument.Save(this.filePath);
        }
    }
}
