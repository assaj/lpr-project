import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';

import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { MatBottomSheetModule, MatButtonModule, MatListModule, MatIconModule} from '@angular/material';
import { MySheetComponent , BottomSheetOverviewExampleSheet} from './components/my-sheet/my-sheet.component';




@NgModule({
  declarations: [
    AppComponent,
    MySheetComponent,
    BottomSheetOverviewExampleSheet,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatBottomSheetModule,
    MatListModule,
    MatIconModule,
  ],
  providers: [],
  entryComponents: [MySheetComponent, BottomSheetOverviewExampleSheet],
  bootstrap: [AppComponent]
})
export class AppModule { }
