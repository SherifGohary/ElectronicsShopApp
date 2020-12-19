import { Category } from "src/app/Category/Models/category";

export class Product {
    id: number;
    creationDate: Date;
    modificationDate: Date;
    createdByUserId: number;
    modifiedByUserId: number;
    name: string
    price: any;
    discount: number;
    twoPiecesDiscount: number;
    count: number;
    description: string
    categoryId: number;
    categoryName: Category;
}
