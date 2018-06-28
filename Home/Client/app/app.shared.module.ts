import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HomeComponent } from './components/home/home.component';
import { GroceryListComponent } from './components/grocery/grocery-list/grocery-list.component';
import { GroceryDetailsComponent } from './components/grocery/grocery-details/grocery-details.component';
import { MealListComponent } from './components/meal/meal-list/meal-list.component';
import { MealDetailsComponent } from './components/meal/meal-details/meal-details.component';
import { CarDetailsComponent } from './components/car/car-details/car-details.component';
import { CarListComponent } from './components/car/car-list/car-list.component';
import { BudgetListComponent } from './components/budget/budget-list/budget-list.component';
import { BudgetDetailsComponent } from './components/budget/budget-details/budget-details.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        BudgetListComponent,
        BudgetDetailsComponent,
        CarDetailsComponent,
        CarListComponent,
        GroceryListComponent,
        GroceryDetailsComponent,
        MealListComponent,
        MealDetailsComponent 
    ],
    imports: [
        CommonModule,
        HttpClientModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'budgets', component: BudgetListComponent },
            { path: 'budgets/:id', component: BudgetDetailsComponent },
            { path: 'cars', component: CarListComponent },
            { path: 'cars/:id', component: CarDetailsComponent },
            { path: 'groceries', component: GroceryListComponent },
            { path: 'groceries/:id', component: GroceryDetailsComponent },
            { path: 'meals', component: MealListComponent },
            { path: 'meals/:id', component: MealDetailsComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {

}
