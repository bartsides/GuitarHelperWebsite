import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { ScalesComponent } from './scales/scales.component';
import { ScaleFinderComponent } from './scaleFinder/scaleFinder.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    ScalesComponent,
    ScaleFinderComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: ScalesComponent, pathMatch: 'full' },
      { path: 'finder', component: ScaleFinderComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
