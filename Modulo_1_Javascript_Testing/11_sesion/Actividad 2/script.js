document.getElementById("formularioNotas").addEventListener("submit", function(e){

    e.preventDefault();
    const nota1 = parseFloat( document.getElementById("nota1").value);
    const nota2 = parseFloat(document.getElementById("nota2").value);
    const nota3 = parseFloat(document.getElementById("nota3").value);
    
    console.log(nota1);
    console.log(nota2);
    console.log(nota3);


    const resultado = document.getElementById("resultado");

    //calcularPromedio(nota1 , nota2, nota3);

try{
        const promedio = calcularPromedio(nota1, nota2 , nota3);
        console.log(promedio);
        resultado.textContent = `El promedio es ${promedio}`;
        //resultado.style.color = "green"
        resultado.style.color = promedio >= 6 ? "green":"orange";

    }catch(error){
        console.log(error.message)
        resultado.textContent = error.message
        resultado.style.color = "red";
    }


} )

function calcularPromedio(n1,n2,n3){
    console.log("Calculando promedio...");
    console.log([n1,n2,n3].some(isNaN) );


    if ([n1,n2,n3].some(isNaN)){
        throw new Error ("Todas las notas deben de ser números")
    }

    if ( [n1,n2,n3].some( n=>n<0 || n>10 ) ){
        throw new Error("Las notas deben de estar entre 0 y 10");

    }

    return ( n1+n2+n3)/3;

}