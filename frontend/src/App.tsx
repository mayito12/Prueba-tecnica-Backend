import { Routes, Route, NavLink } from 'react-router-dom';
import Dashboard from './pages/Dashboard';
import Productos from './pages/Productos';
import Servicios from './pages/Servicios';
import Presupuestos from './pages/Presupuestos';
import Clientes from './pages/Clientes';

function App() {
  return (
    <div style={{ display: 'flex', minHeight: '100vh', fontFamily: 'Inter, sans-serif' }}>
      <nav style={navStyle}>
        <h2 style={{ padding: '0 1rem', color: '#fff' }}>Panel</h2>
        <NavLink to="/" style={linkStyle} end>Dashboard</NavLink>
        <NavLink to="/productos" style={linkStyle}>Productos</NavLink>
        <NavLink to="/servicios" style={linkStyle}>Servicios</NavLink>
        <NavLink to="/presupuestos" style={linkStyle}>Presupuestos</NavLink>
        <NavLink to="/clientes" style={linkStyle}>Clientes</NavLink>
      </nav>
      <main style={{ flex: 1, padding: '2rem', background: '#f5f5f5' }}>
        <Routes>
          <Route path="/" element={<Dashboard />} />
          <Route path="/productos" element={<Productos />} />
          <Route path="/servicios" element={<Servicios />} />
          <Route path="/presupuestos" element={<Presupuestos />} />
          <Route path="/clientes" element={<Clientes />} />
        </Routes>
      </main>
    </div>
  );
}

const navStyle: React.CSSProperties = {
  width: 220,
  background: '#1a1a2e',
  padding: '1rem 0',
  display: 'flex',
  flexDirection: 'column',
  gap: '0.25rem',
};

const linkStyle: React.CSSProperties = {
  padding: '0.75rem 1rem',
  color: '#ccc',
  textDecoration: 'none',
  fontSize: '0.95rem',
};

export default App;
