import { PaymentDetail } from './Ticket-detailreal.model';
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { RealServer } from './Serverclass.model';

@Injectable({
  providedIn: 'root'
})

export class ServerService{
    formData: RealServer;
    readonly rootURL = 'http://localhost:62837/api';
    list: RealServer[];




    constructor(private http: HttpClient) { }

    postServer() {
        return this.http.post(this.rootURL + '/RealServers', this.formData);
      }
      putServer() {
        return this.http.put(this.rootURL + '/RealServers/'+ this.formData.server_ID, this.formData);
      }
      deleteServer(id) {
        return this.http.delete(this.rootURL + '/RealServers/'+ id);
      }

      cashOutServer(id) {
        return this.http.post(this.rootURL + '/RealServers' + this.formData.server_ID, this.formData);
      }

      
    
      refreshList(){
        this.http.get(this.rootURL + '/RealServers')
        .toPromise()
        .then(res => this.list = res as RealServer[]);
      }


}