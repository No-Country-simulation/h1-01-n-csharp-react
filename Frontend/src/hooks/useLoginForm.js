import { useState } from 'react'
import { authenticateUser } from '../api/userService'
import { jwtDecode } from 'jwt-decode'
import { useNavigate } from 'react-router-dom'

const useLoginForm = (userType) => {
  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')
  const [error, setError] = useState('')
  const navigate = useNavigate()
  const registerRoute = userType === 'Medic' ? '/register-medico' : userType === 'Pacient' ? '/register-paciente' : '/'

  const handleSubmit = async (e) => {
    e.preventDefault()

    if (!email || !password) {
      setError('Por favor, rellena todos los campos.')
      return
    }

    try {
      const response = await authenticateUser({ email, password })
      if (response && response.token) {
        const decodedUser = jwtDecode(response.token)
        const typeUser = decodedUser["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]

        if (typeUser === userType) {
          localStorage.setItem('token', response.token)
          const dashboardRoute = userType === 'Medic' ? '/dashboard-medico' : '/dashboard-paciente'
          navigate(dashboardRoute)
        } else {
          setError('Tipo de usuario incorrecto.')
          return;
        }
      }
    } catch (error) {
      setError('Error al autenticar el usuario.')
    }
  }

  return {
    email,
    setEmail,
    password,
    setPassword,
    error,
    handleSubmit,
    registerRoute
  }
}

export default useLoginForm