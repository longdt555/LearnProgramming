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