import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-beer-detail',
  templateUrl: './beer-detail.component.html',
  styleUrls: ['./beer-detail.component.scss']
})
export class BeerDetailComponent implements OnInit {
  @Input() beerName: string;
  @Input() beerCategory: string;
  @Input() beerAbv: number;
  @Input() beerDescription: string;
  @Input() beerCreateDate: Date;

  constructor() { }

  ngOnInit() {
  }

}
