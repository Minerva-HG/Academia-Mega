document.getElementById("testForm").addEventListener("submit", function(e) {
    e.preventDefault(); //Evita el comportamiento por defecto del formulario
    
    const nombre = document.getElementById("nombre").value.trim();
    const edad = document.getElementById("edad").value.trim();
    const resultado = document.getElementById("resultado");
    console.log(nombre, edad);

    try{
        validarDatos(nombre , edad);        
        resultado.textContent = `Hola ${nombre} , tienes ${edad} años`;
        resultado.style.color = "green";
    }catch (error){
        console.log("Error" , error)
        resultado.textContent = error.message;
        resultado.style.color = "red";
    }
})

function hola(){
    console.log("Hola");
}

//Función para validar los datos 

function validarDatos(nombre , edad ){

    console.log("Validando datos ...")

    if ( !nombre  || !edad  ){
        throw new Error ("Por favor completa todos los campos");
    }
    
    if (edad <= 0 ){
        throw new Error ("La edad debe de ser un número válido");
    }

    if (  nombre.length > 30 ){
        throw new Error ("El nombre es demasiado largo");
    }

    console.log("Datos validados correctamente")

}