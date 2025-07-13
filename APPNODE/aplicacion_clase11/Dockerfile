# Esta es la base o el runtime donde mi app se va a ejecutar
FROM node:22
# Establecer el directorio de trabajo dentro de la imagen
WORKDIR /usr/src/app
# Copiar el archivo de definición de dependencias
COPY package*.json ./
# Instalar las dependencias
RUN npm install
# Copiar la solución
COPY . .
# Exponer un puerto
EXPOSE 3001
# Comando que inicie la aplicación
CMD ["node", "app.js"]