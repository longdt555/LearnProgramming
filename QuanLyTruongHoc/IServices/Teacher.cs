using QuanLyTruongHoc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QuanLyTruongHoc.Helper.Helper;

namespace QuanLyTruongHoc.IServices
{
    public class Teacher : BaseService
    {
        public static void GetValueFromUser()
        {
            string row1 = GetValue("Nhập tên");
            int row2 = ConvertToInt(GetValue("Nhập tuổi"));
            var addValue = new Add();
            addValue.AddValue("giaovien", row1, row2);
        }
        public static void UpdateFromUser()
        {
            ////UPDATE
            int id = ConvertToInt(GetValue("Chọn id giáo viên cần sửa"));
            string nameUpdate = GetValue("Nhập tên");
            int ageUpdate = ConvertToInt(GetValue("Nhập tuổi"));
            var updateById = new Update();
            updateById.UpdateValue("giaovien", "name", nameUpdate, "age", ageUpdate, id);
        }
        public static void DeleteFromUser()
        {
            //DELETE
            int idDelete = ConvertToInt(GetValue("Nhập id cần xóa"));
            var deleteById = new Delete();
            deleteById.DeleteById("giaovien", idDelete);

        }
    }
}
