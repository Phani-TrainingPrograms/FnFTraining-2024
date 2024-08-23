import { Routes } from '@angular/router';
import { IndexComponent } from './post/index/index.component';
import { ViewComponent } from './post/view/view.component'
import { CreateComponent } from './post/create/create.component';
import { EditComponent } from './post/edit/edit.component';
import { EmpListComponent } from './employee/emp-list/emp-list.component';

//Here we shall define the possible URLs for our application and map each URL with the component we need to load.
export const routes: Routes = [
    { path : "", redirectTo:'post/index', pathMatch: 'full'},
    { path : 'post/index', component : IndexComponent  },
    { path : 'post/:id/view', component : ViewComponent  },
    { path : 'post/create', component : CreateComponent  },
    { path : 'post/:id/edit', component : EditComponent  },
    {path : 'employeeList', component : EmpListComponent}
];
