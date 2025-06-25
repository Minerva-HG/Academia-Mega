const express = require('express');

const app = express();

const PORT = process.env.PORT || 3000;

app.get('/', (req, res) =>{
    res.send("¡¡¡Hola mundo desde Docker!!! \n Author: Minerva Hernandez Godinez");
});

app.listen(PORT, () =>{
    console.log(`Servidor de Node escuchando en el puerto ${PORT}`);
});