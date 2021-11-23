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

function add(event) {
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

var addEdit = function (id) {

    //var url = "/Loai/addEdit?Id=" + id;

    $("#myModalBodyDiv1").load(url, function () {
        $("#myModal1").modal("show");
    });
};