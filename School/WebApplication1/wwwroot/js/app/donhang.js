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