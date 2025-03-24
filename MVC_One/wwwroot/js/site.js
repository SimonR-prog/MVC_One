document.addEventListener('DOMContentLoaded', () => {

    handleOpenModal();
    handleCloseButtons();





})


function handleOpenModal() {
    const modalButtons = document.querySelectorAll('[data-modal="true"]')
    modalButtons.forEach(button => {
        button.addEventListener('click', () => {
            const target = button.getAttribute('data-target')
            const modal = document.querySelector(target)

            if (modal) {
                modal.classList.add('flex')
            }

        })
    })
}

function handleCloseButtons() {
    const closeButtons = document.querySelectorAll('[data-close="true"]')
    closeButtons.forEach(button => {
        buttons.addEventListener('click', () => {
            const target = button.getAttribute('data-target')
            const closeObject = document.querySelector(target)

            if (closeObject) {
                if (closeObject.classList.contains('modal')) {
                    closeModal();
                }
                else if (closeObject.classList.contains('notification')){
                    closeNotification();
                }
            }
        })
    })
}
function closeModal() {

}
function closeNotification() {

}