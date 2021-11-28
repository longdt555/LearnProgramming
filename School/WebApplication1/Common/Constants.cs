namespace StoreManagement.Common
{
    public static class JMessage
    {
        #region [Permission]

        public static string Forbidden = "Bạn không có quyền truy cập";

        #endregion [Permission]

        #region [Required]

        public static string NameRequied = "Tên không được để trống.";

        #endregion [Required]

        #region [Common]

        public static string SaveSuccessed = "Thêm thành công.";

        public static string SaveFailed= "Thêm không thành công.";

        public static string UpdateSuccessed = "Sửa thành công.";

        public static string SomethingWentWrong = "Có lỗi xảy ra, vui lòng thử lại.";
        #endregion [Common]
    }
}
