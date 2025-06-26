#!/bin/sh
envsubst < /etc/nginx/html/ng-microservices-demo-client/env.template.js > /etc/nginx/html/ng-microservices-demo-client/config/config.prod.json

exec nginx -g "daemon off;"
