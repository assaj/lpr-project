function gravar()
{
    $.ajax({
        type: "GET",
        url: "Movies/Buscar",
        dataType: "json",
        contentType: "application/json",
        success: function (ans) {

            for (var a = 0; a < 3; a++) {
                $('#put').append('<h3>')
                $('#put').append(ans[a].CPF)
                $('#put').append('</h3>')
            }
            console.log(ans)
        },
        error: function (ans) {
            console.log(ans)
            alert('Error');
        }
    });
}