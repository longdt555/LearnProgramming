using System.Collections.Generic;
using System.Linq;

namespace StoreManagement.Common.Helpers
{
    public static class ObjectStateHelper
    {
        public static bool IsNull<T>(this T dest)
        {
            return dest is null;
        }

        public static bool IsNullOrEmpty<T>(this List<T> dest)
        {
            if (dest.IsNull())
                return true;
            else if (dest.Any())
                return true;

            return false;

        }
    }
}
