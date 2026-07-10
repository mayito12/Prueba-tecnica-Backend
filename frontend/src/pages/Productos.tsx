import { useEffect, useState } from 'react';
import { api } from '../api';
import type { Producto } from '../api';

export default function Productos() {
  const [items, setItems] = useState<Producto[]>([]);
  const [form, setForm] = useState({ nombre: '', descripcion: '', precio: 0, stock: 0 });
  const [editing, setEditing] = useState<number | null>(null);
  const [error, setError] = useState('');

  useEffect(() => { load(); }, []);

  const load = async () => {
    try {
      setItems(await api.productos.list());
    } catch {
      setError('Error al cargar productos');
    }
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      if (editing) {
        await api.productos.update(editing, form);
      } else {
        await api.productos.create(form);
      }
      setForm({ nombre: '', descripcion: '', precio: 0, stock: 0 });
      setEditing(null);
      setError('');
      await load();
    } catch {
      setError('Error al guardar producto');
    }
  };

  const handleEdit = (item: Producto) => {
    setForm({ nombre: item.nombre, descripcion: item.descripcion || '', precio: item.precio, stock: item.stock });
    setEditing(item.id);
  };

  const handleDelete = async (id: number) => {
    if (!confirm('¿Eliminar producto?')) return;
    try {
      await api.productos.delete(id);
      await load();
    } catch {
      setError('Error al eliminar producto');
    }
  };

  return (
    <div>
      <h1>Productos</h1>
      {error && <p style={{ color: 'red' }}>{error}</p>}
      <form onSubmit={handleSubmit} style={{ display: 'flex', gap: '0.5rem', marginBottom: '1rem', flexWrap: 'wrap' }}>
        <input placeholder="Nombre" value={form.nombre} onChange={e => setForm({ ...form, nombre: e.target.value })} required />
        <input placeholder="Descripción" value={form.descripcion} onChange={e => setForm({ ...form, descripcion: e.target.value })} />
        <input type="number" step="0.01" placeholder="Precio" value={form.precio} onChange={e => setForm({ ...form, precio: +e.target.value })} required />
        <input type="number" placeholder="Stock" value={form.stock} onChange={e => setForm({ ...form, stock: +e.target.value })} />
        <button type="submit">{editing ? 'Actualizar' : 'Crear'}</button>
        {editing && <button type="button" onClick={() => { setEditing(null); setForm({ nombre: '', descripcion: '', precio: 0, stock: 0 }); }}>Cancelar</button>}
      </form>
      <table style={{ width: '100%', borderCollapse: 'collapse', background: '#fff' }}>
        <thead><tr><th>ID</th><th>Nombre</th><th>Precio</th><th>Stock</th><th>Acciones</th></tr></thead>
        <tbody>
          {items.map(i => (
            <tr key={i.id}><td>{i.id}</td><td>{i.nombre}</td><td>${i.precio.toFixed(2)}</td><td>{i.stock}</td>
              <td>
                <button onClick={() => handleEdit(i)}>Editar</button>
                <button onClick={() => handleDelete(i.id)} style={{ marginLeft: 4 }}>Eliminar</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
