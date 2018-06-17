import { Injectable } from "@angular/core";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Observable } from "rxjs/Observable";
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';

import { Grocery } from "./grocery";

@Injectable()
export class GroceryService
{
    private _groceryUrl = './api/grocery';

    constructor(private _http: HttpClient) { }

    getGroceries(): Observable<Grocery[]>
    {
        return this._http.get<Grocery[]>(this._groceryUrl)
            .do(data => console.log('All: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }

    private handleError(err: HttpErrorResponse)
    {
        console.log(err.message);
        return Observable.throw(err.message);
    }
}