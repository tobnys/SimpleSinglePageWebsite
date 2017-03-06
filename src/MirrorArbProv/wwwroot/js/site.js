// Smooth scrolling
$(function (){
    $('a[href*="#"]:not([href="#"])').click(function () {
        if (location.pathname.replace(/^\//, '') === this.pathname.replace(/^\//, '') && location.hostname === this.hostname) {
            var target = $(this.hash);
            target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
            if (target.length) {
                $('html, body').animate({
                    scrollTop: target.offset().top //- 55
                }, 1000);
                return false;
            }
        }
    });
});

// Close navbar on select for smartphones
$('.nav a').on('click', function () {
    $('.navbar-toggle').click();
});

// Navigation fade + up arrow
$(document).scroll(function () {
    if ($(this).scrollTop() > 10) {
        $('#mainNav').addClass('shrinked');
        $('.glyphicon-arrow-up').removeClass('invisible');
    } else {
        $('#mainNav').removeClass('shrinked');
        $('.glyphicon-arrow-up').addClass('invisible');
    }
});