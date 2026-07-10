import { Routes, Route, NavLink } from 'react-router-dom';
import Dashboard from './pages/Dashboard';
import Productos from './pages/Productos';
import Servicios from './pages/Servicios';
import Presupuestos from './pages/Presupuestos';
import Clientes from './pages/Clientes';

const navItems = [
  { to: '/', label: 'Dashboard', icon: '📊' },
  { to: '/clientes', label: 'Clientes', icon: '👥' },
  { to: '/productos', label: 'Productos', icon: '📦' },
  { to: '/servicios', label: 'Servicios', icon: '🔧' },
  { to: '/presupuestos', label: 'Presupuestos', icon: '💰' },
];

function App() {
  return (
    <div className="flex h-screen bg-gray-50">
      <aside className="w-64 bg-indigo-900 text-white flex flex-col shrink-0">
        <div className="p-5 border-b border-indigo-800">
          <h1 className="text-xl font-bold tracking-tight flex items-center gap-2">
            <span className="w-8 h-8 bg-white text-indigo-900 rounded-lg flex items-center justify-center text-sm font-bold">PG</span>
            Panel Gestión
          </h1>
        </div>
        <nav className="flex-1 p-3 space-y-1">
          {navItems.map(item => (
            <NavLink
              key={item.to}
              to={item.to}
              end={item.to === '/'}
              className={({ isActive }) =>
                `flex items-center gap-3 px-3 py-2.5 rounded-lg text-sm font-medium transition-colors ${
                  isActive
                    ? 'bg-indigo-700 text-white shadow-sm'
                    : 'text-indigo-200 hover:bg-indigo-800 hover:text-white'
                }`
              }
            >
              <span className="text-lg">{item.icon}</span>
              {item.label}
            </NavLink>
          ))}
        </nav>
        <div className="p-4 border-t border-indigo-800 text-xs text-indigo-400">
          v1.0.0
        </div>
      </aside>
      <main className="flex-1 overflow-auto">
        <div className="max-w-7xl mx-auto px-6 py-8">
          <Routes>
            <Route path="/" element={<Dashboard />} />
            <Route path="/clientes" element={<Clientes />} />
            <Route path="/productos" element={<Productos />} />
            <Route path="/servicios" element={<Servicios />} />
            <Route path="/presupuestos" element={<Presupuestos />} />
          </Routes>
        </div>
      </main>
    </div>
  );
}

export default App;
