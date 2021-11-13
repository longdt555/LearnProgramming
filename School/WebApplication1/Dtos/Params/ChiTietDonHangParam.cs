
namespace StoreManagement.Dtos.Params
{
    public class ChiTietDonHangParam
    {
        #region [Construtor]

        public ChiTietDonHangParam(string name, int maDH)
        {
            Name = name;
            MaDH = maDH;
        }

        public ChiTietDonHangParam(int maDH)
        {
            MaDH = maDH;
        }
        public ChiTietDonHangParam(string maDH)
        {
            MaDHv2 = maDH;
        }

        public ChiTietDonHangParam()
        {

        }

        #endregion [Construtor]

        public string Name { get; set; }

        public int MaDH { get; set; }  // 0
        public string MaDHv2 { get; set; }  // 0
    }
}
