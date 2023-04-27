import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BuyersComponent } from './buyers/buyers.component';
import { JobsComponent } from './buyers/components/Jobs/Jobs.component';
import { ProvidersComponent } from './buyers/components/providers/providers.component';
import { WorkdiaryComponent } from './buyers/components/workdiary/workdiary.component';
import { LoginComponent } from './core/login/login.component';
import { RegisterComponent } from './core/register/register.component';
import { HomeComponent } from './home/home.component';
import { HomeComponent1 } from './buyers/components/Home/Home.component';
import { ProviderLogsComponent } from './providers/components/provider-logs/provider-logs.component';
import { ForgotPasswordComponent } from './core/forgotPassword/forgotPassword.component';
import { ResetPasswordComponent } from './core/resetPassword/resetPassword.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'register',
    component: RegisterComponent
  },
  {
    path: 'forgot',
    component: ForgotPasswordComponent
  },
  {
    path: 'reset',
    component: ResetPasswordComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

}
