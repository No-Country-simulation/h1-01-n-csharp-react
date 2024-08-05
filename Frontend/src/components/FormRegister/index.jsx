import useRegisterForm from '../../hooks/useRegisterForm'
import PropTypes from 'prop-types'
import { useRef } from 'react'
import style from './FormRegister.module.css'
import icons from '../../assets/icons/icons'
import '../../index.css'

function FormRegister({ userType, onFieldFilled = () => { } }) {
  const formRef = useRef(null)

  const {
    firstName, setFirstName,
    lastName, setLastName,
    dni, setDni,
    license, setLicense,
    specialtyId, setSpecialtyId,
    email, setEmail,
    password, setPassword,
    confirmPassword, setConfirmPassword,
    phoneNumber, setPhoneNumber,
    birthDate, setBirthDate,
    address, setAddress,
    bloodType, setBloodType,
    focusedField, handleFocus,
    focusedStep, handleStep,
    specialties,
    handleSubmit
  } = useRegisterForm(userType, onFieldFilled)

  const handleExternalSubmit = () => {
    if (formRef.current) {
      formRef.current.requestSubmit()
    }
  }

  return (
    <div className={style.containerRegisterForm}>
      <p className={style.stepNumber}>{focusedStep}</p>
      <h1 className={style.stepText}>{focusedField}</h1>
      <form className={`form ${style.formRegister}`} ref={formRef} onSubmit={handleSubmit}>
        <div className="divInput" onFocus={() => handleStep('Paso 1')}>
          <label className="labelJustina" htmlFor="">Nombre *</label>
          <input className={`${style.inputRegister} inputJustina`} type="text" value={firstName} onFocus={() => handleFocus('Ingresa tu nombre')} onChange={(e) => setFirstName(e.target.value)} />
        </div>
        <div className="divInput" onFocus={() => handleStep('Paso 1')}>
          <label className="labelJustina" htmlFor="">Apellido *</label>
          <input className={`${style.inputRegister} inputJustina`} type="text" value={lastName} onFocus={() => handleFocus('Ingresa tu apellido')} onChange={(e) => setLastName(e.target.value)} />
        </div>
        <div className="divInput" onFocus={() => handleStep('Paso 2')}>
          <label className="labelJustina" htmlFor="">DNI *</label>
          <input className={`${style.inputRegister} inputJustina`} type="text" value={dni} onFocus={() => handleFocus('Ingresa tu DNI')} onChange={(e) => setDni(e.target.value)} />
        </div>
        <div className="divInput" onFocus={() => handleStep('Paso 3')}>
          <label className="labelJustina" htmlFor="">Correo *</label>
          <input className={`${style.inputRegister} inputJustina`} type="email" value={email} onFocus={() => handleFocus('Ingresa tu correo')} onChange={(e) => setEmail(e.target.value)} />
        </div>
        <div className="divInput" onFocus={() => handleStep('Paso 4')}>
          <label className="labelJustina" htmlFor="">Contraseña *</label>
          <input className={`${style.inputRegister} inputJustina`} type="password" value={password} onFocus={() => handleFocus('Ingresa tu contraseña')} onChange={(e) => setPassword(e.target.value)} />
        </div>
        <div className="divInput" onFocus={() => handleStep('Paso 4')}>
          <label className="labelJustina" htmlFor="">Confirmar contraseña *</label>
          <input className={`${style.inputRegister} inputJustina`} type="password" value={confirmPassword} onFocus={() => handleFocus('Ingresa tu confirmación de contraseña')} onChange={(e) => setConfirmPassword(e.target.value)} />
        </div>
        <div className="divInput" onFocus={() => handleStep('Paso 5')}>
          <label className="labelJustina" htmlFor="">Teléfono *</label>
          <input className={`${style.inputRegister} inputJustina`} type="text" value={phoneNumber} onFocus={() => handleFocus('Ingresa tu teléfono')} onChange={(e) => setPhoneNumber(e.target.value)} />
        </div>

        {userType === 'Medic' && (
          <>
            <div className="divInput" onFocus={() => handleStep('Paso 6')}>
              <label className="labelJustina" htmlFor="">Nro de Licencia *</label>
              <input className={`${style.inputRegister} inputJustina`} type="text" value={license} onFocus={() => handleFocus('Ingresa tu número de licencia')} onChange={(e) => setLicense(e.target.value)} />
            </div>
            <div className="divInput" onFocus={() => handleStep('Paso 7')}>
              <label className="labelJustina" htmlFor="">Especialidad *</label>
              <select className={`${style.inputRegister} inputJustina`} value={specialtyId} onFocus={() => handleFocus('Selecciona tu especialidad')} onChange={(e) => setSpecialtyId(e.target.value)}>
                <option value="">Especialidad</option>
                {specialties.map((specialty) => (
                  <option key={specialty.id} value={specialty.id}>
                    {specialty.type}
                  </option>
                ))}
              </select>
            </div>
          </>
        )}

        {userType === 'Pacient' && (
          <>
            <div className="divInput" onFocus={() => handleStep('Paso 6')}>
              <label className="labelJustina" htmlFor="">Fecha de Nacimiento *</label>
              <input className={`${style.inputRegister} inputJustina`} type="date" value={birthDate} onFocus={() => handleFocus('Ingresa tu fecha de nacimiento')} onChange={(e) => setBirthDate(e.target.value)} />
            </div>
            <div className="divInput" onFocus={() => handleStep('Paso 7')}>
              <label className="labelJustina" htmlFor="">Dirección *</label>
              <input className={`${style.inputRegister} inputJustina`} type="text" value={address} onFocus={() => handleFocus('Ingresa tu dirección')} onChange={(e) => setAddress(e.target.value)} />
            </div>
            <div className="divInput" onFocus={() => handleStep('Paso 8')}>
              <label className="labelJustina" htmlFor="">Grupo Sanguíneo *</label>
              <input className={`${style.inputRegister} inputJustina`} type="text" value={bloodType} onFocus={() => handleFocus('Ingresa tu grupo sanguíneo')} onChange={(e) => setBloodType(e.target.value)} />
            </div>
          </>
        )}
      </form>
      <div className={style.divButton}>
        <button onClick={handleExternalSubmit} className="buttonLogin"><img src={icons.ArrowRight} alt="Guardar" />Guardar</button>
      </div>
    </div>
  )
}

FormRegister.propTypes = {
  userType: PropTypes.string.isRequired,
  onFieldFilled: PropTypes.func
}

export default FormRegister