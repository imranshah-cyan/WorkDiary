import { NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './core/login/login.component';
import { RegisterComponent } from './core/register/register.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import {} from '@angular/material/button';
import {} from '@angular/material/button';
import { } from '@angular/material/button';
import { HomeComponent } from './home/home.component';
import { ProviderHeaderComponent } from './providers/components/provider-header/provider-header.component';
import { HeaderComponent } from './core/header/header.component';
import { FooterComponent } from './core/footer/footer.component';
import { BuyersModule } from './buyers/buyers.module';
import { BuyersRoutingModule } from './buyers/buyers-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { ProvidersRoutingModule } from './providers/providers-routing.module';
import { ProvidersModule } from './providers/providers.module';
import { CommonModule, DatePipe } from '@angular/common';
import { ForgotPasswordComponent } from './core/forgotPassword/forgotPassword.component';
import { ResetPasswordComponent } from './core/resetPassword/resetPassword.component';
import { ToastrModule } from 'ngx-toastr';
import { UpdatePasswordComponent } from './Shared/components/UpdatePassword/UpdatePassword.component';
import { JobOffersComponent } from './providers/components/JobOffers/JobOffers.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    ForgotPasswordComponent,
    ResetPasswordComponent,
    HomeComponent,
    ProviderHeaderComponent,
    HeaderComponent,
    FooterComponent,
    UpdatePasswordComponent,
    JobOffersComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    MatButtonModule,
    MatSelectModule,
    BuyersModule,
    BuyersRoutingModule,
    HttpClientModule,
    ProvidersModule,
    ProvidersRoutingModule,
    ToastrModule
  ],
  providers: [DatePipe],
  schemas: [NO_ERRORS_SCHEMA],
  bootstrap: [AppComponent]
})
export class AppModule { }
