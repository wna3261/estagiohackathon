import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CandidatoCreateComponent } from './candidato-create.component';
import { CandidatoCreateRoutingModule } from './candidato-create.component.routing';

@NgModule({
    imports: [
      CommonModule,
      CandidatoCreateRoutingModule,
      FormsModule
    ],
    declarations: [
      CandidatoCreateComponent
    ]
  })
  export class CandidatoCreateModule { }