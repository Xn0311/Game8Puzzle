using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace N_Puzzle
{    public partial class Form1 : Form
    {        
        const int n = 3;
        int i = 1;
        private ListView listView1;
        private ColumnHeader columnHeader1;

        GameEngine game;
        int[] array;
        int index = 0;

        public Form1()
        {
            InitializeComponent();
            game = new GameEngine();
            EnableButtons(false);
            trackBar1.Value = 7;
            InitButtons();
            board1.Array = null;
            index = 0;
           

        }
      ///Khởi tạo buttons
        private void InitButtons()
        {
            EnableInput(true);
            game.Matrix = new Matrix(n);
            game.Size = n;
            array = new int[n * n];
            board1.MatrixSize = n;
            board1.BlankValue = n * n;
            int width = panel1.Width / n;
             panel1.Controls.Clear();
            int m = n * n;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Button btn = new Button();
                    int a = i * n + j;
                    array[a] = 0;
                    a++;
                    if (a != m)
                        btn.Text = a.ToString();
                    else
                        btn.BackColor = Color.Gray;
                    btn.Tag = a;
                    btn.Left = width * j;
                    btn.Top = width * i;
                    btn.Width = width;
                    btn.Height = width;
                    btn.TabStop = false;
                    btn.Click += button_Click;
                    panel1.Controls.Add(btn);
                }
            }
        }
        /// <summary>
        /// Di chuyen thu cong bang phim
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData.ToString())
            {
                case "Up":
                    btnUp_Click(null, null); break;
                case "Down":
                    btnDown_Click(null, null); break;
                case "Right":
                    btnRight_Click(null, null); break;
                case "Left":
                    btnLeft_Click(null, null); break;
                default:
                    break;
            }
            return base.ProcessDialogKey(keyData);
        }
        /// <summary>
        /// Các button nhập dữ liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, EventArgs e)
        {
            
            Button btn = (Button)sender;
            int t = (int)btn.Tag;
            array[index] = t;
            board1.Array = array;
            
            if (t == game.Matrix.BlankValue)
                game.Matrix.Blank_Pos = index;           
            index++;

            // Nút cuối cùng được nhấn
            if (index == array.Length)
            {
                game.Matrix.Value = array;
                index = 0;
                EnableButtons(true);
                EnableInput(false);
            }
            btn.Enabled = false;
            
        }
        /// <summary>
        /// Button tạo game mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            EnableButtons(false);
            EnableInput(true);
            btnShowSolution.Enabled = false;

	        InitButtons();
            board1.Array = null;
            index = 0;

            lbTime.Text = "";
            Clear();
        }
        /// <summary>
        /// Button tạo ngẫu nhiên bảng số
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShuffle_Click(object sender, EventArgs e)
        {
            Clear();//Xoa history
            game.Shuffle();
            btnShowSolution.Enabled = false;
            board1.Array = game.Matrix.Value;//Painted
            EnableInput(false);
            EnableButtons(true);
        }
        /// <summary>
        /// Hien/an Cac button nhap du lieu
        /// </summary>
        /// <param name="value"></param>
        private void EnableInput(bool value)
        {
            foreach (Control ctl in panel1.Controls)
                ctl.Enabled = value; 	                       
        }
        /// <summary>
        /// Hien/an cac button: giải bài toán, tạo mới...
        /// </summary>
        /// <param name="value"></param>
        private void EnableButtons(bool value)
        {
            btnLeft.Enabled = value;
            btnRight.Enabled = value;
            btnUp.Enabled = value;
            btnDown.Enabled = value;
            btnRun.Enabled = value;
        }

        //Cac button chuyen dong thu cong
        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (game.Matrix.CanMoveLeft)
            {
                game.Matrix.MakeMove(MoveDirection.LEFT);
                board1.Invalidate();
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (game.Matrix.CanMoveRight)
            {
                game.Matrix.MakeMove(MoveDirection.RIGHT);
                board1.Invalidate();
            }
        }
        
        private void btnUp_Click(object sender, EventArgs e)
        {
            if (game.Matrix.CanMoveUp)
            {
                game.Matrix.MakeMove(MoveDirection.UP);
                board1.Invalidate();
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (game.Matrix.CanMoveDown)
            {
                game.Matrix.MakeMove(MoveDirection.DOWN);
                board1.Invalidate();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (game.Solution.Count > 0)
            {
                MoveDirection Move = game.Solution.Pop();//save nuoc di chuyen                
                game.Matrix.MakeMove(Move);
                board1.Array = game.Matrix.Value;//auto paint
                Move_Printed(Move); //in loi giai
            }
            else
            {
                timer1.Enabled = false;
                EnableInput(true);
            }
        }

        /// <summary>
        /// Hien thi loi gai
        /// </summary>
        void Move_Printed(MoveDirection move)
        {
            switch (move)
            {
                case MoveDirection.LEFT: listView1.Items.Add((i++).ToString() + " ----->" + " LEFT"); break;
                case MoveDirection.RIGHT: listView1.Items.Add((i++).ToString() + " ----->" + " RIGHT"); break;
                case MoveDirection.UP: listView1.Items.Add((i++).ToString() + " ----->" + " UP"); break;
                case MoveDirection.DOWN: listView1.Items.Add((i++).ToString() + " ----->" + " DOWN"); break;
            }
        }

        /// <summary>
        /// Clear all Item in ListView
        /// </summary>
        void Clear()
        {
            i = 1;
            listView1.Items.Clear();
        }

        //Add History
        void Add()
        {
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Giải thuật";
            this.columnHeader1.Width = 140;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new ColumnHeader[] { this.columnHeader1 });
            this.listView1.Dock = System.Windows.Forms.DockStyle.Right;
            this.listView1.Location = new System.Drawing.Point(400, 0);
            this.listView1.Size = new System.Drawing.Size(160, 330);
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = View.Details;
            this.Controls.Add(this.listView1);
        }
      
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = 1001 - trackBar1.Value * 100;
        }
        
        /// <summary>
        /// Xem hình chuyển động
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowSolution_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;//start tick time
            btnShowSolution.Enabled = false;
        }        

        /// <summary>
        /// Chon thuat giai
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
      

        /// <summary>
        /// Giai bai toan voi thuat toan da chon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Solve()
        {            
            if (game.CanSolve() == true)
            {
                Stopwatch st = new Stopwatch();//đối tượng tính thời gian của giải thuật
                st.Start();//bắt đầu tính giờ

                switch (game.Algorithms)//cac thuat toan de giai
                {                        
                    case 1: game.A_Search(); break;
                   
                }
                st.Stop();//kết thúc việc tính giờ
                if (st.Elapsed.Minutes <= 0)
                {
                    if (st.Elapsed.Seconds > 0)
                    {
                        lbTime.Text = st.Elapsed.TotalSeconds.ToString() + "  Seconds";//Hiển thị thời gian theo giay
                    }
                    else//st.Elapsed.Seconds <= 0
                    {
                        lbTime.Text = st.Elapsed.TotalMilliseconds.ToString() + "  Milliseconds";//Hiển thị thời gian theo mili giay
                    }
                }
                else
                {
                    lbTime.Text = st.Elapsed.TotalMinutes.ToString() + "  Minutes";//Hiển thị thời gian theo phut
                }
                
                st.Reset();
                if (game.Solution.Count == 0)
                    MessageBox.Show("Vui Lòng Tạo Mới","Tạo Mới",MessageBoxButtons.OK,MessageBoxIcon.Information);
                else
                {
                    MessageBox.Show("Tìm Thấy Lời Giải Đi Trong " + game.Solution.Count + " Bước. Nhấn 'Xem Lời Giải' Để Tiếp Tục.", "Lời giải", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                    btnShowSolution.Enabled = true;
                }
            }
            else
            {
               MessageBox.Show("Không Tìm Thấy Lời Giải");
                btnShowSolution.Enabled = true;
            }
        }
        /// <summary>
        /// Tìm lời giải với thuật giải đã chọn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRun_Click(object sender, EventArgs e)
        {
            Clear();
            Solve();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ClientSize = new Size(650, 500);
            Add();
        }

        private void board1_Load(object sender, EventArgs e)
        {

        }
    }
}