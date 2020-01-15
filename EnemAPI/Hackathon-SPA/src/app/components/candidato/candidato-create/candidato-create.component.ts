import { Component, OnInit } from '@angular/core';
import { CandidatoService } from '../../../_services/candidato.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { isNullOrUndefined } from 'util';

@Component({
  selector: 'app-candidato-create',
  templateUrl: './candidato-create.component.html',
  styleUrls: ['./candidato-create.component.css']
})

export class CandidatoCreateComponent implements OnInit {
  public candidato: any = { nome: '', cidade: '', nota: 0 };
  public submitted: boolean = false;
  private id: number;

  constructor(
    private candidatoService: CandidatoService,
    private router: Router,
    private route: ActivatedRoute,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.id = this.route.snapshot.params.id;
    this.hasId();
  }

  private hasId(): void {
    if(this.id != 0){
      this.candidatoService.getCandidato(this.id).subscribe(data=>{
        this.candidato = data;
      })
    }
  }

  public onSubmit(): void {
    if(this.id == 0){
      this.createCandidato();
    }
    else{
      this.updateCandidato();
    }
  }

  public createCandidato() {
    this.submitted = true;
    if (!isNullOrUndefined(this.candidato.nota)) {
      this.candidatoService.cadastrarCandidato(this.candidato).subscribe(data => {
        this.toastr.success("Candidato cadastrado com sucesso.", 'Sucesso!');
        this.submitted = false;
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
          this.submitted = false;
      });
    }
    else {
      this.toastr.error("O campo Nota é obrigatório.");
      this.submitted = false;
      this.candidato.nota = 0;
    }
  }

  public updateCandidato() {
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
