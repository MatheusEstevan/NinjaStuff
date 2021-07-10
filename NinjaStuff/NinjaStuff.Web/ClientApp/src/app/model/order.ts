
import { Customer } from "./customer"
import { Product } from "./product"

export class Order {
    Id: number;
    Date: Date;
    Discount: number;
    Price: number;
    TotalPrice: number;
    CustomerEmail: string;
    Customer: Customer;
    Products: Array<Product>;
}