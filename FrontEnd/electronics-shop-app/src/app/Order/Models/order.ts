import { Product } from "src/app/Product/Models/product";
import { User } from "src/app/User/Models/user";

export class Order {
    id: number;
    creationDate: Date;
    modificationDate: Date;
    productId: number;
    product: Product;
    userId: number;
    user: User;
    numberOfItems: number;
    totalAmount: number;
}