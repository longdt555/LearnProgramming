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
}