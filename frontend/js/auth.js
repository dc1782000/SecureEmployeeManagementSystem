function togglePassword() {
    const password = document.getElementById("password");
    const icon = document.getElementById("eyeIcon");

    if (password.type === "password") {
        password.type = "text";
        icon.classList.remove("bi-eye-slash");
        icon.classList.add("bi-eye");
    } else {
        password.type = "password";
        icon.classList.remove("bi-eye");
        icon.classList.add("bi-eye-slash");
    }
}

async function login() {

    const username = document.getElementById("username").value.trim();
    const password = document.getElementById("password").value.trim();

    const userError = document.getElementById("userError");
    const passError = document.getElementById("passError");
    const errorBox = document.getElementById("error");
    const btn = document.getElementById("loginBtn");

    userError.innerText = "";
    passError.innerText = "";
    errorBox.innerText = "";

    let isValid = true;

    // VALIDATION
    if (!username) {
        userError.innerText = "Username is required";
        isValid = false;
    }

    if (!password) {
        passError.innerText = "Password is required";
        isValid = false;
    }

    if (!isValid) return;

    try {
        // 🔥 LOADING STATE
        btn.disabled = true;
        btn.innerText = "Logging in... ⏳";

        const res = await fetch("http://localhost:5256/api/auth/login", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({ username, password })
        });

        if (!res.ok) {
            errorBox.innerText = "Invalid credentials";
            return;
        }

        const data = await res.json();

        localStorage.setItem("token", data.token);
        localStorage.setItem("username", data.username);
        localStorage.setItem("role", data.role);
        
        // REMEMBER ME
        const rememberEl = document.getElementById("rememberMe");
if (rememberEl && rememberEl.checked) {
    localStorage.setItem("remember_user", username);
}

        

        window.location.href = "dashboard.html";

    } catch (error) {
        console.log(error);
        errorBox.innerText = "Server not reachable";

    } finally {
        // RESET BUTTON
        btn.disabled = false;
        btn.innerText = "Login";
    }
}