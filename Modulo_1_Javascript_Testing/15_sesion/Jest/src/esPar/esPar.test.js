const esPar = require("./esPar");

test("4 es par", ()=>{
    expect(esPar(4)).toBe(true);
});


test("5 no es par", ()=>{
    expect(esPar(5)).toBe(false);
});

//test("6 no es par", ()=>{
//    expect(esPar(6)).toBe(false);
//});