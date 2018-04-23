import { Injectable, OnInit } from '@angular/core';
import { Http } from '@angular/http';
declare let document:Document;

@Injectable()
export class ApiStudyService implements OnInit {  
   baseUrl:string = "http://localhost:5000/"

   constructor(private http: Http) {   
    }

    ngOnInit(): void { 
        console.log(this.baseUrl);
    }
  

  search(term:string, pageIndex:number, pageSize:number){
    return this.http.get(this.baseUrl + 'api/products', {
            "params":{
                "pageIndex": pageIndex,
                "pageSize":  pageSize,
                "term" : term
            }
        });
  }
}