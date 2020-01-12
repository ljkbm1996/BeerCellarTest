import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Beer } from '../models/beer';
import { AppSettings } from '../models/app.settings';
import { BeerCategory } from '../models/beer-category';

@Injectable({
  providedIn: 'root'
})
export class BeerService {

  constructor(private httpClient: HttpClient, private appSettings: AppSettings) { }

  public GetBeers(): Observable<Beer> {
    const url = `${this.appSettings.API_BASE_URL}api/beer`;
    return this.httpClient.get<Beer>(url);
  }

  public GetBeersByPage(page: number): Observable<Beer> {
    const url = `${this.appSettings.API_BASE_URL}api/beers-by-page`;
    const params: HttpParams = new HttpParams().set('page',  page.toString());
    return this.httpClient.get<Beer>(url, {params});
  }

  public GetBeerCategories(): Observable<Array<BeerCategory>> {
    const url = `${this.appSettings.API_BASE_URL}api/beer-category`;
    return this.httpClient.get<Array<BeerCategory>>(url);
  }

  public InsertBeer(beer: Beer): Observable<void> {
    const url = `${this.appSettings.API_BASE_URL}api/`;
    return this.httpClient.post<void>(url, beer);
  }
}
