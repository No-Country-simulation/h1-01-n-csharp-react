import { useState, useEffect } from 'react'
import style from './ListPatientsMedic.module.css'
import { getMedicPatients } from '../../api/medicService'
import icons from '../../assets/icons/icons'
import images from '../../assets/images/images'
import Modal from '../Modal/index'
import AddPatient from '../AddPatient/index'
import TreatmentPatient from '../TreatmentPatient/index'

function calculateAge(birthDate) {
  const birth = new Date(birthDate)
  const today = new Date()
  let age = today.getFullYear() - birth.getFullYear()
  const monthDifference = today.getMonth() - birth.getMonth()

  if (monthDifference < 0 || (monthDifference === 0 && today.getDate() < birth.getDate())) {
    age--
  }
  return age
}

function getRandomColor() {
  const letters = '0123456789ABCDEF'
  let color = '#'
  for (let i = 0; i < 6; i++) {
    color += letters[Math.floor(Math.random() * 16)]
  }
  return color
}

function ListPatientsMedic() {
  const [isModalOpen, setIsModalOpen] = useState(false)
  const [patients, setPatients] = useState([])
  const [searchTerm, setSearchTerm] = useState('')
  const [selectedPatientId, setSelectedPatientId] = useState(null)

  const openModal = () => {
    setIsModalOpen(true)
  }

  const closeModal = () => {
    setIsModalOpen(false)
  }

  useEffect(() => {
    const fetchPatients = async () => {
      try {
        const data = await getMedicPatients()
        setPatients(data)
        console.log('pacientes', data)
      } catch (error) {
        console.error('Error fetching patients:', error)
      }
    }

    fetchPatients()
  }, [])

  const handleSearchChange = (e) => {
    setSearchTerm(e.target.value)
  }

  const handlePatientClick = (patientId) => {
    setSelectedPatientId(selectedPatientId === patientId ? null : patientId)
  }

  const handleBackClick = () => {
    setSelectedPatientId(null)
  }

  const filteredPatients = patients.filter((patient) => {
    const fullName = `${patient.firstName} ${patient.lastName}`.toLowerCase()
    return fullName.includes(searchTerm.toLowerCase())
  })

  const [windowWidth, setWindowWidth] = useState(window.innerWidth)

  useEffect(() => {
    const handleResize = () => setWindowWidth(window.innerWidth)
    window.addEventListener('resize', handleResize)
    return () => window.removeEventListener('resize', handleResize)
  }, [])

  return (
    <div className={style.containerList}>
      {!selectedPatientId && (
        <div className={style.searchPatient}>
          <div className={style.searchBar}>
            <img className={style.iconSearch} src={icons.IconSearch} alt='' />
            <input
              className={style.inputSearch}
              type='text'
              value={searchTerm}
              onChange={handleSearchChange}
              placeholder='Buscar por nombre o apellido'
            />
          </div>
        </div>
      )}
      <div className={style.headerListPatient}>
        {selectedPatientId ? (
          <a href='#' onClick={handleBackClick} className={style.backLink}>
            Volver
          </a>
        ) : (
          <>
            <h1 className={style.textHeader}>Tus Pacientes</h1>
            <div className={style.buttonAdd} onClick={openModal}>
              <img className={style.iconAdd} src={icons.IconAdd} alt='' />
            </div>
          </>
        )}
      </div>
      <div className={style.patientsList}>
        {filteredPatients.length > 0 ? (
          <ul className={style.listPatients}>
            {selectedPatientId === null
              ? filteredPatients.map((patient) => (
                <li key={patient.id}>
                  <div
                    className={style.boardPatient}
                    onClick={() => handlePatientClick(patient.id)}
                    style={{
                      borderLeft:
                        windowWidth > 768 ? `5px solid ${getRandomColor()}` : 'none',
                      borderTop:
                        windowWidth <= 768 ? `5px solid ${getRandomColor()}` : 'none',
                    }}
                  >
                    <img className={style.photoPatient} src={images.PhotoDefault} alt='' />
                    <div className={style.divInfoPatient}>
                      <p>
                        Paciente: {patient.firstName} {patient.lastName}
                      </p>
                      <p>DNI: {patient.dni}</p>
                      <p>ID: {patient.id}</p>
                    </div>
                    <div className={style.divInfoPatient}>
                      <p>Dirección: {patient.address}</p>
                      <p>Tipo de sangre: {patient.bloodType}</p>
                      <p>Afiliación: no se donde sacar eso</p>
                    </div>
                    <div className={style.divInfoPatient}>
                      <p>Tutor: {patient.parentName}</p>
                      <p>Teléfono: {patient.phoneNumber}</p>
                      <p>Edad: {calculateAge(patient.birthDate)} años</p>
                    </div>
                  </div>
                </li>
              ))
              : patients
                .filter((patient) => patient.id === selectedPatientId)
                .map((patient) => (
                  <li key={patient.id}>
                    <div
                      className={style.boardPatient}
                      onClick={() => handlePatientClick(patient.id)}
                      style={{
                        borderLeft:
                          windowWidth > 768 ? `5px solid ${getRandomColor()}` : 'none',
                        borderTop:
                          windowWidth <= 768 ? `5px solid ${getRandomColor()}` : 'none',
                      }}
                    >
                      <img className={style.photoPatient} src={images.PhotoDefault} alt='' />
                      <div className={style.divInfoPatient}>
                        <p>
                          Paciente: {patient.firstName} {patient.lastName}
                        </p>
                        <p>DNI: {patient.dni}</p>
                        <p>ID: {patient.id}</p>
                      </div>
                      <div className={style.divInfoPatient}>
                        <p>Dirección: {patient.address}</p>
                        <p>Tipo de sangre: {patient.bloodType}</p>
                        <p>Afiliación: no se donde sacar eso</p>
                      </div>
                      <div className={style.divInfoPatient}>
                        <p>Tutor: {patient.parentName}</p>
                        <p>Teléfono: {patient.phoneNumber}</p>
                        <p>Edad: {calculateAge(patient.birthDate)} años</p>
                      </div>
                    </div>
                    {selectedPatientId === patient.id && (
                      <div className={style.treatmentContainer}>
                        <TreatmentPatient patientId={patient.id} />
                      </div>
                    )}
                  </li>
                ))}
          </ul>
        ) : (
          <p>No patients found</p>
        )}
      </div>
      <Modal isOpen={isModalOpen} closeModal={closeModal}>
        <AddPatient closeModal={closeModal} />
      </Modal>
    </div>
  )
}

export default ListPatientsMedic