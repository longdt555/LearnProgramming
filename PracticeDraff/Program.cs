using System;
using System.Collections.Generic;
using PracticeDraff;

namespace Practice2Draff
{
    public class Program
    {
        //    T-Type
        //    E-Element
        //    K-Key
        //    N-Number
        //    V-Value
        public static void Main(string[] args)
        {
            ///// Chương trình quản lý thế giới
            //var students = new InitialGenericObject<Student>(5);
            //// get student by id
            //float studentId = 2;
            //var student = students.GetById(studentId);
            //var totalStudents = students.Total();


            //var animals = new InitialGenericObject<Animal>(5);
            //string animalId = "2";
            //var animal = students.GetById(animalId);

            //// get animal by id

            //// nhacua, duongxa, ...

            //// Convert any data type to int
            //// once data type = > funciton

            var students = new Student[10];
            var studentCl = new Student();

            var animals = new Animal[10];
            var animal = new Animal();
            animal.GetAnimalById(animals, "2");


            var flats = new Flat[10];

            //////

            var electric = new BaseModel<Electric>(10);
            electric.GetById("10");
            electric.Total();

            ///
            var students2 = new BaseModel<Student>(10);
            students2.GetById(2);
            students2.Total();
        }

        public int ConvertDoubleToInt(double value)
        {
            return Convert.ToInt32(value);
        }
        public int ConvertFloatToInt(float value)
        {
            return Convert.ToInt32(value);
        }
    }
}