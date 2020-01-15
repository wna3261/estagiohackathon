import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CandidatoListComponent } from './candidato-list.component';
import { CandidatoListRoutingModule } from './candidato-list.component.routing';

@NgModule({
    imports: [
      CommonModule,
      CandidatoListRoutingModule,
      FormsModule
    ],
    declarations: [
      CandidatoListComponent
    ]
  })
  export class CandidatoListModule { }