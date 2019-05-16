import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { User } from '../models/user';
import { UserService } from '../services/user.service';
import { AlertifyjsService } from '../services/alertifyjs.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class MemberDetailResolver implements Resolve<User> {
  constructor(private userService: UserService,
    private router: Router, private alerify: AlertifyjsService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<User> {
      return this.userService.getUserById(route.params['id']).pipe(
        catchError(error => {
          this.alerify.error('Problem retrieving data');
          this.router.navigate(['/members']);
          return of(null);
        })
      )
    }
}
