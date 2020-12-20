import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/Shared/Services/base.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { GenericResult } from 'src/app/Shared/Models/generic-result.model';
import { User } from '../Models/user';
import { Login } from '../Models/login';

@Injectable({
  providedIn: 'root'
})
export class UserService extends BaseService{

  private controller: string = `${this.backendServerUrl}User`;

  constructor(
    http: HttpClient
  ) {
    super(http);
   }


  getAllUsers(pageIndex: number = null, pageSize: number = null): Observable<GenericResult<any>> {
    let url: string = `${this.controller}/get-by-pagger/${pageIndex}/${pageSize}`;
    return this.getAllData<GenericResult<any>>(url);
  }

  getUser(id: any): Observable<User> {
    let url: string = `${this.controller}/get/${id}`;
    return this.getData<User>(url);
  }

  login(credentials: Login): Observable<User> {
    let url: string = `${this.controller}/login`;
    return this.postData(url, credentials);
  }

  addUser(item: User): Observable<User> {
    let url: string = `${this.controller}/add`;
    return this.postData(url, item);
  }

  updateUser(item: User): Observable<User> {
    let url: string = `${this.controller}/update`;
    return this.postData(url, item);
  }

  deleteUser(id: number): Observable<User> {
    let url: string = `${this.controller}/delete/${id}`;
    return this.deleteData(url);
  }
}
