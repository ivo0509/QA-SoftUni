function asyncGenerator(generatorFunc) {
    const generator = generatorFunc();
    function handle(result) {
        if (result.done) return Promise.resolve(result.value);
        return Promise.resolve(result.value).then(
            res => handle(generator.next(res)),
            err => handle(generator.throw(err))
        );
    }
    try {
        return handle(generator.next());
    } catch (err) {
        return Promise.reject(err);
    }
}

function startAsyncGenerator() {
    asyncGenerator(function* () {
        const data1 = yield new Promise(resolve => setTimeout(() => resolve("Task 1 done"), 1000));
        console.log(data1);
        const data2 = yield new Promise(resolve => setTimeout(() => resolve("Task 2 done"), 1500));
        console.log(data2);
        const data3 = yield new Promise(resolve => setTimeout(() => resolve("Task 3 done"), 500));
        console.log(data3);
    }).catch(console.error);
}

window.startAsyncGenerator = startAsyncGenerator;