// Simula una API que retorna los géneros y sus imágenes
async function obtenerGeneros() {
    return new Promise((resolve) => {
    setTimeout(() => {
        resolve([
            { nombre: "Rock",  imagen:  src="./imagenes/rock.jpg"},
            { nombre: "Pop", imagen: src="./imagenes/pop.jpg" },
            { nombre: "Jazz", imagen: src="./imagenes/jazz.jpg" },
            { nombre: "Heavy Metal", imagen: src="./imagenes/hm.jpg" },
            { nombre: "Synth-pop", imagen: src="./imagenes/Synth-pop.jpg" }
                ]);
        }, 1000); // Simula un retardo de red
     });
}

async function mostrarGeneros() {
    const lista = document.getElementById("listaGeneros");
    lista.innerHTML = "<p>Cargando géneros...</p>";

    try {
        const generos = await obtenerGeneros();
        lista.innerHTML = "";

        generos.forEach(genero => {
        const item = document.createElement("li");
        const img = document.createElement("img");
        const link = document.createElement("a");

        //link.href = `https://www.google.com/search?q=${encodeURIComponent(genero.nombre + ' music genre')}`;
        link.target = "_blank";
        link.textContent = genero.nombre;
        link.href = "pop.html"

        img.src = genero.imagen;
        img.link = genero.link;
       // img.alt = genero.nombre;
        img.style.width = "100px";
        img.style.margin = "10px";

        item.appendChild(link);
        item.appendChild(document.createElement("br"));
        item.appendChild(img);
        lista.appendChild(item);
        });
    } catch (error) {
        lista.innerHTML = "<p>Error al cargar los géneros.</p>";
        console.error("Error:", error);
}
}

