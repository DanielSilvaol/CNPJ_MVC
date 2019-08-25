function setupTabs() {
    document.querySelectorAll(".tabs__button").forEach(button => {
        button.addEventListener("click",
            () => {
                const siderBar = button.parentElement;
                const tabsContainer = siderBar.parentElement;
                const tabsNumero = button.dataset.forTab;
                const tabAtiva = tabsContainer.querySelector(`.tabs__content[data-tab="${tabsNumero}"`);

                siderBar.querySelectorAll(".tabs__button").forEach(button => {
                    button.classList.remove("tabs__button--active");
                });

                tabsContainer.querySelectorAll(".tabs__content").forEach(tab => {
                    tab.classList.remove("tabs__content--active");
                });

                button.classList.add("tabs__button--active")
                tabAtiva.classList.add("tabs__content--active");
            });
    });
}

document.addEventListener("DOMContentLoaded", () => {
    setupTabs();

    document.querySelectorAll(".tabs").forEach(tabsContainer => {
        tabsContainer.querySelector(".tabs__sidebar .tabs__button").click();
    });
});


function mascaraMutuario(o, f) {
    v_obj = o
    v_fun = f
    setTimeout('execmascara()', 1)
}

function execmascara() {
    v_obj.value = v_fun(v_obj.value)
}

function cpfCnpj(v) {

    v = v.replace(/\D/g, "")

    v = v.replace(/^(\d{2})(\d)/, "$1.$2")

    v = v.replace(/^(\d{2})\.(\d{3})(\d)/, "$1.$2.$3")

    v = v.replace(/\.(\d{3})(\d)/, ".$1/$2")

    v = v.replace(/(\d{4})(\d)/, "$1-$2")


    return v
}