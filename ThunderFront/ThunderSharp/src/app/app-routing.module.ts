import { DashboardComponent } from './dashboard/dashboard.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { ActorHomeComponent } from './actor-home/actor-home.component';
const routes: Routes = [
  {path: '', component: LoginComponent},
  {path: 'actorhome', component: ActorHomeComponent},
  {path: 'dashboard', component: DashboardComponent},


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
