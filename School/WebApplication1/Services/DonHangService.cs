using Microsoft.EntityFrameworkCore.Internal;
using StoreManagement.Context;
using StoreManagement.IServices;
using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreManagement.Dtos;


namespace StoreManagement.Services
{
    public class DonHangService : BaseService, IDonHangService
    {
        public DonHangService(SMDBContext _context) : base(_context) { }

        public int Add(DonHangModel donHangModel)
        {
            DBContext().DonHangs.Add(donHangModel);
            return DBContext().SaveChanges();
        }

        public void Delete(int id)
        {
            var data = (from dh in DBContext().DonHangs where dh.Id == id select dh).FirstOrDefault(); // Lấy ra đối tượng cần được xóa

            if (data == null) return;

            data.IsDeleted = true;
            data.UpdatedDate = DateTime.Now;

            DBContext().DonHangs.Update(data);
            DBContext().SaveChanges();
        }

        public int Edit(DonHangModel donHangModel)
        {
            var data = DBContext().DonHangs.Where(x => x.Id == donHangModel.Id).FirstOrDefault();
            if (data == null) return 0;
            data.PhiVanChuyen = donHangModel.PhiVanChuyen;
            data.ThanhTien = donHangModel.ThanhTien;
            data.TongTien = donHangModel.TongTien;
            data.TrangThaiDonHang = donHangModel.TrangThaiDonHang;
            data.TrangThaiThanhToan = donHangModel.TrangThaiThanhToan;
            DBContext().DonHangs.Update(data);
            return DBContext().SaveChanges();
        }

        public DonHangModel GetById(int id)
        {
            return DBContext().DonHangs.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
        }



        /*
* step 1: tìm ra đối tượng cần được xóa
* step 2: update isDeleted của bản ghi trên = true;             
*/

        // soft delete => IsDeleted 
        //var delete = (from dhsv in DBContext().DonHangs.Where(x => x.Id == id)
        //              select new DonHangModel
        //              {
        //                  IsDeleted = true
        //              }).ToList();
        //// Select * from donhan where isDeleted = true;

        //DBContext().DonHangs.RemoveRange(delete);
        //DBContext().SaveChanges();



        // Select * from donhang where isdeleted = 0 (false)

        //DBContext().Update(delete);
        //DBContext().SaveChanges();

        //    // tim ra ban ghi

        //    // update isdeleted = true

        //    // dbcontet()..update

        //    // savechange();


        //     public List<DonHangModel> Get()
        //     {
        //         var query =
        //(from dh in _context.DonHangs
        // join kh in _context.KhachHangs on dh.TenKhachHang equals kh.Email
        // where kh.Id == dh.Id
        // select new { kh = kh, dh = dh }).ToList();

        //         return query;
        //     }

        // inner join
        // left join
        //public List<DonHangDto> GetDonHangDto()
        //{
        //    //var query = from person in people
        //    //    join pet in pets on person equals pet.Owner into gj
        //    //    from subpet in gj.DefaultIfEmpty()
        //    //    select new { person.FirstName, PetName = subpet?.Name ?? String.Empty };

        //    // JOIN: from [table1] join [table2] on [condition] where [condition] select [model]

        //    var donHangDtos = (from dh in DBContext().DonHangs
        //                       join kh in DBContext().KhachHangs
        //                           on dh.IdKhachHang equals kh.Id into dhkh
        //                       from khlj in dhkh.DefaultIfEmpty()


        //                       where !dh.IsDeleted && !khlj.IsDeleted
        //                       select new DonHangDto
        //                       {
        //                           Id = dh.Id,
        //                           IdKhachHang = dh.IdKhachHang,
        //                           Email = khlj.Email,
        //                           TenKhachHang = khlj.HoTen,
        //                           NgayLap = dh.NgayLap,
        //                           PhiVanChuyen = dh.PhiVanChuyen,
        //                           ThanhTien = dh.ThanhTien,
        //                           TongTien = dh.TongTien,
        //                           TrangThaiDonHang = dh.TrangThaiDonHang,
        //                           TrangThaiThanhToan = dh.TrangThaiThanhToan
        //                       }).ToList();
        //    return donHangDtos;
        //}

        List<DonHangModel> IDonHangService.GetAll()
        {
            var donHang = (from dh in DBContext().DonHangs
                           where dh.IsDeleted == false
                           select new DonHangModel
                           {
                               Id = dh.Id,
                               IdKhachHang = dh.IdKhachHang,
                               NgayLap = dh.NgayLap,
                               PhiVanChuyen = dh.PhiVanChuyen,
                               ThanhTien = dh.ThanhTien,
                               TongTien = dh.TongTien,
                               TrangThaiDonHang = dh.TrangThaiDonHang,
                               TrangThaiThanhToan = dh.TrangThaiThanhToan,

                           }).ToList();

            //foreach (var item in donHang)
            //{
            //    var idsHangHoa = DBContext().ChiTietDHs.Where(x => x.MaDH == item.Id).Select(x => x.MaHH);

            //    var hanhHoas = (from hh in DBContext().HangHoas
            //                    where idsHangHoa.Contains(hh.Id)
            //                    select new HangHoaDto
            //                    {
            //                        TenHH = hh.TenHH,
            //                        MaLoai = hh.MaLoai
            //                    }).ToList();

            //    item.HangHoaDtos = hanhHoas;
            //}

            return donHang;
        }
    }

}
