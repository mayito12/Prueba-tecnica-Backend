import { useEffect, useState } from 'react';
import { api } from '../api';
import type { Servicio } from '../api';
import { Plus, X, Pencil, Trash2, Save } from 'lucide-react';

export default function ServiciosPage() {
  const [items, setItems] = useState<Servicio[]>([]);
  const [form, setForm] = useState({ nombre: '', descripcion: '', precioPorHora: 0 });
  const [editing, setEditing] = useState<number | null>(null);
  const [showForm, setShowForm] = useState(false);
  const [error, setError] = useState('');
  const [loading, setLoading] = useState(true);

  useEffect(() => { load(); }, []);

  const load = async () => {
    try {
      const data = await api.servicios.list();
      setItems(data.sort((a, b) => a.id - b.id));
    } catch {
      setError('Error al cargar servicios');
    } finally {
      setLoading(false);
    }
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!form.nombre.trim()) return;
    try {
      if (editing) {
        await api.servicios.update(editing, form);
      } else {
        await api.servicios.create(form);
      }
      setForm({ nombre: '', descripcion: '', precioPorHora: 0 });
      setEditing(null);
      setShowForm(false);
      setError('');
      await load();
    } catch {
      setError('Error al guardar servicio');
    }
  };

  const handleEdit = (item: Servicio) => {
    setForm({ nombre: item.nombre, descripcion: item.descripcion || '', precioPorHora: item.precioPorHora });
    setEditing(item.id);
    setShowForm(true);
  };

  const handleDelete = async (id: number) => {
    if (!confirm('¿Eliminar este servicio?')) return;
    try {
      await api.servicios.delete(id);
      await load();
    } catch {
      setError('Error al eliminar servicio');
    }
  };

  const cancelForm = () => {
    setForm({ nombre: '', descripcion: '', precioPorHora: 0 });
    setEditing(null);
    setShowForm(false);
    setError('');
  };

  return (
    <div>
      <div className="flex items-center justify-between mb-6">
        <div>
          <h2 className="text-2xl font-bold text-gray-900">Servicios</h2>
          <p className="text-gray-500 mt-1">{items.length} servicios registrados</p>
        </div>
        <button
          onClick={() => setShowForm(!showForm)}
          className="bg-amber-600 text-white px-4 py-2.5 rounded-lg text-sm font-medium hover:bg-amber-700 transition-colors flex items-center gap-2"
        >
          {showForm ? <X className="w-4 h-4" /> : <Plus className="w-4 h-4" />}
          {showForm ? 'Cancelar' : 'Nuevo Servicio'}
        </button>
      </div>

      {error && (
        <div className="mb-4 bg-red-50 border border-red-200 text-red-700 px-4 py-3 rounded-lg text-sm">{error}</div>
      )}

      {showForm && (
        <form onSubmit={handleSubmit} className="bg-white rounded-xl shadow-sm border border-gray-100 p-6 mb-6">
          <h3 className="text-lg font-semibold text-gray-900 mb-4">{editing ? 'Editar Servicio' : 'Nuevo Servicio'}</h3>
          <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Nombre</label>
              <input value={form.nombre} onChange={e => setForm({ ...form, nombre: e.target.value })} required
                className="w-full px-3 py-2 border border-gray-300 rounded-lg text-sm focus:ring-2 focus:ring-amber-500 focus:border-amber-500 outline-none" placeholder="Nombre del servicio" />
            </div>
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Descripción</label>
              <input value={form.descripcion} onChange={e => setForm({ ...form, descripcion: e.target.value })}
                className="w-full px-3 py-2 border border-gray-300 rounded-lg text-sm focus:ring-2 focus:ring-amber-500 focus:border-amber-500 outline-none" placeholder="Descripción opcional" />
            </div>
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Precio por hora</label>
              <input type="number" step="0.01" min="0" value={form.precioPorHora} onChange={e => setForm({ ...form, precioPorHora: +e.target.value })} required
                className="w-full px-3 py-2 border border-gray-300 rounded-lg text-sm focus:ring-2 focus:ring-amber-500 focus:border-amber-500 outline-none" placeholder="0.00" />
            </div>
          </div>
          <div className="flex gap-3 mt-4">
            <button type="submit" className="bg-amber-600 text-white px-5 py-2 rounded-lg text-sm font-medium hover:bg-amber-700 transition-colors flex items-center gap-2">
              <Save className="w-4 h-4" /> {editing ? 'Actualizar' : 'Crear'}
            </button>
            <button type="button" onClick={cancelForm} className="bg-gray-100 text-gray-700 px-5 py-2 rounded-lg text-sm font-medium hover:bg-gray-200 transition-colors flex items-center gap-2">
              <X className="w-4 h-4" /> Cancelar
            </button>
          </div>
        </form>
      )}

      <div className="bg-white rounded-xl shadow-sm border border-gray-100 overflow-hidden">
        <div className="overflow-x-auto">
          <table className="w-full text-sm">
            <thead>
              <tr className="bg-gray-50 border-b border-gray-100">
                <th className="text-left px-4 py-3 font-medium text-gray-500">ID</th>
                <th className="text-left px-4 py-3 font-medium text-gray-500">Nombre</th>
                <th className="text-left px-4 py-3 font-medium text-gray-500">Precio/hora</th>
                <th className="text-right px-4 py-3 font-medium text-gray-500">Acciones</th>
              </tr>
            </thead>
            <tbody className="divide-y divide-gray-50">
              {loading ? (
                <tr><td colSpan={4} className="px-4 py-12 text-center text-gray-400">Cargando...</td></tr>
              ) : items.length === 0 ? (
                <tr><td colSpan={4} className="px-4 py-12 text-center text-gray-400">No hay servicios registrados</td></tr>
              ) : items.map(i => (
                <tr key={i.id} className="hover:bg-gray-50 transition-colors">
                  <td className="px-4 py-3 text-gray-500">#{i.id}</td>
                  <td className="px-4 py-3 font-medium text-gray-900">{i.nombre}</td>
                  <td className="px-4 py-3 text-gray-600 font-medium">${i.precioPorHora.toFixed(2)}</td>
                  <td className="px-4 py-3 text-right">
                    <button onClick={() => handleEdit(i)} className="text-amber-600 hover:text-amber-800 p-1.5 hover:bg-amber-50 rounded-lg transition-colors" title="Editar">
                      <Pencil className="w-4 h-4" />
                    </button>
                    <button onClick={() => handleDelete(i.id)} className="text-red-500 hover:text-red-700 p-1.5 hover:bg-red-50 rounded-lg transition-colors ml-1" title="Eliminar">
                      <Trash2 className="w-4 h-4" />
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  );
}
