using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookMgn.Repo
{
    public class CommonRepo<T> // Sach Hoa, 
    {
        public  int SoLuongTuMangToiDa = 10;

        public T[] DataList;

        public CommonRepo(int size)
        {
            if (SoLuongTuMangToiDa > 10)
                DataList = new T[10];
            else
            {
                DataList = new T[size];
            }
        }


        private int ConfigLengthOfArray(T model)
        {
            return 0;
        }

        public int FindIndex(T model)
        {
            return 1;
        }
    }
}
