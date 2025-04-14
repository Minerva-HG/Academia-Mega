const capitalizar = require("./capitalizar");

test("capitalizar HOLA => Hola", ()=> {
    expect(capitalizar("HOLA")).toBe("Hola");
})

test("capitalizar JAVASCRIPT => Javascript", ()=> {
    expect(capitalizar("JAVASCRIPT")).toBe("Javascript");
})