import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PopupComponent } from './Popup.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [PopupComponent],
  imports: [
    CommonModule,
    BrowserAnimationsModule,
  ],
  exports: [PopupComponent]
})
export class PopupModule { }
