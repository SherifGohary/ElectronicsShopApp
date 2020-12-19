import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/Shared/Services/base.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { GenericResult } from 'src/app/Shared/Models/generic-result.model';
import { Category } from '../Models/category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService extends BaseService{

  private controller: string = `${this.backendServerUrl}Category`;

  constructor(
    http: HttpClient
  ) {
    super(http);
   }


  getAllCategories(pageIndex: number = null, pageSize: number = null): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-by-pagger/${pageIndex}/${pageSize}`;
    return this.getAllData<GenericResult<any>>(url);
  }

  getCategory(id: any): Observable<Category> {
    let url: string = `${this.controller}/get/${id}`;
    return this.getData<Category>(url);
  }

  addCategory(item: Category): Observable<Category> {
    let url: string = `${this.controller}/add`;
    return this.postData(url, item);
  }

  updateCategory(item: Category): Observable<Category> {
    let url: string = `${this.controller}/update`;
    return this.postData(url, item);
  }

  deleteCategory(id: number): Observable<Category> {
    let url: string = `${this.controller}/delete/${id}`;
    return this.deleteData(url);
  }
}
