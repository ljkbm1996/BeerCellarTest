import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { faBeer, faTshirt } from '@fortawesome/free-solid-svg-icons';
import { BeerService } from 'src/app/services/beer.service';
import { Beer } from 'src/app/models/beer';
import { faSyncAlt } from '@fortawesome/free-solid-svg-icons';
import { Subscription, of } from 'rxjs';
import { finalize, map, distinct } from 'rxjs/operators';
import { BeerData } from 'src/app/models/beer-data';
import { BeerCategory } from 'src/app/models/beer-category';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  pageNumbers: Array<number> = [];
  categories: Array<BeerCategory> = [];
  currentBeer: BeerData;
  currentPage = 1;
  faBeer = faBeer;
  spinner = faSyncAlt;
  beers: Beer;
  beersResult: Beer;
  img = 'https://redi.eu/wp-content/uploads/2015/08/not-available-300x217.png';
  beerSubscription: Subscription;
  isLoading = false;
  constructor(private beerService: BeerService) { }

  ngOnInit() {
    this.setCategories();
    this.beerSubscription = this.beerService.GetBeers()
      .pipe(
        finalize(() => {
          this.isLoading = false;
          for (let i = 1; i <= this.beers.numberOfPages; i++) {
            this.pageNumbers.push(i);
          }

          this.currentPage = this.beers.currentPage;
          this.beers.beerData.forEach((data) => {
            data.abv = parseFloat(data.abv.toString());
          });
        })
      )
      .subscribe(result => {
        this.isLoading = true;
        this.beers = result;
      });
  }

  setCategories() {
    this.beerService.GetBeerCategories().subscribe((categories) => this.categories = categories);
  }

  setCurrentBeer(index: number) {
    this.currentBeer = this.beers.beerData[index];
  }

  setCurrentPage(page: number) {
    this.currentPage = page;
    this.beers = null;
    this.beerSubscription = this.beerService.GetBeersByPage(page).pipe(
      finalize(() => {
        this.isLoading = false;
        this.beers.beerData.forEach((data) => {
          data.abv = parseFloat(data.abv.toString());
        });
      })
    )
      .subscribe(result => {
        this.isLoading = true;
        this.beers = result;
      });
  }

  sortBy(option: string) {
    this.beers.beerData = this.beers.beerData.sort((a, b) => {
      if (a[option] < b[option]) {
        return -1;
      } else if (a[option] > b[option]) {
        return 1;
      }
      return 0;
    });
  }

  categorize(option: string) {
    if (option === 'All') {
      this.beers = null;
      this.setCurrentPage(this.currentPage);
    } else {
      this.beers = null;
        this.beerService.GetBeersByPage(this.currentPage).pipe(
        finalize(() => {
          this.isLoading = false;
          this.beers.beerData.forEach((data) => {
            data.abv = parseFloat(data.abv.toString());
          });

          const filteredBeers = this.beers;
          filteredBeers.beerData = filteredBeers.beerData
            .filter((beer) => beer.style !== null)
            .filter((beer) => beer.style.category.name === option);
          this.beers = filteredBeers;
        })
      )
        .subscribe(result => {
          this.isLoading = true;
          this.beers = result;
        });
    }
  }
}
