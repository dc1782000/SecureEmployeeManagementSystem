async function loadDashboard() {

    const token = checkAuth();

    const res = await fetch("https://localhost:5256/api/employee/dashboard", {
        headers: {
            "Authorization": "Bearer " + token
        }
    });

    if (handleAuthError(res)) return;

    const data = await res.json();

    document.getElementById("totalEmp").innerText = data.totalEmployees;
    document.getElementById("activeEmp").innerText = data.activeEmployees;
    document.getElementById("inactiveEmp").innerText = data.inactiveEmployees;
}

loadDashboard();