import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, take } from 'rxjs';
import { Anime } from '../models/Anime';

@Injectable()
//{providedIn: 'root',}
export class AnimeService {
  baseURL = 'https://localhost:5001/api/animes';
  constructor(private http: HttpClient) {}

  public getAnime(): Observable<Anime[]> {
    return this.http.get<Anime[]>(this.baseURL);
  }

  public getAnimeByNome(nome: string): Observable<Anime[]> {
    return this.http.get<Anime[]>(`${this.baseURL}/${nome}/nome`);
  }

  public getAnimeById(id: number): Observable<Anime> {
    return this.http.get<Anime>(`${this.baseURL}/${id}`);
  }

  public postAnime(anime: Anime): Observable<Anime> {
    return this.http.post<Anime>(this.baseURL, anime);
  }

  public putAnime(id: number, anime: Anime): Observable<Anime> {
    return this.http.put<Anime>(`${this.baseURL}/${id}`, anime);
  }

  public deleteAnime(id: number): Observable<any> {
    return this.http.delete<string>(`${this.baseURL}/${id}`);
  }

  postUpload(animeId: number, file: File[]): Observable<Anime> {
    const fileToUpload = file[0] as File;
    const formData = new FormData();
    formData.append('file', fileToUpload)

    return this.http
      .post<Anime>(`${this.baseURL}/upload-image/${animeId}`, formData)
      .pipe(take(1));
  }
}
