namespace N_Puzzle
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnShuffle = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnShowSolution = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.lbTime = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.board1 = new N_Puzzle.Board();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnShuffle
            // 
            this.btnShuffle.BackColor = System.Drawing.Color.White;
            this.btnShuffle.Location = new System.Drawing.Point(158, 445);
            this.btnShuffle.Margin = new System.Windows.Forms.Padding(4);
            this.btnShuffle.Name = "btnShuffle";
            this.btnShuffle.Size = new System.Drawing.Size(117, 43);
            this.btnShuffle.TabIndex = 1;
            this.btnShuffle.Text = "Tạo tự động";
            this.btnShuffle.UseVisualStyleBackColor = false;
            this.btnShuffle.Click += new System.EventHandler(this.btnShuffle_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.BackColor = System.Drawing.Color.DarkGray;
            this.btnLeft.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btnLeft.Location = new System.Drawing.Point(219, 373);
            this.btnLeft.Margin = new System.Windows.Forms.Padding(4);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(40, 37);
            this.btnLeft.TabIndex = 2;
            this.btnLeft.Text = "◄";
            this.btnLeft.UseVisualStyleBackColor = false;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.BackColor = System.Drawing.Color.DarkGray;
            this.btnRight.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btnRight.Location = new System.Drawing.Point(297, 373);
            this.btnRight.Margin = new System.Windows.Forms.Padding(4);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(40, 37);
            this.btnRight.TabIndex = 2;
            this.btnRight.Text = "►";
            this.btnRight.UseVisualStyleBackColor = false;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.Color.DarkGray;
            this.btnUp.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btnUp.Location = new System.Drawing.Point(258, 337);
            this.btnUp.Margin = new System.Windows.Forms.Padding(4);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(40, 37);
            this.btnUp.TabIndex = 2;
            this.btnUp.Text = "▲";
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.BackColor = System.Drawing.Color.DarkGray;
            this.btnDown.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btnDown.Location = new System.Drawing.Point(258, 373);
            this.btnDown.Margin = new System.Windows.Forms.Padding(4);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(40, 37);
            this.btnDown.TabIndex = 2;
            this.btnDown.Text = "▼";
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 535);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tốc Độ : ";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(88, 520);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(4);
            this.trackBar1.Minimum = 3;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(431, 56);
            this.trackBar1.TabIndex = 8;
            this.trackBar1.Value = 5;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(301, 56);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 236);
            this.panel1.TabIndex = 12;
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(33, 445);
            this.btnNew.Margin = new System.Windows.Forms.Padding(4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(117, 43);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "Tạo mới";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnShowSolution
            // 
            this.btnShowSolution.BackColor = System.Drawing.Color.White;
            this.btnShowSolution.Enabled = false;
            this.btnShowSolution.Location = new System.Drawing.Point(408, 448);
            this.btnShowSolution.Margin = new System.Windows.Forms.Padding(4);
            this.btnShowSolution.Name = "btnShowSolution";
            this.btnShowSolution.Size = new System.Drawing.Size(117, 37);
            this.btnShowSolution.TabIndex = 17;
            this.btnShowSolution.Text = "Xem lời giải";
            this.btnShowSolution.UseVisualStyleBackColor = false;
            this.btnShowSolution.Click += new System.EventHandler(this.btnShowSolution_Click);
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.Color.White;
            this.btnRun.Enabled = false;
            this.btnRun.Location = new System.Drawing.Point(283, 445);
            this.btnRun.Margin = new System.Windows.Forms.Padding(4);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(117, 43);
            this.btnRun.TabIndex = 21;
            this.btnRun.Text = "Giải";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTime.ForeColor = System.Drawing.Color.Blue;
            this.lbTime.Location = new System.Drawing.Point(24, 7);
            this.lbTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(0, 25);
            this.lbTime.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 32);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 18);
            this.label4.TabIndex = 24;
            this.label4.Text = "Trạng Thái Ban Đầu";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(298, 32);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 18);
            this.label5.TabIndex = 25;
            this.label5.Text = "Trạng Thái Đích";
            // 
            // board1
            // 
            this.board1.Array = null;
            this.board1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.board1.BlankValue = 0;
            this.board1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.board1.Location = new System.Drawing.Point(20, 57);
            this.board1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.board1.MatrixSize = 0;
            this.board1.Name = "board1";
            this.board1.Size = new System.Drawing.Size(236, 236);
            this.board1.TabIndex = 0;
            this.board1.Load += new System.EventHandler(this.board1_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(846, 642);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnShowSolution);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnShuffle);
            this.Controls.Add(this.board1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "8-puzzle";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Board board1;
        private System.Windows.Forms.Button btnShuffle;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnShowSolution;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

