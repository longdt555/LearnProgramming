function searchReload(event) {
    event.preventDefault();
    var searchTxt = $('#search-HangHoa').val();

    var path = `${window.location.origin}/HangHoa?pageIndex=1&pageSize=20&name=${searchTxt}`;

    window.location.href = path;
};

function search(event) {
    event.preventDefault();

    var searchTxt = $('#search-HangHoa').val();

    $.ajax({
        url: "/HangHoa/Search", // Url of backend (can be python, php, etc..)*/
        type: "GET", // data type (can be get, post, put, delete)
        data: {
            pageIndex: 1,
            pageSize: 20,
            name: searchTxt
        }, // data in json format
        success: function (response) { // request returns successed
            $('#hanghoa-list').html(response);
        },
        error: function (response) { // // request returns failed
            console.log("error");
        }
    });
};

function deleteRecord(id) {
    var searchTxt = $('#search-HangHoa').val();
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
            $('#hanghoa-list').html(response);
        },
        error: function (response) { // // request returns failed
            console.log("error");
        }
    });
};