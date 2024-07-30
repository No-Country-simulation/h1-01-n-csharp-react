import { createContext, useState, useEffect } from 'react'
import PropTypes from 'prop-types'
import { jwtDecode } from 'jwt-decode'

const UserContext = createContext()

export const UserProvider = ({ children }) => {
  const [user, setUser] = useState(null)

  useEffect(() => {
    const token = localStorage.getItem('token')
    if (token) {
      const decodedUser = jwtDecode(token)
      
      const { "http://schemas.microsoft.com/ws/2008/06/identity/claims/role": rol, ...rest } = decodedUser
      const userWithRenamedKey = {
        ...rest,
        rol
      }
      
      setUser(userWithRenamedKey)
    }
  }, [])

  return (
    <UserContext.Provider value={{ user, setUser }}>
      {children}
    </UserContext.Provider>
  )
}

UserProvider.propTypes = {
  children: PropTypes.node
}

export default UserContext