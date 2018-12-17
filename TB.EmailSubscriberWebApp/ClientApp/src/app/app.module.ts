import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ToastyModule } from "ng2-toasty"
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { EmailSubscription } from './emailSubscription/emailSubscription.component';
import { TopicService } from './services/topic.service';
import { HttpModule } from '@angular/http';
import { SubscriptionService } from './services/subscription.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NotificationsComponent } from './notifications/notifications.component';
import { NotificationsService } from './services/notifications.service';
import { CommonModule } from '@angular/common';
import { GrowlModule, MessageModule, MessagesModule } from 'primeng/primeng';
import { UnsubscribeComponent } from './unsubscribe/unsubscribe.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    EmailSubscription,
    NotificationsComponent,
    UnsubscribeComponent,
    ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserModule,
    CommonModule,
    BrowserAnimationsModule,
    HttpClientModule,
    HttpModule,
    GrowlModule,
    BrowserAnimationsModule,
    MessageModule, MessagesModule,
    FormsModule,
    ToastyModule.forRoot(),
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'emailSubscription', component: EmailSubscription },
    ])
  ],
  providers: [
    TopicService,
    SubscriptionService,
    NotificationsService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
