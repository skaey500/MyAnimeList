import { Estudio } from "./Estudio";
import { Genero } from "./Genero";

export interface Anime {
  id: number;
  nome: string;
  episodios: number;
  imagemURL: string;
  dataLancamento?: Date;
  sinopse: string;
  generos: Genero[];
  estudios: Estudio[];
}
