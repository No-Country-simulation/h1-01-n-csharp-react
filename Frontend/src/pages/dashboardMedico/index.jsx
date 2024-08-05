import { useNavigate } from 'react-router-dom'
import style from './DashboardMedico.module.css'
import icons from '../../assets/icons/icons'
import images from '../../assets/images/images'
import { getMedicUserData } from '../../api/medicService'
import { useState, useEffect } from 'react'
import '../../index.css'

function DashBoardMedico() {
  const [medico, setMedico] = useState(null)

  useEffect(() => {
    const fetchMedicData = async () => {
      try {
        const data = await getMedicUserData()
        setMedico(data)
      } catch (error) {
        console.error('Error fetching medic data:', error)
      }
    }

    fetchMedicData()
  }, [])

  const { firstName, lastName } = medico || {}

  const navigate = useNavigate()

  const handleNavigation = (button) => {
    navigate(`/medic-${button}`)
  }

  return (
    <div className="container">
      <div className={style.backgroundDesktop}>
        <img className={style.imageDesktop} src={images.BackgroundDashboard} alt="Background" />
      </div>
      <div className={style.containerDashboard}>
        <h1 className={style.textWelcomeMedic}>Bienvenido {firstName} {lastName},¿Que haremos hoy?</h1>
        <div className={style.divButtonDashboard}>
          <div className="buttonHome" onClick={() => handleNavigation('pacientes')}>
            <img className="iconHome" src={icons.IconPaciente} alt="Pacientes" />
            <p>Pacientes</p>
          </div>
          <div className="buttonHome" onClick={() => handleNavigation('tratamientos')}>
            <img className="iconHome" src={icons.IconMedico} alt="Tratamientos" />
            <p>Tratamientos</p>
          </div>
          <div className="buttonHome" onClick={() => handleNavigation('turnos')}>
            <img className="iconHome" src={icons.IconTurnos} alt="Turnos" />
            <p>Turnos</p>
          </div>
        </div>
      </div>
    </div>
  )
}

export default DashBoardMedico