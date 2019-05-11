import { Injectable } from '@angular/core';
declare let alertify: any;
alertify.defaults = {
  notifier:{
  // auto-dismiss wait time (in seconds)
  delay:5,
  // default position
  position:'bottom-right',
  // adds a close button to notifier messages
  closeButton: false
  },

   // language resources
   glossary:{
    // dialogs default title
    title:'AlertifyJS',
    // ok button text
    ok: 'OK',
    // cancel button text
    cancel: 'Cancel'
}

}


@Injectable({
  providedIn: 'root'
})
export class AlertifyjsService {

constructor() { }

confirm(message: string, okCallback: () => any){
  alertify.confirm(message, function(e) {
    if(e){
      okCallback()
    }
    else {}
  })
}

okCallback(){
  alertify.warning('onCallback Called')
}

success(message: string) {
  alertify.notify(message, 'success2')
}

error(message: string) {
  alertify.error(message)
}

warning(message: string) {
  alertify.warning(message)
}

message(message: string) {
  alertify.message(message)
}
notify(message: string) {
  alertify.notify(message, 'custom', 4, () => {console.log('dismissed');});
}

}

