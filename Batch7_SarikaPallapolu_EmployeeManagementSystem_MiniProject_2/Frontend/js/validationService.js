/**
 * validationService.js
 * Simplified Mini Project 2 validation
 */

const validationService = (() => {
  function validateAuthForm(formData, isSignup) {
    const errors = {};

    if (!formData.username || !formData.username.trim()) {
      errors.username = "Username is required.";
    }

    if (!formData.password || !formData.password.trim()) {
      errors.password = "Password is required.";
    } else if (formData.password.length < 6) {
      errors.password = "Password must be at least 6 characters.";
    }

    if (isSignup) {
      if (!formData.confirmPassword || !formData.confirmPassword.trim()) {
        errors.confirmPassword = "Confirm password is required.";
      } else if (formData.password !== formData.confirmPassword) {
        errors.confirmPassword = "Passwords do not match.";
      }
    }

    return errors;
  }

  function validateEmployeeForm(formData) {
    const errors = {};

    if (!formData.firstName) errors.firstName = "First name is required.";
    if (!formData.lastName) errors.lastName = "Last name is required.";

    if (!formData.email) {
      errors.email = "Email is required.";
    } else if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(formData.email)) {
      errors.email = "Enter a valid email.";
    }

    if (!formData.phone) {
      errors.phone = "Phone is required.";
    } else if (!/^\d{10}$/.test(formData.phone)) {
      errors.phone = "Phone must be 10 digits.";
    }

    if (!formData.department) errors.department = "Please select a department.";
    if (!formData.designation) errors.designation = "Designation is required.";

    if (!formData.salary) {
      errors.salary = "Salary is required.";
    } else if (isNaN(formData.salary) || Number(formData.salary) <= 0) {
      errors.salary = "Salary must be a positive number.";
    }

    if (!formData.joinDate) errors.joinDate = "Join date is required.";
    if (!formData.status) errors.status = "Please select a status.";

    return errors;
  }

  return {
    validateAuthForm,
    validateEmployeeForm
  };
})();