#!/bin/bash
cd Cortlex.Rescope 
dotnet pack -c Release --no-build -o /var/temp/pack/Cortlex.Rescope
cd..