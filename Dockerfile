FROM microsoft/dotnet:2.1-sdk AS build

WORKDIR /
COPY ./Cortlex.Rescope.CI.sln /

WORKDIR /src
COPY src/Cortlex.Rescope/Cortlex.Rescope.csproj Cortlex.Rescope/
COPY src/Cortlex.Rescope.Autofac/Cortlex.Rescope.Autofac.csproj Cortlex.Rescope.Autofac/
COPY src/Cortlex.Rescope.CastleWindsor/Cortlex.Rescope.CastleWindsor.csproj Cortlex.Rescope.CastleWindsor/
COPY src/Cortlex.Rescope.NETCore/Cortlex.Rescope.NETCore.csproj Cortlex.Rescope.NETCore/

WORKDIR /samples
COPY samples/AspNetCore.Web.Autofac.Default.Example/AspNetCore.Web.Autofac.Default.Example.csproj AspNetCore.Web.Autofac.Default.Example/
COPY samples/AspNetCore.Web.Autofac.Example/AspNetCore.Web.Autofac.Example.csproj AspNetCore.Web.Autofac.Example/
COPY samples/Cortlex.Rescope.CustomScope.Example/Cortlex.Rescope.CustomScope.Example.csproj Cortlex.Rescope.CustomScope.Example/
COPY samples/NETCore.GenericHost.Autofac.Example/NETCore.GenericHost.Autofac.Example.csproj NETCore.GenericHost.Autofac.Example/
COPY samples/NETCore.GenericHost.CoreDI.Example/NETCore.GenericHost.CoreDI.Example.csproj NETCore.GenericHost.CoreDI.Example/

WORKDIR /tests
COPY tests/Cortlex.Rescope.Tests/Cortlex.Rescope.Tests.csproj Cortlex.Rescope.Tests/

WORKDIR /
RUN dotnet restore

COPY src/ src/
COPY samples/ samples/
COPY tests/ tests/
RUN dotnet build --no-restore -c Release


FROM build as test
WORKDIR /tests/Cortlex.Rescope.Tests