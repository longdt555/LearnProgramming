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
            console.log("hihi");
        }
    });
};