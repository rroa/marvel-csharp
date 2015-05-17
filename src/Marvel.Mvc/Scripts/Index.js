var reset = function () {
    $('#submit').removeClass('disabled');
    $('.progress').hide();
    $('#heroes').show();
    $('#staggered-test').hide();
    $('#name').val('');
};

var process = function () {
    $('#error').hide();
    $('#submit').addClass('disabled');
    $('.progress').show();
};

$(document).ready(function () {
    $('.modal-trigger').leanModal();
});

$("#playground").click(function () {
    reset();
    $('#modal1').openModal();
});

$("#submit").click(function () {
    var $name = $('#name').val();
    var $type = $('input[type=radio]:checked', '#search-heroe').val();

    if ($name.length === 0) {
        $('#error').show();
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
        success: function (data) {
            $('.progress').hide();
            $('#heroes').hide();

            var list = $('<ul id="staggered-test">');
            for (var index = 0; index < data.length; index++) {
                var href = $('<a href="' + data[index].Url + '">' + data[index].Name + '</a>');
                var li = $('<li style="transform: translateX(0px); opacity: 1;">');
                li.append(href);

                list.append(li);
            }

            $('.modal-content').append($('<a id="backButton" class="btn">Back!</a>'));
            $('.modal-content').append(list);
            Materialize.showStaggeredList('#staggered-test');

            $("#backButton").click(function () {
                $('#staggered-test').remove();
                $('#backButton').remove();
                reset();
            });
        }
    });
});