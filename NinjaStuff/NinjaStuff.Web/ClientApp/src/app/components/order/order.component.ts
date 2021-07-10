import { Component, OnInit } from '@angular/core';
import { OrderService } from 'src/app/services/order.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {
  constructor(private orderSvc: OrderService) { }
  public orders: any[] = [];

  ngOnInit() {

    this.orderSvc.get().subscribe((data: any) => {
    
      this.orders = data
      console.log(this.orders)
      
    })
    
  }

}
