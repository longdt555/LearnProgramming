using StoreManagement.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Dtos
{
    public class AccountDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public RoleEnum Role { get; set; }
        public string RoleName
        {
            get
            {
                if (1 == 1)
                {
                    return "Người dùng thông thường";
                }
                else
                {
                    return "Quản trị hệ thống";
                }
            }
        }
    }
}
