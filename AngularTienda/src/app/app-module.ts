import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { TiendaComponent } from './componentes/tienda-component/tienda-component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ClienteComponent } from './componentes/cliente-component/cliente-component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CarritoComponents } from './componentes/carrito.components/carrito.components';
import { ArticulosComponent } from './componentes/articulos.component/articulos.component';
import { TiendaArticuloComponent } from './componentes/tienda-articulo.component/tienda-articulo.component';

@NgModule({
  declarations: [
    App,
    TiendaComponent,
    ClienteComponent,
    CarritoComponents,
    ArticulosComponent,
    TiendaArticuloComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule 
  ],
  providers: [
    provideBrowserGlobalErrorListeners()
  ],
  bootstrap: [App]
})

export class AppModule { }
