import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', loadChildren: '../components/candidato/candidato-list/candidato-list.component.module#CandidatoListModule'},
  { path: 'home', loadChildren: '../components/candidato/candidato-list/candidato-list.component.module#CandidatoListModule'},
  { path: 'get/:id', loadChildren: '../components/candidato/candidato-get/candidato-get.component.module#CandidatoGetModule'},
  { path: 'cadastrar',  loadChildren: '../components/candidato/candidato-create/candidato-create.component.module#CandidatoCreateModule'},
  { path: 'put/:id', loadChildren: '../components/candidato/candidato-update/candidato-update.component.module#CandidatoUpdateModule'},
  // { path: 'put/:id', loadChildren: '../components/candidato/candidato-create/candidato-create.component.module#CandidatoCreateModule'},
  { path: 'exibirResultados', loadChildren: '../components/candidato/candidato-approved/candidato-approved.component.module#CandidatoApprovedModule'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRouteModule { }
