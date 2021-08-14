using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
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


            var studentsInt = new int[4]
            {
                1,2,3,4
            };

            Console.WriteLine(studentsInt.Length);

            var studentsFloat = new float[4];

            var studentsDouble = new double[40];

            // Truy cập giá trị  
            WriteLine($"studentsString[0] {studentsString[0]}, studentsInt {studentsInt[0]}, studentsFloat {studentsFloat[0]}, studentsDouble {studentsDouble[0]}"); // ghép chuỗi nội suy chuỗi

            for (var i = 0; i < 4; i++)
            {
                WriteLine($"studentsString[{i}]: {studentsInt[i]}"); // Nen dung

                //WriteLine("studentsString[{" + i+ "}]: " + "{" + studentsInt[i] + "}");
            }

            // Gán giá trị cho phần tử của mảng
            studentsInt[2] = 3;
            studentsInt[3] = 4;


            for (var i = 0; i < 4; i++)
            {
                WriteLine($"studentsString[{i}]: {studentsInt[i]}"); // Nen dung

                //WriteLine("studentsString[{" + i+ "}]: " + "{" + studentsInt[i] + "}");
            }

            // Mảng tĩnh (Cấp phát động - Vùng nhớ (Stack - Heap)) 
            var persons = new string[5];

            // Mảng động (Cấp phát động - Vùng nhớ (Stack - Heap))
            //var value = GetValueFromKeyBoard("Enter range of array:");
            //var arr = new int[value];


            //Write($@"arr.Length {arr.Length}");
            #endregion



            #region [Mảng 2 chiều (Ma trận)]
            // N mảng 1 chiều

            //<datatype>[,] array_name

            // 1 chieu 
            var string1 = new string[5]
            {
                 "HaNam", "HaNoi", "DienBien", "CaoBang", "HaiPhong"
            };


            // mang 2 chieu: tập hợp n mảng 1 chiều
            var string2 = new string[3, 5]
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


            //for (int i = 0; i < 2; i++)
            //{
            //    for (int j = 0; j < 5; j++)
            //    {
            //        WriteLine($@"Province name: {string2[i, j]}");
            //    }
            //}

            // lấy ra độ dài của dòng và cột
            for (var i = 0; i < string2.GetLength(0); i++)  // string2.GetLength(0): Lấy ra độ dài của chiều thứ 1
            {
                for (var j = 0; j < string2.GetLength(1); j++)  // string2.GetLength(1): Lấy ra độ dài của chiều thứ 2
                {
                    WriteLine($@"Province name: {string2[i, j]}");
                }
            }

            #endregion

            #region [Mảng 3 chiều] 
            // N mảng 2 chiều
            // Cách khai báo <kiểu dữ liệu> tên_mảng = new <kiểu dữ liệu>[số lượng phần tử mảng 3 chiều, số lượng dòng trong mảng 2 chiều, số lượng cột mảng 2 chiều]

            var array3 = new string[2, 2, 5]
            {
                {
                    {
                        "HaNam", "HaNoi", "DienBien", "CaoBang", "HaiPhong"
                    },
                    {
                        "SaiGon", "VungTau", "CaMau", "BinhDuong", "DaLat"
                    }
                },
                {
                    {
                        "HaNam", "HaNoi", "DienBien", "CaoBang", "HaiPhong"
                    },
                    {
                        "SaiGon", "VungTau", "CaMau", "BinhDuong", "DaLat"
                    }
                }
            };

            var array5 = new string[1, 2, 2, 5]
            {
                {
                    {
                        {
                            "HaNam", "HaNoi", "DienBien", "CaoBang", "HaiPhong"
                        },
                        {
                            "SaiGon", "VungTau", "CaMau", "BinhDuong", "DaLat"
                        }
                    },
                    {
                        {
                            "HaNam", "HaNoi", "DienBien", "CaoBang", "HaiPhong"
                        },
                        {
                            "SaiGon", "VungTau", "CaMau", "BinhDuong", "DaLat"
                        }
                    }
                }
            };
            var array6 = new string[1, 1, 2, 2, 5]
            {
                {
                    {
                        {
                            {
                                "HaNam", "HaNoi", "DienBien", "CaoBang", "HaiPhong"
                            },
                            {
                                "SaiGon", "VungTau", "CaMau", "BinhDuong", "DaLat"
                            }
                        },
                        {
                            {
                                "HaNam", "HaNoi", "DienBien", "CaoBang", "HaiPhong"
                            },
                            {
                                "SaiGon", "VungTau", "CaMau", "BinhDuong", "DaLat"
                            }
                        }
                    }
                }
            };

            var array4 = new string[,,]
            {
                {
                    {
                        "HaNam", "HaNoi", "DienBien", "CaoBang", "HaiPhong"
                    },
                    {
                        "SaiGon", "VungTau", "CaMau", "BinhDuong", "DaLat"
                    }
                },
                {
                    {
                        "HaNam", "HaNoi", "DienBien", "CaoBang", "HaiPhong"
                    },
                    {
                        "SaiGon", "VungTau", "CaMau", "BinhDuong", "DaLat"
                    }
                }
            };

            for (var i = 0; i < array3.GetLength(0); i++)  // string2.GetLength(0): Lấy ra độ dài của chiều thứ 1
            {
                for (var j = 0; j < array3.GetLength(1); j++)  // string2.GetLength(1): Lấy ra độ dài của chiều thứ 2
                {
                    for (var z = 0; z < array3.GetLength(2); z++)  // string2.GetLength(1): Lấy ra độ dài của chiều thứ 3
                    {
                        WriteLine($@"Province name in array: {array3[i, j, z]}");
                    }
                }
            }


            #endregion [Mảng 3 chiều]

            #region [Mảng dích dắc]

            #endregion [Mảng dích dắc]

            #region [Mảng đa chiều] 
            // 4-5-6 chiều

            #endregion [Mảng đa chiều]
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