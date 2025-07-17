import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TiendaComponent } from './componentes/tienda-component/tienda-component';
import { ClienteComponent } from './componentes/cliente-component/cliente-component';
import { Login } from './auth/login/login';
import { ArticulosComponent } from './componentes/articulos.component/articulos.component';
import { CarritoComponents } from './componentes/carrito.components/carrito.components';
import { TiendaArticuloComponent } from './componentes/tienda-articulo.component/tienda-articulo.component';

const routes: Routes = [
  { path: '', component: Login},
  { path: 'tiendas', component: TiendaComponent },
  { path: 'clientes', component: ClienteComponent},
  { path: 'articulos', component: ArticulosComponent},
  { path: 'agregarArticulos', component: CarritoComponents},
  { path: 'tiendas', component: TiendaComponent},
  { path: 'agregarArticulosATienda', component: TiendaArticuloComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
