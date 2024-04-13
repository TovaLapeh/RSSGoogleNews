$(document).ready(function () {
    $(".news-item a").click(function () {
        var item = $(this);
        var content = item.next();
        content.slideToggle();
    });
});