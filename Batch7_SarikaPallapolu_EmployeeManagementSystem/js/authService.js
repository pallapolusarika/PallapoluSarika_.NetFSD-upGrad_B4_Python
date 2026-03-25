// authService.js
let admins = [{ username: "admin", password: "admin123" }];
let session = { loggedIn: false };

const authService = {
  signup: function(username, password) {
    // check duplicate
    if (admins.find(a => a.username === username)) {
      return { success: false, message: "Username already exists" };
    }
    admins.push({ username, password });
    return { success: true, message: "Signup successful" };
  },

  login: function(username, password) {
    let admin = admins.find(a => a.username === username && a.password === password);
    if (admin) {
      session.loggedIn = true;
      return { success: true };
    }
    return { success: false, message: "Invalid credentials" };
  },

  logout: function() {
    session.loggedIn = false;
  },

  isLoggedIn: function() {
    return session.loggedIn;
  }
};
