import { BrowserRouter as Router, Route, Routes } from 'react-router-dom'
import Home from './pages/home/index'
import Login from './pages/login/index'
import RegisterMedico from './pages/registerMedico/index'
import RegisterPaciente from './pages/registerPaciente/index'
import DashboardMedico from './pages/dashboardMedico/index'
import DashboardPaciente from './pages/dashboardPaciente/index'
import MedicPacientes from './pages/medicPacientes/index'
import MedicTratamientos from './pages/medicTratamientos/index'
import MedicTurnos from './pages/medicTurnos/index'
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
          <Route path="/dashboard-medico" element={<DashboardMedico />} />
          <Route path="/dashboard-paciente" element={<DashboardPaciente />} />
          <Route path="/medic-pacientes" element={<MedicPacientes />} />
          <Route path="/medic-tratamientos" element={<MedicTratamientos />} />
          <Route path="/medic-turnos" element={<MedicTurnos />} />
        </Routes>
      </Router>
    </UserProvider>
  )
}

export default App