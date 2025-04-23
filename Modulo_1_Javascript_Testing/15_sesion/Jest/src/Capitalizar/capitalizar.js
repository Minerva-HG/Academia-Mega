function capitalizar(palabra){
    return palabra.charAt(0).toUpperCase() + palabra.slice(1).toLowerCase();
}

module.exports = capitalizar;