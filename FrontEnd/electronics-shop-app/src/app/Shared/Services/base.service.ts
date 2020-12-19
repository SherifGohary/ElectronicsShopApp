import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { tap, map, catchError } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class BaseService {

  protected backendServerUrl: string;

  protected options = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'language-code': 'en'
    })
};

  constructor(
    private _http: HttpClient,
  ) {
    this.backendServerUrl = "https://localhost:44382/api/"
   }


   private setOptions(forFile: boolean = false){
     
   }

   protected getAllData<T>(url: string): Observable<T> {
    let fullUrl: string = `${url}`;
    this.setOptions();
    return this._http.get(fullUrl, this.options)
        .pipe(
            tap(), 
            catchError(this.handleError<any>('getAll', []))
        );
}
protected getData<T>(url: string): Observable<T> {
    let fullUrl: string = `${url}`;
    this.setOptions();

    return this._http.get(fullUrl, this.options)
        .pipe(
            tap(),
            catchError(this.handleError<any>('get', []))
        );
}
protected postData<T>(url: string, item: any, headers?: any): Observable<T> {
    this.setOptions();
    if(headers != null) {
        this.options.headers.append(headers.name, headers.value);
    }
    return this._http.post(url, item, this.options)
        .pipe(
            tap(),
            catchError(this.handleError<any>('postData', []))
        );
}
protected postFileData<T>(url: string, item: any): Observable<T> {
this.setOptions(true);
return this._http.post(url, item, this.options)
    .pipe(
        tap(),
        catchError(this.handleError<any>('postData', []))
    );
}

protected putData<T>(url: string, item: any): Observable<T> {
    let fullUrl: string = `${url}`;
    this.setOptions();

    return this._http.put(fullUrl, item, this.options)
        .pipe(
            tap(),
            catchError(this.handleError<any>('putData', []))
        );
}
protected deleteData<T>(url: string): Observable<T> {
    let fullUrl: string = `${url}`;
    this.setOptions();

    return this._http.post(fullUrl, null, this.options)
        .pipe(
            tap(),
            catchError(this.handleError<any>('deleteData', []))
        );
}

private handleError<T>(operation = 'operation', result?: T) {
  return (error: any): Observable<T> => {
      if (error) {
          return of();
      }
      else if(error.status== 401)
      {
          console.error(JSON.stringify(error));
      }
      else {
          console.error(JSON.stringify(error));

          console.error(`${operation} failed: ${error.message}`);

          throw error;
      }
  };
}

}
