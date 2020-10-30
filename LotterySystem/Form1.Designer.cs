namespace LotterySystem
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>txt
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        public void InitializeComponent()
        {
            this.btnOpenFileDialog = new System.Windows.Forms.Button();
            this.selectedFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnLotteryStart = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.listView2 = new System.Windows.Forms.ListView();
            this.label14 = new System.Windows.Forms.Label();
            this.listView3 = new System.Windows.Forms.ListView();
            this.label15 = new System.Windows.Forms.Label();
            this.listView4 = new System.Windows.Forms.ListView();
            this.label16 = new System.Windows.Forms.Label();
            this.listView5 = new System.Windows.Forms.ListView();
            this.btnWriteCsv = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.duplicateCheckbox = new System.Windows.Forms.CheckBox();
            this.btnWriteXml = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.label19 = new System.Windows.Forms.Label();
            this.selectedBlack = new System.Windows.Forms.TextBox();
            this.btnOpenBlack = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.selectedWhite = new System.Windows.Forms.TextBox();
            this.btnOpenWhite = new System.Windows.Forms.Button();
            this.fileAmount = new System.Windows.Forms.Label();
            this.blackAmount = new System.Windows.Forms.Label();
            this.whiteAmount = new System.Windows.Forms.Label();
            this.btnFileClear = new System.Windows.Forms.Button();
            this.btnBlackClear = new System.Windows.Forms.Button();
            this.btnWhiteClear = new System.Windows.Forms.Button();
            this.amountFile = new System.Windows.Forms.Label();
            this.amountBlack = new System.Windows.Forms.Label();
            this.amountWhite = new System.Windows.Forms.Label();
            this.txtFirst = new LotterySystem.SecuredTextBox();
            this.txtSecond = new LotterySystem.SecuredTextBox();
            this.txtThird = new LotterySystem.SecuredTextBox();
            this.txtFourth = new LotterySystem.SecuredTextBox();
            this.txtFifth = new LotterySystem.SecuredTextBox();
            this.SuspendLayout();
            // 
            // btnOpenFileDialog
            // 
            this.btnOpenFileDialog.Location = new System.Drawing.Point(826, 39);
            this.btnOpenFileDialog.Name = "btnOpenFileDialog";
            this.btnOpenFileDialog.Size = new System.Drawing.Size(66, 23);
            this.btnOpenFileDialog.TabIndex = 0;
            this.btnOpenFileDialog.Text = "参照";
            this.btnOpenFileDialog.UseVisualStyleBackColor = true;
            this.btnOpenFileDialog.Click += new System.EventHandler(this.btnOpenFileDialog_Click);
            // 
            // selectedFile
            // 
            this.selectedFile.Enabled = false;
            this.selectedFile.Location = new System.Drawing.Point(219, 39);
            this.selectedFile.Name = "selectedFile";
            this.selectedFile.Size = new System.Drawing.Size(600, 22);
            this.selectedFile.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(135, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "5等";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(244, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "人";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(244, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "人";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(135, 274);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "4等";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(244, 305);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "人";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(135, 305);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "3等";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(244, 335);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "人";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(135, 335);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 15);
            this.label8.TabIndex = 12;
            this.label8.Text = "2等";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(244, 366);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 15);
            this.label9.TabIndex = 16;
            this.label9.Text = "人";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(135, 366);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 15);
            this.label10.TabIndex = 15;
            this.label10.Text = "1等";
            // 
            // btnLotteryStart
            // 
            this.btnLotteryStart.Location = new System.Drawing.Point(36, 471);
            this.btnLotteryStart.Name = "btnLotteryStart";
            this.btnLotteryStart.Size = new System.Drawing.Size(334, 70);
            this.btnLotteryStart.TabIndex = 17;
            this.btnLotteryStart.Text = "抽選";
            this.btnLotteryStart.UseVisualStyleBackColor = true;
            this.btnLotteryStart.Click += new System.EventHandler(this.btnLotteryStart_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(33, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(111, 15);
            this.label11.TabIndex = 18;
            this.label11.Text = "ファイル選択(csv)";
            // 
            // listView1
            // 
            this.listView1.Enabled = false;
            this.listView1.Location = new System.Drawing.Point(422, 610);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(346, 170);
            this.listView1.TabIndex = 19;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(425, 592);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 15);
            this.label12.TabIndex = 20;
            this.label12.Text = "1等";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(805, 389);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 15);
            this.label13.TabIndex = 22;
            this.label13.Text = "2等";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // listView2
            // 
            this.listView2.Enabled = false;
            this.listView2.Location = new System.Drawing.Point(801, 407);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(346, 170);
            this.listView2.TabIndex = 21;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(425, 389);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(30, 15);
            this.label14.TabIndex = 24;
            this.label14.Text = "3等";
            // 
            // listView3
            // 
            this.listView3.Enabled = false;
            this.listView3.Location = new System.Drawing.Point(422, 407);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(346, 170);
            this.listView3.TabIndex = 23;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.Details;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(804, 186);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(30, 15);
            this.label15.TabIndex = 26;
            this.label15.Text = "4等";
            // 
            // listView4
            // 
            this.listView4.Enabled = false;
            this.listView4.Location = new System.Drawing.Point(801, 204);
            this.listView4.Name = "listView4";
            this.listView4.Size = new System.Drawing.Size(346, 170);
            this.listView4.TabIndex = 25;
            this.listView4.UseCompatibleStateImageBehavior = false;
            this.listView4.View = System.Windows.Forms.View.Details;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(425, 186);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(30, 15);
            this.label16.TabIndex = 28;
            this.label16.Text = "5等";
            // 
            // listView5
            // 
            this.listView5.Enabled = false;
            this.listView5.Location = new System.Drawing.Point(422, 204);
            this.listView5.Name = "listView5";
            this.listView5.Size = new System.Drawing.Size(346, 170);
            this.listView5.TabIndex = 27;
            this.listView5.UseCompatibleStateImageBehavior = false;
            this.listView5.View = System.Windows.Forms.View.Details;
            // 
            // btnWriteCsv
            // 
            this.btnWriteCsv.Location = new System.Drawing.Point(36, 552);
            this.btnWriteCsv.Name = "btnWriteCsv";
            this.btnWriteCsv.Size = new System.Drawing.Size(334, 70);
            this.btnWriteCsv.TabIndex = 29;
            this.btnWriteCsv.Text = "CSV出力";
            this.btnWriteCsv.UseVisualStyleBackColor = true;
            this.btnWriteCsv.Visible = false;
            this.btnWriteCsv.Click += new System.EventHandler(this.btnWriteCsv_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(420, 158);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(67, 15);
            this.label17.TabIndex = 30;
            this.label17.Text = "抽選結果";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(144, 203);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(112, 15);
            this.label18.TabIndex = 31;
            this.label18.Text = "等級別人員配分";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(36, 710);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(334, 70);
            this.btnReset.TabIndex = 32;
            this.btnReset.Text = "リセット";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Visible = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // duplicateCheckbox
            // 
            this.duplicateCheckbox.AutoSize = true;
            this.duplicateCheckbox.Location = new System.Drawing.Point(113, 407);
            this.duplicateCheckbox.Name = "duplicateCheckbox";
            this.duplicateCheckbox.Size = new System.Drawing.Size(178, 19);
            this.duplicateCheckbox.TabIndex = 34;
            this.duplicateCheckbox.Text = "当選の重複を可能にする";
            this.duplicateCheckbox.UseVisualStyleBackColor = true;
            // 
            // btnWriteXml
            // 
            this.btnWriteXml.Location = new System.Drawing.Point(36, 631);
            this.btnWriteXml.Name = "btnWriteXml";
            this.btnWriteXml.Size = new System.Drawing.Size(334, 70);
            this.btnWriteXml.TabIndex = 35;
            this.btnWriteXml.Text = "XML出力";
            this.btnWriteXml.UseVisualStyleBackColor = true;
            this.btnWriteXml.Visible = false;
            this.btnWriteXml.Click += new System.EventHandler(this.btnWriteXml_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(33, 75);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(152, 15);
            this.label19.TabIndex = 38;
            this.label19.Text = "ブラックリストファイル(csv)";
            // 
            // selectedBlack
            // 
            this.selectedBlack.Enabled = false;
            this.selectedBlack.Location = new System.Drawing.Point(219, 72);
            this.selectedBlack.Name = "selectedBlack";
            this.selectedBlack.Size = new System.Drawing.Size(600, 22);
            this.selectedBlack.TabIndex = 37;
            // 
            // btnOpenBlack
            // 
            this.btnOpenBlack.Location = new System.Drawing.Point(826, 72);
            this.btnOpenBlack.Name = "btnOpenBlack";
            this.btnOpenBlack.Size = new System.Drawing.Size(66, 23);
            this.btnOpenBlack.TabIndex = 36;
            this.btnOpenBlack.Text = "参照";
            this.btnOpenBlack.UseVisualStyleBackColor = true;
            this.btnOpenBlack.Click += new System.EventHandler(this.btnOpenBlack_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(33, 107);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(157, 15);
            this.label20.TabIndex = 41;
            this.label20.Text = "ホワイトリストファイル(csv)";
            // 
            // selectedWhite
            // 
            this.selectedWhite.Enabled = false;
            this.selectedWhite.Location = new System.Drawing.Point(219, 104);
            this.selectedWhite.Name = "selectedWhite";
            this.selectedWhite.Size = new System.Drawing.Size(600, 22);
            this.selectedWhite.TabIndex = 40;
            // 
            // btnOpenWhite
            // 
            this.btnOpenWhite.Location = new System.Drawing.Point(826, 103);
            this.btnOpenWhite.Name = "btnOpenWhite";
            this.btnOpenWhite.Size = new System.Drawing.Size(66, 23);
            this.btnOpenWhite.TabIndex = 39;
            this.btnOpenWhite.Text = "参照";
            this.btnOpenWhite.UseVisualStyleBackColor = true;
            this.btnOpenWhite.Click += new System.EventHandler(this.btnOpenWhite_Click);
            // 
            // fileAmount
            // 
            this.fileAmount.AutoSize = true;
            this.fileAmount.Location = new System.Drawing.Point(907, 43);
            this.fileAmount.Name = "fileAmount";
            this.fileAmount.Size = new System.Drawing.Size(0, 15);
            this.fileAmount.TabIndex = 42;
            // 
            // blackAmount
            // 
            this.blackAmount.AutoSize = true;
            this.blackAmount.Location = new System.Drawing.Point(907, 75);
            this.blackAmount.Name = "blackAmount";
            this.blackAmount.Size = new System.Drawing.Size(0, 15);
            this.blackAmount.TabIndex = 43;
            // 
            // whiteAmount
            // 
            this.whiteAmount.AutoSize = true;
            this.whiteAmount.Location = new System.Drawing.Point(907, 107);
            this.whiteAmount.Name = "whiteAmount";
            this.whiteAmount.Size = new System.Drawing.Size(0, 15);
            this.whiteAmount.TabIndex = 44;
            // 
            // btnFileClear
            // 
            this.btnFileClear.Location = new System.Drawing.Point(902, 39);
            this.btnFileClear.Name = "btnFileClear";
            this.btnFileClear.Size = new System.Drawing.Size(66, 23);
            this.btnFileClear.TabIndex = 45;
            this.btnFileClear.Text = "クリア";
            this.btnFileClear.UseVisualStyleBackColor = true;
            this.btnFileClear.Click += new System.EventHandler(this.btnFileClear_Click);
            // 
            // btnBlackClear
            // 
            this.btnBlackClear.Location = new System.Drawing.Point(902, 72);
            this.btnBlackClear.Name = "btnBlackClear";
            this.btnBlackClear.Size = new System.Drawing.Size(66, 23);
            this.btnBlackClear.TabIndex = 46;
            this.btnBlackClear.Text = "クリア";
            this.btnBlackClear.UseVisualStyleBackColor = true;
            this.btnBlackClear.Click += new System.EventHandler(this.btnBlackClear_Click);
            // 
            // btnWhiteClear
            // 
            this.btnWhiteClear.Location = new System.Drawing.Point(902, 103);
            this.btnWhiteClear.Name = "btnWhiteClear";
            this.btnWhiteClear.Size = new System.Drawing.Size(66, 23);
            this.btnWhiteClear.TabIndex = 47;
            this.btnWhiteClear.Text = "クリア";
            this.btnWhiteClear.UseVisualStyleBackColor = true;
            this.btnWhiteClear.Click += new System.EventHandler(this.btnWhiteClear_Click);
            // 
            // amountFile
            // 
            this.amountFile.AutoSize = true;
            this.amountFile.Location = new System.Drawing.Point(984, 42);
            this.amountFile.Name = "amountFile";
            this.amountFile.Size = new System.Drawing.Size(0, 15);
            this.amountFile.TabIndex = 48;
            // 
            // amountBlack
            // 
            this.amountBlack.AutoSize = true;
            this.amountBlack.Location = new System.Drawing.Point(984, 75);
            this.amountBlack.Name = "amountBlack";
            this.amountBlack.Size = new System.Drawing.Size(0, 15);
            this.amountBlack.TabIndex = 49;
            // 
            // amountWhite
            // 
            this.amountWhite.AutoSize = true;
            this.amountWhite.Location = new System.Drawing.Point(984, 107);
            this.amountWhite.Name = "amountWhite";
            this.amountWhite.Size = new System.Drawing.Size(0, 15);
            this.amountWhite.TabIndex = 50;
            // 
            // txtFirst
            // 
            this.txtFirst.Location = new System.Drawing.Point(180, 362);
            this.txtFirst.MaxLength = 3;
            this.txtFirst.Name = "txtFirst";
            this.txtFirst.Size = new System.Drawing.Size(58, 22);
            this.txtFirst.TabIndex = 14;
            this.txtFirst.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // txtSecond
            // 
            this.txtSecond.Location = new System.Drawing.Point(180, 331);
            this.txtSecond.MaxLength = 3;
            this.txtSecond.Name = "txtSecond";
            this.txtSecond.Size = new System.Drawing.Size(58, 22);
            this.txtSecond.TabIndex = 11;
            this.txtSecond.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // txtThird
            // 
            this.txtThird.Location = new System.Drawing.Point(180, 301);
            this.txtThird.MaxLength = 3;
            this.txtThird.Name = "txtThird";
            this.txtThird.Size = new System.Drawing.Size(58, 22);
            this.txtThird.TabIndex = 8;
            this.txtThird.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // txtFourth
            // 
            this.txtFourth.Location = new System.Drawing.Point(180, 270);
            this.txtFourth.MaxLength = 3;
            this.txtFourth.Name = "txtFourth";
            this.txtFourth.Size = new System.Drawing.Size(58, 22);
            this.txtFourth.TabIndex = 5;
            this.txtFourth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // txtFifth
            // 
            this.txtFifth.Location = new System.Drawing.Point(180, 240);
            this.txtFifth.MaxLength = 3;
            this.txtFifth.Name = "txtFifth";
            this.txtFifth.Size = new System.Drawing.Size(58, 22);
            this.txtFifth.TabIndex = 2;
            this.txtFifth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 807);
            this.Controls.Add(this.amountWhite);
            this.Controls.Add(this.amountBlack);
            this.Controls.Add(this.amountFile);
            this.Controls.Add(this.btnWhiteClear);
            this.Controls.Add(this.btnBlackClear);
            this.Controls.Add(this.btnFileClear);
            this.Controls.Add(this.whiteAmount);
            this.Controls.Add(this.blackAmount);
            this.Controls.Add(this.fileAmount);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.selectedWhite);
            this.Controls.Add(this.btnOpenWhite);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.selectedBlack);
            this.Controls.Add(this.btnOpenBlack);
            this.Controls.Add(this.btnWriteXml);
            this.Controls.Add(this.duplicateCheckbox);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.btnWriteCsv);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.listView5);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.listView4);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.listView3);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnLotteryStart);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtFirst);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtSecond);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtThird);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFourth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFifth);
            this.Controls.Add(this.selectedFile);
            this.Controls.Add(this.btnOpenFileDialog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenFileDialog;
        private System.Windows.Forms.TextBox selectedFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnLotteryStart;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ListView listView4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ListView listView5;
        private System.Windows.Forms.Button btnWriteCsv;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.CheckBox duplicateCheckbox;
        private System.Windows.Forms.Button btnWriteXml;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox selectedBlack;
        private System.Windows.Forms.Button btnOpenBlack;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox selectedWhite;
        private System.Windows.Forms.Button btnOpenWhite;
        private SecuredTextBox txtFifth;
        private SecuredTextBox txtFourth;
        private SecuredTextBox txtThird;
        private SecuredTextBox txtSecond;
        private SecuredTextBox txtFirst;
        private System.Windows.Forms.Label fileAmount;
        private System.Windows.Forms.Label blackAmount;
        private System.Windows.Forms.Label whiteAmount;
        private System.Windows.Forms.Button btnFileClear;
        private System.Windows.Forms.Button btnBlackClear;
        private System.Windows.Forms.Button btnWhiteClear;
        private System.Windows.Forms.Label amountFile;
        private System.Windows.Forms.Label amountBlack;
        private System.Windows.Forms.Label amountWhite;
    }
}

