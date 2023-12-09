function showQuote() {
    let targetElement = document.getElementById('quoteContainer');
    let componentIncrement = document.querySelector('#increment');
    let valueString = parseInt(componentIncrement.value);
    valueString++;
    targetElement.innerHTML = `${valueString}`;
    componentIncrement.value = valueString;
}

function focusById(elmentId) {
    var element = document.getElementById(elmentId);
    if (element)
        element.focus();
}

function clearBorderAndNotification(selector) {
    if (document.querySelector(`${selector}`).nextElementSibling != null) document.querySelector(`${selector}`).nextElementSibling.innerHTML = '';
}

function closeOffcanvas() {
    const offcanvasElementList = document.querySelectorAll('.offcanvas')
    const offcanvasList = [...offcanvasElementList].map(offcanvasEl => new bootstrap.Offcanvas(offcanvasEl))
}