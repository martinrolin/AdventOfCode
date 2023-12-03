const { log } = require("console");
const fs = require('fs');
var data;
try {
    data = fs.readFileSync('..\\Input\\2023\\day03.txt', 'utf8')
} catch (err) {
    console.error(err)
}

const input = parseInput(data);
/*console.log(input);*/

function hasAdjSymbol1(xStart, xEnd, yStart, yEnd, length) {
    if (xStart < 0) xStart = 0;
    if (xEnd > input.length - 1) xEnd = input.length - 1;
    if (yStart < 0) yStart = 0;
    if (yEnd > input[0].length - 1) yEnd = input[0].length - 1;

    for (ii = xStart; ii <= xEnd; ii++) {
        for (jj = yStart; jj <= yEnd; jj++) {
            if (isNaN(input[ii][jj]) && input[ii][jj] != ".") {
                return 1;
            }
        }
    }
}

function hasAdjSymbol2(xStart, xEnd, yStart, yEnd, length, num) {
    if (xStart < 0) xStart = 0;
    if (xEnd > input.length - 1) xEnd = input.length - 1;
    if (yStart < 0) yStart = 0;
    if (yEnd > input[0].length - 1) yEnd = input[0].length - 1;

    for (ii = xStart; ii <= xEnd; ii++) {
        for (jj = yStart; jj <= yEnd; jj++) {
            if (isNaN(input[ii][jj]) && input[ii][jj] == "*") {
                if (map.get(`${ii}:${jj}`) == undefined) map.set(`${ii}:${jj}`, [num]);
                else map.set(`${ii}:${jj}`, [...map.get(`${ii}:${jj}`), num]);
            }
        }
    }
}


acc = 0;
for (i = 0; i < input.length; i++) {
    number = "";
    for (j = 0; j < input[i].length; j++) {
        c = input[i][j];
        if (!isNaN(c)) number += c;
        if ((isNaN(c) || j == input[i].length - 1) && number.length > 0) {
            n = parseInt(number);
            l = number.length;
            number = "";
            if (hasAdjSymbol1(i - 1, i + 1, j - l - 1, j, l)) {
                acc += n;
            }
        }
    }
}
console.log("Part 1 = " + acc);

map = new Map();



acc = 0;
for (i = 0; i < input.length; i++) {
    number = "";
    for (j = 0; j < input[i].length; j++) {
        c = input[i][j];
        if (!isNaN(c)) number += c;
        if ((isNaN(c) || j == input[i].length - 1) && number.length > 0) {
            n = parseInt(number);
            l = number.length;
            number = "";
            if (hasAdjSymbol2(i - 1, i + 1, j - l - 1, j, l, n)) {
                acc += n;
            }
        }
    }
}
map.forEach((element) => {
    if (element.length == 2) acc += element[0] * element[1];
});
console.log("Part 2 = " + acc);

function parseInput(input_string) {
    return input_string.split("\n").map((x) => {
        return x.trim().split("");
    });
}