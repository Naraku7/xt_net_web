function calculate(str) {

    let result = 0;

    // making an array of numbers
    let numbers = str.match(new RegExp(/\d+(\.\d+)?/g)); 

    // making an array of operators
    let operators = str.match(new RegExp(/[+\-*/]/g));  
 
    if (str[0] == '-') {
        result -= Number(numbers[0]);
        operators.shift();
    } else {
        result += Number(numbers[0]);
    }

    for (let i = 1; i < numbers.length; i++) { 
        switch(operators[i-1]) {
            case '-':  result -= numbers[i];
            case '+':  result += Number(numbers[i]);
            case '*':  result *= numbers[i];
            case '/':  result /= numbers[i];

        }
    }
    return result;
}


