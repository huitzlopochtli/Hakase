var img;
var w = 995, h = 605, tow, toh;
var x, y, tox, toy;
var zoom = .01; //zoom step per mouse tick 
var imgX = 0, imgY = 0;
var mode;


// Different Modes
var MODES = {
    PANnZOOM: { value: 0, name: "PNZ", code: "S" },
    MEDIUM: { value: 1, name: "Medium", code: "M" },
    LARGE: { value: 2, name: "Large", code: "L" }
};

function preload() {
    img = loadImage("https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcQwH5Lx5XoR5ab2pJwnA1iYyg1MRnjc4jctSQM391IAUp0Pd-ve");
}

function setup() {
    var canvas = createCanvas(1366, 705);
    canvas.parent('paint');


    // -- background -- 

    push();
    fill(230);
    rect(0, 0, 995, 605, 5);
    pop();

    w = tow = 995;
    h = toh = 605;
    x = tox = w / 2;
    y = toy = h / 2;

}


function draw() {
    // -- background -- 

    push();
    fill(230);
    rect(0, 0, 1366, 705, 5);
    pop();

    push();
    fill(230);
    rect(0, 0, 995, 605, 5);
    pop();

    // Main body


    //tween/smooth motion
    if (mode === MODES.PANnZOOM) {
        x = lerp(x, tox, .1);
        y = lerp(y, toy, .1);
        w = lerp(w, tow, .1);
        h = lerp(h, toh, .1);
        imgX = x - w / 2;
        imgY = y - h / 2;
    }

    image(img, imgX, imgY, w, h);

    // -- background END --




    // Nav
    push();
    fill('#8C8D90');
    rect(0, 610, 1366, 95, 5);
    pop();

    // Side bar
    push();
    fill(86, 177, 222);
    rect(1000, 0, 1366, 605, 5);
    pop();


    //Button 
    var buttonX = 350;
    var buttonY = 620;
    Button(buttonX, buttonY, "Pan & Zoom");
    Button(buttonX + 80, buttonY, "Text");
    Button(buttonX + 160, buttonY, "Text");



}

function Button(x, y, textStr) {
    push();
    fill(86, 177, 222);
    rect(x, y, 70, 70, 5);
    fill(255);
    textAlign(CENTER);
    text(textStr, x + 35, y + 55);
    pop();
}

function mouseDragged() {
    tox += mouseX - pmouseX;
    toy += mouseY - pmouseY;
}

function mouseWheel(event) {
    var e = -event.delta;

    if (e > 0) { //zoom in
        for (var i = 0; i < e; i++) {
            if (tow > 30 * 995) return; //max zoom
            tox -= zoom * (mouseX - tox);
            toy -= zoom * (mouseY - toy);
            tow *= zoom + 1;
            toh *= zoom + 1;
        }
    }

    if (e < 0) { //zoom out
        for (var i = 0; i < -e; i++) {
            if (tow < 995) return; //min zoom
            tox += zoom / (zoom + 1) * (mouseX - tox);
            toy += zoom / (zoom + 1) * (mouseY - toy);
            toh /= zoom + 1;
            tow /= zoom + 1;
        }
    }

}