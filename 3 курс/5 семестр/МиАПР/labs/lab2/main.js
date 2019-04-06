function Canvas() {
    var _obj = {},
        canvas = null,
        ctx = null,
        colors = ["#000000", "#ff0000", "#00ff00", "#0000ff", "#ffff00", "#00ffff", "#ff00ff", "#ffffff", "#660000", "#006600", "#000066", "#666600", "#006666", "#660066", "#c30000", "#00c300", "#0000c3", "#c3c300", "#00c3c3", "#c300c3"];

    function drawPoint(x, y, c, size) {
        ctx.fillStyle = colors[c];
        ctx.fillRect(x, y, size, size);
    }

    function drawPoint2(x, y, c, x1, x2) {
        ctx.beginPath();
        ctx.strokeStyle = colors[19 - c];
        ctx.moveTo(x, y);
        ctx.lineTo(x1, x2);
        ctx.stroke();
    }

    _obj.drawCluster = function(arr, size) {
        for (var i = 0; i < arr.length; i++) {
            drawPoint(arr[i].x, arr[i].y, arr[i].c, size);
        }
    }

    _obj.drawCluster2 = function(arr, arr2) {
        for (var i = 0; i < arr.length; i++) {
            drawPoint2(arr[i].x, arr[i].y, arr[i].c, arr2[arr[i].c].x, arr2[arr[i].c].y);
        }

    }

    _obj.Clear = function() {
        ctx.clearRect(0, 0, canvas.width, canvas.height);
    }

    _obj.Init = function(canvasId) {
        canvas = document.getElementById(canvasId);
        ctx = canvas.getContext('2d');
    }

    return _obj;
}

function randomInt(min, max) {
    return Math.floor(Math.random() * (max - min)) + min;
}

window.onload = function() {
    var tickCount = 0;
    var n = 10000;
    var run = true;
    var c = 2;
    var a = Canvas();
    a.Init("canvas");

    var points = [];
    var centers = [];
    var counts = [];

    for (var i = 0; i < 100; i++) {
        counts[i] = 0;
    }

    for (var i = 0; i < n; i++) {
        points[i] = {
            x: randomInt(0, 600),
            y: randomInt(0, 400),
            c: 0
        };
    }

    // 1) устанавливаем первые 2 ядра (элемента, центра)
    var temp1 = -1;
    var temp2 = -1;
    var max = 0;
    // 2) ищем максимально отстоящие друг от друга
    for (var i = 0; i < n - 1; i++) {
        for (var j = i; j < n; j++) {
            var temp = Math.sqrt(Math.pow(points[i].x - points[j].x, 2) + Math.pow(points[i].y - points[j].y, 2));
            if (max < temp) {
                max = temp;
                temp1 = i;
                temp2 = j;
            }
        }
    }
    centers[0] = {
        x: points[temp1].x,
        y: points[temp1].y,
        c: 0
    };
    centers[1] = {
        x: points[temp2].x,
        y: points[temp2].y,
        c: 1
    };

    // пока минимальное расстояние от одного из векторов до одного из ядер 
    // больше половины расстояния между ядрами - выполняем распределение объектов 
    // по классам и создаем новое ядро
    while (run) {
        // 3) вычисляем расстояния между остальными точками и имеющимися ядрами, среди которых находим наименьшие
        for (var i = 0; i < n; i++) {
            var min = 240000;
            var m_j = c + 1;
            var temp = 0;
            for (var j = 0; j < c; j++) {
                temp = Math.sqrt(Math.pow(points[i].x - centers[j].x, 2) + Math.pow(points[i].y - centers[j].y, 2));
                if (temp < min) {
                    min = temp;
                    m_j = j;
                }
            }
            points[i].c = m_j;

            counts[m_j]++;
        }

        // расстояние между ядрами
        var sum = 0;
        var temp = 0;
        for (var i = 0; i < c - 1; i++) {
            for (var j = i; j < c; j++) {
                temp = Math.sqrt(Math.pow(centers[i].x - centers[j].x, 2) + Math.pow(centers[i].y - centers[j].y, 2));
                sum += temp;
            }
        }
        temp1 = 0;

        // 4) ищем максимальное расстояние среди всех минимальных
        max = 0;
        for (var i = 0; i < c; i++) {
            for (var j = 0; j < n; j++) {
                if (points[j].c === i) {
                    temp = Math.sqrt(Math.pow(centers[i].x - points[j].x, 2) + Math.pow(centers[i].y - points[j].y, 2));
                    if (temp > max) {
                        max = temp;
                        temp1 = j;
                    }
                }
            }
        }

        // минимальное расстояние от одного из векторов до одного из ядер
        temp2 = 0;
        var min = 0;
        for (var i = 0; i < c; i++) {
            temp = Math.sqrt(Math.pow(centers[i].x - points[temp1].x, 2) + Math.pow(centers[i].y - points[temp1].y, 2));
            if (temp > min) {
                min = temp;
                temp2 = i;
            }
        }

        // если минимальное расстояние от одного из векторов до одного из ядер 
        // больше половины расстояния между ядрами - создаем новое ядро
        if (min > sum / (c * 2)) {
            centers[c] = {
                x: points[temp1].x,
                y: points[temp1].y,
                c: c
            };
            c++;
        } else {
            run = false;
        }
    }

    var cc = 0;
    for (var i = 0; i < c; i++) {
        console.log('K[' + i + ']=' + counts[i]);
        cc += counts[i];
    }
    console.log('Сount=' + cc);

    a.drawCluster2(points, centers);
    a.drawCluster(centers, 20);
}