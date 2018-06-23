import { Component, OnInit } from '@angular/core';
import { BudgetItem } from '../budget-item';
import { BudgetService } from '../budget.service';

@Component({
    selector: 'budget-item-list',
    templateUrl: './budget-item-list.component.html'
})

export class BudgetItemListComponent implements OnInit {
    pageTitle: string = 'what the fuck is going on ';
    errorMessage: string;

    budgetItems: BudgetItem[] = [];

    constructor(private _budgetService: BudgetService) { }

    ngOnInit() {
        this._budgetService.getBudgetItems()
            .subscribe(budgetItems => {
                this.budgetItems = budgetItems;
            },
            error => this.errorMessage = <any>error);
    }
}
