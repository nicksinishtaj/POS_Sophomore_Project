import { Component, OnInit } from '@angular/core';
import { PaymentDetailService } from './../../shared/ticket-detailreal.service';

@Component({
  selector: 'app-ticket-detailreal',
  templateUrl: './ticket-detailreal.component.html',
  styleUrls: ['./ticket-detailreal.component.scss']
})
export class TicketDetailrealComponent implements OnInit {

  constructor(private service: PaymentDetailService) { }

  ngOnInit() {
  }

}
