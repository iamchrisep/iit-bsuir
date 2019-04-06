var myFigure, myPent1, x, y, H, W, pointsB, pointsE, pointsM, pointsS, trails, useTrail, animate;

window.onload = function () {
    var canvas = document.getElementById('canvas');

    W = canvas.width = window.innerWidth - 30;
    H = canvas.height = window.innerHeight - 60;

    myFigure = canvas.getContext('2d');
    myFigure.beginPath();
    myFigure.fillStyle = "rgba(0, 102, 102, 1)";
    myFigure.moveTo(100, 180);
    myFigure.lineTo(180, 100);
    myFigure.lineTo(260, 180);
    myFigure.lineTo(230, 280);
    myFigure.lineTo(130, 280);
    myFigure.lineTo(100, 180);
    myFigure.lineTo(100, 180);
    myFigure.fill();

    var myPent = canvas.getContext("2d");
    myPent.beginPath();
    myPent.fillStyle = "rgba(0, 102, 102, 1)";
    myPent.moveTo(100, 180);
    myPent.lineTo(180, 100);
    myPent.lineTo(260, 180);
    myPent.lineTo(230, 280);
    myPent.lineTo(130, 280);
    myPent.lineTo(100, 180);
    myPent.lineTo(100, 180);
    myPent.fill();

    pointsB = [
	{_x:100, _y:180},
	{_x:180, _y:100},
	{_x:260, _y:180},
	{_x:230, _y:280},
	{_x:130, _y:280},
	{_x:100, _y:180}
    ];
/*
    var myHex = canvas.getContext("2d");
    myHex.beginPath();
    myHex.fillStyle = "rgba(0, 102, 102, 1)";
    myHex.moveTo(1600, 600);
    myHex.lineTo(1680, 550);
    myHex.lineTo(1760, 600);
    myHex.lineTo(1760, 700);
    myHex.lineTo(1680, 750);
    myHex.lineTo(1600, 700);
    myHex.lineTo(1600, 600);
    myHex.fill();

    pointsE = [
	{_x:1600, _y:600},
	{_x:1680, _y:550},
	{_x:1760, _y:600},
	{_x:1760, _y:700},
	{_x:1680, _y:750},
	{_x:1600, _y:700}
    ];

    pointsE = [
	{_x:1600, _y:700},
	{_x:1680, _y:750},
	{_x:1760, _y:700},
	{_x:1760, _y:600},
	{_x:1680, _y:550},
	{_x:1600, _y:600}
    ];
*/

    pointsE = [
	{_x:1600, _y:700},
	{_x:1600, _y:600},
	{_x:1680, _y:550},
	{_x:1760, _y:600},
	{_x:1760, _y:700},
	{_x:1680, _y:750}
    ];

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
    x = 100;
    y = 80;
    document.getElementById("startButton").textContent = "Начать анимацию";
    pointsM = [
	{_x:100, _y:180},
	{_x:180, _y:100},
	{_x:260, _y:180},
	{_x:230, _y:280},
	{_x:130, _y:280},
	{_x:100, _y:180}
    ];
    trails = [
	{_x:100, _y:180},
	{_x:180, _y:100},
	{_x:260, _y:180},
	{_x:230, _y:280},
	{_x:130, _y:280},
	{_x:100, _y:180}
    ];
    pointsS = [
	{_x:100, _y:180},
	{_x:180, _y:100},
	{_x:260, _y:180},
	{_x:230, _y:280},
	{_x:130, _y:280},
	{_x:100, _y:180}
    ];
}

function draw(points) {
    drawHexagon(points, "rgba(0, 102, 102, 1)");
}

function drawHexagon(points, color) {
    myFigure.beginPath();
    myFigure.fillStyle = color;
    myFigure.moveTo(points[0]._x, points[0]._y);
    myFigure.lineTo(points[1]._x, points[1]._y);
    myFigure.lineTo(points[2]._x, points[2]._y);
    myFigure.lineTo(points[3]._x, points[3]._y);
    myFigure.lineTo(points[4]._x, points[4]._y);
    myFigure.lineTo(points[5]._x, points[5]._y);
    myFigure.lineTo(points[0]._x, points[0]._y);
    myFigure.fill();
}


function drawTrail(pointsM) {
    drawHexagon(pointsM, "rgba(255, 255, 255, 1)");
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
        useTrail = false;
        //useTrail = true;
        animation();
    }
}

function animation() {
    var currentX = x;
    var currentY = y;

    x += 1500;
    y += 500;

    for (var i = 0; i < 6; i++) {
	pointsS[i]._x = (pointsE[i]._x - pointsB[i]._x) / 500;
	pointsS[i]._y = (pointsE[i]._y - pointsB[i]._y) / 500;
    }

    var stepX = (x - currentX) / 500;
    var stepY = (y - currentY) / 500;

    var k = 0;

    function moveToPoint() {
        if (pointsM[0]._x <= pointsE[0]._x) {
            currentX += stepX;
            currentY += stepY;
            myFigure.clearRect(0, 0, myFigure.canvas.width, myFigure.canvas.height);

	    if (k == 100) {
            	//trails.concat(pointsM);
		/*for (var i=0; i < 6; i++) {
		    trails.push( pointsM[i] );
		}*/
		trails.push.apply( trails, pointsM );
		k = 0;
	    }

            if (useTrail) {
                trails.forEach(function(element) {
                    drawTrail(element);
                }, this);
            }

	    for (var i = 0; i < 6; i++) {
		pointsM[i]._x += pointsS[i]._x;
		pointsM[i]._y += pointsS[i]._y;
	    }
            draw(pointsM);

            if (animate) {
                window.requestAnimationFrame(moveToPoint);
            }
        }
        else {
            trails.push(pointsM);
            document.getElementById("startButton").textContent = "Начать анимацию";
            clearTimeout(animate);
            animate = null;
        }
    }

    moveToPoint();
}
