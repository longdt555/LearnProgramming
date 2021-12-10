function DoPaging(pageIndex, pageSize, currentPage, menuName) {
    // make color
    removeClass(".page-item", "active");

    addClass(`.page-item-${pageIndex}`, "active");

    //  common variables
    var pIndex = pageIndex;
    var pSize = pageSize;
    var searchTxt;
    var url = "";
    var id = "";

    if (menuName === "Loai") {
        searchTxt = $("#search-loai").val();
        url = "/Loai/Search";
        id = "loai-list";
    }
    else if (menuName == "KhachHang") {
        searchTxt = $("#search-khachhang").val();
        url = "/KhachHang/Search";
        id = "khachhang-list";
    }
    else if (menuName === "HangHoa") {
        searchTxt = $("#search-hanghoa").val();
        url = "/HangHoa/Search";
        id = "hanghoa-list";
    }
    else if (menuName == "DonHang") {
        searchTxt = $("#search-donhang").val();
        url = "/DonHang/Search";
        id = "donhang-list";
    }
    else if (menuName == "ChiTietDH") {
        searchTxt = $("#search-chitietdonhang").val();
        url = "/ChiTietDH/Search";
        id = "chitietdonhang-list";
    }
    else if (menuName == "Account") {
        searchTxt = $("#search-Account").val();
        url = "/Account/Search";
        id = "account-list";
    }

    $.ajax({
        url: url, // Url of backend (can be python, php, etc..)*/
        type: "GET", // data type (can be get, post, put, delete)
        data: {
            pageIndex: pIndex,
            pageSize: pSize,
            //currentPage: cPage,
            name: searchTxt,
        }, // data in json format
        success: function (response) { // request returns successed
            $(`#${id}`).html(response);
        },
        error: function (response) { // // request returns failed
            console.log("error");
        }
    });
}
