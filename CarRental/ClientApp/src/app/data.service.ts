import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  
  constructor(private http: HttpClient ) { }

  getData(): Observable<any> {

    return this.http.get("https://jsonplaceholder.typicode.com/posts");
  }

  postData(url: string,body:any): Observable<any> {
    return this.http.post<any>(url, body);
  }
}
