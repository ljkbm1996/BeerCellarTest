import { BeerData } from './beer-data';

export class Beer {
    currentPage: number;
    numberOfPages: number;
    totalResults: number;
    beerData: Array<BeerData>;

    constructor() {
        this.beerData = [];
    }
}
