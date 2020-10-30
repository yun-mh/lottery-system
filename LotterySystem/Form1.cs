using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Security.Permissions;

namespace LotterySystem
{
    /// <summary>
    /// フォームクラス
    /// </summary>
    public partial class Form1 : Form
    {
        // メンバー変数の宣言
        public int csvDataTotal; // 応募者全員のデータ件数
        public Group wonFirst, wonSecond, wonThird, wonFourth, wonFifth, all, white, black; // 等級別の当選者グループ及び応募者全員・ホワイト・ブラックリストグループ
        public Boolean isChecked; // 重複可否の変数

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// フォームのロード時の処理 
        /// </summary>
        /// <param name="sender">イベントを送信したオブジェクト</param>
        /// <param name="e">イベント引数</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // フォームのタイトルを指定する
            this.Text = "抽選システム";

            // 各リストビューに項目を設定する
            resetListView(listView1);
            resetListView(listView2);
            resetListView(listView3);
            resetListView(listView4);
            resetListView(listView5);
        }

        /// <summary>
        /// リストビューの初期化及び項目の設定を行う関数 
        /// </summary>
        /// <param name="listView">リセット対象のリストビュー</param>
        private void resetListView(ListView listView)
        {
            // リストビューにかけられていた全ての設定をクリアする
            listView.Clear();
            listView.Items.Clear();
            listView.Columns.Clear();

            // リストビューの列に項目を追加する
            listView.Enabled = false;
            listView.Columns.Add("応募者番号", 100, HorizontalAlignment.Left);
            listView.Columns.Add("姓名", 100, HorizontalAlignment.Left);
        }

        /// <summary>
        /// UI部品をオン・オフに切り替えるためのメソッド 
        /// </summary>
        /// <param name="status">オンまたはオフ</param>
        public void toggleUIComponent(Boolean status)
        {
            btnWriteCsv.Visible = !status;
            btnWriteXml.Visible = !status;
            btnReset.Visible = !status;
            btnLotteryStart.Visible = status;
            btnFileClear.Enabled = status;
            btnBlackClear.Enabled = status;
            btnWhiteClear.Enabled = status;
            txtFifth.Enabled = status;
            txtFourth.Enabled = status;
            txtThird.Enabled = status;
            txtSecond.Enabled = status;
            txtFirst.Enabled = status;
            duplicateCheckbox.Enabled = status;
            btnOpenFileDialog.Enabled = status;
            btnOpenBlack.Enabled = status;
            btnOpenWhite.Enabled = status;
        }

        /// <summary>
        /// 結果表示する際にすべてのボタンをオフにするためのメソッド
        /// </summary>
        public void setOffUIComponent()
        {
            btnWriteCsv.Visible = false;
            btnWriteXml.Visible = false;
            btnReset.Visible = false;
            btnLotteryStart.Visible = false;
            btnFileClear.Enabled = false;
            btnBlackClear.Enabled = false;
            btnWhiteClear.Enabled = false;
            txtFifth.Enabled = false;
            txtFourth.Enabled = false;
            txtThird.Enabled = false;
            txtSecond.Enabled = false;
            txtFirst.Enabled = false;
            duplicateCheckbox.Enabled = false;
            btnOpenFileDialog.Enabled = false;
            btnOpenBlack.Enabled = false;
            btnOpenWhite.Enabled = false;
        }

        /// <summary>
        /// リセットボタンの処理 
        /// </summary>
        /// <param name="sender">イベントを送信したオブジェクト</param>
        /// <param name="e">イベント引数</param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            // 各種グループリストを初期化する
            all.Clear();
            black.Clear();
            white.Clear();
            wonFirst.Clear();
            wonSecond.Clear();
            wonThird.Clear();
            wonFourth.Clear();
            wonFifth.Clear();

            // 各種入力フォームの値を初期化する
            selectedFile.Text = "";
            selectedBlack.Text = "";
            selectedWhite.Text = "";
            txtFifth.Text = "";
            txtFourth.Text = "";
            txtThird.Text = "";
            txtSecond.Text = "";
            txtFirst.Text = "";
            amountFile.Text = "";
            amountBlack.Text = "";
            amountWhite.Text = "";
            duplicateCheckbox.Checked = false;

            // リストビューを初期化する
            resetListView(listView5);
            resetListView(listView4);
            resetListView(listView3);
            resetListView(listView2);
            resetListView(listView1);

