import { Order } from "src/app/Order/Models/order";
import { Role } from "./role.enum";

export class User {
    id: number;
    creationDate: Date;
    modificationDate: Date;
    fullName: string;
    userName: string;
    password: string;
    email: string;
    country: string;
    city: string;
    address: string;
    birthDate: Date;
    phoneNumber: string;
    role: Role;
    orders: Order[];
}