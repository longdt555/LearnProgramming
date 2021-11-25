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
    $.ajax({
        url: "/ChiTietDH/Add",
        type: "GET",
        data: id,
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
    $.ajax({
        url: "/ChiTietDH/Add",
        type: "GET",
        success: function (response) {
            $('#common-modal').html(response);
            $('#common-modal').modal('show');
        },
        error: function (response) {
            console.log("error");
        }
    });
}

