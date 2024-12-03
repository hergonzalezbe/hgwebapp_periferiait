<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TopTracks.aspx.cs" Inherits="HGWebApp.TopTracks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Lista de canciones</title>	
	<style>
		body{
			font-family:Arial,sans-serif;
		}

		#dvheader {
    font-family: Arial, sans-serif;
    background: linear-gradient(120deg, #1db954, #191414);
    color: #fff;
    display: flex;
    flex-direction: column; 
    justify-content: center;
    align-items: center;
    height: 15vh;
    margin: 0;
}

h1, h2 {
    margin: 0; 
}

h1 {
    font-size: 2rem;
    color: #fff;
}

h2 {
    font-size: 1.5rem;
    color: #fff;
    margin-top: 10px; 
}

.track:hover{
	background-color:lightgray;
}
	</style>
</head>
<body>

    <script type="text/javascript">
		document.addEventListener("DOMContentLoaded", function () {			            
            for (var i = 0; i < data.tracks.length; i++){
                const newDiv = document.createElement('div');
				newDiv.id = 'dvTrack' + i;
				//if (i % 2 == 0) {
				//	newDiv.style.backgroundColor = 'lightgray';
				//}
				//else {
				//	newDiv.style.backgroundColor = 'white';
				//}
                
				newDiv.style.padding = '10px';
				newDiv.style.border = '1px solid black';
				newDiv.style.borderRadius = '5px';
				newDiv.style.margin = '10px';
				newDiv.className = 'track';

				const albumNameSpan = document.createElement('span');
				albumNameSpan.id = 'spAlbumName' + i;
				albumNameSpan.textContent = 'Album: '+data.tracks[i].album.name;
				albumNameSpan.style.display = 'block'; 
				albumNameSpan.style.fontWeight = 'bold'; 

				const image = document.createElement('img');
				image.id = 'img' + i;
				image.style.width = '20%';
				image.src = data.tracks[i].album.images[0].url;
				image.style.display = 'block';

				const releaseDateSpan = document.createElement('span');
				releaseDateSpan.id = 'spReleaseDate' + i;
				releaseDateSpan.textContent = 'Fecha: '+data.tracks[i].album.release_date;
				releaseDateSpan.style.display = 'block'; 
				releaseDateSpan.style.fontWeight = 'bold';
				releaseDateSpan.style.marginTop = '5px'; 

				const artistHeader = document.createElement('span');
				artistHeader.id = 'spArtistHeader' + i;
				artistHeader.textContent = 'Artista(s):';
				artistHeader.style.display= 'block';
				artistHeader.style.fontWeight = 'bold';

				// Agregar los spans al div
				newDiv.appendChild(albumNameSpan);
				newDiv.appendChild(image);
				newDiv.appendChild(releaseDateSpan);
				newDiv.appendChild(artistHeader);

				for (var j = 0; j < data.tracks[i].artists.length; j++) {
					const artistDiv = document.createElement('span');
					artistDiv.id = 'dvArtist' + i + j;
					artistDiv.textContent = ' - ' + data.tracks[i].artists[j].name;
					artistDiv.style.paddingLeft = '30px';
					artistDiv.style.display = 'block';
					artistDiv.style.marginTop = '5px';

					newDiv.appendChild(artistDiv);
				}

                document.getElementById('output').appendChild(newDiv);
		    }
            /*document.getElementById('output').innerText = data.tracks;*/
		});
	</script>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblResult" runat="server"></asp:Label>
        </div>
        <br />
		<div id="dvheader">
			<h1>Periferia IT</h1>
			<h2>Pruebas técnicas</h2>
		</div>
        <div id="output"></div>
    </form>    
</body>
</html>
