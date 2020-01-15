import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CandidatoUpdateComponent } from './candidato-update.component';
import { CandidatoUpdateRoutingModule } from './candidato-update.component.routing';

@NgModule({
    imports: [
      CommonModule,
      CandidatoUpdateRoutingModule,
      FormsModule
    ],
    declarations: [
      CandidatoUpdateComponent
    ]
  })
  export class CandidatoUpdateModule { }