using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using static System.Console;
using static Lesson.Common.Helpers.AppHelper;

namespace Practice
{
    public static class Lesson3
    {
        public static void Array()
        {

            #region [Mảng 1 chiều]
            const string student1 = "Hoang Van 1";
            const string student2 = "Hoang Van 2";
            const string student3 = "Hoang Van 3";
            const string student4 = "Hoang Van 4";

            WriteLine(student1);
            WriteLine(student2);
            WriteLine(student3);
            WriteLine(student4);

            // Cách khởi tạo
            string[] studentsString;

            studentsString = new string[5];


            int[] studentsInt = new int[4]
            {
                1,2,1,3
            };

            float[] studentsFloat = new float[4];

            double[] studentsDouble = new double[40];

            // Truy cập giá trị  
            WriteLine($"studentsString[0] {studentsString[0]}, studentsInt {studentsInt[0]}, studentsFloat {studentsFloat[0]}, studentsDouble {studentsDouble[0]}"); // ghép chuỗi nội suy chuỗi

            for (int i = 0; i < 4; i++)
            {
                WriteLine($"studentsString[{i}]: {studentsInt[i]}"); // Nen dung

                //WriteLine("studentsString[{" + i+ "}]: " + "{" + studentsInt[i] + "}");
            }

            // Gán giá trị cho phần tử của mảng
            studentsInt[2] = 3;
            studentsInt[3] = 4;


            for (int i = 0; i < 4; i++)
            {
                WriteLine($"studentsString[{i}]: {studentsInt[i]}"); // Nen dung

                //WriteLine("studentsString[{" + i+ "}]: " + "{" + studentsInt[i] + "}");
            }

            // Mảng tĩnh (Cấp phát động - Vùng nhớ (Stack - Heap)) 
            string[] persons = new string[5];

            // Mảng động (Cấp phát động - Vùng nhớ (Stack - Heap))
            int value = GetValueFromKeyBoard("Enter range of array:");
            int[] arr = new int[value];


            Write($@"arr.Length {arr.Length}");
            #endregion



            #region [Mảng 2 chiều (Ma trận)]

            //<datatype>[,] array_name

            // 1 chieu 
            string[] string1 = new string[5]
            {
                 "HaNam", "HaNoi", "DienBien", "CaoBang", "HaiPhong"
            };


            // mang 2 chieu: tập hợp n mảng 1 chiều
            string[,] string2 = new string[3, 5]
            {
                {
                    "HaNam", "HaNoi", "DienBien", "CaoBang", "HaiPhong"
                },
                {
                    "SaiGon", "VungTau", "CaMau", "BinhDuong", "DaLat"
                },
                {
                    "HaNam", "HaNoi", "DienBien", "CaoBang", "HaiPhong"
                },
            };
            // "HaNam", "HaNoi", "DienBien", "CaoBang", "HaiPhong", "DaLat"... "SaiGon"
            // truy xuất mảng 2 chiều


            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    WriteLine($@"Province name: {string2[i, j]}");
                }
            }

            #endregion


            #region [Mảng đa chiều]





            #endregion [Mảng đa chiều]


            #region [String]

            var number1 = 10;

           var number2 = 2-2;
            

           if(number2 == 0) return;
           var devide = number1 / number2;


           #endregion
        }



        #region [Private functions helper]

        private static int GetValueFromKeyBoard(string msg)
        {
            Write($@"{msg}");
            return ConvertStringToInt(ReadLine());
        }


        #endregion
    }
}