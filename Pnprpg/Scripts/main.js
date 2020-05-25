var MainJs = (function () {

    function init() {
        updateScripts();
    }

    function call(id, url) {
        toggleLoading();
        $.get(url, function (data) {
            console.log(url);
            dispose();
            $(id).html(data.partial);
            if (data.status)
                $("#status").html(data.status);
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
        $(".ajax-btn").click(function () {
            var id = $(this).data("container");
            if (!id) id = "main";
            var url = $(this).data("url");
            call("#" + id, url);
        });
        $(".ajax-dropdown").change(function () {
            var id = $(this).data("container");
            if (!id) id = "main";
            var url = $(this).data("url") + "/" + this.value;
            call("#" + id, url);
        });
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

    return {
        init: init,
        toggleLoading: toggleLoading,
        formRedirect: formRedirect
    };
})();