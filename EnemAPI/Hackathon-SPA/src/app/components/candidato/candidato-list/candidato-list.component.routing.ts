import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CandidatoListComponent } from './candidato-list.component';

const routes: Routes = [
    { path: '', component: CandidatoListComponent }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
  })
  export class CandidatoListRoutingModule {}