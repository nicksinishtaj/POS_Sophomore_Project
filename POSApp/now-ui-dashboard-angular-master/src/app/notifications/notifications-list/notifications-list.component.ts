import { TicketService } from './../../shared/ticketservice.service';
import { Ticket } from './../../shared/ticketclass.model';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'app-notifications-list',
    templateUrl: './notifications.component.html',
    styles: []
})
export class NotificationsListComponent implements OnInit {

    constructor(private service: TicketService,
        private toastr: ToastrService) { }

    ngOnInit() {
        this.service.refreshList();
    }

    populateForm(pd: Ticket) {
        this.service.formData = Object.assign({}, pd);
    }

    
  onDelete(order_ID) {
    if (confirm('Are you sure to delete this record ?')) {
      this.service.deleteTicket(order_ID)
        .subscribe(res => {
          debugger;
          this.service.refreshList();
          this.toastr.warning('Deleted successfully', 'Payment Detail Register');
        },
          err => {
            debugger;
            console.log(err);
          })
    }




}
}