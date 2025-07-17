function simplePromise() {
    new Promise((resolve) => {
        setTimeout(() => resolve("Success!"), 2000);
    }).then(console.log);
}