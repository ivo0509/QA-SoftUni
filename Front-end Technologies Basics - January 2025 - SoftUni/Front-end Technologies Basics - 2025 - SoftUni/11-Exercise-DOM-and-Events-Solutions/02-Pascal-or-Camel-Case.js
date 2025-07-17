function solve() {
  let input = document.getElementById('text').value.toLowerCase();
  let currentCase = document.getElementById('naming-convention').value;
  let result = document.getElementById('result');

  let splited = input.split(' ');
  let string = '';

  if (currentCase == 'Camel Case') {
    string += splited[0];
    for (let i = 1; i < splited.length; i++) {
      string += splited[i][0].toUpperCase() + splited[i].slice(1, splited[i].length);
      result.textContent = string;
    }

  } else if (currentCase == 'Pascal Case') {
    for (let i = 0; i < splited.length; i++) {
      string += splited[i][0].toUpperCase() + splited[i].slice(1, splited[i].length);
      result.textContent = string;
    }
  } else {
    result.textContent = 'Error!';
  }

}