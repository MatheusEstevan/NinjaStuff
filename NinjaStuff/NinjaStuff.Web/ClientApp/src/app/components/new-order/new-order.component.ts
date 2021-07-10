import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Order } from 'src/app/model/order';
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
  selectedProducts = [];
  productsDropdownSettings = {};
  customers = [];
  customerDropdownSettings = {};
  price: number = 0;
  totalPrice: number = 0;


  orderForm = new FormGroup({
    customer: new FormControl("", [Validators.required]),
    discount: new FormControl(""),
    products: new FormControl("", [Validators.required])
  })

  constructor(private orderService: OrderService,
    private productService: ProductService,
    private customerService: CustomerService,
    private router: Router) { }

  ngOnInit() {

    this.customerService.get().subscribe((data: any) => {
      this.customers = data;
    })
    this.productService.get().subscribe((data: any) => {
      this.products = data
    })
    this.productDropdownInit();
    this.customerDropdownInit();
  }


  save() {
    if (this.orderForm.invalid) {
      alert("Preencha os campos obrigatórios")
    } else {
      let order: any = {
        Discount: this.orderForm.get('discount').value ? this.orderForm.get('discount').value : 0,
        Customer: this.getSelectedCustomer(),
        Products: this.selectedProducts,
        Price: this.price,
        TotalPrice: this.totalPrice
      }
      this.orderService.post(order).subscribe((data) => {
        this.router.navigateByUrl("/order");
      },err => {
        alert(err.error)
      })
    }
  }

  onSelectProduct(item) {
    this.selectedProducts.push(this.products.find(f => f.id == item.id))
    let productPrice = this.products.find(f => f.id == item.id).price;
    let discount = this.orderForm.get("discount").value;
    let hasDiscount = this.orderForm.get("discount").value > 0
    this.price += productPrice;
    this.totalPrice = hasDiscount ? this.price - (this.price * (discount / 100)) : this.totalPrice + productPrice;

  }

  onDeselectProduct(item) {
    this.selectedProducts = this.selectedProducts.filter(s => s.id != item.id)
    let productPrice = this.products.find(f => f.id == item.id).price;
    let discount = this.orderForm.get("discount").value;
    let hasDiscount = this.orderForm.get("discount").value > 0
    this.price -= productPrice;
    this.totalPrice = hasDiscount ? this.price - (this.price * (discount / 100)) : this.totalPrice - productPrice;
  }

  onSelectAllProducts(item) {
    this.selectedProducts = this.products;
    let productsPrice = this.products.map(x => x.price).reduce((a, b) => a + b, 0);
    let discount = this.orderForm.get("discount").value;
    let hasDiscount = this.orderForm.get("discount").value > 0
    this.price = productsPrice;
    this.totalPrice = hasDiscount ? this.price - (this.price * (discount / 100)) : productsPrice;

  }

  onDeSelectAllProducts(item) {
    this.selectedProducts = [];
    this.price = 0;
    this.totalPrice = 0;
  }

  applyDiscount(discount) {
    console.log(discount)
    this.totalPrice = this.price - (this.price * (discount / 100))
  }

  productDropdownInit() {

    this.productsDropdownSettings = {
      singleSelection: false,
      idField: 'id',
      textField: 'description',
      selectAllText: 'Marcar todos',
      unSelectAllText: 'Desmarcar todos',
      itemsShowLimit: 12,
      allowSearchFilter: true,
      searchPlaceholderText: "Procurar",

    };
  }

  customerDropdownInit() {

    this.customerDropdownSettings = {
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

  getSelectedCustomer() {
    return this.customers.find(f => f.email == this.orderForm.get('customer').value[0].email)
  }


}

