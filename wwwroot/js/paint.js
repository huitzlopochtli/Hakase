var imgOrg, img, imgRender;
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







// Different Modes
var MODES = {
    RmvMark: { value: 0, name: "RM", code: "RM" },
    Wallpaper: { value: 1, name: "WP", code: "W" },
    Floor: { value: 2, name: "FL", code: "F" },
    RmvObj: { value: 3, name: "RO", code: "R" },
    Apply: { value: 4, name: "APL", code: "APL" }
};

function preload() {
    console.log(urlParams.get('imgUrl').replace(/\\/g, "/"));
    //img = loadImage(urlParams.get('imgUrl').replace(/\\/g, "/"));
    //img.resize(w, h);
    imgOrg = loadImage(urlParams.get('imgUrl'));
    img = loadImage(urlParams.get('imgUrl'), img => {
        img.resize(w, h);
        imgRender = img;
    });
}

function setup() {
    img.loadPixels();
    imgRender.loadPixels();

    var canvas = createCanvas(1366, 705);
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


    //tween/smooth motion
    //if (mode === MODES.PANnZOOM && mouseX >= 0 && mouseX <= 995 && mouseY >= 0 && mouseY <= 605) {
    //    x = lerp(x, tox, .1);
    //    y = lerp(y, toy, .1);
    //    w = lerp(w, tow, .1);
    //    h = lerp(h, toh, .1);
    //    imgX = x - w / 2;
    //    imgY = y - h / 2;
    //}

    image(img, imgX, imgY, w, h);

    // -- background END --




    // Nav
    push();
    fill('#8C8D90');
    rect(0, 610, 1366, 95);
    pop();

    // Side bar
    push();
    fill('#8C8D90');
    rect(1000, 0, 366, 605);

    // Wallpaper Selection
    if (mode === MODES.Wallpaper) {
        push();
        fill('#00000');
        // Number of walls
        rect(1178, 5, 183, 595);


        rect(1005, 5, 165, 595);

    }

    pop();


    //Button 

    //Button(buttonX, buttonY, "Angle");
    Button(buttonX + 80, buttonY, "X Object", MODES.RmvObj);
    Button(buttonX + 160, buttonY, "Wallpaper", MODES.Wallpaper);
    Button(buttonX + 240, buttonY, "Floor", MODES.Floor);
    Button(buttonX + 320, buttonY, "X Mark", MODES.RmvMark);
    Button(buttonX + 400, buttonY, "Apply", MODES.Apply);


    //Display Wallpaper Angles
    if (mode === MODES.Wallpaper)
        for (var i = 0; i < wallPapers.length; i++) {
            wallPapers[i].display();
        }

    // Remove Object
    if (mode === MODES.RmvObj) {

        if (mouseIsPressed && mouseX >= 0 && mouseY >= 0 && mouseX <= 995 && mouseY <= 665) {

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
            noStroke();
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
            noStroke();
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
            noStroke();
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
            noStroke();
            noFill(); //change this to noFill later
            overBox4 = false;
        }
        ellipse(this.bx4, this.by4, diameter, diameter);

        pop();
    };

    this.mouseDragged = function () {
        if (mouseX >= 2 &&
            mouseX <= 993 &&
            mouseY >= 3 &&
            mouseY <= 603) {

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
    }
}


function mouseDragged() {
    for (var i = 0; i < wallPapers.length; i++) {
        wallPapers[i].mouseDragged();
    }
}

function mouseReleased() {
    for (var i = 0; i < wallPapers.length; i++) {
        wallPapers[i].mouseReleased();
    }
}


function mousePressed() {
    // Check mouse Pressed




    // Wallpaper button
    for (var i = 0; i < wallPapers.length; i++) {
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
        wallPapers.push(new Angle(50, 50, 400, 400, 0, ""));
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
    }


}

