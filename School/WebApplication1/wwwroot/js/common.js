checkExistClass = (parentClass, childClass) => {
    return $(`${parentClass}`).hasClass(`${childClass}`);
};

removeClass = (parentClass, childClass) => {
    if ($(`${parentClass}`).hasClass(`${childClass}`))
        $(`${parentClass}`).removeClass(`${childClass}`);
};

addClass = (parentClass, childClass) => {
    if (!$(`${parentClass}`).hasClass(childClass))
        $(`${parentClass}`).addClass(childClass);
};

getAttrValue = (parentClass, attrName) => {
    return $(parentClass).attr(attrName);
};

getSelectValue = id => {
    return $(id).value;
};

exportAction = url => {
    window.open(url);
};

importAction = (event, url) => {
    event.preventDefault();
    var formData = new FormData();
    formData.append("file", $("input[type=file]")[0].files[0]);
    $.ajax({
        type: "POST",
        url: url,
        data: formData,
        contentType: false,
        processData: false,
        success: function (data) {
            alert(data.Message);
        }
    });
};