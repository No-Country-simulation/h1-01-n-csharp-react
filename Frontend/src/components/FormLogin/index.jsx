import images from '../../assets/images/images'
import style from './FormLogin.module.css'
import '../../index.css'

function FormLogin() {

  return (
    <div className={style.containerLoginForm}>
      <div className="containerLogo">
        <img className="logoJustina" src={images.LogoJustina} />
        <h1 >Inicia sesión</h1>
      </div>
      <form className="form">
        <div className="divInput">
          <label className="labelJustina" htmlFor="email">Email Address</label>
          <input className="inputJustina" type="text" id='email' name='email' placeholder='youremail@gmail.com' />
        </div>
        <div className="divInput">
          <label className="labelJustina" htmlFor="password">Password</label>
          <input className="inputJustina" type="password" id='password' name='password' placeholder='**********' />
        </div>
        <div className={style.divRemember}>
          <a className={style.recoverAccount} href="">¿Olvidaste tu contraseña?</a>
        </div>
        <button className="buttonLogin">Entrar</button>
      </form>
      <p >¿No tienes cuenta? <a className={style.registerLink} href="">Registrate aquí</a></p>
    </div>
  )
}

export default FormLogin