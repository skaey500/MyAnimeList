import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { CollapseModule } from 'ngx-bootstrap/collapse';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule} from 'ngx-bootstrap/modal';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';

import {BsDatepickerModule} from 'ngx-bootstrap/datepicker';
import { defineLocale } from 'ngx-bootstrap/chronos';
import { ptBrLocale } from 'ngx-bootstrap/chronos';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './shared/nav/nav.component';

import { AnimeService } from './services/anime.service';

import { DateTimeFormatPipe } from './helpers/DateTimeFormat.pipe';
import { timeout } from 'rxjs';
import { positionElements } from 'ngx-bootstrap/positioning';
import { GenerosComponent } from './components/generos/generos.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { MangasComponent } from './components/mangas/mangas.component';
import { PerfilComponent } from './components/user/perfil/perfil.component';
import { TituloComponent } from './shared/titulo/titulo.component';
import { EstudiosComponent } from './components/estudios/estudios.component';
import { AnimesComponent } from './components/animes/animes.component';
import { AnimeDetalheComponent } from './components/animes/anime-detalhe/anime-detalhe.component';
import { AnimeListaComponent } from './components/animes/anime-lista/anime-lista.component';
import { UserComponent } from './components/user/user.component';
import { LoginComponent } from './components/user/login/login.component';
import { RegistrationComponent } from './components/user/registration/registration.component';
import { GeneroService } from './services/genero.service';

defineLocale('pt-br', ptBrLocale);

@NgModule({
  declarations: [
    AppComponent,
    AnimesComponent,
    GenerosComponent,
    DashboardComponent,
    MangasComponent,
    PerfilComponent,
    EstudiosComponent,
    NavComponent,
    TituloComponent,
    DateTimeFormatPipe,
    AnimeDetalheComponent,
    AnimeListaComponent,
    UserComponent,
    LoginComponent,
    RegistrationComponent,
   ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CollapseModule.forRoot(),
    BsDropdownModule.forRoot(),
    TooltipModule.forRoot(),
    NgxSpinnerModule,
    BsDatepickerModule.forRoot(),
    ModalModule.forRoot(),
    ToastrModule.forRoot({
        timeOut: 10000,
        positionClass: 'toast-bottom-right',
        preventDuplicates: true,
        progressBar: true
    }),
  ],
  providers: [AnimeService, GeneroService],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule { }
