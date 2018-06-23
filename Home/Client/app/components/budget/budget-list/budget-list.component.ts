import { Component, OnInit } from '@angular/core';
import { Budget } from '../budget';
import { BudgetService } from '../budget.service';

@Component({
    selector: 'budget-list',
    templateUrl: './budget-list.component.html'
})

export class BudgetListComponent implements OnInit {
    pageTitle: string = 'Welcome to the Shit Show';
    errorMessage: string;
    filteredBudgets: Budget[];
    budgets: Budget[] = [];

    _listFilter: string = '';
    get listFilter(): string {
        return this._listFilter;
    }
    set listFilter(value: string) {
        this._listFilter = value;
        this.filteredBudgets = this.listFilter ? this.performFilter(this.listFilter) : this.budgets;
    }

    constructor(private _budgetService: BudgetService) { }

    ngOnInit() {
        this._budgetService.getBudgets()
            .subscribe(budgets => {
                this.budgets = budgets;
                this.filteredBudgets = budgets;
            },
            error => this.errorMessage = <any>error);
    }

    performFilter(filterBy: string) {
        filterBy = filterBy.toLocaleLowerCase();
        return this.budgets.filter((budget: Budget) => budget.budgetName.toLocaleLowerCase().indexOf(filterBy) !== -1);
    }
}
