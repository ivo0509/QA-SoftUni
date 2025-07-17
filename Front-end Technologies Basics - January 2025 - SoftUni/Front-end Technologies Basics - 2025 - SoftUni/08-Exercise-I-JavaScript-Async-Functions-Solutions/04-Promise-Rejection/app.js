function promiseRejection() {
    new Promise((_, reject) => {
        setTimeout(() => reject(new Error("Something went wrong!")), 1000);
    }).catch(console.error);
}