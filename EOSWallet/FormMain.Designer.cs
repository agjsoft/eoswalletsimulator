namespace EOSWallet
{
    partial class FormMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.파일FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.설정SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miOption = new System.Windows.Forms.ToolStripMenuItem();
            this.도움말HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.lbLine = new System.Windows.Forms.TabPage();
            this.label20 = new System.Windows.Forms.Label();
            this.lbEOSing = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.lbVEOSing = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbTotal = new System.Windows.Forms.Label();
            this.lbVEOS = new System.Windows.Forms.Label();
            this.lbEOS = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnVEOS2EOS = new System.Windows.Forms.Button();
            this.btnEOS2VEOS = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbViewOnlyMyVoted = new System.Windows.Forms.CheckBox();
            this.lvNodeList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miVote = new System.Windows.Forms.ToolStripMenuItem();
            this.miVoteCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.lbLine.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일FToolStripMenuItem,
            this.설정SToolStripMenuItem,
            this.도움말HToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(804, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 파일FToolStripMenuItem
            // 
            this.파일FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miExit});
            this.파일FToolStripMenuItem.Name = "파일FToolStripMenuItem";
            this.파일FToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.파일FToolStripMenuItem.Text = "파일(&F)";
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(125, 22);
            this.miExit.Text = "나가기(&X)";
            this.miExit.Click += new System.EventHandler(this.miExit_Click);
            // 
            // 설정SToolStripMenuItem
            // 
            this.설정SToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miOption});
            this.설정SToolStripMenuItem.Name = "설정SToolStripMenuItem";
            this.설정SToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.설정SToolStripMenuItem.Text = "설정(&S)";
            // 
            // miOption
            // 
            this.miOption.Name = "miOption";
            this.miOption.Size = new System.Drawing.Size(115, 22);
            this.miOption.Text = "옵션(&O)";
            this.miOption.Click += new System.EventHandler(this.miOption_Click);
            // 
            // 도움말HToolStripMenuItem
            // 
            this.도움말HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAbout});
            this.도움말HToolStripMenuItem.Name = "도움말HToolStripMenuItem";
            this.도움말HToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.도움말HToolStripMenuItem.Text = "도움말(&H)";
            // 
            // miAbout
            // 
            this.miAbout.Name = "miAbout";
            this.miAbout.Size = new System.Drawing.Size(182, 22);
            this.miAbout.Text = "이오스 지갑 정보(&A)";
            this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.lbLine);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.ItemSize = new System.Drawing.Size(96, 45);
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(804, 506);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.MouseEnter += new System.EventHandler(this.tabControl1_MouseEnter);
            // 
            // lbLine
            // 
            this.lbLine.Controls.Add(this.label20);
            this.lbLine.Controls.Add(this.lbEOSing);
            this.lbLine.Controls.Add(this.label18);
            this.lbLine.Controls.Add(this.panel1);
            this.lbLine.Controls.Add(this.label17);
            this.lbLine.Controls.Add(this.lbVEOSing);
            this.lbLine.Controls.Add(this.label15);
            this.lbLine.Controls.Add(this.label10);
            this.lbLine.Controls.Add(this.label9);
            this.lbLine.Controls.Add(this.label8);
            this.lbLine.Controls.Add(this.lbTotal);
            this.lbLine.Controls.Add(this.lbVEOS);
            this.lbLine.Controls.Add(this.lbEOS);
            this.lbLine.Controls.Add(this.label4);
            this.lbLine.Controls.Add(this.label3);
            this.lbLine.Controls.Add(this.label2);
            this.lbLine.Controls.Add(this.label1);
            this.lbLine.Location = new System.Drawing.Point(4, 49);
            this.lbLine.Name = "lbLine";
            this.lbLine.Padding = new System.Windows.Forms.Padding(3);
            this.lbLine.Size = new System.Drawing.Size(796, 453);
            this.lbLine.TabIndex = 0;
            this.lbLine.Text = "개요(O)";
            this.lbLine.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(243, 80);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(30, 12);
            this.label20.TabIndex = 17;
            this.label20.Text = "EOS";
            // 
            // lbEOSing
            // 
            this.lbEOSing.AutoSize = true;
            this.lbEOSing.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbEOSing.Location = new System.Drawing.Point(123, 80);
            this.lbEOSing.Name = "lbEOSing";
            this.lbEOSing.Size = new System.Drawing.Size(73, 12);
            this.lbEOSing.TabIndex = 16;
            this.lbEOSing.Text = "0.00000000";
            this.lbEOSing.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(23, 80);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 12);
            this.label18.TabIndex = 15;
            this.label18.Text = "전환중";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Location = new System.Drawing.Point(25, 164);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(214, 2);
            this.panel1.TabIndex = 14;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(243, 137);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(38, 12);
            this.label17.TabIndex = 13;
            this.label17.Text = "VEOS";
            // 
            // lbVEOSing
            // 
            this.lbVEOSing.AutoSize = true;
            this.lbVEOSing.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbVEOSing.Location = new System.Drawing.Point(123, 137);
            this.lbVEOSing.Name = "lbVEOSing";
            this.lbVEOSing.Size = new System.Drawing.Size(73, 12);
            this.lbVEOSing.TabIndex = 12;
            this.lbVEOSing.Text = "0.00000000";
            this.lbVEOSing.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(23, 137);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 11;
            this.label15.Text = "투표중";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(244, 181);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 12);
            this.label10.TabIndex = 10;
            this.label10.Text = "EOS";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(243, 108);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 12);
            this.label9.TabIndex = 9;
            this.label9.Text = "VEOS";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(243, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "EOS";
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbTotal.Location = new System.Drawing.Point(123, 181);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(73, 12);
            this.lbTotal.TabIndex = 7;
            this.lbTotal.Text = "0.00000000";
            this.lbTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbVEOS
            // 
            this.lbVEOS.AutoSize = true;
            this.lbVEOS.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbVEOS.Location = new System.Drawing.Point(123, 108);
            this.lbVEOS.Name = "lbVEOS";
            this.lbVEOS.Size = new System.Drawing.Size(73, 12);
            this.lbVEOS.TabIndex = 6;
            this.lbVEOS.Text = "0.00000000";
            this.lbVEOS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbEOS
            // 
            this.lbEOS.AutoSize = true;
            this.lbEOS.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbEOS.Location = new System.Drawing.Point(123, 52);
            this.lbEOS.Name = "lbEOS";
            this.lbEOS.Size = new System.Drawing.Size(73, 12);
            this.lbEOS.TabIndex = 5;
            this.lbEOS.Text = "0.00000000";
            this.lbEOS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "총액:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "투표 가능";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "사용 가능";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(23, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "잔액";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 49);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(796, 453);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "보내기(S)";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 49);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(796, 453);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "받기(R)";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnVEOS2EOS);
            this.tabPage4.Controls.Add(this.btnEOS2VEOS);
            this.tabPage4.Controls.Add(this.label14);
            this.tabPage4.Controls.Add(this.label13);
            this.tabPage4.Controls.Add(this.label12);
            this.tabPage4.Controls.Add(this.label11);
            this.tabPage4.Controls.Add(this.cbViewOnlyMyVoted);
            this.tabPage4.Controls.Add(this.lvNodeList);
            this.tabPage4.Location = new System.Drawing.Point(4, 49);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(796, 453);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "BP 투표(V)";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnVEOS2EOS
            // 
            this.btnVEOS2EOS.Location = new System.Drawing.Point(8, 143);
            this.btnVEOS2EOS.Name = "btnVEOS2EOS";
            this.btnVEOS2EOS.Size = new System.Drawing.Size(108, 77);
            this.btnVEOS2EOS.TabIndex = 7;
            this.btnVEOS2EOS.Text = "VEOS > EOS 전환";
            this.btnVEOS2EOS.UseVisualStyleBackColor = true;
            this.btnVEOS2EOS.Click += new System.EventHandler(this.btnVEOS2EOS_Click);
            // 
            // btnEOS2VEOS
            // 
            this.btnEOS2VEOS.Location = new System.Drawing.Point(8, 58);
            this.btnEOS2VEOS.Name = "btnEOS2VEOS";
            this.btnEOS2VEOS.Size = new System.Drawing.Size(108, 77);
            this.btnEOS2VEOS.TabIndex = 6;
            this.btnEOS2VEOS.Text = "EOS > VEOS 전환";
            this.btnEOS2VEOS.UseVisualStyleBackColor = true;
            this.btnEOS2VEOS.Click += new System.EventHandler(this.btnEOS2VEOS_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(128, 11);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(264, 12);
            this.label14.TabIndex = 5;
            this.label14.Text = "노드 리스트 : 1위~21위가 블록 프로듀서입니다.";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(701, 427);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 12);
            this.label13.TabIndex = 4;
            this.label13.Text = "초 남았습니다.";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(680, 427);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 12);
            this.label12.TabIndex = 3;
            this.label12.Text = "XX";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(533, 427);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(145, 12);
            this.label11.TabIndex = 2;
            this.label11.Text = "블록 프로듀서 재선정까지";
            // 
            // cbViewOnlyMyVoted
            // 
            this.cbViewOnlyMyVoted.AutoSize = true;
            this.cbViewOnlyMyVoted.Location = new System.Drawing.Point(632, 11);
            this.cbViewOnlyMyVoted.Name = "cbViewOnlyMyVoted";
            this.cbViewOnlyMyVoted.Size = new System.Drawing.Size(156, 16);
            this.cbViewOnlyMyVoted.TabIndex = 1;
            this.cbViewOnlyMyVoted.Text = "내가 투표한 노드만 보기";
            this.cbViewOnlyMyVoted.UseVisualStyleBackColor = true;
            this.cbViewOnlyMyVoted.CheckedChanged += new System.EventHandler(this.cbViewOnlyMyVoted_CheckedChanged);
            // 
            // lvNodeList
            // 
            this.lvNodeList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader5,
            this.columnHeader4});
            this.lvNodeList.ContextMenuStrip = this.contextMenuStrip1;
            this.lvNodeList.FullRowSelect = true;
            this.lvNodeList.GridLines = true;
            this.lvNodeList.Location = new System.Drawing.Point(130, 33);
            this.lvNodeList.MultiSelect = false;
            this.lvNodeList.Name = "lvNodeList";
            this.lvNodeList.Size = new System.Drawing.Size(658, 378);
            this.lvNodeList.TabIndex = 0;
            this.lvNodeList.UseCompatibleStateImageBehavior = false;
            this.lvNodeList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "순위";
            this.columnHeader1.Width = 55;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "노드명";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "득표수";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 90;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "내 투표수";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader5.Width = 90;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "소개글";
            this.columnHeader4.Width = 250;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miVote,
            this.miVoteCancel});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(147, 48);
            // 
            // miVote
            // 
            this.miVote.Name = "miVote";
            this.miVote.Size = new System.Drawing.Size(146, 22);
            this.miVote.Text = "투표하기";
            this.miVote.Click += new System.EventHandler(this.miVote_Click);
            // 
            // miVoteCancel
            // 
            this.miVoteCancel.Name = "miVoteCancel";
            this.miVoteCancel.Size = new System.Drawing.Size(146, 22);
            this.miVoteCancel.Text = "투표철회하기";
            this.miVoteCancel.Click += new System.EventHandler(this.miVoteCancel_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 536);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(804, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 558);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.Text = "이오스 지갑 시뮬레이터 v 0.1";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.lbLine.ResumeLayout(false);
            this.lbLine.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage lbLine;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ToolStripMenuItem 파일FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 설정SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 도움말HToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.ToolStripMenuItem miOption;
        private System.Windows.Forms.ToolStripMenuItem miAbout;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Label lbVEOS;
        private System.Windows.Forms.Label lbEOS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox cbViewOnlyMyVoted;
        private System.Windows.Forms.ListView lvNodeList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lbVEOSing;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lbEOSing;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miVote;
        private System.Windows.Forms.ToolStripMenuItem miVoteCancel;
        private System.Windows.Forms.Button btnVEOS2EOS;
        private System.Windows.Forms.Button btnEOS2VEOS;
    }
}

