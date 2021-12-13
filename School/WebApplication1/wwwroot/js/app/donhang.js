function searchReload(event) {
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
        Id: $('#Id').val(),
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

    if (model.PhiVanChuyen == '' || model.PhiVanChuyen == '0') {
        alert("Không được bỏ trống Phí Vận Chuyển");
    }
    else if (model.ThanhTien == '' || model.ThanhTien == '0') {
        alert("Không được bỏ trống Thành Tiền");
    }
    else if (model.TongTien == '' || model.TongTien == '0') {
        alert("Không được bỏ trống Tổng Tiền");
    }
    else if (model.TrangThaiDonHang == '') {
        alert("Không được bỏ trống Trạng Thái Đơn Hàng");
    }
    else if (model.TrangThaiThanhToan == '') {
        alert("Không được bỏ trống Trạng Thái Thanh Toán");
    }
    else if (model.CreatedBy == '' || model.CreatedBy == '0') {
        alert("Không được bỏ trống Created By");
    }
    else if (model.UpdatedBy == '' || model.UpdatedBy == '0') {
        alert("Không được bỏ trống Updated By");
    }
    else {
        $.ajax({
            url: "/DonHang/DoAdd",
            type: "POST",
            data: {
                donHangModel: model,
            },
            success: function (response) {
                ReloadList();
            },
            error: function (response) {
                console.log("error")
            }
        });
    }

}