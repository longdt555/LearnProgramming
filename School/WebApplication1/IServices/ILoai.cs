﻿using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.IServices
{
    public interface ILoai
    {
        List<LoaiModel> GetAll();
    }
}
