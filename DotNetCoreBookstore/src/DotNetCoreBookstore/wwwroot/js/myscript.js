function counter() {
    var count = 0;
    return function () {
        return ++count;
    };
}