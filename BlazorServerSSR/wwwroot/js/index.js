function closeOffcanvas() {
    // Encontre o botão pelo atributo data-bs-dismiss
    const botao = document.querySelector('[data-bs-dismiss="offcanvas"]');

    // Verifica se o botão foi encontrado
    if (botao) {
        // Cria um evento de clique
        const eventoClique = new Event('click', {
            bubbles: true, // Permite que o evento borbulhe pela árvore DOM
            cancelable: true, // Permite que o evento seja cancelado
        });

        // Despacha o evento de clique no botão
        botao.dispatchEvent(eventoClique);
    } else {
        console.error('Botão não encontrado.');
    }

}