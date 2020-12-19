import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CategoryRoutingModule } from '../Routers/category-routing.module';
import { GridModule } from '@progress/kendo-angular-grid';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { ListComponent } from '../Components/list/list.component';
import { EditorComponent } from '../Components/editor/editor.component';

@NgModule({
  declarations: [
    ListComponent,
    EditorComponent,
  ],
  imports: [
    CommonModule,
    CategoryRoutingModule,
    GridModule,
    ReactiveFormsModule,
    FormsModule,
    
  ]
})
export class CategoryModule { }
