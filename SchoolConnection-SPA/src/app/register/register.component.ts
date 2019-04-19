import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Input() valuesFromHome: any // to receive from a parent component
  @Output() cancelRegister = new EventEmitter()
  registerModel: any = {}
  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  register() {
    console.log(this.registerModel)
    this.authService.register(this.registerModel).subscribe(() => {
      console.log('registered')
    }, error => {
      console.log(error)
    })
  }

  cancel() {
    this.cancelRegister.emit(false)
    console.log('cancelled')
  }
}
