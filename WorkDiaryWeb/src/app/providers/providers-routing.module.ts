import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProvidersComponent } from './providers.component';
import { ProviderLogsComponent } from './components/provider-logs/provider-logs.component';
import { ProfileComponentComponent } from '../Shared/components/profileComponent/profileComponent.component';
import { UpdatePasswordComponent } from '../Shared/components/UpdatePassword/UpdatePassword.component';
import { JobOffersComponent } from './components/JobOffers/JobOffers.component';
import { AuthGuard } from '../Auth/auth.guard';
import { SettingsComponent } from './components/settings/settings.component';
import { SecurityQtnComponent } from '../buyers/components/settings/securityQtn/securityQtn.component';

const routes: Routes = [
  {
    path: 'providers',
    component: ProvidersComponent,
    children: [
      {
        path: '',
        component: ProviderLogsComponent,
        canActivate: [AuthGuard]
      },
      {
        path: 'logs',
        component: ProviderLogsComponent,
        canActivate: [AuthGuard]
      },
      {
        path: 'Jobs',
        component: JobOffersComponent,
        canActivate: [AuthGuard]
      },
      {
        path: 'settings',
        component: SettingsComponent,
        canActivate: [AuthGuard],
        children: [
          {
            path: '',
            redirectTo: 'profile',
            pathMatch: 'full'
          },
          {
            path: 'profile',
            component: ProfileComponentComponent
          },
          {
            path: 'updatePassword',
            component: UpdatePasswordComponent
          },
          {
            path: 'security',
            component: SecurityQtnComponent
          }
        ]
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProvidersRoutingModule { }
