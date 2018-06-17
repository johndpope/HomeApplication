import { Component, OnInit } from '@angular/core';
import { Grocery } from '../grocery';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    selector: 'grocery-details',
    templateUrl: './grocery-details.component.html'
})

export class GroceryDetailsComponent implements OnInit {
    pageTitle: string = "Grocery Details"

    grocery: Grocery = {
        'groceryUid': 'fjdakslfjadkslfjdkls',
        'groceryName': 'CURRY SHITS'
    };

    constructor(private _route: ActivatedRoute,
                private _router: Router) { }

    ngOnInit() 
    {
        const id = +this._route.snapshot.paramMap.get('id');
        this.pageTitle += `:${id}`;
        this.grocery = {
            'groceryUid': 'fjdakslfjadkslfjdkls',
            'groceryName': 'CURRY SHITS'
        }
    }

    onBack(): void 
    {
        this._router.navigate(['/groceries']);
    }
}