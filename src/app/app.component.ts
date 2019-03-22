import { Component } from '@angular/core';
import { MatBottomSheet } from '@angular/material';
import { MySheetComponent } from './components/my-sheet/my-sheet.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  

  constructor(private bottomSheet: MatBottomSheet){

  }
  openBottomSheet(){
    this.bottomSheet.open(MySheetComponent);
  }

}

