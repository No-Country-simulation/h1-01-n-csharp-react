import { useLocation } from 'react-router-dom'
import PropTypes from 'prop-types'
import LoginForm from '../../components/FormLogin/index'
import images from '../../assets/images/images'
import style from './Login.module.css'

function Login() {
  const location = useLocation()
  const params = new URLSearchParams(location.search)
  const userType = params.get('userType')

  return (
    <div className="container">
      <div className={style.backgroundLogin}>
        {userType === 'Medic' ? (
          <img className={style.imageLogin} src={images.ImageLoginMedico} alt="Medico" />
        ) : (
          <img className={style.imageLogin} src={images.ImageLoginPaciente} alt="Paciente" />
        )}
      </div>
      <div className={style.containerFormLoginMedico}>
        <LoginForm userType={userType}/>
      </div>
    </div>
  );
}

Login.propTypes = {
  userType: PropTypes.string
}

export default Login