import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import 'rxjs/add/operator/map';

import { Car } from '../car';
import { CarService } from '../car.service';
import { Maintenance } from '../maintenance';

@Component({
    selector: 'car-details',
    templateUrl: './car-details.component.html'
})

export class CarDetailsComponent implements OnInit {
    pageTitle: string;
    errorMessage: string;
    make: string;
    model: string;
    year: number;
    licensePlate: string;
    car: Car;
    carString: string;
    maintenances: Maintenance[] = [];
    filteredMaintenance: Maintenance[];

    constructor(private _route: ActivatedRoute,
                private _router: Router,
                private _carService: CarService) { }

    ngOnInit() {
        const id = +this._route.snapshot.paramMap.get('id');
        this.pageTitle += `:${id}`;
        
        this._carService.getCar(id)
            .subscribe((car: Car) => {
                this.car = car;
                this.carString = this.car.make + ' ' + this.car.model;
                this.pageTitle = this.carString + ' Maintenance';
            });

        this._carService.getCarMaintenance(id)
            .subscribe((maintenance: Maintenance[]) => this.maintenances = maintenance);
    }
}
