import { useLocation } from 'react-router-dom'
import PropTypes from 'prop-types'
import LoginForm from '../../components/FormLogin/index'
import images from '../../assets/images/images'
import style from './LoginMedico.module.css'

function Login() {
  const location = useLocation()
  const params = new URLSearchParams(location.search)
  const userType = params.get('userType')

  return (
    <div className="container">
      <div className={style.backgroundLogin}>
        {userType === 'medico' ? (
          <img className={style.imageLogin} src={images.ImageLoginMedico} alt="Medico" />
        ) : (
          <img className={style.imageLogin} src={images.ImageLoginPaciente} alt="Paciente" />
        )}
      </div>
      <div className={style.containerFormLoginMedico}>
        <LoginForm />
      </div>
    </div>
  );
}

Login.propTypes = {
  userType: PropTypes.string
}

export default Login