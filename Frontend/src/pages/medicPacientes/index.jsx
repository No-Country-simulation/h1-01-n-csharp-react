import ListPatientsMedic from '../../components/ListPatientsMedic/index'
import NavBar from '../../components/NavBar/index'
import SideBar from '../../components/SideBar/index'
import style from './MedicPacientes.module.css'
import images from '../../assets/images/images'
import '../../index.css'

function MedicPacientes() {
  return (
    <div className='container'>
      <NavBar />
      <div className={style.backgroundDesktop}>
        <img className={style.imageDesktop} src={images.BackgroundDashboard} alt="Background" />
      </div>
      <div className={style.containerMedicPacientes}>
        <div className={style.sideBar}>
          <SideBar />
        </div>
        <div className={style.listPacientes}>
          <ListPatientsMedic />
        </div>
      </div>
    </div>
  )
}

export default MedicPacientes