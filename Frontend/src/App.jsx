import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Home from './pages/home/index'
import Login from './pages/login/index'
import RegisterMedico from './pages/registerMedico/index'
import './App.css'

function App() {

  return (
    <Router>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/login" element={<Login />} />
        <Route path="/register-medico" element={<RegisterMedico />} />
      </Routes>
    </Router>
  )
}

export default App