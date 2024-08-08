import { Component } from '@angular/core';
@Component({
  selector: 'app-calc',
  //standalone: true,
  templateUrl: './calc.component.html'
})
export class CalcComponent {
  //variables for the calc:
  fValue : number = 123.0;
  sValue : number = 13.0;
  result : number = this.fValue + this.sValue;
  operand : string ="+"
  title : string ="My Calc Program"
  
  onGetResult(){
    debugger;
    switch(this.operand){
      case "+" : this.result = this.fValue + this.sValue; break;
      case "-" : this.result = this.fValue - this.sValue; break;
      case "X" : this.result = this.fValue * this.sValue; break;
      case "/" : this.result = this.fValue / this.sValue; break;
    }  
  }  
}
