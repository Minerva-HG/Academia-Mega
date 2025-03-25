var int = 12345;
var string = "texto";
var boolean = true;

var nombre = "Minerva";
var apellido = 'Godinez';
var nombreCompleto =`${nombre} ${apellido}`;
var edad = 33;
var diminutivo = "Mine"

console.log(`Hola, soy ${nombreCompleto} y tengo ${edad} años `); //correcto
console.log("Hola, soy " + nombreCompleto + " y tengo " + edad + " años");
console.log("Hola, soy " + diminutivo + " y tengo " + edad + " años");
//comparacion
/*Mayor/menor que: a > b, a < b.
Mayor/menor o igual que: a >= b, a <= b.
Igual: a == b (ten en cuenta que el doble signo == significa comparación, 
mientras que un solo símbolo a = b significaría una asignación).
Distinto. En matemáticas la notación es ≠, 
pero en JavaScript se escribe como una asignación con un signo de exclamación delante: a != b.*/


var numero ="5";
var numeroTexto = 5;
console.error(numero == numeroTexto );//true
console.error(numero === numeroTexto );//False