// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$('option').mousedown(function (e) {
    e.preventDefault();
    $(this).prop('selected', !$(this).prop('selected'));
    return false;
});