

$(document).mouseup(function (e) {
    var containerprofile = $("#profileInfo");
    var containerCart = $("#dropdownCart");

    if (!containerprofile.is(e.target) && containerprofile.has(e.target).length === 0) {
        containerprofile.collapse('hide');
    }

    if (!containerCart.is(e.target) && containerCart.has(e.target).length === 0) {
        containerCart.collapse('hide');
    }
});





