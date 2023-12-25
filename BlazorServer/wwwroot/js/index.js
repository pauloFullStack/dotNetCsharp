

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

function mountSelectedPermissions(idPermission, lislistRoles) {

    const divPermissionsSelected = document.querySelector('#listRoles');
    let newPermissionSelected;

    lislistRoles.forEach((role) => {

        if (role.id == idPermission) {
            newPermissionSelected = document.createElement('span');
            newPermissionSelected.setAttribute('value', role.id);
            newPermissionSelected.setAttribute('id', `divListPermissionsSelected-${role.id}`);
            newPermissionSelected.innerHTML = `${role.name}&nbsp;&nbsp;<svg style="cursor:pointer" onclick="setOptions('${role.id}', '${role.name}')" xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-x-lg" viewBox="0 0 16 16">
  <path d="M2.146 2.854a.5.5 0 1 1 .708-.708L8 7.293l5.146-5.147a.5.5 0 0 1 .708.708L8.707 8l5.147 5.146a.5.5 0 0 1-.708.708L8 8.707l-5.146 5.147a.5.5 0 0 1-.708-.708L7.293 8z"/>
</svg>`;

            newPermissionSelected.style = 'background-color: gray;padding:5px 10px;border-radius:10px;color:#fff;margin-right:10px';

            divPermissionsSelected.appendChild(newPermissionSelected);
        }

    });

    if (divPermissionsSelected.childElementCount >= 1)
        document.querySelector('#btnSavePermissions').style.display = 'block';

    //let selectePermissions = document.querySelector('#selectePermissions');
    //const optionPermissions = document.querySelector(`#optionPermissiion-${idPermission}`);
    //const optionPermissionsDefault = document.querySelector(`#optionDefault`);
    optionPermissionsDefault = document.querySelector(`#optionDefault`).selected = true;
    //if (selectePermissions && (selectePermissions.length - 2) === 0) {
    //    optionPermissionsDefault.textContent = "Nenhuma permissão encontrada";
    //} else {
    //    optionPermissionsDefault.textContent = optionPermissions.textContent;
    //    if (optionPermissions && selectePermissions)
    //        selectePermissions.removeChild(optionPermissions);
    //}

}

function setOptions(idPermission, namePermission) {

    const divPermissionsSelected = document.querySelector('#listRoles');

    if (divPermissionsSelected && divPermissionsSelected.childElementCount == 1)
        document.querySelector('#btnSavePermissions').style.display = 'none';

    //let selectePermissions = document.querySelector('#selectePermissions');

    //if (selectePermissions) {

    //    let newOption = document.createElement('option');

    //    newOption.value = idPermission;
    //    newOption.text = namePermission;
    //    newOption.id = `optionPermissiion-${idPermission}`;

    //    selectePermissions.appendChild(newOption);

    //    document.querySelector(`#divListPermissionsSelected-${idPermission}`).remove();
    //}
    document.querySelector(`#divListPermissionsSelected-${idPermission}`).remove();
}


function createStructDataPermissions(clearForm) {
    // Seleciona o formulário pelo ID
    let form = document.querySelector('#listRoles');

    const valoresDosSpans = [];

    if (form) {
        // Seleciona todos os spans dentro do formulário
        const spans = form.querySelectorAll('span');

        // Itera sobre os spans para obter os valores do atributo 'value'
        spans.forEach(span => {
            const valor = span.getAttribute('value');
            if (valor) {
                valoresDosSpans.push(valor);
            }
        });
    }

    if (clearForm) {
        form.innerHTML = '';
        document.querySelector(`#optionDefault`).selected = true;
        document.querySelector('#btnSavePermissions').style.display = 'none';
    }

    return valoresDosSpans;


}


function redirectRoute(route) {
    window.location.href = route;
} 
