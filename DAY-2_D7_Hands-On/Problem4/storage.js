
let tasks = [];



// Add Task (Callback)
export const addTaskCallback = (task, callback) => {
    setTimeout(() => {
        tasks.push(task);
        callback(`Task "${task}" added successfully.`);
    }, 1000);
};

// Delete Task (Callback)
export const deleteTaskCallback = (task, callback) => {
    setTimeout(() => {
        tasks = tasks.filter(t => t !== task);
        callback(`Task "${task}" deleted successfully.`);
    }, 1000);
};

// List Tasks (Callback)
export const listTasksCallback = (callback) => {
    setTimeout(() => {
        callback(tasks);
    }, 1000);
};




export const addTaskPromise = (task) => {
    return new Promise((resolve) => {
        setTimeout(() => {
            tasks.push(task);
            resolve(`Task "${task}" added successfully.`);
        }, 1000);
    });
};

export const deleteTaskPromise = (task) => {
    return new Promise((resolve) => {
        setTimeout(() => {
            tasks = tasks.filter(t => t !== task);
            resolve(`Task "${task}" deleted successfully.`);
        }, 1000);
    });
};

export const listTasksPromise = () => {
    return new Promise((resolve) => {
        setTimeout(() => {
            resolve(tasks);
        }, 1000);
    });
};




export const addTask = async (task) => {
    return await addTaskPromise(task);
};

export const deleteTask = async (task) => {
    return await deleteTaskPromise(task);
};

export const listTasks = async () => {
    return await listTasksPromise();
};