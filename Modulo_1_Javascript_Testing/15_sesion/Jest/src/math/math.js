const suma = require("./suma");

test("suma 2+3 es igual a 5", ()=>{
    expect(suma(3,3)).toBe(5);
})