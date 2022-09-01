import { Component, OnInit } from '@angular/core';
import { Route } from '@angular/router';
import { UserDataService } from 'src/app/services/user-data.service';


@Component({
  selector: 'app-employeelist',
  templateUrl: './employeelist.component.html',
  styleUrls: ['./employeelist.component.scss']
})
export class EmployeelistComponent implements OnInit {

  item: any;
  searchtext:any;

  constructor(private src: UserDataService) {
  }

  ngOnInit(): void {

    this.src.user().subscribe((data) => {
      console.warn("data", data);
      this.item = data
    });
  }
  onDelete(id: number) {
    this.src.DeleteEmp(id).subscribe(x => {

      window.alert("Employee Delete Succesfully");
      this.ngOnInit();
    })
  }

  getData(data:any){
    this.src.data = data;
  }

}