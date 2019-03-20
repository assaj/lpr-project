import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';

import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { MatBottomSheetModule, MatButtonModule } from '@angular/material';
import { MySheetComponent } from './components/my-sheet/my-sheet.component';



@NgModule({
  declarations: [
    AppComponent,
    MySheetComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatBottomSheetModule,
    
  ],
  providers: [],
  entryComponents: [MySheetComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
