import PropTypes from 'prop-types'
import { useContext } from 'react'
import { Navigate } from 'react-router-dom'
import UserContext from '../../context/UserContext'

const ProtectedRoute = ({ allowedRoles, element }) => {
    const { user } = useContext(UserContext)
    console.log("allowedRoles: ", allowedRoles)
    console.log("user: ", user)

    if (!user) {
        return <Navigate to="/" />
    }

    if (allowedRoles != user.rol) {
        return <Navigate to="/" />
    }

    return element
}

ProtectedRoute.propTypes = {
    element: PropTypes.node,
    allowedRoles: PropTypes.string
}

export default ProtectedRoute