import { createContext, useState, useEffect } from 'react'
import PropTypes from 'prop-types'

function parseJwt(token) {
  try {
    const base64Url = token.split('.')[1]
    const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/')
    const jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
      return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2)
    }).join(''))

    const decoded = JSON.parse(jsonPayload)

    if (decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]) {
      decoded.rol = decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]
      delete decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]
    }

    return decoded
  } catch (e) {
    console.error('Invalid JWT token:', e)
    return null
  }
}

const UserContext = createContext()

export const UserProvider = ({ children }) => {
  const [user, setUser] = useState(null)

  useEffect(() => {
    const token = localStorage.getItem('token')
    if (token) {
      const decodedUser = parseJwt(token)
      if (decodedUser) {
        setUser(decodedUser)
      }
    }
  }, [])

  console.log("token", user)

  const login = async (token) => {
    const decodedUser = parseJwt(token);
    if (decodedUser) {
      localStorage.setItem('token', token);
      setUser(decodedUser);
      return decodedUser;
    } else {
      throw new Error('Invalid token');
    }
  }

  return (
    <UserContext.Provider value={{ user, setUser, login }}>
      {children}
    </UserContext.Provider>
  )
}

UserProvider.propTypes = {
  children: PropTypes.node
}

export default UserContext