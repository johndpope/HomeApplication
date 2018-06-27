import { Component, OnInit, Input } from '@angular/core';
import { BudgetItem } from '../budget-item';
import { BudgetService } from '../budget.service';

@Component({
    selector: 'budget-item-list',
    templateUrl: './budget-item-list.component.html'
})

export class BudgetItemListComponent implements OnInit {
    @Input('budgetUid') budgetUid: string;
    pageTitle: string = 'what the fuck is going on ';
    errorMessage: string;

    budgetItems: BudgetItem[] = [];

    constructor(private _budgetService: BudgetService) { }

    ngOnInit() {
        this._budgetService.getBudgetItems(this.budgetUid)
            .subscribe(budgetItems => {
                this.budgetItems = budgetItems;
            },
            error => this.errorMessage = <any>error);
    }
}
