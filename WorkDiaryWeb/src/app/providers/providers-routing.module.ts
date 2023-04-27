import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProvidersComponent } from './providers.component';
import { ProviderLogsComponent } from './components/provider-logs/provider-logs.component';
import { SettingsComponent } from '../buyers/components/settings/settings.component';
import { ProfileComponentComponent } from '../Shared/components/profileComponent/profileComponent.component';
import { UpdatePasswordComponent } from '../Shared/components/UpdatePassword/UpdatePassword.component';

const routes: Routes = [
  {
    path: 'providers',
    component: ProvidersComponent,
    children: [
      {
        path: '',
        component: ProviderLogsComponent
      },
      {
        path: 'settings',
        component: SettingsComponent,
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
