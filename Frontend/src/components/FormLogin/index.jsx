import PropTypes from 'prop-types'
import { Link } from 'react-router-dom'
import useLoginForm from '../../hooks/useLoginForm'
import images from '../../assets/images/images'
import icons from '../../assets/icons/icons'
import style from './FormLogin.module.css'
import '../../index.css'

function FormLogin({ userType }) {
  const { email, setEmail, password, setPassword, error, handleSubmit, registerRoute } = useLoginForm(userType)

  return (
    <div className={style.containerLoginForm}>
      <div className="containerLogo">
        <img className="logoJustina" src={images.LogoJustina2} alt="Logo" />
        <h1>Inicia sesión</h1>
      </div>
      {error && <p className="error">{error}</p>}
      <form className="form" onSubmit={handleSubmit}>
        <div className="divInput">
          <label className="labelJustina" htmlFor="email">Email Address</label>
          <input
            className="inputJustina"
            type="text"
            id="email"
            name="email"
            placeholder="youremail@gmail.com"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
          />
        </div>
        <div className="divInput">
          <label className="labelJustina" htmlFor="password">Password</label>
          <input
            className="inputJustina"
            type="password"
            id="password"
            name="password"
            placeholder="**********"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
        </div>
        <div className={style.divRemember}>
          <a className={style.recoverAccount} href="">¿Olvidaste tu contraseña?</a>
        </div>
        <button className="buttonLogin" type="submit">
          <img src={icons.ArrowRight} alt="Arrow Right" />Entrar
        </button>
      </form>
      <p>¿No tienes cuenta? <Link className={style.registerLink} to={registerRoute}>Registrate aquí</Link></p>
    </div>
  )
}

FormLogin.propTypes = {
  userType: PropTypes.string
}

export default FormLogin