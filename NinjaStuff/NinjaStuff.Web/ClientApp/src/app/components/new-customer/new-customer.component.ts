import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Customer } from '../../model/customer';
import { CustomerService } from '../../services/customer.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-new-customer',
  templateUrl: './new-customer.component.html',
  styleUrls: ['./new-customer.component.css']
})


export class NewCustomerComponent implements OnInit {

  customerForm = new FormGroup({
    name: new FormControl("", [Validators.required]),

    email: new FormControl("", [
      Validators.required,
      Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$")]),

    village: new FormControl("", [Validators.required])
  })

  constructor(private accountService: CustomerService,

    private router: Router) { }

  ngOnInit() {
  }

  save() {
    if (this.customerForm.invalid) { alert("Preencha os campos obrigatórios") }
    else {
      let customer: Customer = {
        Name: this.customerForm.get('name').value,
        Email: this.customerForm.get('email').value,
        Village: this.customerForm.get('village').value
      }
      this.accountService.post(customer).subscribe((data: any) => {

        this.router.navigateByUrl("/customer");

      }, err => {
        alert(err.error)
      });
    }

  }


}
