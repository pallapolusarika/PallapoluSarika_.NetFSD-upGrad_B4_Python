import {
    addTaskCallback,
    deleteTaskCallback,
    listTasksCallback,
    addTaskPromise,
    deleteTaskPromise,
    listTasksPromise,
    addTask,
    deleteTask,
    listTasks
} from "./storage.js";

const runBtn = document.getElementById("runBtn");

runBtn.addEventListener("click", async () => {

    console.log("===== CALLBACK VERSION =====");

    addTaskCallback("Learn JS", (msg) => {
        console.log(msg);

        addTaskCallback("Practice Async", (msg) => {
            console.log(msg);

            listTasksCallback((tasks) => {
                console.log(`Tasks: ${tasks.join(", ")}`);
            });
        });
    });


    setTimeout(() => {
        console.log("\n===== PROMISE VERSION =====");

        addTaskPromise("Learn Promises")
            .then(msg => {
                console.log(msg);
                return listTasksPromise();
            })
            .then(tasks => {
                console.log(`Tasks: ${tasks.join(", ")}`);
            });

    }, 4000);


    setTimeout(async () => {
        console.log("\n===== ASYNC/AWAIT VERSION =====");

        try {
            const msg1 = await addTask("Master Async/Await");
            console.log(msg1);

            const msg2 = await deleteTask("Learn JS");
            console.log(msg2);

            const currentTasks = await listTasks();
            console.log(`Tasks: ${currentTasks.join(", ")}`);

        } catch (error) {
            console.error(`Error: ${error.message}`);
        }

    }, 8000);

});