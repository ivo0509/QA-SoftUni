class AsyncQueue {
    constructor() {
        this.queue = [];
        this.processing = false;
    }

    enqueue(task) {
        this.queue.push(task);
        if (!this.processing) this.process();
    }

    async process() {
        this.processing = true;
        while (this.queue.length > 0) {
            const task = this.queue.shift();
            await task();
        }
        this.processing = false;
    }
}

function startQueue() {
    const queue = new AsyncQueue();
    queue.enqueue(() => new Promise(resolve => setTimeout(() => { console.log("Task 1 done"); resolve(); }, 1000)));
    queue.enqueue(() => new Promise(resolve => setTimeout(() => { console.log("Task 2 done"); resolve(); }, 1500)));
    queue.enqueue(() => new Promise(resolve => setTimeout(() => { console.log("Task 3 done"); resolve(); }, 500)));
}

window.startQueue = startQueue;