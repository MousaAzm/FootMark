
//dashboard sidebar menu
$(document).ready(function () {
    $('#sidebarCollapse').on('click', function () {
        $('#sidebar').toggleClass('active');
    });
});

$(document).ready(function () {
    $("#arrowIcon").click(function () {
        $('#arrowIcon i').toggleClass("fa-angle-right fa-angle-down");
    });
});

$(document).ready(function () {
    $("#arrowIcon_user").click(function () {
        $('#arrowIcon_user i').toggleClass("fa-angle-right fa-angle-down");
    });
});