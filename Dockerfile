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
RUN dotnet test -c Release --no-build --logger trx --results-directory /var/temp/test-results


FROM build as pack
WORKDIR /src/Cortlex.Rescope
RUN dotnet pack -c Release --no-build -o /var/temp/pack/Cortlex.Rescope

WORKDIR /src/Cortlex.Rescope.Autofac
RUN dotnet pack -c Release --no-build -o /var/temp/pack/Cortlex.Rescope.Autofac

WORKDIR /src/Cortlex.Rescope.CastleWindsor
RUN dotnet pack -c Release --no-build -o /var/temp/pack/Cortlex.Rescope.CastleWindsor

WORKDIR /src/Cortlex.Rescope.NETCore
RUN dotnet pack -c Release --no-build -o /var/temp/pack/Cortlex.Rescope.NETCore