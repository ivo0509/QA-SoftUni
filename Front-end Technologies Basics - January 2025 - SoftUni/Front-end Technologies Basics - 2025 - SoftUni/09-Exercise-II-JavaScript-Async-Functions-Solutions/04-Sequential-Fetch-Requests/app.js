async function fetchSequential() {
    const res1 = await fetch("https://swapi.dev/api/people/1").then(res => res.json());
    console.log(res1);
    const res2 = await fetch("https://swapi.dev/api/people/2").then(res => res.json());
    console.log(res2);
}