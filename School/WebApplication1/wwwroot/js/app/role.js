﻿function submitForm() {
    debugger; // sử dụng để debug js
    var isValid = true;
    $('#errMsg').html('');

    // lấy giá trị của các trường dữ liệu (js / jquery)
    var name = $('#name').val();
    var name1 = $('#name1').val();

    // xử lý dữ liệu nếu có - cộng trừ nhân chia, ghép dữ liệu, xóa dữ liệu, validate(ABC_9)
    // name == name1

    if (name !== name1) {
        $('#errMsg').html("<span style='color:red'>[Name] phải bằng [Name1]</span>");
        isValid = false;
    }

    // gọi hành động BE

    if (isValid) {
        var model = {
            name: $('#name').val()
        };

        $.ajax({
            url: "/Role/DoSave", // Url of backend (can be python, php, etc..)*/
            type: "POST", // data type (can be get, post, put, delete)
            data: model, // data in json format
            //async : false, // enable or disable async (optional, but suggested as false if you need to populate data afterwards)
            success: function (response) { // request returns successed
                if (response.success) {
                    $('#errMsg').html("<span style='color:red'>Xin chào " + response.data + "</span>");
                }
            },
            error: function (response) { // // request returns failed
                console.log("hihi");
            }
        });
    };

    // xử lý response trả về (data, status, error)

    // thực hiện thay đổi UI
};