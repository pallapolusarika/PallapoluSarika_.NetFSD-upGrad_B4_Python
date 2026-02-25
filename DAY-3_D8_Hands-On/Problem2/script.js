
const toggleBtn = document.getElementById("toggleBtn");
const body = document.body;


function applyTheme(theme) {
    body.className = theme;
    localStorage.setItem("theme", theme);
}


function toggleTheme() {
    const currentTheme = body.classList.contains("dark") ? "dark" : "light";
    const newTheme = currentTheme === "dark" ? "light" : "dark";
    applyTheme(newTheme);
}


function loadTheme() {
    const savedTheme = localStorage.getItem("theme") || "light";
    applyTheme(savedTheme);
}

toggleBtn.addEventListener("click", toggleTheme);


loadTheme();