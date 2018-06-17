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

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
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
