import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './auth/feature/login/login.component';
import { SignupComponent } from './auth/feature/signup/signup.component';
import { CommentsListComponent } from './comments/feature/comments-list/comments-list.component';

const routes: Routes = [
  {path: '', pathMatch: 'full', redirectTo: 'comments'},
  {path: 'auth/login', component: LoginComponent},
  {path: 'auth/signup', component: SignupComponent},
  {path: 'comments', component: CommentsListComponent},
  {path: '**', redirectTo: 'comments'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {useHash: true})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
