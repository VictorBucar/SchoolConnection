import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { AlertifyjsService } from '../services/alertifyjs.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Input() valuesFromHome: any // to receive from a parent component
  @Output() cancelRegister = new EventEmitter()
  registerModel: any = {}
  constructor(private authService: AuthService, private alerify: AlertifyjsService) { }

  ngOnInit() {
  }

  register() {
    console.log(this.registerModel)
    this.authService.register(this.registerModel).subscribe(() => {
      //console.log('registered')
      this.alerify.success('Registration successful')
    }, error => {
      //console.log(error)
      this.alerify.error(error)
    })
  }

  cancel() {
    this.cancelRegister.emit(false)
    console.log('cancelled')
  }
}
