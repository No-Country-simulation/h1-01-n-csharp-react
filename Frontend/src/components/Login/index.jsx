import images from '../../assets/images/images'
import style from './Login.module.css'

function Login() {
  return (
    <div className={style.containerLogin}>
      <div className={style.containerLogo}>
        <img src={images.LogoJustina}/>
        <h1 className={style.bienvenida}>Nos alegra verte de nuevo</h1>
      </div>
      <form className={style.formLogin}>
        <div className={style.divInput}>
          <label htmlFor="email">Correo electronico</label>
          <input type="text" id='email' name='email' />
        </div>
        <div className={style.divInput}>
          <label htmlFor="password">Contraseña</label>
          <input type="password" id='password' name='password' />
          <span>La contraseña debe contener 8 caracteres incluyendo una letra mayuscula.</span>
        </div>
        <div className={style.divRemember}>
          <div>
            <input type="checkbox" id='recordarme' name='recordarme'/>
            <label htmlFor="recordarme">Recordarme</label>
          </div>
          <a href="">¿Olvidaste tu contraseña?</a>
        </div>
        <button>Ingresar</button>
        <p className={style.politicasCondiciones}>Da click en “ingresar” si tu certificas que estas de acuerdo con 
          las <a href="">politicas de privacidad</a> y <a href="">terminos y condiciones.</a></p>
      </form>
      <p className={style.comunicarse}>¿No tienes usuario? Comunicarse con su entidad de salud </p>
    </div>
  )
}

export default Login