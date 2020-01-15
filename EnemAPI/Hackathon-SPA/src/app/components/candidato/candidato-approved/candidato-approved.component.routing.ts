import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CandidatoApprovedComponent } from './candidato-approved.component';

const routes: Routes = [
    { path: '', component: CandidatoApprovedComponent }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
  })
  export class CandidatoApprovedRoutingModule {}