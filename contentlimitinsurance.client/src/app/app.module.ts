import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { MaterialModule } from './shared/module/material.module';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ContentComponent } from './content/content.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { SpinnerComponent } from './spinner/spinner.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';

import { WebAPIService } from './shared/service/web-api.service';
import { HttpProviderService } from './shared/service/http-provider.service';
import { SpinnerService } from './shared/service/spinner.service';


@NgModule({
  declarations: [
    AppComponent,
    ContentComponent,
    HeaderComponent,
    FooterComponent,
    SpinnerComponent
  ],
  imports: [
    BrowserModule, FormsModule, ReactiveFormsModule, HttpClientModule, MaterialModule,
    AppRoutingModule
  ],
  providers: [
    provideAnimationsAsync('noop'),
    [WebAPIService],
    [HttpProviderService],
    [SpinnerService]
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
