let stopwatchInterval;
let elapsedTime = 0;
let saveInterval;

function startStopwatch() {
    if (stopwatchInterval) return;
    console.log("Stopwatch started");
    stopwatchInterval = setInterval(() => {
        elapsedTime++;
        console.log(`Elapsed time: ${elapsedTime} seconds`);
    }, 1000);

    saveInterval = setInterval(async () => {
        await saveElapsedTime(elapsedTime);
    }, 5000);
}

function stopStopwatch() {
    if (!stopwatchInterval) return;
    clearInterval(stopwatchInterval);
    clearInterval(saveInterval);
    stopwatchInterval = null;
    saveInterval = null;
    console.log(`Stopwatch stopped at ${elapsedTime} seconds`);
    elapsedTime = 0;
}

function saveElapsedTime(time) {
    return new Promise((resolve) => {
        setTimeout(() => {
            console.log(`Elapsed time saved: ${time} seconds`);
            resolve();
        }, 500);
    });
}

window.startStopwatch = startStopwatch;
window.stopStopwatch = stopStopwatch;