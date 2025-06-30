require('dotenv').config();
const express = require('express');
const mongoose = require('mongoose');
const cors = require('cors');

const app = express();
const port = process.env.PORT || 3000;

app.use(cors());
app.use(express.json());

mongoose.connect('mongodb://localhost:27017/myappdb', {
    useNewUrlParser: true,
    useUnifiedTopology: true
})
.then(() => console.log('Contando a MongoDB'))
.catch(err => console.error('error conetando a MongoDB', err));

const itemsRouter = require('./routes/items');
app.use('/api/items', itemsRouter);

app.listen(port, () => console.log(`API corriendo en http://localhost:${port}`));