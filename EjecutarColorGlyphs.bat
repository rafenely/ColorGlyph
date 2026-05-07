@echo off
echo Actualizando el programa desde la nube...
git pull
echo.
echo Compilando y levantando el servidor...
echo El programa se abrira automaticamente en el navegador.
echo No cierres esta ventana hasta terminar de usarlo.
echo.
dotnet watch
pause