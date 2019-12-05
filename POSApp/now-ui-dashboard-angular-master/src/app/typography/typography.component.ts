import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ServerService } from './../shared/serverservice.service';
import { RealServer } from '../shared/serverclass.model';
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
              private service: ServerService) {}
  
  ngOnInit() {
    this.resetForm();
    this.service.refreshList()
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.form.reset();
    this.service.formData = {
      server_ID: 0,
      server_LNAME: '',
      server_FNAME: '',
      server_MI: '',
      total_TIPS: 0
    }
  }

  onSubmit(form: NgForm) {
    if (this.service.formData.server_ID == 0)
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  insertRecord(form: NgForm) {
    this.service.postServer().subscribe(
      res => {
        debugger;
        this.resetForm(form);
        this.toastr.success('Submitted successfully', 'Server Created');
        this.service.refreshList();
      },
      err => {
        debugger;
        console.log(err);
      }
    )
  }
  updateRecord(form: NgForm) {
    this.service.putServer().subscribe(
      res => {
        this.resetForm(form);
        this.toastr.info('Submitted successfully', 'Server');
        this.service.refreshList();
      },
      err => {
        console.log(err);
      }
    )
  }

  populateForm(pd: RealServer) {
    this.service.formData = Object.assign({}, pd);
  }

  onDelete(PMId) {
    if (confirm('Are you sure to delete this Server ?')) {
      this.service.deleteServer(PMId)
        .subscribe(res => {
          debugger;
          this.service.refreshList();
          this.toastr.warning('Deleted successfully', 'Server Deletion');
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