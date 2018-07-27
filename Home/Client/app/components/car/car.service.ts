import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';

import { Car } from './car';
import { Maintenance } from './maintenance';

@Injectable()
export class CarService {
    private _carUrl = './api/car';
    private _maintenanceUrl = './api/maintenance';

    constructor(private _http: HttpClient) { }

    getCars(): Observable<Car[]> {
        return this._http.get<Car[]>(this._carUrl)
            .do(data => console.log('All: ' + JSON.stringify(data)));
    }

    getCar(id: number): Observable<Car> {
        return this._http.get<Car>(this._carUrl + '/' + id.toString())
            .do(data => console.log('All: ' + JSON.stringify(data)));
    }

    getCarMaintenance(id: number): Observable<Maintenance[]> {
        return this._http.get<Maintenance[]>(this._maintenanceUrl + '/' + id.toString())
            .do(data => console.log('Maintenance: ' + JSON.stringify(data)));
    }
}
