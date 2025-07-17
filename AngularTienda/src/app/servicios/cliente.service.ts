import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Cliente } from '../Interfaces/cliente';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  constructor(private http: HttpClient) {}
  
  private urlBase = environment.apiURL + '/api/clientes';

  getClientes(): Observable<Cliente[]> {
    return this.http.get<Cliente[]>(`${this.urlBase}/obtenerClientes`);
  }

  crearCliente(cliente: Cliente): Observable<Cliente> {
    return this.http.post<Cliente>(`${this.urlBase}/crearCliente`, cliente);
  }

  eliminar(id: number): Observable<void> {
    return this.http.delete<void>(`${this.urlBase + '/eliminarCliente'}/${id}`);
  }

  editar(cliente: Cliente): Observable<Cliente>{
    return this.http.put<Cliente>(`${this.urlBase + '/editarCliente'}/${cliente.id}`, cliente);  
  }
}
