//closure
/*
function contador(){
    let cuenta = 0;
    return fuction (){
        cuenta ++;
        return cuenta;
    
    }
}

    const incrementar = contador ();
    console.log(incrementar);
    console.log(incrementar);
    console.log(incrementar);
    console.log(incrementar);
    console.log(incrementar);*/


    //ejercicio

function multiplicador (factor){
    return function(numero){
        return numero * factor;
    }
}

const duplicar = multiplicador(12);
const triplicar = multiplicador(3);

console.log(duplicar(5));
console.log(duplicar(5));


    //ejercicio 2


const valor = 1
function obtenerModulo() {
    let datos = [1,2,3,4,5,6,7,8,9,10,11]
    return datos.filter(item => item % valor === 0)
}

console.log(obtenerModulo());