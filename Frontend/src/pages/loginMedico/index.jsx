import LoginForm from '../../components/FormLogin/index'
import images from '../../assets/images/images'
import style from './LoginMedico.module.css'
import '../../index.css'

function LoginMedico() {
  return (
    <div className="container">
      <div className={style.backgroundMedico}>
        <img className={style.imageMedico} src={images.ImageLoginMedico} />
      </div>
      <div className={style.containerFormLoginMedico}>
        <LoginForm />
      </div>
    </div>
  )
}

export default LoginMedico