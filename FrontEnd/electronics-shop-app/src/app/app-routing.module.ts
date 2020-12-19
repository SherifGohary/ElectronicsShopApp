import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  { path: "", pathMatch: "full", redirectTo: "/product" },
  //{path: '', pathMatch: 'full', redirectTo: '/financial/financial-list'},
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
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
