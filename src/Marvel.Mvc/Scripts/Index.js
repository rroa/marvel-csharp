(function($) {
    'use strict';
    var reset = function () {
        $('#submit').removeClass('disabled');
        $('.progress').hide();
        $('#heroes').show();
        $('#staggered-test').hide();
        $('#name').val('');
    };
    var error = function(desc) {
        $('#error').text(desc);
        $('#error').show();
    };
    var process = function () {
        $('#error').hide();
        $('#submit').addClass('disabled');
        $('.progress').show();
    };
   var processResult = function (data) {
        var list = $('<ul id="staggered-test">');
        for (var index = 0; index < data.length; index++) {
            var href = $('<a href="' + data[index].Url + '">' + data[index].Name + '</a>');
            var li = $('<li style="transform: translateX(0px); opacity: 1;">');
            li.append(href);
            list.append(li);
        };
        $('.modal-content').append(list);
        Materialize.showStaggeredList('#staggered-test');
        $('#backButton').show();
    };
    var apiRequest = function() {
        var $name = $('#name').val();
        var $type = $('input[type=radio]:checked', '#search-heroe').val();

        if (!$name) {
            error("You must provide a name.");
            return;
        }

        process();

        var postdata = {
            Name: $name,
            Type: $type
        };

        $.ajax({
            type: 'POST',
            url: '/Home/SomeActionMethod',
            contentType: "application/json",
            dataType: 'json',
            data: JSON.stringify(postdata),
            success: function(data) {
                $('.progress').hide();
                if (!data || data.length === 0) {
                    error('Not Found!');
                } else {
                    $('#heroes').hide();
                    processResult(data);
                }
            }
        });
    };
    $("#playground").click(function () {
        reset();
        $('#backButton').hide();
        $('#playgroundModal').openModal();
    });
    $("#backButton").click(function () {
        $('#staggered-test').remove();
        $('#backButton').hide();
        reset();
    });
    $("#name").keydown(function(e) {
        if (e.keyCode === 13) {
            apiRequest();
        }
    });
    $("#submit").click(apiRequest);
})(jQuery);



