using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Learn10_9.Helper;

namespace Learn10_9
{
    public static class Common
    {
        public static Dictionary<string, string> book = new Dictionary<string, string>();
        public static string key, value;
        public static void AddSach()
        {
            key = GetValue("Nhập key của sách");
            value = GetValue("Nhập tên sách");
            book.Add(key, value);
        }
        public static void EditByKey()
        {
            key = GetValue("Nhập key để sửa sách");
            book.Remove(key);
  
        }
        public static void DeleteByKey()
        {
            key = GetValue("Nhập key để xóa sách");
            book.Remove(key);
        }
        public static void Print()
        {
            foreach (var item in book)
            {
                Console.WriteLine($"Key: {item.Key}\nTên sách: {item.Value}");
            }
        }
    }
}
