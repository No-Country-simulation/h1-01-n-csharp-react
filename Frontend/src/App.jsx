import { BrowserRouter as Router, Route, Routes } from 'react-router-dom'
import Home from './pages/home/index'
import Login from './pages/login/index'
import RegisterMedico from './pages/registerMedico/index'
import RegisterPaciente from './pages/registerPaciente/index'
import DashboardMedico from './pages/dashboardMedico/index'
import DashboardPaciente from './pages/dashboardPaciente/index'
import ProtectedRoute from './components/ProtectedRoute/index'
import { UserProvider } from './context/UserContext'
import './App.css'

function App() {

  return (
    <UserProvider>
      <Router>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/login" element={<Login />} />
          <Route path="/register-medico" element={<RegisterMedico />} />
          <Route path="/register-paciente" element={<RegisterPaciente />} />
          <Route
            path="/dashboard-medico"
            element={<ProtectedRoute allowedRoles='Medic' element={<DashboardMedico />} />}
          />
          <Route
            path="/dashboard-paciente"
            element={<ProtectedRoute allowedRoles='Pacient' element={<DashboardPaciente />} />}
          />
        </Routes>
      </Router>
    </UserProvider>
  )
}

export default App