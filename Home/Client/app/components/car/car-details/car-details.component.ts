import { Component, OnInit } from "@angular/core";

@Component({
    selector: 'car-details',
    templateUrl: './car-details.component.html'
})

export class CarDetailsComponent implements OnInit
{
    pageTitle: string = "Car";
    errorMessage: string;

    constructor()
    { }

    ngOnInit()
    { }
}