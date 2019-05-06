import { Injectable } from '@angular/core';
import { CanActivate, UrlTree, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { AlertifyjsService } from '../services/alertifyjs.service';


@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router,
              private alertify: AlertifyjsService) {}

  canActivate(): boolean | UrlTree {
    if(this.authService.loggedIn()){
      return true
    }

    this.alertify.error('You shall not pass!!!')
    this.router.navigate(['/home'])
    return false
  }
}
