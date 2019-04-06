function Canvas() {
    var _obj = {},
        canvas = null,
        ctx = null,
        colors = ["#000000", "#ff0000", "#00ff00", "#0000ff", "#ffff00", "#00ffff", "#ff00ff", "#ffffff", "#660000", "#006600", "#000066", "#666600", "#006666", "#660066", "#c30000", "#00c300", "#0000c3", "#c3c300", "#00c3c3", "#c300c3"];

    function drawPoint(x, y, c, size) {
        ctx.fillStyle = colors[c];
        ctx.fillRect(x, y, size, size);
    }

    _obj.drawCluster = function(arr, size) {
        for (var i = 0; i < arr.length; i++) {
            drawPoint(arr[i].x, arr[i].y, arr[i].c, size);
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
    var n = 100000;
    var k = 20;
    var a = Canvas();
    a.Init("canvas");

    var points = [];
    var centersOld = [];
    var centersNew = [];
    var counts = [];

    for (var i = 0; i < k; i++) {
        centersNew[i] = {
            x: 0,
            y: 0,
            kk: 0
        }
    }

    for (var i = 0; i < k; i++) {
        counts[i] = 0;
    }

    for (var i = 0; i < n; i++) {
        points[i] = {
            x: randomInt(0, 600),
            y: randomInt(0, 400),
            kk: 0
        };
    }

    for (var i = 0; i < k; i++) {
        var temp = Math.floor((n - 1) / (i + 1));
        centersOld[i] = {
            x: points[temp].x,
            y: points[temp].y,
            kk: i
        }
        console.log(centersOld[i]);
    }

    /* 1 */

    for (var i = 0; i < n; i++) {
        var min = 240000;
        var m_j = 0;
        var temp = 0;
        for (var j = 0; j < k; j++) {
            m = Math.sqrt(Math.pow(points[i].x - centersOld[j].x, 2) + Math.pow(points[i].y - centersOld[j].y, 2));
            if (m < min) {
                min = m;
                m_j = j;
            }
        }
        points[i].kk = m_j;
        counts[m_j]++;
    }

    var cc = 0;
    for (var i = 0; i < k; i++) {
        console.log(counts[i]);
        cc += counts[i];
    }
    console.log(cc);

    for (var i = 0; i < k; i++) {
        if ((centersOld[i].x != centersNew[i].x) || (centersOld[i].y != centersNew[i].y)) {
            /* 2 */
        }
    }

    /* 2 */

    for (var i = 0; i < n; i++) {
        // массивы средниеквадратичных сумм координат точек каждого кластера (20)
        var m_j = 0;
        var temp = 0;
        for (var j = 0; j < k; j++) {
            m = Math.sqrt(Math.pow(points[i].x - centersOld[j].x, 2) + Math.pow(points[i].y - centersOld[j].y, 2));
            if (m < min) {
                min = m;
                m_j = j;
            }
        }
        points[i].kk = m_j;
        counts[m_j]++;
    }


    /*
        function Tick() {
            tickCount++;

            for (var i = 0; i < n; i++) {
                var min = 100000;
                var temp_j = c + 1;
                var temp = 0;
                for (var j = 0; j < c; j++) {
                    temp = Math.sqrt(Math.pow(points[i].x - centers[j].x, 2) + Math.pow(points[i].y - centers[j].y, 2));

                    if (temp < min) {
                        min = temp;
                        temp_j = j;
                    }
                }
                points[i].c = temp_j;
            }

            for (var j = 0; j < c; j++) {
                var max = 0;
                var temp1 = {
                    x: n + 1,
                    y: n + 1
                };
                var temp2 = {
                    x: n + 1,
                    y: n + 1
                };
                for (var i = 0; i < n - 1; i++) {
                    for (var g = i; g < n; g++) {

                        if (points[i].c === j && j === points[g].c) {
                            var temp = Math.sqrt(Math.pow(points[i].x - points[g].x, 2) + Math.pow(points[i].y - points[g].y, 2));
                            if (temp > max) {
                                temp1.x = points[i].x;
                                temp1.y = points[i].y;
                                temp2.x = points[g].x;
                                temp2.y = points[g].y;
                                max = temp;
                            }
                        }
                    }
                }

                var tempX = (temp1.x + temp2.x) / 2;
                var tempY = (temp1.y + temp2.y) / 2;
                console.log(tempX);

                var min = 100000;
                var temp_x = n + 1;
                var temp_y = n + 1;
                var point = n + 1;
                for (var i = 0; i < n; i++) {
                    if (points[i].c === j) {
                        temp = Math.sqrt(Math.pow(points[i].x - tempX, 2) + Math.pow(points[i].y - tempY, 2));

                        if (temp < min) {
                            min = temp;
                            temp_x = points[i].x;
                            temp_y = points[i].y;
                            point = i;
                        }
                    }

                }
                centers[j].x = points[point].x;
                centers[j].y = points[point].y;

            }

            a.Clear();
            a.drawCluster(points, 2);
            a.drawCluster(centers, 20);

            console.log(tickCount);
        }
        setInterval(Tick, 500);
    */
}