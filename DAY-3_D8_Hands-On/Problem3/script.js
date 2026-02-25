// Selecting elements
const taskInput = document.getElementById("taskInput");
const addBtn = document.getElementById("addBtn");
const taskList = document.getElementById("taskList");

// Create new task
function createTask(taskText) {
    const li = document.createElement("li");

    li.innerHTML = `
        <span class="task-text">${taskText}</span>
        <div>
            <button class="complete-btn">&#10004;</button>
            <button class="delete-btn">&#10006;</button>
        </div>
    `;

    taskList.appendChild(li);
}

// Add task
function addTask() {
    const text = taskInput.value.trim();
    if (text === "") return;

    createTask(text);
    taskInput.value = "";
}

// Add button click
addBtn.addEventListener("click", addTask);

// Event Delegation
taskList.addEventListener("click", function (e) {

    // Delete task
    if (e.target.classList.contains("delete-btn")) {
        e.target.closest("li").remove();
    }

    // Mark complete
    if (e.target.classList.contains("complete-btn")) {
        e.target.closest("li").classList.toggle("completed");
    }
});