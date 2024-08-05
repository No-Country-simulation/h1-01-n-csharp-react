import FormRegister from "../../components/FormRegister"
import { useLocation } from 'react-router-dom'
import style from './RegisterPaciente.module.css'
import images from '../../assets/images/images'
import '../../index.css'

function RegisterPaciente() {
  const location = useLocation()
  const params = new URLSearchParams(location.search)
  const userType = params.get('userType')

  return (
    <div className='container'>
      <div className={style.backgroundRegister}>
        <img className={style.imageRegister} src={images.BackgroundDesktop} />
      </div>
      <div className={style.containerRegisterPaciente}>
        <div className={style.containerPhoto}>
          <img className={style.logoPhoto} src={images.LogoJustina} />
          
        </div>
        <div className={style.containerFormRegisterPaciente}>
          <FormRegister userType={userType} />
        </div>
      </div>
    </div>
  )
}

export default RegisterPaciente