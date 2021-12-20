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


importAction = (event, idDom, url) => {
    event.preventDefault();
    debugger;
    var input = document.getElementById(idDom);
    var file = input.files[0];

    var formData = new FormData();
    formData.append("file", file);

    $.ajax({
        url: url,
        data: formData,
        contentType: false,
        processData: false,
        type: "post",
        success: function (response) {
            if (response.status) {
            } else {
            }
        }
    });
};