import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { AlertifyjsService } from '../services/alertifyjs.service';


@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  loginModel: any = {};

  constructor(public authService: AuthService, private alertify: AlertifyjsService) { }

  ngOnInit() {
  }

  login() {
    this.authService.login(this.loginModel).subscribe(next => {
      // console.log('logged in successfully')
       this.alertify.success('Logged in successfully')
    }, error => {
      this.alertify.error(error)
    });
  }

  loggedIn() {
    return this.authService.loggedIn()
  }
  logout() {
    localStorage.removeItem('token')
    //console.log('logged out')
    this.alertify.message('Logged out')
  }
}
