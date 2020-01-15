import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CandidatoGetComponent } from './candidato-get.component';

const routes: Routes = [
    { path: '', component: CandidatoGetComponent }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
  })
  export class CandidatoGetRoutingModule {}