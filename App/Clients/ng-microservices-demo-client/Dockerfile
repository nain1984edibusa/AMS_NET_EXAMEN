### STAGE 1: Build ###
FROM node:22.16.0-alpine AS build
RUN apk add --update python3 make g++\
    && rm -rf /var/cache/apk/*

WORKDIR /usr/src/app

    
COPY package.json package-lock.json ./
RUN npm install
COPY . .
RUN npm run build

### STAGE 2: Run ###
FROM nginx:1.17.1-alpine
COPY nginx.conf /etc/nginx/nginx.conf
COPY --from=build /usr/src/app/dist/ng-microservices-demo-client/browser /etc/nginx/html/ng-microservices-demo-client/

COPY entrypoint.sh /entrypoint.sh
RUN chmod +x entrypoint.sh

ENTRYPOINT ["/entrypoint.sh"]
