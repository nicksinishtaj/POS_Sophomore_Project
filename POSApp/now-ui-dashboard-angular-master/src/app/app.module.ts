import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app.routing';
import { ComponentsModule } from './components/components.module';

import { AppComponent } from './app.component';

import { AdminLayoutComponent } from './layouts/admin-layout/admin-layout.component';
import { TicketDetailsComponent } from './ticket-details/ticket-details.component';
import { TicketDetailsrealComponent } from './ticket-detailsreal/ticket-detailsreal.component';
import { TicketDetailrealComponent } from './ticket-detailsreal/ticket-detailreal/ticket-detailreal.component';
import { TicketDetaillistrealComponent } from './ticket-detailsreal/ticket-detaillistreal/ticket-detaillistreal.component';
import { TicketDetailrealService } from './shared/ticket-detailreal.service';

@NgModule({
  imports: [
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    ComponentsModule,
    RouterModule,
    AppRoutingModule,
    NgbModule,
    ToastrModule.forRoot()
  ],
  declarations: [
    AppComponent,
    AdminLayoutComponent,
    TicketDetailsComponent,
    TicketDetailsrealComponent,
    TicketDetailrealComponent,
    TicketDetaillistrealComponent

  ],
  providers: [TicketDetailrealService],
  bootstrap: [AppComponent]
})
export class AppModule { }
