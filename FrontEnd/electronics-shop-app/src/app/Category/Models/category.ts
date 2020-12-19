import { Product } from "src/app/Product/Models/product";

export class Category {
    id: number;
    creationDate: Date;
    modificationDate: Date;
    name: string
    Products: Product[];
}
