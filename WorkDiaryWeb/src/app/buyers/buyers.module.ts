import { NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RouterModule } from '@angular/router';

import { BuyersRoutingModule } from './buyers-routing.module';
import { BuyersComponent } from './buyers.component';
import { ProviderCardComponent } from './components/provider-card/provider-card.component';

import { MatMenuModule } from '@angular/material/menu';
import { SettingsComponent } from './components/settings/settings.component';
import { AppLogSessionComponent } from './components/app-log-session/app-log-session.component';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { JobsComponent } from './components/Jobs/Jobs.component';

@NgModule({
  declarations: [
    BuyersComponent,
    ProviderCardComponent,
    AppLogSessionComponent,
    JobsComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    BuyersRoutingModule,
    MatMenuModule,
    HttpClientModule
  ],
  schemas: [NO_ERRORS_SCHEMA],
  exports: [
    ProviderCardComponent,
    RouterModule,
  ]
})
export class BuyersModule { }
