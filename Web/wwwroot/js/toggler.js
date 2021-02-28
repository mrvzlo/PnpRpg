var TogglerJs = (function () {
    function disableAll() {
        var buttons = $('button, input');
        buttons.attr('disabled', true);
        buttons.addClass('temp-disable');
        console.log(0);
    }

    function enableAll() {
        var disabled = $('.temp-disable');
        disabled.attr('disabled', false);
        disabled.removeClass('temp-disable');
        console.log(1);
    }

    return {
        disableAll: disableAll,
        enableAll: enableAll
    };
})();