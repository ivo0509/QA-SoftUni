function askQuestion(question, answers) {
    return new Promise((resolve) => {
        let message = question + '\n';
        answers.forEach((answer, index) => {
            message += `${index + 1}. ${answer}\n`;
        });
        const answer = prompt(message);
        resolve(parseInt(answer) - 1);
    });
}

const questions = [
    {
        question: "What is 2 + 2?",
        answers: ["3", "4", "5"],
        correct: 1
    },
    {
        question: "What is the capital of France?",
        answers: ["Berlin", "Madrid", "Paris"],
        correct: 2
    },
    {
        question: "What is the square root of 16?",
        answers: ["4", "5", "6"],
        correct: 0
    }
];

async function startQuiz() {
    console.log("Quiz started");
    let score = 0;
    for (let i = 0; i < questions.length; i++) {
        const { question, answers, correct } = questions[i];
        const userAnswer = await askQuestion(question, answers);
        if (userAnswer === correct) {
            console.log("Correct!");
            score++;
        } else {
            console.log("Wrong!");
        }
    }
    console.log(`\nYou scored ${score} out of ${questions.length}.`);
}

window.startQuiz = startQuiz;
