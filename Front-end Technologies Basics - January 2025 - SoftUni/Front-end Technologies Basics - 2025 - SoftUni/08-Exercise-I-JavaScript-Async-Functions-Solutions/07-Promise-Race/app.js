function racePromise() {
    const p1 = new Promise(resolve => setTimeout(() => resolve("1 second"), 1000));
    const p2 = new Promise(resolve => setTimeout(() => resolve("2 seconds"), 2000));
    const p3 = new Promise(resolve => setTimeout(() => resolve("3 seconds"), 3000));
    
    Promise.race([p1, p2, p3]).then(console.log);
}