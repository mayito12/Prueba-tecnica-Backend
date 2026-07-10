import { useEffect, useState } from 'react';
import { api } from '../api';
import type { Cliente } from '../api';

export default function Clientes() {
  const [items, setItems] = useState<Cliente[]>([]);
  const [form, setForm] = useState({ nombre: '', email: '', telefono: '', direccion: '' });
  const [editing, setEditing] = useState<number | null>(null);
  const [error, setError] = useState('');

  useEffect(() => { load(); }, []);

  const load = async () => {
    try {
      setItems(await api.clientes.list());
    } catch {
      setError('Error al cargar clientes');
    }
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      if (editing) {
        await api.clientes.update(editing, form);
      } else {
        await api.clientes.create(form);
      }
      setForm({ nombre: '', email: '', telefono: '', direccion: '' });
      setEditing(null);
      setError('');
      await load();
    } catch {
      setError('Error al guardar cliente');
    }
  };

  const handleEdit = (item: Cliente) => {
    setForm({ nombre: item.nombre, email: item.email, telefono: item.telefono || '', direccion: item.direccion || '' });
    setEditing(item.id);
  };

  const handleDelete = async (id: number) => {
    if (!confirm('¿Eliminar cliente?')) return;
    try {
      await api.clientes.delete(id);
      await load();
    } catch {
      setError('Error al eliminar cliente');
    }
  };

  return (
    <div>
      <h1>Clientes</h1>
      {error && <p style={{ color: 'red' }}>{error}</p>}
      <form onSubmit={handleSubmit} style={{ display: 'flex', gap: '0.5rem', marginBottom: '1rem', flexWrap: 'wrap' }}>
        <input placeholder="Nombre" value={form.nombre} onChange={e => setForm({ ...form, nombre: e.target.value })} required />
        <input placeholder="Email" type="email" value={form.email} onChange={e => setForm({ ...form, email: e.target.value })} />
        <input placeholder="Teléfono" value={form.telefono} onChange={e => setForm({ ...form, telefono: e.target.value })} />
        <input placeholder="Dirección" value={form.direccion} onChange={e => setForm({ ...form, direccion: e.target.value })} />
        <button type="submit">{editing ? 'Actualizar' : 'Crear'}</button>
        {editing && <button type="button" onClick={() => { setEditing(null); setForm({ nombre: '', email: '', telefono: '', direccion: '' }); }}>Cancelar</button>}
      </form>
      <table style={{ width: '100%', borderCollapse: 'collapse', background: '#fff' }}>
        <thead><tr><th>ID</th><th>Nombre</th><th>Email</th><th>Teléfono</th><th>Acciones</th></tr></thead>
        <tbody>
          {items.map(i => (
            <tr key={i.id}><td>{i.id}</td><td>{i.nombre}</td><td>{i.email}</td><td>{i.telefono || '-'}</td>
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
