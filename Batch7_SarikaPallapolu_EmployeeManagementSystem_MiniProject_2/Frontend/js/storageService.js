
const storageService = (() => {
  function _headers(withAuth = true) {
    const headers = {
      "Content-Type": "application/json"
    };

    if (withAuth) {
      const token = localStorage.getItem("token");
      if (token) {
        headers["Authorization"] = `Bearer ${token}`;
      }
    }

    return headers;
  }

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

  /**
   * Returns paginated employees from API.
   * params example:
   * { search, department, status, sortBy, sortDir, page, pageSize }
   */
  async function getAll(params = {}) {
    const query = new URLSearchParams();

    Object.entries(params).forEach(([key, value]) => {
      if (value !== undefined && value !== null && value !== "") {
        query.append(key, value);
      }
    });

    const url = `${API_BASE_URL}/employees${query.toString() ? `?${query.toString()}` : ""}`;

    const response = await fetch(url, {
      method: "GET",
      headers: _headers(true)
    });

    return _handleResponse(response);
  }

  /**
   * Returns one employee by ID.
   */
  async function getById(id) {
    const response = await fetch(`${API_BASE_URL}/employees/${id}`, {
      method: "GET",
      headers: _headers(true)
    });

    return _handleResponse(response);
  }

  /**
   * Adds employee through API.
   */
  async function add(employee) {
    const response = await fetch(`${API_BASE_URL}/employees`, {
      method: "POST",
      headers: _headers(true),
      body: JSON.stringify(employee)
    });

    return _handleResponse(response);
  }

  /**
   * Updates employee through API.
   */
  async function update(id, data) {
    const response = await fetch(`${API_BASE_URL}/employees/${id}`, {
      method: "PUT",
      headers: _headers(true),
      body: JSON.stringify(data)
    });

    return _handleResponse(response);
  }

  /**
   * Deletes employee through API.
   */
  async function remove(id) {
    const response = await fetch(`${API_BASE_URL}/employees/${id}`, {
      method: "DELETE",
      headers: _headers(true)
    });

    return _handleResponse(response);
  }

  /**
   * Not used in Mini Project 2 because backend creates IDs.
   * Kept only so old code does not crash.
   */
  function nextId() {
    return null;
  }

  return {
    getAll,
    getById,
    add,
    update,
    remove,
    nextId
  };
})();