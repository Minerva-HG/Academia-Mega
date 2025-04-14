document.getElementById("searchForm").addEventListener("submit", function(event) {
    event.preventDefault();
    let artist = document.getElementById("artista").value;
    if (artist.trim() !== "") {
        let searchUrl = "https://www.google.com/search?q=" + encodeURIComponent(artist);
        window.open(searchUrl, "_blank");
    } else {
        alert("Por favor, ingresa un nombre de artista.");
    }
});

document.querySelectorAll(".artist-img").forEach(img => {
    img.addEventListener("click", function() {
        alert("Has hecho clic en la imagen de " + this.alt);
    });
    
    img.addEventListener("mouseover", function() {
        this.style.animation = "moveImage 1s infinite";
    });
    
    img.addEventListener("mouseout", function() {
        this.style.animation = "none";
    });
});