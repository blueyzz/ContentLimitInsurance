import { CategoryVM } from "./categoryVM.model";

export class Content {
  Categories: CategoryVM[];
  Total: number;
  DisplayTotal: string;

  constructor() {
    this.Categories = [];
    this.Total = 0;
    this.DisplayTotal = '';
  }
}
