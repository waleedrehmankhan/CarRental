import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  apiBaseUrl: String
  constructor(private http: HttpClient

    ,
    @Inject("API_BASE_URL") apiBaseUrl: String



  ) {
    this.apiBaseUrl = apiBaseUrl;
  }

  getData(): Observable<any> {

    return this.http.get("https://jsonplaceholder.typicode.com/posts");
  }

  postData(url: string, body: any): Observable<any> {
    debugger;
    //let headers = new HttpHeaders({
    //  'Content-Type': 'application/json;charset=UTF-8'
    //});
    //let options = { headers: headers };

    return this.http.post<any>(this.apiBaseUrl + url, body);
  }


   

}
