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
        this.filteredCars = this.listFilter ? this.performFilter(this.listFilter) : this.cars;
    }

    constructor(private _carService: CarService) { }

    ngOnInit() {
        this._carService.getCars()
            .subscribe((cars: Car[]) => {
                this.cars = cars;
                this.filteredCars = cars;
            });
    }

    performFilter(filterBy: string) 
    {
        filterBy = filterBy.toLocaleLowerCase();
        return this.cars.filter((car: Car) => car.make.toLocaleLowerCase().indexOf(filterBy) !== -1);
    }
}
