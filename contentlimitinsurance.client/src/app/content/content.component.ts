import { Component, OnInit } from '@angular/core';
import { HttpProviderService } from '../shared/service/http-provider.service';
import { Category } from '../shared/models/category.model';
import { Content } from '../shared/models/content.model';
import { AddItem } from '../shared/models/add-item.model';
import { SpinnerService } from "../shared/service/spinner.service";

@Component({
  selector: 'app-content',
  standalone: false,

  templateUrl: './content.component.html',
  styleUrl: './content.component.css'
})
export class ContentComponent implements OnInit {
  categories: Category[] = [];
  selectedCategory: Category;
  name: string;
  value: number;


  content: Content;
  displayContent: boolean = false;
  addItem: AddItem = new AddItem();

  constructor(private httpProviderService: HttpProviderService, private spinnerService: SpinnerService) { }

  ngOnInit(): void {
    this.loadCategories();
    this.loadContents();
  }


  /*
   * Load Categories
   */
  async loadCategories() {
    this.spinnerService.show();
    this.httpProviderService.getCategories().subscribe(
      (data: any) => {
        if (data != null && data.body != null) {
          let result = data.body;
          if (result) {
            this.categories = result;
          }
        }
      }
    );
    this.spinnerService.hide();
  }

  /*
   * Load Content
   */
  async loadContents() {
    this.httpProviderService.getContent().subscribe(
      (data: any) => {
        if (data != null && data.body != null) {
          let result = data.body;
          if (result) {
            this.content = result;
            this.displayContent = this.content.Categories.length > 0;
          }
        }
      }
    );
  }


  /*
   * Add Item
   */
  async add() {
    this.addItem.CategoryID = this.selectedCategory.CategoryID;

    this.httpProviderService.addItem(this.addItem).subscribe(
      (data: any) => {
        if (data != null && data.body != null) {
          this.loadContents();
          this.name = '';
          this.value = 0;
        }
      });
  }


  /*
   * Delete Item
   */
  async delete(itemID: number) {
  if (confirm("Are you sure you want to delete this item?")) {
      this.httpProviderService.deleteItem(itemID).subscribe(
        (data: any) => {
          if (data != null && data.body != null) {
            this.loadContents();
          }
        });
    }
  }
}
