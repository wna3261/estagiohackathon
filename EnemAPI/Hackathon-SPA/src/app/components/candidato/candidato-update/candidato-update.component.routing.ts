import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CandidatoUpdateComponent } from './candidato-update.component';

const routes: Routes = [
    { path: '', component: CandidatoUpdateComponent }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
  })
  export class CandidatoUpdateRoutingModule {}