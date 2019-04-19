import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Input() valuesFromHome: any // to receive from a parent component
  @Output() cancelRegister = new EventEmitter()
  registerModel: any = {}
  constructor() { }

  ngOnInit() {
  }

  register() {
    console.log(this.registerModel)
  }

  cancel() {
    this.cancelRegister.emit(false)
    console.log('cancelled')
  }
}
