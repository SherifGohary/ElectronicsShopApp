import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from '../Routers/user-routing.module';
import { ListComponent } from '../Components/list/list.component';
import { EditorComponent } from '../Components/editor/editor.component';
import { GridModule } from '@progress/kendo-angular-grid';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { LoginComponent } from '../Components/login/login.component';
// import { BsDatepickerModule } from 'ngx-bootstrap';

@NgModule({
  declarations: [
    ListComponent,
    EditorComponent,
    LoginComponent
  ],
  imports: [
    CommonModule,
    UserRoutingModule,
    GridModule,
    ReactiveFormsModule,
    FormsModule,
    DropDownsModule,
    // BsDatepickerModule
  ]
})
export class UserModule { }
