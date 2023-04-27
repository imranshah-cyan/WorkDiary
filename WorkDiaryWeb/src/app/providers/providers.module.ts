import { NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RouterModule } from '@angular/router';

import { MatMenuModule } from '@angular/material/menu';

import { ProvidersRoutingModule } from './providers-routing.module';
import { ProvidersComponent } from './providers.component';
import { ProviderLogsComponent } from './components/provider-logs/provider-logs.component';
import { LogSessionComponent } from './components/log-session/log-session.component';
import { SettingsComponent } from '../buyers/components/settings/settings.component';


@NgModule({
  declarations: [
    ProvidersComponent,
    ProviderLogsComponent,
    LogSessionComponent,
    SettingsComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    ProvidersRoutingModule,
    MatMenuModule,
  ],
  schemas: [NO_ERRORS_SCHEMA],
  exports: [
    RouterModule,
  ]
})
export class ProvidersModule { }
