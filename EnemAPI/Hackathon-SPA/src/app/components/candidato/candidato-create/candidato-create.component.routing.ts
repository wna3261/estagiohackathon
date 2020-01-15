import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CandidatoCreateComponent } from './candidato-create.component';

const routes: Routes = [
    { path: '', component: CandidatoCreateComponent }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
  })
  export class CandidatoCreateRoutingModule {}