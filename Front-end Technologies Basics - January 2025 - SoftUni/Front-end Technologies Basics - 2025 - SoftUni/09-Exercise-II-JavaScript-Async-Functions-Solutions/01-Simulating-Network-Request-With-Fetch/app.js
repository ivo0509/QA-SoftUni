async function fetchData() {
    const response = await fetch("https://swapi.dev/api/people/1");
    const data = await response.json();
    console.log(data);
}