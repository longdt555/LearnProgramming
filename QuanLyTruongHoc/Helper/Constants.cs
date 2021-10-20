using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTruongHoc.Helper
{
    public static class Constants
    {
        private static Dictionary<string, string> Queries = new Dictionary<string, string>()
        {
        };
    }

    public static class Queries
    {
        public static string DeleteById = "DELETE {0} WHERE ID = {1}";
        public static string Insert = "INSERT INTO {0} ({1}) VALUES ({2})";
        public static string UpdateById = "UPDATE {0} SET ({1}) = {2}, ({3}) = {4} WHERE {5} = {6}";
        public static string SelectById = "SELECT * FROM {0}";
    }
}
