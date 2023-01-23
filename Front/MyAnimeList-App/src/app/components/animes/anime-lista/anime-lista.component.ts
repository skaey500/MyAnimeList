import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Anime } from '@app/models/Anime';
import { AnimeService } from '@app/services/anime.service';
import { ThisReceiver } from '@angular/compiler';
import { environment } from '@enviroments/environment';

@Component({
  selector: 'app-anime-lista',
  templateUrl: './anime-lista.component.html',
  styleUrls: ['./anime-lista.component.scss']
})
export class AnimeListaComponent implements OnInit {

  modalRef!: BsModalRef;
  public animesFiltrados: Anime[] = [];
  public animes: Anime[] = [];
  public animeId = 0

  public larguraImagem = 65;
  public margemImagem = 2;
  public mostrarImagem = true;
  private filtroListado = '';

  public get filtroLista() {
    return this.filtroListado;
  }

  public set filtroLista(value: string) {
    this.filtroListado = value;
    this.animesFiltrados = this.filtroLista
      ? this.filtrarAnimes(this.filtroLista)
      : this.animes;
  }

  public filtrarAnimes(filtrarPor: string): Anime[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.animes.filter(
      (anime: any) => anime.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  constructor(
    private animeService: AnimeService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private router: Router
  ) {}

  public ngOnInit(): void {
    this.getAnimes();
    this.spinner.show();
  }

  public alterarImagem(): void {
    this.mostrarImagem = !this.mostrarImagem;
  }

  public mostraImagem(imagemURL: string): string {
    return (imagemURL != '')
      ? `${environment.apiURL}resources/images/${imagemURL}`
      : 'assets/semImagem.jpg'

  }

  public getAnimes(): void {
    this.animeService.getAnime().subscribe({
      next: (animes: Anime[]) => {
        this.animes = animes;
        this.animesFiltrados = this.animes;
      },
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao carregar os Animes.', 'Erro!');
      },
      complete: () => this.spinner.hide(),
    });
  }

  openModal(event: any, template: TemplateRef<any>, animeId: number): void {
    event.stopPropagation();
    this.animeId = animeId;
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  confirm(): void {
    this.modalRef.hide();
    this.spinner.show();
    this.animeService.deleteAnime(this.animeId).subscribe(
      (result: any) => {
        console.log(result)
        this.toastr.success('O Anime foi deletado com Sucesso.', 'Deletado!');
        this.spinner.hide;
        this.getAnimes();
      },
      (error: any) => {
        console.error(error);
        this.toastr.error(`Erro ao tentar deletar o anime ${this.animeId}`, 'Erro');
        this.spinner.hide();
      },
       () => this.spinner.hide(),
    )
  }

  decline(): void {
    this.modalRef.hide();
  }


  detalheAnime(id: number): void {
    this.router.navigate([`animes/detalhe/${id}`])
  }

}
