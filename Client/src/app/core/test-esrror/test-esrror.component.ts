import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-test-esrror',
  templateUrl: './test-esrror.component.html',
  styleUrls: ['./test-esrror.component.scss']
})
export class TestEsrrorComponent implements OnInit {

  baseUrl = environment.apiUrl;
  validationErrors: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }

  get404Error(){
    this.http.get(this.baseUrl + "products/42").subscribe(res => {
      console.log(res);
    }, error => {
      console.log(error);
    });
  }

  get500Error(){
    this.http.get(this.baseUrl + "buggy/servererror").subscribe(res => {
      console.log(res);
    }, error => {
      console.log(error);
    });
  }

  get400Error(){
    this.http.get(this.baseUrl + "buggy/badrequest").subscribe(res => {
      console.log(res);
    }, error => {
      console.log(error);
    });
  }

  get400ValidationError(){
    this.http.get(this.baseUrl + "products/fartytwo").subscribe(res => {
      console.log(res);
    }, error => {
      console.log(error);
      this.validationErrors = error.errors;
    });
  }

}
