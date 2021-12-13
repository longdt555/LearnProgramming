function DoPaging(pageIndex, pageSize, menuName, totalPages, action, isUpdatePageSize) {
    // action: prev - next
    // isUpdatePageSize: thay đổi số lượng phần tử theo select
    
    //  common variables
    var searchTxt;
    var url = "";
    var id = "";

    // BEGIN: Xử lý pageIndex đối với trường hợp next - prev 
    var currentPage = 0;
    if (checkExistClass(".page-item", "active")) {
        currentPage = parseInt(getAttrValue(".page-item.active", "index"));
    }

    // BEGIN: Xử lý đối với trường hợp thay đổi số trang theo select
    if (isUpdatePageSize) {

    } else {
        if (action === 1) {
            pageIndex = currentPage - 1;
        }

        if (action === 2) {
            pageIndex = currentPage + 1;
        }
    }

    // END

    // BEGIN: Thực hiện ẩn hiện nút: Prev + Next

    if (pageIndex > 1) {
        removeClass(".active-pre", "hide");
    } else {
        addClass(".active-pre", "hide");
    }

    if (pageIndex === totalPages) {
        addClass(".active-next", "hide");
    } else {
        removeClass(".active-next", "hide");
    }

    //END

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
            pageIndex: pageIndex,
            pageSize: pageSize,
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


    // BEGIN: Thực hiện bôi xanh trang hiện tại
    removeClass(".page-item", "active");

    addClass(`.page-item-${pageIndex}`, "active");

    // END
}
