if (!(window.File && window.FileReader && window.FileList && window.Blob)) {
    alert('The File APIs are not fully supported in this browser.');
}

var words = [],
    stemWords = [],
    zipf1Words = {},
    zipf1Freqs = {},
    zipf2Freqs = {},
    C1 = 0,
    C2 = 0;

function drawGraph(selector, dataArray) {
    function keys(arr) {
        return Object.keys(arr);
    }

    function values(arr) {
        return Object.values(arr);
    }

    var ctx = document.getElementById(selector).getContext('2d');
    var chart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: keys(dataArray),
            datasets: [{
                data: values(dataArray),
                backgroundColor: 'rgba(32, 201, 151, 0.2)',
                borderColor: 'rgba(32, 201, 151, 1)',
                borderWidth: 2,
                pointRadius: 0,
                pointHoverRadius: 0,
                pointHitRadius: 30
            }]
        },
        options: {
            legend: {
                display: false
            }
        }
    });
}

function sVal(a, b) {
    if (a[1] < b[1]) return 1;
    else if (a[1] > b[1]) return -1;
    else return 0;
}

function doZipf1(arr) {
    var a = [],
        b = [],
        sortable = [],
        prev,
        K = 0;

    arr.sort();
    for (var i = 0; i < arr.length; i++) {
        if (arr[i] !== prev) {
            a.push(arr[i]);
            b.push(1);
        } else {
            b[b.length - 1]++;
        }
        prev = arr[i];
    }

    for (var i = 0; i < a.length; i++) {
        sortable.push([a[i], b[i]]);
    }
    sortable.sort(sVal);

    if (document.getElementById('language').value == 'english') {
        K = sortable.length;
    } else {
        K = words.length;
    }

    for (var i = 0; i < sortable.length; i++) {
        zipf1Words[i + 1] = sortable[i][0];
        zipf1Freqs[i + 1] = sortable[i][1] / K;
        C1 += zipf1Freqs[i + 1] * (i + 1) / words.length;
    }

    C1 = C1.toFixed(3);

    return zipf1Freqs;
}

function doZipf2(arr) {
    var sortable = [],
        sortFix = [],
        K = 0;

    for (var i in arr) {
        sortable.push(arr[i]);
    }
    sortable.sort(function(a, b) {
        return a - b;
    });

    for (var i = 0; i < sortable.length; i++) {
        sortFix[i] = sortable[i].toFixed(7);
    }

    sortFix.forEach(function(a) {
        zipf2Freqs[a] = zipf2Freqs[a] + 1 || 1;
    });

    if (document.getElementById('language').value == 'english') {
        K = 0.178;
    } else {
        if (document.getElementById('language').value == 'russian') {
            K = 1.6;
        } else {
            K = 2.5;
        }
    }

    C2 = (sortable[sortable.length - 1] * K).toFixed(3);

    return zipf2Freqs;
}


var Stem = function(lng) {
    var testStemmer = new Snowball(lng);
    return function(word) {
        testStemmer.setCurrent(word);
        testStemmer.stem();
        return testStemmer.getCurrent();
    }
};

function doStemWords(lng, words) {
    for (var i = 0; i < words.length; i++) {
        stemWords[i + 1] = new Stem(lng)(words[i]);
    }
}


function handleFileSelect(evt) {
    var lang, file = evt.target.files[0];
    if (!file.type.match('text.*')) {
        return alert(file.name + " is not a valid text file.");
    }
    var reader = new FileReader();
    reader.readAsText(file);
    reader.onload = function(e) {
        words = [];
        stemWords = [];
        zipf1Words = {};
        zipf1Freqs = {};
        zipf2Freqs = {};
        C1 = 0;
        C2 = 0;

        words = reader.result.replace(/(\\r?\\n)+/gi, ' ')
            .replace(/['\-]/gi, '')
            .replace(/[,.~`|\/^&!?@{}\[\]<>#%$()_−–—+=*;:"\\«»]/gi, ' ')
            .replace(/[0-9]/gi, ' ')
            .replace(/[ ]{2,}/gi, ' ')
            .replace(/\s/gi, ' ')
            .replace(/\s{2,}/gi, ' ')
            .trim()
            .toLowerCase()
            .match(/\S+/g);

        if (document.getElementById('language').value == 'belorussian') {
            lang = 'russian';
        } else {
            lang = document.getElementById('language').value;
        }
        doStemWords(lang, words);
        drawGraph('chart1', doZipf1(stemWords));
        drawGraph('chart2', doZipf2(zipf1Freqs));
        document.getElementById('C1').innerText = 'Константа Зипфа = ' + C1;
        document.getElementById('C2').innerText = 'Константа Зипфа = ' + C2;
    };
}

window.onload = function() {
    document.getElementById('file').addEventListener('change', handleFileSelect, false);
}