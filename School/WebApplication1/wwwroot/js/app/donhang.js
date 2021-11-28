﻿function searchReload(event) {
    event.preventDefault();
    var searchTxt = $('#search-DonHang').val();

    var path = `${window.location.origin}/DonHang?pageIndex=1&pageSize=20&TrangThaiDonHang=${searchTxt}`;

    window.location.href = path;

};

function search(event) {
    event.preventDefault();

    var searchTxt = $('#search-DonHang').val();

    $.ajax({
        url: "/DonHang/Search",
        type: "GET",
        data: {
            pageIndex: 1,
            pageSize: 20,
            TrangThaiDonHang: searchTxt
        },
        success: function (response) {
            $('#donhang-list').html(response);
        },
        error: function (response) {
            console.log("error");
        }
    });
};

function deleteRecord(id) {
    var searchTxt = $('#search-DonHang').val();
    var pIndex = currentPage;
    var pSize = pageSize;

    $.ajax({
        url: "/DonHang/Delete",
        type: "GET",
        data: {
            pageIndex: pIndex,
            pageSize: pSize,
            TrangThaiDonHang: searchTxt,
            id
        },
        success: function (response) {
            $('#donhang-list').html(response);
        },
        error: function (response) {
            console.log("error");
        }
    });
};

function ShowAddModal(id) {
    $.ajax({
        url: "/DonHang/Add",
        type: "GET",
        data: { id: id },
        success: function (response) {
            $('#common-modal').html(response);

            if (id == 0) {
                $('#title').html('Thêm Đơn Hàng');
                $('#btn-save').html('Lưu Đơn Hàng');
            }
            else {
                $('#title').html('Lưu Đơn Hàng');
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
        url: "/DonHang/Search",
        type: "GET",
        data: {
            pageIndex: 1,
            pageSize: 20
        },
        success: function (response) {
            $('#donhang-list').html(response);
        },
        error: function (response) {
            console.log("error");
        }
    });
}

function SubmitForm() {
    event.preventDefault();

    var model = {
        PhiVanChuyen: $('#PhiVanChuyen').val(),
        ThanhTien: $('#ThanhTien').val(),
        TongTien: $('#TongTien').val(),
        TrangThaiDonHang: $('#TrangThaiDonHang').val(),
        TrangThaiThanhToan: $('#TrangThaiThanhToan').val(),
        CreatedBy: $('#CreatedBy').val(),
        CreatedDate: $('#CreatedDate').val(),
        UpdatedDate: $('#UpdatedDate').val(),
        UpdatedBy: $('#UpdatedBy').val()
    };

    $.ajax({
        url: "/DonHang/DoAdd",
        type: "POST",
        data: {
            donHangModel: model,
        },
        success: function (response) {
            $('#donhang-list').html(response);
        },
        error: function (response) {
            console.log("error")
        }
    });
}