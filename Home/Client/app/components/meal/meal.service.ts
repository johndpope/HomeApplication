import { Injectable } from "@angular/core";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Observable } from "rxjs/Observable";
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';

import { Meal } from "./meal";

@Injectable()
export class MealService
{
    private _mealUrl = './api/meal';
    
    constructor(private _http: HttpClient)
    { }

    getMeals(): Observable<Meal[]> 
    {
        return this._http.get<Meal[]>(this._mealUrl)
            .do(data => console.log('All: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }

    private handleError(err: HttpErrorResponse)
    {
        console.log(err.message);
        return Observable.throw(err.message);
    }
}