            // 各種UI部品を初期化する
            toggleUIComponent(true);
        }

        /// <summary>
        /// 当選人数入力のテキストボックスにキーを入力する時のバリデーション関数 
        /// </summary>
        /// <param name="sender">イベントを送信したオブジェクト</param>
        /// <param name="e">イベント引数</param>
        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 制御文字は入力可能(バックスペース等)
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }
            // 数字(0-9)は入力可能
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
                return;
            }
            // 上記以外は入力不可
            e.Handled = true;
        }

        /// <summary>
        /// ファイル参照ボタンの処理 
        /// </summary>
        /// <param name="sender">イベントを送信したオブジェクト</param>
        /// <param name="e">イベント引数</param>
        private void btnOpenFileDialog_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "抽選対象者ファイルを開く";
            openFileDialog.FileName = "";
            openFileDialog.Filter = "CSVファイル(*.csv)|*.csv";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // CSVファイル以外の拡張子のファイルが選択された場合の例外処理
                if (Path.GetExtension(openFileDialog.FileName) != ".csv")
                {
                    MessageBox.Show("対応可能なファイルはCSVファイルのみです。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 不正なcsvファイルを選択した場合の例外処理
                FileHandler fileHandler = new FileHandler(openFileDialog.FileName);
                int res = fileHandler.checkCsv();

                switch (res) {
                    case 0:
                        break;
                    case 1:
                        MessageBox.Show("正しいCSVファイルを選択してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    case 2:
                        MessageBox.Show("ロードしようとするCSVファイルが開いている状態です。ファイルを閉めてからもう一回試してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }

                // 入力欄にファイルのパスを表示する
                selectedFile.Text = openFileDialog.FileName;

                try
                {
                    csvDataTotal = fileHandler.calculateData();
                    amountFile.Text = csvDataTotal.ToString() + " 人";
                }
                catch (IOException)
                {
                    return;
                }
            }
        }

        /// <summary>
        /// 選択した対象者リストファイルをクリアする操作
        /// </summary>
        /// <param name="sender">イベントを送信したオブジェクト</param>
        /// <param name="e"></param>
        private void btnFileClear_Click(object sender, EventArgs e)
        {
            selectedFile.Text = "";
            amountFile.Text = "";
        }

        /// <summary>
        /// 選択したブラックリストファイルをクリアする操作
        /// </summary>
        /// <param name="sender">イベントを送信したオブジェクト</param>
        /// <param name="e">イベント引数</param>
        private void btnBlackClear_Click(object sender, EventArgs e)
        {
            selectedBlack.Text = "";
            amountBlack.Text = "";
        }

        /// <summary>
        /// 選択したホワイトリストファイルをクリアする操作
        /// </summary>
        /// <param name="sender">イベントを送信したオブジェクト</param>
        /// <param name="e">イベント引数</param>
        private void btnWhiteClear_Click(object sender, EventArgs e)
        {
            selectedWhite.Text = "";
            amountWhite.Text = "";
        }

        /// <summary>
        /// ブラックリスト参照ボタンの処理 
        /// </summary>
        /// <param name="sender">イベントを送信したオブジェクト</param>
        /// <param name="e">イベント引数</param>
        private void btnOpenBlack_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "ブラックリストファイルを開く";
            openFileDialog.FileName = "";
            openFileDialog.Filter = "CSVファイル(*.csv)|*.csv";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // CSVファイル以外の拡張子のファイルが選択された場合の例外処理
                if (Path.GetExtension(openFileDialog.FileName) != ".csv")
                {
                    MessageBox.Show("対応可能なファイルはCSVファイルのみです。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 不正なcsvファイルを選択した場合の例外処理
                FileHandler fileHandler = new FileHandler(openFileDialog.FileName);
                int res = fileHandler.checkCsv();

                switch (res)
                {
                    case 0:
                        int amount = fileHandler.calculateData();
                        amountBlack.Text = amount.ToString() + " 人";
                        break;
                    case 1:
                        MessageBox.Show("正しいCSVファイルを選択してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    case 2:
                        MessageBox.Show("ロードしようとするCSVファイルが開いている状態です。ファイルを閉めてからもう一回試してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }

                selectedBlack.Text = openFileDialog.FileName; // 入力欄にファイルのパスを表示する
            }
        }

        /// <summary>
        /// ホワイトリスト参照ボタンの処理 
        /// </summary>
        /// <param name="sender">イベントを送信したオブジェクト</param>
        /// <param name="e">イベント引数</param>
        private void btnOpenWhite_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "ホワイトリストファイルを開く";
            openFileDialog.FileName = "";
            openFileDialog.Filter = "CSVファイル(*.csv)|*.csv";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // CSVファイル以外の拡張子のファイルが選択された場合の例外処理
                if (Path.GetExtension(openFileDialog.FileName) != ".csv")
                {
                    MessageBox.Show("対応可能なファイルはCSVファイルのみです。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 不正なcsvファイルを選択した場合の例外処理
                FileHandler fileHandler = new FileHandler(openFileDialog.FileName);
                int res = fileHandler.checkCsv();

                switch (res)
                {
                    case 0:
                        int amount = fileHandler.calculateData();
                        amountWhite.Text = amount.ToString() + " 人";
                        break;
                    case 1:
                        MessageBox.Show("正しいCSVファイルを選択してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    case 2:
                        MessageBox.Show("ロードしようとするCSVファイルが開いている状態です。ファイルを閉めてからもう一回試してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }

                selectedWhite.Text = openFileDialog.FileName; // 入力欄にファイルのパスを表示する
            }
        }

        /// <summary>
        /// テキストボックスが空欄のままで抽選ボタンを押す時にテキストボックスを0で設定するメソッド 
        /// </summary>
        /// <param name="txt">対象テキストボックス</param>
        private void blankToZero(System.Windows.Forms.TextBox txt)
        {
            if (txt.Text.Equals("")) txt.Text = "0";
        }

        /// <summary>
        /// 全角数字を半角数字に変換するメソッド 
        /// </summary>
        /// <param name="txt">対象テキストボックス</param>
        private void fullWidthToHalfWidth(System.Windows.Forms.TextBox txt)
        {
            string converted = "";
            // テキストボックスに全角数字が含まれているか正規表現でチェックし、あったら半角に変換する
            foreach (char character in txt.Text)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(character.ToString(), @"^[０-９]+$"))
                {
                    converted += Microsoft.VisualBasic.Strings.StrConv(character.ToString(), VbStrConv.Narrow);
                }
                else
                {
                    converted += character.ToString();
                }
            }

            if (converted == "")
            {
                return;
            }
            else
            {
                txt.Text = converted;   
            }
        }

        /// <summary>
        /// CSV出力ボタンの処理関数 
        /// </summary>
        /// <param name="sender">イベントを送信したオブジェクト</param>
        /// <param name="e">イベント引数</param>
        private void btnWriteCsv_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = "";
            saveFileDialog.Filter = "CSVファイル(*.csv)|*.csv";

            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // ダイアログで指定したパス名を取得する
                string filePath = saveFileDialog.FileName;

                // 保存するファイル名の拡張子がCSVではない場合、処理を中止する
                if (Path.GetExtension(filePath) != ".csv")
                {
                    MessageBox.Show("CSVファイル形式で保存してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // メッセージボックスのための変数を宣言する
                string msg = "";
                string title = "";
                MessageBoxIcon icon = new MessageBoxIcon();

                // 当選者グループのインスタンスを生成する
                WinnerGroup winners = new WinnerGroup(wonFirst, wonSecond, wonThird, wonFourth, wonFifth); ;

                FileHandler export = new FileHandler(filePath, winners);

                try
                {
                    export.writeCsv();
                    msg = "CSV出力が完了しました。";
                    title = "CSV出力完了";
                    icon = MessageBoxIcon.None;
                }
                catch (IOException) // 保存しようとするファイル名と同じ名前のファイルが開いている際の例外
                {
                    msg = "出力しようとするCSVファイルが開いている状態です。ファイルを閉めてからもう一回試してください。";
                    title = "エラー";
                    icon = MessageBoxIcon.Error;
                }
                catch // その他の例外
                {
                    msg = "CSV出力に問題が発生しました。";
                    title = "エラー";
                    icon = MessageBoxIcon.Error;
                }
                finally
                {
                    MessageBox.Show(msg, title, MessageBoxButtons.OK, icon);
                }
            }
        }

        /// <summary>
        /// XML出力ボタンの処理関数 
        /// </summary>
        /// <param name="sender">イベントを送信したオブジェクト</param>
        /// <param name="e">イベント引数</param>
        private void btnWriteXml_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = "";
            saveFileDialog.Filter = "XMLファイル(*.xml)|*.xml";

            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // ダイアログで指定したパス名を取得する
                string filePath = saveFileDialog.FileName;

                // 保存するファイル名の拡張子がXMLではない場合、処理を中止する
                if (Path.GetExtension(filePath) != ".xml")
                {
                    MessageBox.Show("XMLファイル形式で保存してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // メッセージボックスのための変数を宣言する
                string msg = "";
                string title = "";
                MessageBoxIcon icon = new MessageBoxIcon();

                // 当選者グループのインスタンス生成
                WinnerGroup winners = new WinnerGroup(wonFirst, wonSecond, wonThird, wonFourth, wonFifth); ;

                FileHandler export = new FileHandler(filePath, winners);

                // XMLで保存する
                try
                {
                    export.writeXml();
                    msg = "XML出力が完了しました。";
                    title = "XML出力完了";
                    icon = MessageBoxIcon.None;
                }
                catch (IOException) // 保存しようとするファイル名と同じ名前を持っているファイルが開いている際の例外
                {
                    msg = "出力しようとするXMLファイルが開いている状態です。ファイルを閉めてからもう一度試行ってください。";
                    title = "エラー";
                    icon = MessageBoxIcon.Error;
                }
                catch // その他の例外
                {
                    msg = "XML出力に問題が発生しました。";
                    title = "エラー";
                    icon = MessageBoxIcon.Error;
                }
                finally
                {
                    MessageBox.Show(msg, title, MessageBoxButtons.OK, icon);
                }
            }
        }

        /// <summary>
        /// 抽選ボタンの処理関数 
        /// </summary>
        /// <param name="sender">イベントを送信したオブジェクト</param>
        /// <param name="e">イベント引数</param>
        async private void btnLotteryStart_Click(object sender, EventArgs e)
        {
            // CSVファイルを参照したかチェック
            if (selectedFile.Text.Equals(""))
            {
                MessageBox.Show("対象CSVファイルを選択してください。", "エラー", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            // 等級別の人数が全部空欄または0の場合
            if ((txtFifth.Text.Equals("")) && (txtFourth.Text.Equals("")) && (txtThird.Text.Equals("")) && (txtSecond.Text.Equals("")) && (txtFirst.Text.Equals("")) 
                || (txtFifth.Text.Equals("0")) && (txtFourth.Text.Equals("0")) && (txtThird.Text.Equals("0")) && (txtSecond.Text.Equals("0")) && (txtFirst.Text.Equals("0")))
            {
                MessageBox.Show("抽選する人数を設定してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 等あたりの人数が空欄の場合の補正
            blankToZero(txtFifth);
            blankToZero(txtFourth);
            blankToZero(txtThird);
            blankToZero(txtSecond);
            blankToZero(txtFirst);

            // 全角数字が入力された場合、半角数字で変換する
            fullWidthToHalfWidth(txtFifth);
            fullWidthToHalfWidth(txtFourth);
            fullWidthToHalfWidth(txtThird);
            fullWidthToHalfWidth(txtSecond);
            fullWidthToHalfWidth(txtFirst);

            // 重複フラグに重複可否の値を入れる
            isChecked = duplicateCheckbox.Checked;

            // 等級別の人数を取得する
            int fifthNum = Int16.Parse(txtFifth.Text);
            int fourthNum = Int16.Parse(txtFourth.Text);
            int thirdNum = Int16.Parse(txtThird.Text);
            int secondNum = Int16.Parse(txtSecond.Text);
            int firstNum = Int16.Parse(txtFirst.Text);
            int sumTotal = fifthNum + fourthNum + thirdNum + secondNum + firstNum;

            // 等級別の人数合計がCSVファイル内のデータ件数を超える場合の処理(重複不可のみ)
            if (isChecked == false && (sumTotal > csvDataTotal))
            {
                MessageBox.Show("当選可能人数の合計が全体の応募者人数を超えました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 抽選のためのグループリストのインスタンスを生成する
            all = new Group();
            black = new Group();
            white = new Group();
            wonFirst = new Group(1, firstNum, listView1);
            wonSecond = new Group(2, secondNum, listView2);
            wonThird = new Group(3, thirdNum, listView3);
            wonFourth = new Group(4, fourthNum, listView4);
            wonFifth = new Group(5, fifthNum, listView5);

            // 当選者グループの集まりを生成する
            WinnerGroup winners = new WinnerGroup(wonFirst, wonSecond, wonThird, wonFourth, wonFifth);

            // 抽選クラスの生成
            Lottery lottery = new Lottery(all, white, black, winners, selectedFile, selectedBlack, selectedWhite, sumTotal, isChecked);

            // 抽選を行う
            try
            {
                setOffUIComponent();
                await lottery.doLottery();
            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show("エラーが発生しました。もう一度行ってください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception)
            {
                MessageBox.Show("ブラックリストとホワイトリスト内に共通的なデータがあります。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // 抽選終了後にCSV出力ボタンとリセットボタンは表示し、抽選ボタンは非表示にする
            toggleUIComponent(false);
        }
    }
}

