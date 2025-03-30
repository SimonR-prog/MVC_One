document.addEventListener('DOMContentLoaded', () => {

    handleOpenModals();
    handleCloseButtons();
    runForms();
})

function runForms() {
    const forms = document.querySelectorAll('form')
    forms.forEach(form => {
        form.addEventListener('submit', async (e) => {
            e.preventDefault()

            clearFormErrorMessages(form)

            const formData = new FormData(form)
            try {
                const res = await fetch(form.action, {
                    method: 'post',
                    body: formData
                })
                if (res.ok) {
                    const modal = form.closest('.modal')
                    if (modal)
                        closeModal(modal);

                    window.location.reload();
                }
                else {
                    const data = await res.json()
                    if (data.errors) {
                        addFormErrorMessages(data.errors, form)
                    }
                }
            }
            catch {
                console.log("Something went wrong with the form.")
            }
        })
    })
}

function addFormErrorMessages(errors, form) {
    Object.keys(errors).forEach(key => {

        const input = form.querySelector(`[name="${key}"]`)
        if (input) {
            input.classList.add('input-validation-error')
        }

        const span = form.querySelector(`[data-valmsg-for="${key}"]`)
        if (span) {
            span.innerText = errors[key].join('\n')
            span.classList.add('field-validation-error')
        }
    })
}

function clearFormErrorMessages(form) {
    form.querySelectorAll('[data-val="true"]').forEach(input => {
        input.classList.remove('input-validation-error')
    })

    form.querySelectorAll('[data-valmsg="true"]').forEach(span => {
        span.innerText = ''
        span.classList.remove('field-validation-error')
    })
}

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

    modal.querySelectorAll('form').forEach(form => {
        form.reset();
    })
}
