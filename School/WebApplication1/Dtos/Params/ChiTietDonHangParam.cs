
namespace StoreManagement.Dtos.Params
{
    public class ChiTietDonHangParam
    {
        #region [Construtor]


        public ChiTietDonHangParam(int maDH)
        {
            MaDH = maDH;
        }
       

        public ChiTietDonHangParam()
        {

        }

        #endregion [Construtor]

      
        public int MaDH { get; set; }  // 0

    }
}
