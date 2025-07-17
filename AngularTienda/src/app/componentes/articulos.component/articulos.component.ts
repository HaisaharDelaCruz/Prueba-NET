import { Component, OnInit } from '@angular/core';
import { Articulos } from '../../Interfaces/articulos';
import { ArticulosService } from '../../servicios/articulos.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-articulos.component',
  standalone: false,
  templateUrl: './articulos.component.html',
  styleUrl: './articulos.component.css'
})
export class ArticulosComponent implements OnInit{
  articulos: Articulos[] = [];
  articuloForm: FormGroup;
  selectedFile: File | null = null;

  constructor(private articuloService: ArticulosService, private fb: FormBuilder) {
    this.articuloForm = this.fb.group({
      id: [0],
      codigo: ['', Validators.required],
      descripcion: [''],
      imagen: [0, Validators.required],
      precio: [0, Validators.required],
      stock: [0, Validators.required]
    });
  }

  ngOnInit(): void {
    this.cargarArticulos();
  }

  cargarArticulos(): void {
    this.articuloService.obtenerTodos().subscribe(data => {
      this.articulos = data;
    });
  }

  guardar(): void {
    const formData = new FormData();
    const articulo = this.articuloForm.value;

    formData.append('id', articulo.id);
    formData.append('codigo', articulo.codigo);
    formData.append('descripcion', articulo.descripcion);
    formData.append('precio', articulo.precio);
    formData.append('stock', articulo.stock);

    if (this.selectedFile) {
      formData.append('imagen', this.selectedFile); // Archivo real
    }

    const operacion = articulo.id === 0
      ? this.articuloService.crear(formData)
      : this.articuloService.actualizar(articulo.id, formData);

    operacion.subscribe(() => {
      this.resetFormulario();
      this.cargarArticulos();
    });
  }

  eliminar(id: number): void {
    if (!confirm('¿Estás seguro de eliminar este artículo?')) return;

    this.articuloService.eliminar(id).subscribe(() => {
      this.articulos = this.articulos.filter(a => a.id !== id);
    });
  }

  cargarFormulario(articulo: Articulos): void {
    this.articuloForm.patchValue(articulo);
  }

  resetFormulario(): void {
    this.articuloForm.reset({
      id: 0,
      codigo: '',
      descripcion: '',
      imagen: '',
      precio: 0,
      stock: 0
    });
  }

  onFileSelected(event: Event): void {
  const input = event.target as HTMLInputElement;
    if (input.files && input.files.length > 0) {
      this.selectedFile = input.files[0];
    }
  }
}
