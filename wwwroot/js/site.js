// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function toggleTheme() {
    var theme = localStorage.getItem('theme') || 'light';
    if (theme === 'light') {
        document.body.classList.remove('bg-light');
        document.body.style.backgroundColor = "#1C1C1C";
        document.body.style.color = "white";

        document.getElementById("textAnswer").style.color = "#00fa9a";

        // Применяем стили ко всем текстовым элементам
        var elements = document.querySelectorAll('*');
        elements.forEach(function (element) {
            if (element.tagName.toLowerCase() !== 'body' && element.tagName.toLowerCase() !== 'textanswer') { // Исключаем body, так как уже изменяется выше
                element.style.color = "white";
                element.classList.add('text-white');
                element.classList.remove('text-black');
            }
        });

        localStorage.setItem('theme', 'dark');
    } else {
        document.body.classList.add('bg-light');
        document.body.style.backgroundColor = "white";
        document.body.style.color = "black";

        document.getElementById("textAnswer").style.color = "#00fa9a";

        // Применяем стили ко всем текстовым элементам
        var elements = document.querySelectorAll('*');
        elements.forEach(function (element) {
            if (element.tagName.toLowerCase() !== 'body' && element.tagName.toLowerCase() !== 'textanswer') { // Исключаем body, так как уже изменяется выше
                element.style.color = "black ";
                element.classList.remove('text-white');
                element.classList.add('text-black');
            }
        });

        localStorage.setItem('theme', 'light');
    }
}
