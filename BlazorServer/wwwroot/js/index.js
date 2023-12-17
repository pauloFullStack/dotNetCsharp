

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