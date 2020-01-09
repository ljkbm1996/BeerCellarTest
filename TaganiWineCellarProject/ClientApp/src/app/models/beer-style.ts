import { BeerCategory } from './beer-category';

export class BeerStyle {
    id: number;
    categoryId: number;
    category: BeerCategory;
    name: string;
    shortName: string;
    description: string;
}
