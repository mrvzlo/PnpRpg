var TogglerJs = (function () {
    function disableAll() {
        var buttons = $('button, input');
        buttons.attr('disabled', true);
        buttons.addClass('temp-disable');
    }

    function enableAll() {
        var disabled = $('.temp-disable');
        disabled.attr('disabled', false);
        disabled.removeClass('temp-disable');
    }

    return {
        disableAll: disableAll,
        enableAll: enableAll
    };
})();