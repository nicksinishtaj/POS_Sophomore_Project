import { TicketService } from './../../shared/ticketservice.service';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'notifications-details',
  templateUrl: './notifications.component.html',
  styleUrls: ['./notifications.component.css']
})

export class NotificationsComponent implements OnInit {

        constructor(private service: TicketService, private toastr: ToastrService){}

      
  ngOnInit() {
    this.resetForm();
  }
        
        
          resetForm(form?: NgForm) {
            if (form != null)
              form.form.reset();
            this.service.formData = {
              order_ID: 0,
              order_DATETIME: new Date(),
              order_QTY: 0,
              order_Total: 0,
              prod_ID: 0,
              order_Name: '',
              tip: 0,
              deposit: 0,
              isOpen: true,
              server_ID: 0
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
                this.toastr.success('Submitted successfully', 'Payment Detail Register');
                this.service.refreshList();
              },
              err => {
                debugger;
                console.log(err);
              }
            )
          }
          updateRecord(form: NgForm) {
            this.service.putTicket().subscribe(
              res => {
                this.resetForm(form);
                this.toastr.info('Submitted successfully', 'Payment Detail Register');
                this.service.refreshList();
              },
              err => {
                console.log(err);
              }
            )
          }




}