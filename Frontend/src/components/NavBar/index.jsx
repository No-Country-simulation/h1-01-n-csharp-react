import style from './NavBar.module.css'
import images from '../../assets/images/images'
import { useState, useEffect } from 'react'
import { getMedicUserData } from '../../api/medicService'

function NavBar() {
  const [medico, setMedico] = useState(null)

  useEffect(() => {
    const fetchMedicData = async () => {
      try {
        const data = await getMedicUserData()
        setMedico(data)
      } catch (error) {
        console.error('Error fetching medic data:', error)
      }
    }

    fetchMedicData()
  }, [])

  const { firstName = '', lastName = '' } = medico || {}
  const firstInitial = firstName.charAt(0)
  const lastInitial = lastName.charAt(0)

  return (
    <div className={style.containerNavbar}>
      <img className={style.logoNavbar} src={images.LogoJustina} alt="logo" />
      <h1 className={style.imageSesion}>{firstInitial}{lastInitial}</h1>
    </div>
  )
}

export default NavBar