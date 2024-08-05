import { useLocation, useNavigate } from 'react-router-dom'
import style from './SideBar.module.css'
import icons from '../../assets/icons/icons'

function SideBar() {
  const location = useLocation()
  const navigate = useNavigate()
  const path = location.pathname

  const isActive = (pathToCheck) => path === pathToCheck

  const handleNavigation = (route) => {
    navigate(route)
  }

  return (
    <div className={style.containerSidebar}>
      <div
        className={`${style.buttonSidebar} ${isActive('/medic-pacientes') ? style.buttonActive : ''}`}
        onClick={() => handleNavigation('/medic-pacientes')}
      >
        <div
          className={`${style.divLogoSidebar} ${isActive('/medic-pacientes') ? style.divActive : ''}`}
        >
          <img className={style.logoSidebar} src={icons.IconPaciente} alt="logoPacientes" />
        </div>
        <h1>Pacientes</h1>
      </div>
      <div
        className={`${style.buttonSidebar} ${isActive('/medic-tratamientos') ? style.buttonActive : ''}`}
        onClick={() => handleNavigation('/medic-tratamientos')}
      >
        <div
          className={`${style.divLogoSidebar} ${isActive('/medic-tratamientos') ? style.divActive : ''}`}
        >
          <img className={style.logoSidebar} src={icons.IconMedico} alt="logoTratamientos" />
        </div>
        <h1>Tratamientos</h1>
      </div>
      <div
        className={`${style.buttonSidebar} ${isActive('/medic-turnos') ? style.buttonActive : ''}`}
        onClick={() => handleNavigation('/medic-turnos')}
      >
        <div
          className={`${style.divLogoSidebar} ${isActive('/medic-turnos') ? style.divActive : ''}`}
        >
          <img className={style.logoSidebar} src={icons.IconTurnos} alt="logoTurnos" />
        </div>
        <h1>Turnos</h1>
      </div>
    </div>
  )
}

export default SideBar