document.addEventListener('DOMContentLoaded', () => {

    handleOpenModals();
    handleCloseButtons();
    initDropdowns();
    initModals();
    initCustomSelects();
})

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



function initDropdowns() {
    document.addEventListener('click', (e) => {
        let clickedInsideDropdown = false

        document.querySelectorAll('[data-type="dropdown"]').forEach(dropdownTrigger => {
            const targetId = dropdownTrigger.getAttribute('data-target')
            const dropdown = document.querySelector(targetId)

            if (dropdownTrigger.contains(e.target)) {
                clickedInsideDropdown = true
                document.querySelectorAll('.dropdown.dropdown-show').forEach(open => {
                    if (open !== dropdown) open.classList.remove('dropdown-show')
                })
                dropdown?.classList.toggle('dropdown-show')
            }
        })

        if (!clickedInsideDropdown && !e.target.closest('.dropdown')) {
            document.querySelectorAll('.dropdown.dropdown-show').forEach(open => {
                open.classList.remove('dropdown-show')
            })
        }
    })
}

function initModals() {
    document.querySelectorAll('[data-type="modal"]').forEach(trigger => {
        const target = document.querySelector(trigger.getAttribute('data-target'))
        trigger.addEventListener('click', () => {
            target?.classList.add('modal-show')
        })
    })

    document.querySelectorAll('[data-type="close"]').forEach(btn => {
        const target = document.querySelector(btn.getAttribute('data-target'))
        btn.addEventListener('click', () => {
            target?.classList.remove('modal-show')
        })
    })
}

function initCustomSelects() {
    document.querySelectorAll('.form-select').forEach(select => {
        const trigger = select.querySelector('.form-select-trigger')
        const triggerText = trigger.querySelector('.form-select-text')
        const options = select.querySelectorAll('.form-select-option')
        const hiddenInput = select.querySelector('input[type="hidden"]')
        const placeholder = select.dataset.placeholder || "Välj"

        const setValue = (value = "", text = placeholder) => {
            triggerText.textContent = text
            hiddenInput.value = value
            select.classList.toggle('has-placeholder', !value)
        }

        setValue()

        trigger.addEventListener('click', e => {
            e.stopPropagation()
            document.querySelectorAll('.form-select.open').forEach(el => {
                if (el !== select) el.classList.remove('open')
            })
            select.classList.toggle('open')
        })

        options.forEach(option => {
            option.addEventListener('click', () => {
                setValue(option.dataset.value, option.textContent)
                select.classList.remove('open')
            })
        })

        document.addEventListener('click', e => {
            if (!select.contains(e.target)) select.classList.remove('open')
        })
    })
}