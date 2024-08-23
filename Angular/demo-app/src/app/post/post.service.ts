import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Post } from './post';
import { catchError, Observable } from 'rxjs';
//A service in Angular is a class whose object could be injected into any component within the Angular and use its methods and data. We use services to create singleton objects that can be refered accross the components of the Angular Application. 

//We have an Injectable directive that allows the objects of this class injected into the components, this is the DI of Angular. 
//This service will create methods for interacting with the REST API by using the HttpClient object and try to call the HTTP Methods: GET, POST, PUT and DELETE.
//providedIn root will make this service available at the root level(Top Most) of the Angular App, this feature is made available from Ang-5. 
@Injectable({
  providedIn: 'root'
})
export class PostService {
  //constructors in angular is typically used to inject additional components into the class. 
  private baseAddress : string = "http://localhost:3000/posts"
  httpOptions = {
    headers : new HttpHeaders({
      'Content-type' : 'application/json'
    })
  }
  constructor(private httpClient : HttpClient) {
    
   }

   //Function to HttpPost.
   create(post : Post) : Observable<any>{
     const url = `${this.baseAddress}`
     return this.httpClient.post(url, JSON.stringify(post), this.httpOptions );
   }

   getAll() : Observable<any>{
    return this.httpClient.get(this.baseAddress);
    }

   find(id : number ) : Observable<any>{
    return this.httpClient.get(this.baseAddress + "/" + id);
   }

   update(id : number, post:Post) : Observable<any>{
    return this.httpClient.put(this.baseAddress +"/" + id, JSON.stringify(post), this.httpOptions);
   }

   delete(id : number) : Observable<any>{
    return this.httpClient.delete(this.baseAddress + "/" + id, this.httpOptions)
   }
}
