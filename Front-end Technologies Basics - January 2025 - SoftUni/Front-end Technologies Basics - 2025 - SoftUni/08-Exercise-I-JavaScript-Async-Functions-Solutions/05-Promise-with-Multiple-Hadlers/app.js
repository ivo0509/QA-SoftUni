function promiseWithMultipleHandlers() {
    new Promise((resolve) => {
            setTimeout(() => resolve("Hello World"), 2000);
        })
        .then((message) => {
            console.log(message); 
            return message; 
        })
        .then((message) => {
            console.log(message); 
        });

}