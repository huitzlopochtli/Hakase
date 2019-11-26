function Angle(x, y, w, l, strokeVal, type) {

    var bx1 = x;
    var by1 = y;
    var bx2 = x + w;
    var by2 = y;
    var bx3 = x + w;
    var by3 = y + l;
    var bx4 = x;
    var by4 = y + l;
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
        background(255);
        stroke(0);
        noFill();
        quad(bx1, by1, bx2, by2, bx3, by3, bx4, by4);
        noFill();
        // Test if the cursor is over the box 
        if (mouseX > bx1 - diameter && mouseX < bx1 + diameter &&
            mouseY > by1 - diameter && mouseY < by1 + diameter) {
            overBox1 = true;
            if (!locked1) {
                stroke('#4C60AD');
                strokeWeight(2);
                noFill();
            }
        } else {
            noStroke();
            noFill(); //change this to noFill later
            overBox1 = false;
        }
        ellipse(bx1, by1, diameter, diameter);

        if (mouseX > bx2 - diameter && mouseX < bx2 + diameter &&
            mouseY > by2 - diameter && mouseY < by2 + diameter) {
            overBox2 = true;
            if (!locked2) {
                stroke('#4C60AD');
                strokeWeight(2);
                noFill();
            }
        } else {
            noStroke();
            noFill(); //change this to noFill later
            overBox2 = false;
        }
        ellipse(bx2, by2, diameter, diameter);

        if (mouseX > bx3 - diameter && mouseX < bx3 + diameter &&
            mouseY > by3 - diameter && mouseY < by3 + diameter) {
            overBox3 = true;
            if (!locked3) {
                stroke('#4C60AD');
                strokeWeight(2);
                noFill();
            }
        } else {
            noStroke();
            noFill(); //change this to noFill later
            overBox3 = false;
        }
        ellipse(bx3, by3, diameter, diameter);

        if (mouseX > bx4 - diameter && mouseX < bx4 + diameter &&
            mouseY > by4 - diameter && mouseY < by4 + diameter) {
            overBox4 = true;
            if (!locked4) {
                stroke('#4C60AD');
                strokeWeight(2);
                noFill();
            }
        } else {
            noStroke();
            noFill(); //change this to noFill later
            overBox4 = false;
        }
        ellipse(bx4, by4, diameter, diameter);



        pop();
    };

    this.mouseDragged = function () {
        if (locked1) {
            noStroke();
            fill(230);
            bx1 = mouseX - x1Offset;
            by1 = mouseY - y1Offset;
        }

        if (locked2) {
            bx2 = mouseX - x2Offset;
            by2 = mouseY - y2Offset;
        }

        if (locked3) {
            bx3 = mouseX - x3Offset;
            by3 = mouseY - y3Offset;
        }

        if (locked4) {
            bx4 = mouseX - x4Offset;
            by4 = mouseY - y4Offset;
        }
    };

    this.clicked = function () {
        if (overBox1) {
            locked1 = true;
            noStroke();
            noFill();
            x1Offset = mouseX - bx1;
            y1Offset = mouseY - by1;
        }
        if (!overBox1) {
            locked1 = false;
        }

        if (overBox2) {
            locked2 = true;
            x2Offset = mouseX - bx2;
            y2Offset = mouseY - by2;
        }
        if (!overBox2) {
            locked2 = false;
        }

        if (overBox3) {
            locked3 = true;
            x3Offset = mouseX - bx3;
            y3Offset = mouseY - by3;
        }
        if (!overBox3) {
            locked3 = false;
        }

        if (overBox4) {
            locked4 = true;
            x4Offset = mouseX - bx4;
            y4Offset = mouseY - by4;
        }
        if (!overBox4) {
            locked4 = false;
        }

    };
}