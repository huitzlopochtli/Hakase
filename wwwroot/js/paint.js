var canvas;


var imgOrg, img, imgRender, imgCopy;
var w = 995, h = 605, tow, toh;
var x, y, tox, toy;
var zoom = .01; //zoom step per mouse tick 
var imgX = 0, imgY = 0;
var mode;
var buttonX = 270;
var buttonY = 625;
var keys = { 37: 1, 38: 1, 39: 1, 40: 1 };
var urlParams = new URLSearchParams(window.location.search);

var wallPapers = [];
var wallPaperClicked;
var wallAngleClicked;
var wallPapersImages = [];

var currentPage;
var prevPage;
var nextPage;
var totalPage;
var press = 0;

var appliedClicked = 0;

var mouseClk = 0;


// Different Modes
var MODES = {
    RmvMark: { value: 0, name: "RM", code: "RM" },
    Wallpaper: { value: 1, name: "WP", code: "W" },
    Floor: { value: 2, name: "FL", code: "F" },
    RmvObj: { value: 3, name: "RO", code: "R" },
    Apply: { value: 4, name: "APL", code: "APL" }
};

function preload() {

    imgOrg = loadImage(urlParams.get('imgUrl'));
    img = loadImage(urlParams.get('imgUrl'), img => {
        img.resize(w, h);
    });
    imgRender = loadImage(urlParams.get('imgUrl'), img => {
        img.resize(w, h);
    });
    getImages();
}

