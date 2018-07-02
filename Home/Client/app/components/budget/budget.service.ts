import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';

import { Budget } from './budget';
import { BudgetItem } from './budget-item';

@Injectable()
export class BudgetService {
    private _budgetUrl = './api/budget';

    constructor(private _http: HttpClient) { }

    getBudgets(): Observable<Budget[]> {
        return this._http.get<Budget[]>(this._budgetUrl)
            .do(data => console.log('All: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }
    
    // Still need to figure out how to pass things to an api call
    getBudgetItems(budgetUid: string): Observable<BudgetItem[]> {
        return this._http.get<BudgetItem[]>(this._budgetUrl)
            .do(data => console.log('All: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }

    getBudgetItems(budgetUid: string): Observable<BudgetItem[]> {
        return this._http.get<BudgetItem[]>(this._budgetUrl)
            .do(data => console.log('All: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }

    private handleError(err: HttpErrorResponse)
    {
        console.log(err.message);
        return Observable.throw(err.message);
    }
}
