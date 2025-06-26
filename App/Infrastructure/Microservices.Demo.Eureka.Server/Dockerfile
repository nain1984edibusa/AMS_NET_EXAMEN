FROM openjdk:21-slim-buster AS base
WORKDIR /app

FROM maven:3.9.9-eclipse-temurin-21 AS build
WORKDIR /build

COPY pom.xml ./
RUN mvn dependency:go-offline

FROM build AS publish
COPY src ./src
RUN mvn -f pom.xml clean package -DskipTests

FROM base AS final
WORKDIR /app
COPY --from=publish /build/target/*.jar ./app.jar
COPY opentelemetry-javaagent.jar ./opentelemetry-javaagent.jar
COPY elastic-apm-agent.jar ./elastic-apm-agent.jar

ENV ELASTIC_APM_SERVER_URL=http://apm-server:8200
ENV ELASTIC_APM_SERVICE_NAME=Eureka.Server
ENV ELASTIC_APM_ENVIRONMENT=production

ENTRYPOINT ["java", "-javaagent:elastic-apm-agent.jar", "-javaagent:opentelemetry-javaagent.jar", "-Dotel.exporter.otlp.endpoint=http://jaeger:4318", "-Dotel.service.name=Eureka.Server","-Dotel.environment=production","-jar", "/app/app.jar"]