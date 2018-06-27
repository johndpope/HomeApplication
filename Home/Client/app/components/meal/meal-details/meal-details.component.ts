import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { Meal } from '../meal';

@Component({
    selector: 'meal-details',
    templateUrl: './meal-details.component.html'
})

export class MealDetailsComponent implements OnInit {
    pageTitle: string = "Meal Details Component";
    meal: Meal;

    constructor(private _route: ActivatedRoute,
                private _router: Router) { }

    ngOnInit()
    {
        const id = +this._route.snapshot.paramMap.get('id');
        this.pageTitle += `:${id}`;
        this.meal = {
            'mealId': 1,
            'mealName': 'Chicken Devan'
        };
    }

    onBack(): void 
    {
        this._router.navigate(['/meals']);
    }
}