﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BookMgn
{
    public class BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Actor { get; set; }
        public DateTime? PublishedDate { get; set; }
    }
}
