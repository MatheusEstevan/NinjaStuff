import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  constructor(private productSvc: ProductService) { }
  public products: any[] = [];

  ngOnInit() {

    this.productSvc.get().subscribe((data: any) => {
    
      this.products = data
      console.log(this.products)
      
    })
    
  }
}
