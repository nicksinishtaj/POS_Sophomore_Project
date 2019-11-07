import { Injectable } from '@angular/core';
import { TicketDetailreal } from './ticket-detailreal.model';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class TicketDetailrealService {




    formData: TicketDetailreal
    readonly rootURL = 'http://localhost:62837/api';
    list : TicketDetailreal[];

  constructor(private http:HttpClient) { }

  postTicket(){
    return this.http.post(this.rootURL+'/Tickets', this.formData)
  }

  putTicket()
  {
    return this.http.put(this.rootURL + '/Tickets' + this.formData.order_ID, this.formData);
  }

  deletePaymentDetail(id) {
    return this.http.delete(this.rootURL + '/Tickets'+ id);
  }


  refreshList(){
    this.http.get(this.rootURL + '/Tickets')
    .toPromise()
    .then(res => this.list = res as TicketDetailreal[]);
  }
}
