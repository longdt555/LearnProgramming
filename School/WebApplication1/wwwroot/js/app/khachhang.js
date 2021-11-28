function searchReload(event) {
    event.preventDefault();
    var searchTxt = $('#search-khachhang').val();

    var path = `${window.location.origin}/KhachHang?pageIndex=1&pageSize=20&name=${searchTxt}`;

    window.location.href = path;
};

function search(event) {
    event.preventDefault();

    var searchTxt = $('#search-khachhang').val();

    $.ajax({
        url: "/KhachHang/Search", // Url of backend (can be python, php, etc..)*/
        type: "GET", // data type (can be get, post, put, delete)
        data: {
            pageIndex: 1,
            pageSize: 20,
            name: searchTxt
        }, // data in json format
        success: function (response) { // request returns successed
            $('#khachhang-list').html(response);
        },
        error: function (response) { // // request returns failed
            console.log("error");
        }
    });
};

function deleteRecord(id) {
   
    var searchTxt = $('#search-khachhang').val();
    var pIndex = currentPage;
    var pSize = pageSize;

    $.ajax({
        url: "/KhachHang/Delete", // Url of backend (can be python, php, etc..)*/
        type: "GET", // data type (can be get, post, put, delete)
        data: {
            pageIndex: pIndex,
            pageSize: pSize,
            name: searchTxt,
            id
        }, // data in json format
        success: function (response) { // request returns successed
            $('#khachhang-list').html(response);
        },
        error: function (response) { // // request returns failed
            console.log("error");
        }
    });
};

function ShowAddModal(id) {
    $.ajax({
        url: "/KhachHang/Add",
        type: "GET",
        data: { id: id },
        success: function (response) {
            $('#common-modal').html(response);

            if (id == 0) {
                $('#title').html('Thêm Khách Hàng');
                $('#btn-save').html('Lưu Khách Hàng');
            }
            else {
                $('#title').html('Lưu Khách Hàng');
                $('#btn-save').html('Cập nhật');
            }

            $('#common-modal').modal('show');
        },
        error: function (response) {
            console.log("error");
        }
    });
}

function ReloadList() {
    $.ajax({
        url: "/KhachHang/Search",
        type: "GET",
        data: {
            pageIndex: 1,
            pageSize: 20
        },
        success: function (response) {
            $('#khachhang-list').html(response);
        },
        error: function (response) {
            console.log("error");
        }
    });
}

function SubmitForm() {
    event.preventDefault();

    var model = {
        HoTen: $('#HoTen').val(),
        Email: $('#Email').val(),
        MatKhau: $('#MatKhau').val(),
        RandomKey: $('#RandomKey').val(),
        DangHoatDong: $('#DangHoatDong').val(),
        NhanQuangCao: $('#NhanQuangCao').val(),
        CreatedBy: $('#CreatedBy').val(),
        CreatedDate: $('#CreatedDate').val(),
        UpdatedDate: $('#UpdatedDate').val(),
        UpdatedBy: $('#UpdatedBy').val()
    };

    $.ajax({
        url: "/KhachHang/DoAdd",
        type: "POST",
        data: {
            khachHangModel: model,
        },
        success: function (response) {
            $('#khachhang-list').html(response);
        },
        error: function (response) {
            console.log("error");
        }
    });
}