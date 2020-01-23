var MainJs = (function() {

    function init() {
        updateScripts();
    }

    function call(id, url) {
        $("#loading").show();
        $.get(url, function (data) {
            console.log(url);
            dispose();
            $(id).html(data.partial);
            window.history.pushState("object or string", "Title", data.url);
            updateScripts();
        });
    }

    function dispose() {
        $('[data-toggle="tooltip"]').tooltip('dispose');
    }

    function updateScripts() {
        $('.carousel').carousel({
            interval: 0
        })
        $("#loading").hide();
        $('[data-toggle="tooltip"]').tooltip();
        $('.ajax-btn').click(function () {
            var id = $(this).data("container");
            if (!id) id = "main";
            var url = $(this).data("url");
            call("#" + id, url);
        });
    }

    return {
        init: init
    };
})();