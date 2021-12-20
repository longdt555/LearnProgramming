function searchReload(event) {
    event.preventDefault();
    var searchTxt = $("#search-HangHoa").val();

    var path = `${window.location.origin}/HangHoa?pageIndex=1&pageSize=20&name=${searchTxt}`;

    window.location.href = path;
};

function search(event) {
    event.preventDefault();

    var searchTxt = $("#search-HangHoa").val();

    $.ajax({
        url: "/HangHoa/Search", // Url of backend (can be python, php, etc..)*/
        type: "GET", // data type (can be get, post, put, delete)
        data: {
            pageIndex: 1,
            pageSize: 20,
            name: searchTxt
        }, // data in json format
        success: function (response) { // request returns successed
            $("#hanghoa-list").html(response);
        },
        error: function (response) { // // request returns failed
            console.log("error");
        }
    });
};

function deleteRecord(id) {
    var searchTxt = $("#search-HangHoa").val();
    var pIndex = currentPage;
    var pSize = pageSize;

    $.ajax({
        url: "/HangHoa/Delete", // Url of backend (can be python, php, etc..)*/
        type: "GET", // data type (can be get, post, put, delete)
        data: {
            pageIndex: pIndex,
            pageSize: pSize,
            name: searchTxt,
            id
        }, // data in json format
        success: function (response) { // request returns successed
            $("#hanghoa-list").html(response);
        },
        error: function (response) { // // request returns failed
            console.log("error");
        }
    });
};

function ShowAddModal(id) {
    $.ajax({
        url: "/HangHoa/Add",
        type: "GET",
        data: { id: id },
        success: function (response) {
            $("#common-modal").html(response);

            if (id == 0) {
                $("#title").html("Thêm Hàng Hóa");
                $("#btn-save").html("Lưu Hàng Hóa");
            }
            else {
                $("#title").html("Lưu Hàng Hóa");
                $("#btn-save").html("Cập nhật");
            }

            $("#common-modal").modal("show");
        },
        error: function (response) {
            console.log("error");
        }
    });
}

function ReloadList() {
    $.ajax({
        url: "/HangHoa/Search",
        type: "GET",
        data: {
            pageIndex: 1,
            pageSize: 20
        },
        success: function (response) {
            $("#hanghoa-list").html(response);
        },
        error: function (response) {
            console.log("error");
        }
    });
}

function SubmitForm() {
    event.preventDefault();
    var model = {
        TenHH: $("#TenHH").val(),
        Id: $("#IdHangHoa").val(),
        TenLoai: $("#TenLoai").val(),
        SoLuong: $("#SoLuong").val(),
        DonGia: $("#DonGia").val(),
        GiamGia: $("#GiamGia").val(),
        ChiTiet: $("#ChiTiet").val(),
        IdLoai: $("#IdLoai").val(),
        MaLoai: $("#MaLoai").val(),
        //CreatedBy: $('#CreatedBy').val,
        //UpdatedBy: $('#UpdatedBy').val(),
        CreatedDate: $("#CreatedDate").val(),
        UpdatedDate: $("#UpdatedDate").val(),
    };

    if (model.TenHH == "") {
        alert("Không được bỏ trống Tên Hàng Hóa");
    }
    else if (model.TenLoai == "") {
        alert("Không được bỏ trống Tên Loại");
    }
    else if (model.SoLuong == "" || model.SoLuong == "0") {
        alert("Không được bỏ trống Số Lượng");
    }
    else if (model.DonGia == "" || model.DonGia == "0") {
        alert("Không được bỏ trống Đơn Giá");
    }
    else if (model.GiamGia == "") {
        alert("Không được bỏ trống Giảm Giá");
    }
    else if (model.ChiTiet == "") {
        alert("Không được bỏ trống Chi Tiết");
    }
    else if (model.IdLoai == "") {
        alert("Không được bỏ trống Id Loại");
    }
    else if (model.MaLoai == "") {
        alert("Không được bỏ trống Mã Loại");
    }
    else {
        $.ajax({
            url: "/HangHoa/DoAdd",
            type: "POST",
            data: {
                hangHoaModel: model
            },
            success: function (response) {
                ReloadList();
            },
            error: function (response) {
                console.log("error");
            }
        });
    }

};