'use strict';
function test(s) {
    var arr = s.split(",");
    return arr.reduce(
        function (x, y) {
            return x * 10 + y;
        }
    );
}
var test1 = test("12345");

// console.log(test1.inc());

// console.log(test1.inc());


function count_test(initial) {
    var x = initial || 0;
    return {
        inc: function () {
            x += 1;
            return x;
        }
    }
}

function fib(max) {
    var t,
        a = 0,
        b = 1,
        arr = [0, 1];
    while (arr.length < max) {
        [a, b] = [b, a + b];
        arr.push(b);
    }
    return arr;
}


var tt = (function (i) {
    for (var j = 1; j <= i; j++) {
        setTimeout(function () { console.log(j) });
        console.log(j);
    }
}
)(100)


