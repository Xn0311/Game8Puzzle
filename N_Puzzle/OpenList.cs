using System;
using System.Collections.Generic;
using System.Text;

namespace N_Puzzle
{

    class OpenList
    {
        private List<Matrix> list;
        private HashSet<int> idList;

        public OpenList()
        {
            list = new List<Matrix>();
            idList = new HashSet<int>();
        }

        public Matrix this[long ID]
        {
            get
            {
                for (int i = 0; i < list.Count; i++)
                    if (list[i].Id == ID)
                        return list[i];
                return null;
            }
        }

        public Matrix this[int pos]
        {
            get { return list[pos]; }
            set { list[pos] = value; }
        }

        public void Add(Matrix item)
        {
            if(idList.Contains(item.Id))
                return;
            idList.Add(item.Id);
            
            for (int i = 0; i < list.Count; i++)
            {                

                if (item.ComparingValue<=list[i].ComparingValue)
                {
                    list.Insert(i, item);
                    return;
                }
            }
            list.Add(item);//thêm vào cuối
        }
        public void Clear()
        {
            list.Clear();
            idList.Clear();
        }
        public void Remove(Matrix item)
        {
            idList.Remove(item.Id);
            list.Remove(item);
        }

        public int Count
        { get { return list.Count; } }

   
        /// <summary>
        /// Thay thế một ma trận trong list bằng một ma trận khác
        /// </summary>
        public void Replace(Matrix m)
        {
            for (int i = 0; i < list.Count; i++)
                if (list[i].Id == m.Id)
                    list[i] = m;
        }

        public bool Contains(int ID)
        {
            return idList.Contains(ID);
        }
    }
}
