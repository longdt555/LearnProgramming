function DoPaging(pageIndex, pageSize, currentPage, menuName) {
    debugger;
    if (menuName == 'Loai') {
        var searchTxt = $('#search-loai').val();
        var pIndex = pageIndex;
        var pSize = pageSize;
        //var cPage = currentPage;
        //var paging = $('#i').val();

        $.ajax({
            url: "/Loai/Search", // Url of backend (can be python, php, etc..)*/
            type: "GET", // data type (can be get, post, put, delete)
            data: {
                pageIndex: pIndex,
                pageSize: pSize,
                //currentPage: cPage,
                name: searchTxt,
            }, // data in json format
            success: function (response) { // request returns successed
                $('#loai-list').html(response);

                $("li").removeClass("active");

            },
            error: function (response) { // // request returns failed
                console.log("error");
            }
        });
    }
    else if (menuName == 'KhachHang') {
        var searchTxt = $('#search-khachhang').val();
        var pIndex = pageIndex;
        var pSize = pageSize;

        $.ajax({
            url: "/KhachHang/Search", // Url of backend (can be python, php, etc..)*/
            type: "GET", // data type (can be get, post, put, delete)
            data: {
                pageIndex: pIndex,
                pageSize: pSize,
                name: searchTxt,
            }, // data in json format
            success: function (response) { // request returns successed
                $('#khachhang-list').html(response);

                //$("li").addClass("active");
                $("li").removeClass("active");

                //$(pageIndex).css({ "color": "#fff", "background-color": "#007bff", "border-color": "#007bff" });
            },
            error: function (response) { // // request returns failed
                console.log("error");
            }
        });
    }
    else if (menuName == 'HangHoa') {
        var searchTxt = $('#search-hanghoa').val();
        var pIndex = pageIndex;
        var pSize = pageSize;

        $.ajax({
            url: "/HangHoa/Search", // Url of backend (can be python, php, etc..)*/
            type: "GET", // data type (can be get, post, put, delete)
            data: {
                pageIndex: pIndex,
                pageSize: pSize,
                name: searchTxt,
            }, // data in json format
            success: function (response) { // request returns successed
                $('#hanghoa-list').html(response);

                //$("li").addClass("active");
                $("li").removeClass("active");

                //$(pageIndex).css({ "color": "#fff", "background-color": "#007bff", "border-color": "#007bff" });
            },
            error: function (response) { // // request returns failed
                console.log("error");
            }
        });
    }
    else if (menuName == 'DonHang') {
        var searchTxt = $('#search-donhang').val();
        var pIndex = pageIndex;
        var pSize = pageSize;

        $.ajax({
            url: "/DonHang/Search", // Url of backend (can be python, php, etc..)*/
            type: "GET", // data type (can be get, post, put, delete)
            data: {
                pageIndex: pIndex,
                pageSize: pSize,
                name: searchTxt,
            }, // data in json format
            success: function (response) { // request returns successed
                $('#donhang-list').html(response);

                //$("li").addClass("active");
                $("li").removeClass("active");

                //$(pageIndex).css({ "color": "#fff", "background-color": "#007bff", "border-color": "#007bff" });
            },
            error: function (response) { // // request returns failed
                console.log("error");
            }
        });
    }
    else if (menuName == 'ChiTietDH') {
        var searchTxt = $('#search-chitietdonhang').val();
        var pIndex = pageIndex;
        var pSize = pageSize;

        $.ajax({
            url: "/ChiTietDH/Search", // Url of backend (can be python, php, etc..)*/
            type: "GET", // data type (can be get, post, put, delete)
            data: {
                pageIndex: pIndex,
                pageSize: pSize,
                name: searchTxt,
            }, // data in json format
            success: function (response) { // request returns successed
                $('#chitietdonhang-list').html(response);

                //$("li").addClass("active");
                $("li").removeClass("active");

                //$(pageIndex).css({ "color": "#fff", "background-color": "#007bff", "border-color": "#007bff" });
            },
            error: function (response) { // // request returns failed
                console.log("error");
            }
        });
    }
    else if (menuName == 'Account') {
        var searchTxt = $('#search-Account').val();
        var pIndex = pageIndex;
        var pSize = pageSize;

        $.ajax({
            url: "/Account/Search", // Url of backend (can be python, php, etc..)*/
            type: "GET", // data type (can be get, post, put, delete)
            data: {
                pageIndex: pIndex,
                pageSize: pSize,
                name: searchTxt,
            }, // data in json format
            success: function (response) { // request returns successed
                $('#account-list').html(response);

                //$("li").addClass("active");
                $("li").removeClass("active");

                //$(pageIndex).css({ "color": "#fff", "background-color": "#007bff", "border-color": "#007bff" });
            },
            error: function (response) { // // request returns failed
                console.log("error");
            }
        });
    }

}



