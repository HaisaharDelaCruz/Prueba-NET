export interface Articulos {
  id: number;
  codigo: string;
  descripcion: string;
  precio: number;
  stock: number;
  imagen?: File | Uint8Array | null; 
  imagenBase64?: string | null;    
}