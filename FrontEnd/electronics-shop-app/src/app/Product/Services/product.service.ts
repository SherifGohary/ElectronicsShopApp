import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/Shared/Services/base.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { GenericResult } from 'src/app/Shared/Models/generic-result.model';
import { Product } from '../Models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService extends BaseService{

  private controller: string = `${this.backendServerUrl}Product`;

  constructor(
    http: HttpClient
  ) {
    super(http);
   }


  getAllProducts(pageIndex: number = null, pageSize: number = null): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-by-pagger/${pageIndex}/${pageSize}`;
    return this.getAllData<GenericResult<any>>(url);
  }

  getProduct(id: any): Observable<Product> {
    let url: string = `${this.controller}/get/${id}`;
    return this.getData<Product>(url);
  }

  addProduct(item: Product): Observable<Product> {
    let url: string = `${this.controller}/add`;
    return this.postData(url, item);
  }

  updateProduct(item: Product): Observable<Product> {
    let url: string = `${this.controller}/update`;
    return this.postData(url, item);
  }

  deleteProduct(id: number): Observable<Product> {
    let url: string = `${this.controller}/delete/${id}`;
    return this.deleteData(url);
  }
}
