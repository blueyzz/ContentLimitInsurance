import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContentComponent } from './content/content.component';

const routes: Routes = [
  { path: '', component: ContentComponent },
  { path: 'content', component: ContentComponent },
  { path: 'content/getcategories', component: ContentComponent },
  { path: 'content/getcontent', component: ContentComponent },
  { path: 'content/addItem', component: ContentComponent },
  { path: 'content/deleteItem', component: ContentComponent }
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
