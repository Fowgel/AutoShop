var url = @Url.Action("GetAllParentCategories");

$(document).ready(function () {
    $('#parentCategories').click(function () {
        $.ajax({
            url: url,
            type: 'POST', /*---> = Post för att få en postback till kontrollern*/
            datatype: 'JSON',
            success: function (result) {
                $.each(result, function (index, value) {
                    $('#parent').append('<li value="'
                        /*value från functionen each, och andra  value är från selectlisten*/
                        + value.value + '">'
                        /*value från functionen each, text från selectlisten*/
                        + value.text + '</li>');
                });
            }
        });
    });
});