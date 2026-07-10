import { useEffect, useState } from 'react';
import { api } from '../api';
import type { DashboardData } from '../api';

export default function Dashboard() {
  const [data, setData] = useState<DashboardData | null>(null);

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
        setData({
          totalClientes: 0, totalProductos: 0, totalServicios: 0,
          totalPresupuestos: 0, presupuestosPendientes: 0, ingresosTotales: 0,
        });
      }
    };
    load();
  }, []);

  const cards = data ? [
    { label: 'Clientes', value: data.totalClientes },
    { label: 'Productos', value: data.totalProductos },
    { label: 'Servicios', value: data.totalServicios },
    { label: 'Presupuestos', value: data.totalPresupuestos },
    { label: 'Pendientes', value: data.presupuestosPendientes },
    { label: 'Ingresos', value: `$${data.ingresosTotales.toFixed(2)}` },
  ] : [];

  return (
    <div>
      <h1>Dashboard</h1>
      <div style={{ display: 'grid', gridTemplateColumns: 'repeat(3, 1fr)', gap: '1rem', marginTop: '1rem' }}>
        {cards.map(c => (
          <div key={c.label} style={cardStyle}>
            <h3>{c.label}</h3>
            <p style={{ fontSize: '2rem', fontWeight: 700, margin: 0 }}>{c.value}</p>
          </div>
        ))}
      </div>
    </div>
  );
}

const cardStyle: React.CSSProperties = {
  background: '#fff',
  borderRadius: 8,
  padding: '1.5rem',
  boxShadow: '0 1px 3px rgba(0,0,0,0.1)',
};
