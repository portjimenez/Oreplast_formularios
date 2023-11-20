$(document).ready(function () {

    // jQuery para abrir el menú al hacer clic en el botón
    $('.menu-btn').click(function () {
        $('.side-bar').addClass('active');
        $('.menu-btn').css("visibility", "hidden");
        $('.content').toggleClass("content-active");
    });

    // Botón para cerrar el menú
    $('.close-btn').click(function () {
        $('.side-bar').removeClass('active');
        $('.menu-btn').css("visibility", "visible");
        $('.content').removeClass("content-active");
    });

    // jQuery para desplegar los submenús
    $('.sub-btn').click(function () {
        $(this).next('.sub-menu').slideToggle();
        $(this).find('.dropdown').toggleClass('rotate');
    });

    $('.sub-item').click(function (){
        $(this).next('.sub-menu-item').slideToggle();
        $(this).find('.dropdown').toggleClass('rotate');
    });
});