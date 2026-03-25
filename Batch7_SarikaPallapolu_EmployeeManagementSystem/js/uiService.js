const uiService = {
  // Render dashboard summary cards
  renderDashboardCards: function(summary) {
    $("#summary-cards").html(`
      <div class="col-md-3">
        <div class="card total-card"><div class="card-body">Total Employees: ${summary.total}</div></div>
      </div>
      <div class="col-md-3">
        <div class="card active-card"><div class="card-body">Active: ${summary.active}</div></div>
      </div>
      <div class="col-md-3">
        <div class="card inactive-card"><div class="card-body">Inactive: ${summary.inactive}</div></div>
      </div>
      <div class="col-md-3">
        <div class="card departments-card"><div class="card-body">Departments: ${summary.departments}</div></div>
      </div>
    `);
  },

  // Render department breakdown
  renderDepartmentBreakdown: function(data) {
    const rows = data.map(d => `
      <tr>
        <td>${d.department}</td>
        <td>${d.count}</td>
        <td>${d.percentage}%</td>
      </tr>
    `).join("");
    $("#dept-breakdown tbody").html(rows);
  },

  // Render recent employees with badges
  renderRecentEmployees: function(list) {
    const items = list.map(e => `
      <li class="list-group-item d-flex justify-content-between align-items-center">
        <div>
          <strong>${e.firstName} ${e.lastName}</strong> - ${e.designation}
        </div>
        <div>
          <span class="badge bg-primary me-2">${e.department}</span>
          <span class="badge ${e.status === "Active" ? "bg-success" : "bg-secondary"}">${e.status}</span>
        </div>
      </li>
    `).join("");
    $("#recent-employees").html(items);
  },

  // Render employee table with all fields + aligned buttons
  renderEmployeeTable: function(list) {
    const rows = list.map(e => `
      <tr>
        <td>${e.id}</td>
        <td>${e.firstName} ${e.lastName}</td>
        <td>${e.email || "—"}</td>
        <td>${e.phone || "—"}</td>
        <td>${e.department}</td>
        <td>${e.designation}</td>
        <td>₹${e.salary || "—"}</td>
        <td>${e.joinDate || "—"}</td>
        <td>${e.status}</td>
        <td>
          <div class="d-flex flex-nowrap gap-1">
            <button class="btn btn-info btn-sm view-btn" data-id="${e.id}">View</button>
            <button class="btn btn-warning btn-sm edit-btn" data-id="${e.id}">Edit</button>
            <button class="btn btn-danger btn-sm delete-btn" data-id="${e.id}">Delete</button>
          </div>
        </td>
      </tr>
    `).join("");
    $("#employee-table tbody").html(rows);
  }
};
