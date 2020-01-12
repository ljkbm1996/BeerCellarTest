import { Component, OnInit, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { BeerService } from 'src/app/services/beer.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Beer } from 'src/app/models/beer';
import { BeerData } from 'src/app/models/beer-data';
import { BeerStyle } from 'src/app/models/beer-style';
import { BeerLabel } from 'src/app/models/beer-label';

@Component({
  selector: 'app-add-beer-modal',
  templateUrl: './add-beer-modal.component.html',
  styleUrls: ['./add-beer-modal.component.scss']
})
export class AddBeerModalComponent implements OnInit {
  @Input() pageNumber: number;
  beerForm: FormGroup;

  constructor(public activeModal: NgbActiveModal, private beerService: BeerService, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.initializeForm();
  }

  initializeForm() {
    this.beerForm = this.formBuilder.group({
      name: ['', Validators.required],
      nameDisplay: ['', Validators.required],
      abv: ['', Validators.required],
      styleName: ['', Validators.required],
      styleShortName: ['', Validators.required],
      styleDescription: ['', Validators.required],
      labelsIcon: ['', Validators.required]
    });
  }

  onSubmit(formValue: FormData) {
    const beer: Beer = new Beer();
    const beerData: BeerData = new BeerData();
    const beerStyle: BeerStyle = new BeerStyle();
    const beerLabels: BeerLabel = new BeerLabel();

    beer.currentPage = this.pageNumber;
    beerData.name = formValue['name'];
    beerData.nameDisplay = formValue['nameDisplay'];
    beerData.abv = formValue['abv'];
    beerData.style = beerStyle;
    beerData.style.name = formValue['styleName'];
    beerData.style.shortName = formValue['styleShortName'];
    beerData.style.description = formValue['styleDescription'];
    beerData.labels = beerLabels;
    beerData.labels.icon = formValue['labelsIcon'];

    beer.beerData.push(beerData);

    this.beerService.InsertBeer(beer).subscribe();
  }

}
