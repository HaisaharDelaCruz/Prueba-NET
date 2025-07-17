import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { TiendaArticulo } from '../Interfaces/TiendaArticulo';
import { Observable } from 'rxjs';
import { TiendaArticuloDTO } from '../Interfaces/TiendaArticuloDTO';

@Injectable({
  providedIn: 'root'
})
export class TiendaArticuloService {
  private apiURL = environment.apiURL + '/api/articulo';

  constructor(private http: HttpClient) {}

  asignarArticulo(data: TiendaArticulo): Observable<any> {
    return this.http.post(`${this.apiURL}/asignarArticulo`, data);
  }

  mostrarTiendaArticulo(): Observable<TiendaArticuloDTO[]> {
    return this.http.get<TiendaArticuloDTO[]>(`${this.apiURL}/mostrarTiendaArticulo`);
  }
}
