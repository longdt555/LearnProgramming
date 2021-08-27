using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson.Common.Enums
{
    public enum Color
    {
        RED, // 0
        BLUE, // 1
        YELLOW // 2
    }
    public enum Color1
    {
        RED = 1,
        BLUE = 2,
        YELLOW
    }

    public enum Color2
    {
        RED = 2,
        BLUE = 1,
        YELLOW
    }

    public enum Color3
    {
        RED = 2,
        BLUE = 4,
        YELLOW
    }


    public enum IdentityLesson
    {
        Lesson1 = 1,
        Lesson2,
        Lesson3,
        Lesson4,
        Lesson5,
        Lesson6,
        Lesson7,
    }
}
