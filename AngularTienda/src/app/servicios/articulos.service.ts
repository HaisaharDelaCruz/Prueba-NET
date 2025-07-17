import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Articulos } from '../Interfaces/articulos';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ArticulosService {
  private apiUrl = `${environment.apiURL}/api/articulo`;

  constructor(private http: HttpClient) {}

  obtenerTodos(): Observable<Articulos[]> {
    return this.http.get<Articulos[]>(`${this.apiUrl}/obtenerArticulos`);
  }

  obtenerPorId(id: number): Observable<Articulos> {
    return this.http.get<Articulos>(`${this.apiUrl}/${id}`);
  }

  crear(formData: FormData): Observable<any> {
    return this.http.post<Articulos>(`${this.apiUrl}/crearArticulo`, formData);
  }

  actualizar(id: number, formData: FormData): Observable<any> {
    return this.http.put(`${this.apiUrl}/editarArticulo/${id}`, formData);
  }

  eliminar(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

  obtenerPorTienda(tiendaId: number): Observable<Articulos[]> {
    return this.http.get<Articulos[]>(`${this.apiUrl}/articulosPorTienda/${tiendaId}`);
  }
}
