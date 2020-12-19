import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListComponent } from './../../Product/Components/list/list.component';
import { EditorComponent } from './../../Product/Components/editor/editor.component';
import { GridModule } from '@progress/kendo-angular-grid';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { ProductRoutingModule } from '../Routers/product-routing.module';


@NgModule({
  declarations: [
    ListComponent,
    EditorComponent
  ],
  imports: [
    CommonModule,
    ProductRoutingModule,
    GridModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class ProductModule { }
