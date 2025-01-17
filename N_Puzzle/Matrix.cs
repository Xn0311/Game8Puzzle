using System;
using System.Collections.Generic;
using System.Text;

namespace N_Puzzle
{
    /// <summary>
    /// Hướng di chuyển của ô trống từ trạng thái parent sang trạng thái hiện tại
    /// </summary>
    public enum MoveDirection
    {
        UP = 1, LEFT = 2, DOWN = 3, RIGHT = 4
    }
    public class Matrix
    {
        public int Id;
        public int Size;
        public int Length;
        /// <summary>
        /// Lưu đối tượng cha, là trạng thái trước của trạng thái hiện tại
        /// </summary>
        public Matrix Parent;
        /// <summary>
        /// mảng lưu bảng số
        /// </summary>
        private int[] _value;
        /// <summary>
        /// vị trí của ô trống
        /// </summary>
        public int Blank_Pos;
        private int _score;
        /// <summary>
        /// Hàm đánh giá f(u)
        /// </summary>
        public int Score
        {
            get{return _score;}
            set {
                _score = value;
                ComparingValue = _score + StepCount; //f(u)
            }
        }
        /// <summary>
        /// là giá trị dùng để so sánh các phần tử Matrix trong OpenList, là tổng của Score và StepCount (số nước đi từ trạng thái đầu tiên đến trạng thái hiện tại)
        /// </summary>
        public int ComparingValue;    
        /// <summary>
        /// ô trống
        /// </summary>
        public int BlankValue;
        /// <summary>
        /// đối tượng kiểu MoveDirection, lưu hướng di chuyển để từ trạng thái trước đó tới trạng thái hiện tại
        /// </summary>
        public MoveDirection Direction;
        /// <summary>
        /// Số nước đi để đến trạng thái hiện tại từ trạng thái bắt đầu g(u)
        /// </summary>
        public int StepCount;

        /// <summary>
        /// truyền  Kích Thước vào Ma Trận
        /// </summary>
        public Matrix(int size)
        {
            this.Size = size;
            this.BlankValue = size * size;
            this.Length = this.BlankValue;
            InitMatrix();
        }
       
        /// <summary>
        ///trạng thái đích
        /// </summary>
        public void InitMatrix()
        {
            this._value = new int[Length];
            for (int i = 0; i < Length; i++)
            {
                _value[i] = i + 1;
            }
            Blank_Pos = Length - 1;
        }

        /// <summary>
        /// Tạo ra id cho đối tượng, id dựa vào thứ tự sắp xếp các số trong mảng,
        /// </summary>
        internal void GetId()
        {
            this.Id = 0;
            int n = 1;
            for (int i = 0; i < Length - 1; i++)
            {
                if (_value[i] == BlankValue)
                    Blank_Pos = i;
                this.Id += _value[i] * n;
                n *= 10;
            }
        }

        public int[] Value
        {
            get { return _value; }
            set
            {
                this._value = value;
                GetId();
            }
        }
        /*Bạn có thể thấy trong lớp Matrix mình tạo một indexer với tham số truyền vào là index:
        dựa vào indexer này ta sẽ lấy được giá trị tương ứng từ mảng value mà không cần truy xuất đến mảng này.*/
        public int this[int index]
        {
            get { return _value[index]; }
            set { _value[index] = value; }
        }

        public int this[int x, int y]
        {
            get { return _value[x * Size + y]; }
            set { _value[x * Size + y] = value; }
        }


        /// <summary>
        /// nhân bản một trạng thái đang xét
        /// </summary>
        /// <returns></returns>
        public Matrix Clone()
        {
            Matrix m = (Matrix)this.MemberwiseClone();
            m._value = (int[])this._value.Clone();
            return m;
        }
        // Xáo trộn ngẫu nhiên các ô số
        public void Shuffle()
        {
            Random rnd = new Random();
            for (int i = 0; i < this.Length; i++)
            {
                int a = rnd.Next(Length);

                if (i != a)
                {
                    int t = _value[i];
                    _value[i] = _value[a];
                    _value[a] = t;

                    if (_value[i] == BlankValue)
                    {
                        Blank_Pos = i;
                    }
                    else if (_value[a] == BlankValue)
                    {
                        Blank_Pos = a;
                    }
                }
            }
            GetId();
        }
        //di chuyen 
        public void MakeMove(MoveDirection direction)
        {
            int position = 0;
            if (direction == MoveDirection.UP)
                position = Blank_Pos - Size;
            else if (direction == MoveDirection.DOWN)
                position = Blank_Pos + Size;
            else if (direction == MoveDirection.LEFT)
                position = Blank_Pos - 1;
            else// if (direction == MoveDirection.RIGHT)
                position = Blank_Pos + 1;

            _value[Blank_Pos] = _value[position];
            _value[position] = this.BlankValue;

            Blank_Pos = position;
            GetId();
        }
        public bool CanMoveUp
        {

            get { return Blank_Pos > Size - 1; }
        }
        public bool CanMoveDown
        {
            get { return Blank_Pos < Length - Size; }
        }
        public bool CanMoveLeft
        {
            get { return GameEngine.IndexCols[Blank_Pos] > 0; }
        }
        public bool CanMoveRight
        {
            get { return GameEngine.IndexCols[Blank_Pos] < Size - 1; }
        }

        public override int GetHashCode()
        {
            return this.Id;
        }
      
        

    }
}
