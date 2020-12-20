import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GridModule } from '@progress/kendo-angular-grid';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { OrderRoutingModule } from '../Routers/order-routing.module';
import { ListComponent } from '../Components/list/list.component';
import { EditorComponent } from '../Components/editor/editor.component';

@NgModule({
  declarations: [
    EditorComponent,
    ListComponent
  ],
  imports: [
    CommonModule,
    OrderRoutingModule,
    GridModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class OrderModule { }
