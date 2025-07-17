import { TestBed } from '@angular/core/testing';

import { TiendaArticuloService } from './tienda-articulo.service';

describe('TiendaArticuloService', () => {
  let service: TiendaArticuloService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TiendaArticuloService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
