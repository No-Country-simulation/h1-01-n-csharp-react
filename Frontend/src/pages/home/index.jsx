import style from './Home.module.css'
import icons from '../../assets/icons/icons'
import images from '../../assets/images/images'
import '../../index.css'

function Home() {
    return (
        <div className="container">
            <div className={style.backgroundDesktop}>
                <img className={style.imageDesktop} src={images.BackgroundDesktop}/>
            </div>
            <div className={style.containerHome}>
                <img className={style.logoHome} src={images.LogoJustina2} />
                <h1>Elige tu perfil</h1>
                <div className={style.divButtonHome}>
                    <div className={style.buttonHome}>
                        <img className={style.iconHome} src={icons.IconPaciente} />
                        <p>Paciente</p>
                    </div>
                    <div className={style.buttonHome}>
                        <img className={style.iconHome} src={icons.IconMedico} />
                        <p>Medico</p>
                    </div>
                </div>
            </div>

        </div>
    )
}

export default Home