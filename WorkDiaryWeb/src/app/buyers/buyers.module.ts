import { NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';

import { RouterModule } from '@angular/router';

import { BuyersRoutingModule } from './buyers-routing.module';
import { BuyersComponent } from './buyers.component';
import { ProviderCardComponent } from './components/provider-card/provider-card.component';

import { MatMenuModule } from '@angular/material/menu';
import { AppLogSessionComponent } from './components/app-log-session/app-log-session.component';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { JobsComponent } from './components/Jobs/Jobs.component';
import { HomeComponent1 } from './components/Home/Home.component';
import { ProviderProfileComponent } from './components/provider-profile/provider-profile.component';
import { ProvidersComponent } from './components/providers/providers.component';
import { JobDetailsComponent } from './components/job-details/job-details.component';
import { JobOffersComponent } from './components/job-offers/job-offers.component';
import { WorkdiaryComponent } from './components/workdiary/workdiary.component';
import { FormsModule } from '@angular/forms';
import { PostJobComponent } from './components/PostJob/PostJob.component';
import { ProjectTeamComponent } from './components/settings/ProjectTeam/ProjectTeam.component';
import { ToastrModule } from 'ngx-toastr';
import { SecurityQtnComponent } from './components/settings/securityQtn/securityQtn.component';
import { SettingsComponent } from './components/settings/settings.component';

@NgModule({
  declarations: [
    BuyersComponent,
    ProviderCardComponent,
    AppLogSessionComponent,
    JobsComponent,
    HomeComponent1,
    ProviderProfileComponent,
    ProvidersComponent,
    JobDetailsComponent,
    JobOffersComponent,
    WorkdiaryComponent,
    PostJobComponent,
    ProjectTeamComponent,
    SecurityQtnComponent,
    SettingsComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    FormsModule,
    BuyersRoutingModule,
    MatMenuModule,
    HttpClientModule,
    ToastrModule.forRoot(),
  ],
  schemas: [NO_ERRORS_SCHEMA],
  exports: [
    ProviderCardComponent,
    RouterModule,
  ]
})
export class BuyersModule { }
