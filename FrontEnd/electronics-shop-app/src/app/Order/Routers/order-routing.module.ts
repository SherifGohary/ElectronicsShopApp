import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EditorComponent } from '../Components/editor/editor.component';
import { ListComponent } from '../Components/list/list.component';


const routes: Routes = [
  {
    path: '', pathMatch: 'full', redirectTo: '/order/list'
  },
  {
    path: 'list',
    // canActivate: [AuthGuard], 
    component: ListComponent
  },
  {
    path: 'list/:pageIndex',
    // canActivate: [AuthGuard], 
    component: ListComponent
  },
  {
    path: 'add/:productId',
    // canActivate: [AuthGuard], 
    component: EditorComponent
  },
  {
    path: 'edit/:editId',
    // canActivate: [AuthGuard], 
    component: EditorComponent
  },
  {
    path: 'detail/:detailId',
    // canActivate: [AuthGuard], 
    component: EditorComponent
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OrderRoutingModule { }
