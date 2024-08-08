import { Component } from '@angular/core';

@Component({
  selector: 'myroot',
  //standalone: true, //new in Ang 17.x so that U dont need a module to refer it. It can be used anywhere within the app
  templateUrl: './approot.html'
})
export class AppComponent {
  title: string = 'My First Angular component';
  developedBy : string = "Phaniraj B.N.";
  btnText: string ="Click Here"

  onClick = () =>{
    alert("Button was clicked")
  }
}
