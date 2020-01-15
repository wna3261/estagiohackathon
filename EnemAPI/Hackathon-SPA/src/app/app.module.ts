import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRouteModule } from './app-route/app-route.module';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { CandidatoService } from './_services/candidato.service';
import { ModalModule } from 'ngx-bootstrap/modal';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
   declarations: [
      AppComponent
   ],
   imports: [
      BrowserModule,
      AppRouteModule,
      FormsModule,
      HttpClientModule,
      BrowserAnimationsModule,
      ToastrModule.forRoot(),
      ModalModule.forRoot()
   ],
   providers: [
      CandidatoService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
