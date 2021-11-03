namespace StoreManagement.Dtos.Params
{
    public class SearchParam<T>
    {

        #region [Constructor]
        public SearchParam(int pageIndex, int pageSize, T filter)
        {
            _pageIndex = pageIndex;
            _pageSize = pageSize;
            _filter = filter;
        }

        #endregion [Constructor]

        #region [Params]
        private int _pageIndex { get; set; }
        private int _pageSize { get; set; }
        private T _filter { get; set; }

        #endregion [Params]

        #region [Encapsulation / Getter]

        public int PageIndex => _pageIndex == 0 ? 1 : _pageIndex;
        public int PageSize => _pageSize == 0 ? 20 : _pageSize;
        public T Filter() => _filter;

        #endregion [Encapsulation / Getter]
    }
}