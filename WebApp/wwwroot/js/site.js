document.addEventListener("DOMContentLoaded", () => {
    let btnMobile = document.querySelector('.btn-mobile')
    let nav = document.querySelector('nav')

    btnMobile.addEventListener('click', () => {
        btnMobile.classList.toggle('active')
        btnMobile.classList.toggle('fixed')

        nav.classList.toggle('active')
    })

    window.addEventListener('resize', () => {
        btnMobile.classList.remove('active')
        btnMobile.classList.remove('fixed')

        nav.classList.remove('active')
    })
})