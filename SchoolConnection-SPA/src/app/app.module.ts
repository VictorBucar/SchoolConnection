import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { HttpClientModule } from '@angular/common/http';
import { AuthService } from './services/auth.service';
import { RegisterComponent } from './register/register.component';
import { HomeComponent } from './home/home.component';

import { ErrorInterceptorProvider } from './services/error.interceptor';
import { AlertifyjsService } from './services/alertifyjs.service';
import { SchoolListComponent } from './school-list/school-list.component';
import { ListsComponent } from './lists/lists.component';
import { MessagesComponent } from './messages/messages.component';
import { appRoutes } from './routes';
import { AuthGuard } from './guards/auth.guard';
import { UserService } from './services/user.service';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MemberCardComponent } from './members/member-card/member-card.component';



@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      RegisterComponent,
      HomeComponent,
      SchoolListComponent,
      ListsComponent,
      MessagesComponent,
      MemberListComponent,
      MemberCardComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      HttpClientModule,
      FormsModule,
      BsDropdownModule.forRoot(),
      RouterModule.forRoot(appRoutes)
   ],
   providers: [
      AuthService,
      ErrorInterceptorProvider,
      AlertifyjsService,
      AuthGuard,
      UserService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
