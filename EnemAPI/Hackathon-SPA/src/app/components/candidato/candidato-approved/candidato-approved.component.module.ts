import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CandidatoApprovedComponent } from './candidato-approved.component';
import { CandidatoApprovedRoutingModule } from './candidato-approved.component.routing';

@NgModule({
    imports: [
      CommonModule,
      CandidatoApprovedRoutingModule,
      FormsModule
    ],
    declarations: [
      CandidatoApprovedComponent
    ]
  })
  export class CandidatoApprovedModule { }