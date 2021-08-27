using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookMgn.Repo
{
    public class CommonRepo<T> // Sach Hoa, 
    {
        public List<T> DataList;

        public CommonRepo()
        {
            DataList = new List<T>();
        }

        public T Add(T model)
        {
            DataList.Add(model);
            return model;
        }

        //public T GetById<T2>(T2 id)
        //{
        //    //return DataList.FirstOrDefault()...
        //}

    }
}
