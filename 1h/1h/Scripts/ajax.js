function gravar()
{
    $.ajax({
        type: "POST",
        url: "Movies/GravarJson",
        data: {
            nome: $('#custumerInput').val()
        },
        dataType: "json",
        success: function (ans) {
            //alert(ans.Name);
            $('#put').append('<h3>')
            $('#put').append(ans.Name)
            $('#put').append('</h3>')
        },
        error: function (ans) {
            alert('Error');
        }
    });
}