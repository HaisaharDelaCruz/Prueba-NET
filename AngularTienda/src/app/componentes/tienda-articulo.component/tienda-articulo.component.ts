import { Component } from '@angular/core';
import { Articulos } from '../../Interfaces/articulos';
import { TiendaArticuloService } from '../../servicios/tienda-articulo.service';
import { ArticulosService } from '../../servicios/articulos.service';
import { TiendaArticulo } from '../../Interfaces/TiendaArticulo';
import { TiendaService } from '../../servicios/tienda.service';
import { Tienda } from '../../Interfaces/tienda';
import { TiendaArticuloDTO } from '../../Interfaces/TiendaArticuloDTO';

@Component({
  selector: 'app-tienda-articulo.component',
  standalone: false,
  templateUrl: './tienda-articulo.component.html',
  styleUrl: './tienda-articulo.component.css'
})
export class TiendaArticuloComponent {
  tiendaId = 0; 
  articuloId = 0;
  articulos: Articulos[] = [];
  tiendas: Tienda[] = [];
  tiendaArticuloDTO: TiendaArticuloDTO[] = [];

  constructor(private servicio: TiendaArticuloService, private articuloService: ArticulosService, private tiendaService: TiendaService) {}

  ngOnInit(): void {
    this.articuloService.obtenerTodos().subscribe(data => this.articulos = data);
    this.tiendaService.getTiendas().subscribe(data => this.tiendas = data);
    this.servicio.mostrarTiendaArticulo().subscribe(data => this.tiendaArticuloDTO = data);
  }

  asignar(): void {
    const dto: TiendaArticulo = {
      tiendaId: Number(this.tiendaId),
      articuloId: Number(this.articuloId)
    };

    this.servicio.asignarArticulo(dto).subscribe({
      next: (res: any) => {
        alert(res.mensaje);
        this.ngOnInit();
      },
      error: (err) => {
        console.error(err);
        alert('El articulo ya existe');
      }
    });
  }

}
