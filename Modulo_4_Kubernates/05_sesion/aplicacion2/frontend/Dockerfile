FROM node:22 as build
WORKDIR /app
COPY package*.json ./
RUN npm ci
COPY . . 
RUN npm run build -- --output-path=dist

FROM nginx:alpine
COPY --from=build /app/dist /usr/share/nginx/html

