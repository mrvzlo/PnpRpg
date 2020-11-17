var AjaxJs = (function () {

    var settings = {};

    function init() {
        $(document).on('click', '.clear-btn', function () {
            $(this).closest('.closeable').remove();
        });
        $(document).on('click', '.confirm-btn', confirmBtn);
        $(document).on('click', '.clone-btn', cloneBtn);
        $(document).on('click', '.add-params', addParams);
        $(document).on('change', '.color-picker', MainJs.updateColorPicker);
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

    function addParams() {
        var caller = $(this);
        var form = $(`#${caller.attr('form')}`);
        caller.children('input').each(function () {
            $(`#${this.name}`).val(this.value);
        });
        form.submit();
    }
    
    return {
        init: init
    };
})();