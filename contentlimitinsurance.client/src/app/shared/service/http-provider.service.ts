import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { WebAPIService } from './web-api.service';
import { Router } from '@angular/router';
import { getBaseUrl } from "../../../main";
import { AddItem } from "../models/add-item.model";

@Injectable({
  providedIn: 'root'
})

export class HttpProviderService {
  private static baseURL = getBaseUrl();
  private static contentURL = `${HttpProviderService.baseURL}/content`;
  private static getContentURL = `${HttpProviderService.contentURL}/getcontent`;
  private static getCategoriesURL = `${HttpProviderService.contentURL}/getcategories`;
  private static addItemURL = `${HttpProviderService.contentURL}/addItem`;
  private static deleteItemURL = `${HttpProviderService.contentURL}/deleteItem`;

  constructor(private webAPIService: WebAPIService, private router: Router) { }

  public contentPage() {
    this.router.navigate(["content"]);
  }

  public getContent(): Observable<any> {
    
    return this.webAPIService.get(HttpProviderService.getContentURL); 
  }

  public getCategories(): Observable<any> {
    return this.webAPIService.get(HttpProviderService.getCategoriesURL);
  }

  public addItem(addItem: AddItem): Observable<any> {
    const name = addItem.Name;
    const value = addItem.Value;
    const categoryID = addItem.CategoryID;
    return this.webAPIService.post(HttpProviderService.addItemURL, { name, value, categoryID });
  }

  public deleteItem(itemID: number): Observable<any> {
    return this.webAPIService.post(HttpProviderService.deleteItemURL, { itemID });
  }
}
