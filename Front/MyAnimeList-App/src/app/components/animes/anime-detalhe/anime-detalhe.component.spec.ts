import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AnimeDetalheComponent } from './anime-detalhe.component';

describe('AnimeDetalheComponent', () => {
  let component: AnimeDetalheComponent;
  let fixture: ComponentFixture<AnimeDetalheComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AnimeDetalheComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AnimeDetalheComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
