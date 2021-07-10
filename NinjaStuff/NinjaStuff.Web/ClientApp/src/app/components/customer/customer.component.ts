import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../../services/customer.service';
@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {
  constructor(private customerSvc: CustomerService) { }
  public customers: any[] = [];

  ngOnInit() {

    this.customerSvc.get().subscribe((data: any) => {
    
      this.customers = data
      console.log(this.customers)
      
    })
    
  }
 

}
