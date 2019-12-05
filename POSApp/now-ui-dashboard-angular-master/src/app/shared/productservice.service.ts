import { PaymentDetail } from './Ticket-detailreal.model';
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Product } from './Productclass.model';

@Injectable({
  providedIn: 'root'
})

export class ProductService{
    formData: Product;
    readonly rootURL = 'http://localhost:62837/api';
    list: Product[];




    constructor(private http: HttpClient) { }

    postProduct() {
        return this.http.post(this.rootURL + '/Products', this.formData);
      }
      putProduct() {
        return this.http.put(this.rootURL + '/Products/'+ this.formData.prod_ID, this.formData);
      }
      deleteProduct(id) {
        return this.http.delete(this.rootURL + '/Products/'+ id);
      }

      cashOutProduct(id) {
        return this.http.post(this.rootURL + '/Products' + this.formData.prod_ID, this.formData);
      }

      
    
      refreshList(){
        this.http.get(this.rootURL + '/Products')
        .toPromise()
        .then(res => this.list = res as Product[]);
      }


}