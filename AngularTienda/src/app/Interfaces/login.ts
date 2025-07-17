export interface LoginRequest {
  correo: string;
  contraseña: string;
}

export interface LoginResponse {
  token: string;
  id: number;
  nombreUsuario: string;
  expiracion: string;
}
