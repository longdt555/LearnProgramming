function searchReload(event) {
    event.preventDefault();
    var searchTxt = $('#search-loai').val();

    var path = `${window.location.origin}/Loai?pageIndex=1&pageSize=20&name=${searchTxt}`;

    window.location.href = path;
};

function search(event) {
    event.preventDefault();

    var searchTxt = $('#search-loai').val();

    $.ajax({
        url: "/Loai/Search", // Url of backend (can be python, php, etc..)*/
        type: "GET", // data type (can be get, post, put, delete)
        data: {
            pageIndex: 1,
            pageSize: 20,
            name: searchTxt
        }, // data in json format
        success: function (response) { // request returns successed
            $('#loai-list').html(response);
        },
        error: function (response) { // // request returns failed
            console.log("error");
        }
    });
};

function deleteRecord(id) {
    var searchTxt = $('#search-loai').val();
    var pIndex = currentPage;
    var pSize = pageSize;

    $.ajax({
        url: "/Loai/Delete", // Url of backend (can be python, php, etc..)*/
        type: "GET", // data type (can be get, post, put, delete)
        data: {
            pageIndex: pIndex,
            pageSize: pSize,
            name: searchTxt,
            id
        }, // data in json format
        success: function (response) { // request returns successed
            $('#loai-list').html(response);
        },
        error: function (response) { // // request returns failed
            console.log("error");
        }
    });
};

function ShowAddModal(id) {
    $.ajax({
        url: "/Loai/Add", // Url of backend (can be python, php, etc..)*/
        type: "GET", // data type (can be get, post, put, delete)
        data: { id: id },
        success: function (response) { // request returns successed
            $('#common-modal').html(response);

            if (id == 0) {
                $('#title').html('Thêm Loại');
                $('#btn-save').html('Lưu Loại');
            }
            else {
                $('#title').html('Lưu Loại');
                $('#btn-save').html('Cập nhật');
            }

            $('#common-modal').modal('show');
        },
        error: function (response) { // // request returns failed
            console.log("error");
        }
    });
};


/// reload lại danh sách tài khoản
function ReloadList() {
    $.ajax({
        url: "/Loai/Search", // Url of backend (can be python, php, etc..)*/
        type: "GET", // data type (can be get, post, put, delete)
        data: {
            pageIndex: 1,
            pageSize: 20
        }, // data in json format
        success: function (response) { // request returns successed
            $('#loai-list').html(response);
        },
        error: function (response) { // // request returns failed
            console.log("error");
        }
    });
};

/// thực hiện lưu tài khoản đồng thời reload lại danh sách tài khoản
function SubmitForm() {
    debugger;
    event.preventDefault();

    var model = {
        Id: $('#Id').val(),
        TenLoai: $('#TenLoai').val(),
        Mota: $('#Mota').val(),
        MaLoaiCha: $('#MaLoaiCha').val(),
        CreatedBy: $('#CreatedBy').val(),
        CreatedDate: $('#CreatedDate').val(),
        UpdatedDate: $('#UpdatedDate').val(),
        UpdatedBy: $('#UpdatedBy').val()
    };

    if (model.TenLoai == '') {
        alert("Không được bỏ trống Tên Loại");
    }
    else if (model.Mota == '') {
        alert("Không được bỏ trống Mô Tả");
    }
    else if (model.MaLoaiCha == '' || model.MaLoaiCha == '0') {
        alert("Không được bỏ trống Mã Loại Cha");
    }
    else if (model.CreatedBy == '' || model.CreatedBy == '0') {
        alert("Không được bỏ trống Created By");
    }
    else if (model.UpdatedBy == '' || model.UpdatedBy == '0') {
        alert("Không được bỏ trống Updated By");
    }
    else {
        $.ajax({
            url: "/Loai/DoAdd", // Url of backend (can be python, php, etc..)*/
            type: "POST", // data type (can be get, post, put, delete)
            data: {
                loaiModel: model,
            },
            success: function (response) { // request returns successed
                ReloadList();
            },
            error: function (response) { // // request returns failed
                console.log("error");
            }
        });
    }

};