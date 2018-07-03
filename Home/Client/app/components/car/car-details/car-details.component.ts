import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { Car } from '../car';
import { CarService } from '../car.service';

@Component({
    selector: 'car-details',
    templateUrl: './car-details.component.html'
})

export class CarDetailsComponent implements OnInit {
    pageTitle: string = 'Car';
    errorMessage: string;
    make: string;
    model: string;
    year: number;
    licensePlate: string;
    car: Car;

    constructor(private _route: ActivatedRoute,
                private _router: Router,
                private _carService: CarService) { }

    ngOnInit() {
        const id = +this._route.snapshot.paramMap.get('id');
        this.pageTitle += `:${id}`;
        this._carService.getCar(id)
            .subscribe(car => {
                this.car = car;
                this.make = this.car.make;
                this.model = this.car.model;
                this.year = this.car.year;
                this.licensePlate = this.car.licensePlate;
            },
            error => this.errorMessage = <any>error);
    }
}