function getImages(wallPaperNumber, floorNumber) {
    $.ajax({
        type: 'GET',
        url: '/materials/MaterialThumbnails?pageNumber=' + wallPaperNumber,
        dataType: 'json',
        success: function (data) {
            console.log(data);
            wallPapersImages = [];
            currentPage = data.pageNumber;
            prevPage = data.prevPage;
            nextPage = data.nextPage;
            totalPage = data.totalPage;

            for (let i = 0; i < data.data.length; i++) {
                wallPapersImages.push(
                    {
                        id: data.data[i].id,
                        thumbnail: loadImage(data.data[i].thumbnail),
                        fullImage: loadImage(data.data[i].image, img => {
                            img.resize(w, h);
                        })
                    });
            }
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function setup() {
    img.loadPixels();
    imgRender.loadPixels();

    canvas = createCanvas(1366, 705);
    canvas.parent('paint');
    noStroke();

    // -- background -- 

    push();
    fill(255);
    rect(0, 0, w, h, 5);
    pop();

    w = tow = 995;
    h = toh = 605;
    x = tox = w / 2;
    y = toy = h / 2;
}


function draw() {
    // -- background -- 

    push();
    fill(255);
    rect(0, 0, 1366, 705);
    pop();

    push();
    fill(255);
    rect(0, 0, 995, 605);
    pop();

    // Main body

    image(img, imgX, imgY, w, h);


    // Nav
    push();
    fill('#8C8D90');
    rect(0, 610, 995, 95, 5);
    pop();

    // Side bar
    push();
    fill('#8C8D90');
    rect(1000, 0, 366, 1366, 5);
    // Wallpaper Selection
    if (mode === MODES.Wallpaper) {
        push();
        fill('#00000');

        // Number of walls
        rect(1178, 5, 183, 595);
        for (let i = 0; i < wallPapersImages.length; i++) {
            new wallThumbnails(1200, 40 + 100 * i, wallPapersImages[i]).display();
        }

        new prevButton(1050, 610).display();
        new currentButton(1130, 610).display();
        new nextButton(1210, 610).display();

        // Number of angles
        rect(1005, 5, 165, 595);
        for (let i = 0; i < wallPapers.length; i++) {
            new angleButton(1010, i === 0 ? 12 : (6 + (60 * i)), wallPapers[i]).display();
        }

        new createNewAngle(1010, 540).display();
        new angleDelete(1090, 540).display();

    }

    if (mode === MODES.Apply) {
        new SaveP(1150, 600).display();
    }

    pop();


    //Button 

    //Button(buttonX, buttonY, "Angle");
    Button(buttonX + 80, buttonY, "Mark", MODES.RmvObj);
    Button(buttonX + 160, buttonY, "Wallpaper", MODES.Wallpaper);
    Button(buttonX + 240, buttonY, "Floor", MODES.Floor);
    Button(buttonX + 320, buttonY, "Remove", MODES.RmvMark);
    Button(buttonX + 400, buttonY, "Apply", MODES.Apply);


    //Display Wallpaper Angles
    if (mode === MODES.Wallpaper)
        for (var i = 0; i < wallPapers.length; i++) {
            if (wallAngleClicked === wallPapers[i])
                wallPapers[i].display();
        }

    // Remove Object
    if (mode === MODES.RmvObj) {

        if (mouseIsPressed && mouseX >= 0 && mouseY >= 0 && mouseX <= 995 && mouseY <= 605) {

            var upperLeft = { x: mouseX - 50, y: mouseY - 50 };
            var upperright = { x: mouseX + 50, y: mouseY - 50 };
            var lowerLeft = { x: mouseX - 50, y: mouseY + 50 };
            var lowerRight = { x: mouseX + 50, y: mouseY + 50 };

            var index = (mouseX + mouseY * w) * 4;

            var index1 = (upperLeft.x + upperLeft.y * w) * 4;
            var index2 = (upperright.x + upperright.y * w) * 4;
            var index3 = (lowerLeft.x + lowerLeft.y * w) * 4;
            var index4 = (lowerRight.x + lowerRight.y * w) * 4;

            console.log(
                imgRender.pixels[index],
                imgRender.pixels[index + 1],
                img.pixels[index + 2]
            );

            var diff = 5;
            var count = 0;


            for (let i = index1; i < index4; i += 4) {
                //i >= index1 + 995 * 4 * count && i <= index2 + 995 * 4 * count
                if (true) {
                    if (
                        img.pixels[i + 0] >= imgRender.pixels[index + 0] - diff &&
                        img.pixels[i + 0] <= imgRender.pixels[index + 0] + diff &&
                        img.pixels[i + 1] >= imgRender.pixels[index + 1] - diff &&
                        img.pixels[i + 1] <= imgRender.pixels[index + 1] + diff &&
                        img.pixels[i + 2] >= imgRender.pixels[index + 2] - diff &&
                        img.pixels[i + 2] <= imgRender.pixels[index + 2] + diff &&
                        img.pixels[i + 3] >= imgRender.pixels[index + 3] &&
                        img.pixels[i + 3] <= imgRender.pixels[index + 3]
                    ) {
                        img.pixels[i] = 0;
                        img.pixels[i + 1] = 0;
                        img.pixels[i + 2] = 0;
                        img.pixels[i + 3] = 255;
                    }
                }

                count++;
            }



            img.updatePixels();

        }
    }

    // Remove mark
    if (mode === MODES.RmvMark) {
        if (mouseX >= 0 && mouseX <= 995 && mouseY >= 0 && mouseY <= 605) {


            var radius = 10;

            fill(255, 255, 255);
            if (mouseIsPressed) {
                fill(0, 255, 0);

                var xCenter = mouseX;
                var yCenter = mouseY;
                var pp;
                for (let x = xCenter - radius; x <= xCenter; x++) {
                    for (let y = yCenter - radius; y <= yCenter; y++) {
                        // we don't have to take the square root, it's slow
                        if ((x - xCenter) * (x - xCenter) + (y - yCenter) * (y - yCenter) <= radius * radius) {
                            var xSym = xCenter - (x - xCenter);
                            var ySym = yCenter - (y - yCenter);
                            console.log(pixelsValue(x, y), pixelsValue(x, ySym), pixelsValue(xSym, y), pixelsValue(xSym, ySym));

                            pp = pixelsValue(x, y);
                            img.pixels[pp + 0] = imgRender.pixels[pp + 0];
                            img.pixels[pp + 1] = imgRender.pixels[pp + 1];
                            img.pixels[pp + 2] = imgRender.pixels[pp + 2];
                            img.pixels[pp + 3] = imgRender.pixels[pp + 3];

                            pp = pixelsValue(x, ySym);
                            img.pixels[pp + 0] = imgRender.pixels[pp + 0];
                            img.pixels[pp + 1] = imgRender.pixels[pp + 1];
                            img.pixels[pp + 2] = imgRender.pixels[pp + 2];
                            img.pixels[pp + 3] = imgRender.pixels[pp + 3];

                            pp = pixelsValue(xSym, y);
                            img.pixels[pp + 0] = imgRender.pixels[pp + 0];
                            img.pixels[pp + 1] = imgRender.pixels[pp + 1];
                            img.pixels[pp + 2] = imgRender.pixels[pp + 2];
                            img.pixels[pp + 3] = imgRender.pixels[pp + 3];

                            pp = pixelsValue(xSym, ySym);
                            img.pixels[pp + 0] = imgRender.pixels[pp + 0];
                            img.pixels[pp + 1] = imgRender.pixels[pp + 1];
                            img.pixels[pp + 2] = imgRender.pixels[pp + 2];
                            img.pixels[pp + 3] = imgRender.pixels[pp + 3];


                        }
                    }
                }

                img.updatePixels();
            }
            circle(mouseX, mouseY, radius * 2, radius * 2);
        }
    }


}

function Button(x, y, textStr, type) {
    push();
    fill(86, 177, 222);
    if (mode === MODES.RmvObj && type === MODES.RmvObj)
        fill(86, 177, 0);
    if (mode === MODES.Floor && type === MODES.Floor)
        fill(86, 177, 0);
    if (mode === MODES.RmvMark && type === MODES.RmvMark)
        fill(86, 177, 0);
    if (mode === MODES.Wallpaper && type === MODES.Wallpaper)
        fill(86, 177, 0);
    if (mode === MODES.Apply && type === MODES.Apply)
        fill(86, 177, 0);

    rect(x, y, 70, 70, 5);
    fill(255);
    textAlign(CENTER);
    text(textStr, x + 35, y + 55);
    pop();
}

function Angle(x, y, w, l, strokeVal, type) {

    this.bx1 = x;
    this.by1 = y;
    this.bx2 = x + w;
    this.by2 = y;
    this.bx3 = x + w;
    this.by3 = y + l;
    this.bx4 = x;
    this.by4 = y + l;



    var diameter = 15;
    var overBox1 = false;
    var overBox2 = false;
    var overBox3 = false;
    var overBox4 = false;
    var locked1 = false;
    var locked2 = false;
    var locked3 = false;
    var locked4 = false;
    var x1Offset = 0.0;
    var y1Offset = 0.0;
    var x2Offset = 0.0;
    var y2Offset = 0.0;
    var x3Offset = 0.0;
    var y3Offset = 0.0;
    var x4Offset = 0.0;
    var y4Offset = 0.0;


    this.type = type;
    this.strokeVal = strokeVal;

    this.display = function () {
        push();
        noStroke();
        //background(255);
        stroke('#ff0000');
        strokeWeight(3);
        noFill();
        quad(this.bx1, this.by1, this.bx2, this.by2, this.bx3, this.by3, this.bx4, this.by4);
        noFill();
        // Test if the cursor is over the box 
        if (mouseX > this.bx1 - diameter && mouseX < this.bx1 + diameter &&
            mouseY > this.by1 - diameter && mouseY < this.by1 + diameter) {
            overBox1 = true;
            if (!locked1) {
                stroke('#4C60AD');
                strokeWeight(5);
                noFill();
            }
        } else {
            stroke(0, 255, 0);
            strokeWeight(1);
            noFill(); //change this to noFill later
            overBox1 = false;
        }
        ellipse(this.bx1, this.by1, diameter, diameter);

        if (mouseX > this.bx2 - diameter && mouseX < this.bx2 + diameter &&
            mouseY > this.by2 - diameter && mouseY < this.by2 + diameter) {
            overBox2 = true;
            if (!locked2) {
                stroke('#4C60AD');
                strokeWeight(5);
                noFill();
            }
        } else {
            stroke(0, 255, 0);
            strokeWeight(1);
            noFill(); //change this to noFill later
            overBox2 = false;
        }
        ellipse(this.bx2, this.by2, diameter, diameter);

        if (mouseX > this.bx3 - diameter && mouseX < this.bx3 + diameter &&
            mouseY > this.by3 - diameter && mouseY < this.by3 + diameter) {
            overBox3 = true;
            if (!locked3) {
                stroke('#4C60AD');
                strokeWeight(5);
                noFill();
            }
        } else {
            stroke(0, 255, 0);
            strokeWeight(1);
            noFill(); //change this to noFill later
            overBox3 = false;
        }
        ellipse(this.bx3, this.by3, diameter, diameter);

        if (mouseX > this.bx4 - diameter && mouseX < this.bx4 + diameter &&
            mouseY > this.by4 - diameter && mouseY < this.by4 + diameter) {
            overBox4 = true;
            if (!locked4) {
                stroke('#4C60AD');
                strokeWeight(5);
                noFill();
            }
        } else {
            stroke(0, 255, 0);
            strokeWeight(1);
            noFill(); //change this to noFill later
            overBox4 = false;
        }
        ellipse(this.bx4, this.by4, diameter, diameter);

        pop();
    };

    this.mouseDragged = function () {
        if (mouseX >= 1 &&
            mouseX <= 994 &&
            mouseY >= 1 &&
            mouseY <= 604) {

            if (locked1) {
                noStroke();
                fill(230);
                this.bx1 = mouseX - x1Offset;
                this.by1 = mouseY - y1Offset;
            }

            if (locked2) {
                this.bx2 = mouseX - x2Offset;
                this.by2 = mouseY - y2Offset;
            }

            if (locked3) {
                this.bx3 = mouseX - x3Offset;
                this.by3 = mouseY - y3Offset;
            }

            if (locked4) {
                this.bx4 = mouseX - x4Offset;
                this.by4 = mouseY - y4Offset;
            }
        }
    };

    this.clicked = function () {
        if (overBox1) {
            locked1 = true;
            noStroke();
            noFill();
            x1Offset = mouseX - this.bx1;
            y1Offset = mouseY - this.by1;
        }
        if (!overBox1) {
            locked1 = false;
        }

        if (overBox2) {
            locked2 = true;
            x2Offset = mouseX - this.bx2;
            y2Offset = mouseY - this.by2;
        }
        if (!overBox2) {
            locked2 = false;
        }

        if (overBox3) {
            locked3 = true;
            x3Offset = mouseX - this.bx3;
            y3Offset = mouseY - this.by3;
        }
        if (!overBox3) {
            locked3 = false;
        }

        if (overBox4) {
            locked4 = true;
            x4Offset = mouseX - this.bx4;
            y4Offset = mouseY - this.by4;
        }
        if (!overBox4) {
            locked4 = false;
        }

    };

    this.mouseReleased = function () {
        locked1 = false;
        locked2 = false;
        locked3 = false;
        locked4 = false;
    };
}

// Check mouse Dragged
function mouseDragged() {
    for (var i = 0; i < wallPapers.length; i++) {
        wallPapers[i].mouseDragged();
    }
}
// Check mouse Released
function mouseReleased() {
    console.log("Called");
    mouseClk = 0;
    for (var i = 0; i < wallPapers.length; i++) {
        wallPapers[i].mouseReleased();
    }
}

// Check mouse Pressed
function mousePressed() {


    // Wallpaper angles clicked
    for (var i = 0; i < wallPapers.length; i++) {
        if (wallAngleClicked === wallPapers[i])
            wallPapers[i].clicked();
    }

    // Button Pressed 1st
    if (mouseX >= buttonX &&
        mouseX <= buttonX + 70 &&
        mouseY >= buttonY &&
        mouseY <= buttonY + 70) {
        mode = MODES.PANnZOOM;
    }

    // Remove Obj Button
    if (mouseX >= (buttonX + 80) &&
        mouseX <= (buttonX + 80) + 70 &&
        mouseY >= buttonY &&
        mouseY <= buttonY + 70) {
        mode = MODES.RmvObj;
        console.log("Remove Clicked");
    }

    if (mouseX >= (buttonX + 160) &&
        mouseX <= (buttonX + 160) + 70 &&
        mouseY >= buttonY &&
        mouseY <= buttonY + 70) {
        mode = MODES.Wallpaper;
        console.log("Wallpaper Clicked");

        //create Rectangle angle
        if (wallPapers.length === 0) {
            wallPapers.push(new Angle(50, 50, 400, 400, 0, null));
            wallAngleClicked = wallPapers[0];
        }
    }

    if (mouseX >= (buttonX + 240) &&
        mouseX <= (buttonX + 240) + 70 &&
        mouseY >= buttonY &&
        mouseY <= buttonY + 70) {
        mode = MODES.Floor;
        console.log("Floor Clicked");
    }

    if (mouseX >= (buttonX + 320) &&
        mouseX <= (buttonX + 320) + 70 &&
        mouseY >= buttonY &&
        mouseY <= buttonY + 70) {
        mode = MODES.RmvMark;
        console.log("Angle Clicked");
    }

    if (mouseX >= (buttonX + 400) &&
        mouseX <= (buttonX + 400) + 70 &&
        mouseY >= buttonY &&
        mouseY <= buttonY + 70) {
        mode = MODES.Apply;
        console.log("Apply Clicked");


        for (let i = 0; i < wallPapers.length; i++) {
            if (wallPapers[i].type) {
                wallPapers[i].type.fullImage.loadPixels();

                skewImage(wallPapers[i]);
            }
        }

    }

}

function pixelsValue(x, y) {
    return (x + y * w) * 4;
}

function wallThumbnails(x, y, img) {
    this.x = x;
    this.y = y;
    this.width = 100;
    this.height = 100;

    this.display = function () {
        push();
        fill(0, 255, 0);
        if (mouseIsPressed) {
            if (mouseX >= this.x &&
                mouseX <= this.x + this.width + 120 &&
                mouseY >= this.y &&
                mouseY <= this.y + this.height) {
                fill(255, 0, 0);
                wallPaperClicked = img.id;
                wallAngleClicked.type = img;
            }
        }
        if (wallPaperClicked === img.id)
            fill(255, 0, 0);
        rect(this.x + 15, this.y + 15, this.width - 10, this.height - 10, 5);
        image(img.thumbnail, this.x + 20, this.y + 20, this.width - 20, this.height - 20);
        pop();
    };
}

function angleButton(x, y, angle) {
    this.x = x;
    this.y = y;

    this.width = 50;
    this.height = 50;

    this.display = function () {
        push();
        fill(0, 255, 0);
        if (mouseIsPressed) {
            if (mouseX >= this.x &&
                mouseX <= this.x + this.width + 120 &&
                mouseY >= this.y &&
                mouseY <= this.y + this.height) {
                fill(255, 0, 0);
                wallAngleClicked = angle;
            }
        }
        if (wallAngleClicked === angle)
            fill(255, 0, 0);
        //角度
        rect(this.x - 1, this.y - 1, this.width + 105, this.height + 1, 5);
        if (angle.type) {
            image(angle.type.thumbnail, this.x, this.y, this.width + 103, this.height - 2);
        }
        fill(0);
        textSize(32);
        textAlign(CENTER);
        text('角度:' + (wallPapers.indexOf(angle) + 1), this.x + 75, this.y + 33);

        pop();
    };
}

function createNewAngle(x, y) {
    this.x = x;
    this.y = y;
    this.width = 75;
    this.height = 50;

    this.display = function () {
        push();
        fill(0, 255, 0);
        if (mouseIsPressed &&
            mouseX >= this.x &&
            mouseX <= this.x + this.width &&
            mouseY >= this.y &&
            mouseY <= this.y + this.height
        ) {
            var ang = new Angle(50, 50, 400, 400, 0, null);
            if (!isAngleAvailable(ang)) {
                wallPapers.push(ang);
                wallAngleClicked = ang;
            }
            fill(255, 0, 0);
        }

        rect(this.x, this.y, this.width, this.height, 5);
        fill(0);
        textSize(14);
        textAlign(CENTER);
        text('新しい角度', this.x + this.width / 2, this.y + this.height / 2);
        pop();
    };
}

function isAngleAvailable(ang) {
    for (let i = 0; i < wallPapers.length; i++) {
        if (
            wallPapers[i].bx1 === ang.bx1 &&
            wallPapers[i].by1 === ang.by1 &&
            wallPapers[i].bx2 === ang.bx2 &&
            wallPapers[i].by2 === ang.by2 &&
            wallPapers[i].bx3 === ang.bx3 &&
            wallPapers[i].by3 === ang.by3 &&
            wallPapers[i].bx4 === ang.bx4 &&
            wallPapers[i].by4 === ang.by4
        )
            return true;
    }
    return false;
}

function angleDelete(x, y) {
    this.x = x;
    this.y = y;
    this.width = 70;
    this.height = 50;

    this.display = function () {
        push();
        fill(0, 255, 0);
        if (mouseIsPressed &&
            mouseX >= this.x &&
            mouseX <= this.x + this.width &&
            mouseY >= this.y &&
            mouseY <= this.y + this.height
        ) {
            if (wallPapers.length !== 0 && wallPapers[0] !== wallAngleClicked) {
                wallPapers = wallPapers.slice(wallPapers.indexOf(wallAngleClicked), 1);
                wallAngleClicked = wallPapers[0];
            }
        }

        rect(this.x, this.y, this.width, this.height, 5);
        fill(0);
        textSize(14);
        textAlign(CENTER);
        text('削除する', this.x + this.width / 2, this.y + this.height / 2);
        pop();
    };
}

function nextButton(x, y) {
    this.x = x;
    this.y = y;
    this.width = 70;
    this.height = 50;

    this.display = function () {
        push();
        fill(0, 255, 0);
        if (mouseIsPressed &&
            mouseX >= this.x &&
            mouseX <= this.x + this.width &&
            mouseY >= this.y &&
            mouseY <= this.y + this.height
        ) {
            fill(255, 0, 0);
            if (nextPage <= totalPage && press === 0)
                getImages(nextPage, null);
            press = press === 0 ? 1 : 0;
        }

        rect(this.x, this.y, this.width, this.height, 5);
        fill(0);
        textSize(14);
        textAlign(CENTER);
        text('>>' + nextPage, this.x + this.width / 2, this.y + this.height / 2);
        pop();
    };
}

function prevButton(x, y) {
    this.x = x;
    this.y = y;
    this.width = 70;
    this.height = 50;

    this.display = function () {
        push();
        fill(0, 255, 0);
        if (mouseIsPressed &&
            mouseX >= this.x &&
            mouseX <= this.x + this.width &&
            mouseY >= this.y &&
            mouseY <= this.y + this.height
        ) {
            if (prevPage > 0)
                getImages(prevPage, null);
        }

        rect(this.x, this.y, this.width, this.height, 5);
        fill(0);
        textSize(14);
        textAlign(CENTER);
        text(prevPage + '<<', this.x + this.width / 2, this.y + this.height / 2);
        pop();
    };
}

function currentButton(x, y) {
    this.x = x;
    this.y = y;
    this.width = 70;
    this.height = 50;

    this.display = function () {
        push();
        fill(0, 255, 0);
        if (mouseIsPressed &&
            mouseX >= this.x &&
            mouseX <= this.x + this.width &&
            mouseY >= this.y &&
            mouseY <= this.y + this.height
        ) {
            ;
        }

        rect(this.x, this.y, this.width, this.height, 5);
        fill(0);
        textSize(14);
        textAlign(CENTER);
        text('..' + currentPage + '..', this.x + this.width / 2, this.y + this.height / 2);
        pop();
    };
}

function skewImage(w) {
    var skImg = w.type.fullImage;
    var first = { x: w.bx1, y: w.by1 };
    var second = { x: w.bx2, y: w.by2 };
    var third = { x: w.bx3, y: w.by3 };
    var forth = { x: w.bx4, y: w.by4 };

    var dist1 = first.y - 0;
    var dist2 = 605 - second.y;
    var dist3 = 605 - third.y;
    var dist4 = forth.y - 605;
    var deg = 0;

    w.type.fullImage.loadPixels();

    //revert(imgCopy, img);

    for (let i = 0; i < img.pixels.length; i += 4) {
        if (
            img.pixels[i + 0] === 0 &&
            img.pixels[i + 1] === 0 &&
            img.pixels[i + 2] === 0 &&
            img.pixels[i + 3] === 255
        ) {
            img.pixels[i + 0] = w.type.fullImage.pixels[i + 0];
            img.pixels[i + 1] = w.type.fullImage.pixels[i + 1];
            img.pixels[i + 2] = w.type.fullImage.pixels[i + 2];
            img.pixels[i + 3] = w.type.fullImage.pixels[i + 3];
        }
    }

    img.updatePixels();

}


function lengthSquare(X, Y) {
    var xDiff = X.x - Y.x;
    var yDiff = X.y - Y.y;
    return xDiff * xDiff + yDiff * yDiff;
}

function returnAngle(X, Y) {
    return Math.sqrt(lengthSquare(X, Y));
}

function revert(imgPrev, imgNow) {
    for (let i = 0; i < img.pixels.length; i += 4) {
        imgNow.pixels[i + 0] = imgPrev.pixels[i + 0];
        imgNow.pixels[i + 1] = imgPrev.pixels[i + 1];
        imgNow.pixels[i + 2] = imgPrev.pixels[i + 2];
        imgNow.pixels[i + 3] = imgPrev.pixels[i + 3];
    }
}

function SaveP(x, y) {
    this.x = x;
    this.y = y;
    this.width = 70;
    this.height = 50;

    this.display = function () {
        push();
        fill(0, 255, 0);
        if (mouseIsPressed &&
            mouseX >= this.x &&
            mouseX <= this.x + this.width &&
            mouseY >= this.y &&
            mouseY <= this.y + this.height
        ) {
            if (mouseClk === 0) {
                mouseClk = 1;
                fill(255, 0, 0);
                console.log("Saved");

                if (wallAngleClicked.type) {
                    var id = wallAngleClicked.type.id;
                    var saveCanvas = createGraphics(w, h);
                    var c = get(0, 0, w, h);
                    saveCanvas.image(c, 0, 0);
                    save(saveCanvas, "hakase", "png");

                    // ajax call to server will go here
                    saveFrames("hakase", "png", 1, 1, file => {
                        $.ajax({
                            type: 'GET',
                            data: file,
                            url: '/paint/UploadReform?id=' + id,
                            dataType: 'json',
                            success: function (data) {
                                
                            },
                            error: function (error) {
                                console.log(error);
                            }
                        });
                    });
                }
            }
        }

        rect(this.x, this.y, this.width, this.height, 5);
        fill(0);
        textSize(14);
        textAlign(CENTER);
        text('Save', this.x + this.width / 2, this.y + this.height / 2);
        pop();
    };
}