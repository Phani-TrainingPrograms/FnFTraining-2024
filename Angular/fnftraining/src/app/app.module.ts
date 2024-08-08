import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule } from "@angular/forms";

import { AppComponent } from "./app.component";
import { CalcComponent } from "./Components/calc/calc.component";
import { MasterComponent } from "./Components/master/master.component";
import { EmpDetailComponent } from "./Components/emp-detail/emp-detail.component";

//Any Angular App is made of one or more Modules and each module is made up with one or more components supported by models(data), interfaces(Contracts), pipes(filters), services(http) and custom directives(UR own logical components).

@NgModule({
    declarations:[
        AppComponent,
        CalcComponent,
        MasterComponent,
        EmpDetailComponent
    ],
    imports:[
        BrowserModule, FormsModule
    ],
    providers:[],
    bootstrap: [AppComponent, CalcComponent, MasterComponent]
})
export class AppModule{}