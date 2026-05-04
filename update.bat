@echo off
:: Cambia al directorio donde reside este script
cd /d "%~dp0"

echo Haciendo pull en: %cd%

:: Ejecuta el comando de git
git pull

:: Mantiene la ventana abierta para ver el resultado
pause