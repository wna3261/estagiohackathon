import { Component, OnInit } from '@angular/core';
import { CandidatoService } from '../../../_services/candidato.service';
import { Router, ActivatedRoute } from '@angular/router';
import { isNullOrUndefined } from 'util';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-candidato-update',
  templateUrl: './candidato-update.component.html',
  styleUrls: ['./candidato-update.component.css']
})

export class CandidatoUpdateComponent implements OnInit {
  public candidato: any = {};
  private id: any;

  constructor(
    private candidatoService: CandidatoService,
    private route: ActivatedRoute,
    private router: Router,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.id = this.route.snapshot.params.id;
    this.candidatoService.getCandidato(this.id).subscribe(data => {
      this.candidato = data;
    });
  }

  public atualizarCandidato() {
    if (!isNullOrUndefined(this.candidato.nota)) {
      this.candidatoService.atualizarCandidato(this.candidato).subscribe(data => {
        this.toastr.success("Candidato atualizado com sucesso.", "Sucesso!");
        this.router.navigate(['home']);
      }, error => {
        error.error.errors ?
          Object.values(error.error.errors).forEach(fieldErrors => {
            let errors = fieldErrors as Array<string>;
            errors.forEach(error => {
              this.toastr.error(error)
            });
          }) :
          this.toastr.warning(error.error);
      });
    }
    else {
      this.toastr.error("O campo Nota é obrigatório.");
      this.candidato.nota = 0;
    }
  }

  public cancel() {
    this.router.navigate(['home']);
  }

}
