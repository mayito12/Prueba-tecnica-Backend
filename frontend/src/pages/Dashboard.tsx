import { useEffect, useState } from 'react';
import { api } from '../api';
import { Users, Package, Wrench, DollarSign, Clock, TrendingUp } from 'lucide-react';

interface DashData {
  totalClientes: number; totalProductos: number; totalServicios: number;
  totalPresupuestos: number; presupuestosPendientes: number; ingresosTotales: number;
}

export default function Dashboard() {
  const [data, setData] = useState<DashData | null>(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const load = async () => {
      try {
        const [clientes, productos, servicios, presupuestos] = await Promise.all([
          api.clientes.list(),
          api.productos.list(),
          api.servicios.list(),
          api.presupuestos.list(),
        ]);
        setData({
          totalClientes: clientes.length,
          totalProductos: productos.length,
          totalServicios: servicios.length,
          totalPresupuestos: presupuestos.length,
          presupuestosPendientes: presupuestos.filter(p => p.estado === 'Pendiente').length,
          ingresosTotales: presupuestos.filter(p => p.estado === 'Aprobado').reduce((sum, p) => sum + p.total, 0),
        });
      } catch {
        setData({ totalClientes: 0, totalProductos: 0, totalServicios: 0, totalPresupuestos: 0, presupuestosPendientes: 0, ingresosTotales: 0 });
      } finally {
        setLoading(false);
      }
    };
    load();
  }, []);

  const cards = [
    { label: 'Clientes', value: data?.totalClientes ?? 0, icon: Users, color: 'from-blue-500 to-blue-600' },
    { label: 'Productos', value: data?.totalProductos ?? 0, icon: Package, color: 'from-emerald-500 to-emerald-600' },
    { label: 'Servicios', value: data?.totalServicios ?? 0, icon: Wrench, color: 'from-amber-500 to-amber-600' },
    { label: 'Presupuestos', value: data?.totalPresupuestos ?? 0, icon: DollarSign, color: 'from-violet-500 to-violet-600' },
    { label: 'Pendientes', value: data?.presupuestosPendientes ?? 0, icon: Clock, color: 'from-rose-500 to-rose-600' },
    { label: 'Ingresos', value: `$${(data?.ingresosTotales ?? 0).toLocaleString()}`, icon: TrendingUp, color: 'from-teal-500 to-teal-600' },
  ];

  if (loading) {
    return (
      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
        {[...Array(6)].map((_, i) => (
          <div key={i} className="h-32 bg-white rounded-xl animate-pulse" />
        ))}
      </div>
    );
  }

  return (
    <div>
      <div className="mb-8">
        <h2 className="text-2xl font-bold text-gray-900">Dashboard</h2>
        <p className="text-gray-500 mt-1">Resumen general del sistema</p>
      </div>
      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
        {cards.map(c => {
          const Icon = c.icon;
          return (
            <div key={c.label} className="bg-white rounded-xl shadow-sm border border-gray-100 overflow-hidden hover:shadow-md transition-shadow">
              <div className={`bg-gradient-to-r ${c.color} px-5 py-4`}>
                <Icon className="w-6 h-6 text-white" />
              </div>
              <div className="px-5 py-4">
                <p className="text-sm font-medium text-gray-500">{c.label}</p>
                <p className="text-3xl font-bold text-gray-900 mt-1">{c.value}</p>
              </div>
            </div>
          );
        })}
      </div>
    </div>
  );
}
