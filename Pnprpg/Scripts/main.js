var MainJs = (function () {

    var settings = {};

    function init() {
        $(document).on("click", ".ajax-btn", function () {
            var id = $(this).data("container");
            if (!id) id = "main";
            var url = $(this).data("url");
            var style = $(this).data("style");
            call("#" + id, url, style);
        });
        $(document).on("click", ".clear-btn", function () {
            $(this).closest('.closeable').remove();
        });
        $(document).on("change", ".ajax-dropdown", function () {
            var id = $(this).data("container");
            if (!id) id = "main";
            var url = $(this).data("url");
            var style = $(this).data("style");
            if (url.includes('?'))
                url += "&id=" + this.value;
            else
                url += "/" + this.value;
            call("#" + id, url, style);
        });
        $(document).on('click', '.confirm-btn', function () {
            var btn = $(this);
            var form = btn.data('form');
            var field = btn.data('field');
            $("#" + field).val(btn.data('value'));
            if (confirm(btn.data('text')))
                $('#' + form).submit();
        });

        $(document).on("click", ".clone-btn", function () {
            var caller = $(this);
            var clone = $(caller.data("target"));
            var index = clone.find('.index');
            var id = new Date().getTime();
            index.attr('value', id);
            clone.children().children('.form-control').each(function (i, e) {
                var name = $(e).attr('name');
                $(e).attr('name', replaceFormQueryItemId(name, id));
            });
            htmlInsert(caller.data("style"), clone.clone().html(), caller.data("container"));
        });
        $(document).on('change', '.color-picker', updateColorPicker);

        updateScripts();
        $('.html-editor').trumbowyg();
    }

    function call(id, url, style) {
        toggleLoading();
        $.get(url, function (data) {
            dispose();
            htmlInsert(style, data.partial, id);
            if (data.status)
                $("#status").html(data.status);
            if (data.url)
                window.history.pushState("object or string", "Title", data.url);
            updateScripts();
        });
    }

    function replaceFormQueryItemId(src, id) {
        return src.split('[')[0] + '[' + id + ']' + src.split(']')[1];
    }

    function htmlInsert(style, data, id) {
        switch (style) {
            case "append":
                $(id).after(data);
                break;
            case "prepend":
                $(id).before(data);
                break;
            case "replace":
                $(id).replaceWith(data);
                break;
            default:
                $(id).html(data);
        }
    }

    function dispose() {
        $('[data-toggle="tooltip"]').tooltip("dispose");
    }

    function updateScripts() {
        $(".carousel").carousel({
            interval: 0
        });
        toggleLoading();
        $('[data-toggle="tooltip"]').tooltip();
        initMvcGrids();
        updateColorPicker();
    }

    // enabled by default
    function toggleLoading() {
        $("#loading").toggle();
    }

    function formRedirect() {
        var url = $("#redirect").data('redirect');
        if (!url) return;
        toggleLoading();
        window.location = url;
    }

    function setCookie(cname, cvalue, exdays) {
        var d = new Date();
        d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
        var expires = "expires=" + d.toUTCString();
        document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
    }

    function getCookie(cname) {
        var name = cname + "=";
        var ca = document.cookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == ' ') {
                c = c.substring(1);
            }
            if (c.indexOf(name) == 0) {
                return c.substring(name.length, c.length);
            }
        }
        return "";
    }

    function inc(value) {
        if (!settings.pos)
            settings.pos = value;
        return settings.pos++;
    }

    function initMvcGrids() {
        [].forEach.call(document.getElementsByClassName('mvc-grid'), function (element) {
            new MvcGrid(element);
        });
        $('.mvc-grid-loader').parent().html(getSpinner());
    }

    function getSpinner() {
        return $("#loading > div").clone();
    }

    function updateColorPicker() {
        var picker = $('.color-picker');
        picker.css('background-color', "#" + picker.val());
    }

    return {
        init: init,
        toggleLoading: toggleLoading,
        formRedirect: formRedirect,
        setCookie: setCookie,
        getCookie: getCookie,
        inc: inc,
        initMvcGrids: initMvcGrids
    };
})();