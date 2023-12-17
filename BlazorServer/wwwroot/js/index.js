

function showErroCategory(id, message) {
    if (document.querySelector(`#${id}`))
        document.querySelector(`#${id}`).innerHTML = `<h1>${message}</h1>`;
}

function TesteFront(id, message) {
    document.querySelector(`#${id}`).innerHTML = `<h1>${message}</h1>`;
}

/* Focu no input */
function focusById(elmentId) {

    var element = document.getElementById(elmentId);

    if (element)
        element.focus();
}


/* Clear border input */
function notifyError(id, color, message) {
    const element = document.querySelector(`#${id}`);

    element.style = `border: 1px solid ${color};margin-bottom:5px`;
    element.nextElementSibling.innerHTML = message;
}



function clearBorderAndNotification() {
    if (document.querySelector(`.validation-message`))
        document.querySelector(`.validation-message`).innerHTML = '';
}


function getCookie(name) {
    const cookieString = document.cookie;
    const cookies = cookieString.split(';');

    for (let i = 0; i < cookies.length; i++) {
        const cookie = cookies[i].trim();
        // Verifica se o cookie começa com o nome fornecido
        if (cookie.startsWith(name + '=')) {
            return cookie.substring(name.length + 1);
        }
    }
    return null;
}

function url() {
    return `${window.location.protocol}//${window.location.hostname}${window.location.port ? ":" + window.location.port : ""}`;
}


// Gera o CSRF
//function testeChamar() {

//    fetch(`${url()}/Identity/Account/Login`).then(function (response) {
//        return response.json();
//    }).then(function (response) {
//    });


//}

//testeChamar();

function Gerar() {
    const nomeArquivo = document.getElementsByName('material-aula-anexo')[0].files[0];
    const titulo = document.querySelector('#titulo-anexo-aula').value;

    const form_data = new FormData();
    form_data.append('nomeArquivo', nomeArquivo);
    form_data.append('titulo', titulo);
    form_data.append('codigoAulaLocacao', codigoAulaLocacao);

    fetch(`${url()}/`, {
        method: "POST",
        body: form_data
    }).then(function (response) {
        return response.json();
    }).then(function (response) {
        alert(response.mensagem)
        if (response.parametro) {
            ModalAulas(response.parametro)
        }

    });
}

//document.getElementById('account').addEventListener('submit', function (event) {
//    event.preventDefault(); // Evita o comportamento padrão do formulário (envio tradicional)

//    let formData = new FormData(this); // Obtém os dados do formulário

//    fetch('https://localhost:7210/Identity/Account/Login', {
//        method: 'POST',
//        body: formData
//    })
//        .then(response => {
//            // Tratar a resposta da requisição, se necessário
//            console.log('Requisição enviada com sucesso!', response);
//        })
//        .catch(error => {
//            // Tratar possíveis erros de requisição
//            console.error('Erro ao enviar requisição:', error);
//        });
//});


function login(email, password) {
    /*let formData = new FormData(this);*/ // Obtém os dados do formulário
    console.log(email, password);
    const formData = new FormData();
    formData.append('Email', email);
    formData.append('Password', password);

    fetch('https://localhost:7210/Identity/Account/Login', {
        method: 'POST',
        body: formData
    })
        .then(response => {
            // Tratar a resposta da requisição, se necessário
            console.log('Requisição enviada com sucesso!', response);
        })
        .catch(error => {
            // Tratar possíveis erros de requisição
            console.error('Erro ao enviar requisição:', error);
        });
}

function teste() {
    alert('Teste');
}
