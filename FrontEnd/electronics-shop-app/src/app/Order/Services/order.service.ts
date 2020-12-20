import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/Shared/Services/base.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { GenericResult } from 'src/app/Shared/Models/generic-result.model';
import { Order } from '../Models/order';

@Injectable({
  providedIn: 'root'
})
export class OrderService extends BaseService{

  private controller: string = `${this.backendServerUrl}Order`;

  constructor(
    http: HttpClient
  ) {
    super(http);
   }


  getAllOrders(pageIndex: number = null, pageSize: number = null): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-by-pagger/${pageIndex}/${pageSize}`;
    return this.getAllData<GenericResult<any>>(url);
  }

  getOrder(id: any): Observable<Order> {
    let url: string = `${this.controller}/get/${id}`;
    return this.getData<Order>(url);
  }

  addOrder(item: Order): Observable<Order> {
    let url: string = `${this.controller}/add`;
    return this.postData(url, item);
  }

  updateOrder(item: Order): Observable<Order> {
    let url: string = `${this.controller}/update`;
    return this.postData(url, item);
  }

  deleteOrder(id: number): Observable<Order> {
    let url: string = `${this.controller}/delete/${id}`;
    return this.deleteData(url);
  }
}
