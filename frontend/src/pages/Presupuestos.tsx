import { useEffect, useState } from 'react';
import { api } from '../api';
import type { Presupuesto, Cliente, Producto, Servicio } from '../api';

export default function Presupuestos() {
  const [items, setItems] = useState<Presupuesto[]>([]);
  const [clientes, setClientes] = useState<Cliente[]>([]);
  const [productos, setProductos] = useState<Producto[]>([]);
  const [servicios, setServicios] = useState<Servicio[]>([]);
  const [expanded, setExpanded] = useState<number | null>(null);
  const [showForm, setShowForm] = useState(false);
  const [error, setError] = useState('');
  const [form, setForm] = useState<{
    clienteId: number;
    detalles: { tipoItem: string; itemId: number; cantidad: number }[];
  }>({ clienteId: 0, detalles: [{ tipoItem: 'Producto', itemId: 0, cantidad: 1 }] });

  useEffect(() => { loadAll(); }, []);

  const loadAll = async () => {
    try {
      const [p, c, prod, serv] = await Promise.all([
        api.presupuestos.list(),
        api.clientes.list(),
        api.productos.list(),
        api.servicios.list(),
      ]);
      setItems(p);
      setClientes(c);
      setProductos(prod);
      setServicios(serv);
    } catch {
      setError('Error al cargar datos');
    }
  };

  const addDetalle = () => {
    setForm(f => ({ ...f, detalles: [...f.detalles, { tipoItem: 'Producto', itemId: 0, cantidad: 1 }] }));
  };

  const updateDetalle = (idx: number, field: string, value: unknown) => {
    setForm(f => {
      const d = [...f.detalles];
      d[idx] = { ...d[idx], [field]: value };
      return { ...f, detalles: d };
    });
  };

  const removeDetalle = (idx: number) => {
    setForm(f => ({ ...f, detalles: f.detalles.filter((_, i) => i !== idx) }));
  };

  const handleCreate = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      await api.presupuestos.create(form);
      setShowForm(false);
      setForm({ clienteId: 0, detalles: [{ tipoItem: 'Producto', itemId: 0, cantidad: 1 }] });
      setError('');
      await loadAll();
    } catch {
      setError('Error al crear presupuesto');
    }
  };

  const handleUpdateEstado = async (id: number, estado: string) => {
    try {
      await api.presupuestos.updateEstado(id, { estado });
      await loadAll();
    } catch {
      setError('Error al actualizar estado');
    }
  };

  const handleDelete = async (id: number) => {
    if (!confirm('¿Eliminar presupuesto?')) return;
    try {
      await api.presupuestos.delete(id);
      await loadAll();
    } catch {
      setError('Error al eliminar presupuesto');
    }
  };

  return (
    <div>
      <h1>Presupuestos</h1>
      {error && <p style={{ color: 'red' }}>{error}</p>}
      <button onClick={() => setShowForm(!showForm)} style={{ marginBottom: '1rem' }}>
        {showForm ? 'Cancelar' : 'Nuevo Presupuesto'}
      </button>

      {showForm && (
        <form onSubmit={handleCreate} style={{ background: '#fff', padding: '1rem', borderRadius: 8, marginBottom: '1rem' }}>
          <select value={form.clienteId} onChange={e => setForm({ ...form, clienteId: +e.target.value })} required>
            <option value={0}>Seleccionar cliente</option>
            {clientes.map(c => <option key={c.id} value={c.id}>{c.nombre}</option>)}
          </select>

          <h4>Detalles</h4>
          {form.detalles.map((d, idx) => (
            <div key={idx} style={{ display: 'flex', gap: '0.5rem', marginBottom: '0.5rem' }}>
              <select value={d.tipoItem} onChange={e => updateDetalle(idx, 'tipoItem', e.target.value)}>
                <option value="Producto">Producto</option>
                <option value="Servicio">Servicio</option>
              </select>
              <select value={d.itemId} onChange={e => updateDetalle(idx, 'itemId', +e.target.value)} required>
                <option value={0}>Seleccionar item</option>
                {(d.tipoItem === 'Producto' ? productos : servicios).map(i => (
                  <option key={i.id} value={i.id}>{(i as Producto).nombre || (i as Servicio).nombre}</option>
                ))}
              </select>
              <input type="number" min={1} placeholder="Cantidad" value={d.cantidad} onChange={e => updateDetalle(idx, 'cantidad', +e.target.value)} />
              <button type="button" onClick={() => removeDetalle(idx)}>X</button>
            </div>
          ))}
          <button type="button" onClick={addDetalle}>+ Agregar detalle</button>
          <button type="submit" style={{ marginLeft: '0.5rem' }}>Crear Presupuesto</button>
        </form>
      )}

      <table style={{ width: '100%', borderCollapse: 'collapse', background: '#fff' }}>
        <thead><tr><th>ID</th><th>Cliente</th><th>Total</th><th>Estado</th><th>Fecha</th><th>Acciones</th></tr></thead>
        <tbody>
          {items.map(p => (
            <>
              <tr key={p.id} onClick={() => setExpanded(expanded === p.id ? null : p.id)} style={{ cursor: 'pointer' }}>
                <td>{p.id}</td><td>{p.clienteNombre}</td><td>${p.total.toFixed(2)}</td>
                <td>{p.estado}</td><td>{new Date(p.fechaCreacion).toLocaleDateString()}</td>
                <td>
                  {p.estado === 'Pendiente' && (
                    <>
                      <button onClick={e => { e.stopPropagation(); handleUpdateEstado(p.id, 'Aprobado'); }}>Aprobar</button>
                      <button onClick={e => { e.stopPropagation(); handleUpdateEstado(p.id, 'Rechazado'); }} style={{ marginLeft: 4 }}>Rechazar</button>
                    </>
                  )}
                  <button onClick={e => { e.stopPropagation(); handleDelete(p.id); }} style={{ marginLeft: 4 }}>Eliminar</button>
                </td>
              </tr>
              {expanded === p.id && (
                <tr key={`det-${p.id}`}>
                  <td colSpan={6} style={{ padding: '0.5rem 1rem', background: '#fafafa' }}>
                    <strong>Detalles:</strong>
                    <ul>
                      {p.detalles.map(d => (
                        <li key={d.id}>{d.tipoItem} x{d.cantidad} - ${d.precioUnitario.toFixed(2)} c/u = ${d.subtotal.toFixed(2)}</li>
                      ))}
                    </ul>
                  </td>
                </tr>
              )}
            </>
          ))}
        </tbody>
      </table>
    </div>
  );
}
