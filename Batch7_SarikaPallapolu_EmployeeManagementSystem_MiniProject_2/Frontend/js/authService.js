/**
 * authService.js
 * Handles authentication using backend API for Mini Project 2.
 */

const authService = (() => {
  let _currentUser = null;

  async function _handleResponse(response) {
    const contentType = response.headers.get("content-type") || "";
    const data = contentType.includes("application/json")
      ? await response.json()
      : null;

    if (!response.ok) {
      const error = new Error(data?.message || `Request failed with status ${response.status}`);
      error.status = response.status;
      error.data = data;
      throw error;
    }

    return data;
  }

  async function signup(username, password, role = "Viewer") {
    const response = await fetch(`${API_BASE_URL}/auth/register`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify({ username, password, role })
    });

    return _handleResponse(response);
  }

  async function login(username, password) {
    const response = await fetch(`${API_BASE_URL}/auth/login`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify({ username, password })
    });

    const result = await _handleResponse(response);

    if (result.success && result.token) {
      localStorage.setItem("token", result.token);
      localStorage.setItem("username", result.username || "");
      localStorage.setItem("role", result.role || "");
      _currentUser = {
        username: result.username,
        role: result.role,
        token: result.token
      };
    }

    return result;
  }

  function logout() {
    localStorage.removeItem("token");
    localStorage.removeItem("username");
    localStorage.removeItem("role");
    _currentUser = null;
  }

  function isLoggedIn() {
    return !!localStorage.getItem("token");
  }

  function getCurrentUser() {
    if (_currentUser) return _currentUser;

    const token = localStorage.getItem("token");
    const username = localStorage.getItem("username");
    const role = localStorage.getItem("role");

    if (!token) return null;

    _currentUser = { username, role, token };
    return _currentUser;
  }

  function getToken() {
    return localStorage.getItem("token");
  }

  function getRole() {
    return localStorage.getItem("role");
  }

  function isAdmin() {
    return getRole() === "Admin";
  }

  return {
    signup,
    login,
    logout,
    isLoggedIn,
    getCurrentUser,
    getToken,
    getRole,
    isAdmin
  };
})();