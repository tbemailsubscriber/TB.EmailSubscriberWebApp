import { Component, OnInit } from '@angular/core';
import { SubscriptionService } from '../services/subscription.service';
import { NotificationsService } from '../services/notifications.service';

@Component({
  selector: 'app-unsubscribe',
  templateUrl: './unsubscribe.component.html',
  styleUrls: ['./unsubscribe.component.css']
})
export class UnsubscribeComponent implements OnInit {

  constructor(private _subscriptionService: SubscriptionService, private _notificationsService: NotificationsService) { }

  ngOnInit()
  {

  }

}
