import { Component } from '@angular/core';
import { Articulos } from '../../Interfaces/articulos';
import { CarritoService } from '../../servicios/carrito.service';
import { ArticulosService } from '../../servicios/articulos.service';

@Component({
  selector: 'app-carrito.components',
  standalone: false,
  templateUrl: './carrito.components.html',
  styleUrl: './carrito.components.css'
})
export class CarritoComponents {
  articulos: Articulos[] = [];
  carrito: { articulo: Articulos, cantidad: number }[] = [];
  clienteId = Number(localStorage.getItem('clienteId'));
  compras: any[] = [];

  constructor(private carritoService: CarritoService, private articuloService: ArticulosService) {}

  ngOnInit(): void {
    this.articuloService.obtenerTodos().subscribe(data => this.articulos = data);
    this.carritoService.obtenerComprasCliente(this.clienteId).subscribe(data => {
      this.compras = data;
    });
  }

  agregar(articulo: Articulos): void {
    const item = this.carrito.find(c => c.articulo.id === articulo.id);

    if (item) {
      if (item.cantidad < articulo.stock) {
        item.cantidad++;
      } else {
        alert('No hay más stock disponible de este artículo.');
      }
    } else {
      if (articulo.stock > 0) {
        this.carrito.push({ articulo, cantidad: 1 });
      } else {
        alert('Artículo sin stock.');
      }
    }
  }

  quitar(articulo: Articulos): void {
    const index = this.carrito.findIndex(c => c.articulo.id === articulo.id);
    if (index !== -1) {
      const item = this.carrito[index];
      if (item.cantidad > 1) {
        item.cantidad--;
      } else {
        this.carrito.splice(index, 1);
      }
    }
  }

  comprar(): void {
    const ids: number[] = [];

    this.carrito.forEach(item => {
      for (let i = 0; i < item.cantidad; i++) {
        ids.push(item.articulo.id);
      }
    });

    this.carritoService.comprar(this.clienteId, ids).subscribe(() => {
      alert('Compra realizada con éxito');
      this.carrito = [];
      this.ngOnInit();
    });

  }
}
