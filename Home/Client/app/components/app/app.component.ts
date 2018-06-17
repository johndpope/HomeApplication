import { Component } from '@angular/core';

import { GroceryService } from '../grocery/grocery.service';
import { MealService } from '../meal/meal.service';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    providers: [ GroceryService, MealService ]
})
export class AppComponent {
}
