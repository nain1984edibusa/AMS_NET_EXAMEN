#Observability and Monitoring
docker compose -f docker-compose-obs.yml up -d prometheus
docker compose -f docker-compose-obs.yml restart prometheus

docker compose -f docker-compose-obs.yml build
docker compose -f docker-compose-obs.yml up -d

# Databases
docker compose -f docker-compose-db.yml up -d sqlserver cloudbeaver
docker compose -f docker-compose-db.yml up -d elasticsearch elasticvue
docker compose -f docker-compose-db.yml up -d

# Infrastructures
docker compose -f docker-compose-infr.yml up -d eureka.server config.server gateway

docker compose -f docker-compose-infr.yml build
docker compose -f docker-compose-infr.yml up -d

docker compose -f docker-compose-infr.yml build gateway
docker compose -f docker-compose-infr.yml up -d gateway
docker compose -f docker-compose-infr.yml down gateway

# Applications
docker compose -f docker-compose-app.yml up -d products.service
docker compose -f docker-compose-app.yml build products.service

docker compose -f docker-compose-app.yml build policies.service
docker compose -f docker-compose-app.yml up -d policies.service

docker compose -f docker-compose-app.yml build policies.search.service
docker compose -f docker-compose-app.yml up -d policies.search.service

docker compose -f docker-compose-app.yml build
docker compose -f docker-compose-app.yml up -d


# Cludbeaver
# User: cbadmin
# Password: Password1234

# Elasticsearch
# User: elastic
# Password: elastic





docker compose -f docker-compose-db.yml up -d sqlserver postgres mysql postgres-idp cloudbeaver
docker compose -f docker-compose-infr.yml up -d eureka.server config.server gateway identity kafka kafka-ui
docker compose -f docker-compose-app.yml up -d products.service
docker compose -f docker-compose-app.yml up -d pricing.service
docker compose -f docker-compose-app.yml up -d policies.service



http://localhost:5176/manage/prometheus