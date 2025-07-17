async function throttlePromises() {
    const asyncTasks = [
        () => new Promise(resolve => setTimeout(() => { console.log("Task 1 done"); resolve("Task 1 done"); }, 1000)),
        () => new Promise(resolve => setTimeout(() => { console.log("Task 2 done"); resolve("Task 2 done"); }, 1500)),
        () => new Promise(resolve => setTimeout(() => { console.log("Task 3 done"); resolve("Task 3 done"); }, 500)),
        () => new Promise(resolve => setTimeout(() => { console.log("Task 4 done"); resolve("Task 4 done"); }, 2500)),
    ];

    async function throttle(tasks, limit) {
        const results = [];
        const executing = [];
        for (const task of tasks) {
            const p = task().then(result => {
                executing.splice(executing.indexOf(p), 1);
                return result;
            });
            results.push(p);
            executing.push(p);
            if (executing.length >= limit) {
                await Promise.race(executing);
            }
        }
        return Promise.all(results);
    }

    const results = await throttle(asyncTasks, 2);
    console.log('All tasks done:', results);
}

window.throttlePromises = throttlePromises;