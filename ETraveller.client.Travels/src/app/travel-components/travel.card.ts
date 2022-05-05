import { Component, Input, OnInit } from '@angular/core';


@Component({
    selector: 'app-travel-card',
    templateUrl: './travel.card.html',
    styleUrls: ['./travel.card.css']
})
export class TravelCard implements OnInit{
    @Input("travel") travel: { Name: string; TravelImage: string; Description: string; };
    constructor() {
        this.travel = {
            Name:"",
            TravelImage:"",
            Description:""
            };
    }
    ngOnInit(): void {
    }
}
