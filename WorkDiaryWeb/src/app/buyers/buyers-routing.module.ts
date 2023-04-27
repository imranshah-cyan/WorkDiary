import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from '../home/home.component';
import { BuyersComponent } from './buyers.component';
import { HomeComponent1 } from './components/Home/Home.component';
import { JobsComponent } from './components/Jobs/Jobs.component';
import { PostJobComponent } from './components/PostJob/PostJob.component';
import { ProviderCardComponent } from './components/provider-card/provider-card.component';
import { ProvidersComponent } from './components/providers/providers.component';
import { WorkdiaryComponent } from './components/workdiary/workdiary.component';
import { SettingsComponent } from './components/settings/settings.component';
import { ProfileComponentComponent } from '../Shared/components/profileComponent/profileComponent.component';
import { UpdatePasswordComponent } from '../Shared/components/UpdatePassword/UpdatePassword.component';

const routes: Routes = [
  {
    path: 'buyers',
    component: BuyersComponent,
    children: [
      {
        path: '',
        component: HomeComponent1,
      },
      {
        path: 'home',
        component: HomeComponent1
      },
      {
        path: 'jobs',
        component: JobsComponent
      },
      {
        path: 'postjobs',
        component: PostJobComponent
      },
      {
        path: 'providers',
        component: ProvidersComponent
      },
      {
        path: 'providercard',
        component: ProviderCardComponent
      },
      {
        path: 'workdiary',
        component: WorkdiaryComponent
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
export class BuyersRoutingModule { }
