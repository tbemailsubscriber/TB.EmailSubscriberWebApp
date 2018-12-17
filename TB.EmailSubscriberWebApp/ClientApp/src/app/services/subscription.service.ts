import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs';
import 'rxjs/add/observable/throw'; 
import 'rxjs/add/operator/catch';

@Injectable()
export class SubscriptionService {

  constructor(private http: Http) { }


  subscribe(subscribtion) {
    return this.http.post('https://localhost:44370/api/subscription/', subscribtion).map(res => res.json()).catch (this.errorHandler);;
  }
  errorHandler(error: Response) {
    console.log(error);
    return Observable.throw(error);
  }
 
}
