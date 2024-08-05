import { useState } from 'react';
import PropTypes from 'prop-types';
import style from './AddPatient.module.css';
import icons from '../../assets/icons/icons';
import '../../index.css';

function AddPatient({ closeModal }) {
    const [formData, setFormData] = useState({
        firstName: '',
        lastName: '',
        dni: '',
        birthDate: '',
        phone: '',
        address: '',
        email: '',
        bloodType: '',
        diagnosis: '',
        allergies: '',
        diagnosisDate: '',
        insurance: '',
        treatment: ''
    })

    const handleChange = (e) => {
        const { name, value } = e.target
        setFormData({
            ...formData,
            [name]: value
        })
    }

    const handleSubmit = async (e) => {
        e.preventDefault();
        closeModal();
    }

    return (
        <div className={`container ${style.containerAddPatient}`}>
            <h1 className={style.titleAddPatient}>Crear paciente</h1>
            <form onSubmit={handleSubmit} className={style.formAddPatient}>
                <div className={style.divAddPatient}>
                    <h1 className={style.titleAddPatient}>Ingresa tus datos personales</h1>
                    <div className={style.divInfoPatient}>
                        {[
                            { label: 'Nombre', name: 'firstName', type: 'text' },
                            { label: 'Apellido', name: 'lastName', type: 'text' },
                            { label: 'DNI', name: 'dni', type: 'text' },
                            { label: 'Fecha de nacimiento', name: 'birthDate', type: 'date' },
                            { label: 'Telefono', name: 'phone', type: 'text' },
                            { label: 'Direccion', name: 'address', type: 'text' },
                            { label: 'Correo', name: 'email', type: 'text' },
                            { label: 'Grupo sanguineo', name: 'bloodType', type: 'text' }
                        ].map(({ label, name, type }) => (
                            <div className='divInput' key={name}>
                                <label className='labelJustina'>{label} *</label>
                                <input
                                    className={`inputJustina ${style.inputAddPatient}`}
                                    type={type}
                                    name={name}
                                    value={formData[name]}
                                    onChange={handleChange}
                                    required
                                />
                            </div>
                        ))}
                    </div>
                </div>
                <div className={style.divAddPatient}>
                    <h1 className={style.titleAddPatient}>Ingresa el historial medico</h1>
                    <div className={style.divInfoPatient}>
                        {[
                            { label: 'Diagnostico', name: 'diagnosis', type: 'text' },
                            { label: 'Alergias', name: 'allergies', type: 'text' },
                            { label: 'Fecha diagnostico', name: 'diagnosisDate', type: 'text' },
                            { label: 'Prepaga/Obra social', name: 'insurance', type: 'text' },
                            { label: 'Tratamiento', name: 'treatment', type: 'text' },
                            { label: 'Grupo sanguineo', name: 'bloodType', type: 'text' }
                        ].map(({ label, name, type }) => (
                            <div className='divInput' key={name}>
                                <label className='labelJustina'>{label} *</label>
                                <input
                                    className={`inputJustina ${style.inputAddPatient}`}
                                    type={type}
                                    name={name}
                                    value={formData[name]}
                                    onChange={handleChange}
                                    required
                                />
                            </div>
                        ))}
                    </div>
                </div>
                <button type="submit" className="buttonLogin">
                    <img src={icons.ArrowRight} alt="Arrow Right" />Guardar
                </button>
            </form>
        </div>
    )
}

AddPatient.propTypes = {
    closeModal: PropTypes.func.isRequired
}

export default AddPatient