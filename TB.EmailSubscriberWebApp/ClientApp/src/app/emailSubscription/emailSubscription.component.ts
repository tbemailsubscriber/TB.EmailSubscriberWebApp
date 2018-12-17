import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { TopicService } from '../services/topic.service';
import { SubscriptionService } from '../services/subscription.service';
import { NotificationsService } from '../services/notifications.service';
import { HttpErrorResponse, HttpResponse } from '@angular/common/http';

@Component({
  selector: 'app-emailSubscription',
  templateUrl: './emailSubscription.component.html',
})
export class EmailSubscription implements OnInit {

  topics: any[];
  errorMessage: any;
  response: any;
  subscription: Subscription = {
    email: '',
    topics: [],
  };
  constructor( private _topicService: TopicService, private _subscriptionService: SubscriptionService, private _notificationsService: NotificationsService)
  {
    
  }

  ngOnInit() {
    this.getTopics();
  }

  getTopics() {
    this._topicService.getTopics().subscribe(topics => this.topics = topics)
  }  

  onTopicToggle(topicId, $event) {
    if ($event.target.checked)
      this.subscription.topics.push(topicId);
    else {
      var index = this.subscription.topics.indexOf(topicId);
      this.subscription.topics.splice(index, 1);
    }
  }

  subscribe() {
    if (this.subscription.topics.length != 0) {
      this._subscriptionService.subscribe(this.subscription)
        .subscribe((response: CustomResponse) => {
          if (response.code == 200) {
            this._notificationsService.notify("success", 'Subscription succesfull: ', response.message);
            this.subscription.email = '';
          }
          else
            this._notificationsService.notify("error", 'Subscription unsuccesfull with code (' + response.code+'): ', response.message);
        },
        (error) => {
          this._notificationsService.notify("error", 'Subscription unsuccesfull: ', error.message);
          }
        );

    }
    else
    {
      this._notificationsService.notify("warn", 'Subscription :', "Plese select one topic or more.");
    }
  }

}

export interface CustomResponse
{
  code: number;
  message: string;
  }

export interface Subscription {
  email: string;
  topics: KeyValuePair[];
}
export interface KeyValuePair {
  id: number;
  name: string;
}
