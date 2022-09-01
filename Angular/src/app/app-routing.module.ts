import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddemployeeComponent } from './admin/addemployee/addemployee.component';
import { AdminModule } from './admin/admin.module';
import { BodyComponent } from './admin/body/body.component';
import { EmployeelistComponent } from './admin/employeelist/employeelist.component';

const routes: Routes = [
  {
    path:'',loadChildren:()=> import('./admin/admin.module').then(x=>x.AdminModule)
  }
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
