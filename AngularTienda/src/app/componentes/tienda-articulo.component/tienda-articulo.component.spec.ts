import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TiendaArticuloComponent } from './tienda-articulo.component';

describe('TiendaArticuloComponent', () => {
  let component: TiendaArticuloComponent;
  let fixture: ComponentFixture<TiendaArticuloComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TiendaArticuloComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TiendaArticuloComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
