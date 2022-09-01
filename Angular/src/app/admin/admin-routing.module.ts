import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddemployeeComponent } from './addemployee/addemployee.component';
import { BodyComponent } from './body/body.component';
import { EmployeelistComponent } from './employeelist/employeelist.component';

const routes: Routes = [
  {
    path:'',component:BodyComponent
  },
  {
    path:'employeelist',component:EmployeelistComponent
  },
  {
    path:'addemp',component:AddemployeeComponent
  },
  {
    path:'editemp',component:AddemployeeComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
