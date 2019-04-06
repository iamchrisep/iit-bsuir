var state = 2010,

    lengthQueue = 0,

    isNotEmptyQueue = false,

    state2010 = [0, 0.6, 1],
    state1010 = [0, 0.4, 1],
    state2011 = [0, 0.2, 0.5, 0.7, 1],
    state1001 = [0, 0.5, 1],
    state1011 = [0, 0.2, 0.7, 1],
    state2111 = [0, 0.2, 0.7, 1],
    state1111 = [0, 0.2, 0.7, 1],
    state2211 = [0, 0.2, 0.7, 1],
    state1211 = [0, 0.2, 1];

function getRandom() {
    return Math.random().toFixed(1);
}

function transition(currentValue, currentState) {
    switch (currentState) {
        case 1000:
            return 2010;
        case 2010:
            if (currentValue >= state2010[0] && currentValue < state2010[1]) {
                return 1000;
            }
            return 1010;
        case 1010:
            if (currentValue >= state1010[0] && currentValue < state1010[1]) {
                return 2010;
            }
            return 2011;
        case 2011:
            if (currentValue >= state2011[0] && currentValue < state2011[1]) {
                return 1000;
            }
            if (currentValue >= state2011[1] && currentValue < state2011[2]) {
                return 1010;
            }
            if (currentValue >= state2011[2] && currentValue < state2011[3]) {
                return 1001;
            }
            return 1011;
        case 1001:
            if (currentValue >= state1001[0] && currentValue < state1001[1]) {
                return 2010;
            }
            return 2011;
        case 1011:
            if (currentValue >= state1011[0] && currentValue < state1011[1]) {
                return 2010;
            }
            if (currentValue >= state1011[1] && currentValue < state1011[2]) {
                return 2011;
            }
            isNotEmptyQueue = true;
            lengthQueue += 0.028;
            return 2111;
        case 2111:
            if (currentValue >= state2111[0] && currentValue < state2111[1]) {
                return 1010;
            }
            if (currentValue >= state2111[1] && currentValue < state2111[2]) {
                return 1011;
            }
            isNotEmptyQueue = true;
            lengthQueue += 0.011;
            return 1111;
        case 1111:
            if (currentValue >= state1111[0] && currentValue < state1111[1]) {
                return 2011;
            }
            if (currentValue >= state1111[1] && currentValue < state1111[2]) {
                isNotEmptyQueue = true;
                lengthQueue += 0.028;
                return 2111;
            }
            isNotEmptyQueue = true;
            lengthQueue += 2 * 0.004;
            return 2211;
        case 2211:
            if (currentValue >= state2211[0] && currentValue < state2211[1]) {
                return 1011;
            }
            if (currentValue >= state2211[1] && currentValue < state2211[2]) {
                isNotEmptyQueue = true;
                lengthQueue += 0.011;
                return 1111;
            }
            isNotEmptyQueue = true;
            lengthQueue += 2 * 0.001;
            return 1211;
        case 1211:
            if (currentValue >= state1211[0] && currentValue < state1211[1]) {
                isNotEmptyQueue = true;
                lengthQueue += 0.028;
                return 2111;
            }
            isNotEmptyQueue = true;
            lengthQueue += 2 * 0.004;
            return 2211;
        default:
            return 0;
    }
}

function gen1() {
    document.getElementById('gen1').classList.add('disabled');
    document.getElementById('gen2').classList.add('disabled');
    isNotEmptyQueue = false;
    while (!isNotEmptyQueue) {
        var value = getRandom();
        state = transition(value, state);
        if (state > 0) {
            var tableRef = document.getElementById('stateTable');
            var newRow = tableRef.insertRow();
            if (isNotEmptyQueue) {
                newRow.classList.add('red-text');
                document.getElementById('L').innerHTML = lengthQueue.toFixed(3);
                document.getElementById('W').innerHTML = (lengthQueue / 0.085).toFixed(3);
            }
            var newCell1 = newRow.insertCell();
            newCell1.innerHTML = value;
            var newCell2 = newRow.insertCell();
            newCell2.innerHTML = state;
            var tbody = document.querySelector("tbody");
            tbody.scrollTop = tbody.scrollHeight;
        } else {
            alert('Ошибка! Перезагрузите, пожалуйста, страницу');
        }
    }
    document.getElementById('gen1').classList.remove('disabled');
    document.getElementById('gen2').classList.remove('disabled');
}

function gen2() {
    document.getElementById('gen1').classList.add('disabled');
    document.getElementById('gen2').classList.add('disabled');
    isNotEmptyQueue = false;
    var value = getRandom();
    state = transition(value, state);
    if (state > 0) {
        var tableRef = document.getElementById('stateTable');
        var newRow = tableRef.insertRow();
        if (isNotEmptyQueue) {
            newRow.classList.add('red-text');
            document.getElementById('L').innerHTML = lengthQueue.toFixed(3);
            document.getElementById('W').innerHTML = (lengthQueue / 0.085).toFixed(3);
        }
        var newCell1 = newRow.insertCell();
        newCell1.innerHTML = value;
        var newCell2 = newRow.insertCell();
        newCell2.innerHTML = state;
        var tbody = document.querySelector("tbody");
        tbody.scrollTop = tbody.scrollHeight;
    } else {
        alert('Ошибка! Перезагрузите, пожалуйста, страницу');
    }
    document.getElementById('gen1').classList.remove('disabled');
    document.getElementById('gen2').classList.remove('disabled');
}