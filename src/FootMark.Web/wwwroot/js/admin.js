
//dashboard sidebar menu
$(document).ready(function () {
    $('#sidebarCollapse').on('click', function () {
        $('#sidebar').toggleClass('active');
    });
});

$(document).ready(function () {
    $("#arrowIcon").click(function () {
        $('i').toggleClass("fa-angle-right fa-angle-down");
    });
});
