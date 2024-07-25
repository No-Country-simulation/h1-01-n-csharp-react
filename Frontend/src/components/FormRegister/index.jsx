import { useState, useEffect } from 'react'
import PropTypes from 'prop-types'
import style from './FormRegister.module.css'
import '../../index.css'

function FormRegister({ onFieldFilled }) {
  const [rolId, setRolId] = useState('')
  const [name, setName] = useState('')
  const [surname, setSurname] = useState('')
  const [dni, setDni] = useState('')
  const [license, setLicense] = useState('')
  const [specialty, setSpecialty] = useState('')
  const [email, setEmail] = useState('')

  const [focusedField, setFocusedField] = useState('Selecciona tu rol')
  const [focusedStep, setFocusedStep] = useState('Paso 1')

  const handleFocus = (field) => {
    setFocusedField(field)
  }

  const handleStep = (step) => {
    setFocusedStep(step);
  }

  useEffect(() => {
    onFieldFilled({
      'Paso 1': rolId !== '',
      'Paso 2': name !== '' && surname !== '',
      'Paso 3': dni !== '',
      'Paso 4': license !== '',
      'Paso 5': specialty !== '',
      'Paso 6': email !== ''
    });
  }, [rolId, name, surname, dni, license, specialty, email, onFieldFilled])

  return (
    <div className={style.containerRegisterForm}>
      <p className={style.stepNumber}>{focusedStep}</p>
      <h1 className={style.stepText}>{focusedField}</h1>
      <form className="form">
        <div className="divInput" onFocus={() => handleStep('Paso 1')}>
          <label className="labelJustina" htmlFor="">Selecciona tu rol *</label>
          <select className={`${style.inputRegister} inputJustina`} value={rolId} onFocus={() => handleFocus('Selecciona tu rol')} onChange={(e) => setRolId(e.target.value)}>
            <option value="">Rol</option>
            <option value="1">Médico</option>
            <option value="2">Paciente</option>
          </select>
        </div>
        <div className="divInput" onFocus={() => handleStep('Paso 2')}>
          <label className="labelJustina" htmlFor="">Nombre *</label>
          <input className={`${style.inputRegister} inputJustina`} type="text" value={name} onFocus={() => handleFocus('Ingresa tu nombre')} onChange={(e) => setName(e.target.value)} />
        </div>
        <div className="divInput" onFocus={() => handleStep('Paso 2')}>
          <label className="labelJustina" htmlFor="">Apellido *</label>
          <input className={`${style.inputRegister} inputJustina`} type="text" value={surname} onFocus={() => handleFocus('Ingresa tu apellido')} onChange={(e) => setSurname(e.target.value)} />
        </div>
        <div className="divInput" onFocus={() => handleStep('Paso 3')}>
          <label className="labelJustina" htmlFor="">DNI *</label>
          <input className={`${style.inputRegister} inputJustina`} type="text" value={dni} onFocus={() => handleFocus('Ingresa tu DNI')} onChange={(e) => setDni(e.target.value)} />
        </div>
        <div className="divInput" onFocus={() => handleStep('Paso 4')}>
          <label className="labelJustina" htmlFor="">Nro de Licencia *</label>
          <input className={`${style.inputRegister} inputJustina`} type="text" value={license} onFocus={() => handleFocus('Ingresa tu numero de licencia')} onChange={(e) => setLicense(e.target.value)} />
        </div>
        <div className="divInput" onFocus={() => handleStep('Paso 5')}>
          <label className="labelJustina" htmlFor="">Especialidad *</label>
          <select className={`${style.inputRegister} inputJustina`} value={specialty} onFocus={() => handleFocus('Selecciona tu especialidad')} onChange={(e) => setSpecialty(e.target.value)}>
            <option value="">Especialidad</option>
          </select>
        </div>
        <div className="divInput" onFocus={() => handleStep('Paso 6')}>
          <label className="labelJustina" htmlFor="">Correo *</label>
          <input className={`${style.inputRegister} inputJustina`} type="email" value={email} onFocus={() => handleFocus('Ingresa tu correo')} onChange={(e) => setEmail(e.target.value)} />
        </div>
      </form>
      <div className={style.divButton}>
        <button className="buttonLogin">Guardar</button>
      </div>
    </div>
  )
}

FormRegister.propTypes = {
  onFieldFilled: PropTypes.string
}

export default FormRegister