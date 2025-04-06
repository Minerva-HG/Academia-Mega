const MathModule = (function(){
    //variables privadas
    const PI =3.1416

    //funciones privadas
    function cuadrado (x){
        return x * x;
    }
    
    //funciones publicas
    return{
        areaCirculo(radio){
            return PI * cuadrado(radio);
        },
        suma(a, b){
            return a +b;
        }
    }

})();

console.log(MathModule.areaCirculo(2))
console.log(MathModule.suma(2,3))