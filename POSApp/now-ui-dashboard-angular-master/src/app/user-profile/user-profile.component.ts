import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { TicketDetailrealService } from './../shared/ticket-detailreal.service';
import { TicketDetailreal } from '../shared/ticket-detailreal.model';
import { HttpClient } from "@angular/common/http";

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {



  constructor(private service: TicketDetailrealService) { }

  ngOnInit() {

    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.form.reset();

    this.service.formData = {
      order_ID: 0,
      order_DATETIME: new Date,
      order_QTY: '',
      order_Total: '',
      prod_ID: ''
    }

  }

  onSubmit(form: NgForm) {
    if (this.service.formData.order_ID == 0)
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  insertRecord(form: NgForm) {
    this.service.postTicket().subscribe(
      res => {
        debugger;
        this.resetForm(form);
        this.service.refreshList();
      },
      err => {
        debugger;
        console.log(err);
      }
    )
  }
  updateRecord(form: NgForm) {
    this.service.postTicket().subscribe(
      res => {
        this.resetForm(form);
      },
      err => {
        console.log(err);
      }
    )
  }






  }


