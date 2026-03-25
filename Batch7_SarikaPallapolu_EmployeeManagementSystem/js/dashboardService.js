// dashboardService.js
const dashboardService = {
  getSummary: function() {
    const total = employees.length;
    const active = employees.filter(e => e.status === "Active").length;
    const inactive = employees.filter(e => e.status === "Inactive").length;
    const departments = [...new Set(employees.map(e => e.department))].length;

    return { total, active, inactive, departments };
  },

  getDepartmentBreakdown: function() {
    const deptCounts = {};
    employees.forEach(e => {
      deptCounts[e.department] = (deptCounts[e.department] || 0) + 1;
    });

    const total = employees.length;
    return Object.entries(deptCounts).map(([dept, count]) => ({
      department: dept,
      count,
      percentage: Math.round((count / total) * 100)
    }));
  },

  getRecentEmployees: function(n = 5) {
    return employees.slice(-n);
  }
};
