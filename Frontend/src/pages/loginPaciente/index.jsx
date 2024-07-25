import LoginForm from '../../components/FormLogin/index'
import images from '../../assets/images/images'
import style from './LoginPaciente.module.css'
import '../../index.css'

function LoginPaciente() {
  return (
    <div className="container">
      <div className={style.backgroundPacienteDesktop}>
        <img className={style.imagePacienteDesktop} src={images.ImageLoginPacienteDesktop} />
      </div>
      <div className={style.backgroundPacienteMobile}>
        <img className={style.imagePacienteMobile} src={images.ImageLoginPacienteMobile} />
      </div>
      <div className={style.containerFormLoginPaciente}>
        <LoginForm />
      </div>
    </div>
  )
}

export default LoginPaciente