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
            //responsive: true,
            //maintainAspectRatio: false,
            legend: {
                display: false
            }
        }
    });
}

// ----------------------------------------------------------------------------

function pickRand(array) {
    return array[Math.floor(array.length * Math.random())];
}

function pickRands(array, n) {
    var result = [];
    for (var i = 0; i < n; i++) {
        result.push(pickRand(array));
    }
    return result;
}

function log10(x) {
    return Math.log(x) / Math.LN10;
}

function mult(array) {
    return array.reduce(function(a, b) {
        return a * b;
    });
}

function sum(array) {
    return array.reduce(function(a, b) {
        return a + b;
    });
}
// ----------------------------------------------------------------------------

var n = 30,
    r = 7,
    k = 100000,
    a = Math.pow(2, n - 1) - 2765,
    m = Math.pow(2, n) - 14,
    details;


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

function uniformDist(sequence, a, b) {
    return sequence.map(function(r) {
        return a + (b - a) * r;
    });
}

var uniformDistSequence = uniformDist(originalSequence, 5, 10);

drawHistogram(uniformDistSequence, 'graph2');
details = calculateDetails(uniformDistSequence);
document.getElementById('M2').innerHTML = details.matWait;
document.getElementById('D2').innerHTML = details.disp;
document.getElementById('S2').innerHTML = details.sko;

// ----------------------------------------------------------------------------


function simpsonDist(sequence, a, b) {
    var uniformDistSequence = uniformDist(sequence, a / 2, b / 2);
    return sequence.map(function(r) {
        var y = pickRand(uniformDistSequence),
            z = pickRand(uniformDistSequence);

        return y + z;
    });
}

var simpsonDistSequence = simpsonDist(originalSequence, 5, 10);

drawHistogram(simpsonDistSequence, 'graph3');
details = calculateDetails(simpsonDistSequence);
document.getElementById('M3').innerHTML = details.matWait;
document.getElementById('D3').innerHTML = details.disp;
document.getElementById('S3').innerHTML = details.sko;

// ----------------------------------------------------------------------------

function exponentialDist(sequence, lambda) {
    return sequence.map(function(r) {
        return (-1 / lambda) * log10(r);
    });
}

var exponentialDistSequence = exponentialDist(originalSequence, 1.5);

drawHistogram(exponentialDistSequence, 'graph4');
details = calculateDetails(exponentialDistSequence);
document.getElementById('M4').innerHTML = details.matWait;
document.getElementById('D4').innerHTML = details.disp;
document.getElementById('S4').innerHTML = details.sko;

// ----------------------------------------------------------------------------

function gammaDist(sequence, eta, lambda) {
    return sequence.map(function(r) {
        var multRands = mult(pickRands(sequence, eta));
        return (-1 / lambda) * log10(multRands);
    });
}

var gammaDistSequence = gammaDist(originalSequence, 20, 1.5);
drawHistogram(gammaDistSequence, 'graph5');
details = calculateDetails(gammaDistSequence);
document.getElementById('M5').innerHTML = details.matWait;
document.getElementById('D5').innerHTML = details.disp;
document.getElementById('S5').innerHTML = details.sko;

// ----------------------------------------------------------------------------

function gaussianDist(sequence, mean, variance, n) {
    return sequence.map(function(r) {
        var sumRands = sum(pickRands(sequence, n));
        return mean + variance * Math.sqrt(12 / n) * (sumRands - n / 2);
    });
}

var gaussianDistSequence = gaussianDist(originalSequence, -2, 0.5, 6);
drawHistogram(gaussianDistSequence, 'graph6');
details = calculateDetails(gaussianDistSequence);
document.getElementById('M6').innerHTML = details.matWait;
document.getElementById('D6').innerHTML = details.disp;
document.getElementById('S6').innerHTML = details.sko;

// ----------------------------------------------------------------------------

function triangularDest(sequence, a, b) {
    var uniformDistSequence = uniformDist(sequence, a, b);
    return sequence.map(function(r) {
        var r1 = pickRand(uniformDistSequence),
            r2 = pickRand(uniformDistSequence);

        return a + (b - a) * Math.min(r1, r2);
    });
}

var triangularDestSequence = triangularDest(originalSequence, 5, 10);
drawHistogram(triangularDestSequence, 'graph7');
details = calculateDetails(triangularDestSequence);
document.getElementById('M7').innerHTML = details.matWait;
document.getElementById('D7').innerHTML = details.disp;
document.getElementById('S7').innerHTML = details.sko;