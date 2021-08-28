using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generic.Repo
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

        public T GetById<T2>(T2 id)
        {
            return DataList.FirstOrDefault();
        }

        public T DeleteById<T>(T id)
        {
            DataList.RemoveAt(Convert.ToInt16(id));
            return id;
        }

        public T SearchByName<T>(T name)
        {
            DataList.FindAll(x => x.Name.Contains(name));
            return name;
        }

    }
}