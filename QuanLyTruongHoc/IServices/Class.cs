using QuanLyTruongHoc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QuanLyTruongHoc.Helper.Helper;

namespace QuanLyTruongHoc.IServices
{
    public class Class : BaseService
    {
        public static void GetValueFromUser()
        {
            string row1 = GetValue("Nhập tên");
            string row2 = GetValue("Nhập môn học");
            var addValue = new AddClass();
            addValue.AddValue("lophoc", row1, row2);
        }
        public static void UpdateFromUser()
        {
            ////UPDATE
            int id = ConvertToInt(GetValue("Chọn id lớp học cần sửa"));
            string name = GetValue("Nhập tên");
            string subject = GetValue("Nhập môn học");
            var updateById = new UpdateClass();
            updateById.UpdateValue("lophoc", "name", name, "subject", subject, id);
        }
        public static void DeleteFromUser()
        {
            //DELETE
            int idDelete = ConvertToInt(GetValue("Nhập id cần xóa"));
            var deleteById = new Delete();
            deleteById.DeleteById("lophoc", idDelete);

        }
    }
}
