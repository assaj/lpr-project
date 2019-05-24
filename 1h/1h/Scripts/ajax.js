function gravar()
{
    $.ajax({
        type: "GET",
        url: "Movies/Buscar",
        dataType: "json",
        contentType: "application/json",
        success: function (ans) {
            console.log(ans)
            //$('#put').append('<h3>')
            $('#put').append(ans.Name)
            //$('#put').append('</h3>')
        },
        error: function (ans) {
            console.log(ans)
            alert('Error');
        }
    });
}