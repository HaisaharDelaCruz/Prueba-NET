import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CarritoService {
  private url = `${environment.apiURL}/api/carrito/`;

  constructor(private http: HttpClient) {}
  
  comprar(clienteId: number, articuloIds: number[]) {
    return this.http.post(`${this.url}comprar`, { clienteId, articuloIds });
  }

  obtenerComprasCliente(clienteId: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.url}obtenerComprasCliente/${clienteId}`);
  }
}
