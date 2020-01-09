import { BeerLabel } from './beer-label';
import { BeerStyle } from './beer-style';

export class BeerData {
    id: string;
    name: string;
    nameDisplay: string;
    abv: number;
    createDate: Date;
    updateDate: Date;
    isOrganic: string;
    isRetired: string;
    labels: BeerLabel;
    style: BeerStyle;
}
