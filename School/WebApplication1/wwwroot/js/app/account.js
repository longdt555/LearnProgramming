function search(event) {
    event.preventDefault();
    var searchTxt = $('#search-Account').val();

    var path = `${window.location.origin}/Account?pageIndex=1&pageSize=20&name=${searchTxt}`;

    window.location.href = path;
};