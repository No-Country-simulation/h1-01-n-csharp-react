import PropTypes from 'prop-types'
import AddTreatment from '../AddTreatment/index'
import Modal from '../Modal/index'
import { useState, useEffect } from 'react'
import { getTreatments } from '../../api/medicService'
import style from './TreatmentPatient.module.css'
import icons from '../../assets/icons/icons'
import '../../index.css'

function TreatmentPatient({ patientId }) {
  const [isModalOpen, setIsModalOpen] = useState(false)
  const [treatments, setTreatments] = useState([])

  const openModal = () => {
    setIsModalOpen(true)
  }

  const closeModal = () => {
    setIsModalOpen(false)
  }

  useEffect(() => {
    const fetchTreatments = async () => {
      try {
        const allTreatments = await getTreatments()
        const filteredTreatments = allTreatments.filter(treatment => treatment.id === patientId)
        setTreatments(filteredTreatments)
      } catch (error) {
        console.error('Error fetching treatments:', error)
      }
    }

    fetchTreatments()
  }, [patientId])

  const hasTreatments = treatments.length > 0
  const firstTreatment = treatments[0] || {}
  const lastTreatment = treatments[treatments.length - 1] || {}

  const treatmentToShow = treatments.length === 1 ? firstTreatment : {}

  return (
    <div className={style.containerTreatment}>
      {hasTreatments ? (
        <>
          <div className={style.containerDiv}>
            <h1 className={style.titleTreatment}>Resumen historia clínica</h1>
            <div className={style.divTreatment}>
              <div className='divInput'>
                <label className='labelJustina' htmlFor="treatment1">Tratamiento *</label>
                <input className='inputJustina' type="text" id="treatment1" value={treatments.length === 1 ? treatmentToShow.name || '' : firstTreatment.name || ''} disabled />
              </div>
              <div className='divInput'>
                <label className='labelJustina' htmlFor="dosage1">Dosis *</label>
                <input className='inputJustina' type="text" id="dosage1" value={treatments.length === 1 ? treatmentToShow.medDosages?.[0]?.name || '' : firstTreatment.medDosages?.[0]?.name || ''} disabled />
              </div>
              <div className='divInput'>
                <label className='labelJustina' htmlFor="start1">Inicio *</label>
                <input className='inputJustina' type="date" id="start1" value={treatments.length === 1 ? treatmentToShow.startDate ? treatmentToShow.startDate.split('T')[0] : '' : firstTreatment.startDate ? firstTreatment.startDate.split('T')[0] : ''} disabled />
              </div>
              <div className='divInput'>
                <label className='labelJustina' htmlFor="end1">Fin *</label>
                <input className='inputJustina' type="date" id="end1" value={treatments.length === 1 ? treatmentToShow.endDate ? treatmentToShow.endDate.split('T')[0] : '' : firstTreatment.endDate ? firstTreatment.endDate.split('T')[0] : ''} disabled />
              </div>
              <div className='divInput'>
                <label className='labelJustina' htmlFor="instructions1">Indicaciones *</label>
                <input className='inputJustina' type="text" id="instructions1" value={treatments.length === 1 ? treatmentToShow.medDosages?.[0]?.instructions || '' : firstTreatment.medDosages?.[0]?.instructions || ''} disabled />
              </div>
            </div>
          </div>
          <div className={style.containerDiv}>
            <h1 className={style.titleTreatment}>Último tratamiento</h1>
            <div className={style.divTreatment}>
              <div className='divInput'>
                <label className='labelJustina' htmlFor="treatment2">Tratamiento *</label>
                <input className='inputJustina' type="text" id="treatment2" value={treatments.length === 1 ? treatmentToShow.name || '' : lastTreatment.name || ''} disabled />
              </div>
              <div className='divInput'>
                <label className='labelJustina' htmlFor="dosage2">Dosis *</label>
                <input className='inputJustina' type="text" id="dosage2" value={treatments.length === 1 ? treatmentToShow.medDosages?.[0]?.name || '' : lastTreatment.medDosages?.[0]?.name || ''} disabled />
              </div>
              <div className='divInput'>
                <label className='labelJustina' htmlFor="start2">Inicio *</label>
                <input className='inputJustina' type="date" id="start2" value={treatments.length === 1 ? treatmentToShow.startDate ? treatmentToShow.startDate.split('T')[0] : '' : lastTreatment.startDate ? lastTreatment.startDate.split('T')[0] : ''} disabled />
              </div>
              <div className='divInput'>
                <label className='labelJustina' htmlFor="end2">Fin *</label>
                <input className='inputJustina' type="date" id="end2" value={treatments.length === 1 ? treatmentToShow.endDate ? treatmentToShow.endDate.split('T')[0] : '' : lastTreatment.endDate ? lastTreatment.endDate.split('T')[0] : ''} disabled />
              </div>
              <div className='divInput'>
                <label className='labelJustina' htmlFor="instructions2">Indicaciones *</label>
                <input className='inputJustina' type="text" id="instructions2" value={treatments.length === 1 ? treatmentToShow.medDosages?.[0]?.instructions || '' : lastTreatment.medDosages?.[0]?.instructions || ''} disabled />
              </div>
            </div>
          </div>
          <div>
            <div className={style.containerDiv}>
              <h1 className={style.titlePatologies}>Patologías</h1>
              <div className={style.divTreatment}>
                <label>
                  En lista de espera
                  <input type="checkbox" name="waitingList" />
                </label>
                <label>
                  Es cruzado
                  <input type="checkbox" name="crossed" />
                </label>
                <label>
                  Confirmado
                  <input type="checkbox" name="confirmed" />
                </label>
              </div>
              <h1 className={style.titlePatologies}>Observaciones</h1>
              <div>
                <textarea className={style.textAreaObser} name="observations" id="observations"></textarea>
              </div>
            </div>
          </div>
        </>
      ) : (
        <div className={style.noTreatment}>
          <h1 className={style.textNoTreatment}>Sin historia clínica</h1>
          <div onClick={openModal} className={style.addTreatmentButton}><img className={style.iconAdd} src={icons.IconAdd} alt="" /></div>
        </div>
      )}
      <Modal isOpen={isModalOpen} closeModal={closeModal}>
        <AddTreatment closeModal={closeModal} />
      </Modal>
    </div>
  );
}

TreatmentPatient.propTypes = {
  patientId: PropTypes.string.isRequired
}

export default TreatmentPatient