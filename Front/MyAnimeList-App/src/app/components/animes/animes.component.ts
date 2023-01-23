import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Anime } from '../../models/Anime';
import { AnimeService } from '../../services/anime.service';

@Component({
  selector: 'app-animes',
  templateUrl: './animes.component.html',
  styleUrls: ['./animes.component.scss'],
  //providers: [AnimeService]
})
export class AnimesComponent implements OnInit {
 ngOnInit(): void {

 }
}

