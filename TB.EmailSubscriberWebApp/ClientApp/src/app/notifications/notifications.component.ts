import { Component, OnInit, OnDestroy } from '@angular/core';
import { Message, GrowlModule, MessageModule, MessagesModule } from 'primeng/primeng';
import { Subscription } from 'rxjs/Subscription';
import { NotificationsService } from '../services/notifications.service';

@Component({
  selector: 'app-notifications',
  templateUrl: './notifications.component.html',
  styleUrls: ['./notifications.component.css']
})
export class NotificationsComponent implements OnInit, OnDestroy {
  msgs: Message[] = [];
  subscription: Subscription;

  constructor(private notificationsService: NotificationsService) { }

  ngOnInit() {
    this.subscribeToNotifications();
  }

  subscribeToNotifications() {
    this.subscription = this.notificationsService.notificationChange
      .subscribe(notification => {
        this.msgs.length = 0;
        this.msgs.push(notification);
      });
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
