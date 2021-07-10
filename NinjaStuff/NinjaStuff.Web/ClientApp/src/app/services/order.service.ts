import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private _baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;

  }


  get(): Observable<any> {
    return this.http.get(this._baseUrl + "api/order");
  }


  post(customer: any): Observable<any> {
    return this.http.post(this._baseUrl + "api/order", customer, {});
  }

}
