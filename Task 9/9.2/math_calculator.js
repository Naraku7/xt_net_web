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

    result += evaluate(numbers, operators);

    return result;
}

function evaluate(numbers, operators) {

    let result = 0;

    //starting with 1 index because of checking for minus in str[0]
    for (let i = 1; i < numbers.length; i++) { 
        switch(operators[i-1]) {
            case '-':  result -= Number(numbers[i]);
            break;
            case '+':  result += Number(numbers[i]);
            break;
            case '*':  result *= Number(numbers[i]);
            break;
            case '/':  result /= Number(numbers[i]);
            break;
        }
    }
    return result;
}


