import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { AlertifyjsService } from '../services/alertifyjs.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  loginModel: any = {};

  constructor(public authService: AuthService, private alertify: AlertifyjsService,
    private router: Router) { }

  ngOnInit() {
  }

  login() {
    this.authService.login(this.loginModel).subscribe(next => {
      // console.log('logged in successfully')
       this.alertify.success('Logged in successfully')
    }, error => {
      this.alertify.error(error)
    }, () => {
      this.router.navigate(['/schools'])
    });
  }

  loggedIn() {
    return this.authService.loggedIn()
  }
  logout() {
    localStorage.removeItem('token')
    //console.log('logged out')
    this.alertify.message('Logged out')
    this.router.navigate(['/home'])
  }
}
