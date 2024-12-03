using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace N_Puzzle
{
    public partial class Board : UserControl
    {
        private float cellWidth;
        private const int x0 = 200;
        private const int y0 = 200;
        private Font myFont;

        private int[] _array;
        private int _blankValue;
        private int _size;

        public Board()
        {
            InitializeComponent();

            myFont = new Font("Tahoma", 16);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            
            if (_array != null)
            {
              
                DrawMatrix(e.Graphics, _array);
                
            }
            if (_size > 0)
            {
                cellWidth = (float)(this.Width - 0.8) / _size;
                DrawGrid(e.Graphics);
            }
            base.OnPaint(e);
        }
        protected override void OnResize(EventArgs e)
        {
            this.Width = Math.Min(this.Width, this.Height);
            this.Height = this.Width;
            
            base.OnResize(e);
        }
        public int MatrixSize
        {
            get { return _size; }
            set { _size = value;
            Invalidate();
            }
        }

        public int BlankValue
        {
            get { return _blankValue; }
            set
            {
                _blankValue = value;

                Invalidate();
            }
        }
        public int[] Array
        {
            get { return _array; }
            set
            {
                _array = value;

                Invalidate();
            }
        }
        // vẽ ma trận 
        public void DrawMatrix(Graphics g, int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int r = i / _size;
                int c = i % _size;
                if (array[i] == _blankValue)
                {
                    g.FillRectangle(Brushes.Gray, cellWidth * c, cellWidth * r, cellWidth, cellWidth);                    
                    
                }
                else
                {
                    string s = array[i].ToString();
                    if (s == "0") s = string.Empty;
                    SizeF size = g.MeasureString(s, myFont);
                    float left = cellWidth * c + (cellWidth - size.Width) /2 ;
                    float top = cellWidth * r + (cellWidth - size.Height) / 2;
                    g.DrawString(s, myFont, Brushes.Blue, left, top);
                }                
            }
            
        }
        // vẽ lưới cho ma trận 
        private void DrawGrid(Graphics g)
        {
            for (int i = 0; i <= _size; i++)
            {
                g.DrawLine(Pens.Black, 0, i * cellWidth, this.Width, i * cellWidth);
                g.DrawLine(Pens.Black, i * cellWidth, 0, i * cellWidth, this.Width);
            }
        }

        private void Board_Load(object sender, EventArgs e)
        {

        }
    }

}
