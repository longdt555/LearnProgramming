function searchReload(event) {
    event.preventDefault();
    var searchTxt = $('#search-chitietdonhang').val();

    var path = `${window.location.origin}/ChiTietDH?pageIndex=1&pageSize=20&maDH=${searchTxt}`;

    window.location.href = path;
};

function search(event) {
    debugger;
    event.preventDefault();

    var searchTxt = $('#search-chitietdonhang').val();

    $.ajax({
        url: "/ChiTietDH/Search",
        type: "GET",
        data: {
            pageIndex: 1,
            pageSize: 20,
            maDH: searchTxt
        },
        success: function (response) {
            $('#chitietdonhang-list').html(response);
        },
        error: function (response) {
            console.log("error");
        }
    });
};

function deleteRecord(id) {
    var searchTxt = $('#search-chitietdonhang').val();
    var pIndex = currentPage;
    var pSize = pageSize;

    $.ajax({
        url: "/ChiTietDH/Delete",
        type: "GET",
        data: {
            pageIndex: pIndex,
            pageSize: pSize,
            maDH: searchTxt,
            id
        },
        success: function (response) {
            $('#chitietdonhang-list').html(response);
        },
        error: function (response) {
            console.log("error");
        }
    });
};

function ShowAddModal(id) {
    //debugger;
    $.ajax({
        url: "/ChiTietDH/Add",
        type: "GET",
        data: { id: id },
        success: function (response) {
            $('#common-modal').html(response);

            if (id == 0) {
                $('#title').html('Thêm Chi Tiết Đơn Hàng');
                $('#btn-save').html('Lưu Chi Tiết Đơn Hàng');
            }
            else {
                $('#title').html('Thêm Chi Tiết Đơn Hàng');
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
        url: "/ChiTietDH/Search",
        type: "GET",
        data: {
            pageIndex: 1,
            pageSize: 20
        },
        success: function (response) {
            $('#chitietdonhang-list').html(response);
        },
        error: function (response) {
            console.log("error");
        }
    });
}

function SubmitForm() {
    event.preventDefault();

    var model = {
        Id: $('#Id').val(),
        MaDH: $('#MaDH').val(),
        MaHH: $('#MaHH').val(),
        DonGia: $('#DonGia').val(),
        SoLuong: $('#SoLuong').val(),
        CreatedBy: $('#CreatedBy').val(),
        CreatedDate: $('#CreatedDate').val(),
        UpdatedDate: $('#UpdatedDate').val(),
        UpdatedBy: $('#UpdatedBy').val(),
    };

    if (model.MaDH == '' || model.MaDH == '0') {
        alert("Không được bỏ trống Mã Đơn Hàng");
    }
    else if (model.MaHH == '' || model.MaHH == '0') {
        alert("Không được bỏ trống Mã Hàng Hóa");
    }
    else if (model.DonGia == '' || model.DonGia == '0') {
        alert("Không được bỏ trống Đơn Giá");
    }
    else if (model.SoLuong == '' || model.SoLuong == '0') {
        alert("Không được bỏ trống Số Lượng");
    }
    else if (model.CreatedBy == '' || model.CreatedBy == '0') {
        alert("Không được bỏ trống Created By");
    }
    else if (model.UpdatedBy == '' || model.UpdatedBy == '0') {
        alert("Không được bỏ trống Updated By");
    }
    else {
        $.ajax({
            url: "/ChiTietDH/DoAdd",
            type: "POST",
            data: {
                chiTietDHModel: model,
            },
            success: function (response) {
                ReloadList();
            },
            error: function (response) {
                console.log("error");
            }
        });
    }

}

