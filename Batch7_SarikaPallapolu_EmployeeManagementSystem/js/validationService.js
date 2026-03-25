// validationService.js
const validationService = {
  validateAuthForm: function(formData, isSignup = false) {
    let errors = {};

    if (!formData.username) {
      errors.username = "Username is required";
    }
    if (!formData.password) {
      errors.password = "Password is required";
    }
    if (isSignup) {
      if (formData.password.length < 6) {
        errors.password = "Password must be at least 6 characters";
      }
      if (formData.password !== formData.confirmPassword) {
        errors.confirmPassword = "Passwords do not match";
      }
    }
    return errors;
  }
};


