function moveOption(base, destination) {
    let baseOptions = base.options;
    let anySelected = false;

    for (let i = 0; i < baseOptions.length; i++) {
        if(baseOptions[i].selected) {
            baseOptions[i].selected = false;
            destination.add(baseOptions[i]);
            anySelected = true;
            i--;
        }
    }
    if(!anySelected) {
        alert("You have to select an option");
    }
}

function moveAllOptions(base, destination) {
    let baseOptions = base.options;

    for (let i = 0; i < baseOptions.length; i++) {
        baseOptions[i].selected = false;
        destination.add(baseOptions[i]);
        i--;
    }
}