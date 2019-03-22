import { Component } from '@angular/core';
import {MatBottomSheet,MatBottomSheetRef} from '@angular/material';
import {DomSanitizer} from '@angular/platform-browser';

@Component({
  selector: 'app-my-sheet',
  templateUrl: './my-sheet.component.html',
  styleUrls: ['./my-sheet.component.scss']
})

export class MySheetComponent {

  constructor(private bottomSheetRef: MatBottomSheetRef<MySheetComponent>) { }

  openLink(event: MouseEvent): void {
    this.bottomSheetRef.dismiss();
    event.preventDefault();
  }

}


@Component({
  selector: 'bottom-sheet-overview-example-sheet',
  templateUrl: './bottom-sheet-overview-example-sheet.html',
})
export class BottomSheetOverviewExampleSheet {
  constructor(private bottomSheetRef: MatBottomSheetRef<BottomSheetOverviewExampleSheet>) {}

  openLink(event: MouseEvent): void {
    this.bottomSheetRef.dismiss();
    event.preventDefault();
  }
}


@Component({
  selector: 'icon-overview-example',
  templateUrl: './bottom-sheet-overview-example-sheet.html'
})
export class IconOverviewExample {
  
}
