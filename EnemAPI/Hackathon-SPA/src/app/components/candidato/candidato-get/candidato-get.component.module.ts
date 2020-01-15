import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CandidatoGetComponent } from './candidato-get.component';
import { CandidatoGetRoutingModule } from './candidato-get.component.routing';

@NgModule({
    imports: [
      CommonModule,
      CandidatoGetRoutingModule,
      FormsModule
    ],
    declarations: [
      CandidatoGetComponent
    ]
  })
  export class CandidatoGetModule { }