import { Component, OnInit } from '@angular/core';
import { Cliente } from '../../Interfaces/cliente';
import { ClienteService } from '../../servicios/cliente.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-cliente-component',
  standalone: false,
  templateUrl: './cliente-component.html',
  styleUrl: './cliente-component.css'
})
export class ClienteComponent implements OnInit{
  clientes: Cliente[] = [];
  nuevoClientes: Cliente = {id: 0, nombre: '', apellido: '', direccion: '', contrasena:'', correo: ''}
  clienteForm: FormGroup;

  constructor(private clienteService: ClienteService, private fb: FormBuilder) { 
    this.clienteForm = this.fb.group({
      nombre: ['', Validators.required],
      apellido: ['', Validators.required],
      direccion: ['', Validators.required],
      correo: ['', Validators.required],
      contrasena: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.clienteService.getClientes().subscribe(data => {
      this.clientes = data;
    });
  }

  crearCliente(): void {
    if (this.clienteForm.valid) {
      this.clienteService.crearCliente(this.clienteForm.value).subscribe(() => {
        this.clienteForm.reset();
        this.ngOnInit();
      });
    }
  }

  eliminarCliente(id: number): void {
    if (!confirm('¿Estás seguro de eliminar este artículo?')) return;

    this.clienteService.eliminar(id).subscribe(() => {
      this.clientes = this.clientes.filter(a => a.id !== id);
    });
  }

  editarCliente(): void{
    if (this.clienteForm.valid && this.nuevoClientes.id !== 0) {
      const clienteEditado: Cliente = {
        id: this.nuevoClientes.id,
        ...this.clienteForm.value
      };

      this.clienteService.editar(clienteEditado).subscribe(() => {
        this.resetFormulario();
        this.ngOnInit();
      });
    }
  }

  cargarFormulario(cliente: Cliente): void {
    this.nuevoClientes = { ...cliente };
    this.clienteForm.patchValue({
      nombre: cliente.nombre,
      apellido: cliente.apellido,
      direccion: cliente.direccion,
      correo: cliente.correo,
      contrasena: cliente.contrasena // opcional mostrarla
    });
  }

  resetFormulario(): void {
    this.nuevoClientes = {id: 0, nombre: '', apellido: '', direccion: '', contrasena:'', correo: ''};
    this.clienteForm.reset();
  }
}
