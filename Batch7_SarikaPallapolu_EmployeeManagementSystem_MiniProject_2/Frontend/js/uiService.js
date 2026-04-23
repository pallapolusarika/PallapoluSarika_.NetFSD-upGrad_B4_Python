/**
 * uiService.js
 * Owns all DOM rendering and UI feedback.
 * Receives plain data from app.js. Never calls other services directly.
 * Never contains business logic.
 *
 * @module uiService
 */

const uiService = (() => {

  /* ── Helpers ──────────────────────────────────────────────── */

  function _formatSalary(n) {
    return '₹' + Number(n).toLocaleString('en-IN');
  }

  function _formatDate(dateString) {
    if (!dateString) return '';
    const d = new Date(dateString);
    if (isNaN(d.getTime())) return dateString;

    const day = String(d.getDate()).padStart(2, '0');
    const month = String(d.getMonth() + 1).padStart(2, '0');
    const year = d.getFullYear();

    return `${day}-${month}-${year}`;
  }

  function _deptBadge(dept) {
    const cls = (dept || '').toLowerCase().replace(/\s+/g, '-');
    return `<span class="badge-dept badge-${cls}">${dept}</span>`;
  }

  function _statusBadge(status) {
    const cls = (status || '').toLowerCase();
    return `<span class="badge-${cls}">${status}</span>`;
  }

  function _avatarColor(name) {
    const colors = ['#3b82f6', '#a855f7', '#f59e0b', '#10b981', '#ef4444', '#0ea5e9', '#84cc16', '#ec4899'];
    let hash = 0;
    for (let i = 0; i < name.length; i++) {
      hash = name.charCodeAt(i) + ((hash << 5) - hash);
    }
    return colors[Math.abs(hash) % colors.length];
  }

  /* ── Employee Table ───────────────────────────────────────── */

  function renderEmployeeTable(employees) {
    const $tbody = $('#employeeTableBody');
    $tbody.empty();

    if (!employees || employees.length === 0) {
      $tbody.html(`
        <tr>
          <td colspan="9">
            <div class="empty-state">
              <i class="bi bi-search"></i>
              <p>No employees found matching your criteria.</p>
            </div>
          </td>
        </tr>
      `);
      return;
    }

    employees.forEach(e => {
      const row = `
        <tr>
          <td><strong>#${e.id}</strong></td>
          <td><strong>${e.firstName} ${e.lastName}</strong></td>
          <td><small>${e.email}</small></td>
          <td>${_deptBadge(e.department)}</td>
          <td>${e.designation}</td>
          <td class="salary-cell">${_formatSalary(e.salary)}</td>
          <td>${_formatDate(e.joinDate)}</td>
          <td>${_statusBadge(e.status)}</td>
          <td>
            <div class="d-flex gap-1">
              <button class="btn-action view" data-id="${e.id}" title="View"><i class="bi bi-eye"></i></button>
              <button class="btn-action edit" data-id="${e.id}" title="Edit"><i class="bi bi-pencil"></i></button>
              <button class="btn-action del" data-id="${e.id}" title="Delete"><i class="bi bi-trash3"></i></button>
            </div>
          </td>
        </tr>`;
      $tbody.append(row);
    });
  }

  /* ── Dashboard Cards ──────────────────────────────────────── */

  function renderDashboardCards(summary) {
    const cards = [
      { label: 'Total Employees', value: summary.total, icon: 'bi-people-fill', color: 'blue' },
      { label: 'Active Employees', value: summary.active, icon: 'bi-person-check-fill', color: 'green' },
      { label: 'Inactive Employees', value: summary.inactive, icon: 'bi-person-x-fill', color: 'red' },
      { label: 'Total Departments', value: summary.departments, icon: 'bi-diagram-3-fill', color: 'purple' }
    ];

    const $container = $('#kpiCards');
    $container.empty();

    cards.forEach(c => {
      $container.append(`
        <div class="col-6 col-xl-3">
          <div class="kpi-card">
            <div class="kpi-icon ${c.color}"><i class="bi ${c.icon}"></i></div>
            <div>
              <p class="kpi-label">${c.label}</p>
              <p class="kpi-value">${c.value}</p>
            </div>
          </div>
        </div>
      `);
    });
  }

  /* ── Department Breakdown ─────────────────────────────────── */

  function renderDepartmentBreakdown(data) {
    const $el = $('#deptBreakdown');
    $el.empty();

    if (!data || !data.length) {
      $el.html('<p class="text-muted small">No data available.</p>');
      return;
    }

    const max = Math.max(...data.map(d => d.count), 1);

    const deptColors = {
      Engineering: '#3b82f6',
      Marketing: '#a855f7',
      HR: '#f59e0b',
      Finance: '#10b981',
      Operations: '#ef4444'
    };

    data.forEach(d => {
      const pct = Math.round((d.count / max) * 100);
      const color = deptColors[d.department] || '#64748b';

      $el.append(`
        <div class="dept-row">
          <span class="dept-label">${d.department}</span>
          <div class="dept-bar-wrap">
            <div class="dept-bar" style="width:${pct}%;background:${color}"></div>
          </div>
          <span class="dept-count">${d.count}</span>
        </div>
      `);
    });
  }

  /* ── Recent Employees ─────────────────────────────────────── */

  function renderRecentEmployees(employees) {
    const $el = $('#recentEmployees');
    $el.empty();

    if (!employees || !employees.length) {
      $el.html('<p class="text-muted small">No employees yet.</p>');
      return;
    }

    employees.forEach(e => {
      const initials = (e.firstName[0] + e.lastName[0]).toUpperCase();
      const color = _avatarColor(e.firstName + e.lastName);

      $el.append(`
        <div class="recent-emp-item">
          <div class="recent-emp-avatar" style="background:${color}">${initials}</div>
          <div class="recent-emp-info">
            <p class="recent-emp-name">${e.firstName} ${e.lastName}</p>
            <p class="recent-emp-role">${e.designation}</p>
          </div>
          <div class="d-flex flex-column align-items-end gap-1">
            ${_deptBadge(e.department)}
            ${_statusBadge(e.status)}
          </div>
        </div>
      `);
    });
  }

  /* ── Modals ───────────────────────────────────────────────── */

  function showViewModal(employee) {
    const fields = [
      { label: 'Employee ID', value: `#${employee.id}` },
      { label: 'First Name', value: employee.firstName },
      { label: 'Last Name', value: employee.lastName },
      { label: 'Email', value: employee.email },
      { label: 'Phone', value: employee.phone },
      { label: 'Department', value: _deptBadge(employee.department) },
      { label: 'Designation', value: employee.designation },
      { label: 'Salary', value: `<span class="salary-cell">${_formatSalary(employee.salary)}</span>` },
      { label: 'Join Date', value: _formatDate(employee.joinDate) },
      { label: 'Status', value: _statusBadge(employee.status) }
    ];

    let html = '<div class="view-grid">';
    fields.forEach(f => {
      html += `<div class="view-item"><label>${f.label}</label><p>${f.value}</p></div>`;
    });
    html += '</div>';

    $('#viewEmpBody').html(html);
    const modal = new bootstrap.Modal(document.getElementById('viewEmpModal'));
    modal.show();
  }

  function populateForm(employee) {
    $('#editEmployeeId').val(employee.id);
    $('#empFirstName').val(employee.firstName);
    $('#empLastName').val(employee.lastName);
    $('#empEmail').val(employee.email);
    $('#empPhone').val(employee.phone);
    $('#empDepartment').val(employee.department);
    $('#empDesignation').val(employee.designation);
    $('#empSalary').val(employee.salary);
    $('#empJoinDate').val(employee.joinDate ? employee.joinDate.split('T')[0] : '');
    $('#empStatus').val(employee.status);
    $('#empFormModalLabel').html('<i class="bi bi-pencil-fill me-2"></i>Edit Employee');
    $('#empFormSubmitLabel').text('Update Employee');
  }

  function clearForm() {
    $('#editEmployeeId').val('');
    $('#empFirstName, #empLastName, #empEmail, #empPhone, #empDesignation, #empSalary, #empJoinDate').val('');
    $('#empDepartment, #empStatus').val('');
    $('#empFormModalLabel').html('<i class="bi bi-person-plus-fill me-2"></i>Add Employee');
    $('#empFormSubmitLabel').text('Add Employee');
    clearInlineErrors();
  }

  /* ── Inline Errors ────────────────────────────────────────── */

  function showInlineErrors(errors) {
    clearInlineErrors();

    const fieldMap = {
      firstName: '#empFirstName',
      lastName: '#empLastName',
      email: '#empEmail',
      phone: '#empPhone',
      department: '#empDepartment',
      designation: '#empDesignation',
      salary: '#empSalary',
      joinDate: '#empJoinDate',
      status: '#empStatus'
    };

    Object.entries(errors).forEach(([field, msg]) => {
      const $input = $(fieldMap[field]);
      if ($input.length) {
        $input.addClass('is-invalid');
        $input.next('.invalid-feedback').text(msg).addClass('show');
      }
    });
  }

  function showAuthErrors(errors, prefix) {
    clearAuthErrors(prefix);

    const fieldMap = {
      username: `#${prefix}Username`,
      password: `#${prefix}Password`,
      confirmPassword: `#${prefix}Confirm`
    };

    Object.entries(errors).forEach(([field, msg]) => {
      const $input = $(fieldMap[field]);
      if ($input.length) {
        $input.addClass('is-invalid');
        $input.closest('.input-group').next('.invalid-feedback').text(msg).addClass('show');
      }
    });
  }

  function clearInlineErrors() {
    $('#empFormModal .form-control, #empFormModal .form-select').removeClass('is-invalid');
    $('#empFormModal .invalid-feedback').text('').removeClass('show');
  }

  function clearAuthErrors(prefix) {
    $(`#${prefix}Username, #${prefix}Password, #${prefix}Confirm`).removeClass('is-invalid');
    $(`#${prefix}UsernameError, #${prefix}PasswordError, #${prefix}ConfirmError`).text('').removeClass('show');
  }

  /* ── Toast ────────────────────────────────────────────────── */

  function showToast(message, type = 'success') {
    const icons = {
      success: 'bi-check-circle-fill',
      danger: 'bi-x-circle-fill',
      warning: 'bi-exclamation-triangle-fill',
      info: 'bi-info-circle-fill'
    };

    const id = 'toast-' + Date.now();

    const html = `
      <div id="${id}" class="toast custom-toast align-items-center text-bg-${type} border-0" role="alert" aria-live="assertive" data-bs-delay="3500">
        <div class="d-flex">
          <div class="toast-body d-flex align-items-center gap-2">
            <i class="bi ${icons[type] || 'bi-info-circle-fill'}"></i>
            ${message}
          </div>
          <button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast"></button>
        </div>
      </div>`;

    $('#toastContainer').append(html);
    const toastEl = document.getElementById(id);
    new bootstrap.Toast(toastEl).show();
    toastEl.addEventListener('hidden.bs.toast', () => toastEl.remove());
  }

  /* ── Record Count Label ───────────────────────────────────── */

  function updateRecordCount(count) {
    $('#recordCount').text(
      count === 0 ? 'No employees found.' : `Showing ${count} employee${count !== 1 ? 's' : ''}`
    );
  }

  return {
    renderEmployeeTable,
    renderDashboardCards,
    renderDepartmentBreakdown,
    renderRecentEmployees,
    showViewModal,
    populateForm,
    clearForm,
    showInlineErrors,
    showAuthErrors,
    clearInlineErrors,
    clearAuthErrors,
    showToast,
    updateRecordCount
  };
})();
