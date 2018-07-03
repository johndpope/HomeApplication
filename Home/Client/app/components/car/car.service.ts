import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';

import { Car } from './car';

@Injectable()
export class CarService {
    private _carUrl = './api/car';

    constructor(private _http: HttpClient) { }

    getCars(): Observable<Car[]> {
        return this._http.get<Car[]>(this._carUrl)
            .do(data => console.log('All: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }

    getCar(id: number): Observable<Car> {
        let params = new HttpParams()
            .set('id', String(id));
        let requestOptions = { params: params };
        return this._http.get(this._carUrl, requestOptions)
            .do(data => console.log('All: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }

    private handleError(err: HttpErrorResponse) {
        console.log(err.message);
        return Observable.throw(err.message);
    }
}
