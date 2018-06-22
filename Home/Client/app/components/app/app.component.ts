import { Component } from '@angular/core';

import { GroceryService } from '../grocery/grocery.service';
import { MealService } from '../meal/meal.service';
import { CarService } from '../car/car.service';
import { BudgetService } from '../budget/budget.service';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    providers: [ CarService, GroceryService, MealService, BudgetService ]
})
export class AppComponent {
}
