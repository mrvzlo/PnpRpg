var MainJs = (function () {

    var settings = {};

    function init() {
        $(document).on("click", ".ajax-btn",function () {
            var id = $(this).data("container");
            if (!id) id = "main";
            var url = $(this).data("url");
            var style = $(this).data("style");
            var add = $(this).data("add");
            if (add != null) url += inc(add);
            call("#" + id, url, style);
        });
        $(document).on("click", ".clear-btn", function () {
            console.log($(this).data("container"));
            var id = $(this).data("container");
            $("#"+id).remove();
        });
        $(document).on("change", ".ajax-dropdown",function () {
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
        updateScripts();
    }

    function call(id, url, style) {
        toggleLoading();
        $.get(url, function (data) {
            dispose();
            switch (style) {
                case "append":
                    $(id).after(data.partial);
                    break;
                case "prepend":
                    $(id).before(data.partial);
                    break;
                case "replace":
                    $(id).replaceWith(data.partial);
                    break;
                default:
                    $(id).html(data.partial);
            } 

            if (data.status)
                $("#status").html(data.status);
            if (data.url)
                window.history.pushState("object or string", "Title", data.url);
            updateScripts();
        });
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