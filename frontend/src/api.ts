const API_BASE = 'http://localhost:5118/api';

async function request<T>(path: string, options?: RequestInit): Promise<T> {
  const res = await fetch(`${API_BASE}${path}`, {
    headers: { 'Content-Type': 'application/json' },
    ...options,
  });
  if (!res.ok) {
    const err = await res.json().catch(() => ({ message: res.statusText }));
    throw new Error(err.message || 'Error en la solicitud');
  }
  if (res.status === 204) return undefined as T;
  return res.json();
}

export interface Cliente {
  id: number;
  nombre: string;
  email: string;
  telefono?: string;
  direccion?: string;
  fechaCreacion: string;
}

export interface Producto {
  id: number;
  nombre: string;
  descripcion?: string;
  precio: number;
  stock: number;
  fechaCreacion: string;
}

export interface Servicio {
  id: number;
  nombre: string;
  descripcion?: string;
  precioPorHora: number;
  fechaCreacion: string;
}

export interface PresupuestoItem {
  id: number;
  tipo: string;
  itemId: number;
  nombreItem: string;
  cantidad: number;
  precioUnitario: number;
  subtotal: number;
}

export interface Presupuesto {
  id: number;
  clienteId: number;
  clienteNombre: string;
  fechaCreacion: string;
  total: number;
  estado: string;
  items: PresupuestoItem[];
}

export const api = {
  clientes: {
    list: () => request<Cliente[]>('/clientes'),
    get: (id: number) => request<Cliente>(`/clientes/${id}`),
    create: (data: Partial<Cliente>) => request<Cliente>('/clientes', { method: 'POST', body: JSON.stringify(data) }),
    update: (id: number, data: Partial<Cliente>) => request<Cliente>(`/clientes/${id}`, { method: 'PUT', body: JSON.stringify(data) }),
    delete: (id: number) => request<void>(`/clientes/${id}`, { method: 'DELETE' }),
  },
  productos: {
    list: () => request<Producto[]>('/productos'),
    get: (id: number) => request<Producto>(`/productos/${id}`),
    create: (data: Partial<Producto>) => request<Producto>('/productos', { method: 'POST', body: JSON.stringify(data) }),
    update: (id: number, data: Partial<Producto>) => request<Producto>(`/productos/${id}`, { method: 'PUT', body: JSON.stringify(data) }),
    delete: (id: number) => request<void>(`/productos/${id}`, { method: 'DELETE' }),
  },
  servicios: {
    list: () => request<Servicio[]>('/servicios'),
    get: (id: number) => request<Servicio>(`/servicios/${id}`),
    create: (data: Partial<Servicio>) => request<Servicio>('/servicios', { method: 'POST', body: JSON.stringify(data) }),
    update: (id: number, data: Partial<Servicio>) => request<Servicio>(`/servicios/${id}`, { method: 'PUT', body: JSON.stringify(data) }),
    delete: (id: number) => request<void>(`/servicios/${id}`, { method: 'DELETE' }),
  },
  presupuestos: {
    list: () => request<Presupuesto[]>('/presupuestos'),
    get: (id: number) => request<Presupuesto>(`/presupuestos/${id}`),
    create: (data: { clienteId: number; items: { tipo: string; itemId: number; cantidad: number }[] }) =>
      request<Presupuesto>('/presupuestos', { method: 'POST', body: JSON.stringify(data) }),
    updateEstado: (id: number, data: { estado: string }) =>
      request<Presupuesto>(`/presupuestos/${id}/estado`, { method: 'PATCH', body: JSON.stringify(data) }),
    delete: (id: number) => request<void>(`/presupuestos/${id}`, { method: 'DELETE' }),
  },
};
