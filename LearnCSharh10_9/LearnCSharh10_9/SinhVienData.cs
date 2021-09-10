using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LearnCSharh10_9.Helper;
using static LearnCSharh10_9.XepLoaiHocLuc;

namespace LearnCSharh10_9
{
    public class SinhVienData
    {
        public int GenerateId(List<SinhVien> sinhViens)
        {
            int maxId = 0;
            //2,5,3,7
            if (sinhViens.Count == 0 && sinhViens == null)
            {
                return maxId;
            }

            for (int i = 0; i < sinhViens.Count; i++)
            {
                if (sinhViens[i].ID < maxId)
                {
                    continue;
                }
                maxId = sinhViens[i].ID;
            }
            return maxId + 1;
        }
        public int GetTotal(List<SinhVien> sinhViens)
        {
            return sinhViens == null ? 0 : sinhViens.Count();
        }

        //tạo 1 hàm nhận tham chiếu list sinh viên
        //cho phép nhập dữ liệu vào 1 đối tượng sv
        //add đổi tượng sv vào list sv
        //return id của sv

        public int Add(List<SinhVien> sinhViens)
        {
            var sinhVien = new SinhVien();
            sinhVien.ID = GenerateId(sinhViens);
            sinhVien.Name = GetValue("Nhập tên");
            sinhVien.Sex = GetValue("Nhập giới tính");
            sinhVien.Age = ConvertToInt(GetValue("Nhập tuổi"));
            sinhVien.DiemToan = ConvertToDouble(GetValue("Nhập điểm toán"));
            sinhVien.DiemLy = ConvertToDouble(GetValue("Nhập điểm lý"));
            sinhVien.DiemHoa = ConvertToDouble(GetValue("Nhập điểm hóa"));
            sinhVien.DiemTB = CalculateAvgScore(sinhVien.DiemToan, sinhVien.DiemLy, sinhVien.DiemHoa);
            sinhVien.HocLuc = RankedAcademic(sinhVien.DiemTB);
            sinhViens.Add(sinhVien);
            return sinhVien.ID;
        }
        public SinhVien GetSvById(List<SinhVien> sinhViens, int id)
        {
            for (int i = 0; i < sinhViens.Count; i++)
            {
                if (sinhViens[i].ID == id)
                {
                    return sinhViens[i];
                }
            }
            return null;
        }
        //tim doi tuong qua id
        //nhập thông tin thay đổi
        public bool Update(List<SinhVien> sinhViens, int id)
        {
            var sinhVien = GetSvById(sinhViens, id);
            if (sinhVien == null)
            {
                return false;
            }
            sinhVien.Name = GetValue("Nhập tên");
            sinhVien.Sex = GetValue("Nhập giới tính");
            sinhVien.Age = ConvertToInt(GetValue("Nhập tuổi"));
            sinhVien.DiemToan = ConvertToDouble(GetValue("Nhập điểm toán"));
            sinhVien.DiemLy = ConvertToDouble(GetValue("Nhập điểm lý"));
            sinhVien.DiemHoa = ConvertToDouble(GetValue("Nhập điểm hóa"));
            sinhVien.DiemTB = CalculateAvgScore(sinhVien.DiemToan, sinhVien.DiemLy, sinhVien.DiemHoa);
            sinhVien.HocLuc = RankedAcademic(sinhVien.DiemTB);
            return true;
        }
        public bool Delete(List<SinhVien> sinhViens, int id)
        {
            var sinhVien = GetSvById(sinhViens, id);
            if (sinhVien == null)
            {
                return false;
            }
            return sinhViens.Remove(sinhVien);

        }
        public List<SinhVien> SearchName(List<SinhVien> sinhViens, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return sinhViens;
            }
            var newList = new List<SinhVien>();
            foreach (var item in sinhViens)
            {
                if (item.Name == name)
                {
                    newList.Add(item);
                }
            }
            return newList;
        }
        public List<SinhVien> SortByAvgScore(List<SinhVien> sinhViens, string sortCondition)
        {
            switch (sortCondition)
            {
                case SortCondition.Esc:
                    return sinhViens.OrderBy(x => x.DiemTB).ToList();

                case SortCondition.Desc:
                    return sinhViens.OrderByDescending(x => x.DiemTB).ToList();
                default:
                    return sinhViens;
            }
        }
        public List<SinhVien> SortByName(List<SinhVien> sinhViens)
        {
            return sinhViens.OrderBy(x => x.Name).ToList();
        }
        public List<SinhVien> SortById(List<SinhVien> sinhViens)
        {
            return sinhViens.OrderBy(x => x.ID).ToList();
        }
        public void Print(List<SinhVien> sinhViens)
        {
            foreach (var item in sinhViens)
            {
                Console.WriteLine($"ID: {item.ID}\nName: {item.Name}\nGiới tính: {item.Sex}\n" +
                    $"Tuổi: {item.Age}\nĐiểm toán: {item.DiemToan}\nĐiểm Lý: {item.DiemLy}\n" +
                    $"Điểm hóa: {item.DiemHoa}\nĐiểm TB: {item.DiemTB}\nHọc lực: {item.HocLuc}");
            }
        }
        #region FuncionHelper
        private double CalculateAvgScore(double diemToan, double diemLy, double diemHoa)
        {
            return (diemToan + diemLy + diemHoa) / 3;
        }
        private string RankedAcademic(double avgScore)
        {
            if (avgScore >= 8)
            {
                return Gioi;
            }
            if (avgScore < 8 && avgScore >= 6.5)
            {
                return Kha;
            }
            if (avgScore < 6.5 && avgScore >= 5)
            {
                return TB;
            }
            if (avgScore < 5)
            {
                return Yeu;
            }
            return Error;
        }

        public static List<SinhVien> BubbleSort(List<SinhVien> sinhViens)
        {
            for (int i = 0; i < sinhViens.Count; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (sinhViens[j - 1].DiemTB > sinhViens[j].DiemTB)
                    {
                        SinhVien temp = sinhViens[j - 1];
                        sinhViens[j - 1] = sinhViens[j];
                        sinhViens[j] = temp;
                    }
                }
            }
            return sinhViens;
        }
        #endregion
    }
}
