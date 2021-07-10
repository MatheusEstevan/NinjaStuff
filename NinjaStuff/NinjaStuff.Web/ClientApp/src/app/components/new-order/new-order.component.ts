import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CustomerService } from 'src/app/services/customer.service';
import { OrderService } from 'src/app/services/order.service';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-new-order',
  templateUrl: './new-order.component.html',
  styleUrls: ['./new-order.component.css']
})
export class NewOrderComponent implements OnInit {
  products = [];
  selectedItems = [];
  productsDropdownSettings = {};
  customers = [];
  customerDropdownSettings = {};

  orderForm = new FormGroup({
    customer: new FormControl("", [Validators.required]),
    discount: new FormControl("", [Validators.required]),
    products: new FormControl("", [Validators.required])
  })

  constructor(private orderService: OrderService,
              private productService: ProductService,
              private customerService: CustomerService,
              private router: Router) { }

  ngOnInit() {

    this.customerService.get().subscribe((data: any) =>{
      this.customers = data;
    })
    this.productService.get().subscribe((data: any) => {
      this.products = data
    })
    this.productDropdownInit();
    this.customerDropdownInit();
  }

  productDropdownInit(){

    this.productsDropdownSettings = {
      singleSelection: false,
      idField: 'id',
      textField: 'description',
      selectAllText: 'Marcar todos',
      unSelectAllText: 'Desmarcar todos',
      itemsShowLimit: 3,
      allowSearchFilter: true,
      searchPlaceholderText: "Procurar",
     
    };
  }

  customerDropdownInit(){

    this.customerDropdownSettings= {
      singleSelection: true,
      idField: 'id',
      textField: 'email',
      selectAllText: 'Marcar todos',
      unSelectAllText: 'Desmarcar todos',
      itemsShowLimit: 3,
      allowSearchFilter: true,
      searchPlaceholderText: "Procurar",
     
    };
  }

}

