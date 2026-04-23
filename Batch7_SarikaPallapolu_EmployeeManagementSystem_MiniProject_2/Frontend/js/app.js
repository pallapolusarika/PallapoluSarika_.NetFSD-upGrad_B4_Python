/**
 * app.js
 * Mini Project 2 version
 * Uses backend API through authService and storageService
 */

$(function () {
  let _deleteTargetId = null;
  let _currentSearch = "";
  let _currentDept = "";
  let _currentStatus = "";
  let _currentSort = "";
  let _allEmployees = [];

  async function _loadEmployees() {
    try {
      const params = {};

      if (_currentSearch) params.search = _currentSearch;
      if (_currentDept) params.department = _currentDept;
      if (_currentStatus) params.status = _currentStatus;

      if (_currentSort) {
        const lastDash = _currentSort.lastIndexOf("-");
        if (lastDash > 0) {
          const field = _currentSort.substring(0, lastDash);
          const dir = _currentSort.substring(lastDash + 1);
          params.sortBy = field;
          params.sortDir = dir;
        }
      }

      const result = await storageService.getAll(params);
      _allEmployees = result.data || [];
      uiService.renderEmployeeTable(_allEmployees);
      uiService.updateRecordCount(_allEmployees.length);
    } catch (err) {
      console.error("Error loading employees:", err);
      _allEmployees = [];
      uiService.renderEmployeeTable([]);
      uiService.updateRecordCount(0);
    }
  }

  async function _refreshDashboard() {
    try {
      const result = await storageService.getAll({});
      const employees = result.data || [];

      const summary = {
        total: employees.length,
        active: employees.filter(e => e.status === "Active").length,
        inactive: employees.filter(e => e.status === "Inactive").length,
        departments: new Set(employees.map(e => e.department)).size
      };

      const deptMap = {};
      employees.forEach(e => {
        deptMap[e.department] = (deptMap[e.department] || 0) + 1;
      });

      const breakdown = Object.keys(deptMap).map(dept => ({
        department: dept,
        count: deptMap[dept]
      }));

      const recentEmployees = [...employees]
        .sort((a, b) => b.id - a.id)
        .slice(0, 5);

      uiService.renderDashboardCards(summary);
      uiService.renderDepartmentBreakdown(breakdown);
      uiService.renderRecentEmployees(recentEmployees);
    } catch (err) {
      console.error("Error refreshing dashboard:", err);
      uiService.renderDashboardCards({
        total: 0,
        active: 0,
        inactive: 0,
        departments: 0
      });
      uiService.renderDepartmentBreakdown([]);
      uiService.renderRecentEmployees([]);
    }
  }

  async function _showSection(section) {
    if (section === "dashboard") {
      $("#dashboardSection").removeClass("d-none");
      $("#employeeSection").addClass("d-none");
      $("#navDashboard").addClass("active");
      $("#navEmployees").removeClass("active");
      await _refreshDashboard();
    } else {
      $("#employeeSection").removeClass("d-none");
      $("#dashboardSection").addClass("d-none");
      $("#navEmployees").addClass("active");
      $("#navDashboard").removeClass("active");
      await _loadEmployees();
    }
  }

  function _showAuth(view) {
    $("#appWrapper").addClass("d-none");
    $("#authWrapper").removeClass("d-none");

    if (view === "signup") {
      $("#signupView").removeClass("d-none");
      $("#loginView").addClass("d-none");
    } else {
      $("#loginView").removeClass("d-none");
      $("#signupView").addClass("d-none");
    }
  }

  async function _showApp() {
    $("#authWrapper").addClass("d-none");
    $("#appWrapper").removeClass("d-none");

    const user = authService.getCurrentUser();
    $("#navUsername").text(user?.username || "");

    await _showSection("dashboard");
  }

  async function init() {
    if (authService.isLoggedIn()) {
      await _showApp();
    } else {
      _showAuth("login");
    }
  }

  $("#goToSignup").on("click", function (e) {
    e.preventDefault();
    uiService.clearAuthErrors("login");
    $("#loginUsername, #loginPassword").val("");
    _showAuth("signup");
  });

  $("#goToLogin").on("click", function (e) {
    e.preventDefault();
    uiService.clearAuthErrors("signup");
    $("#signupUsername, #signupPassword, #signupConfirm").val("");
    _showAuth("login");
  });

  $("#signupBtn").on("click", async function () {
    const formData = {
      username: $("#signupUsername").val(),
      password: $("#signupPassword").val(),
      confirmPassword: $("#signupConfirm").val()
    };

    const errors = validationService.validateAuthForm(formData, true);
    if (Object.keys(errors).length > 0) {
      uiService.showAuthErrors(errors, "signup");
      return;
    }

    try {
      await authService.signup(formData.username, formData.password, "Admin");
      uiService.showToast("Account created successfully! Please sign in.", "success");

      setTimeout(() => {
        $("#signupUsername, #signupPassword, #signupConfirm").val("");
        uiService.clearAuthErrors("signup");
        _showAuth("login");
      }, 1000);
    } catch (err) {
      uiService.showAuthErrors({ username: err.message || "Signup failed." }, "signup");
    }
  });

  $("#loginBtn").on("click", async function () {
    const formData = {
      username: $("#loginUsername").val(),
      password: $("#loginPassword").val()
    };

    const errors = validationService.validateAuthForm(formData, false);
    if (Object.keys(errors).length > 0) {
      uiService.showAuthErrors(errors, "login");
      return;
    }

    try {
      const result = await authService.login(formData.username, formData.password);

      if (!result.success) {
        $("#loginAlert")
          .text("Invalid credentials. Please check your username and password.")
          .removeClass("d-none")
          .addClass("alert-danger");
        return;
      }

      $("#loginAlert").addClass("d-none").text("");
      await _showApp();
    } catch (err) {
      $("#loginAlert")
        .text(err.message || "Login failed.")
        .removeClass("d-none")
        .addClass("alert-danger");
    }
  });

  $("#loginPassword").on("keydown", function (e) {
    if (e.key === "Enter") {
      $("#loginBtn").trigger("click");
    }
  });

  $("#signupConfirm").on("keydown", function (e) {
    if (e.key === "Enter") {
      $("#signupBtn").trigger("click");
    }
  });

  $("#loginUsername, #loginPassword").on("input", function () {
    $(this).removeClass("is-invalid");
    $("#loginAlert").addClass("d-none");
  });

  $("#signupUsername, #signupPassword, #signupConfirm").on("input", function () {
    $(this).removeClass("is-invalid");
  });

  $("#logoutBtn").on("click", function () {
    authService.logout();
    _showAuth("login");
    uiService.showToast("You have been signed out.", "info");
  });

  $("#navDashboard").on("click", async function (e) {
    e.preventDefault();
    if (!authService.isLoggedIn()) {
      _showAuth("login");
      return;
    }
    await _showSection("dashboard");
  });

  $("#navEmployees").on("click", async function (e) {
    e.preventDefault();
    if (!authService.isLoggedIn()) {
      _showAuth("login");
      return;
    }
    await _showSection("employees");
  });

  function openAddModal() {
    if (!authService.isLoggedIn()) return;
    uiService.clearForm();
    const modal = new bootstrap.Modal(document.getElementById("empFormModal"));
    modal.show();
  }

  $("#navAddEmployee, #empAddEmployee").on("click", openAddModal);

  $("#empFormSubmit").on("click", async function () {
    const editId = $("#editEmployeeId").val() ? parseInt($("#editEmployeeId").val(), 10) : null;

    const formData = {
      firstName: $("#empFirstName").val().trim(),
      lastName: $("#empLastName").val().trim(),
      email: $("#empEmail").val().trim(),
      phone: $("#empPhone").val().trim(),
      department: $("#empDepartment").val(),
      designation: $("#empDesignation").val().trim(),
      salary: $("#empSalary").val(),
      joinDate: $("#empJoinDate").val(),
      status: $("#empStatus").val()
    };

    const errors = validationService.validateEmployeeForm(formData, editId);
    if (Object.keys(errors).length > 0) {
      uiService.showInlineErrors(errors);
      return;
    }

    const payload = {
      ...formData,
      salary: parseFloat(formData.salary)
    };

    try {
      if (editId) {
        await storageService.update(editId, payload);
        uiService.showToast("Employee updated successfully.", "success");
      } else {
        await storageService.add(payload);
        uiService.showToast("Employee added successfully.", "success");
      }

      const modalEl = document.getElementById("empFormModal");
      const modalInstance = bootstrap.Modal.getInstance(modalEl);
      if (modalInstance) {
        modalInstance.hide();
      }

      await _loadEmployees();
      await _refreshDashboard();
    } catch (err) {
      uiService.showToast(err.message || "Operation failed.", "danger");
    }
  });

  $("#empFormModal").on("input change", ".form-control, .form-select", function () {
    $(this).removeClass("is-invalid");
    $(this).next(".invalid-feedback").text("").removeClass("show");
  });

  $("#employeeTableBody").on("click", ".btn-action.view", async function () {
    const id = parseInt($(this).data("id"), 10);

    try {
      const employee = await storageService.getById(id);
      if (employee) {
        uiService.showViewModal(employee);
      }
    } catch (err) {
      uiService.showToast("Unable to load employee.", "danger");
    }
  });

  $("#employeeTableBody").on("click", ".btn-action.edit", async function () {
    const id = parseInt($(this).data("id"), 10);

    try {
      const employee = await storageService.getById(id);
      if (!employee) return;

      uiService.clearForm();
      uiService.populateForm(employee);

      const modal = new bootstrap.Modal(document.getElementById("empFormModal"));
      modal.show();
    } catch (err) {
      uiService.showToast("Unable to load employee.", "danger");
    }
  });

  $("#employeeTableBody").on("click", ".btn-action.del", async function () {
    const id = parseInt($(this).data("id"), 10);

    try {
      const employee = await storageService.getById(id);
      if (!employee) return;

      _deleteTargetId = id;
      $("#deleteEmpMessage").text(`Are you sure you want to delete ${employee.firstName} ${employee.lastName}?`);

      const modal = new bootstrap.Modal(document.getElementById("deleteEmpModal"));
      modal.show();
    } catch (err) {
      uiService.showToast("Unable to load employee.", "danger");
    }
  });

  $("#confirmDeleteBtn").on("click", async function () {
    if (_deleteTargetId === null) return;

    try {
      await storageService.remove(_deleteTargetId);
      _deleteTargetId = null;

      const modalEl = document.getElementById("deleteEmpModal");
      const modalInstance = bootstrap.Modal.getInstance(modalEl);
      if (modalInstance) {
        modalInstance.hide();
      }

      uiService.showToast("Employee deleted.", "danger");
      await _loadEmployees();
      await _refreshDashboard();
    } catch (err) {
      uiService.showToast("Delete failed.", "danger");
    }
  });

  $("#searchInput").on("input", async function () {
    _currentSearch = $(this).val();
    if (_currentSearch) {
      $("#clearSearch").removeClass("d-none");
    } else {
      $("#clearSearch").addClass("d-none");
    }
    await _loadEmployees();
  });

  $("#clearSearch").on("click", async function () {
    $("#searchInput").val("");
    _currentSearch = "";
    $(this).addClass("d-none");
    await _loadEmployees();
  });

  $("#deptFilter").on("change", async function () {
    _currentDept = $(this).val();
    await _loadEmployees();
  });

  $('input[name="statusOpt"]').on("change", async function () {
    _currentStatus = $(this).val();
    await _loadEmployees();
  });

  $("#sortSelect").on("change", async function () {
    _currentSort = $(this).val();
    await _loadEmployees();
  });

  init();
});