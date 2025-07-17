async function promiseRejectionAsync() {
    try {
        await new Promise((_, reject) => setTimeout(() => reject(new Error("Oops!")), 1000));
    } catch (error) {
        console.error(error.message);
    }
}