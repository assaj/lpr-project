$('#form').toggle()

$('#chatButton').click(function () {
  $('#form').toggle()
})

$('#sendMessage').click(function () {
  document.getElementById('chat').innerHTML += requisition($('#inputMessage').val())
})

function requisition (msg) {
  let html = '<div class="container"><img src="https://www.w3schools.com/w3images/avatar_g2.jpg" alt="Avatar" style="width:100%;"><p>'
  html += msg
  html += '</p><span class="time-right" style="color: black">11:00</span></div>'
  return html
}

/*
function answer (msg) {
  let html = '<div class="container darker"><img src="http://www.linktapinformatica.com.br/img/icones/incone%20atendente.jpg" alt="Avatar" style="width:100%;"><p>'
  html += 'Certo, basta seguir essa sequencia de passos....'
  html += '</p><span class="time-right" style="color: black">11:00</span></div>'
  return html
}
*/