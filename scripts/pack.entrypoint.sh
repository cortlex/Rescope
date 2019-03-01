#!/bin/bash
cd ..
cd /src/Cortlex.Rescope 
dotnet pack -c Release --no-build -o /var/temp/pack/Cortlex.Rescope /p:Version=$1
cd ..

cd /src/Cortlex.Rescope.Autofac
dotnet pack -c Release --no-build -o /var/temp/pack/Cortlex.Rescope.Autofac /p:Version=$1
cd ..

cd /src/Cortlex.Rescope.CastleWindsor
dotnet pack -c Release --no-build -o /var/temp/pack/Cortlex.Rescope.CastleWindsor /p:Version=$1
cd ..

cd /src/Cortlex.Rescope.NETCore
dotnet pack -c Release --no-build -o /var/temp/pack/Cortlex.Rescope.NETCore /p:Version=$1
cd ..