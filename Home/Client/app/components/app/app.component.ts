import { Component } from '@angular/core';

import { GroceryService } from '../grocery/grocery.service';
import { MealService } from '../meal/meal.service';
import { CarService } from '../car/car.service';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    providers: [ CarService, GroceryService, MealService ]
})
export class AppComponent {
}
