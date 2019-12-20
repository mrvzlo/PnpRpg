var MainJs = (function() {

    function init() {
        tooltips();

        $('.ajax-btn').click(function() {
            var id = $(this).data("container");
            if (!id) id = "main";
            var url = $(this).data("url");
            call("#" + id, url);
        });
    }

    function call(id, url) {
        $.get(url, function(data) {
            $(id).html(data);
            tooltips();
        });
    }

    function tooltips() {
        $('[data-toggle="tooltip"]').tooltip();
    }

    return {
        init: init,
    };
})();