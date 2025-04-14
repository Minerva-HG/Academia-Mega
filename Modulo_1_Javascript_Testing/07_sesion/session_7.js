console.log("Clase 07 Java Script Liderly")

try{
    let resultado = 10/1;
    console.log(resultado);
    throw new Error("Este es un error personalizado")
}catch(error){
    console.error("Se ha producido un error", error.message);            
}finally{
    console.log("Esté codigo se ejecuta siempre");                        
}

console.log("Este es un mensaje")
console.error("Esto es un error")
console.warn("Esta es una advertencia")