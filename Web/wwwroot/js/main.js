var MainJs = (function () {

    var settings = {};

    function init(trumbowygIcons) {
        $.trumbowyg.svgPath = trumbowygIcons;
        updateScripts();
        $('.html-editor').trumbowyg();
    }

    function updateScripts() {
        $('.carousel').carousel({
            interval: 0
        });
        toggleLoading();
        $('[data-toggle="tooltip"]').tooltip();
        $('[data-toggle="popover"]').popover();
        initMvcGrids();
        updateColorPicker();
    }

    function toggleLoading() {
        $('#loading').toggle();
    }

    function initMvcGrids() {
        document.querySelectorAll('.mvc-grid').forEach(element => new MvcGrid(element));
        $('.mvc-grid-loader').parent().html(getSpinner());
    }

    function getSpinner() {
        return $('#loading > div').clone();
    }

    function updateColorPicker() {
        var picker = $('.color-picker');
        picker.css('background-color', '#' + picker.val());
    }

    return {
        init: init,
        toggleLoading: toggleLoading,
        initMvcGrids: initMvcGrids,
        updateScripts: updateScripts,
        updateColorPicker: updateColorPicker
    };
})();