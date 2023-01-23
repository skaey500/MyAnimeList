import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Anime } from '@app/models/Anime';
import { AnimeService } from '@app/services/anime.service';
import { GeneroService } from '@app/services/genero.service';
import { environment } from '@enviroments/environment';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Genero} from '@app/models/Genero';

@Component({
  selector: 'app-anime-detalhe',
  templateUrl: './anime-detalhe.component.html',
  styleUrls: ['./anime-detalhe.component.scss'],
})
export class AnimeDetalheComponent implements OnInit {
  form!: FormGroup;
  animeId!: number;
  anime = {} as Anime;
  genero = {} as Genero;
  estadoSalvar = 'post';
  imagemURL = 'assets/upload.png';
  file: any[] = [];

  get modoEditar(): boolean {
    return this.estadoSalvar === 'put';
  }

  get f(): any {
    return this.form.controls;
  }

  get bsConfig(): any {
    return {
      adaptivePosition: true,
      dateInputFormat: 'DD/MM/YYYY',
      containerClass: 'theme-default',
      showWeekNumbers: false,
    };
  }

  constructor(
    private fb: FormBuilder,
    private localeService: BsLocaleService,
    private router: ActivatedRoute,
    private animeService: AnimeService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    private generoService: GeneroService,
  ) {
    this.localeService.use('pt-br');
  }

  public carregarAnime(): void {
    const animeIdParam = this.router.snapshot.paramMap.get('id');
    this.animeId = Number(this.router.snapshot.paramMap.get('id'));
    if (animeIdParam != null) {
      this.spinner.show();

      this.estadoSalvar = 'put';

      this.animeService.getAnimeById(+animeIdParam).subscribe(
        (anime: Anime) => {
          this.anime = { ...anime };
          this.form.patchValue(this.anime);
          if (this.anime.imagemURL != '') {
            this.imagemURL = environment.apiURL + 'resources/images/' + this.anime.imagemURL
          }
        },
        (error: any) => {
          this.spinner.hide();
          this.toastr.error('Erro ao tentar carregar Anime.', 'Erro!');
          console.error(error);
        },
        () => {
          this.spinner.hide();
        }
      );
    }
  }

  getgenero(seucu: string): void {

  }

  ngOnInit(): void {
    this.carregarAnime();
    this.validation();
    //this.generoService.getAllGenero().subscribe(
      //(genero: Genero[])=> {
        //this.genero = genero;

    //},
    //)

  }

  public validation(): void {
    this.form = this.fb.group({
      nome: [
        '',
        [
          Validators.required,
          Validators.minLength(2),
          Validators.maxLength(50),
        ],
      ],
      episodios: [
        '',
        [
          Validators.required,
          Validators.minLength(1),
          Validators.maxLength(26),
        ],
      ],

      imagemURL: [''],
      dataLancamento: ['', Validators.required],
      sinopse: [
        '',
        [
          Validators.required,
          Validators.minLength(2),
          Validators.maxLength(50),
        ],
      ],
    });
  }

  public resetForm(): void {
    this.form.reset();
  }

  public cssValidator(campoForm: FormControl): any {
    return { 'is-invalid': campoForm.errors && campoForm.touched };
  }

  public salvarAlteracao() {
    this.spinner.show();
    if (this.form.valid) {
      if (this.estadoSalvar === 'post') {
        this.anime = { ...this.form.value };
        this.animeService.postAnime(this.anime).subscribe(
          () => this.toastr.success('Anime salvo com Sucesso!', 'Sucesso'),
          (error: any) => {
            console.error(error);
            this.toastr.error('Erro ao salvar Anime', 'Erro');
            this.spinner.hide();
          },
          () => this.spinner.hide()
        );
      } else {
        this.anime = { id: this.anime.id, ...this.form.value };
        this.animeService.putAnime(this.anime.id, this.anime).subscribe(
          () => this.toastr.success('Anime salvo com Sucesso!', 'Sucesso'),
          (error: any) => {
            console.error(error);
            this.toastr.error('Erro ao salvar Anime', 'Erro');
          },
          () => this.spinner.hide()
        );
      }
    }
  }

  onFileChange(an: any): void {
    const reader = new FileReader();

    reader.onload = (anim: any) => this.imagemURL = anim.target.result;

    this.file = an.target.files;
    reader.readAsDataURL(this.file[0]);

    this.uploadImagem();
  }

  uploadImagem(): void {
    this.spinner.show();
    this.animeService.postUpload(this.animeId, this.file).subscribe(
      () => {
        this.carregarAnime();
        this.toastr.success('Imagem atualizada com Sucesso', 'Sucesso!');
      },
      (error: any) => {
        this.toastr.error('Erro ao fazer upload de imagem', 'Erro!');
        console.log(error);
      }
    ).add(() => this.spinner.hide());
  }
}
