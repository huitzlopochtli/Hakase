var img;
var w = 995, h = 605, tow, toh;
var x, y, tox, toy;
var zoom = .01; //zoom step per mouse tick 
var imgX = 0, imgY = 0;
var mode;
var buttonX = 270;
var buttonY = 625;
var keys = { 37: 1, 38: 1, 39: 1, 40: 1 };
var urlParams = new URLSearchParams(window.location.search);


// Different Modes
var MODES = {
    PANnZOOM: { value: 0, name: "PNZ", code: "P" },
    Wallpaper: { value: 1, name: "WP", code: "W" },
    Floor: { value: 2, name: "FL", code: "F" }
};

function preload() {
    console.log(urlParams.get('imgUrl').replace(/\\/g, "/"));
    img = loadImage(urlParams.get('imgUrl').replace(/\\/g, "/"));
}

function setup() {
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
    if (mode === MODES.PANnZOOM && mouseX >= 0 && mouseX <= 995 && mouseY >= 0 && mouseY <= 605) {
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
    rect(0, 610, 1366, 95);
    pop();

    // Side bar
    push();
    fill('#8C8D90');
    rect(1000, 0, 1366, 605);
    pop();


    //Button 

    //Button(buttonX, buttonY, "Angle");
    Button(buttonX + 80, buttonY, "Remove Object");
    Button(buttonX + 160, buttonY, "Wallpaper");
    Button(buttonX + 240, buttonY, "Floor");
    Button(buttonX + 320, buttonY, "Angle");
    Button(buttonX + 400, buttonY, "Apply");

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

function mousePressed() {
    // Check mouse Pressed
    // Button Pressed 1st
    if (mouseX >= buttonX &&
        mouseX <= buttonX + 70 &&
        mouseY >= buttonY &&
        mouseY <= buttonY + 70) {
        mode = MODES.PANnZOOM;
        disableScroll();
    }

    if (mouseX >= buttonX &&
        mouseX <= buttonX + 70 &&
        mouseY >= buttonY &&
        mouseY <= buttonY + 70) {

        console.log("Wallpaper Clicked!");
    }
}


//function mouseDragged() {
//    tox += mouseX - pmouseX;
//    toy += mouseY - pmouseY;
//}
//function mouseWheel(event) {

//    if (mouseX >= 0 &&
//        mouseX <= w &&
//        mouseY >= 0 &&
//        mouseY <= h) {


//        var e = -event.delta;

//        if (e > 0) { //zoom in
//            for (var i = 0; i < e; i++) {
//                if (tow > 30 * 995) return; //max zoom
//                tox -= zoom * (mouseX - tox);
//                toy -= zoom * (mouseY - toy);
//                tow *= zoom + 1;
//                toh *= zoom + 1;
//            }
//        }

//        if (e < 0) { //zoom out
//            for (var i = 0; i < -e; i++) {
//                if (tow < 995) return; //min zoom
//                tox += zoom / (zoom + 1) * (mouseX - tox);
//                toy += zoom / (zoom + 1) * (mouseY - toy);
//                toh /= zoom + 1;
//                tow /= zoom + 1;
//            }
//        }
//    }

//}


//// Disable Scroll
//function preventDefault(e) {
//    e = e || window.event;
//    if (e.preventDefault)
//        e.preventDefault();
//    e.returnValue = false;
//}
//function preventDefaultForScrollKeys(e) {
//    if (keys[e.keyCode]) {
//        preventDefault(e);
//        return false;
//    }
//}
//function disableScroll() {
//    if (window.addEventListener) // older FF
//        window.addEventListener('DOMMouseScroll', preventDefault, false);
//    document.addEventListener('wheel', preventDefault, { passive: false }); // Disable scrolling in Chrome
//    window.onwheel = preventDefault; // modern standard
//    window.onmousewheel = document.onmousewheel = preventDefault; // older browsers, IE
//    window.ontouchmove = preventDefault; // mobile
//    document.onkeydown = preventDefaultForScrollKeys;
//}