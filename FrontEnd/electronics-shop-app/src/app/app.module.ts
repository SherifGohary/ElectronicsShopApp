import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavigationModule } from '@progress/kendo-angular-navigation';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { IconsModule } from '@progress/kendo-angular-icons';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { IndicatorsModule } from '@progress/kendo-angular-indicators';
import { LayoutModule } from '@progress/kendo-angular-layout';
import { GridModule } from '@progress/kendo-angular-grid';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { ToastrModule } from 'ngx-toastr'







// import { ListComponent } from './Category/Components/list/list.component';
// import { EditorComponent } from './Category/Components/editor/editor.component';
// import { ListComponent } from './Product/Components/list/list.component';
// import { EditorComponent } from './Product/Components/editor/editor.component';

@NgModule({
  declarations: [
    AppComponent,
    // ListComponent,
    // EditorComponent,
    // ListComponent,
    // EditorComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NavigationModule,
    BrowserAnimationsModule,
    IconsModule,
    InputsModule,
    IndicatorsModule,
    LayoutModule,
    GridModule,
    DropDownsModule,
    ToastrModule.forRoot(),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
