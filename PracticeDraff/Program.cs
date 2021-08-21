using System.Collections;
using System.Text;
using Lesson.Common.Helpers;
using static System.Console;

namespace PracticeDraff
{
    class Program
    {
        static void Main(string[] args)
        {
            OutputEncoding = Encoding.UTF8;
            /// mảng tĩnh
            int[] mangTinh = new int[3]
            {
                1,2,3
            };

            WriteLine($@"mangTinh length: {mangTinh.Length} - Elements: {mangTinh[0]}, {mangTinh[1]}, {mangTinh[2]}");

            /// mảng động
            int value = AppHelper.ConvertStringToInt(AppHelper.GetValueFromKeyBoard("Nhập độ dài của mảng"));
            int[] mangDong = new int[value];

            WriteLine($"mangDong length: {mangDong.Length}");

            /// Collection

            ArrayList collection = new ArrayList();
            collection.Add(1);
            collection.Add(2);
            collection.Add(3);

            WriteLine($@"collection length: {collection.Count} - Elements: {mangTinh[0]}, {collection[1]}, {collection[2]}");

        }
    }
}
