import { Component, OnInit, TemplateRef } from '@angular/core';
import { CandidatoService } from '../../../_services/candidato.service';
import { Router } from '@angular/router';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-candidato-list',
  templateUrl: './candidato-list.component.html',
  styleUrls: ['./candidato-list.component.scss']
})

export class CandidatoListComponent implements OnInit {
  public candidatos: any;
  private modalRef: BsModalRef;

  constructor(
    private candidatoService: CandidatoService,
    private modalService: BsModalService,
    private router: Router) { }

  ngOnInit() {
    this.listarCandidatos();
  }

  public openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }
  
  public decline(): void {
    this.modalRef.hide();
  }

  private listarCandidatos() {
    this.candidatoService.listarCandidatos().subscribe(response => {
      this.candidatos = response;
    }, error => {
      console.log(error);
    });
  }

  public getCandidato(id: any) {
    this.router.navigate(['get/', id]);
  }

  public atualizarCandidato(id: any) {
    this.router.navigate(['put/', id]);
  }

  public deletarCandidato(id: any) {
    this.candidatoService.deletarCandidato(id).subscribe(data => {
      this.listarCandidatos();
    }, error => {
      console.log(error);
    });
    this.modalRef.hide();
  }

}
