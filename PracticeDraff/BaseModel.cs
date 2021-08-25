using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeDraff
{
    public class BaseModel<T>
    {
        public T[] DataList;

        public BaseModel(int size)
        {
            DataList = new T[size];
        }

        public T GetById<T2>(T2 id)
        {
            return DataList[ConvertValueToIntGen(id)];
        }

        //public Electric Get..
        public int Total()
        {
            return DataList.Length;
        }

        public T[] GetAll()
        {
            return DataList;
        }

        //public T FindByProperty<T2>(T2 property)
        //{
        //    return DataList
        //}

        //
        private static int ConvertValueToIntGen<T3>(T3 value) // T thay thế cho kiểu dữ liệu đầu vào.
        {
            return int.TryParse(value.ToString(), out var intOut) ? intOut : 0;
        }
    }
}
