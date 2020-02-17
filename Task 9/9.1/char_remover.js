let separators = ["?", "!", ":", ";", ",", ".", " ", "\t", "\r"];

function removeChar(str) {
    words = str.split(' ');
    let letters = {}; 
    let result;

    words.forEach(function(word) {
        word.split('').forEach(function(letter, i) {
            if(!letters[letter] && separators.indexOf(letter) == -1 && word.indexOf(letter, i+1) != -1) {
                letters[letter] = 1;
            }
        });
    });

    result = str.split('').filter(function (v) {
        return !letters[v];
    }).join('');

    return result;
}