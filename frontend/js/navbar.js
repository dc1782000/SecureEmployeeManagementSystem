async function loadNavbar() {

    const res = await fetch("components/navbar.html");
    const html = await res.text();

    document.getElementById("navbar-container").innerHTML = html;

    setTimeout(() => {
        initNavbar();
    }, 0);
}

function initNavbar() {

    const username = localStorage.getItem("username");
    const role = localStorage.getItem("role");

    const userInfo = document.getElementById("userInfo");
    const adminActions = document.getElementById("adminActions");

    userInfo.innerHTML = `
        <span class="badge bg-light text-dark px-3 py-2 rounded-pill">
            👤 ${username || "User"}
        </span>
    `;

    if (role === "Admin") {
        adminActions.innerHTML = `
            <a href="employees.html" class="btn btn-warning btn-sm rounded-pill">
                ⚙ Manage
            </a>
        `;
    } else {
        adminActions.innerHTML = "";
    }
}


document.addEventListener("click", function (e) {

    const btn = e.target.closest("#logoutBtn");

    if (btn) {
        localStorage.clear();
        window.location.replace("index.html");
    }
});