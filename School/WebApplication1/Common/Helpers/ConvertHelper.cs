using System;

namespace StoreManagement.Common.Helpers
{
    public static class ConvertHelper
    {
        public static int ConvertToInt<T>(T model)
        {
            try
            {
                return Convert.ToInt32(model);
            }
            catch 
            {
                return 0;
            }
        }
    }
}
