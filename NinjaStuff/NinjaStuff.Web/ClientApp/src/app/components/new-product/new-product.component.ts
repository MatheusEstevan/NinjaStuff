import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Product } from 'src/app/model/product';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-new-product',
  templateUrl: './new-product.component.html',
  styleUrls: ['./new-product.component.css']
})
export class NewProductComponent implements OnInit {

  productForm = new FormGroup({
    description: new FormControl("", [Validators.required]),
    price: new FormControl("", [Validators.required]),
    picture: new FormControl("", [Validators.required])
  })

  constructor(private productService: ProductService,

    private router: Router) { }

  ngOnInit() {
  }

  save() {
    if(this.productForm.invalid){
      alert("Preencha os campos obrigatórios");
    }else{
      let product:  Product = {
        Description: this.productForm.get('description').value,
        Price:this.productForm.get('price').value,
        Picture: this.productForm.get('picture').value
      }
      this.productService.post(product).subscribe((data: any) => {
  
        this.router.navigateByUrl("/product");
  
      }, err => {
        alert(err.error)
      });
    }
   
  }

}
