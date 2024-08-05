import { useState, useContext } from 'react'
import { authenticateUser } from '../api/userService'
import { useNavigate } from 'react-router-dom'
import UserContext from '../context/UserContext'

const useLoginForm = (userType) => {
  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')
  const [error, setError] = useState('')
  const navigate = useNavigate()
  const { login } = useContext(UserContext);
  const registerRoute = userType === 'Medic' ? `/register-medico?userType=${userType}` : userType === 'Pacient' ? `/register-paciente?userType=${userType}` : '/'

  const handleSubmit = async (e) => {
    e.preventDefault()

    if (!email || !password) {
      setError('Por favor, rellena todos los campos.')
      return
    }

    try {
      const response = await authenticateUser({ email, password })
      if (response && response.token) {
        const decodedUser = await login(response.token)

        if (decodedUser.rol === userType) {
          const dashboardRoute = userType === 'Medic' ? '/dashboard-medico' : userType === 'Pacient' ? '/dashboard-paciente' : '/'
          navigate(dashboardRoute)
        } else {
          setError('Tipo de usuario incorrecto.')
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
