import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';


@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[];
  public distancia: Distancia;
  //public distancia2;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string)
  {

    let headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': 'Basic dGVzdGU6MTIzNA=='
    });
    let options = { headers: headers };
    
    let postData = {
      longitude: 596,
      latitude: 596,
      nome: "Chris"
    }

    http.post<Distancia>('https://localhost:44342/api/distancia/BuscaDistancias', JSON.stringify(postData),
      {
        headers: headers
      }).subscribe(result => {

        this.distancia = result;
       // this.distancia = result;
       // alert("funiona" + JSON.stringify(result.calculoHistoricoLogs[0].nomeAmigo));
        //this.distancia.calculoHistoricoLogs[0].nomeAmigo);
        //this.distancia2 = JSON.parse(JSON.stringify(result));
        //alert(JSON.stringify(b["calculoHistoricoLogs"]));
        //alert(JSON.stringify(b["calculoHistoricoLogs"][0]));
        //alert(JSON.stringify(b["calculoHistoricoLogs"][0].nomeAmigo));
       // var c = JSON.parse(JSON.stringify(result.CalculoHistoricoLogs[0]));
        //var c = JSON.parse(JSON.stringify(result.CalculoHistoricoLogs[0]));
       // alert(JSON.stringify(c));
        //b = JSON.parse(a)
        //alert(JSON.stringify(result.CalculoHistoricoLogs["CalculoHistoricoLogs"]));
        //this.distancia.CalculoHistoricoLogs = result["CalculoHistoricoLogs"];
        //var teste = JSON.parse(result);
        //teste
        //alert(result["CalculoHistoricoLogs"]);
        //alert(JSON.stringify(result));
        ////this.distancia = result;
        //alert(result.CalculoHistoricoLogs[0].NomeAmigo);
        //this.distancia = JSON.parse(JSON.stringify(result));
       // alert(this.distancia.CalculoHistoricoLogs[0].NomeAmigo);
        //alert(result.CalculoHistoricoLog[0])
        //this.distancia = JSON.stringify(result);
       // alert(JSON.stringify(result);
    }, error => console.error(error));

    //this.httpClient.post("http://127.0.0.1:3000/customers",
    //  {
       
    //  }
    //    "name": "Customer004",
    //    "email": "customer004@email.com",
    //    "tel": "0000252525"
    //  })
    //  .subscribe(
    //    data => {
    //      console.log("POST Request is successful ", data);
    //    },
    //    error => {

    //      console.log("Error", error);


  }
}

interface WeatherForecast {
  dateFormatted: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
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
