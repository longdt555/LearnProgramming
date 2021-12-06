function DoPaging(pageIndex, pageSize, menuName) {
    debugger;
    if (menuName == 'Loai') {
        var searchTxt = $('#search-loai').val();
        var pIndex = pageIndex;
        var pSize = pageSize;

        $.ajax({
            url: "/Loai/Search", // Url of backend (can be python, php, etc..)*/
            type: "GET", // data type (can be get, post, put, delete)
            data: {
                pageIndex: pIndex,
                pageSize: pSize,
                name: searchTxt,
            }, // data in json format
            success: function (response) { // request returns successed
                $('#loai-list').html(response);
            },
            error: function (response) { // // request returns failed
                console.log("error");
            }
        });
    }
    else {
        alert("Error");
    }
}

