$(document).ready(function() {

  // 🔹 Utility: Show Bootstrap Toast
  function showToast(message, type = "info") {
    const toastId = "liveToast";
    if (!document.getElementById(toastId)) {
      $("body").append(`
        <div id="${toastId}" class="toast align-items-center text-bg-${type} border-0 position-fixed bottom-0 end-0 m-3" role="alert" aria-live="assertive" aria-atomic="true">
          <div class="d-flex">
            <div class="toast-body">${message}</div>
            <button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast"></button>
          </div>
        </div>
      `);
    } else {
      $(`#${toastId} .toast-body`).text(message);
      $(`#${toastId}`).removeClass().addClass(`toast align-items-center text-bg-${type} border-0 position-fixed bottom-0 end-0 m-3`);
    }
    const toast = new bootstrap.Toast(document.getElementById(toastId));
    toast.show();
  }

  // 🔹 Signup form submit
  $("#signup-form").on("submit", function(e) {
    e.preventDefault();

    const formData = {
      username: $("#signup-username").val(),
      password: $("#signup-password").val(),
      confirmPassword: $("#signup-confirm").val()
    };

    const errors = validationService.validateAuthForm(formData, true);

    if (Object.keys(errors).length > 0) {
      showToast(Object.values(errors).join("\n"), "danger");
      return;
    }

    const result = authService.signup(formData.username, formData.password);
    if (result.success) {
      showToast("Signup successful! Redirecting to login...", "success");
      $("#signup-view").hide();
      $("#login-view").show();
    } else {
      showToast(result.message, "danger");
    }
  });

  // 🔹 Login form submit
  $("#login-form").on("submit", function(e) {
    e.preventDefault();

    const formData = {
      username: $("#login-username").val(),
      password: $("#login-password").val()
    };

    const errors = validationService.validateAuthForm(formData, false);

    if (Object.keys(errors).length > 0) {
      showToast(Object.values(errors).join("\n"), "danger");
      return;
    }

    const result = authService.login(formData.username, formData.password);
    if (result.success) {
      showToast("Login successful! Redirecting to dashboard...", "success");
      $("#login-view").hide();
      $("#dashboard-view").show();
      $("#employees-view").show();

      // Show logged-in admin name
      $(".fw-bold.text-primary").text(formData.username);

      // Render dashboard
      uiService.renderDashboardCards(dashboardService.getSummary());
      uiService.renderDepartmentBreakdown(dashboardService.getDepartmentBreakdown());
      uiService.renderRecentEmployees(dashboardService.getRecentEmployees(5));

      // Render employee list
      uiService.renderEmployeeTable(employeeService.getAll());

      // 🔹 Combined search + filters + sorting
      function applyAllFilters() {
        const query = $("#search-bar").val();
        const dept = $("#dept-filter").val();
        const status = $("#status-filter").val();
        let results = employeeService.applyFilters(query, dept, status);

        const sortOption = $("#sort-filter").val();
        if (sortOption) {
          results = employeeService.sortBy(results, sortOption);
        }

        uiService.renderEmployeeTable(results);
        uiService.renderDashboardCards(dashboardService.getSummary());
        uiService.renderDepartmentBreakdown(dashboardService.getDepartmentBreakdown());
        uiService.renderRecentEmployees(dashboardService.getRecentEmployees(5));
      }

      $("#search-bar").on("input", applyAllFilters);
      $("#dept-filter").on("change", applyAllFilters);
      $("#status-filter").on("change", applyAllFilters);
      $("#sort-filter").on("change", applyAllFilters);

      // 🔹 Add Employee
      $("#add-employee-form").on("submit", function(e) {
        e.preventDefault();
        const newEmp = {
          firstName: $("#emp-firstName").val(),
          lastName: $("#emp-lastName").val(),
          email: $("#emp-email").val(),
          phone: $("#emp-phone").val(),
          department: $("#emp-dept").val(),
          designation: $("#emp-designation").val(),
          salary: $("#emp-salary").val(),
          joinDate: $("#emp-joinDate").val(),
          status: $("#emp-status").val()
        };
        const result = employeeService.add(newEmp);
        if (result.success) {
          showToast("Employee added successfully!", "success");
          applyAllFilters();
          $("#addEmployeeModal").modal("hide");
          this.reset();
        } else {
          showToast(result.errors.join("\n"), "danger");
        }
      });

      // 🔹 View Employee
      $(document).on("click", ".view-btn", function() {
        const id = parseInt($(this).data("id"));
        const emp = employeeService.getById(id);
        showToast(`${emp.firstName} ${emp.lastName} | ${emp.designation} | ${emp.department} | ₹${emp.salary}`, "info");
      });

      // 🔹 Edit Employee
      $(document).on("click", ".edit-btn", function() {
        const id = parseInt($(this).data("id"));
        const emp = employeeService.getById(id);

        // Pre-fill modal
        $("#emp-firstName").val(emp.firstName);
        $("#emp-lastName").val(emp.lastName);
        $("#emp-email").val(emp.email);
        $("#emp-phone").val(emp.phone);
        $("#emp-dept").val(emp.department);
        $("#emp-designation").val(emp.designation);
        $("#emp-salary").val(emp.salary);
        $("#emp-joinDate").val(emp.joinDate);
        $("#emp-status").val(emp.status);
        $("#addEmployeeModal").modal("show");

        // Override submit for update
        $("#add-employee-form").off("submit").on("submit", function(e) {
          e.preventDefault();
          const updatedEmp = {
            firstName: $("#emp-firstName").val(),
            lastName: $("#emp-lastName").val(),
            email: $("#emp-email").val(),
            phone: $("#emp-phone").val(),
            department: $("#emp-dept").val(),
            designation: $("#emp-designation").val(),
            salary: $("#emp-salary").val(),
            joinDate: $("#emp-joinDate").val(),
            status: $("#emp-status").val()
          };
          const result = employeeService.update(id, updatedEmp);
          if (result.success) {
            showToast("Employee updated successfully!", "success");
            applyAllFilters();
            $("#addEmployeeModal").modal("hide");
            this.reset();
          } else {
            showToast(result.errors.join("\n"), "danger");
          }
        });
      });

      // 🔹 Delete Employee
      $(document).on("click", ".delete-btn", function() {
        const id = parseInt($(this).data("id"));
        if (confirm("Are you sure you want to delete this employee?")) {
          const result = employeeService.delete(id);
          if (result.success) {
            showToast("Employee deleted successfully!", "success");
            applyAllFilters();
          } else {
            showToast(result.errors.join("\n"), "danger");
          }
        }
      });

      // 🔹 Logout
      $("#logout-btn").on("click", function() {
        sessionStorage.clear();
        $("#dashboard-view").hide();
        $("#employees-view").hide();
        $("#login-view").show();
        showToast("Logged out successfully.", "info");
      });

    } else {
      showToast(result.message, "danger");
    }
  });
});
