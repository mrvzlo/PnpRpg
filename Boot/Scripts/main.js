var MainJs = (function() {

    function init() {
        $('.ajax-btn').click(function() {
            var id = $(this).data("container");
            if (!id) id = "main";
            var url = $(this).data("url");
            call("#" + id, url);
        });
    }

    function call(id, url) {
        $(id).load(url);
    }

    return {
        init: init,
    };
})();