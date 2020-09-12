var AjaxJs = (function () {

    var settings = {};

    function init() {
        $(document).on('click', '.ajax-btn', function () { prepareCall($(this), false); });
        $(document).on('change', '.ajax-dropdown', function () { prepareCall(true); });
        $(document).on('click', '.clear-btn', function () {
            $(this).closest('.closeable').remove();
        });
        $(document).on('click', '.confirm-btn', confirmBtn);
        $(document).on('click', '.clone-btn', cloneBtn);
        $(document).on('change', '.color-picker', MainJs.updateColorPicker);
    }

    function prepareCall(caller, include) {
        var id = caller.data('container');
        if (!id) id = 'main';
        var url = caller.data('url');
        var style = caller.data('style');
        if (include) {
            if (url.includes('?'))
                url += '&id=' + caller.val();
            else
                url += '/' + caller.val();
        }
        call('#' + id, url, style);
    }

    function call(id, url, style) {
        MainJs.toggleLoading();
        $.get(url, function (data) {
            dispose();
            htmlInsert(style, data.partial, id);
            if (data.status)
                $('#status').html(data.status);
            MainJs.updateScripts();
        });
    }

    function confirmBtn() {
        var btn = $(this);
        var form = btn.data('form');
        var field = btn.data('field');
        $('#' + field).val(btn.data('value'));
        if (confirm(btn.data('text')))
            $('#' + form).submit();
    }

    function cloneBtn() {
        var caller = $(this);
        var clone = $(caller.data('target'));
        var index = clone.find('.index');
        var id = new Date().getTime();
        index.attr('value', id);
        clone.find('select, input:not(.index)').each(function (i, e) {
            var name = $(e).attr('name');
            $(e).attr('name', replaceFormQueryItemId(name, id));
        });
        htmlInsert(caller.data('style'), clone.clone().html(), caller.data('container'));
    }

    function replaceFormQueryItemId(src, id) {
        return src.split('[')[0] + '[' + id + ']' + src.split(']')[1];
    }

    function htmlInsert(style, data, id) {
        switch (style) {
            case 'append':
                $(id).after(data);
                break;
            case 'prepend':
                $(id).before(data);
                break;
            case 'replace':
                $(id).replaceWith(data);
                break;
            default:
                $(id).html(data);
        }
    }

    function dispose() {
        $('[data-toggle="tooltip"]').tooltip('dispose');
    }
    
    function formRedirect() {
        var url = $('#redirect').data('redirect');
        if (!url) return;
        MainJs.toggleLoading();
        window.location = url;
    }

    function load(url) {
        return call('#main', url);
    }

    return {
        init: init,
        formRedirect: formRedirect,
        load: load
    };
})();