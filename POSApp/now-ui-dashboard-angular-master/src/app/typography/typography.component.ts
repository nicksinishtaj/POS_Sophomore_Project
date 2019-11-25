import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { TicketService } from './../shared/ticketservice.service';
import { Ticket } from '../shared/ticketclass.model';
import { HttpClient } from "@angular/common/http";
import { ToastrService } from 'ngx-toastr';
import { MatDialog, MatDialogConfig} from '@angular/material';

@Component({
  selector: 'app-typography',
  templateUrl: './typography.component.html',
  styleUrls: ['./typography.component.css']
})
export class TypographyComponent implements OnInit {

  constructor(private toastr: ToastrService, 
              private service: TicketService) {}
  
  ngOnInit() {
    this.resetForm();
    this.service.refreshList()
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
      isOpen: true
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
        this.toastr.success('Submitted successfully', 'Ticket Created');
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
        this.toastr.info('Submitted successfully', 'Ticket');
        this.service.refreshList();
      },
      err => {
        console.log(err);
      }
    )
  }

  populateForm(pd: Ticket) {
    this.service.formData = Object.assign({}, pd);
  }

  onDelete(PMId) {
    if (confirm('Are you sure to delete this ticket ?')) {
      this.service.deleteTicket(PMId)
        .subscribe(res => {
          debugger;
          this.service.refreshList();
          this.toastr.warning('Deleted successfully', 'Ticket Deletion');
        },
          err => {
            debugger;
            console.log(err);
          })
    }
 }

 onCashOut(form: NgForm) {
  let myDialog:any = <any>document.getElementById("myDialog");
    myDialog.showModal();

 }


 PopupOpen = false;

  openPopup() {
    this.PopupOpen = true;
  }

  deleteOption() {
    this.PopupOpen = false;
  }

  cancelOption() {
    this.PopupOpen = false;
  }

}