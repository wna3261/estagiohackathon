import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CandidatoService } from '../../../_services/candidato.service';

@Component({
  selector: 'app-candidato-get',
  templateUrl: './candidato-get.component.html',
  styleUrls: ['./candidato-get.component.css']
})

export class CandidatoGetComponent implements OnInit {
  public id: any;
  public candidato: any;

  constructor(
    private route: ActivatedRoute,
    private candidatoService: CandidatoService,
    private router: Router
  ) { }

  ngOnInit() {
    this.id = this.route.snapshot.params.id;
    this.candidatoService.getCandidato(this.id).subscribe(response => {
      this.candidato = response;
    }, error => {
      console.log(error);
    });
  }

  public home() {
    this.router.navigate(['home']);
  }
}
