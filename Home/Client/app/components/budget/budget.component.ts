import { Component, OnInit } from "@angular/core";

@Component({
    selector: 'budget',
    templateUrl: './budget.component.html'
})

export class BudgetComponent implements OnInit
{
    pageTitle: string = "Welcome to the Shit Show";
    errorMessage: string;

    constructor()
    { }

    ngOnInit()
    { }
}
