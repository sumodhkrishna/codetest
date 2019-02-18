import { Component, OnInit } from '@angular/core';
import { DeliveryService } from '../../services/delivery-service';
import { DeliveryModel } from '../models/delivery-model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  providers:[DeliveryService]
})
export class HomeComponent implements OnInit {
  constructor(private deliveryService:DeliveryService){}
  orders:DeliveryModel[] = []; 
  objectToSave: DeliveryModel = new DeliveryModel();
  ngOnInit(): void {
    this.deliveryService.getAllOrders().subscribe((data:DeliveryModel[]) => {
      this.orders = data;
    } )
  }
  save(){
    this.deliveryService.saveOrder(this.objectToSave).subscribe((data:DeliveryModel) => {
      this.deliveryService.getAllOrders().subscribe((data:DeliveryModel[]) => {
        this.orders = data;
        this.objectToSave = new DeliveryModel();
      } )
    })
  }


}
