import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Genero } from '@app/models/Genero';
import { Observable } from 'rxjs/internal/Observable';

@Injectable()
export class GeneroService {

  baseURL = 'https://localhost:5001/api/generos';

  constructor(private http: HttpClient) {}

  public getAllGenero(): Observable<Genero[]> {
    return this.http.get<Genero[]>(this.baseURL);
  }

  public getGeneroByNome(nome: string): Observable<Genero[]> {
    return this.http.get<Genero[]>(`${this.baseURL}/${nome}/nome`);
  }

  public getGeneroById(id: number): Observable<Genero> {
    return this.http.get<Genero>(`${this.baseURL}/${id}`);
  }

  public postGenero(genero: Genero): Observable<Genero> {
    return this.http.post<Genero>(this.baseURL, genero);
  }

  public putGenero(id: number, genero: Genero): Observable<Genero> {
    return this.http.put<Genero>(`${this.baseURL}/${id}`, genero);
  }

  public deleteGenero(id: number): Observable<any> {
    return this.http.delete<string>(`${this.baseURL}/${id}`);
  }
}
