using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    // Định nghĩa những hành vi cần được triển khai, cần có cho một lớp khác

    public abstract class Abstract
    {
        // Phương thức (method):  bao gồm abstract method, normal method

        #region [abstract methods]
        // Dùng từ khóa abstract
        // Abstract method phải nằm trong 1 Abstract class
        // Abstract method: không có thân hàm
        public abstract void SayHelloAbstract();
        public abstract string SayHelloAbstractV2();

        #endregion [abstract methods]

        #region [normal methods]

        public string SayHello()
        {
            return "Hello";
        }

        #endregion [normal methods]

        #region [variables]

        //  Biến: dùng tất cả các loại biến

        public int Code = 10;
        public static int CodeStatic = 10;
        public const int CodeConst = 10;

        #endregion [variables]
    }


}