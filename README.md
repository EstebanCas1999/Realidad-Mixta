# Proyecto de Realidad mixta

Este proyecto esta implementando con el kit de desarrollo Mixed Reality ToolKit 2 o por sus siglas en inglés MRTK2 desarrollado por Microsoft.

## Instalación

> ## Requisitos
>- Poseeer Windows 10 u 11.
>- Tener Unity instalado en la versión 2020.3.48f1
>- Tener Visual Studio en la version 2022.


Con el proyecto abierto en unity tenemos que configurar el apartado de Build Settings que se encuentra en File -> Build Settings  para poder instalar la aplicacion en nuestras gafas  Oculus Meta Quest 2.

Nota: El proyecto tomara algunos minutos en abrir, debido que necesita instalar todas las configuraciones que se agregaron para ejecutar el kit de desarrollo de Mixed Reality ToolKit 2.

![image](https://github.com/user-attachments/assets/6e3c548d-4c8b-428a-819d-8a29dead29a9)


Elegimos la plataforma Android y oprimimos el boton Switch Platform, una vez oprimido instalara todas las configuraciones necesarias para poder instalarlo en nuestras gafas Oculus Meta Quest 2, una vez haya terminado la instalacion  procedemos a conectar nuestras gafas a nuestro equipo (Importante: Oculus Meta Quest 2 debe tener habilitado el modo desarrollador para poder hacer instalaciones de apks) y en el apartado de Run Device seleccionamos nuestras gafas, seguidamente oprimimos el boton Build And Run, el cual nos abrira una ventana que nos pedira el nombre de la apk.

![image](https://github.com/user-attachments/assets/5172320e-0022-4952-9643-ef04992ea93a)

Con el nombre dado comenzara el proceso de instalación, terminado ese proceso la aplicacion se ejecutará en nuestras gafas.

![image](https://github.com/user-attachments/assets/c6db6548-4e5b-46b6-876c-fe33536a342b)

Para poder ejecutar nuestra aplicacion en unity tendremos que ir a nuestras carpetas Assets/Scenes y seleccionamos nuestra escena main dandole play

![image](https://github.com/user-attachments/assets/a3e060fb-20fa-4387-acc6-03fe05aa27b7)

Si necesita abordar más en la herramienta MRTK 2, microsoft ofrece un tutorial de primeros pasos para que pueda agregar sus propias escenas implementando realidad mixta
https://learn.microsoft.com/es-es/training/modules/learn-mrtk-tutorials/
