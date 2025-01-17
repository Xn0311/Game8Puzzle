using System;
using System.Collections.Generic;
using System.Text;

namespace N_Puzzle
{
    class GameEngine
    {
        // Lưu tọa độ dòng và cột của các giá trị tương ứng
        public static int[] IndexRows;
        public static int[] IndexCols;
        bool  chang;

        public int Algorithms = 1;//default = A*
        private int _size =3 ;
        private Matrix _matrix;
        private int WIN_VALUE = 0; 
       
        public OpenList openQ;// chứa các node đang chờ để xét
        private SortedList<int, Matrix> closeQ; //chứa các node đã xét
        public Stack<MoveDirection> Solution;//giải pháp (lưu lại số nước đi để giải bài toán )

        public GameEngine()
        {

            openQ = new OpenList();// lưu các trạng thái chờ để phát  triển
            closeQ = new SortedList<int, Matrix>();// lưu lại  các trạng thái đã xét 
            Solution = new Stack<MoveDirection>(); //” để lưu lại đường đi tìm được từ trạng thái đầu tiên tới đích.
        }

        public int Size//tính sẵn giá trị dòng và cột của mọi phần tử trong bảng số.
        {
            get { return _size; }
            set
            {
                _size = value;
                _matrix = new Matrix(_size);

                int m = _size * _size;
                IndexRows = new int[m];
                IndexCols = new int[m];
                for (int i = 0; i < m; i++)
                {
                    IndexRows[i] = i / _size;
                    IndexCols[i] = i % _size;
                }

            }
        }
        public Matrix Matrix
        {
            get { return _matrix; }
            set
            {
                _matrix = value;
            }
        }
        public void Shuffle()
        {
            do
            {
                this._matrix.Shuffle();
            }
            while (!CanSolve(this._matrix));

        }

        public bool CanSolve()
        {
            return CanSolve(this._matrix);
        }
        /// <summary>
        /// Kiểm tra xem puzzle có thể chuyển về dạng đích ko  
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public bool CanSolve(Matrix matrix)
        {
            int value = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                int t = matrix[i];
                if (t > 1 && t < matrix.BlankValue)
                {
                    //xét ô kế tiếp
                    for (int m = i + 1; m < matrix.Length; m++)
                        if (matrix[m] < t)
                            value++;
                }
            }
            
            if (value % 2 == 0)
            {
                chang = true;
            }
            else
                chang = false;

            return chang;


        }
        /// <summary>
        /// A* Search
        /// </summary>
        public void A_Search()
        {
            // Làm rỗng các collection
            openQ.Clear();
            closeQ.Clear();
            Solution.Clear();

            // Thêm phần tử hiện tại vào OPEN
            this._matrix.Parent = null;
            openQ.Add(this._matrix); //thêm trạng thái hiện tại đang xét vào tập Mở 
            this._matrix.Score = Evaluate(this._matrix);// hàm lượng giá Heuristic tính giá trị khoảng cách
                                                         //từ trạng thái hiện tại tới trạng thái đích của một bảng
            while (openQ.Count > 0)
            {
                // Lấy node có giá trị (ComparingValue) nhỏ nhất
                Matrix m = openQ[0];
                // Kiểm tra xem có phải trạng thái đích
                if (m.Score == WIN_VALUE)
                {
                    // Tạo solution để lưu lại quá trình tìm kiếm 
                    TrackPath(m);
                    return;
                }
                // Xóa node đầu tiên của OPEN
                openQ.Remove(m);
                // Sinh các node tiếp theo của node m
                GenMove_A(m);
            }
        }


        /// <summary>
        /// Lấy đường đi từ matrix hiện tại đến matrix bắt đầu
        /// </summary>
        /// <param name="matrix"></param>
        private void TrackPath(Matrix matrix)
        {
            if (matrix.Parent != null)
            {
                //Tạo danh sách các nước đi từ trạng thái đầu tiên đến đích và lưu vào đối tượng solution.
                Solution.Push(matrix.Direction);
                TrackPath(matrix.Parent);
            }
        }

        /// <summary>
        /// Sinh nước đi của A*
        /// </summary>
        /// <param name="matrix"></param>
        private void GenMove_A(Matrix matrix)
        {
            Matrix m1;
             
            // nếu node này đã từng xét qua
            if (closeQ.ContainsKey(matrix.Id))
            {
                m1 = closeQ[matrix.Id];
                // Kiểm tra và cập nhật nếu có số nước đi ít hơn node trong CLOSE
                if (matrix.StepCount < m1.StepCount)
                    m1 = matrix;
            }
            else
            
                closeQ.Add(matrix.Id, matrix);

            // Sinh ra các node con
            if (matrix.Direction != MoveDirection.LEFT && matrix.CanMoveRight)
            {
                CloneMove_A(matrix, MoveDirection.RIGHT);
            }
            if (matrix.Direction != MoveDirection.UP && matrix.CanMoveDown)
            {
                CloneMove_A(matrix, MoveDirection.DOWN);
            }
            if (matrix.Direction != MoveDirection.RIGHT && matrix.CanMoveLeft)
            {
                CloneMove_A(matrix, MoveDirection.LEFT);
            }

            if (matrix.Direction != MoveDirection.DOWN && matrix.CanMoveUp)
            {
                CloneMove_A(matrix, MoveDirection.UP);
            }
        }
        /// <summary>
        /// Sao chép ra một node con của một node dựa vào hướng di chuyển của A*
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="direction"></param>
        private void CloneMove_A(Matrix parent, MoveDirection direction)
        {
            // Tạo và cập nhật các giá trị cho node con
            Matrix m = parent.Clone();
            m.MakeMove(direction);
            m.Direction = direction;
            m.StepCount ++; // g(v) = g(u) + cost(u, v)
            m.Score = Evaluate(m); //hàm lượng giá Heuristic tính giá trị của một bảng số.h(u)
             m.Parent = parent;
            // Nếu nút đã có trong Open
            if (openQ.Contains(m.Id))
            {
                Matrix mOpen = openQ[(long)m.Id];
                if (m.StepCount < mOpen.StepCount)
                    openQ.Replace(m);
            }
            // Nếu node đã có trong CLOSE
            if (closeQ.ContainsKey(m.Id))
            {
                Matrix m1 = closeQ[m.Id];
                if (m.StepCount < m1.StepCount)
                    closeQ[m1.Id] = m;
            }
            // Trong truong hop chua xuat hien trong Open lan Close
            if (!openQ.Contains(m.Id) && !closeQ.ContainsKey(m.Id))
            {
                // Them no vao tap OPEN
                openQ.Add(m);
            }
        }


        /// <summary>
        /// Hàm đánh giá heuristic:h(u)
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int Evaluate(Matrix matrix)//hàm lượng giá Heuristic tính giá trị của một bảng số
        {
                // Ô nằm sai vị trí bị cộng điểm bằng khoảng cách ô đó đến vị trí đúng            
                int score = 0;
                if (chang == true)
                {
                    for (int i = 0; i < matrix.Length; i++)
                    {
                        int value = matrix[i] - 1;
                        score += Math.Abs(IndexRows[i] - IndexRows[value]) + Math.Abs(IndexCols[i] - IndexCols[value]);
                    }
                }
                return score;
            }


        }
    }


