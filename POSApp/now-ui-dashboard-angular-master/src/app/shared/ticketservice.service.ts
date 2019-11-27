import { PaymentDetail } from './ticket-detailreal.model';
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Ticket } from './ticketclass.model';

@Injectable({
  providedIn: 'root'
})

export class TicketService{
    formData: Ticket;
    readonly rootURL = 'http://localhost:62837/api';
    list: Ticket[];




    constructor(private http: HttpClient) { }

    postTicket() {
        return this.http.post(this.rootURL + '/Tickets', this.formData);
      }
      putTicket() {
        return this.http.put(this.rootURL + '/Tickets/'+ this.formData.order_ID, this.formData);
      }
      deleteTicket(id) {
        return this.http.delete(this.rootURL + '/Tickets/'+ id);
      }

      cashOutTicket(id) {
        return this.http.post(this.rootURL + '/Tickets' + this.formData.order_ID, this.formData);
      }

      
    
      refreshList(){
        this.http.get(this.rootURL + '/Tickets')
        .toPromise()
        .then(res => this.list = res as Ticket[]);
      }


}