import { Component, OnInit } from '@angular/core';
import { UserDataService } from 'src/app/services/user-data.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-addemployee',
  templateUrl: './addemployee.component.html',
  styleUrls: ['./addemployee.component.scss']
})
export class AddemployeeComponent implements OnInit {


  constructor(private src: UserDataService, private rote: Router) { }

  hide: boolean = false;
  hideed: boolean = false;

  AddEmployee = new FormGroup({
    id: new FormControl(0),
    name: new FormControl('', [Validators.required, Validators.pattern('[a-zA-Z ]+$')]),
    gender: new FormControl('', [Validators.required,Validators.pattern(/\b(Male|Female|male|female)\b/)]),
    age: new FormControl('', [Validators.required, Validators.max(62), Validators.min(18)]),
    salary: new FormControl('', [Validators.required, Validators.pattern(/^-?(0|[1-9]\d*)?$/)]),
    city: new FormControl('', [Validators.required, Validators.pattern('[a-zA-Z ]+$')])
  });
 

  
  get name() { return this.AddEmployee.get('name') }
  get gender() { return this.AddEmployee.get('gender') }
  get age() { return this.AddEmployee.get('age') }
  get salary() { return this.AddEmployee.get('salary') }
  get city() { return this.AddEmployee.get('city') }


  ngOnInit(): void {
    this.hideed = false;
    this.hide = false;
    if (this.src.data != null) {
      this.setvalue();
      this.hide = true;
      this.hideed = false;
      this.src.data = null;
    }
    else {
      this.hideed = true;
      this.hide = false;
      this.AddEmployee.reset();
    }
  }
  

  setvalue() {
    this.AddEmployee.setValue(this.src.data);
    // this.AddEmployee.controls['id'].setValue(this.src.data.id);
    // this.AddEmployee.controls['name'].setValue(this.src.data.name);
    // this.AddEmployee.controls['gender'].setValue(this.src.data.gender);
    // this.AddEmployee.controls['age'].setValue(this.src.data.age);
    // this.AddEmployee.controls['salary'].setValue(this.src.data.salary);
    // this.AddEmployee.controls['city'].setValue(this.src.data.city);
  }

  submitdata() {
    this.hide = false;
    this.hideed = false;
    console.log(this.AddEmployee.value);
    this.AddEmployee.controls.id.setValue(0);
    this.src.AddEmp(this.AddEmployee.value).subscribe((result) => {
      console.log(result);
      this.AddEmployee.reset();
      this.rote.navigate(['employeelist']);
    });
  }

  savedata() {
    this.hideed = false;
    this.hide = false;
    this.src.EditEmp(this.AddEmployee.value).subscribe((result) => {
      console.log(result);
      this.src.data = null;
      this.rote.navigate(['employeelist']);
    });
  }
}