document.addEventListener('DOMContentLoaded', () => {

    handleOpenModals();
    handleCloseButtons();

})


function handleOpenModals() {
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
        button.addEventListener('click', () => {
            const target = button.getAttribute('data-target')
            const closeObject = document.querySelector(target)

            if (closeObject) {
                if (closeObject.classList.contains('modal')) {
                    closeModal(closeObject);
                }
                //else if (closeObject.classList.contains('notification')){
                //    closeNotification();
                //}
            }
        })
    })
}

function closeModal(modal) {
    if (modal) {
        modal.classList.remove('flex');
    }
    //function closeNotification() {

    //}

}