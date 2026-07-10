import { useEffect, useState } from 'react';
import { api } from '../api';
import type { Servicio } from '../api';

export default function Servicios() {
  const [items, setItems] = useState<Servicio[]>([]);
  const [form, setForm] = useState({ nombre: '', descripcion: '', precioPorHora: 0 });
  const [editing, setEditing] = useState<number | null>(null);
  const [error, setError] = useState('');

  useEffect(() => { load(); }, []);

  const load = async () => {
    try {
      setItems(await api.servicios.list());
    } catch {
      setError('Error al cargar servicios');
    }
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      if (editing) {
        await api.servicios.update(editing, form);
      } else {
        await api.servicios.create(form);
      }
      setForm({ nombre: '', descripcion: '', precioPorHora: 0 });
      setEditing(null);
      setError('');
      await load();
    } catch {
      setError('Error al guardar servicio');
    }
  };

  const handleEdit = (item: Servicio) => {
    setForm({ nombre: item.nombre, descripcion: item.descripcion || '', precioPorHora: item.precioPorHora });
    setEditing(item.id);
  };

  const handleDelete = async (id: number) => {
    if (!confirm('¿Eliminar servicio?')) return;
    try {
      await api.servicios.delete(id);
      await load();
    } catch {
      setError('Error al eliminar servicio');
    }
  };

  return (
    <div>
      <h1>Servicios</h1>
      {error && <p style={{ color: 'red' }}>{error}</p>}
      <form onSubmit={handleSubmit} style={{ display: 'flex', gap: '0.5rem', marginBottom: '1rem', flexWrap: 'wrap' }}>
        <input placeholder="Nombre" value={form.nombre} onChange={e => setForm({ ...form, nombre: e.target.value })} required />
        <input placeholder="Descripción" value={form.descripcion} onChange={e => setForm({ ...form, descripcion: e.target.value })} />
        <input type="number" step="0.01" placeholder="Precio por hora" value={form.precioPorHora} onChange={e => setForm({ ...form, precioPorHora: +e.target.value })} required />
        <button type="submit">{editing ? 'Actualizar' : 'Crear'}</button>
        {editing && <button type="button" onClick={() => { setEditing(null); setForm({ nombre: '', descripcion: '', precioPorHora: 0 }); }}>Cancelar</button>}
      </form>
      <table style={{ width: '100%', borderCollapse: 'collapse', background: '#fff' }}>
        <thead><tr><th>ID</th><th>Nombre</th><th>Precio/hora</th><th>Acciones</th></tr></thead>
        <tbody>
          {items.map(i => (
            <tr key={i.id}><td>{i.id}</td><td>{i.nombre}</td><td>${i.precioPorHora.toFixed(2)}</td>
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
