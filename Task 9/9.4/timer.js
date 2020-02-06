let paused = false;
let again = false;

(function startCountdown() {
    let timer = document.getElementById('Timer');
    let time = timer.innerText;

    if(time == 0) {
        switch (document.title) {
            case 'Page 1': document.location.href = 'page2.html';
            break;
            case 'Page 2': document.location.href = 'page3.html';
            break;
            case 'Page 3': 
            again = confirm('Do you want to see pages again?');
            if(again) {
                document.location.href = 'page1.html';
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
