#!/bin/bash
cd ..
cd /src/Cortlex.Rescope 
dotnet pack -c Release --no-build -o /var/temp/pack/Cortlex.Rescope /p:Version=
cd ..

cd /src/Cortlex.Rescope.Autofac
dotnet pack -c Release --no-build -o /var/temp/pack/Cortlex.Rescope.Autofac /p:Version=
cd ..

cd /src/Cortlex.Rescope.CastleWindsor
dotnet pack -c Release --no-build -o /var/temp/pack/Cortlex.Rescope.CastleWindsor /p:Version=
cd ..

cd /src/Cortlex.Rescope.NETCore
dotnet pack -c Release --no-build -o /var/temp/pack/Cortlex.Rescope.NETCore /p:Version=
cd ..