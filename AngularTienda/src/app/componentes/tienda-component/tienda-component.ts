import { Component, OnInit } from '@angular/core';
import { TiendaService } from '../../servicios/tienda.service'; // Asegúrate de que la ruta sea correcta
import { Tienda } from '../../Interfaces/tienda'; // Asegúrate de que la ruta sea correcta

@Component({
  selector: 'app-tienda-component',
  standalone: false,
  templateUrl: './tienda-component.html',
  styleUrl: './tienda-component.css'
})

export class TiendaComponent implements OnInit{
  tiendas: Tienda[] = [];
  nuevaTienda: Tienda = { id: 0, sucursal: '', direccion: '' };

  constructor(private tiendaService: TiendaService) { }

  ngOnInit(): void {
    this.tiendaService.getTiendas().subscribe(data => {
      this.tiendas = data;
    });
  }

  cargarTiendas(): void {
    this.tiendaService.getTiendas().subscribe(data => this.tiendas = data);
  }

  crearTienda(): void {
    this.tiendaService.crearTienda(this.nuevaTienda).subscribe(() => {
      this.nuevaTienda = { id: 0, sucursal: '', direccion: '' };
      this.cargarTiendas();
    });
  }

  eliminarTienda(id: number): void {
    if (!confirm('¿Estás seguro de eliminar este artículo?')) return;

    this.tiendaService.eliminar(id).subscribe(() => {
      this.tiendas = this.tiendas.filter(a => a.id !== id);
    });
  }

  editarTienda(): void{
    this.tiendaService.editar(this.nuevaTienda).subscribe(() => {
      this.resetFormulario();
      this.cargarTiendas();
    });
  }

  cargarFormulario(tienda: Tienda): void {
    this.nuevaTienda = { ...tienda };
  }

  resetFormulario(): void {
    this.nuevaTienda = { id: 0, sucursal: '', direccion: '' };
  }
}
