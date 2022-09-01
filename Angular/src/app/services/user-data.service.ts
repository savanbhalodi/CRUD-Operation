import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class UserDataService {

  data:any;
  hide:boolean=true;

  url =" http://localhost:36268/site/";

  constructor(private http:HttpClient) { }
  user()
  {
    return this.http.get(this.url+'GetAllEmployees');
  }
  DeleteEmp(id:number){
    return this.http.delete(this.url+'DeleteEmp/'+id); 
  }
  AddEmp(data:any){
    return this.http.post(this.url+'AddEmployee',data);
  }
  EditEmp(data:any){
    return this.http.put(this.url+'EditEmployee',data);
  }
}