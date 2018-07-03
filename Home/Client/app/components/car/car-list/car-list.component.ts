import { Component, OnInit } from '@angular/core';

import { Car } from '../car';
import { CarService } from '../car.service';

@Component({
    selector: 'car-list',
    templateUrl: './car-list.component.html'
})

export class CarListComponent implements OnInit {
    pageTitle: string = 'Car Maintenance';
    errorMessage: string;
    filteredCars: Car[];
    cars: Car[] = [];

    _listFilter: string = '';
    get listFilter(): string {
        return this._listFilter;
    }
    set listFilter(value: string) {
        this._listFilter = value;
        this.filteredCars = [];
    }

    constructor(private _carService: CarService) { }

    ngOnInit() {
        this._carService.getCars()
            .subscribe(cars => {
                this.cars = cars;
                this.filteredCars = cars;
            },
            error => this.errorMessage = <any>error);
    }
}
