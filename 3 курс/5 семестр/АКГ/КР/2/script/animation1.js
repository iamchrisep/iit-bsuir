var myFigure, distanceX, distanceY, x, y, H, W, currentScale, trails, useTrail, animate;

window.onload = function () {
    var canvas = document.getElementById('canvas');
    myFigure = canvas.getContext('2d');

    var canvas1 = document.getElementById('canvas1');

    W = canvas.width = canvas1.width = window.innerWidth - 30;
    H = canvas.height = canvas1.height = window.innerHeight - 60;

    var myWin = canvas1.getContext("2d");
    myWin.beginPath();
    myWin.fillStyle = "rgba(255, 255, 255, 1)";
    //myWin.fillStyle = "rgba(255, 255, 255, 0)";
    myWin.moveTo(600, 100);
    myWin.lineTo(1200, 100);
    myWin.lineTo(1200, 300);
    myWin.lineTo(800, 300);
    myWin.lineTo(800, 500);
    myWin.lineTo(1200, 500);
    myWin.lineTo(1200, 700);
    myWin.lineTo(600, 700);
    myWin.lineTo(600, 100);
    myWin.fill();
    myWin.strokeStyle = "rgba(0, 0, 0, 1)";
    myWin.lineWidth = 1;
    myWin.stroke();
    var myBack = canvas1.getContext("2d");
    myBack.beginPath();
    myBack.fillStyle = "rgba(255, 255, 255, 0)";
    //myBack.fillStyle = "rgba(255, 255, 255, 1)";
    myBack.moveTo(0, 0);
    myBack.lineTo(0, H);
    myBack.lineTo(600, H);
    myBack.lineTo(600, 100);
    myBack.lineTo(1200, 100);
    myBack.lineTo(1200, 300);
    myBack.lineTo(800, 300);
    myBack.lineTo(800, 500);
    myBack.lineTo(1200, 500);
    myBack.lineTo(1200, 700);
    myBack.lineTo(600, 700);
    myBack.lineTo(600, H);
    myBack.lineTo(W, H);
    myBack.lineTo(W, 0);
    myBack.fill();
    reset();
};

function reset() {
    x = 700;
    y = 200;
    document.getElementById("startButton").textContent = "Начать анимацию";
    currentScale = 1;
    trails = [{_x:x, _y:y, _s:currentScale}];
    draw(x, y, currentScale);
}

function draw(currentX, currentY, scale) {
    currentScale *= scale;
    drawHexagon(currentX, currentY, currentScale, "rgba(255, 248, 0, 1)");
}

function drawHexagon(currentX, currentY, scale, color) {
    myFigure.beginPath();
    myFigure.fillStyle = color;
    myFigure.moveTo(currentX + 180 * scale, currentY);
    myFigure.lineTo(currentX + 360 * scale, currentY + 120 * scale);
    myFigure.lineTo(currentX + 360 * scale, currentY + 320 * scale);
    myFigure.lineTo(currentX + 180 * scale, currentY + 440 * scale);
    myFigure.lineTo(currentX, currentY + 320 * scale);
    myFigure.lineTo(currentX, currentY + 120 * scale);
    myFigure.lineTo(currentX + 180 * scale, currentY);
    myFigure.fill();
}

function drawTrail(currentX, currentY, scale) {
    drawHexagon(currentX, currentY, scale, "rgba(255, 255, 255, 1)");
    myFigure.strokeStyle = "rgba(0, 0, 0, 0.5)";
    myFigure.lineWidth = 1;
    myFigure.stroke();
}

function startAnimation() {
    if (animate) {
        document.getElementById("startButton").textContent = "Начать анимацию";
        clearTimeout(animate);
        animate = null;
    }
    else {
        reset();
        animate = true;
        document.getElementById("startButton").textContent = "Закончить анимацию";
        distanceX = 100;
        distanceY = 100;
        useTrail = false;
        //useTrail = true;
        animation();
    }
}

function animation() {
    var n = 0;
    var currentX = x;
    var currentY = y;

    do {
        n = distanceX * (Math.random() * 5 - 2);
    }
    while (x + n <= 100 || x + n >= W - 500);

    x += n;

    do {
        n = distanceY * (Math.random() * 5 - 2);
    }
    while (y + n <= 100 || y + n >= H - 500);

    y += n;

    var stepX = (x - currentX) / 100;
    var stepY = (y - currentY) / 100;
    var k = 0;

    function moveToPoint() {
        if (k != 100) {
            k++;
            currentX += stepX;
            currentY += stepY;
            myFigure.clearRect(0, 0, myFigure.canvas.width, myFigure.canvas.height);
            if (useTrail) {
                trails.forEach(function(element) {
                    drawTrail(element._x, element._y, element._s);
                }, this);
            }
            draw(currentX, currentY, 1);
            if (animate) {
                window.requestAnimationFrame(moveToPoint);
            }
        }
        else {
            trails.push({_x:currentX, _y:currentY, _s:currentScale});
            animate = setTimeout(animation, 100);
        }
    }

    moveToPoint();
}
