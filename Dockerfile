FROM microsoft/dotnet:2.1-sdk AS build

WORKDIR /

COPY Cortlex.Rescope.CI.sln /
COPY src/ /src
COPY tests/ /tests
COPY samples/ /samples

RUN dotnet restore Cortlex.Rescope.CI.sln
RUN dotnet build Cortlex.Rescope.CI.sln --no-restore -c Release


FROM build as test
WORKDIR /tests/Cortlex.Rescope.Tests


FROM build as pack
WORKDIR /src/Cortlex.Rescope