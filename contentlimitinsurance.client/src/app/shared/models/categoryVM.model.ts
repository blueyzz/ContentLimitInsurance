import { Item } from './item.model';

export class CategoryVM {
  CategoryID: number;
  Name: string;
  Items: Item[];
  CategoryTotal: number;
  DisplayCategoryTotal: string;

  constructor() {
    this.CategoryID = 0;
    this.Name = '';
    this.Items = [];
    this.CategoryTotal = 0;
    this.DisplayCategoryTotal = '';
  }
}
