<h1>Pruebas técnicas de Hernan Gonzalez para Periferia IT</h1>
<h2>Consumo de la API de spotify</h2>
<br/>
1) Crear cuenta en spotify for developers.

Se creó con hergonzalebe@gmail.com (por medio de google)

IDE de desarrollo VS2019 framework 4.6.1<br/>
Nombre HGWebApp<br/>
client id : a3f4dc305e4e4fe9b0ecd373e6d992f2<br/>
client secret: dc41b15da4c24ee09c5958b4b1483d17<br/>
package Restsharp 112.1.0<br/>
package Newtonsoft.Json  13.0.3<br/>

2) Para asegurar los endpoints se crearon unos métodos en el archivo Global.asax para impedir que se usen otras rutas diferentes a Login o TopTracks.
3) ClientId, CientSecret y RedirectUri se están guardando en el web.config
4) El token que genera spotify se está guardando en la variable de sesión Session["token"]
5) En lugar de crear webmethods para la obtención de token y uso del endpoint, se está pasando el response en una variable a través de ScriptManager.RegisterStartupScript para que quede visible en el javascript.
6) El javascript crea elementos de manera dinámica (div, span, img), para que el código se pueda adaptar a listas de canciones y artistas de diferentes longitudes.
7) El css no está en archivos separados sino dentro de <style></style> en los archivos de la aplicación.   
