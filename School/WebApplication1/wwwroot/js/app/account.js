function searchReload(event) {
    event.preventDefault();
    var searchTxt = $('#search-Account').val();

    var path = `${window.location.origin}/Account?pageIndex=1&pageSize=20&name=${searchTxt}`;

    window.location.href = path;
};

function search(event) {
    event.preventDefault();

    var searchTxt = $('#search-Account').val();

    $.ajax({
        url: "/Account/Search", // Url of backend (can be python, php, etc..)*/
        type: "GET", // data type (can be get, post, put, delete)
        data: {
            pageIndex: 1,
            pageSize: 20,
            name: searchTxt
        }, // data in json format
        success: function (response) { // request returns successed
            $('#account-list').html(response);
        },
        error: function (response) { // // request returns failed
            console.log("error");
        }
    });
};


/// xóa tài khoản đồng thời reload lại danh sách tài khoản
function deleteRecord(id) {
    var searchTxt = $('#search-Account').val();
    var pIndex = currentPage;
    var pSize = pageSize;

    $.ajax({
        url: "/Account/Delete", // Url of backend (can be python, php, etc..)*/
        type: "GET", // data type (can be get, post, put, delete)
        data: {
            pageIndex: pIndex,
            pageSize: pSize,
            name: searchTxt,
            id
        }, // data in json format
        success: function (response) { // request returns successed
            $('#account-list').html(response);
        },
        error: function (response) { // // request returns failed
            console.log("error");
        }
    });
};

/// hiển thị modal thêm tài khoản
function ShowAddModal(id) {
    $.ajax({
        url: "/Account/Add", // Url of backend (can be python, php, etc..)*/
        type: "GET", // data type (can be get, post, put, delete)
        data: { id: id },
        success: function (response) { // request returns successed
            $('#common-modal').html(response);

            if (id == 0) {
                $('#title').html('Thêm người dùng');
                $('#btn-save').html('Lưu người dùng');
            }
            else {
                $('#title').html('Lưu người dùng');
                $('#btn-save').html('Cập nhật');
            }

            $('#common-modal').modal('show');
        },
        error: function (response) { // // request returns failed
            console.log("error");
        }
    });
}


/// reload lại danh sách tài khoản
function ReloadList() {
    $.ajax({
        url: "/Account/Search", // Url of backend (can be python, php, etc..)*/
        type: "GET", // data type (can be get, post, put, delete)
        data: {
            pageIndex: 1,
            pageSize: 20
        }, // data in json format
        success: function (response) { // request returns successed
            $('#account-list').html(response);
        },
        error: function (response) { // // request returns failed
            console.log("error");
        }
    });
}

/// thực hiện lưu tài khoản đồng thời reload lại danh sách tài khoản
function SubmitForm() {
    event.preventDefault();

    var model = {
        Id: $('#Id').val(),
        UserName: $('#UserName').val(),
        Password: $('#Password').val(),
        Role: $('#Role').val(),
        CreatedBy: $('#CreatedBy').val(),
        CreatedDate: $('#CreatedDate').val(),
        UpdatedBy: $('#UpdatedBy').val(),
        UpdatedDate: $('#UpdatedDate').val(),
    };

    if (model.UserName == '') {
        alert("Không được bỏ trống Tên Tài Khoản");
    }
    else if (model.Password == '') {
        alert("Không được bỏ trống Mật Khẩu");
    }
    else if (model.Role == '' || model.Role == '0') {
        alert("Không được bỏ trống Phân Quyền");
    }
    else if (model.CreatedBy == '' || model.CreatedBy == '0') {
        alert("Không được bỏ trống Created By");
    }
    else if (model.UpdatedBy == '' || model.UpdatedBy == '0') {
        alert("Không được bỏ trống Updated By");
    }
    else {
        $.ajax({
            url: "/Account/DoAdd", // Url of backend (can be python, php, etc..)*/
            type: "POST", // data type (can be get, post, put, delete)
            data: {
                accountModel: model,
            },
            success: function (response) { // request returns successed
                ReloadList();
            },
            error: function (response) { // // request returns failed
                console.log("error");
            }
        });
    }
}