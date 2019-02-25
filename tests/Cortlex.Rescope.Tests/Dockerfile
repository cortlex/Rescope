FROM microsoft/dotnet:2.1-sdk AS build

COPY ./ ./app

WORKDIR /app/tests/Cortlex.Rescope.Tests

RUN dotnet restore