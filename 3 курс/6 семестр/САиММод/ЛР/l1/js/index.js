function matWait(seq) {
    var sum = seq.reduce(function(sum, x) {
        return sum + x;
    });
    return sum / seq.length;
}

function disp(seq, matWait) {
    var sum = seq.reduce(function(sum, x) {
        return Math.pow(x - matWait, 2);
    });
    return sum / seq.length;
}

function sko(disp) {
    return Math.sqrt(disp);
}

function calculateDetails(sequence) {
    var details = {};
    details.matWait = matWait(sequence);
    details.disp = disp(sequence, details.matWait);
    details.sko = sko(details.disp);
    return details;
}

// ----------------------------------------------------------------------------

function drawHistogram(sequence, selector, segmentsCount) {
    segmentsCount = segmentsCount || 30;

    var min = Math.min.apply(null, sequence),
        max = Math.max.apply(null, sequence),
        length = max - min;

    var segmentLength = length / segmentsCount;

    var map = {};

    sequence.forEach(function(el) {
        if (el >= max || el < min) { return; }
        var segmentNumber = Math.ceil(el / segmentLength);
        map[segmentNumber] = (map[segmentNumber] + 1) || 1;
    });

    function sortNeg(a, b) { return a - b; }

    function values(obj) {
        return Object.keys(obj).sort(sortNeg).map(function(key) {
            return obj[key] / sequence.length;
        });
    }

    function keys(obj) {
        return Object.keys(obj).sort(sortNeg).map(function(key) {
            return (segmentLength * key).toFixed(3);
        });
    }

    var ctx = document.getElementById(selector).getContext('2d');
    var data = {
        labels: keys(map),
        datasets: [{
            borderWidth: "0",
            backgroundColor: [
                "#FFCDD2", "#F8BBD0", "#E1BEE7", "#D1C4E9", "#C5CAE9", "#BBDEFB", "#B3E5FC", "#B2EBF2", "#B2DFDB", "#C8E6C9",
                "#DCEDC8", "#F0F4C3", "#FFF9C4", "#FFECB3", "#FFE0B2", "#FFCCBC", "#FFCDD2", "#F8BBD0", "#E1BEE7", "#D1C4E9",
                "#C5CAE9", "#BBDEFB", "#B3E5FC", "#B2EBF2", "#B2DFDB", "#C8E6C9", "#DCEDC8", "#F0F4C3", "#FFF9C4", "#FFECB3",
                "#FFE0B2"
            ],
            hoverBackgroundColor: [
                "#F44336", "#E91E63", "#9C27B0", "#673AB7", "#3F51B5", "#2196F3", "#03A9F4", "#00BCD4", "#009688", "#4CAF50",
                "#8BC34A", "#CDDC39", "#FFEB3B", "#FFC107", "#FF9800", "#FF5722", "#F44336", "#E91E63", "#9C27B0", "#673AB7",
                "#3F51B5", "#2196F3", "#03A9F4", "#00BCD4", "#009688", "#4CAF50", "#8BC34A", "#CDDC39", "#FFEB3B", "#FFC107",
                "#FF9800"
            ],
            data: values(map),
        }]
    };

    var chart = new Chart(ctx, {
        type: 'bar',
        data: data,
        options: {
            responsive: true,
            maintainAspectRatio: false,
            legend: {
                display: false
            }
        }
    });
}

function drawDetails(sequence, selector) {
    var details = calculateDetails(sequence);

    document.getElementById('M').innerHTML = details.matWait;
    document.getElementById('D').innerHTML = details.disp;
    document.getElementById('S').innerHTML = details.sko;
}

// ----------------------------------------------------------------------------

var n = 30,
    r = 7,
    k = 100000,
    a = Math.pow(2, n - 1) - 2765,
    m = Math.pow(2, n) - 14;


function originalDistClean(r0, k) {
    var seq = [r0];
    for (var i = 0; i < k; i++) {
        seq.push((a * seq[i]) % m);
    }
    return seq;
}

function originalDistNormalize(seq) {
    return seq.map(function(r) {
        return r / m;
    });
}

var originalSequenceClean = originalDistClean(r, k);
var originalSequence = originalDistNormalize(originalSequenceClean);

drawHistogram(originalSequence, 'graph');
drawDetails(originalSequence, 'details');

// ----------------------------------------------------------------------------

// проверка по косвенным признакам
function isDist(seq, n1) {
    var k1 = 0;
    for (var i = 0; i < n1; i += 2) {
        if ((Math.pow(seq[i], 2) + Math.pow(seq[i + 1], 2)) < 1) {
            k1++;
        }
    }
    return (2 * k1 / n1);
}

document.getElementById('P').innerHTML = Math.PI / 4;
document.getElementById('KN').innerHTML = isDist(originalSequence, k);

function findPeriod(seq) {
    var Xv = seq[seq.length - 1],
        i1 = -1,
        i2 = -1,
        flag = false;

    // нахождение длины периода
    for (var i = 0; i < seq.length; i++) {
        if (seq[i] == Xv) {
            if (!flag) {
                flag = true;
                i1 = i;
                continue;
            } else {
                i2 = i;
                break;
            }
        }
    }
    var period = i2 - i1;

    // нахождение длины участка апериодичности
    var i3 = 0;
    while (seq[i3] != seq[i3 + period])
        i3++;
    var aperiod = i3 + period;

    if (i2 == -1 || i1 == -1) {
        document.getElementById('flag').innerHTML = 'Не найдено';
    } else {
        document.getElementById('flag').innerHTML = 'Найдено';
        document.getElementById('per').innerHTML = period;
        document.getElementById('aper').innerHTML = aperiod;
    }
}
findPeriod(originalSequence);