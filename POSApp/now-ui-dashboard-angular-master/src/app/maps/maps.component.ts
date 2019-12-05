import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { TicketService } from './../shared/ticketservice.service';
import { ProductService } from './../shared/productservice.service';
import { Ticket } from '../shared/ticketclass.model';
import { HttpClient } from "@angular/common/http";
import { ToastrService } from 'ngx-toastr';
import { MatDialog, MatDialogConfig} from '@angular/material';
import { Product } from '../shared/productclass.model';

@Component({
  selector: 'app-maps',
  templateUrl: './maps.component.html',
  styleUrls: ['./maps.component.css']
})
export class MapsComponent implements OnInit {

  constructor(private toastr: ToastrService, 
              private service: ProductService) {}
  
  ngOnInit() {
    this.resetForm();
    this.service.refreshList()
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.form.reset();
    this.service.formData = {
      prod_ID: 0,
      prod_NAME: '',
      prod_COST: 0,
      prod_COUNT: 0


    }
  }

  onSubmit(form: NgForm) {
    if (this.service.formData.prod_ID == 0)
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  insertRecord(form: NgForm) {
    this.service.postProduct().subscribe(
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
    this.service.putProduct().subscribe(
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

  populateForm(pd: Product) {
    this.service.formData = Object.assign({}, pd);
  }

  onDelete(PMId) {
    if (confirm('Are you sure to delete this product ?')) {
      this.service.deleteProduct(PMId)
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