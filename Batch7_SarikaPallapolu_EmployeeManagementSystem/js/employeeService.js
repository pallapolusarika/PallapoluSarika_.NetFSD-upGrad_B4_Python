// Employee Service
const employeeService = {
  // Get all employees
  getAll: function() {
    return employees;
  },

  // Get employee by ID
  getById: function(id) {
    return employees.find(e => e.id === id);
  },

  // 🔹 Add new employee with validation
  add: function(emp) {
    const errors = [];

    // Required fields
    if (!emp.firstName || !emp.lastName || !emp.email || !emp.phone || !emp.department || !emp.designation || !emp.salary || !emp.joinDate) {
      errors.push("All fields are required.");
    }

    // Email format + uniqueness
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(emp.email)) {
      errors.push("Invalid email format.");
    }
    if (employees.some(e => e.email === emp.email)) {
      errors.push("Email already exists.");
    }

    // Phone validation (10 digits)
    if (!/^\d{10}$/.test(emp.phone)) {
      errors.push("Phone must be 10 digits.");
    }

    // Salary positive number
    if (parseFloat(emp.salary) <= 0) {
      errors.push("Salary must be a positive number.");
    }

    // Join Date valid
    if (isNaN(new Date(emp.joinDate).getTime())) {
      errors.push("Invalid join date.");
    }

    if (errors.length > 0) {
      return { success: false, errors };
    }

    emp.id = employees.length ? employees[employees.length - 1].id + 1 : 1;
    employees.push(emp);
    return { success: true };
  },

  // 🔹 Update employee by ID
  update: function(id, updatedEmp) {
    const index = employees.findIndex(e => e.id === id);
    if (index !== -1) {
      employees[index] = { id, ...updatedEmp };
      return { success: true };
    }
    return { success: false, errors: ["Employee not found."] };
  },

  // 🔹 Delete employee by ID
  delete: function(id) {
    const index = employees.findIndex(e => e.id === id);
    if (index !== -1) {
      employees.splice(index, 1);
      return { success: true };
    }
    return { success: false, errors: ["Employee not found."] };
  },

  // ✅ Combined search + filters (AND logic)
  applyFilters: function(query, dept, status) {
    return employees.filter(e => {
      const matchesQuery =
        !query ||
        (e.firstName + " " + e.lastName).toLowerCase().includes(query.toLowerCase()) ||
        (e.email || "").toLowerCase().includes(query.toLowerCase());

      const matchesDept = dept === "All" || e.department === dept;
      const matchesStatus = status === "All" || e.status === status;

      return matchesQuery && matchesDept && matchesStatus;
    });
  },

  // ✅ Sorting logic
  sortBy: function(list, option) {
    const sorted = [...list];
    switch (option) {
      case "name-asc":
        sorted.sort((a, b) => (a.firstName + " " + a.lastName).localeCompare(b.firstName + " " + b.lastName));
        break;
      case "name-desc":
        sorted.sort((a, b) => (b.firstName + " " + b.lastName).localeCompare(a.firstName + " " + a.lastName));
        break;
      case "salary-asc":
        sorted.sort((a, b) => (parseFloat(a.salary) || 0) - (parseFloat(b.salary) || 0));
        break;
      case "salary-desc":
        sorted.sort((a, b) => (parseFloat(b.salary) || 0) - (parseFloat(a.salary) || 0));
        break;
      case "date-asc":
        sorted.sort((a, b) => new Date(a.joinDate) - new Date(b.joinDate));
        break;
      case "date-desc":
        sorted.sort((a, b) => new Date(b.joinDate) - new Date(a.joinDate));
        break;
    }
    return sorted;
  }
};
