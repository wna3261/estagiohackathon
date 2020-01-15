import { Component, OnInit } from '@angular/core';
import { CandidatoService } from '../../../_services/candidato.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-candidato-approved',
  templateUrl: './candidato-approved.component.html',
  styleUrls: ['./candidato-approved.component.css']
})

export class CandidatoApprovedComponent implements OnInit {
  public numVagas: any;

  constructor(
    private candidatoService: CandidatoService,
    private router: Router) { }

  ngOnInit() {
  }

  public exibirResultados() {
    this.candidatoService.exibirResultados(this.numVagas).subscribe(data => {
      this.router.navigate(['home']);
    }, error => {
      console.log(error);
    });
  }

  public cancel() {
    this.router.navigate(['home']);
  }
}
