import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiServiceService {
  private apiUrl:any = 'https://fakestoreapi.com/products'

  constructor(private http:HttpClient) {

  }

  getProduct(): Observable<any>{
    return this.http.get(this.apiUrl);
  }
}