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
import { ProviderProfileComponent } from './components/provider-profile/provider-profile.component';
import { JobDetailsComponent } from './components/job-details/job-details.component';
import { JobOffersComponent } from './components/job-offers/job-offers.component';
import { ProjectTeamComponent } from './components/settings/ProjectTeam/ProjectTeam.component';
import { SecurityQtnComponent } from './components/settings/securityQtn/securityQtn.component';
import { AuthGuard } from '../Auth/auth.guard';

const routes: Routes = [
  {
    path: 'buyers',
    component: BuyersComponent,
    children: [
      {
        path: '',
        component: HomeComponent1,
        canActivate: [AuthGuard]
      },
      {
        path: 'home',
        component: HomeComponent1,
        canActivate: [AuthGuard]
      },
      {
        path: 'jobs',
        component: JobsComponent,
        canActivate: [AuthGuard]
      },
      {
        path: 'postjobs',
        component: PostJobComponent,
        canActivate: [AuthGuard]
      },
      {
        path: 'providers',
        component: ProvidersComponent,
        canActivate: [AuthGuard]
      },
      {
        path: 'providercard',
        component: ProviderCardComponent,
        canActivate: [AuthGuard]
      },
      {
        path: 'offers',
        component: JobOffersComponent,
        canActivate: [AuthGuard]
      },
      {
        path: 'workdiary',
        component: WorkdiaryComponent,
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
          },
          {
            path: 'projectTeam',
            component: ProjectTeamComponent
          }
        ]
      },
      {
        path: 'provProfile',
        component: ProviderProfileComponent
      },
      {
        path: 'jobDetails',
        component: JobDetailsComponent
      }
    ]
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BuyersRoutingModule { }
