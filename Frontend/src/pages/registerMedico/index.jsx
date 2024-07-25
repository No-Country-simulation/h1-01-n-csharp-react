import { useState } from 'react'
import RegisterForm from '../../components/FormRegister/index'
import images from '../../assets/images/images'
import style from './RegisterMedico.module.css'
import '../../index.css'

function RegisterMedico() {
    const [filledFields, setFilledFields] = useState({
        'Paso 1': false,
        'Paso 2': false,
        'Paso 3': false,
        'Paso 4': false,
        'Paso 5': false,
        'Paso 6': false
    });

    const handleFieldFilled = (fields) => {
        setFilledFields(fields)
    }

    const getStepStyle = (step) => {
        return filledFields[step] ? { backgroundColor: '#ff669c' } : {}
    }

    return (
        <div className='container'>
            <div className={style.containerStep}>
                <div className={style.step}>
                    <h1 className={style.stepTitle}>Completa tus datos</h1>
                    <div className={style.divStep}>
                        <div className={style.stepSecuence}>
                            <div className={style.circleStep} style={getStepStyle('Paso 1')}></div>
                            <div className={style.line}></div>
                        </div>
                        <p className={style.textStep}>Selecciona tu rol</p>
                    </div>
                    <div className={style.divStep}>
                        <div className={style.stepSecuence}>
                            <div className={style.circleStep} style={getStepStyle('Paso 2')}></div>
                            <div className={style.line}></div>
                        </div>
                        <p className={style.textStep}>Ingresa tu nombre y apellido</p>
                    </div>
                    <div className={style.divStep}>
                        <div className={style.stepSecuence}>
                            <div className={style.circleStep} style={getStepStyle('Paso 3')}></div>
                            <div className={style.line}></div>
                        </div>
                        <p className={style.textStep}>Ingresa tu DNI</p>
                    </div>
                    <div className={style.divStep}>
                        <div className={style.stepSecuence}>
                            <div className={style.circleStep} style={getStepStyle('Paso 4')}></div>
                            <div className={style.line}></div>
                        </div>
                        <p className={style.textStep}>Ingresa tu N° de licencia</p>
                    </div>
                    <div className={style.divStep}>
                        <div className={style.stepSecuence}>
                            <div className={style.circleStep} style={getStepStyle('Paso 5')}></div>
                            <div className={style.line}></div>
                        </div>
                        <p className={style.textStep}>Ingresa tu especialidad</p>
                    </div>
                    <div className={style.divStep}>
                        <div className={style.stepSecuence}>
                            <div className={style.circleStep} style={getStepStyle('Paso 6')}></div>
                            <div className={style.line}></div>
                        </div>
                        <p className={style.textStep}>Ingresa tu correo electronico</p>
                    </div>
                </div>
                <div className={style.divLogoStep}>
                    <img className={style.logoStep} src={images.LogoJustina} alt="" />
                </div>
            </div>
            <div className={style.containerFormRegisterMedico}>
                <RegisterForm onFieldFilled={handleFieldFilled} />
            </div>
        </div>
    )
}

export default RegisterMedico