let paused = false;
let again = false;

(function startCountdown() {
    let timer = document.getElementById('timer');
    let time = timer.innerText;

    if(time == 0) {
        switch (document.title) {
            case 'Page 1': window.location.href = 'page2.html';
            break;
            case 'Page 2': window.location.href = 'page3.html';
            break;
            case 'Page 3': 
            again = confirm('Do you want to see pages again?');
            if(again) {
                window.location.href = 'page1.html';
            } else {
                return;
            }
            break;
        }
    } else {
        if(!paused) {
            timer.innerText --;  
        }
    }
    setTimeout(startCountdown, 1000);
}());

document.getElementById('pause').addEventListener('click', pauseCountdown);
document.getElementById('continue').addEventListener('click', continueCountdown);
