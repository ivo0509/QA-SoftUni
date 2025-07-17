async function getUserInput(promptMessage) {
    return new Promise((resolve) => {
        const input = prompt(promptMessage);
        resolve(input);
    });
}

async function startCountdown() {
    const userInput = await getUserInput("Enter the number of seconds for the countdown:");
    let timeLeft = parseInt(userInput);

    if (isNaN(timeLeft) || timeLeft <= 0) {
        console.log("Please enter a valid number of seconds.");
        return;
    }

    console.log(`Countdown started from ${timeLeft} seconds`);
    const countdownInterval = setInterval(async () => {
        console.log(`Time left: ${timeLeft} seconds`);
        timeLeft--;
        if (timeLeft == 0) {
            clearInterval(countdownInterval);
            console.log("Countdown finished");
            await saveRemainingTime(timeLeft);
        }
    }, 1000);
}

function saveRemainingTime(time) {
    return new Promise((resolve) => {
        setTimeout(() => {
            console.log(`Remaining time saved: ${time} seconds`);
            resolve();
        }, 500);
    });
}

window.startCountdown = startCountdown;