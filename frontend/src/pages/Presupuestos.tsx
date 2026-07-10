import { useEffect, useState, Fragment } from 'react';
import { api } from '../api';
import type { Presupuesto, Cliente, Producto, Servicio } from '../api';
import { Plus, X, Trash2, Check, Ban, ChevronRight, ChevronDown } from 'lucide-react';

type DetalleForm = { tipo: string; itemId: number; cantidad: number };

export default function Presupuestos() {
  const [items, setItems] = useState<Presupuesto[]>([]);
  const [clientes, setClientes] = useState<Cliente[]>([]);
  const [productos, setProductos] = useState<Producto[]>([]);
  const [servicios, setServicios] = useState<Servicio[]>([]);
  const [expanded, setExpanded] = useState<number | null>(null);
  const [showForm, setShowForm] = useState(false);
  const [error, setError] = useState('');
  const [loading, setLoading] = useState(true);
  const [form, setForm] = useState<{ clienteId: number; items: DetalleForm[] }>({
    clienteId: 0,
    items: [{ tipo: 'Producto', itemId: 0, cantidad: 1 }],
  });

  useEffect(() => { loadAll(); }, []);

  const loadAll = async () => {
    try {
      const [p, c, prod, serv] = await Promise.all([
        api.presupuestos.list(),
        api.clientes.list(),
        api.productos.list(),
        api.servicios.list(),
      ]);
      setItems(p.sort((a, b) => a.id - b.id));
      setClientes(c);
      setProductos(prod);
      setServicios(serv);
    } catch {
      setError('Error al cargar datos');
    } finally {
      setLoading(false);
    }
  };

  const addDetalle = () => setForm(f => ({
    ...f, items: [...f.items, { tipo: 'Producto', itemId: 0, cantidad: 1 }],
  }));

  const updateDetalle = (idx: number, field: keyof DetalleForm, value: unknown) => {
    setForm(f => {
      const d = [...f.items];
      d[idx] = { ...d[idx], [field]: value };
      return { ...f, items: d };
    });
  };

  const removeDetalle = (idx: number) => {
    setForm(f => ({ ...f, items: f.items.filter((_, i) => i !== idx) }));
  };

  const handleCreate = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!form.clienteId) { setError('Seleccione un cliente'); return; }
    try {
      await api.presupuestos.create(form);
      setShowForm(false);
      setForm({ clienteId: 0, items: [{ tipo: 'Producto', itemId: 0, cantidad: 1 }] });
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
    if (!confirm('¿Eliminar este presupuesto?')) return;
    try {
      await api.presupuestos.delete(id);
      await loadAll();
    } catch {
      setError('Error al eliminar presupuesto');
    }
  };

  const estadoBadge = (estado: string) => {
    const styles: Record<string, string> = {
      Pendiente: 'bg-yellow-100 text-yellow-800',
      Aprobado: 'bg-green-100 text-green-800',
      Rechazado: 'bg-red-100 text-red-800',
    };
    return (
      <span className={`inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium ${styles[estado] || 'bg-gray-100 text-gray-800'}`}>
        {estado}
      </span>
    );
  };

  return (
    <div>
      <div className="flex items-center justify-between mb-6">
        <div>
          <h2 className="text-2xl font-bold text-gray-900">Presupuestos</h2>
          <p className="text-gray-500 mt-1">{items.length} presupuestos registrados</p>
        </div>
        <button
          onClick={() => setShowForm(!showForm)}
          className="bg-violet-600 text-white px-4 py-2.5 rounded-lg text-sm font-medium hover:bg-violet-700 transition-colors flex items-center gap-2"
        >
          {showForm ? <X className="w-4 h-4" /> : <Plus className="w-4 h-4" />}
          {showForm ? 'Cancelar' : 'Nuevo Presupuesto'}
        </button>
      </div>

      {error && (
        <div className="mb-4 bg-red-50 border border-red-200 text-red-700 px-4 py-3 rounded-lg text-sm">{error}</div>
      )}

      {showForm && (
        <form onSubmit={handleCreate} className="bg-white rounded-xl shadow-sm border border-gray-100 p-6 mb-6">
          <h3 className="text-lg font-semibold text-gray-900 mb-4">Nuevo Presupuesto</h3>
          <div className="mb-4">
            <label className="block text-sm font-medium text-gray-700 mb-1">Cliente</label>
            <select value={form.clienteId} onChange={e => setForm({ ...form, clienteId: +e.target.value })} required
              className="w-full md:w-80 px-3 py-2 border border-gray-300 rounded-lg text-sm focus:ring-2 focus:ring-violet-500 focus:border-violet-500 outline-none">
              <option value={0}>Seleccionar cliente</option>
              {clientes.map(c => <option key={c.id} value={c.id}>{c.nombre}</option>)}
            </select>
          </div>

          <div className="mb-4">
            <div className="flex items-center justify-between mb-2">
              <h4 className="text-sm font-semibold text-gray-700">Items</h4>
              <button type="button" onClick={addDetalle} className="text-violet-600 hover:text-violet-800 text-sm font-medium transition-colors flex items-center gap-1">
                <Plus className="w-3.5 h-3.5" /> Agregar
              </button>
            </div>
            <div className="space-y-3">
              {form.items.map((d, idx) => (
                <div key={idx} className="flex flex-wrap items-end gap-3 p-3 bg-gray-50 rounded-lg">
                  <div>
                    <label className="block text-xs font-medium text-gray-500 mb-1">Tipo</label>
                    <select value={d.tipo} onChange={e => updateDetalle(idx, 'tipo', e.target.value)}
                      className="px-3 py-2 border border-gray-300 rounded-lg text-sm focus:ring-2 focus:ring-violet-500 focus:border-violet-500 outline-none">
                      <option value="Producto">Producto</option>
                      <option value="Servicio">Servicio</option>
                    </select>
                  </div>
                  <div>
                    <label className="block text-xs font-medium text-gray-500 mb-1">Item</label>
                    <select value={d.itemId} onChange={e => updateDetalle(idx, 'itemId', +e.target.value)} required
                      className="px-3 py-2 border border-gray-300 rounded-lg text-sm focus:ring-2 focus:ring-violet-500 focus:border-violet-500 outline-none">
                      <option value={0}>Seleccionar</option>
                      {(d.tipo === 'Producto' ? productos : servicios).map(i => (
                        <option key={i.id} value={i.id}>{(i as Producto).nombre || (i as Servicio).nombre}</option>
                      ))}
                    </select>
                  </div>
                  <div>
                    <label className="block text-xs font-medium text-gray-500 mb-1">Cantidad</label>
                    <input type="number" min={1} value={d.cantidad} onChange={e => updateDetalle(idx, 'cantidad', +e.target.value)}
                      className="w-20 px-3 py-2 border border-gray-300 rounded-lg text-sm focus:ring-2 focus:ring-violet-500 focus:border-violet-500 outline-none" />
                  </div>
                  <button type="button" onClick={() => removeDetalle(idx)}
                    className="p-2 text-red-500 hover:text-red-700 hover:bg-red-50 rounded-lg transition-colors" title="Eliminar">
                    <Trash2 className="w-4 h-4" />
                  </button>
                </div>
              ))}
            </div>
          </div>

          <button type="submit" className="bg-violet-600 text-white px-6 py-2.5 rounded-lg text-sm font-medium hover:bg-violet-700 transition-colors flex items-center gap-2">
            <Check className="w-4 h-4" /> Crear Presupuesto
          </button>
        </form>
      )}

      <div className="bg-white rounded-xl shadow-sm border border-gray-100 overflow-hidden">
        <div className="overflow-x-auto">
          <table className="w-full text-sm">
            <thead>
              <tr className="bg-gray-50 border-b border-gray-100">
                <th className="text-left px-4 py-3 font-medium text-gray-500">ID</th>
                <th className="text-left px-4 py-3 font-medium text-gray-500">Cliente</th>
                <th className="text-left px-4 py-3 font-medium text-gray-500">Total</th>
                <th className="text-left px-4 py-3 font-medium text-gray-500">Estado</th>
                <th className="text-left px-4 py-3 font-medium text-gray-500">Fecha</th>
                <th className="text-right px-4 py-3 font-medium text-gray-500">Acciones</th>
              </tr>
            </thead>
            <tbody className="divide-y divide-gray-50">
              {loading ? (
                <tr><td colSpan={6} className="px-4 py-12 text-center text-gray-400">Cargando...</td></tr>
              ) : items.length === 0 ? (
                <tr><td colSpan={6} className="px-4 py-12 text-center text-gray-400">No hay presupuestos registrados</td></tr>
              ) : items.map(p => (
                <Fragment key={p.id}>
                  <tr className="hover:bg-gray-50 transition-colors">
                    <td className="px-4 py-3">
                      <button onClick={() => setExpanded(expanded === p.id ? null : p.id)}
                        className="text-gray-500 hover:text-gray-700 flex items-center gap-1">
                        {expanded === p.id ? <ChevronDown className="w-4 h-4" /> : <ChevronRight className="w-4 h-4" />}
                        <span className="font-mono">#{p.id}</span>
                      </button>
                    </td>
                    <td className="px-4 py-3 font-medium text-gray-900">{p.clienteNombre}</td>
                    <td className="px-4 py-3 font-semibold text-gray-900">${p.total.toLocaleString()}</td>
                    <td className="px-4 py-3">{estadoBadge(p.estado)}</td>
                    <td className="px-4 py-3 text-gray-600">{new Date(p.fechaCreacion).toLocaleDateString('es', { year: 'numeric', month: 'short', day: 'numeric' })}</td>
                    <td className="px-4 py-3 text-right">
                      {p.estado === 'Pendiente' && (
                        <>
                          <button onClick={() => handleUpdateEstado(p.id, 'Aprobado')}
                            className="text-green-600 hover:text-green-800 p-1.5 hover:bg-green-50 rounded-lg transition-colors" title="Aprobar">
                            <Check className="w-4 h-4" />
                          </button>
                          <button onClick={() => handleUpdateEstado(p.id, 'Rechazado')}
                            className="text-red-500 hover:text-red-700 p-1.5 hover:bg-red-50 rounded-lg transition-colors ml-1" title="Rechazar">
                            <Ban className="w-4 h-4" />
                          </button>
                        </>
                      )}
                      <button onClick={() => handleDelete(p.id)}
                        className="text-gray-400 hover:text-red-600 p-1.5 hover:bg-red-50 rounded-lg transition-colors ml-1" title="Eliminar">
                        <Trash2 className="w-4 h-4" />
                      </button>
                    </td>
                  </tr>
                  {expanded === p.id && (
                    <tr key={`det-${p.id}`}>
                      <td colSpan={6} className="px-4 py-4 bg-gray-50">
                        <div className="flex items-center justify-between mb-3">
                          <h3 className="text-sm font-semibold text-gray-700">Items del presupuesto #{p.id}</h3>
                          <button onClick={() => setExpanded(null)} className="text-gray-400 hover:text-gray-600 p-1 rounded-lg hover:bg-gray-100 transition-colors" title="Cerrar">
                            <X className="w-4 h-4" />
                          </button>
                        </div>
                        {p.items.length === 0 ? (
                          <p className="text-gray-400 text-sm">Sin items</p>
                        ) : (
                          <div className="space-y-2">
                            {p.items.map(d => (
                              <div key={d.id} className="flex items-center justify-between bg-white rounded-lg border border-gray-200 px-4 py-3">
                                <div className="flex items-center gap-3">
                                  <span className={`w-2 h-2 rounded-full ${d.tipo === 'Producto' ? 'bg-emerald-400' : 'bg-amber-400'}`} />
                                  <div>
                                    <span className="font-medium text-gray-900">{d.nombreItem}</span>
                                    <span className="text-gray-400 text-xs ml-2">{d.tipo}</span>
                                  </div>
                                  <span className="text-gray-400 text-sm">×{d.cantidad}</span>
                                </div>
                                <div className="text-right">
                                  <span className="text-gray-500 text-xs block">${d.precioUnitario.toFixed(2)} c/u</span>
                                  <span className="font-semibold text-gray-900">${d.subtotal.toFixed(2)}</span>
                                </div>
                              </div>
                            ))}
                            <div className="flex justify-between items-center pt-3 border-t border-gray-200">
                              <span className="text-gray-500 text-sm">{p.items.length} {p.items.length === 1 ? 'item' : 'items'}</span>
                              <span className="text-xl font-bold text-gray-900">Total: ${p.total.toLocaleString()}</span>
                            </div>
                          </div>
                        )}
                      </td>
                    </tr>
                  )}
                </Fragment>
              ))}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  );
}
