import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AnimeDetalheComponent } from './components/animes/anime-detalhe/anime-detalhe.component';
import { AnimeListaComponent } from './components/animes/anime-lista/anime-lista.component';

import { AnimesComponent } from './components/animes/animes.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { EstudiosComponent } from './components/estudios/estudios.component';
import { GenerosComponent } from './components/generos/generos.component';
import { MangasComponent } from './components/mangas/mangas.component';
import { PerfilComponent } from './components/user/perfil/perfil.component';
import { LoginComponent } from './components/user/login/login.component';
import { RegistrationComponent } from './components/user/registration/registration.component';
import { UserComponent } from './components/user/user.component';

const routes: Routes = [
  {
    path: 'user',
    component: UserComponent,
    children: [
      { path: 'login', component: LoginComponent },
      { path: 'registration', component: RegistrationComponent },
    ],
  },
  { path: 'user/perfil', component: PerfilComponent },
  { path: 'animes', redirectTo: 'animes/lista' },
  {
    path: 'animes',
    component: AnimesComponent,
    children: [
      { path: 'detalhe/:id', component: AnimeDetalheComponent },
      { path: 'detalhe', component: AnimeDetalheComponent },
      { path: 'lista', component: AnimeListaComponent },
    ],
  },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'generos', component: GenerosComponent },
  { path: 'mangas', component: MangasComponent },
  { path: 'perfil', component: PerfilComponent },
  { path: 'estudios', component: EstudiosComponent },
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: '**', redirectTo: 'dashboard', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
