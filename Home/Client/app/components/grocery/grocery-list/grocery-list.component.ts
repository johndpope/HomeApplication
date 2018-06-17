import { Component, OnInit } from '@angular/core';
import { Grocery } from '../grocery';
import { GroceryService } from '../grocery.service';

@Component({
    selector: 'grocery-list',
    templateUrl: './grocery-list.component.html'
})

export class GroceryListComponent implements OnInit {
    pageTitle: string = "Grocery Shopping";
    errorMessage: string;
    filteredGroceries: Grocery[];
    groceries: Grocery[] = [];

    _listFilter:string = "";
    get listFilter(): string
    {
        return this._listFilter;
    }
    set listFilter(value: string) 
    {
        this._listFilter = value;
        this.filteredGroceries = this.listFilter ? this.performFilter(this.listFilter) : this.groceries;
    }

    constructor(private _groceryService: GroceryService) 
    { }

    ngOnInit()
    {
        this._groceryService.getGroceries()
            .subscribe(groceries => {
                this.groceries = groceries;
                this.filteredGroceries = groceries;
            },
            error => this.errorMessage = <any>error);
    }

    performFilter(filterBy: string) 
    {
        filterBy = filterBy.toLocaleLowerCase();
        return this.groceries.filter((grocery: Grocery) => grocery.groceryName.toLocaleLowerCase().indexOf(filterBy) !== -1);
    }
}