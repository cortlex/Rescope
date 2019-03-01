#!/bin/bash
cd ..
cd /src/Cortlex.Rescope 
dotnet pack -c Release --no-build -o /var/temp/pack/Cortlex.Rescope
cd ..

cd /src/Cortlex.Rescope.Autofac
dotnet pack -c Release --no-build -o /var/temp/pack/Cortlex.Rescope.Autofac
cd ..

cd /src/Cortlex.Rescope.CastleWindsor
dotnet pack -c Release --no-build -o /var/temp/pack/Cortlex.Rescope.CastleWindsor
cd ..

cd /src/Cortlex.Rescope.NETCore
dotnet pack -c Release --no-build -o /var/temp/pack/Cortlex.Rescope.NETCore
cd ..