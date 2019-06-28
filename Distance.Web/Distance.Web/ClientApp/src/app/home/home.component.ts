import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  _http: HttpClient;
  distancia: Distancia;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
   this._http = http;
  }

  buscarAmigos(nome, longitude, latitude)
  {
    let headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': 'Basic dGVzdGU6MTIzNA=='
    });
    let options = { headers: headers };

    let postData = {
      longitude: longitude,
      latitude: latitude,
      nome: nome
    }
  
     this._http.post<Distancia>('https://localhost:44342/api/distancia/BuscaDistancias', JSON.stringify(postData),
      {
        headers: headers
      }).subscribe(result => {

        this.distancia = result;

      }, error => console.error(error));

  }
}


interface Distancia {
  Nome: string;
  Latitude: number;
  Longitude: number;
  calculoHistoricoLogs: calculoHistoricoLogs[]
}


interface calculoHistoricoLogs {
  nomeAmigo: string;
  longitudeDestino: number;
  latitudeDestino: number;
}


