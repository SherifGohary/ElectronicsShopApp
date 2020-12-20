import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  { path: "", pathMatch: "full", redirectTo: "/product" },
  {
    path: "product",
    loadChildren:
      "src/app/Product/Modules/product.module#ProductModule",
  },
  {
    path: "category",
    loadChildren:
      "src/app/Category/Modules/category.module#CategoryModule",
  },
  {
    path: "user",
    loadChildren:
      "src/app/User/Modules/user.module#UserModule",
  },
  {
    path: "order",
    loadChildren:
      "src/app/Order/Modules/order.module#OrderModule",
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
