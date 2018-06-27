import { Component, OnInit } from '@angular/core';
import { Budget } from '../budget';
import { BudgetService } from '../budget.service';

@Component({
    selector: 'budget-list',
    styleUrls: ['./budget-list.component.css'],
    templateUrl: './budget-list.component.html'
})

export class BudgetListComponent implements OnInit {
    pageTitle: string = 'Welcome to Broken Promises and False Hopes';
    errorMessage: string;
    budgets: Budget[] = [];

    constructor(private _budgetService: BudgetService) { }

    ngOnInit() {
        this._budgetService.getBudgets()
            .subscribe(budgets => {
                this.budgets = budgets;
            },
            error => this.errorMessage = <any>error);
    }
}
