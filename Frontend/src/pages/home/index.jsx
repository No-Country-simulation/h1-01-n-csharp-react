import { useNavigate } from 'react-router-dom'
import style from './Home.module.css'
import icons from '../../assets/icons/icons'
import images from '../../assets/images/images'
import '../../index.css'

function Home() {
    const navigate = useNavigate()

    const handleNavigation = (userType) => {
        navigate(`/login?userType=${userType}`)
    }

    return (
        <div className="container">
            <div className={style.backgroundDesktop}>
                <img className={style.imageDesktop} src={images.BackgroundDesktop} alt="Background" />
            </div>
            <div className={style.containerHome}>
                <img className={style.logoHome} src={images.LogoJustina2} alt="Logo" />
                <h1>Elige tu perfil</h1>
                <div className={style.divButtonHome}>
                    <div className="buttonHome" onClick={() => handleNavigation('Pacient')}>
                        <img className="iconHome" src={icons.IconPaciente} alt="Paciente" />
                        <p>Paciente</p>
                    </div>
                    <div className="buttonHome" onClick={() => handleNavigation('Medic')}>
                        <img className="iconHome" src={icons.IconMedico} alt="Medico" />
                        <p>Medico</p>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default Home