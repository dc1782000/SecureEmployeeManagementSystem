function checkAuth() {
    const token = localStorage.getItem("token");

    if (!token) {
        window.location.replace("index.html");
        return null;
    }

    return token;
}

function handleAuthError(res) {
    if (res && (res.status === 401 || res.status === 403)) {
        localStorage.clear();
        window.location.replace("index.html");
        return true;
    }
    return false;
}