
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DeliveryModel } from '../app/models/delivery-model';

@Injectable()
export class DeliveryService{
    constructor(private http:HttpClient){

    }
    getAllOrders(){
        return this.http.get("http://localhost:50782/api/Delivery");
    }
    saveOrder(obj: DeliveryModel){
        return this.http.post("http://localhost:50782/api/Delivery", obj);
    }
}