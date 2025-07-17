import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Tienda } from '../Interfaces/tienda';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})

export class TiendaService {
  
  constructor(private http: HttpClient) {}
  
  private urlBase = environment.apiURL + '/api/tiendas';

  getTiendas(): Observable<Tienda[]> {
    return this.http.get<Tienda[]>(`${this.urlBase}/obtenerTiendas`);
  }

  crearTienda(tienda: Tienda): Observable<Tienda> {
    return this.http.post<Tienda>(this.urlBase + '/crearTienda', tienda);
  }

  eliminar(id: number): Observable<void> {
    return this.http.delete<void>(`${this.urlBase + '/eliminarTienda'}/${id}`);
  }

  editar(tienda: Tienda): Observable<Tienda>{
    return this.http.put<Tienda>(`${this.urlBase + '/editarTienda'}/${tienda.id}`, tienda);  
  }

}
