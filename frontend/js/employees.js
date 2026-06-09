
let editingEmployeeId = null;
let searchTimeout = null;


document.addEventListener("DOMContentLoaded", () => {
    loadEmployees();
});

document.getElementById("search").addEventListener("input", () => {
    clearTimeout(searchTimeout);

    searchTimeout = setTimeout(() => {
        loadEmployees();
    }, 400);
});

document.getElementById("department").addEventListener("change", loadEmployees);

async function loadEmployees() {

    const token = localStorage.getItem("token");

    const search = document.getElementById("search").value.toLowerCase();
    const dept = document.getElementById("department").value;

    let url = "http://localhost:5256/api/employee";

    if (search || dept) {
        url = `http://localhost:5256/api/employee/search?keyword=${encodeURIComponent(search)}&department=${encodeURIComponent(dept)}`;
    }

    const res = await fetch(url, {
        headers: {
            "Authorization": "Bearer " + token
        }
    });

    if (!res.ok) {
        if (res.status === 401 || res.status === 403) {
            localStorage.clear();
            window.location.replace("index.html");
        }
        return;
    }

    const data = await res.json();

    let rows = "";

    data.forEach(e => {
        rows += `
        <tr>
            <td>${e.employeeCode}</td>
            <td>${(e.firstName ?? "") + " " + (e.lastName ?? "")}</td>
            <td>${e.email}</td>
            <td>${e.department}</td>
            <td>${e.designation}</td>
            <td>
                ${e.isActive
                    ? `<span class="badge bg-success">Active</span>`
                    : `<span class="badge bg-danger">Inactive</span>`
                }
            </td>

            <td>
                <button class="btn btn-sm btn-primary" onclick="editEmployee('${e.employeeId}')">
                    <i class="bi bi-pencil-square"></i>
                </button>

                <button class="btn btn-sm btn-danger" onclick="deleteEmployee('${e.employeeId}')">
                    <i class="bi bi-trash"></i>
                </button>
            </td>
        </tr>`;
    });

    document.getElementById("empTable").innerHTML = rows;
}


async function saveEmployee() {

    if (editingEmployeeId) {
        await updateEmployee(editingEmployeeId);
    } else {
        await addEmployee();
    }
}

async function addEmployee() {

    const token = localStorage.getItem("token");

    const employee = getFormData();

    if (!validate(employee)) return;

    const res = await fetch("http://localhost:5256/api/employee", {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            "Authorization": "Bearer " + token
        },
        body: JSON.stringify(employee)
    });

    if (!res.ok) {
        alert("Failed to add employee");
        return;
    }

    alert("Employee added successfully");

    closeModal();
}


async function updateEmployee(id) {

    const token = localStorage.getItem("token");

    const employee = getFormData();

    if (!validate(employee)) return;

    const res = await fetch(`http://localhost:5256/api/employee/${id}`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
            "Authorization": "Bearer " + token
        },
        body: JSON.stringify(employee)
    });

    if (!res.ok) {
        alert("Update failed");
        return;
    }

    alert("Employee updated successfully");

    closeModal();
}


async function deleteEmployee(id) {

    const token = localStorage.getItem("token");

    if (!confirm("Delete this employee?")) return;

    const res = await fetch(`http://localhost:5256/api/employee/${id}`, {
        method: "DELETE",
        headers: {
            "Authorization": "Bearer " + token
        }
    });

    if (res.ok) {
        alert("Deleted");
        loadEmployees();
    } else {
        alert("Delete failed");
    }
}


async function editEmployee(id) {

    const token = localStorage.getItem("token");

    const res = await fetch(`http://localhost:5256/api/employee/${id}`, {
        headers: {
            "Authorization": "Bearer " + token
        }
    });

    if (!res.ok) {
        alert("Failed to fetch employee");
        return;
    }

    const e = await res.json();

    document.getElementById("employeeCode").value = e.employeeCode;
    document.getElementById("firstName").value = e.firstName;
    document.getElementById("lastName").value = e.lastName;
    document.getElementById("email").value = e.email;
    document.getElementById("emp_department").value = e.department;
    document.getElementById("emp_designation").value = e.designation;
    document.getElementById("joiningDate").value = e.joiningDate.split("T")[0];
    document.getElementById("isActive").value = e.isActive.toString();

    editingEmployeeId = id;

    new bootstrap.Modal(document.getElementById("employeeModal")).show();
}


function getFormData() {

    return {
        employeeCode: document.getElementById("employeeCode").value.trim(),
        firstName: document.getElementById("firstName").value.trim(),
        lastName: document.getElementById("lastName").value.trim(),
        email: document.getElementById("email").value.trim(),
        department: document.getElementById("emp_department").value.trim(),
        designation: document.getElementById("emp_designation").value.trim(),
        joiningDate: document.getElementById("joiningDate").value,
        isActive: document.getElementById("isActive").value === "true"
    };
}

// ================= VALIDATION =================
function validate(emp) {

    let missing = [];

    if (!emp.employeeCode) missing.push("Employee Code");
    if (!emp.firstName) missing.push("First Name");
    if (!emp.lastName) missing.push("Last Name");
    if (!emp.email) missing.push("Email");
    if (!emp.department) missing.push("Department");
    if (!emp.designation) missing.push("Designation");
    if (!emp.joiningDate) missing.push("Joining Date");

    if (missing.length > 0) {
        alert("Missing: \n" + missing.join("\n"));
        return false;
    }

    return true;
}

// ================= CLOSE MODAL =================
function closeModal() {

    bootstrap.Modal.getInstance(document.getElementById("employeeModal")).hide();

    clearForm();

    editingEmployeeId = null;

    loadEmployees();
}

// ================= CLEAR FORM =================
function clearForm() {

    document.querySelectorAll("input").forEach(i => i.value = "");

    document.querySelectorAll("select").forEach(s => s.selectedIndex = 0);
}