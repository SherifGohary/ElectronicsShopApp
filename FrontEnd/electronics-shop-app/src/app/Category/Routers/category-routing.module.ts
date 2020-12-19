import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EditorComponent } from '../Components/editor/editor.component';
import { ListComponent } from '../Components/list/list.component';


const routes: Routes = [
  {
    path: '', pathMatch: 'full', redirectTo: '/category/list'
  },
  {
    path: 'list', 
    // data: { permissionCodes: [+PermissionEnum.brandsList] },
    // canActivate: [AuthGuard], 
    component: ListComponent
  },
  {
    path: 'list/:pageIndex', 
    // data: { permissionCodes: [+PermissionEnum.brandsList] },
    // canActivate: [AuthGuard], 
    component: ListComponent
  },
  {
    path: 'add', 
    // data: { permissionCodes: [+PermissionEnum.addBrand] },
    // canActivate: [AuthGuard], 
    component: EditorComponent
  },
  {
    path: 'edit/:editId', 
    // data: { permissionCodes: [+PermissionEnum.editBrand] },
    // canActivate: [AuthGuard], 
    component: EditorComponent
  },
  {
    path: 'detail/:detailId', 
    // data: { permissionCodes: [+PermissionEnum.brandsList] },
    // canActivate: [AuthGuard], 
    component: EditorComponent
  },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CategoryRoutingModule { }
