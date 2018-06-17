import { Component, OnInit } from '@angular/core';
import { Meal } from '../meal';
import { MealService } from '../meal.service';

@Component({
    selector: 'meal-list',
    templateUrl: './meal-list.component.html'
})

export class MealListComponent implements OnInit {
    pageTitle: string = "Meals";
    errorMessage: string;
    filteredMeals: Meal[];
    meals: Meal[] = [];

    _listFilter: string;
    get listFilter(): string 
    {
        return this._listFilter;
    }

    set listFilter(value: string) 
    {
        this._listFilter = value;
        this.filteredMeals = this.listFilter ? this.performFilter(this.listFilter) : this.meals;
    }

    constructor(private _mealService: MealService) 
    { }

    performFilter(filterBy: string): Meal[]
    {
        filterBy = filterBy.toLocaleLowerCase();
        return this.meals.filter((meal: Meal) => meal.mealName.toLocaleLowerCase().indexOf(filterBy) !== -1);
    }

    ngOnInit()
    {
        this._mealService.getMeals()
            .subscribe(meals => {
                this.meals = meals;
                this.filteredMeals = meals;
            },
            error => this.errorMessage = <any>error);
    }
}
