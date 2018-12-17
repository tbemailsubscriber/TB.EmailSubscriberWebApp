import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class TopicService {

  constructor(private http: Http) { }

  getTopics() {
    return this.http.get('https://localhost:44370/api/Topic').map(res => res.json());
  }
}
